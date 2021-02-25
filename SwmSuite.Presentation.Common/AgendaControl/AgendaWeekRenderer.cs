using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing.Text;
using System.Drawing;
using System.Collections.ObjectModel;

namespace SwmSuite.Presentation.Common.AgendaControl {

	public class AgendaWeekRenderer : AgendaRenderer {

		public override void RenderHeaderCaption( Graphics graphics , Rectangle bounds , AgendaScheme scheme , DateTime date ) {
			int dayWidth = ( bounds.Width - scheme.TimeRulerWidth ) / 7;
			TextRenderingHint oldRendering = graphics.TextRenderingHint;
			graphics.TextRenderingHint = scheme.HeaderCaptionRendering;
			for( int i = 0 ; i < 7 ; i++ ) {
				Rectangle drawRectangle = new Rectangle( bounds.Left + scheme.TimeRulerWidth + i * dayWidth , bounds.Top , dayWidth , bounds.Height );
				DateTime day = date.AddDays( i );
				graphics.DrawString( day.ToString( "ddd dd/MM" ) , scheme.HeaderCaptionFont , GetHeaderCaptionBrush( scheme ) , drawRectangle , GetHeaderCaptionFormat() );
			}
			graphics.TextRenderingHint = oldRendering;
		}

		public override void RenderSeperators( Graphics graphics , Rectangle bounds , AgendaScheme scheme ) {
			int dayWidth = ( bounds.Width - scheme.TimeRulerWidth ) / 7;
			for( int i = 0 ; i < 7 ; i++ ) {
				Rectangle drawRectangle = new Rectangle( bounds.Left + scheme.TimeRulerWidth + i * dayWidth , bounds.Top , dayWidth , bounds.Height );
				graphics.DrawLine( GetBorderPen( scheme ) , drawRectangle.Left , drawRectangle.Top , drawRectangle.Left , drawRectangle.Bottom );
			}
		}

		public override void RenderSelection( Graphics graphics , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings , DateTime date , DateTime selectionStart , DateTime selectionEnd ) {
			List<Rectangle> rectangles = GetRowRectangles( settings , bounds );
			for( int i = 0 ; i < 7 ; i++ ) {
				float currentHour = (float)settings.CurrentBeginPosition;
				for( int j = 0 ; j < rectangles.Count / 7 ; j++ ) {
					DateTime now = new DateTime( date.Year , date.Month , date.Day , (int)currentHour , currentHour - (int)currentHour > 0 ? 30 : 0 , 0 );
					now = now.AddDays( i );
					if( now >= selectionStart && now <= selectionEnd ) {
						graphics.FillRectangle( GetSelectionBrush( scheme ) , rectangles[i * ( rectangles.Count / 7 ) + j] );
					}
					currentHour += 0.5f;
				}
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
					for( int i = 0 ; i < 7 ; i++ ) {
						float currentHour = (float)settings.CurrentBeginPosition;
						for( int j = 0 ; j < rectangles.Count / 7 ; j++ ) {
							DateTime now = new DateTime( date.Year , date.Month , date.Day , (int)currentHour , currentHour - (int)currentHour > 0 ? 30 : 0 , 0 );
							now = now.AddDays( i );
							DateTime next = new DateTime( date.Year , date.Month , date.Day , (int)currentHour , currentHour - (int)currentHour > 0 ? 30 : 0 , 0 ).AddMinutes( 30 );
							next = next.AddDays( i );
							if( agendaAppointment.Begin >= now && agendaAppointment.Begin <= next ) {
								startRectangle = rectangles[i * ( rectangles.Count / 7 ) + j];
							}
							if( agendaAppointment.End >= now && agendaAppointment.End <= next ) {
								endRectangle = rectangles[i * ( rectangles.Count / 7 ) + j];
							}
							currentHour += 0.5f;
						}
						if( startRectangle.HasValue && endRectangle.HasValue ) {
							int appointmentWidth = startRectangle.Value.Width / agendaAppointment.Overlaps;
							agendaAppointment.Bounds = new Rectangle( startRectangle.Value.Left + appointmentWidth * agendaAppointment.OverlapOffset , startRectangle.Value.Top , appointmentWidth , endRectangle.Value.Top - startRectangle.Value.Top );
						}
					}
				}
				if( agendaAppointment.Bounds.HasValue ) {
					RenderAppointment( graphics , agendaAppointment.Bounds.Value , scheme , agendaAppointment );
				}
			}

			//int numberOfRows = AgendaTools.GetNumberOfRows( settings );
			//int[] rowHeights = AgendaTools.GetRowHeights( settings , bounds );
			//// Draw appointments.
			//foreach( AgendaAppointment agendaAppointment in appointments ) {
			//  if( agendaAppointment.Begin.Hour < settings.DefaultBeginHour ) {
			//    agendaAppointment.Begin = new DateTime( agendaAppointment.Begin.Year , agendaAppointment.Begin.Month , agendaAppointment.Begin.Day , settings.DefaultBeginHour , 0 , 0 );
			//  }
			//  if( agendaAppointment.End.Hour > settings.DefaultEndHour || ( agendaAppointment.End.Hour == settings.DefaultEndHour && agendaAppointment.End.Minute > 0 ) ) {
			//    agendaAppointment.End = new DateTime( agendaAppointment.Begin.Year , agendaAppointment.Begin.Month , agendaAppointment.Begin.Day , settings.DefaultEndHour , 0 , 0 );
			//  }
			//  Rectangle? startRectangle = null;
			//  Rectangle? endRectangle = null;
			//  int dayWidth = bounds.Width / 7;
			//  for( int i = 0 ; i < 7 ; i++ ) {
			//    int heightSum = 0;
			//    float currentHour = (float)settings.CurrentBeginPosition;
			//    for( int j = 0 ; j < numberOfRows ; j++ ) {
			//      DateTime now = new DateTime( date.Year , date.Month , date.Day , (int)currentHour , currentHour - (int)currentHour > 0 ? 30 : 0 , 0 );
			//      now = now.AddDays( i );
			//      DateTime next = new DateTime( date.Year , date.Month , date.Day , (int)currentHour , currentHour - (int)currentHour > 0 ? 30 : 0 , 0 ).AddMinutes( 30 );
			//      next = next.AddDays( i );
			//      if( agendaAppointment.Begin >= now && agendaAppointment.Begin <= next ) {
			//        startRectangle = new Rectangle( bounds.Left + i * dayWidth , bounds.Top + heightSum , dayWidth , rowHeights[j] );
			//      }
			//      if( agendaAppointment.End >= now && agendaAppointment.End <= next ) {
			//        endRectangle = new Rectangle( bounds.Left + i * dayWidth , bounds.Top + heightSum , dayWidth , rowHeights[j] );
			//      }
			//      currentHour += 0.5f;
			//      heightSum += rowHeights[j];
			//    }
			//    if( startRectangle.HasValue && endRectangle.HasValue ) {
			//      Rectangle drawRectangle = new Rectangle( startRectangle.Value.Left , startRectangle.Value.Top , startRectangle.Value.Width , endRectangle.Value.Top - startRectangle.Value.Top );
			//      RenderAppointment( graphics , drawRectangle , scheme , agendaAppointment.Color );
			//    }
			//  }
			//}
		}

		protected override List<Rectangle> GetRowRectangles( AgendaSettings settings , Rectangle bounds ) {
			if( _rowRectangles == null ) {
				_rowRectangles = new List<Rectangle>();
				int numberOfRows = AgendaTools.GetNumberOfRows( settings );
				int[] rowHeights = AgendaTools.GetRowHeights( settings , bounds );
				int dayWidth = bounds.Width / 7;
				for( int i = 0 ; i < 7 ; i++ ) {
					// Draw rows.
					int heightSum = 0;
					float currentHour = (float)settings.CurrentBeginPosition;
					for( int j = 0 ; j < numberOfRows ; j++ ) {
						_rowRectangles.Add( new Rectangle( bounds.Left + i * dayWidth , bounds.Top + heightSum , dayWidth , rowHeights[j] ) );
						heightSum += rowHeights[j];
					}
				}
			}
			return _rowRectangles;
		}

	}

}
