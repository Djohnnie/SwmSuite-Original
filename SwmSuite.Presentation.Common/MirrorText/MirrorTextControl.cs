using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.MirrorText {
	
	public partial class MirrorTextControl : UserControl {

		#region -_ Private Members _-

		private MirrorTextRenderer _renderer = new MirrorTextRenderer();
		private MirrorTextScheme _scheme = new MirrorTextScheme();
		private String _caption = "MirrorText";

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public MirrorTextRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public MirrorTextScheme Scheme {
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
				this.Renderer.Invalidate();
				this.Invalidate();
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MirrorTextControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
			this.BackColor = Color.Transparent;
		}

		#endregion

		private void MirrorTextControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.Render( e.Graphics , this.ClientRectangle , this.Caption , this.Scheme );
		}

		private void MirrorTextControl_SizeChanged( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

	}

}
