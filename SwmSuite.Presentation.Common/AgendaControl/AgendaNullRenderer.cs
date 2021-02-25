using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;

namespace SwmSuite.Presentation.Common.AgendaControl {
	
	public class AgendaNullRenderer : AgendaRenderer {

		public override void RenderHeaderCaption( Graphics graphics , Rectangle bounds , AgendaScheme scheme , DateTime date ) {
			
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
