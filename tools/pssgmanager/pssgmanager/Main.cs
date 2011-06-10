using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PSSGManager {
	public partial class Main : Form {
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
	}
}
