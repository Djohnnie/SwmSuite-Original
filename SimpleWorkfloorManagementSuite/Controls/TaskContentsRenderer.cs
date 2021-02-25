using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	public class TaskContentsRenderer : IDisposable {

		#region -_ Private Members _-

		private Pen _borderPen;
		private LinearGradientBrush _backgroundBrush;
		private SolidBrush _textBrush;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TaskContentsRenderer"/> class.
		/// </summary>
		public TaskContentsRenderer() {
		}

		#endregion

		#region -_ Public Methods _-

		public void RenderBorder( Graphics graphics , Rectangle drawRectangle , TaskContentsScheme scheme ) {
			graphics.DrawRectangle( GetBorderPen( scheme ) , drawRectangle );
		}

		public void RenderTitle( Graphics graphics , Rectangle drawRectangle , TaskContentsScheme scheme ) {
			graphics.FillRectangle( GetBackgroundBrush( scheme , drawRectangle ) , drawRectangle );
		}

		public void RenderTitleContents( Graphics graphics , Rectangle drawRectangle , TaskContentsScheme scheme , String subject , String from , String date ) {
			Rectangle contentsRectangle = new Rectangle( drawRectangle.Left + 5 , drawRectangle.Top + 5 , drawRectangle.Width - 10 , drawRectangle.Height - 10 );

			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			TextRenderer.DrawText( graphics , subject , scheme.BigFont , contentsRectangle , scheme.TextColor , TextFormatFlags.Left | TextFormatFlags.Top );
			TextRenderer.DrawText( graphics , from , scheme.SmallFont , contentsRectangle , scheme.TextColor , TextFormatFlags.Left | TextFormatFlags.VerticalCenter );
			TextRenderer.DrawText( graphics , date , scheme.SmallFont , contentsRectangle , scheme.TextColor , TextFormatFlags.Left | TextFormatFlags.Bottom );
			graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public void Invalidate() {
			if( _borderPen != null ) {
				_borderPen.Dispose();
				_borderPen = null;
			}
			if( _backgroundBrush != null ) {
				_backgroundBrush.Dispose();
				_backgroundBrush = null;
			}
			if( _textBrush != null ) {
				_textBrush.Dispose();
				_textBrush = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private Pen GetBorderPen( TaskContentsScheme scheme ) {
			if( _borderPen == null ) {
				_borderPen = new Pen( scheme.BorderColor );
			}
			return _borderPen;
		}

		private LinearGradientBrush GetBackgroundBrush( TaskContentsScheme scheme , Rectangle bounds ) {
			if( _backgroundBrush == null ) {
				_backgroundBrush = new LinearGradientBrush( bounds , scheme.TitleBackgroundColor1 , scheme.TitleBackgroundColor2 , LinearGradientMode.Horizontal );
			}
			return _backgroundBrush;
		}

		private SolidBrush GetTextBrush( TaskContentsScheme scheme ) {
			if( _textBrush == null ) {
				_textBrush = new SolidBrush( scheme.TextColor );
			}
			return _textBrush;
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
