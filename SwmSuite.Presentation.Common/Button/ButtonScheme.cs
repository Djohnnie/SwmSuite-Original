using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace SwmSuite.Presentation.Common {

	public class ButtonScheme {

		#region -_ Private Members _-

		private Color _borderColor;
		private Color _backgroundColor1;
		private Color _backgroundColor2;
		private LinearGradientMode _backgroundGradientMode;
		private Color _captionColor;
		private Font _captionFont;
		private StringFormat _captionFormat;
		private TextRenderingHint _captionRendering;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the color of the border.
		/// </summary>
		/// <value>The color of the border.</value>
		public Color BorderColor {
			get {
				return _borderColor;
			}
			set {
				_borderColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the first background color.
		/// </summary>
		/// <value>The first background color.</value>
		public Color BackgroundColor1 {
			get {
				return _backgroundColor1;
			}
			set {
				_backgroundColor1 = value;
			}
		}

		/// <summary>
		/// Gets or sets the second background color.
		/// </summary>
		/// <value>The second background color.</value>
		public Color BackgroundColor2 {
			get {
				return _backgroundColor2;
			}
			set {
				_backgroundColor2 = value;
			}
		}

		/// <summary>
		/// Gets or sets the background gradient mode.
		/// </summary>
		/// <value>The background gradient mode.</value>
		public LinearGradientMode BackgroundGradientMode {
			get {
				return _backgroundGradientMode;
			}
			set {
				_backgroundGradientMode = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the caption.
		/// </summary>
		/// <value>The color of the caption.</value>
		public Color CaptionColor {
			get {
				return _captionColor;
			}
			set {
				_captionColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the caption font.
		/// </summary>
		/// <value>The caption font.</value>
		public Font CaptionFont {
			get {
				return _captionFont;
			}
			set {
				_captionFont = value;
			}
		}

		/// <summary>
		/// Gets or sets the caption format.
		/// </summary>
		/// <value>The caption format.</value>
		public StringFormat CaptionFormat {
			get {
				return _captionFormat;
			}
			set {
				_captionFormat = value;
			}
		}

		/// <summary>
		/// Gets or sets the caption rendering.
		/// </summary>
		/// <value>The caption rendering.</value>
		public TextRenderingHint CaptionRendering {
			get {
				return _captionRendering;
			}
			set {
				_captionRendering = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [green button].
		/// </summary>
		/// <value><c>true</c> if [green button]; otherwise, <c>false</c>.</value>
		public bool GreenButton {
			get { return false; }
			set {
				if( value ) {
					this.BackgroundColor1 = Color.FromArgb( 255 , 255 , 255 );
					this.BackgroundColor2 = Color.FromArgb( 235 , 255 , 235 );
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [red button].
		/// </summary>
		/// <value><c>true</c> if [red button]; otherwise, <c>false</c>.</value>
		public bool RedButton {
			get { return false; }
			set {
				if( value ) {
					this.BackgroundColor1 = Color.FromArgb( 255 , 255 , 255 );
					this.BackgroundColor2 = Color.FromArgb( 255 , 235 , 235 );
				}
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ButtonScheme() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="borderColor"></param>
		/// <param name="background1Color"></param>
		/// <param name="background2Color"></param>
		/// <param name="gradientMode"></param>
		/// <param name="captionColor"></param>
		/// <param name="captionFont"></param>
		/// <param name="captionFormat"></param>
		/// <param name="captionRendering"></param>
		public ButtonScheme( Color borderColor , Color background1Color , Color background2Color , LinearGradientMode gradientMode , Color captionColor , Font captionFont , StringFormat captionFormat , TextRenderingHint captionRendering ) {
			this.BorderColor = borderColor;
			this.BackgroundColor1 = background1Color;
			this.BackgroundColor2 = background2Color;
			this.BackgroundGradientMode = gradientMode;
			this.CaptionColor = captionColor;
			this.CaptionFont = captionFont;
			this.CaptionFormat = captionFormat;
			this.CaptionRendering = captionRendering;
		}

		#endregion

	}

}