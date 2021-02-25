using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwmSuite.Presentation.Common.AgendaControl {
	
	/// <summary>
	/// Class defining the event arguments for a selection changed event on the agenda control.
	/// </summary>
	public class AppointmentSelectionChangedEventArgs : EventArgs {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the appointment.
		/// </summary>
		/// <value>The appointment.</value>
		public AgendaAppointment Appointment { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AppointmentSelectionChangedEventArgs"/> class.
		/// </summary>
		public AppointmentSelectionChangedEventArgs() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AppointmentSelectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="appointment">The appointment.</param>
		public AppointmentSelectionChangedEventArgs(AgendaAppointment appointment) {
			this.Appointment = appointment;
		}

		#endregion

	}

}
