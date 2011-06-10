using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Text;
using System.Windows.Forms;

namespace PSSGManager {
	public partial class Main : Form {
		private CPSSGFile pssgFile;

		public Main() {
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "PSSG files|*.pssg|All files|*.*";
			dialog.Title = "Select a PSSG file";
			if (dialog.ShowDialog() == DialogResult.OK) {
				StreamReader sr = new StreamReader(dialog.FileName);
				CPSSGFile f = new CPSSGFile(sr.BaseStream);
				pssgFile = f;
				treeView.Nodes.Add(createTreeViewNode(f.rootNode));
			} else {

			}
		}

		private TreeNode createTreeViewNode(CNode node) {
			TreeNode treeNode = new TreeNode();
			treeNode.Text = node.name;
			treeNode.Tag = node;
			if (node.subNodes != null) {
				foreach (CNode subNode in node.subNodes) {
					treeNode.Nodes.Add(createTreeViewNode(subNode));
				}
			}
			return treeNode;
		}

		private void treeView_AfterSelect(object sender, TreeViewEventArgs e) {
			if (treeView.SelectedNode != null) {
				dataGridViewAttributes.Rows.Clear();
				foreach (KeyValuePair<string, CAttribute> pair in ((CNode)treeView.SelectedNode.Tag).attributes) {
					dataGridViewAttributes.Rows.Add(pair.Key, pair.Value);
				}
			}
		}

		private void buttonExportAll_Click(object sender, EventArgs e) {
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "XML files|*.xml|All files|*.*";
			dialog.Title = "Select location to save XML output";
			if (dialog.ShowDialog() == DialogResult.OK) {
				XmlWriterSettings settings = new XmlWriterSettings();
				settings.Indent = true;
				using (XmlWriter writer = XmlWriter.Create(dialog.FileName, settings)) {
					writer.WriteStartDocument();
					writeNodesToXml(writer, pssgFile.rootNode);
					writer.WriteEndDocument();
				}
			}
		}

		private void writeNodesToXml(XmlWriter writer, CNode node) {
			writer.WriteStartElement(node.name.ToLower());
			foreach (KeyValuePair<string, CAttribute> pair in node.attributes) {
				writer.WriteElementString(pair.Key, pair.Value.ToString());
			}
			if (node.subNodes != null) {
				foreach (CNode subNode in node.subNodes) {
					writeNodesToXml(writer, subNode);
				}
			}
			writer.WriteEndElement();
		}
	}
}
