using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.PopUpButton {

	public partial class PopUpButtonControl : Button {

		#region -_ Private Members _-

		private PopUpButtonRenderer _renderer = new PopUpButtonRenderer();
		private PopUpButtonScheme _schemeNormal;
		private PopUpButtonScheme _schemeHovered;
		private PopUpButtonScheme _schemePushed;
		private PopUpButtonScheme _schemeDisabled;
		private PopUpButtonState _state = PopUpButtonState.Normal;
		private String _caption;
		private String _subCaption;

		#endregion

		#region -_ Public Properties _-

		public PopUpButtonRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public PopUpButtonScheme SchemeNormal {
			get {
				return _schemeNormal;
			}
			set {
				_schemeNormal = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public PopUpButtonScheme SchemeHovered {
			get {
				return _schemeHovered;
			}
			set {
				_schemeHovered = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public PopUpButtonScheme SchemePushed {
			get {
				return _schemePushed;
			}
			set {
				_schemePushed = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public PopUpButtonScheme SchemeDisabled {
			get {
				return _schemeDisabled;
			}
			set {
				_schemeDisabled = value;
			}
		}

		public PopUpButtonScheme Scheme {
			get {
				switch( this.State ) {
					case PopUpButtonState.Hovered: {
							return this.SchemeHovered;
						}
					case PopUpButtonState.Pushed: {
							return this.SchemePushed;
						}
					case PopUpButtonState.Disabled: {
							return this.SchemeDisabled;
						}
					default: {
							return this.SchemeNormal;
						}
				}
			}
		}

		public PopUpButtonState State {
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
		/// Gets or sets the sub caption.
		/// </summary>
		/// <value>The caption.</value>
		public String SubCaption {
			get {
				return _subCaption;
			}
			set {
				_subCaption = value;
			}
		}

		/// <summary>
		/// Gets or sets the image that is displayed on this button control.
		/// </summary>
		public Image Picture { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="PopUpButtonControl"/> class.
		/// </summary>
		public PopUpButtonControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.SchemeNormal = new PopUpButtonScheme(
				Color.FromArgb( 64 , 64 , 64 ) ,
				Color.Transparent ,
				Color.Transparent ,
				LinearGradientMode.Vertical ,
				Color.FromArgb( 0 , 0 , 0 ) ,
				Color.FromArgb( 0 , 0 , 0 ) ,
				new Font( "Verdana" , 10.0f , FontStyle.Regular ) ,
				new Font( "Verdana" , 8.0f , FontStyle.Regular ) ,
				new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center } ,
				TextRenderingHint.ClearTypeGridFit
			);
			this.SchemeHovered = new PopUpButtonScheme(
				Color.FromArgb( 64 , 64 , 64 ) ,
				Color.FromArgb( 246 , 251 , 253 ) ,
				Color.FromArgb( 213 , 239 , 252 ) ,
				LinearGradientMode.Vertical ,
				Color.FromArgb( 0 , 0 , 0 ) ,
				Color.FromArgb( 0 , 0 , 0 ) ,
				new Font( "Verdana" , 10.0f , FontStyle.Regular ) ,
				new Font( "Verdana" , 8.0f , FontStyle.Regular ) ,
				new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center } ,
				TextRenderingHint.ClearTypeGridFit
			);
			this.SchemePushed = new PopUpButtonScheme(
				Color.FromArgb( 64 , 64 , 64 ) ,
				Color.FromArgb( 214 , 214 , 214 ) ,
				Color.FromArgb( 231 , 231 , 231 ) ,
				LinearGradientMode.Vertical ,
				Color.FromArgb( 0 , 0 , 0 ) ,
				Color.FromArgb( 0 , 0 , 0 ) ,
				new Font( "Verdana" , 10.0f , FontStyle.Regular ) ,
				new Font( "Verdana" , 8.0f , FontStyle.Regular ) ,
				new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center } ,
				TextRenderingHint.ClearTypeGridFit
			);
			this.SchemeDisabled = new PopUpButtonScheme(
				Color.FromArgb( 200 , 200 , 200 ) ,
				Color.FromArgb( 255 , 255 , 255 ) ,
				Color.FromArgb( 237 , 237 , 237 ) ,
				LinearGradientMode.Vertical ,
				Color.FromArgb( 200 , 200 , 200 ) ,
				Color.FromArgb( 200 , 200 , 200 ) ,
				new Font( "Verdana" , 10.0f , FontStyle.Regular ) ,
				new Font( "Verdana" , 8.0f , FontStyle.Regular ) ,
				new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center } ,
				TextRenderingHint.ClearTypeGridFit
			);
		}

		#endregion

		/// <summary>
		/// Handles the Paint event of the PopUpButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void PopUpButtonControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.RenderBackground( e.Graphics , this.ClientRectangle , this.Scheme );
			this.Renderer.RenderBorder( e.Graphics , this.ClientRectangle , this.Scheme );
			Rectangle captionRectangle = new Rectangle( this.ClientRectangle.Left + 5 , this.ClientRectangle.Top + 5 , this.ClientRectangle.Width - 10 , (int)( (float)this.Scheme.CaptionFont.Height * 1.5f ) );
			Rectangle subCaptionRectangle = new Rectangle( captionRectangle.Left , captionRectangle.Bottom + 5 , captionRectangle.Width , this.ClientRectangle.Height - captionRectangle.Height - 10 );
			this.Renderer.RenderCaption( e.Graphics , captionRectangle , this.Caption , this.Scheme );
			this.Renderer.RenderSubCaption( e.Graphics , subCaptionRectangle , this.SubCaption , this.Scheme );
			if( this.Picture != null ) {
				this.Renderer.RenderImage( e.Graphics , this.ClientRectangle , this.Picture );
			}
		}

		/// <summary>
		/// Handles the MouseEnter event of the PopUpButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void PopUpButtonControl_MouseEnter( object sender , EventArgs e ) {
			if( this.State != PopUpButtonState.Disabled ) {
				this.State = PopUpButtonState.Hovered;
			}
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseLeave event of the PopUpButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void PopUpButtonControl_MouseLeave( object sender , EventArgs e ) {
			if( this.State != PopUpButtonState.Disabled ) {
				this.State = PopUpButtonState.Normal;
			}
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseDown event of the PopUpButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void PopUpButtonControl_MouseDown( object sender , MouseEventArgs e ) {
			if( this.State != PopUpButtonState.Disabled ) {
				this.State = PopUpButtonState.Pushed;
			}
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseUp event of the PopUpButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void PopUpButtonControl_MouseUp( object sender , MouseEventArgs e ) {
			if( this.State != PopUpButtonState.Disabled ) {
				this.State = PopUpButtonState.Hovered;
			}
			this.Invalidate();
		}

		/// <summary>
		/// Handles the EnabledChanged event of the PopUpButtonControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void PopUpButtonControl_EnabledChanged( object sender , EventArgs e ) {
			if( this.Enabled ) {
				this.State = PopUpButtonState.Normal;
			} else {
				this.State = PopUpButtonState.Disabled;
			}
			this.Renderer.Invalidate();
			Invalidate();
		}

	}

}
