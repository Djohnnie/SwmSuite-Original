using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.Marquee {
	
	public partial class MarqueeButtonControl : UserControl {

		#region -_ Private Members _-

		private MarqueeScheme _scheme = new MarqueeScheme();
		private MarqueeRenderer _renderer = new MarqueeRenderer();
		private String _text;
		private bool _hovered;

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public MarqueeScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public MarqueeRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		public String Caption {
			get {
				return _text;
			}
			set {
				_text = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="MarqueeButtonControl"/> class.
		/// </summary>
		public MarqueeButtonControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		/// <summary>
		/// Handles the Paint event of the MarqueeButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void MarqueeButtonControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.RenderBackground( e.Graphics , this.ClientRectangle , this.Scheme );
			if( _hovered ) {
				this.Renderer.RenderShadowText( e.Graphics , this.ClientRectangle , this.Caption , this.Scheme );
			}
			this.Renderer.RenderButtonText( e.Graphics , this.ClientRectangle , this.Caption , this.Scheme );
		}

		/// <summary>
		/// Handles the SizeChanged event of the MarqueeButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MarqueeButtonControl_SizeChanged( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseEnter event of the MarqueeButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MarqueeButtonControl_MouseEnter( object sender , EventArgs e ) {
			_hovered = true;
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseLeave event of the MarqueeButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MarqueeButtonControl_MouseLeave( object sender , EventArgs e ) {
			_hovered = false;
			this.Invalidate();
		}

	}

}
