using System;
using System.Collections.Generic;
using System.Text;
using MiscUtil.IO;
using MiscUtil.Conversion;

namespace PSSGManager {
	class CPSSGFile {
		public string magic;
		public CNodeInfo[] nodeInfo;
		public CAttributeInfo[] attributeInfo;
		public CNode rootNode;

		public CPSSGFile(System.IO.Stream fileStream) {
			EndianBinaryReaderEx reader = new EndianBinaryReaderEx(new BigEndianBitConverter(), fileStream);

			magic = reader.ReadPSSGString(4);
			// TODO: Check magic
			int size = reader.ReadInt32();
			int attributeInfoCount = reader.ReadInt32();
			int nodeInfoCount = reader.ReadInt32();

			attributeInfo = new CAttributeInfo[attributeInfoCount];
			nodeInfo = new CNodeInfo[nodeInfoCount];

			for (int i = 0; i < nodeInfoCount; i++) {
				nodeInfo[i] = new CNodeInfo(reader, this);
			}

			rootNode = new CNode(reader, this);
		}


		public List<CNode> findNodes(string name) {
			return rootNode.findNodes(name);
		}

		public List<CNode> findNodes(string name, string attributeName, string attributeValue) {
			return rootNode.findNodes(name, attributeName, attributeValue);
		}
	}

	class CNodeInfo {
		public int id;
		public string name;
		public Dictionary<int, CAttributeInfo> attributeInfo;

		public CNodeInfo(EndianBinaryReaderEx reader, CPSSGFile file) {
			attributeInfo = new Dictionary<int, CAttributeInfo>();

			id = reader.ReadInt32();
			name = reader.ReadPSSGString();
			int attributeInfoCount = reader.ReadInt32();
			CAttributeInfo ai;
			for (int i = 0; i < attributeInfoCount; i++) {
				ai = new CAttributeInfo(reader);
				attributeInfo.Add(ai.id, ai);

				file.attributeInfo[ai.id - 1] = ai;
			}
		}
	}

	class CAttributeInfo {
		public int id;
		public string name;

		public CAttributeInfo(EndianBinaryReaderEx reader) {
			id = reader.ReadInt32();
			name = reader.ReadPSSGString();
		}
	}

	class CNode {
		public int id;
		public Dictionary<string, CAttribute> attributes;
		public CNode[] subNodes;
		public bool isDataNode = false;
		public byte[] data;
		public string name {
			get {
				return file.nodeInfo[id - 1].name;
			}
		}

		private CPSSGFile file;

		public CNode(EndianBinaryReaderEx reader, CPSSGFile file) {
			this.file = file;

			id = reader.ReadInt32();
			int size = reader.ReadInt32();
			long end = reader.BaseStream.Position + size;

			int attributeSize = reader.ReadInt32();
			long attributeEnd = reader.BaseStream.Position + attributeSize;
			// Each attr is at least 8 bytes (id + size), so take a conservative guess
			attributes = new Dictionary<string, CAttribute>();
			CAttribute attr;
			while (reader.BaseStream.Position < attributeEnd) {
				attr = new CAttribute(reader, file);
				attributes.Add(attr.name, attr);
			}

			switch (name) {
				case "BOUNDINGBOX":
				case "DATABLOCKDATA":
				case "DATABLOCKBUFFERED":
				case "INDEXSOURCEDATA":
				case "RENDERINTERFACEBOUNDBUFFERED":
				case "SHADERINPUT":
				case "TEXTUREIMAGEBLOCKDATA":
				case "TRANSFORM":
					isDataNode = true;
					break;
			}

			if (isDataNode) {
				data = reader.ReadBytes((int)(end - reader.BaseStream.Position));
			} else {
				// Each node at least 12 bytes (id + size + arg size)
				subNodes = new CNode[(end - reader.BaseStream.Position) / 12];
				int nodeCount = 0;
				while (reader.BaseStream.Position < end) {
					subNodes[nodeCount] = new CNode(reader, file);
					nodeCount++;
				}
				Array.Resize(ref subNodes, nodeCount);
			}
		}

		public List<CNode> findNodes(string nodeName) {
			return findNodes(nodeName, null, null);
		}

		public List<CNode> findNodes(string nodeName, string attributeName, string attributeValue) {
			List<CNode> ret = new List<CNode>();
			if (this.name == nodeName) {
				if (attributeName != null && attributeValue != null) {
					CAttribute attr;
					if (attributes.TryGetValue(attributeName, out attr) && attr.value == attributeValue) {
						ret.Add(this);
					}
				} else {
					ret.Add(this);
				}
			}
			if (subNodes != null) {
				foreach (CNode subNode in subNodes) {
					ret.AddRange(subNode.findNodes(nodeName, attributeName, attributeValue));
				}
			}
			return ret;
		}

		public override string ToString() { return name; }
	}

	class CAttribute {
		public int id;
		public object data;
		public string value {
			get {
				if (data is Int32) {
					return ((int)data).ToString();
				} else if (data is string) {
					return (string)data;
				}
				return "data";
			}
		}
		public string name {
			get {
				return file.attributeInfo[id - 1].name;
			}
		}
		public override string ToString() {
			return value;
		}

		private CPSSGFile file;

		public CAttribute(EndianBinaryReaderEx reader, CPSSGFile file) {
			this.file = file;

			id = reader.ReadInt32();
			int size = reader.ReadInt32();
			if (size == 4) {
				data = reader.ReadInt32();
				return;
			} else if (size > 4) {
				int strlen = reader.ReadInt32();
				if (size - 4 == strlen) {
					data = reader.ReadPSSGString(strlen);
					return;
				} else {
					reader.Seek(-4, System.IO.SeekOrigin.Current);
				}
			}
			data = reader.ReadBytes(size);
		}
	}

	class EndianBinaryReaderEx : EndianBinaryReader {
		public EndianBinaryReaderEx(EndianBitConverter bitConvertor, System.IO.Stream stream) : base(bitConvertor, stream) {
		}

		public string ReadPSSGString() {
			int length = this.ReadInt32();
			return this.ReadPSSGString(length);
		}
		public string ReadPSSGString(int length) {
			return Encoding.ASCII.GetString(this.ReadBytes(length));
		}
	}
}
