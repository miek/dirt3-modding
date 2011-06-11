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

			device.DeviceReset += new EventHandler(this.OnDeviceReset);

			OnDeviceReset(device, null);

			initialised = true;
		}

		public void OnDeviceReset(object sender, EventArgs e) {
			device = sender as Device;
		}

		public void Render() {
			CustomVertex.TransformedColored[] vertexes = new CustomVertex.TransformedColored[3];

			vertexes[0].Position = new Vector4(50, 50, 0, 1.0f);
			vertexes[0].Color = System.Drawing.Color.FromArgb(0, 255, 0).ToArgb();

			vertexes[1].Position = new Vector4(500, 50, 0, 1.0f);
			vertexes[1].Color = System.Drawing.Color.FromArgb(0, 0, 255).ToArgb();

			vertexes[2].Position = new Vector4(50, 250, 0, 1.0f);
			vertexes[2].Color = System.Drawing.Color.FromArgb(255, 0, 0).ToArgb();

			device.VertexFormat = CustomVertex.TransformedColored.Format;
			device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, vertexes);
		}

		protected override void OnPaint(PaintEventArgs e) {
			if (device == null) {
				e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, Width, Height));
				return;
			}

			device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Blue, 1.0f, 0);
			device.BeginScene();
			Render();
			device.EndScene();
			device.Present();
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
}
