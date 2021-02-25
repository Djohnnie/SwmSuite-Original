using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.Marquee {

	public class MarqueeRenderer : IDisposable {

		#region -_ Private Members _-

		private SolidBrush _textBrush;
		private StringFormat _textFormat;
		private Bitmap _background;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		#endregion

		#region -_ Public Methods _-

		public void RenderBackground( Graphics graphics , Rectangle drawRectangle , MarqueeScheme scheme ) {
			graphics.DrawImageUnscaled( GetBackground( drawRectangle , scheme ) , drawRectangle );
		}

		public void RenderText( Graphics graphics , Rectangle drawRectangle , String text , MarqueeScheme scheme ) {
			Rectangle textRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top , GetTextWidth( graphics , text , scheme ) , drawRectangle.Height );
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics.DrawString( text , scheme.TextFont , GetTextBrush( scheme ) , textRectangle , GetTextFormat() );
			//TextRenderer.DrawText( graphics , text , scheme.TextFont , textRectangle , scheme.TextColor , TextFormatFlags.Left | TextFormatFlags.VerticalCenter );
			graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public void RenderButtonText( Graphics graphics , Rectangle drawRectangle , String text , MarqueeScheme scheme ) {
			Rectangle textRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top , drawRectangle.Width , drawRectangle.Height );
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			//graphics.DrawString( text , scheme.TextFont , GetTextBrush( scheme ) , textRectangle , GetTextFormat() );
			TextRenderer.DrawText( graphics , text , scheme.TextFont , textRectangle , scheme.TextColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
			graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public void RenderShadowText( Graphics graphics , Rectangle drawRectangle , String text , MarqueeScheme scheme ) {
			Rectangle textRectangle = new Rectangle( drawRectangle.Left + 1 , drawRectangle.Top + 1 , drawRectangle.Width , drawRectangle.Height );
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			//graphics.DrawString( text , scheme.TextFont , GetTextBrush( scheme ) , textRectangle , GetTextFormat() );
			TextRenderer.DrawText( graphics , text , scheme.TextFont , textRectangle , Color.Black , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
			graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public int GetTextWidth( Graphics graphics , String text , MarqueeScheme scheme ) {
			//SizeF sizeToReturn = TextRenderer.MeasureText( graphics , text , scheme.TextFont );
			SizeF sizeToReturn = graphics.MeasureString( text , scheme.TextFont );
			return ( (int)sizeToReturn.Width ) + 1;
		}

		public void Invalidate() {
			if( _textBrush != null ) {
				_textBrush.Dispose();
				_textBrush = null;
			}
			if( _textFormat != null ) {
				_textFormat.Dispose();
				_textFormat = null;
			}
			if( _background != null ) {
				_background.Dispose();
				_background = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private SolidBrush GetTextBrush( MarqueeScheme scheme ) {
			if( _textBrush == null ) {
				_textBrush = new SolidBrush( scheme.TextColor );
			}
			return _textBrush;
		}

		private StringFormat GetTextFormat() {
			if( _textFormat == null ) {
				_textFormat = new StringFormat() { Alignment = StringAlignment.Near , LineAlignment = StringAlignment.Center };
			}
			return _textFormat;
		}

		private Bitmap GetBackground( Rectangle bounds , MarqueeScheme scheme ) {
			if( _background == null ) {
				_background = new Bitmap( bounds.Width , bounds.Height );
				Graphics graphics = Graphics.FromImage( _background );
				Rectangle topRectangle = new Rectangle( bounds.Left , bounds.Top , bounds.Width , bounds.Height / 2 );
				Rectangle bottomRectangle = new Rectangle( bounds.Left , bounds.Top + bounds.Height / 2 , bounds.Width , bounds.Height / 2 );
				LinearGradientBrush topBrush = new LinearGradientBrush( topRectangle , scheme.BackgroundColor1 , scheme.BackgroundColor2 , LinearGradientMode.Vertical );
				LinearGradientBrush bottomBrush = new LinearGradientBrush( bottomRectangle , scheme.BackgroundColor3 , scheme.BackgroundColor4 , LinearGradientMode.Vertical );
				graphics.FillRectangle( topBrush , topRectangle );
				graphics.FillRectangle( bottomBrush , bottomRectangle );
				bottomBrush.Dispose();
				topBrush.Dispose();
				graphics.Dispose();
			}
			return _background;
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
