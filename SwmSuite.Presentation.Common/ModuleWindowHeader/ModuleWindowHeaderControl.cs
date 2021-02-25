using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SwmSuite.Presentation.Common.ModuleWindowHeader {

	[Designer( typeof( ParentControlDesigner ) )]
	public partial class ModuleWindowHeaderControl : UserControl {
		
		#region -_ Private Members _-

		private ModuleWindowHeaderRenderer _renderer = new ModuleWindowHeaderRenderer();
		
		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ModuleWindowHeaderRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ModuleWindowHeaderControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		private void ModuleWindowHeaderControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.Render( e.Graphics , this.ClientRectangle );
		}
	}
}
