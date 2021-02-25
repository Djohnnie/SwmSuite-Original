using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.BrowserView {

	public class BrowserViewScheme {

		#region -_ Private Members _-

		private Color _columnHeaderBackColor1;
		private Color _columnHeaderBackColor2;
		private Color _columnHeaderBackColor3;
		private Color _columnHeaderBackColor4;
		private Color _columnHeaderCaptionColor;
		private Font _columnHeaderCaptionFont;
		private TextRenderingHint _columnHeaderCaptionRendering;

		private Color _rowNormalBackgroundColor1;
		private Color _rowNormalBackgroundColor2;
		private Color _rowHoveredBackgroundColor1;
		private Color _rowHoveredBackgroundColor2;
		private Color _rowSelectedBackgroundColor1;
		private Color _rowSelectedBackgroundColor2;
		private Color _rowCaptionColor;
		private Font _rowCaptionFont;
		private TextRenderingHint _rowCaptionRendering;

		#endregion

		#region -_ Public Properties _-

		public event EventHandler<EventArgs> NeedsRedraw;

		public Color ColumnHeaderBackgroundColor1 {
			get {
				return _columnHeaderBackColor1;
			}
			set {
				_columnHeaderBackColor1 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ColumnHeaderBackgroundColor2 {
			get {
				return _columnHeaderBackColor2;
			}
			set {
				_columnHeaderBackColor2 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ColumnHeaderBackgroundColor3 {
			get {
				return _columnHeaderBackColor3;
			}
			set {
				_columnHeaderBackColor3 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ColumnHeaderBackgroundColor4 {
			get {
				return _columnHeaderBackColor4;
			}
			set {
				_columnHeaderBackColor4 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ColumnHeaderCaptionColor {
			get {
				return _columnHeaderCaptionColor;
			}
			set {
				_columnHeaderCaptionColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Font ColumnHeaderCaptionFont {
			get {
				return _columnHeaderCaptionFont;
			}
			set {
				_columnHeaderCaptionFont = value;
				RaiseNeedsRedraw();
			}
		}

		public TextRenderingHint ColumnHeaderCaptionRendering {
			get {
				return _columnHeaderCaptionRendering;
			}
			set {
				_columnHeaderCaptionRendering = value;
				RaiseNeedsRedraw();
			}
		}

		public Color RowNormalBackgroundColor1 {
			get {
				return _rowNormalBackgroundColor1;
			}
			set {
				_rowNormalBackgroundColor1 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color RowNormalBackgroundColor2 {
			get {
				return _rowNormalBackgroundColor2;
			}
			set {
				_rowNormalBackgroundColor2 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color RowHoveredBackgroundColor1 {
			get {
				return _rowHoveredBackgroundColor1;
			}
			set {
				_rowHoveredBackgroundColor1 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color RowHoveredBackgroundColor2 {
			get {
				return _rowHoveredBackgroundColor2;
			}
			set {
				_rowHoveredBackgroundColor2 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color RowSelectedBackgroundColor1 {
			get {
				return _rowSelectedBackgroundColor1;
			}
			set {
				_rowSelectedBackgroundColor1 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color RowSelectedBackgroundColor2 {
			get {
				return _rowSelectedBackgroundColor2;
			}
			set {
				_rowSelectedBackgroundColor2 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color RowCaptionColor {
			get {
				return _rowCaptionColor;
			}
			set {
				_rowCaptionColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Font RowCaptionFont {
			get {
				return _rowCaptionFont;
			}
			set {
				_rowCaptionFont = value;
				RaiseNeedsRedraw();
			}
		}

		public TextRenderingHint RowCaptionRendering {
			get {
				return _rowCaptionRendering;
			}
			set {
				_rowCaptionRendering = value;
				RaiseNeedsRedraw();
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public BrowserViewScheme() {
			this.ColumnHeaderBackgroundColor1 = Color.FromArgb( 136 , 180 , 192 );
			this.ColumnHeaderBackgroundColor2 = Color.FromArgb( 71 , 139 , 158 );
			this.ColumnHeaderBackgroundColor3 = Color.FromArgb( 19 , 97 , 119 );
			this.ColumnHeaderBackgroundColor4 = Color.FromArgb( 83 , 159 , 171 );
			this.ColumnHeaderCaptionColor = Color.FromArgb( 255 , 255 , 255 );
			this.ColumnHeaderCaptionFont = new Font( "Verdana" , 10.0f , FontStyle.Bold );
			this.ColumnHeaderCaptionRendering = TextRenderingHint.ClearTypeGridFit;

			this.RowNormalBackgroundColor1 = Color.FromArgb( 255 , 255 , 255 );
			this.RowNormalBackgroundColor2 = Color.FromArgb( 255 , 255 , 255 );
			this.RowHoveredBackgroundColor1 = Color.FromArgb( 248 , 252 , 254 );
			this.RowHoveredBackgroundColor2 = Color.FromArgb( 232 , 245 , 253 );
			this.RowSelectedBackgroundColor1 = Color.FromArgb( 220 , 235 , 252 );
			this.RowSelectedBackgroundColor2 = Color.FromArgb( 193 , 219 , 252 );
			this.RowCaptionColor = Color.FromArgb( 0 , 0 , 0 );
			this.RowCaptionFont = new Font( "Verdana" , 10.0f , FontStyle.Regular );
			this.ColumnHeaderCaptionRendering = TextRenderingHint.ClearTypeGridFit;
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="backColor1"></param>
		/// <param name="backColor2"></param>
		/// <param name="backColor3"></param>
		/// <param name="backColor4"></param>
		/// <param name="captionColor"></param>
		/// <param name="captionFont"></param>
		/// <param name="captionRendering"></param>
		public BrowserViewScheme( Color backColor1 , Color backColor2 , Color backColor3 , Color backColor4 , Color captionColor , Font captionFont , TextRenderingHint captionRendering ) {
			this.ColumnHeaderBackgroundColor1 = backColor1;
			this.ColumnHeaderBackgroundColor2 = backColor2;
			this.ColumnHeaderBackgroundColor3 = backColor3;
			this.ColumnHeaderBackgroundColor4 = backColor4;
			this.ColumnHeaderCaptionColor = captionColor;
			this.ColumnHeaderCaptionFont = captionFont;
			this.ColumnHeaderCaptionRendering = captionRendering;
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