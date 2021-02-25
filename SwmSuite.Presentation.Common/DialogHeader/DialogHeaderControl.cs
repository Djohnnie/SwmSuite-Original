using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.Design;

namespace SwmSuite.Presentation.Common.DialogHeader {

	[Designer( typeof( ParentControlDesigner ) )]
	public partial class DialogHeaderControl : UserControl {

		#region -_ Private Members _-

		private DialogHeaderScheme _scheme = new DialogHeaderScheme();
		private DialogHeaderRenderer _renderer = new DialogHeaderRenderer();
		private String _mainText;
		private String _subText;
		private bool _onlyMainTitle = false;

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public DialogHeaderScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public DialogHeaderRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		public String MainText {
			get {
				return _mainText;
			}
			set {
				_mainText = value;
				this.Renderer.Invalidate();
				this.Invalidate();
			}
		}

		public String SubText {
			get {
				return _subText;
			}
			set {
				_subText = value;
				this.Renderer.Invalidate();
				this.Invalidate();
			}
		}

		public bool OnlyMainText {
			get {
				return _onlyMainTitle;
			}
			set {
				_onlyMainTitle = value;
				this.Renderer.Invalidate();
				this.Invalidate();
			}
		}

		#endregion

		#region -_ Construction _-

		public DialogHeaderControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Scheme.NeedsRedraw += new EventHandler<EventArgs>( Scheme_NeedsRedraw );
		}

		#endregion

		#region -_ Event Handling _-

		private void DialogHeaderControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.RenderBackground( e.Graphics , this.ClientRectangle , this.Scheme );
			this.Renderer.RenderTitle( e.Graphics , this.ClientRectangle , this.Scheme , this.MainText , this.SubText , this.OnlyMainText );
		}

		private void Scheme_NeedsRedraw( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			Invalidate();
			MessageBox.Show( "Scheme_NeedsRedraw" );
		}

		#endregion

		private void DialogHeaderControl_Resize( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
		}

		#region -_ Public Methods _-

		#endregion

		#region -_ Private Methods _-

		#endregion

	}

}
