using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace PSSGManager {
	public class ModelView : UserControl {
		protected Device device = null;
		private System.Diagnostics.Process process1;
		private Model model;
		private VertexBuffer vertexBuffer;
		private IndexBuffer indexBuffer;

		protected bool initialised = false;
		public bool Initialised {
			get { return initialised; }
		}

		public void InitialiseGraphics() {
			PresentParameters pp = new PresentParameters();
			pp.Windowed = true;
			pp.SwapEffect = SwapEffect.Discard;
			pp.EnableAutoDepthStencil = true;
			pp.AutoDepthStencilFormat = DepthFormat.D16;
			pp.DeviceWindowHandle = this.Handle;

			device = new Device(0, DeviceType.Hardware, this, CreateFlags.HardwareVertexProcessing, pp);
			//device.RenderState.FillMode = FillMode.WireFrame;

			device.DeviceReset += new EventHandler(this.OnDeviceReset);

			OnDeviceReset(device, null);

			initialised = true;
		}

		public void OnDeviceReset(object sender, EventArgs e) {
			device = sender as Device;
		}

		private void Render() {
			/*CustomVertex.TransformedColored[] vertexes = new CustomVertex.TransformedColored[3];

			vertexes[0].Position = new Vector4(50, 50, 0, 1.0f);
			vertexes[0].Color = System.Drawing.Color.FromArgb(0, 255, 0).ToArgb();

			vertexes[1].Position = new Vector4(500, 50, 0, 1.0f);
			vertexes[1].Color = System.Drawing.Color.FromArgb(0, 0, 255).ToArgb();

			vertexes[2].Position = new Vector4(50, 250, 0, 1.0f);
			vertexes[2].Color = System.Drawing.Color.FromArgb(255, 0, 0).ToArgb();

			device.VertexFormat = CustomVertex.TransformedColored.Format;
			device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, vertexes);*/

			device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.White, 1.0f, 0);
			device.BeginScene();

			device.VertexFormat = CustomVertex.PositionNormalColored.Format;
			device.SetStreamSource(0, vertexBuffer, 0);
			device.Indices = indexBuffer;

			device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, model.vertices.Length, 0, model.indices.Length / 3);

			device.EndScene();
			device.Present();
		}

		public void RenderModel(Model model) {
			this.model = model;
			vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionNormalColored), model.vertices.Length,
										device, Usage.Dynamic | Usage.WriteOnly, CustomVertex.PositionNormalColored.Format, Pool.Default);
			vertexBuffer.SetData(model.vertices, 0, LockFlags.None);

			indexBuffer = new IndexBuffer(typeof(ushort), model.indices.Length, device, Usage.WriteOnly, Pool.Default);
			indexBuffer.SetData(model.indices, 0, LockFlags.None);

			device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, this.Width / this.Height, 1f, 50f);
			device.Transform.View = Matrix.LookAtLH(new Vector3(-3, 3, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
			device.RenderState.Lighting = true;
			device.Lights[0].Type = LightType.Directional;
			device.Lights[0].Diffuse = Color.White;
			device.Lights[0].Direction = new Vector3(3, -3, -3);
			device.Lights[0].Position = new Vector3(-3, 3, 3);
			device.Lights[0].Enabled = true;

			Render();
		}

		protected override void OnPaint(PaintEventArgs e) {
			if (device == null || model == null) {
				e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, Width, Height));
				return;
			}

			Render();
		}

		protected override void OnPaintBackground(PaintEventArgs e) {
		}

		protected override void OnSizeChanged(EventArgs e) {
			Invalidate();
		}

		private void InitializeComponent() {
			this.process1 = new System.Diagnostics.Process();
			this.SuspendLayout();
			// 
			// process1
			// 
			this.process1.StartInfo.Domain = "";
			this.process1.StartInfo.LoadUserProfile = false;
			this.process1.StartInfo.Password = null;
			this.process1.StartInfo.StandardErrorEncoding = null;
			this.process1.StartInfo.StandardOutputEncoding = null;
			this.process1.StartInfo.UserName = "";
			this.process1.SynchronizingObject = this;
			// 
			// ModelView
			// 
			this.Name = "ModelView";
			this.ResumeLayout(false);

		}
	}

	public class Model {
		public string name;
		public CustomVertex.PositionNormalColored[] vertices;
		public ushort[] indices;

		public Model(string name, CustomVertex.PositionNormalColored[] vertices, ushort[] indices) {
			this.name = name;
			this.vertices = vertices;
			this.indices = indices;
		}

		public override string ToString() {
			return name;
		}
	}
}

