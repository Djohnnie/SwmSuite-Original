using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SwmSuite.Presentation.Common.WindowPanel {

	[Designer( typeof( ParentControlDesigner ) )]
	public partial class WindowPanelControl : UserControl {

		#region -_ Private Members _-

		private WindowPanelRenderer _renderer = new WindowPanelRenderer();
		private WindowPanelScheme _scheme = new WindowPanelScheme();

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public WindowPanelRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public WindowPanelScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public WindowPanelControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
			this.BackColor = Color.Transparent;
		}

		#endregion

		private void WindowPanelControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.Render( e.Graphics , this.ClientRectangle , this.Scheme );
		}



	}

}
