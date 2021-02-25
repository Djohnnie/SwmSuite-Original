using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.Data.Common {
	
	public enum AppointmentVisibility {

		/// <summary>
		/// Appointment (title and details) is visible for everyone.
		/// </summary>
		Public,

		/// <summary>
		/// Appointment (title only) is visible for everyone.
		/// </summary>
		Visible,

		/// <summary>
		/// Appointment is only visible for owner.
		/// </summary>
		Private,

		/// <summary>
		/// Appointment is not visible.
		/// </summary>
		Invisible

	}

}
