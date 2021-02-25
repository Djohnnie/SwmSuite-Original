using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Proxy.Interface {
	
	public interface IHolidayFacade {

		/// <summary>
		/// Get overtime entries for one or more employees and year.
		/// </summary>
		/// <param name="employees">The employees to get the overtime entries for.</param>
		/// <param name="year">The year to get the overtime entries for.</param>
		/// <returns>An OvertimeEntryCollection containing the requested overtime entries.</returns>
		OvertimeEntryCollection GetOvertimeEntries( EmployeeCollection employees , int year );

		/// <summary>
		/// Create a new overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The new overtime entry to create.</param>
		/// <returns>The created overtime entry.</returns>
		OvertimeEntry CreateOvertimeEntry( OvertimeEntry overtimeEntry );

		/// <summary>
		/// Update an existing overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The existing overtime entry to update.</param>
		/// <returns>The updated overtime entry.</returns>
		OvertimeEntry UpdateOvertimeEntry( OvertimeEntry overtimeEntry );

		/// <summary>
		/// Accept the specified overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry to accept.</param>
		void AcceptOvertimeEntry( OvertimeEntry overtimeEntry );

		/// <summary>
		/// Deny the specified overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry to deny.</param>
		void DenyOvertimeEntry( OvertimeEntry overtimeEntry );

	}
}
