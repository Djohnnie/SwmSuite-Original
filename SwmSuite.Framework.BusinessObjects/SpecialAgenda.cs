using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwmSuite.Data.BusinessObjects {
	
	/// <summary>
	/// Enumerator defining a special flag for an agenda.
	/// </summary>
	public enum SpecialAgenda {

		/// <summary>
		/// Not a special agenda.
		/// </summary>
		NothingSpecial,

		/// <summary>
		/// An agenda containing guest appointments.
		/// </summary>
		GuestAgenda,

		/// <summary>
		/// An agenda containing timetable entries.
		/// </summary>
		TimeTableAgenda

	}

}
