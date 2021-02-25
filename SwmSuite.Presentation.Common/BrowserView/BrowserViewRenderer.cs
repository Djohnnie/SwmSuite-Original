using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.BrowserView {

	public class BrowserViewRenderer : IDisposable {

		#region -_ Private Members _-

		private SolidBrush _rowNormalFillBrush = null;
		private SolidBrush _rowNormal2FillBrush = null;
		private LinearGradientBrush _rowHoveredFillBrush = null;
		private LinearGradientBrush _rowSelectedFillBrush = null;
		private SolidBrush _rowCaptionBrush = null;
		private StringFormat _rowCaptionFormat = null;

		private LinearGradientBrush _columnHeaderTopFillBrush = null;
		private LinearGradientBrush _columnHeaderBottomFillBrush = null;
		private SolidBrush _columnHeaderCaptionBrush = null;
		private StringFormat _columnHeaderCaptionFormat = null;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public BrowserViewRenderer() {
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Draws the row normal.
		/// </summary>
		/// <param name="graphics">The graphics.</param>
		/// <param name="drawRectangle">The draw rectangle.</param>
		/// <param name="caption">The caption.</param>
		/// <param name="scheme">The scheme.</param>
		/// <param name="oddRow">if set to <c>true</c> [odd row].</param>
		public void DrawRowNormal( Graphics graphics , Rectangle drawRectangle , String caption , BrowserViewScheme scheme , bool oddRow ) {
			graphics.FillRectangle( GetRowNormalBrush( scheme , oddRow ) , drawRectangle );
			DrawRowCaption( graphics , drawRectangle , caption , scheme );
		}

		/// <summary>
		/// Draws the row normal.
		/// </summary>
		/// <param name="graphics">The graphics.</param>
		/// <param name="drawRectangle">The draw rectangle.</param>
		/// <param name="caption">The caption.</param>
		/// <param name="scheme">The scheme.</param>
		/// <param name="oddRow">if set to <c>true</c> [odd row].</param>
		public void DrawRowNormal( Graphics graphics , Rectangle drawRectangle , String caption , BrowserViewScheme scheme , bool oddRow , Color backgroundColor1 , Color backgroundColor2 ) {
			LinearGradientBrush fillBrush = new LinearGradientBrush( drawRectangle , backgroundColor1 , backgroundColor2 , LinearGradientMode.Vertical );
			graphics.FillRectangle( fillBrush , drawRectangle );
			DrawRowCaption( graphics , drawRectangle , caption , scheme );
			fillBrush.Dispose();
		}

		/// <summary>
		/// Draws the row hovered.
		/// </summary>
		/// <param name="graphics">The graphics.</param>
		/// <param name="drawRectangle">The draw rectangle.</param>
		/// <param name="caption">The caption.</param>
		/// <param name="scheme">The scheme.</param>
		public void DrawRowHovered( Graphics graphics , Rectangle drawRectangle , String caption , BrowserViewScheme scheme ) {
			graphics.FillRectangle( GetRowHoveredBrush( drawRectangle , scheme ) , drawRectangle );
			DrawRowCaption( graphics , drawRectangle , caption , scheme );
		}

		/// <summary>
		/// Draws the row selected.
		/// </summary>
		/// <param name="graphics">The graphics.</param>
		/// <param name="drawRectangle">The draw rectangle.</param>
		/// <param name="caption">The caption.</param>
		/// <param name="scheme">The scheme.</param>
		public void DrawRowSelected( Graphics graphics , Rectangle drawRectangle , String caption , BrowserViewScheme scheme ) {
			graphics.FillRectangle( GetRowSelectedBrush( drawRectangle , scheme ) , drawRectangle );
			DrawRowCaption( graphics , drawRectangle , caption , scheme );
		}

		/// <summary>
		/// Draws the column header.
		/// </summary>
		/// <param name="graphics">The graphics.</param>
		/// <param name="drawRectangle">The draw rectangle.</param>
		/// <param name="caption">The caption.</param>
		/// <param name="scheme">The scheme.</param>
		public void DrawColumnHeader( Graphics graphics , Rectangle drawRectangle , String caption , BrowserViewScheme scheme ) {
			Rectangle topRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top , drawRectangle.Width , drawRectangle.Height / 2 );
			Rectangle bottomRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top + drawRectangle.Height / 2 , drawRectangle.Width , drawRectangle.Height / 2 );
			graphics.FillRectangle( GetColumnHeaderTopFillBrush( topRectangle , scheme ) , topRectangle );
			graphics.FillRectangle( GetColumnHeaderBottomFillBrush( bottomRectangle , scheme ) , bottomRectangle );
			TextRenderingHint oldRendering = graphics.TextRenderingHint;
			graphics.TextRenderingHint = scheme.ColumnHeaderCaptionRendering;
			graphics.DrawString( caption , scheme.ColumnHeaderCaptionFont , GetColumnHeaderCaptionBrush( scheme ) , drawRectangle , GetColumnHeaderCaptionFormat() );
			graphics.TextRenderingHint = oldRendering;
		}

		/// <summary>
		/// Invalidates this instance.
		/// </summary>
		public void Invalidate() {
			if( _rowNormalFillBrush != null ) {
				_rowNormalFillBrush.Dispose();
				_rowNormalFillBrush = null;
			}
			if( _rowNormal2FillBrush != null ) {
				_rowNormal2FillBrush.Dispose();
				_rowNormal2FillBrush = null;
			}
			if( _rowHoveredFillBrush != null ) {
				_rowHoveredFillBrush.Dispose();
				_rowHoveredFillBrush = null;
			}
			if( _rowSelectedFillBrush != null ) {
				_rowSelectedFillBrush.Dispose();
				_rowSelectedFillBrush = null;
			}

			if( _columnHeaderTopFillBrush != null ) {
				_columnHeaderTopFillBrush.Dispose();
				_columnHeaderTopFillBrush = null;
			}
			if( _columnHeaderBottomFillBrush != null ) {
				_columnHeaderBottomFillBrush.Dispose();
				_columnHeaderBottomFillBrush = null;
			}
			if( _columnHeaderCaptionBrush != null ){
				_columnHeaderCaptionBrush.Dispose();
				_columnHeaderCaptionBrush = null;
			}
			if( _columnHeaderCaptionFormat != null ) {
				_columnHeaderCaptionFormat.Dispose();
				_columnHeaderCaptionFormat = null;
			}
			if( _rowCaptionBrush != null ) {
				_rowCaptionBrush.Dispose();
				_rowCaptionBrush = null;
			}
			if( _rowCaptionFormat != null ) {
				_rowCaptionFormat.Dispose();
				_rowCaptionFormat = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private void DrawRowCaption( Graphics graphics , Rectangle drawRectangle , String caption , BrowserViewScheme scheme ){
			TextRenderingHint oldRendering = graphics.TextRenderingHint;
			graphics.TextRenderingHint = scheme.ColumnHeaderCaptionRendering;
			graphics.DrawString( caption , scheme.RowCaptionFont , GetRowCaptionBrush( scheme ) , drawRectangle , GetRowCaptionFormat() );
			graphics.TextRenderingHint = oldRendering;
		}

		private SolidBrush GetRowNormalBrush( BrowserViewScheme scheme , bool oddRow ) {
			if( _rowNormalFillBrush == null ) {
				_rowNormalFillBrush = new SolidBrush( oddRow ? scheme.RowNormalBackgroundColor2 : scheme.RowNormalBackgroundColor1 );
			}
			return _rowNormalFillBrush;
		}

		private SolidBrush GetRowNormalBrush( Color color ) {
			if( _rowNormal2FillBrush == null ) {
				_rowNormal2FillBrush = new SolidBrush( color );
			}
			return _rowNormal2FillBrush;
		}

		private LinearGradientBrush GetRowHoveredBrush( Rectangle bounds , BrowserViewScheme scheme ) {
			if( _rowHoveredFillBrush == null ) {
				_rowHoveredFillBrush = new LinearGradientBrush( bounds , scheme.RowHoveredBackgroundColor1 , scheme.RowHoveredBackgroundColor2 , LinearGradientMode.Vertical );
			}
			return _rowHoveredFillBrush;
		}

		private LinearGradientBrush GetRowSelectedBrush( Rectangle bounds , BrowserViewScheme scheme ) {
			if( _rowSelectedFillBrush == null ) {
				_rowSelectedFillBrush = new LinearGradientBrush( bounds , scheme.RowSelectedBackgroundColor1 , scheme.RowSelectedBackgroundColor2 , LinearGradientMode.Vertical );
			}
			return _rowSelectedFillBrush;
		}

		private SolidBrush GetRowCaptionBrush( BrowserViewScheme scheme ) {
			if( _rowCaptionBrush == null ) {
				_rowCaptionBrush = new SolidBrush( scheme.RowCaptionColor );
			}
			return _rowCaptionBrush;
		}

		private StringFormat GetRowCaptionFormat() {
			if( _rowCaptionFormat == null ) {
				_rowCaptionFormat = new StringFormat();
				_rowCaptionFormat.Alignment = StringAlignment.Near;
				_rowCaptionFormat.LineAlignment = StringAlignment.Center;
			}
			return _rowCaptionFormat;
		}

		private LinearGradientBrush GetColumnHeaderTopFillBrush( Rectangle bounds , BrowserViewScheme scheme ) {
			if( _columnHeaderTopFillBrush == null ) {
				_columnHeaderTopFillBrush = new LinearGradientBrush( bounds , scheme.ColumnHeaderBackgroundColor1 , scheme.ColumnHeaderBackgroundColor2 , LinearGradientMode.Vertical );
			}
			return _columnHeaderTopFillBrush;
		}

		private LinearGradientBrush GetColumnHeaderBottomFillBrush( Rectangle bounds , BrowserViewScheme scheme ) {
			if( _columnHeaderBottomFillBrush == null ) {
				_columnHeaderBottomFillBrush = new LinearGradientBrush( bounds , scheme.ColumnHeaderBackgroundColor3 , scheme.ColumnHeaderBackgroundColor4 , LinearGradientMode.Vertical );
			}
			return _columnHeaderBottomFillBrush;
		}

		private SolidBrush GetColumnHeaderCaptionBrush( BrowserViewScheme scheme ) {
			if( _columnHeaderCaptionBrush == null ) {
				_columnHeaderCaptionBrush = new SolidBrush( scheme.ColumnHeaderCaptionColor );
			}
			return _columnHeaderCaptionBrush;
		}

		private StringFormat GetColumnHeaderCaptionFormat() {
			if( _columnHeaderCaptionFormat == null ) {
				_columnHeaderCaptionFormat = new StringFormat();
				_columnHeaderCaptionFormat.Alignment = StringAlignment.Near;
				_columnHeaderCaptionFormat.LineAlignment = StringAlignment.Center;
			}
			return _columnHeaderCaptionFormat;
		}


		#endregion

		#region -_ IDisposable Members _-

		public void Dispose() {
			GC.SuppressFinalize( this );
			Dispose( true );
		}

		protected void Dispose( bool dispose ) {
			if( dispose ) {
				Invalidate();
			}
		}

		#endregion
	}

}
