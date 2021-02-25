using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace SwmSuite.Presentation.Common {

	public partial class ButtonControl : Button {

		#region -_ Private Members _-

		private ButtonRenderer _renderer = new ButtonRenderer();
		private ButtonScheme _schemeNormal;
		private ButtonScheme _schemeHovered;
		private ButtonScheme _schemePushed;
		private ButtonScheme _schemeDisabled;
		private ButtonState _state = ButtonState.Normal;
		private String _caption;

		#endregion

		#region -_ Public Properties _-

		public ButtonRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ButtonScheme SchemeNormal {
			get {
				return _schemeNormal;
			}
			set {
				_schemeNormal = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ButtonScheme SchemeHovered {
			get {
				return _schemeHovered;
			}
			set {
				_schemeHovered = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ButtonScheme SchemePushed {
			get {
				return _schemePushed;
			}
			set {
				_schemePushed = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ButtonScheme SchemeDisabled {
			get {
				return _schemeDisabled;
			}
			set {
				_schemeDisabled = value;
			}
		}

		public ButtonScheme Scheme {
			get {
				switch( this.State ) {
					case ButtonState.Hovered: {
						return this.SchemeHovered;
					}
					case ButtonState.Pushed: {
						return this.SchemePushed;
					}
					case ButtonState.Disabled: {
						return this.SchemeDisabled;
					}
					default: {
						return this.SchemeNormal;
					}
				}
			}
		}

		public ButtonState State {
			get {
				return _state;
			}
			set {
				_state = value;
			}
		}

		/// <summary>
		/// Gets or sets the caption.
		/// </summary>
		/// <value>The caption.</value>
		public String Caption {
			get {
				return _caption;
			}
			set {
				_caption = value;
			}
		}

		/// <summary>
		/// Gets or sets the image that is displayed on this button control.
		/// </summary>
		public Image Picture { get; set; }

		#endregion

		#region -_ Construction _-

		public ButtonControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.SchemeNormal = new ButtonScheme(
				Color.FromArgb( 64 , 64 , 64 ) ,
				Color.FromArgb( 255 , 255 , 255 ) ,
				Color.FromArgb( 237 , 237 , 237 ) ,
				LinearGradientMode.Vertical ,
				Color.FromArgb( 0 , 0 , 0 ) ,
				new Font( "Verdana" , 10.0f , FontStyle.Regular ) ,
				new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center } ,
				TextRenderingHint.ClearTypeGridFit
			);
			this.SchemeHovered = new ButtonScheme(
				Color.FromArgb( 64 , 64 , 64 ) ,
				Color.FromArgb( 246 , 251 , 253 ) ,
				Color.FromArgb( 213 , 239 , 252 ) ,
				LinearGradientMode.Vertical ,
				Color.FromArgb( 0 , 0 , 0 ) ,
				new Font( "Verdana" , 10.0f , FontStyle.Regular ) ,
				new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center } ,
				TextRenderingHint.ClearTypeGridFit
			);
			this.SchemePushed = new ButtonScheme(
				Color.FromArgb( 64 , 64 , 64 ) ,
				Color.FromArgb( 214 , 214 , 214 ) ,
				Color.FromArgb( 231 , 231 , 231 ) ,
				LinearGradientMode.Vertical ,
				Color.FromArgb( 0 , 0 , 0 ) ,
				new Font( "Verdana" , 10.0f , FontStyle.Regular ) ,
				new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center } ,
				TextRenderingHint.ClearTypeGridFit
			);
			this.SchemeDisabled = new ButtonScheme(
				Color.FromArgb( 200 , 200 , 200 ) ,
				Color.FromArgb( 255 , 255 , 255 ) ,
				Color.FromArgb( 237 , 237 , 237 ) ,
				LinearGradientMode.Vertical ,
				Color.FromArgb( 200 , 200 , 200 ) ,
				new Font( "Verdana" , 10.0f , FontStyle.Regular ) ,
				new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center } ,
				TextRenderingHint.ClearTypeGridFit
			);
		}

		#endregion

		#region -_ EventHandling _-

		/// <summary>
		/// Handles the Paint event of the ButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void ButtonControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.RenderBackground( e.Graphics , this.ClientRectangle , this.Scheme );
			this.Renderer.RenderBorder( e.Graphics , this.ClientRectangle , this.Scheme );
			this.Renderer.RenderCaption( e.Graphics , this.ClientRectangle , this.Caption , this.Scheme );
			if( this.Picture != null ) {
				this.Renderer.RenderImage( e.Graphics , this.ClientRectangle , this.Picture );
			}
		}

		/// <summary>
		/// Handles the MouseEnter event of the ButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void ButtonControl_MouseEnter( object sender , EventArgs e ) {
			if( this.State != ButtonState.Disabled ) {
				this.State = ButtonState.Hovered;
			}
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseLeave event of the ButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void ButtonControl_MouseLeave( object sender , EventArgs e ) {
			if( this.State != ButtonState.Disabled ) {
				this.State = ButtonState.Normal;
			}
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseDown event of the ButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void ButtonControl_MouseDown( object sender , MouseEventArgs e ) {
			if( this.State != ButtonState.Disabled ) {
				this.State = ButtonState.Pushed;
			}
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseUp event of the ButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void ButtonControl_MouseUp( object sender , MouseEventArgs e ) {
			if( this.State != ButtonState.Disabled ) {
				this.State = ButtonState.Hovered;
			}
			this.Invalidate();
		}

		/// <summary>
		/// Handles the EnabledChanged event of the ButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void ButtonControl_EnabledChanged( object sender , EventArgs e ) {
			if( this.Enabled ) {
				this.State = ButtonState.Normal;
			} else {
				this.State = ButtonState.Disabled;
			}
			this.Renderer.Invalidate();
			Invalidate();
		}

		#endregion

	}

}