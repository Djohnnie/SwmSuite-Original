using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.Clock {
	
	public class ClockRenderer : IDisposable {

		#region -_ Private Members _-

		private SolidBrush _timeBrush = null;
		private StringFormat _timeFormat = null;
		private SolidBrush _dateBrush = null;
		private StringFormat _dateFormat = null;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ClockRenderer() {
		}

		#endregion

		#region -_ Public Methods _-

		public void DrawTimeAndDate( Graphics graphics , Rectangle drawRectangle , String time , String date , ClockScheme scheme ) {
			Rectangle topRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top , drawRectangle.Width , drawRectangle.Height / 2 );
			Rectangle bottomRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top + drawRectangle.Height / 2 , drawRectangle.Width , drawRectangle.Height / 2 );
			DrawTime( graphics , topRectangle , time , scheme );
			DrawDate( graphics , bottomRectangle , date , scheme );
		}

		public void DrawTime( Graphics graphics , Rectangle drawRectangle , String time , ClockScheme scheme ) {
			TextRenderingHint oldRendering = graphics.TextRenderingHint;
			graphics.TextRenderingHint = scheme.TimeRendering;
			graphics.DrawString( time , scheme.TimeFont , GetTimeBrush( scheme ) , drawRectangle , GetTimeFormat() );
			graphics.TextRenderingHint = oldRendering;
		}

		public void DrawDate( Graphics graphics , Rectangle drawRectangle , String date , ClockScheme scheme ) {
			TextRenderingHint oldRendering = graphics.TextRenderingHint;
			graphics.TextRenderingHint = scheme.DateRendering;
			graphics.DrawString( date , scheme.DateFont , GetDateBrush( scheme ) , drawRectangle , GetDateFormat() );
			graphics.TextRenderingHint = oldRendering;
		}

		public void Invalidate() {
			if( _timeBrush != null ) {
				_timeBrush.Dispose();
				_timeBrush = null;
			}
			if( _timeFormat != null ) {
				_timeFormat.Dispose();
				_timeFormat = null;
			}
			if( _dateBrush != null ) {
				_dateBrush.Dispose();
				_dateBrush = null;
			}

			if( _dateFormat != null ) {
				_dateFormat.Dispose();
				_dateFormat = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private SolidBrush GetTimeBrush( ClockScheme scheme ) {
			if( _timeBrush == null ) {
				_timeBrush = new SolidBrush( scheme.TimeColor );
			}
			return _timeBrush;
		}

		private StringFormat GetTimeFormat() {
			if( _timeFormat == null ) {
				_timeFormat = new StringFormat();
				_timeFormat.Alignment = StringAlignment.Far;
				_timeFormat.LineAlignment = StringAlignment.Far;
			}
			return _timeFormat;
		}

		private SolidBrush GetDateBrush( ClockScheme scheme ) {
			if( _dateBrush == null ) {
				_dateBrush = new SolidBrush( scheme.DateColor );
			}
			return _dateBrush;
		}

		private StringFormat GetDateFormat() {
			if( _dateFormat == null ) {
				_dateFormat = new StringFormat();
				_dateFormat.Alignment = StringAlignment.Far;
				_dateFormat.LineAlignment = StringAlignment.Near;
			}
			return _dateFormat;
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
