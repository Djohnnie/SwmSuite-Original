using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Collections.ObjectModel;

namespace SwmSuite.Presentation.Common.AgendaControl {

	public class AgendaMonthRenderer : AgendaRenderer {

		public override void RenderHeaderCaption( Graphics graphics , Rectangle bounds , AgendaScheme scheme , DateTime date ) {
			int dayWidth = ( bounds.Width - scheme.TimeRulerWidth ) / 7;
			TextRenderingHint oldRendering = graphics.TextRenderingHint;
			graphics.TextRenderingHint = scheme.HeaderCaptionRendering;
			for( int i = 0 ; i < 7 ; i++ ) {
				Rectangle drawRectangle = new Rectangle( bounds.Left + scheme.TimeRulerWidth + i * dayWidth , bounds.Top , dayWidth , bounds.Height );
				DateTime day = date.AddDays( i );
				graphics.DrawString( day.ToString( "ddd" ) , scheme.HeaderCaptionFont , GetHeaderCaptionBrush( scheme ) , drawRectangle , GetHeaderCaptionFormat() );
			}
			graphics.TextRenderingHint = oldRendering;
		}

		public override void RenderSeperators( Graphics graphics , Rectangle bounds , AgendaScheme scheme ) {

		}

		public override void RenderSelection( Graphics graphics , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings , DateTime date , DateTime selectionStart , DateTime selectionEnd ) {
		}

		public override void RenderAppointments( Graphics graphics , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings , DateTime date , Collection<AgendaAppointment> appointments ) {

		}

		protected override List<Rectangle> GetRowRectangles( AgendaSettings settings , Rectangle bounds ) {
			List<Rectangle> rectanglesToReturn = new List<Rectangle>();
			return rectanglesToReturn;
		}

	}

}
