using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.Marquee {
	
	public partial class MarqueeControl : UserControl {

		#region -_ Private Members _-

		private MarqueeScheme _scheme = new MarqueeScheme();
		private MarqueeRenderer _renderer = new MarqueeRenderer();
		private String _text;

		private int _step;

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

		public String MarqueeText {
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
		/// Default constructor.
		/// </summary>
		public MarqueeControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Scheme.NeedsRedraw += new EventHandler<EventArgs>( Scheme_NeedsRedraw );
		}

		void Scheme_NeedsRedraw( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Resets this instance.
		/// </summary>
		public void Reset() {
			_step = this.Width;
		}

		#endregion

		private void timer_Tick( object sender , EventArgs e ) {
			this.Invalidate();
			_step -= 2;
			if( _step < -( this.ClientRectangle.Width + ( this.Renderer.GetTextWidth( this.CreateGraphics() , this.MarqueeText , this.Scheme ) - this.ClientRectangle.Width ) ) ) {
				_step = this.ClientRectangle.Width;
			}
		}

		private void MarqueeControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.RenderBackground( e.Graphics , this.ClientRectangle , this.Scheme );
			e.Graphics.TranslateTransform( (float)_step , 0.0f );
			this.Renderer.RenderText( e.Graphics , this.ClientRectangle , this.MarqueeText , this.Scheme );
			e.Graphics.ResetTransform();
		}

		private void MarqueeControl_SizeChanged( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

	}

}
