using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the TimeTablePurposeDataService methods.
	/// </summary>
	public interface ITimeTablePurposeDal {

		/// <summary>
		/// Get all timetablepurposedatacollection from the database.
		/// </summary>
		/// <returns>A TimeTablePurposeDataCollection containing all timetablepurposedatacollection.</returns>
		TimeTablePurposeDataCollection GetTimeTablePurposeDataCollection();

		/// <summary>
		/// Get all timetablepurposedatacollection from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the timetable purposes for.</param>
		/// <returns>An TimeTablePurposeDataCollection containing all requested timetablepurposedatacollection.</returns>
		TimeTablePurposeDataCollection GetTimeTablePurposeDataCollectionForEmployeeGroup( int employeeGroupSysId );

		/// <summary>
		/// Get a single timetablepurposedata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetablepurposedata to retrieve.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the requested timetablepurposedata.</returns>
		TimeTablePurposeDataCollection GetTimeTablePurposeDataBySysId( int sysId );

		/// <summary>
		/// Get multiple timetablepurposedatacollection from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetablepurposedatacollection to retrieve.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the requested timetablepurposedatacollection.</returns>
		TimeTablePurposeDataCollection GetTimeTablePurposeDataCollectionBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more timetablepurposedatacollection to the database.
		/// </summary>
		/// <param name="timetablepurposedatacollection">An TimeTablePurposeDataCollection containing the timetablepurposedatacollection to insert.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the inserted timetablepurposedatacollection.</returns>
		TimeTablePurposeDataCollection InsertTimeTablePurposeDataCollection( TimeTablePurposeDataCollection timetablepurposedatacollection );

		/// <summary>
		/// Update one or more timetablepurposedatacollection in the database.
		/// </summary>
		/// <param name="timetablepurposedatacollection">An TimeTablePurposeDataCollection containing the timetablepurposedatacollection to update.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the updated timetablepurposedatacollection.</returns>
		TimeTablePurposeDataCollection UpdateTimeTablePurposeDataCollection( TimeTablePurposeDataCollection timetablepurposedatacollection );

		/// <summary>
		/// Remove one or more timetablepurposedatacollection from the database.
		/// </summary>
		/// <param name="timetablepurposedatacollection">An TimeTablePurposeDataCollection containing the timetablepurposedatacollection to remove.</param>
		void RemoveTimeTablePurposeDataCollection( TimeTablePurposeDataCollection timetablepurposedatacollection );

		/// <summary>
		/// Remove all timetablepurposedatacollection from the database.
		/// </summary>
		void RemoveAllTimeTablePurposeDataCollection();

	}

}
