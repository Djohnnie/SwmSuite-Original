using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using SwmSuite.Presentation.Drawing;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.AgendaControl {

	public abstract class AgendaRenderer : IDisposable {

		#region -_ Private Members _-

		private LinearGradientBrush _headerTopFillBrush = null;
		private LinearGradientBrush _headerBottomFillBrush = null;
		private SolidBrush _headerCaptionBrush = null;
		private StringFormat _headerCaptionFormat = null;

		private LinearGradientBrush _timeRulerFillBrush = null;
		private SolidBrush _timeRulerCaptionBrush = null;
		private Pen _timeRulerBorderPen = null;
		private StringFormat _timerRulerCaptionFormat = null;

		private SolidBrush _backgroundFillBrush = null;
		private Pen _gridPen = null;

		private Pen _borderPen = null;

		private SolidBrush _selectionBrush = null;

		protected List<Rectangle> _rowRectangles = null;

		#endregion

		#region -_ Public Methods _-

		public abstract void RenderHeaderCaption( Graphics graphics , Rectangle bounds , AgendaScheme scheme , DateTime date );

		public abstract void RenderSeperators( Graphics graphics , Rectangle bounds , AgendaScheme scheme );

		public abstract void RenderSelection( Graphics graphics , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings , DateTime date , DateTime selectionStart , DateTime selectionEnd );

		public void RenderHeader( Graphics graphics , Rectangle bounds , AgendaScheme scheme ) {
			Rectangle topRectangle = new Rectangle( bounds.Left , bounds.Top , bounds.Width , bounds.Height / 2 );
			Rectangle bottomRectangle = new Rectangle( bounds.Left , topRectangle.Bottom , bounds.Width , bounds.Height / 2 );
			graphics.FillRectangle( GetHeaderTopFillBrush( topRectangle , scheme ) , topRectangle );
			graphics.FillRectangle( GetHeaderBottomFillBrush( bottomRectangle , scheme ) , bottomRectangle );
			//TextRenderingHint oldRendering = graphics.TextRenderingHint;
			//graphics.TextRenderingHint = scheme.HeaderCaptionRendering;
			//graphics.DrawString( caption , scheme.HeaderCaptionFont , GetHeaderCaptionBrush( scheme ) , bounds , GetHeaderCaptionFormat() );
			//graphics.TextRenderingHint = oldRendering;
		}

		public void RenderBorder( Graphics graphics , Rectangle bounds , AgendaScheme scheme ) {
			graphics.DrawRectangle( GetBorderPen( scheme ) , bounds );
		}

		//public abstract void RenderAgenda( Graphics graphics , Rectangle bounds , AgendaScheme scheme , List<AgendaAppointment> data );

		public void RenderTimeRuler( Graphics graphics , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings ) {
			graphics.FillRectangle( GetTimeRulerFillBrush( bounds , scheme ) , bounds );

			int numberOfRows = AgendaTools.GetNumberOfRows( settings );
			int[] rowHeights = AgendaTools.GetRowHeights( settings , bounds );
			// Draw rows.
			int heightSum = 0;
			String hourCaption = "";
			float currentHour = (float)settings.CurrentBeginPosition;
			for( int i = 0 ; i < numberOfRows ; i++ ) {
				int height = 0;
				if( i < rowHeights.Length - 1 ) {
					height = rowHeights[i] + rowHeights[i + 1];
				} else {
					height = rowHeights[i] * 2;
				}
				Rectangle rowBounds = new Rectangle( bounds.Left , bounds.Top + heightSum - rowHeights[i] , bounds.Width , height );
				Rectangle rowBounds2 = new Rectangle( bounds.Left , bounds.Top + heightSum - rowHeights[i] , bounds.Width , height );
				if( currentHour - (int)currentHour == 0.0f && i > 0 ) {
					hourCaption = new DateTime( 2000 , 1 , 1 , (int)currentHour , 0 , 0 ).ToShortTimeString();
					//graphics.DrawString( hourCaption , scheme.TimeRulerCaptionFont , GetTimeRulerCaptionBrush( scheme ) , rowBounds , GetTimeRulerCaptionFormat() );
					TextRenderer.DrawText( graphics , hourCaption , scheme.TimeRulerCaptionFont , rowBounds , scheme.TimeRulerCaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
				} else {
					//graphics.DrawLine( GetTimeRulerBorderPen( scheme ) , rowBounds2.Left , rowBounds2.Bottom , rowBounds2.Right , rowBounds2.Bottom );
				}
				currentHour += 0.5f;
				heightSum += rowHeights[i];
			}
		}

		//public abstract void RenderContents( Graphics graphics , Rectangle bounds , AgendaScheme scheme );

		public void RenderGrid( Graphics graphics , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings ) {
			int numberOfRows = AgendaTools.GetNumberOfRows( settings );
			int[] rowHeights = AgendaTools.GetRowHeights( settings , bounds );
			// Draw rows.
			int heightSum = 0;
			float currentHour = (float)settings.CurrentBeginPosition;
			for( int i = 0 ; i < numberOfRows ; i++ ) {
				Rectangle rowBounds = new Rectangle( bounds.Left , bounds.Top + heightSum , bounds.Width , rowHeights[i] );
				//graphics.DrawLine( GetGridPen( scheme ) , rowBounds.Left , rowBounds.Top + rowBounds.Height / 2 , rowBounds.Right , rowBounds.Top + rowBounds.Height / 2 );
				graphics.DrawLine( GetGridPen( scheme ) , rowBounds.Left , rowBounds.Bottom , rowBounds.Right , rowBounds.Bottom );
				currentHour += 0.5f;
				heightSum += rowHeights[i];
			}
		}

		public abstract void RenderAppointments( Graphics graphics , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings , DateTime date , Collection<AgendaAppointment> appointments );

		#region -_ Appointment _-

		public void RenderAppointment( Graphics graphics , Rectangle drawRectangle , AgendaScheme scheme , AgendaAppointment appointment ) {
			if( drawRectangle.Height > 0 ) {
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				GraphicsPath borderPath = DrawingTools.GetRoundedRect( drawRectangle , 10 );
				// Clear the appointmentfield.
				SolidBrush clearBrush = new SolidBrush( Color.White );
				graphics.FillPath( clearBrush , borderPath );
				clearBrush.Dispose();
				// Fill the appointment.

				LinearGradientBrush fillBrush = new LinearGradientBrush( drawRectangle ,
					appointment.Selected || appointment.Hovered ? appointment.Color3 : appointment.Color2 ,
					appointment.Selected || appointment.Hovered ? appointment.Color2 : appointment.Color3 , LinearGradientMode.ForwardDiagonal );
				graphics.FillPath( fillBrush , borderPath );
				fillBrush.Dispose();

				Rectangle timeRectangle = new Rectangle( drawRectangle.Left + 5 , drawRectangle.Top + 5 , drawRectangle.Width - 10 , (int)scheme.AppointmentTimeFont.Size * 2 + 1 );
				Rectangle titleRectangle = new Rectangle( drawRectangle.Left + 5 , drawRectangle.Top + 5 + (int)scheme.AppointmentTimeFont.Size * 2 + 5 , drawRectangle.Width - 10 , drawRectangle.Height - ( (int)scheme.AppointmentTimeFont.Size * 4 + 1 ) + 20 );
				Rectangle placeRectangle = new Rectangle( drawRectangle.Left + 5 , drawRectangle.Bottom - 5 - (int)scheme.AppointmentTimeFont.Size * 2 + 1 , drawRectangle.Width - 10 , (int)scheme.AppointmentTimeFont.Size * 2 + 1 );

				// Draw time
				String time = appointment.Begin.ToShortTimeString() + " - " + appointment.End.ToShortTimeString();
				TextRenderer.DrawText( graphics , time , scheme.AppointmentTimeFont , timeRectangle , scheme.AppointmentTimeColor , TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.EndEllipsis );

				// Draw title.
				graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				graphics.SetClip( titleRectangle );
				TextRenderer.DrawText( graphics , appointment.Title , scheme.AppointmentTitleFont , titleRectangle , scheme.AppointmentTitleColor , TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.EndEllipsis | TextFormatFlags.WordBreak | TextFormatFlags.PreserveGraphicsClipping );
				graphics.ResetClip();
				// Draw place.
				TextRenderer.DrawText( graphics , appointment.Place , scheme.AppointmentPlaceFont , placeRectangle , scheme.AppointmentPlaceColor , TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.EndEllipsis );

				graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
				// Draw the border.
				Pen borderPen = new Pen( appointment.Color1 , appointment.Selected ? 3.0f : 1.0f );
				graphics.DrawPath( borderPen , borderPath );
				borderPen.Dispose();
				graphics.SmoothingMode = SmoothingMode.Default;
			}
		}


		#endregion

		/// <summary>
		/// Invalidates this instance.
		/// </summary>
		public virtual void Invalidate() {
			if( _headerTopFillBrush != null ) {
				_headerTopFillBrush.Dispose();
				_headerTopFillBrush = null;
			}
			if( _headerBottomFillBrush != null ) {
				_headerBottomFillBrush.Dispose();
				_headerBottomFillBrush = null;
			}
			if( _headerCaptionBrush != null ) {
				_headerCaptionBrush.Dispose();
				_headerCaptionBrush = null;
			}
			if( _headerCaptionFormat != null ) {
				_headerCaptionFormat.Dispose();
				_headerCaptionFormat = null;
			}
			if( _timeRulerFillBrush != null ) {
				_timeRulerFillBrush.Dispose();
				_timeRulerFillBrush = null;
			}
			if( _timeRulerCaptionBrush != null ) {
				_timeRulerCaptionBrush.Dispose();
				_timeRulerCaptionBrush = null;
			}
			if( _timeRulerBorderPen != null ) {
				_timeRulerBorderPen.Dispose();
				_timeRulerBorderPen = null;
			}
			if( _timerRulerCaptionFormat != null ) {
				_timerRulerCaptionFormat.Dispose();
				_timerRulerCaptionFormat = null;
			}
			if( _borderPen != null ) {
				_borderPen.Dispose();
				_borderPen = null;
			}
			if( _backgroundFillBrush != null ) {
				_backgroundFillBrush.Dispose();
				_backgroundFillBrush = null;
			}
			if( _gridPen != null ) {
				_gridPen.Dispose();
				_gridPen = null;
			}
			if( _selectionBrush != null ) {
				_selectionBrush.Dispose();
				_selectionBrush = null;
			}
			if( _rowRectangles != null ) {
				_rowRectangles = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		protected LinearGradientBrush GetHeaderTopFillBrush( Rectangle bounds , AgendaScheme scheme ) {
			if( _headerTopFillBrush == null ) {
				_headerTopFillBrush = new LinearGradientBrush( bounds , scheme.HeaderBackColor1 , scheme.HeaderBackColor2 , LinearGradientMode.Vertical );
			}
			return _headerTopFillBrush;
		}

		protected LinearGradientBrush GetHeaderBottomFillBrush( Rectangle bounds , AgendaScheme scheme ) {
			if( _headerBottomFillBrush == null ) {
				_headerBottomFillBrush = new LinearGradientBrush( bounds , scheme.HeaderBackColor3 , scheme.HeaderBackColor4 , LinearGradientMode.Vertical );
			}
			return _headerBottomFillBrush;
		}

		protected SolidBrush GetHeaderCaptionBrush( AgendaScheme scheme ) {
			if( _headerCaptionBrush == null ) {
				_headerCaptionBrush = new SolidBrush( scheme.HeaderCaptionColor );
			}
			return _headerCaptionBrush;
		}

		protected StringFormat GetHeaderCaptionFormat() {
			if( _headerCaptionFormat == null ) {
				_headerCaptionFormat = new StringFormat();
				_headerCaptionFormat.Alignment = StringAlignment.Center;
				_headerCaptionFormat.LineAlignment = StringAlignment.Center;
			}
			return _headerCaptionFormat;
		}

		protected Pen GetBorderPen( AgendaScheme scheme ) {
			if( _borderPen == null ) {
				_borderPen = new Pen( scheme.BorderColor );
			}
			return _borderPen;
		}

		protected LinearGradientBrush GetTimeRulerFillBrush( Rectangle bounds , AgendaScheme scheme ) {
			if( _timeRulerFillBrush == null ) {
				_timeRulerFillBrush = new LinearGradientBrush( bounds , scheme.TimeRulerBackgroundColor1 , scheme.TimeRulerBackgroundColor2 , LinearGradientMode.ForwardDiagonal );
			}
			return _timeRulerFillBrush;
		}

		protected SolidBrush GetTimeRulerCaptionBrush( AgendaScheme scheme ) {
			if( _timeRulerCaptionBrush == null ) {
				_timeRulerCaptionBrush = new SolidBrush( scheme.TimeRulerCaptionColor );
			}
			return _timeRulerCaptionBrush;
		}

		protected Pen GetTimeRulerBorderPen( AgendaScheme scheme ) {
			if( _timeRulerBorderPen == null ) {
				_timeRulerBorderPen = new Pen( scheme.TimeRulerCaptionColor );
			}
			return _timeRulerBorderPen;
		}

		protected StringFormat GetTimeRulerCaptionFormat() {
			if( _timerRulerCaptionFormat == null ) {
				_timerRulerCaptionFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Near };
			}
			return _timerRulerCaptionFormat;
		}

		protected SolidBrush GetBackgroundFillBrush( AgendaScheme scheme ) {
			if( _backgroundFillBrush == null ) {
				_backgroundFillBrush = new SolidBrush( scheme.BackgroundColor );
			}
			return _backgroundFillBrush;
		}

		protected Pen GetGridPen( AgendaScheme scheme ) {
			if( _gridPen == null ) {
				_gridPen = new Pen( scheme.GridColor );
			}
			return _gridPen;
		}

		protected SolidBrush GetSelectionBrush( AgendaScheme scheme ) {
			if( _selectionBrush == null ) {
				_selectionBrush = new SolidBrush( scheme.SelectionColor );
			}
			return _selectionBrush;
		}

		protected abstract List<Rectangle> GetRowRectangles( AgendaSettings settings , Rectangle bounds );

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
