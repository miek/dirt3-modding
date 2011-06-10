using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace PSSGManager {
	public abstract partial class ModelView : UserControl {
		protected Device device = null;

		protected bool initialised = false;
		public bool Initialised {
			get { return initialised; }
		}

		public virtual void InitialiseGraphics() {
			PresentParameters pp = new PresentParameters();
		}
	}
}
