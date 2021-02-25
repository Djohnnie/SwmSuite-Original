using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.DialogHeader {
	
	public class DialogHeaderScheme {

		#region -_ Private Members _-

		private Color _backColor1;
		private Color _backColor2;
		private Color _titleColor;
		private Font _titleFont;
		private TextRenderingHint _titleRendering;
		private Color _subTitleColor;
		private Font _subTitleFont;
		private TextRenderingHint _subTitleRendering;

		#endregion

		#region -_ Public Properties _-

		public event EventHandler<EventArgs> NeedsRedraw;

		public Color BackgroundColor1 {
			get {
				return _backColor1;
			}
			set {
				_backColor1 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color BackgroundColor2 {
			get {
				return _backColor2;
			}
			set {
				_backColor2 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color TitleColor {
			get {
				return _titleColor;
			}
			set {
				_titleColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Font TitleFont {
			get {
				return _titleFont;
			}
			set {
				_titleFont = value;
				RaiseNeedsRedraw();
			}
		}

		public TextRenderingHint TitleRendering {
			get {
				return _titleRendering;
			}
			set {
				_titleRendering = value;
				RaiseNeedsRedraw();
			}
		}

		public Color SubTitleColor {
			get {
				return _subTitleColor;
			}
			set {
				_subTitleColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Font SubTitleFont {
			get {
				return _subTitleFont;
			}
			set {
				_subTitleFont = value;
				RaiseNeedsRedraw();
			}
		}

		public TextRenderingHint SubTitleRendering {
			get {
				return _subTitleRendering;
			}
			set {
				_subTitleRendering = value;
				RaiseNeedsRedraw();
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DialogHeaderScheme() {
			this.BackgroundColor1 = Color.FromArgb( 10 , 75 , 115 );
			this.BackgroundColor2 = Color.FromArgb( 50 , 175 , 175 );
			this.TitleColor = Color.FromArgb( 255 , 255 , 255 );
			this.TitleFont = new Font( "Verdana" , 12.0f , FontStyle.Bold );
			this.TitleRendering = TextRenderingHint.ClearTypeGridFit;
			this.SubTitleColor = Color.FromArgb( 200 , 200 , 200 );
			this.SubTitleFont = new Font( "Verdana" , 10.0f , FontStyle.Regular );
			this.SubTitleRendering = TextRenderingHint.ClearTypeGridFit;
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="backColor1"></param>
		/// <param name="backColor2"></param>
		/// <param name="titleColor"></param>
		/// <param name="titleFont"></param>
		/// <param name="titleRendering"></param>
		/// <param name="subTitleColor"></param>
		/// <param name="subTitleFont"></param>
		/// <param name="subTitleRendering"></param>
		public DialogHeaderScheme( Color backColor1 , Color backColor2 , Color titleColor , Font titleFont , TextRenderingHint titleRendering , Color subTitleColor , Font subTitleFont , TextRenderingHint subTitleRendering ) {
			this.BackgroundColor1 = backColor1;
			this.BackgroundColor2 = backColor2;
			this.TitleColor = titleColor;
			this.TitleFont = titleFont;
			this.TitleRendering = titleRendering;
			this.SubTitleColor = subTitleColor;
			this.SubTitleFont = subTitleFont;
			this.SubTitleRendering = subTitleRendering;
		}

		#endregion

		#region -_ Public Methods _-

		#endregion

		#region -_ Private Methods _-

		/// <summary>
		/// Raise the 'NeedsRedraw' event.
		/// </summary>
		private void RaiseNeedsRedraw() {
			if( this.NeedsRedraw != null ) {
				this.NeedsRedraw( this , EventArgs.Empty );
			}
		}

		#endregion

	}
}
