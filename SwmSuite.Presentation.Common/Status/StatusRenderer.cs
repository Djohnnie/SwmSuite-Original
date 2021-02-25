using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.Status {

	public class StatusRenderer : IDisposable {

		#region -_ Private Members _-

		private LinearGradientBrush _backgroundBrush;
		private StringFormat _leftStringFormat;
		private StringFormat _middleStringFormat;
		private StringFormat _rightStringFormat;
		private SolidBrush _captionBrush;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StatusRenderer() {
		}

		#endregion

		#region -_ Public Methods _-

		public void RenderBackground( Graphics graphics , Rectangle drawRectangle , StatusScheme scheme ) {
			graphics.FillRectangle( GetBackgroundBrush( scheme , drawRectangle ) , drawRectangle );
		}

		public void RenderText( Graphics graphics , Rectangle drawRectangle , String leftCaption , String middleCaption , String rightCaption, StatusScheme scheme ) {
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics.DrawString( leftCaption , scheme.CaptionFont , GetCaptionBrush( scheme ) , drawRectangle , GetLeftStringFormat() );
			graphics.DrawString( middleCaption , scheme.CaptionFont , GetCaptionBrush( scheme ) , drawRectangle , GetMiddleStringFormat() );
			graphics.DrawString( rightCaption , scheme.CaptionFont , GetCaptionBrush( scheme ) , drawRectangle , GetRightStringFormat() );
			graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public void Invalidate() {
			if( _backgroundBrush != null ) {
				_backgroundBrush.Dispose();
				_backgroundBrush = null;
			}
			if( _leftStringFormat != null ) {
				_leftStringFormat.Dispose();
				_leftStringFormat = null;
			}
			if( _middleStringFormat != null ) {
				_middleStringFormat.Dispose();
				_middleStringFormat = null;
			}
			if( _rightStringFormat != null ) {
				_rightStringFormat.Dispose();
				_rightStringFormat = null;
			}
			if( _captionBrush != null ) {
				_captionBrush.Dispose();
				_captionBrush = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private LinearGradientBrush GetBackgroundBrush( StatusScheme scheme , Rectangle bounds ) {
			if( _backgroundBrush == null ) {
				_backgroundBrush = new LinearGradientBrush( bounds , scheme.BackgroundColor1 , scheme.BackgroundColor2 , LinearGradientMode.Vertical );
			}
			return _backgroundBrush;
		}

		private StringFormat GetLeftStringFormat() {
			if( _leftStringFormat == null ) {
				_leftStringFormat = new StringFormat() { Alignment = StringAlignment.Near , LineAlignment = StringAlignment.Center };
			}
			return _leftStringFormat;
		}

		private StringFormat GetMiddleStringFormat() {
			if( _middleStringFormat == null ) {
				_middleStringFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center };
			}
			return _middleStringFormat;
		}

		private StringFormat GetRightStringFormat() {
			if( _rightStringFormat == null ) {
				_rightStringFormat = new StringFormat() { Alignment = StringAlignment.Far , LineAlignment = StringAlignment.Center };
			}
			return _rightStringFormat;
		}

		private SolidBrush GetCaptionBrush( StatusScheme scheme ) {
			if( _captionBrush == null ) {
				_captionBrush = new SolidBrush( scheme.CaptionColor );
			}
			return _captionBrush;
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