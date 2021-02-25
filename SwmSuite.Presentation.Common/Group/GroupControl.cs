using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SwmSuite.Presentation.Common.Group {

	[Designer( typeof( ParentControlDesigner ) )]
	public partial class GroupControl : UserControl {

		#region -_ Private Members _-

		private GroupRenderer _renderer = new GroupRenderer();
		private GroupScheme _scheme = new GroupScheme();
		private String _caption = "GroupControl";

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public GroupRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public GroupScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		public String Caption {
			get {
				return _caption;
			}
			set {
				_caption = value;
			}
		}

		#endregion

		#region -_ Construction _-

		public GroupControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		private void GroupControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.Render( e.Graphics , this.ClientRectangle , this.Caption , this.Scheme );
		}

		private void GroupControl_SizeChanged( object sender , EventArgs e ) {

		}

	}

}
