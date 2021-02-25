using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {

	public sealed class HolidayFacade : IHolidayFacade {

		/// <summary>
		/// Get overtime entries for one or more employees and year.
		/// </summary>
		/// <param name="employees">The employees to get the overtime entries for.</param>
		/// <param name="year">The year to get the overtime entries for.</param>
		/// <returns>An OvertimeEntryCollection containing the requested overtime entries.</returns>
		OvertimeEntryCollection IHolidayFacade.GetOvertimeEntries( EmployeeCollection employees , int year ) {
			return new OvertimeEntryBll().GetOvertimeEntries( employees , year );
		}

		/// <summary>
		/// Create a new overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The new overtime entry to create.</param>
		/// <returns>The created overtime entry.</returns>
		OvertimeEntry IHolidayFacade.CreateOvertimeEntry( OvertimeEntry overtimeEntry ) {
			return new OvertimeEntryBll().CreateOvertimeEntry( overtimeEntry );
		}

		/// <summary>
		/// Update an existing overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The existing overtime entry to update.</param>
		/// <returns>The updated overtime entry.</returns>
		OvertimeEntry IHolidayFacade.UpdateOvertimeEntry( OvertimeEntry overtimeEntry ) {
			return new OvertimeEntryBll().UpdateOvertimeEntry( overtimeEntry );
		}

		/// <summary>
		/// Accept the specified overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry to accept.</param>
		void IHolidayFacade.AcceptOvertimeEntry( OvertimeEntry overtimeEntry ) {
			new OvertimeEntryBll().AcceptOvertimeEntry( overtimeEntry );
		}

		/// <summary>
		/// Deny the specified overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry to deny.</param>
		void IHolidayFacade.DenyOvertimeEntry( OvertimeEntry overtimeEntry ) {
			new OvertimeEntryBll().DenyOvertimeEntry( overtimeEntry );
		}

	}

}
