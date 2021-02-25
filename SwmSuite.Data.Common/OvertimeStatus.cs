using System;
using System.Collections.Generic;
using System.Text;

namespace SwmSuite.Data.Common {
	
	/// <summary>
	/// enumerator defining the status for an overtime entry.
	/// </summary>
	public enum OvertimeStatus {

		/// <summary>
		/// Overtime entry is pending.
		/// </summary>
		Pending,

		/// <summary>
		/// Overtime entry is accepted.
		/// </summary>
		Accepted,

		/// <summary>
		/// Overtime entry is denied.
		/// </summary>
		Denied

	}

}
