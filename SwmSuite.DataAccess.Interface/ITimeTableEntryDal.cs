using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the TimeTableEntryDataService methods.
	/// </summary>
	public interface ITimeTableEntryDal {

		/// <summary>
		/// Get all timetableentrydatacollection from the database.
		/// </summary>
		/// <returns>A TimeTableEntryDataCollection containing all timetableentrydatacollection.</returns>
		TimeTableEntryDataCollection GetTimeTableEntryDataCollection();

		/// <summary>
		/// Get all timetable entries from the database for a specific employee on a specific date.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the timetable entries for.</param>
		/// <param name="onDate">The date to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryDataCollection containing all requested timetables entries.</returns>
		TimeTableEntryDataCollection GetTimeTableEntryDataCollectionForEmployeeOnDate(
			int employeeSysId , DateTime onDate );

		/// <summary>
		/// Get all timetable entries from the database for a specific employee in a specific date period.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the timetable entries for.</param>
		/// <param name="periodStart">The startdate of the period to get the timetable entries for.</param>
		/// <param name="periodEnd">The enddate of the period to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryDataCollection containing all requested timetables entries.</returns>
		TimeTableEntryDataCollection GetTimeTableEntryDataCollectionForEmployeeInPeriod(
			int employeeSysId , DateTime periodStart , DateTime periodEnd );

		/// <summary>
		/// Get a single timetableentrydata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetableentrydata to retrieve.</param>
		/// <returns>An TimeTableEntryDataCollection containing the requested timetableentrydata.</returns>
		TimeTableEntryDataCollection GetTimeTableEntryDataBySysId( int sysId );

		/// <summary>
		/// Get multiple timetableentrydatacollection from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetableentrydatacollection to retrieve.</param>
		/// <returns>An TimeTableEntryDataCollection containing the requested timetableentrydatacollection.</returns>
		TimeTableEntryDataCollection GetTimeTableEntryDataCollectionBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more timetableentrydatacollection to the database.
		/// </summary>
		/// <param name="timetableentrydatacollection">An TimeTableEntryDataCollection containing the timetableentrydatacollection to insert.</param>
		/// <returns>An TimeTableEntryDataCollection containing the inserted timetableentrydatacollection.</returns>
		TimeTableEntryDataCollection InsertTimeTableEntryDataCollection( TimeTableEntryDataCollection timetableentrydatacollection );

		/// <summary>
		/// Update one or more timetableentrydatacollection in the database.
		/// </summary>
		/// <param name="timetableentrydatacollection">An TimeTableEntryDataCollection containing the timetableentrydatacollection to update.</param>
		/// <returns>An TimeTableEntryDataCollection containing the updated timetableentrydatacollection.</returns>
		TimeTableEntryDataCollection UpdateTimeTableEntryDataCollection( TimeTableEntryDataCollection timetableentrydatacollection );

		/// <summary>
		/// Remove one or more timetableentrydatacollection from the database.
		/// </summary>
		/// <param name="timetableentrydatacollection">An TimeTableEntryDataCollection containing the timetableentrydatacollection to remove.</param>
		void RemoveTimeTableEntryDataCollection( TimeTableEntryDataCollection timetableentrydatacollection );

		/// <summary>
		/// Remove all timetableentrydatacollection from the database.
		/// </summary>
		void RemoveAllTimeTableEntryDataCollection();

	}

}
