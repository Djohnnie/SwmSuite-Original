using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SwmSuite.Presentation.Common.AnalogClock {

	public class NiceAnalogClockRenderer {

		#region -_ Private Members _-

		private Bitmap _analogClockCachedBackground;

		#endregion

		#region -_ Public Members _-


		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="NiceAnalogClockRenderer"/> class.
		/// </summary>
		public NiceAnalogClockRenderer() {

		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Renders the nice analogclock control using this renderer.
		/// </summary>
		/// <param name="graphics">The graphics to render on.</param>
		/// <param name="drawRectangle">The rectangle to render in.</param>
		/// <param name="scheme">The scheme to render with.</param>
		public void Render( Graphics graphics , Rectangle drawRectangle , NiceAnalogClockScheme scheme ) {
			graphics.DrawImageUnscaled( GetBackground( drawRectangle , scheme ) , drawRectangle );
		}

		/// <summary>
		/// Invalidates this instance.
		/// </summary>
		public void Invalidate() {
			if( _analogClockCachedBackground != null ) {
				_analogClockCachedBackground.Dispose();
				_analogClockCachedBackground = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private void DrawIndicators( Graphics graphics , Rectangle drawRectangle , NiceAnalogClockScheme scheme ) {
			int x1;
			int y1;
			int x2;
			int y2;

			int hourIndicatorWidth = (int)( ( scheme.HourIndicatorWidth / 100.0f ) * (float)drawRectangle.Width );
			int minuteIndicatorWidth = (int)( ( scheme.MinuteIndicatorWidth / 100.0f ) * (float)drawRectangle.Width );
			Pen hourIndicatorPen = new Pen( Color.White , hourIndicatorWidth );
			Pen minuteIndicatorPen = new Pen( Color.White , minuteIndicatorWidth );

			// draw minuteindicators
			for( int i = 0 ; i < 60 ; i++ ) {
				x1 = drawRectangle.Left + drawRectangle.Width / 2 +
					(int)( drawRectangle.Width / 2 * Math.Sin( 2 * Math.PI * (double)i / 60.0f ) );
				y1 = drawRectangle.Top + drawRectangle.Height / 2 -
					(int)( drawRectangle.Height / 2 * Math.Cos( 2 * Math.PI * (double)i / 60.0f ) );

				x2 = drawRectangle.Left + drawRectangle.Width / 2 +
					(int)( drawRectangle.Width / ( 2.0f + scheme.InnerRingWidth/25 ) * Math.Sin( 2 * Math.PI * (double)i / 60.0f ) );
				y2 = drawRectangle.Top + drawRectangle.Height / 2 -
					(int)( drawRectangle.Height / ( 2.0f + scheme.InnerRingWidth / 25 ) * Math.Cos( 2 * Math.PI * (double)i / 60.0f ) );

				graphics.DrawLine( minuteIndicatorPen , x1 , y1 , x2 , y2 );
			}

			// draw hourindicators
			for( int i = 0 ; i < 12 ; i++ ) {
				x1 = drawRectangle.Left + drawRectangle.Width / 2 +
					(int)( drawRectangle.Width / 2 * Math.Sin( 2 * Math.PI * (double)i / 12.0f ) );
				y1 = drawRectangle.Top + drawRectangle.Height / 2 -
					(int)( drawRectangle.Height / 2 * Math.Cos( 2 * Math.PI * (double)i / 12.0f ) );

				x2 = drawRectangle.Left + drawRectangle.Width / 2 +
					(int)( drawRectangle.Width / ( 2.0f + scheme.InnerRingWidth / 25 ) * Math.Sin( 2 * Math.PI * (double)i / 12.0f ) );
				y2 = drawRectangle.Top + drawRectangle.Height / 2 -
					(int)( drawRectangle.Height / ( 2.0f + scheme.InnerRingWidth / 25 ) * Math.Cos( 2 * Math.PI * (double)i / 12.0f ) );

				graphics.DrawLine( hourIndicatorPen , x1 , y1 , x2 , y2 );
			}

			hourIndicatorPen.Dispose();
			minuteIndicatorPen.Dispose();
		}

		private Bitmap GetBackground( Rectangle drawRectangle , NiceAnalogClockScheme scheme ) {
			if( _analogClockCachedBackground == null ) {
				// Prepare bitmap and graphics.
				_analogClockCachedBackground = new Bitmap( drawRectangle.Width , drawRectangle.Height );
				Graphics graphics = Graphics.FromImage( _analogClockCachedBackground );
				// Prepare rectangles, brushes and pens.
				Rectangle outerRectangle = GetOuterRectangle( drawRectangle );
				int borderRectangleOffset = (int)( ( scheme.OuterRingWidth / 100.0f ) * (float)outerRectangle.Width );
				Rectangle borderRectangle = new Rectangle( outerRectangle.Left + borderRectangleOffset , outerRectangle.Top + borderRectangleOffset , outerRectangle.Width - 2 * borderRectangleOffset , outerRectangle.Height - 2 * borderRectangleOffset );
				int innerRectangleOffset = (int)( ( ( scheme.OuterRingWidth + scheme.InnerRingWidth ) / 100.0f ) * (float)outerRectangle.Width );
				Rectangle innerRectangle = new Rectangle( outerRectangle.Left + innerRectangleOffset , outerRectangle.Top + innerRectangleOffset , outerRectangle.Width - 2 * innerRectangleOffset , outerRectangle.Height - 2 * innerRectangleOffset );
				LinearGradientBrush backgroundBrush1 = new LinearGradientBrush( outerRectangle , scheme.FaceColor1 , scheme.FaceColor2 , LinearGradientMode.ForwardDiagonal );
				LinearGradientBrush backgroundBrush2 = new LinearGradientBrush( outerRectangle , scheme.FaceColor2 , scheme.FaceColor1 , LinearGradientMode.ForwardDiagonal );
				// Start drawing.
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.FillEllipse( backgroundBrush1 , outerRectangle );
				graphics.FillEllipse( backgroundBrush2 , borderRectangle );
				graphics.FillEllipse( backgroundBrush1 , innerRectangle );
				DrawIndicators( graphics , borderRectangle , scheme );
				// Dispose objects.
				backgroundBrush1.Dispose();
			}
			return _analogClockCachedBackground;
		}

		private Rectangle GetOuterRectangle( Rectangle bounds ) {
			if( bounds.Width > bounds.Height ) {
				return new Rectangle( bounds.Left + bounds.Width / 2 - bounds.Height / 2 , bounds.Top , bounds.Height , bounds.Height );
			} else {
				return new Rectangle( bounds.Left , bounds.Top + bounds.Height / 2 - bounds.Width / 2 , bounds.Width , bounds.Width );
			}
		}

		#endregion

	}

}
