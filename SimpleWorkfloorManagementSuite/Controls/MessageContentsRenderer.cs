using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SimpleWorkfloorManagementSuite.Controls {

	public class MessageContentsRenderer : IDisposable {

		#region -_ Private Members _-

		private Pen _borderPen;
		private LinearGradientBrush _backgroundBrush;
		private SolidBrush _textBrush;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="MessageContentsRenderer"/> class.
		/// </summary>
		public MessageContentsRenderer() {
		}

		#endregion

		#region -_ Public Methods _-

		public void RenderBorder( Graphics graphics , Rectangle drawRectangle , MessageContentsScheme scheme ) {
			graphics.DrawRectangle( GetBorderPen( scheme ) , drawRectangle );
		}

		public void RenderTitle( Graphics graphics , Rectangle drawRectangle , MessageContentsScheme scheme ) {
			graphics.FillRectangle( GetBackgroundBrush( scheme , drawRectangle ) , drawRectangle );
		}

		public void RenderTitleContents( Graphics graphics , Rectangle drawRectangle , MessageContentsScheme scheme , String subject , String from , String date ) {
			StringFormat subjectStringFormat = new StringFormat() { Alignment = StringAlignment.Near , LineAlignment = StringAlignment.Near };
			StringFormat fromStringFormat = new StringFormat() { Alignment = StringAlignment.Near , LineAlignment = StringAlignment.Center };
			StringFormat dateStringFormat = new StringFormat() { Alignment = StringAlignment.Near , LineAlignment = StringAlignment.Far };

			Rectangle contentsRectangle = new Rectangle( drawRectangle.Left + 10 , drawRectangle.Top + 10 , drawRectangle.Width - 20 , drawRectangle.Height - 20 );

			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics.DrawString( subject , scheme.BigFont , GetTextBrush( scheme ) , contentsRectangle , subjectStringFormat );
			graphics.DrawString( from , scheme.SmallFont , GetTextBrush( scheme ) , contentsRectangle , fromStringFormat );
			graphics.DrawString( date , scheme.SmallFont , GetTextBrush( scheme ) , contentsRectangle , dateStringFormat );
			graphics.TextRenderingHint = TextRenderingHint.SystemDefault;

			dateStringFormat.Dispose();
			fromStringFormat.Dispose();
			subjectStringFormat.Dispose();
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

		private Pen GetBorderPen( MessageContentsScheme scheme ) {
			if( _borderPen == null ) {
				_borderPen = new Pen( scheme.BorderColor );
			}
			return _borderPen;
		}

		private LinearGradientBrush GetBackgroundBrush( MessageContentsScheme scheme , Rectangle bounds ) {
			if( _backgroundBrush == null ) {
				_backgroundBrush = new LinearGradientBrush( bounds , scheme.TitleBackgroundColor1 , scheme.TitleBackgroundColor2 , LinearGradientMode.Horizontal );
			}
			return _backgroundBrush;
		}

		private SolidBrush GetTextBrush( MessageContentsScheme scheme ) {
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