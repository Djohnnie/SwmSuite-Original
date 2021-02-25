using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	public interface IOvertimeEntryDal {

		/// <summary>
		/// Get all overtimeentrydata from the database.
		/// </summary>
		/// <returns>A OvertimeEntryDataCollection containing all overtimeentrydata.</returns>
		OvertimeEntryDataCollection GetOvertimeEntryData();

		/// <summary>
		/// Get all overtimeentrydata from the database for a specific employee and year.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the overtime entries for.</param>
		/// <param name="year">The year to get the overtime entries for.</param>
		/// <returns>An OvertimeEntryDataCollection containing all overtimeentrydata.</returns>
		OvertimeEntryDataCollection GetOvertimeEntryDataByEmployeeAndYear( int employeeSysId , int year );

		/// <summary>
		/// Get a single overtimeentrydata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the overtimeentrydata to retrieve.</param>
		/// <returns>An OvertimeEntryDataCollection containing the requested overtimeentrydata.</returns>
		OvertimeEntryDataCollection GetOvertimeEntryDataBySysId( int sysId );

		/// <summary>
		/// Get multiple overtimeentrydata from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the overtimeentrydata to retrieve.</param>
		/// <returns>An OvertimeEntryDataCollection containing the requested overtimeentrydata.</returns>
		OvertimeEntryDataCollection GetOvertimeEntryDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more overtimeentrydata to the database.
		/// </summary>
		/// <param name="overtimeentrydata">An OvertimeEntryDataCollection containing the overtimeentrydata to insert.</param>
		/// <returns>An OvertimeEntryDataCollection containing the inserted overtimeentrydata.</returns>
		OvertimeEntryDataCollection InsertOvertimeEntryData( OvertimeEntryDataCollection overtimeentrydata );

		/// <summary>
		/// Update one or more overtimeentrydata in the database.
		/// </summary>
		/// <param name="overtimeentrydata">An OvertimeEntryDataCollection containing the overtimeentrydata to update.</param>
		/// <returns>An OvertimeEntryDataCollection containing the updated overtimeentrydata.</returns>
		OvertimeEntryDataCollection UpdateOvertimeEntryData( OvertimeEntryDataCollection overtimeentrydata );

		/// <summary>
		/// Remove one or more overtimeentrydata from the database.
		/// </summary>
		/// <param name="overtimeentrydata">An OvertimeEntryDataCollection containing the overtimeentrydata to remove.</param>
		void RemoveOvertimeEntryData( OvertimeEntryDataCollection overtimeentrydata );

		/// <summary>
		/// Remove all overtimeentrydata from the database.
		/// </summary>
		void RemoveAllOvertimeEntryData();

	}

}
