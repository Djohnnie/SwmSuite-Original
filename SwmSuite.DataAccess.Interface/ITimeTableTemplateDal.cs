using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the TimeTableTemplateService methods.
	/// </summary>
	public interface ITimeTableTemplateDal {

		/// <summary>
		/// Get all timetabletemplates from the database.
		/// </summary>
		/// <returns>A TimeTableTemplateCollection containing all timetabletemplates.</returns>
		TimeTableTemplateDataCollection GetTimeTableTemplateData();

		/// <summary>
		/// Get all timetabletemplatedatacollection from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the timetable templates for.</param>
		/// <returns>An TimeTableTemplateDataCollection containing all requested timetabletemplatedatacollection.</returns>
		TimeTableTemplateDataCollection GetTimeTableTemplateDataForEmployeeGroup( int employeeGroupSysId );

		/// <summary>
		/// Get a single timetabletemplate from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetabletemplate to retrieve.</param>
		/// <returns>An TimeTableTemplateCollection containing the requested timetabletemplate.</returns>
		TimeTableTemplateDataCollection GetTimeTableTemplateDataBySysId( int sysId );

		/// <summary>
		/// Get multiple timetabletemplates from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetabletemplates to retrieve.</param>
		/// <returns>An TimeTableTemplateCollection containing the requested timetabletemplates.</returns>
		TimeTableTemplateDataCollection GetTimeTableTemplateDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more timetabletemplates to the database.
		/// </summary>
		/// <param name="timetabletemplates">An TimeTableTemplateCollection containing the timetabletemplates to insert.</param>
		/// <returns>An TimeTableTemplateCollection containing the inserted timetabletemplates.</returns>
		TimeTableTemplateDataCollection InsertTimeTableTemplateData( TimeTableTemplateDataCollection timetabletemplates );

		/// <summary>
		/// Update one or more timetabletemplates in the database.
		/// </summary>
		/// <param name="timetabletemplates">An TimeTableTemplateCollection containing the timetabletemplates to update.</param>
		/// <returns>An TimeTableTemplateCollection containing the updated timetabletemplates.</returns>
		TimeTableTemplateDataCollection UpdateTimeTableTemplateData( TimeTableTemplateDataCollection timetabletemplates );

		/// <summary>
		/// Remove one or more timetabletemplates from the database.
		/// </summary>
		/// <param name="timetabletemplates">An TimeTableTemplateCollection containing the timetabletemplates to remove.</param>
		void RemoveTimeTableTemplateData( TimeTableTemplateDataCollection timetabletemplates );

		/// <summary>
		/// Remove all timetabletemplates from the database.
		/// </summary>
		void RemoveAllTimeTableTemplateData();

	}

}
