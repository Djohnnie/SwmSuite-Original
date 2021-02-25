using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Collections.ObjectModel;

namespace SwmSuite.Presentation.Common.AgendaControl {

	public class AgendaDayRenderer : AgendaRenderer {



		#region -_ Public Methods _-

		public override void RenderHeaderCaption( Graphics graphics , Rectangle bounds , AgendaScheme scheme , DateTime date ) {
			Rectangle drawRectangle = new Rectangle( bounds.Left + scheme.TimeRulerWidth , bounds.Top , bounds.Width - scheme.TimeRulerWidth - 1 , bounds.Height );
			TextRenderingHint oldRendering = graphics.TextRenderingHint;
			graphics.TextRenderingHint = scheme.HeaderCaptionRendering;
			graphics.DrawString( date.ToLongDateString() , scheme.HeaderCaptionFont , GetHeaderCaptionBrush( scheme ) , drawRectangle , GetHeaderCaptionFormat() );
			graphics.TextRenderingHint = oldRendering;
		}

		public override void RenderSeperators( Graphics graphics , Rectangle bounds , AgendaScheme scheme ) {

		}

		public override void RenderSelection( Graphics graphics , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings , DateTime date , DateTime selectionStart , DateTime selectionEnd ) {
			List<Rectangle> rectangles = GetRowRectangles( settings , bounds );
			float currentHour = (float)settings.CurrentBeginPosition;
			for( int i = 0 ; i < rectangles.Count ; i++ ) {
				DateTime now = new DateTime( date.Year , date.Month , date.Day , (int)currentHour , currentHour - (int)currentHour > 0 ? 30 : 0 , 0 );
				if( now >= selectionStart && now <= selectionEnd ) {
					graphics.FillRectangle( GetSelectionBrush( scheme ) , rectangles[i] );
				}
				currentHour += 0.5f;
			}
		}

		public override void RenderAppointments( Graphics graphics , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings , DateTime date , Collection<AgendaAppointment> appointments ) {
			List<Rectangle> rectangles = GetRowRectangles( settings , bounds );
			foreach( AgendaAppointment agendaAppointment in appointments ) {
				if( !agendaAppointment.Bounds.HasValue ) {
					if( agendaAppointment.Begin.Hour < settings.DefaultBeginHour ) {
						agendaAppointment.Begin = new DateTime( agendaAppointment.Begin.Year , agendaAppointment.Begin.Month , agendaAppointment.Begin.Day , settings.DefaultBeginHour , 0 , 0 );
					}
					if( agendaAppointment.End.Hour > settings.DefaultEndHour || ( agendaAppointment.End.Hour == settings.DefaultEndHour && agendaAppointment.End.Minute > 0 ) ) {
						agendaAppointment.End = new DateTime( agendaAppointment.Begin.Year , agendaAppointment.Begin.Month , agendaAppointment.Begin.Day , settings.DefaultEndHour , 0 , 0 );
					}
					Rectangle? startRectangle = null;
					Rectangle? endRectangle = null;
					float currentHour = (float)settings.CurrentBeginPosition;
					for( int i = 0 ; i < rectangles.Count ; i++ ) {
						DateTime now = new DateTime( date.Year , date.Month , date.Day , (int)currentHour , currentHour - (int)currentHour > 0 ? 30 : 0 , 0 );
						DateTime next = new DateTime( date.Year , date.Month , date.Day , (int)currentHour , currentHour - (int)currentHour > 0 ? 30 : 0 , 0 ).AddMinutes( 30 );
						if( agendaAppointment.Begin >= now && agendaAppointment.Begin <= next ) {
							startRectangle = rectangles[i];
						}
						if( agendaAppointment.End >= now && agendaAppointment.End <= next ) {
							endRectangle = rectangles[i];
						}
						currentHour += 0.5f;
					}
					if( startRectangle.HasValue && endRectangle.HasValue ) {
						int appointmentWidth = startRectangle.Value.Width / agendaAppointment.Overlaps;
						agendaAppointment.Bounds = new Rectangle( startRectangle.Value.Left + appointmentWidth * agendaAppointment.OverlapOffset , startRectangle.Value.Top , appointmentWidth , endRectangle.Value.Top - startRectangle.Value.Top );
					}
				}
				if( agendaAppointment.Bounds.HasValue ) {
					RenderAppointment( graphics , agendaAppointment.Bounds.Value , scheme , agendaAppointment );
				}
			}
		}

		protected override List<Rectangle> GetRowRectangles( AgendaSettings settings , Rectangle bounds ) {
			if( _rowRectangles == null ) {
				_rowRectangles = new List<Rectangle>();
				int numberOfRows = AgendaTools.GetNumberOfRows( settings );
				int[] rowHeights = AgendaTools.GetRowHeights( settings , bounds );
				// Draw rows.
				int heightSum = 0;
				float currentHour = (float)settings.CurrentBeginPosition;
				for( int i = 0 ; i < numberOfRows ; i++ ) {
					_rowRectangles.Add( new Rectangle( bounds.Left , bounds.Top + heightSum , bounds.Width , rowHeights[i] ) );
					heightSum += rowHeights[i];
				}
			}
			return _rowRectangles;
		}

		#endregion

		#region -_ Private Members _-



		#endregion
	}

}
