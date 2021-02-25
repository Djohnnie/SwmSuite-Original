using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.AnalogClock {

	public class AnalogClockRenderer : IDisposable {

		#region -_ Private Members _-

		private Pen _borderPen;
		private Pen _hourIndicatorPen;
		private Pen _hourHandPen;
		private Pen _minuteHandPen;
		private Pen _secondHandPen;
		private SolidBrush _backgroundBrush;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AnalogClockRenderer() {
		}

		#endregion

		#region -_ Public Methods _-

		public void Invalidate() {
			if( _borderPen != null ) {
				_borderPen.Dispose();
				_borderPen = null;
			}
			if( _hourIndicatorPen != null ) {
				_hourIndicatorPen.Dispose();
				_hourIndicatorPen = null;
			}
			if( _hourHandPen != null ) {
				_hourHandPen.Dispose();
				_hourHandPen = null;
			}

			if( _minuteHandPen != null ) {
				_minuteHandPen.Dispose();
				_minuteHandPen = null;
			}
			if( _secondHandPen != null ) {
				_secondHandPen.Dispose();
				_secondHandPen = null;
			}
			if( _backgroundBrush != null ) {
				_backgroundBrush.Dispose();
				_backgroundBrush = null;
			}
		}

		#endregion

		public void RenderCountDown( Graphics graphics , Rectangle drawRectangle , int start , int length , AnalogClockScheme scheme ) {
			// calculate inner rectangle.
			Rectangle innerRectangle;
			if( drawRectangle.Width > drawRectangle.Height ) {
				innerRectangle = new Rectangle( drawRectangle.Left + drawRectangle.Width / 2 - drawRectangle.Height / 2 , drawRectangle.Top , drawRectangle.Height , drawRectangle.Height );
			} else {
				innerRectangle = new Rectangle( drawRectangle.Width , drawRectangle.Top + drawRectangle.Height / 2 - drawRectangle.Width / 2 , drawRectangle.Width , drawRectangle.Width );
			}

			SolidBrush fillBrush = new SolidBrush( scheme.CountDownFillColor );
			float startAngle = ( 360.0f / 60.0f * (float)start ) - 90.0f;
			float sweepAngle = ( 360.0f / 60.0f * (float)length );
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.FillPie( fillBrush , innerRectangle , startAngle , sweepAngle );
			graphics.SmoothingMode = SmoothingMode.Default;
		}

		public void Render( Graphics graphics , Rectangle drawRectangle , DateTime time , AnalogClockScheme scheme ) {
			// calculate inner rectangle.
			Rectangle innerRectangle;
			if( drawRectangle.Width > drawRectangle.Height ) {
				innerRectangle = new Rectangle( drawRectangle.Left + drawRectangle.Width / 2 - drawRectangle.Height / 2 , drawRectangle.Top , drawRectangle.Height , drawRectangle.Height );
			} else {
				innerRectangle = new Rectangle( drawRectangle.Width , drawRectangle.Top + drawRectangle.Height / 2 - drawRectangle.Width / 2 , drawRectangle.Width , drawRectangle.Width );
			}
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			// draw border and background
			graphics.FillEllipse( GetBackgroundBrush( scheme ) , innerRectangle );
			graphics.DrawEllipse( GetBorderPen( scheme ) , innerRectangle );

			int x1;
			int y1;
			int x2;
			int y2;

			// draw minuteindicators
			for( int i = 0 ; i < 60 ; i++ ) {
				x1 = innerRectangle.Left + innerRectangle.Width / 2 +
					(int)( innerRectangle.Width / 2 * Math.Sin( 2 * Math.PI * (double)i / 60.0f ) );
				y1 = innerRectangle.Top + innerRectangle.Height / 2 -
					(int)( innerRectangle.Height / 2 * Math.Cos( 2 * Math.PI * (double)i / 60.0f ) );

				x2 = innerRectangle.Left + innerRectangle.Width / 2 +
					(int)( innerRectangle.Width / 2.10f * Math.Sin( 2 * Math.PI * (double)i / 60.0f ) );
				y2 = innerRectangle.Top + innerRectangle.Height / 2 -
					(int)( innerRectangle.Height / 2.10f * Math.Cos( 2 * Math.PI * (double)i / 60.0f ) );

				graphics.DrawLine( GetHourIndicatorPen( scheme ) , x1 , y1 , x2 , y2 );
			}

			// draw hourindicators
			for( int i = 0 ; i < 12 ; i++ ) {
				x1 = innerRectangle.Left + innerRectangle.Width / 2 +
					(int)( innerRectangle.Width / 2 * Math.Sin( 2 * Math.PI * (double)i / 12.0f ) );
				y1 = innerRectangle.Top + innerRectangle.Height / 2 -
					(int)( innerRectangle.Height / 2 * Math.Cos( 2 * Math.PI * (double)i / 12.0f ) );

				x2 = innerRectangle.Left + innerRectangle.Width / 2 +
					(int)( innerRectangle.Width / 2.25f * Math.Sin( 2 * Math.PI * (double)i / 12.0f ) );
				y2 = innerRectangle.Top + innerRectangle.Height / 2 -
					(int)( innerRectangle.Height / 2.25f * Math.Cos( 2 * Math.PI * (double)i / 12.0f ) );

				graphics.DrawLine( GetHourIndicatorPen( scheme ) , x1 , y1 , x2 , y2 );
			}

			// draw time
			Rectangle bottomRect = new Rectangle( innerRectangle.Left , innerRectangle.Top + innerRectangle.Height / 2 , innerRectangle.Width , innerRectangle.Height / 2 );
			StringFormat timeStringFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center };
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics.DrawString( time.ToShortTimeString() , scheme.TimeFont , new SolidBrush( scheme.TimeColor ) , bottomRect , timeStringFormat );
			graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
			timeStringFormat.Dispose();

			// draw hourhand
			double hour = (double)time.Hour + (double)time.Minute / 60.0f;
			x1 = innerRectangle.Left + innerRectangle.Width / 2 +
					(int)( innerRectangle.Width / 4 * Math.Sin( 2 * Math.PI * hour / 12.0f ) );
			y1 = innerRectangle.Top + innerRectangle.Height / 2 -
				(int)( innerRectangle.Height / 4 * Math.Cos( 2 * Math.PI * hour / 12.0f ) );

			x2 = innerRectangle.Left + innerRectangle.Width / 2;
			y2 = innerRectangle.Top + innerRectangle.Height / 2;

			graphics.DrawLine( GetHourHandPen( scheme ) , x1 , y1 , x2 , y2 );

			// draw minutehand
			double minute = (double)time.Minute + (double)time.Second / 60.0f;
			x1 = innerRectangle.Left + innerRectangle.Width / 2 +
					(int)( innerRectangle.Width / 3 * Math.Sin( 2 * Math.PI * minute / 60.0f ) );
			y1 = innerRectangle.Top + innerRectangle.Height / 2 -
				(int)( innerRectangle.Height / 3 * Math.Cos( 2 * Math.PI * minute / 60.0f ) );

			x2 = innerRectangle.Left + innerRectangle.Width / 2;
			y2 = innerRectangle.Top + innerRectangle.Height / 2;

			graphics.DrawLine( GetMinuteHandPen( scheme ) , x1 , y1 , x2 , y2 );

			// draw secondhand
			double second = (double)time.Second;
			x1 = innerRectangle.Left + innerRectangle.Width / 2 +
					(int)( innerRectangle.Width / 2.50f * Math.Sin( 2 * Math.PI * second / 60.0f ) );
			y1 = innerRectangle.Top + innerRectangle.Height / 2 -
				(int)( innerRectangle.Height / 2.50f * Math.Cos( 2 * Math.PI * second / 60.0f ) );

			x2 = innerRectangle.Left + innerRectangle.Width / 2;
			y2 = innerRectangle.Top + innerRectangle.Height / 2;

			graphics.DrawLine( GetSecondHandPen( scheme ) , x1 , y1 , x2 , y2 );

			graphics.SmoothingMode = SmoothingMode.Default;
		}

		#region -_ Private Methods _-

		private Pen GetBorderPen( AnalogClockScheme scheme ) {
			if( _borderPen == null ) {
				_borderPen = new Pen( scheme.BorderColor , scheme.BorderWidth );
			}
			return _borderPen;
		}

		private Pen GetHourIndicatorPen( AnalogClockScheme scheme ) {
			if( _hourIndicatorPen == null ) {
				_hourIndicatorPen = new Pen( scheme.HourIndicatorColor , scheme.HourIndicatorWidth );
			}
			return _hourIndicatorPen;
		}

		private Pen GetHourHandPen( AnalogClockScheme scheme ) {
			if( _hourHandPen == null ) {
				_hourHandPen = new Pen( scheme.HourHandColor , scheme.HourHandWidth );
			}
			return _hourHandPen;
		}

		private Pen GetMinuteHandPen( AnalogClockScheme scheme ) {
			if( _minuteHandPen == null ) {
				_minuteHandPen = new Pen( scheme.MinuteHandColor , scheme.MinuteHandWidth );
			}
			return _minuteHandPen;
		}

		private Pen GetSecondHandPen( AnalogClockScheme scheme ) {
			if( _secondHandPen == null ) {
				_secondHandPen = new Pen( scheme.SecondHandColor , scheme.SecondHandWidth );
			}
			return _secondHandPen;
		}

		private SolidBrush GetBackgroundBrush( AnalogClockScheme scheme ) {
			if( _backgroundBrush == null ) {
				_backgroundBrush = new SolidBrush( scheme.BackgroundColor );
			}
			return _backgroundBrush;
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
