using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.PopUpButton {

	public class PopUpButtonScheme {

		#region -_ Private Members _-

		private Color _borderColor;
		private Color _backgroundColor1;
		private Color _backgroundColor2;
		private LinearGradientMode _backgroundGradientMode;
		private Color _captionColor;
		private Color _subCaptionColor;
		private Font _captionFont;
		private Font _subCaptionFont;
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
		/// Gets or sets the color of the sub caption.
		/// </summary>
		/// <value>The color of the sub caption.</value>
		public Color SubCaptionColor {
			get {
				return _subCaptionColor;
			}
			set {
				_subCaptionColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the font of the caption.
		/// </summary>
		/// <value>The font of the caption.</value>
		public Font CaptionFont {
			get {
				return _captionFont;
			}
			set {
				_captionFont = value;
			}
		}

		/// <summary>
		/// Gets or sets the font of the sub caption.
		/// </summary>
		/// <value>The font of the sub caption.</value>
		public Font SubCaptionFont {
			get {
				return _subCaptionFont;
			}
			set {
				_subCaptionFont = value;
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

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public PopUpButtonScheme() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="borderColor">Color of the border.</param>
		/// <param name="background1Color">Color of the background1.</param>
		/// <param name="background2Color">Color of the background2.</param>
		/// <param name="gradientMode">The gradient mode.</param>
		/// <param name="captionColor">Color of the caption.</param>
		/// <param name="subCaptionColor">Color of the sub caption.</param>
		/// <param name="captionFont">The caption font.</param>
		/// <param name="subCaptionFont">The sub caption font.</param>
		/// <param name="captionFormat">The caption format.</param>
		/// <param name="captionRendering">The caption rendering.</param>
		public PopUpButtonScheme( Color borderColor , Color background1Color , Color background2Color , LinearGradientMode gradientMode , Color captionColor , Color subCaptionColor , Font captionFont , Font subCaptionFont , StringFormat captionFormat , TextRenderingHint captionRendering ) {
			this.BorderColor = borderColor;
			this.BackgroundColor1 = background1Color;
			this.BackgroundColor2 = background2Color;
			this.BackgroundGradientMode = gradientMode;
			this.CaptionColor = captionColor;
			this.SubCaptionColor = subCaptionColor;
			this.CaptionFont = captionFont;
			this.SubCaptionFont = subCaptionFont;
			this.CaptionFormat = captionFormat;
			this.CaptionRendering = captionRendering;
		}

		#endregion

	}

}
