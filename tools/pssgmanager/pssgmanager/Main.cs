using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Text;
using System.Windows.Forms;
using FreeImageAPI;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace PSSGManager {
	public partial class Main : Form {
		private CPSSGFile pssgFile;
		private Model[] models;

		public Main() {
			InitializeComponent();
			modelView1.InitialiseGraphics();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "PSSG files|*.pssg|All files|*.*";
			dialog.Title = "Select a PSSG file";
			if (dialog.ShowDialog() == DialogResult.OK) {
				closeFile();
				StreamReader sr = new StreamReader(dialog.FileName);
				CPSSGFile f = new CPSSGFile(sr.BaseStream);
				pssgFile = f;
				treeView.Nodes.Add(createTreeViewNode(f.rootNode));
				createTreeViewTexturesList(f.rootNode);

				listBox1.Items.Clear();
				List<CNode> rdsNodes = f.findNodes("RENDERDATASOURCE");
				models = new Model[rdsNodes.Count];
				int i = 0;
				foreach (CNode rdsNode in rdsNodes)
				{
					List<CNode> dbNodes = f.findNodes("DATABLOCK", "id", rdsNode.subNodes[1].attributes["dataBlock"].value.Substring(1));
					if (dbNodes.Count == 1)
					{
						models[i] = createModelFromNodes(rdsNode, dbNodes[0]);
						listBox1.Items.Add(models[i]);
						i++;
					}
					else
					{
						// TODO: *shrug*
					}
				}
			}
			else
			{

			}
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
			closeFile();
		}

		private void closeFile() {
			if (this.pssgFile == null) return;

			// All tab
			treeView.Nodes.Clear();
			dataGridViewAttributes.Rows.Clear();

			// Models tab
			listBox1.Items.Clear();


			pssgFile = null;
		}

		private Model createModelFromNodes(CNode rdsNode, CNode dbNode) {
			MiscUtil.Conversion.BigEndianBitConverter bc = new MiscUtil.Conversion.BigEndianBitConverter();
			CustomVertex.PositionNormalColored[] vertices = new CustomVertex.PositionNormalColored[(int)dbNode.attributes["elementCount"].data];

			Vector3 pos = new Vector3();
			int color;
			Vector3 normal = new Vector3();
			int vertexCount = 0;
			for (int i = 0; i < (int)dbNode.attributes["size"].data; i += 28) {
				pos.X = bc.ToSingle(dbNode.subNodes[3].data, i);
				pos.Y = bc.ToSingle(dbNode.subNodes[3].data, i + 4);
				pos.Z = bc.ToSingle(dbNode.subNodes[3].data, i + 8);

				color = bc.ToInt32(dbNode.subNodes[3].data, i + 12);

				normal.X = bc.ToSingle(dbNode.subNodes[3].data, i + 16);
				normal.Y = bc.ToSingle(dbNode.subNodes[3].data, i + 20);
				normal.Z = bc.ToSingle(dbNode.subNodes[3].data, i + 24);

				vertices[vertexCount] = new CustomVertex.PositionNormalColored(pos, normal, color);
				vertexCount++;
			}

			int indexCount = (int)rdsNode.subNodes[0].attributes["count"].data;
			ushort[] indices = new ushort[indexCount];
			for (int i = 0; i < indexCount; i++) {
				indices[i] = bc.ToUInt16(rdsNode.subNodes[0].subNodes[0].data, i * 2);
			}
			return new Model(rdsNode.attributes["id"].value, vertices, indices);
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

		private void createTreeViewTexturesList(CNode node)
		{
			if (node.name == "TEXTURE")
			{
				TreeNode treeNode = new TreeNode();
				treeNode.Text = node.attributes["id"].value;
				treeNode.Tag = node;
				treeViewTextures.Nodes.Add(treeNode);
			}
			if (node.subNodes != null)
			{
				foreach (CNode subNode in node.subNodes)
				{
					createTreeViewTexturesList(subNode);
				}
			}
		}

		private void treeViewTextures_AfterSelect(object sender, TreeViewEventArgs e)
		{
			int height = 0; int width = 0;
			pictureBoxTextures.Dock = DockStyle.Fill;
			height = pictureBoxTextures.Height;
			width = pictureBoxTextures.Width;
			writeDDS(Application.StartupPath + "\\temp.dds");
			FREE_IMAGE_FORMAT format = FREE_IMAGE_FORMAT.FIF_DDS;
			System.Drawing.Bitmap image = FreeImage.LoadBitmap(Application.StartupPath + "\\temp.dds", FREE_IMAGE_LOAD_FLAGS.DEFAULT, ref format);
			if (image.Height <= height && image.Width <= width)
			{
				pictureBoxTextures.Dock = DockStyle.None;
				pictureBoxTextures.Width = image.Width;
				pictureBoxTextures.Height = image.Height;
			}
			pictureBoxTextures.Image = image;
		}

        private void writeDDS(string ddsPath)
        {
            byte[] ddh;
            CNode node = ((CNode)treeViewTextures.SelectedNode.Tag);
            using (BinaryReader b = new BinaryReader(File.Open(Application.StartupPath + "\\dxt.ddh", FileMode.Open)))
            {
                ddh = b.ReadBytes(128);
            }
            using (BinaryWriter b = new BinaryWriter(File.Open(ddsPath, FileMode.Create)))
            {
                b.Write(ddh);
                b.Write(node.subNodes[0].subNodes[0].data);
            }
			using (Stream outStream = File.Open(ddsPath, FileMode.Open))
			{
				outStream.Seek(12, SeekOrigin.Begin);
				// Change Height and Width
				outStream.Write(BitConverter.GetBytes((int)node.attributes["height"].data), 0, 4);
				outStream.Write(BitConverter.GetBytes((int)node.attributes["width"].data), 0, 4);
				// Change size
				switch ((string)node.attributes["texelFormat"].data)
				{
					case "dxt1":
						outStream.Write(BitConverter.GetBytes(((int)node.attributes["width"].data) * ((int)node.attributes["height"].data) / 2), 0, 4);
						break;
					default:
						outStream.Write(BitConverter.GetBytes(((int)node.attributes["width"].data) * ((int)node.attributes["height"].data)), 0, 4);
						break;
				}
				// Skip 4
				outStream.Seek(4, SeekOrigin.Current);
				// Change numberMipMapLevels + 1
				outStream.Write(BitConverter.GetBytes((int)node.attributes["numberMipMapLevels"].data + 1), 0, 4);
				// Skip 52
				outStream.Seek(52, SeekOrigin.Current);
				// Change Format
				outStream.Write(Encoding.UTF8.GetBytes(((string)node.attributes["texelFormat"].data).ToUpper()), 0, 4);
			}
        }
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			modelView1.RenderModel((Model)listBox1.SelectedItem);
		}
	}
}
