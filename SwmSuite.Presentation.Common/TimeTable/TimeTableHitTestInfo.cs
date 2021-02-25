using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwmSuite.Presentation.Common.TimeTable {
	
	/// <summary>
	/// Enumerating defining the possible hit regions on the timetable control.
	/// </summary>
	public enum TimeTableHitTestInfo {

		/// <summary>
		/// Nothing.
		/// </summary>
		Nothing,

		/// <summary>
		/// Header.
		/// </summary>
		Header,

		/// <summary>
		/// Day (not containing entry).
		/// </summary>
		Day,

		/// <summary>
		/// Entry.
		/// </summary>
		Entry,

		/// <summary>
		/// Footer.
		/// </summary>
		Footer,

		/// <summary>
		/// Day column.
		/// </summary>
		DayColumn

	}

}
