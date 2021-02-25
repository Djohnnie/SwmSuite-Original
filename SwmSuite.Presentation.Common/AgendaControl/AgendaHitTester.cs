using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;

namespace SwmSuite.Presentation.Common.AgendaControl {

	public abstract class AgendaHitTester {

		#region -_ Private Members _-

		/// <summary>
		/// Gets or sets the selection.
		/// </summary>
		/// <value>The selection.</value>
		public DateTime Selection { get; set; }

		/// <summary>
		/// Gets or sets the appointment.
		/// </summary>
		/// <value>The appointment.</value>
		public AgendaAppointment Appointment { get; set; }

		#endregion

		#region -_ Public Methods _-

		public virtual AgendaHitTestArea HitTest( Point hit , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings , DateTime selection , Collection<AgendaAppointment> appointments ) {
			AgendaHitTestArea areaToReturn = AgendaHitTestArea.Content;
			Rectangle headerRectangle = new Rectangle( bounds.Left , bounds.Top , bounds.Width - 1 , scheme.HeaderHeight );
			Rectangle timeRulerRectangle = new Rectangle( bounds.Left , bounds.Top + scheme.HeaderHeight , scheme.TimeRulerWidth , bounds.Height - scheme.HeaderHeight - 1 );
			Rectangle contentsRectangle = new Rectangle( bounds.Left + scheme.TimeRulerWidth , bounds.Top + scheme.HeaderHeight , bounds.Width - scheme.TimeRulerWidth - 1 , bounds.Height - scheme.HeaderHeight - 1 );
			if( headerRectangle.Contains( hit ) ) {
				areaToReturn = AgendaHitTestArea.Header;
			}
			if( timeRulerRectangle.Contains( hit ) ) {
				areaToReturn = AgendaHitTestArea.TimeRuler;
			}
			if( contentsRectangle.Contains( hit ) ) {
				areaToReturn = AgendaHitTestArea.Content;
				Point point = new Point( hit.X - ( contentsRectangle.Left - bounds.Left ) , hit.Y - ( contentsRectangle.Top - bounds.Top ) );
				HitTestContents( hit , contentsRectangle , scheme , settings , selection );
			}
			areaToReturn = HitTestAppointment( hit , appointments , areaToReturn );
			return areaToReturn;
		}

		public virtual AgendaHitTestArea HitTestAppointment( Point hit , Collection<AgendaAppointment> appointments , AgendaHitTestArea hitTestArea ) {
			AgendaHitTestArea areaToReturn = hitTestArea;
			this.Appointment = null;
			foreach( AgendaAppointment appointment in appointments ){
				if( appointment.Bounds.HasValue ){
					if( appointment.Bounds.Value.Contains( hit)){
						this.Appointment = appointment;
						areaToReturn = AgendaHitTestArea.Appointment;
					}
				}
			}
			return areaToReturn;
		}

		#endregion

		#region -_ Private Methods _-

		protected abstract void HitTestContents( Point hit , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings , DateTime selection );

		#endregion

	}

}
