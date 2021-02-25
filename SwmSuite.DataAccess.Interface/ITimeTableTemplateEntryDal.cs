using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	public interface ITimeTableTemplateEntryDal {

		/// <summary>
		/// Get all timetabletemplateentries from the database.
		/// </summary>
		/// <returns>A TimeTableTemplateEntryCollection containing all timetabletemplateentries.</returns>
		TimeTableTemplateEntryDataCollection GetTimeTableTemplateEntryData();

		/// <summary>
		/// Get all timetable entries from the database for a specific employee on a specific date.
		/// </summary>
		/// <param name="timeTableTemplateSysId">The internal id of the employee to get the timetable entries for.</param>
		/// <returns>A TimeTableTemplateEntryDataCollection containing all requested timetables entries.</returns>
		TimeTableTemplateEntryDataCollection GetTimeTableTemplateEntryDataForTemplateOnDate( int timeTableTemplateSysId );

		/// <summary>
		/// Get a single timetabletemplateentry from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetabletemplateentry to retrieve.</param>
		/// <returns>An TimeTableTemplateEntryCollection containing the requested timetabletemplateentry.</returns>
		TimeTableTemplateEntryDataCollection GetTimeTableTemplateEntryDataBySysId( int sysId );

		/// <summary>
		/// Get multiple timetabletemplateentries from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetabletemplateentries to retrieve.</param>
		/// <returns>An TimeTableTemplateEntryCollection containing the requested timetabletemplateentries.</returns>
		TimeTableTemplateEntryDataCollection GetTimeTableTemplateEntryDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more timetabletemplateentries to the database.
		/// </summary>
		/// <param name="timetabletemplateentries">An TimeTableTemplateEntryCollection containing the timetabletemplateentries to insert.</param>
		/// <returns>An TimeTableTemplateEntryCollection containing the inserted timetabletemplateentries.</returns>
		TimeTableTemplateEntryDataCollection InsertTimeTableTemplateEntryData( TimeTableTemplateEntryDataCollection timetabletemplateentries );

		/// <summary>
		/// Update one or more timetabletemplateentries in the database.
		/// </summary>
		/// <param name="timetabletemplateentries">An TimeTableTemplateEntryCollection containing the timetabletemplateentries to update.</param>
		/// <returns>An TimeTableTemplateEntryCollection containing the updated timetabletemplateentries.</returns>
		TimeTableTemplateEntryDataCollection UpdateTimeTableTemplateEntryData( TimeTableTemplateEntryDataCollection timetabletemplateentries );

		/// <summary>
		/// Remove one or more timetabletemplateentries from the database.
		/// </summary>
		/// <param name="timetabletemplateentries">An TimeTableTemplateEntryCollection containing the timetabletemplateentries to remove.</param>
		void RemoveTimeTableTemplateEntryData( TimeTableTemplateEntryDataCollection timetabletemplateentries );

		/// <summary>
		/// Remove all timetabletemplateentries from the database.
		/// </summary>
		void RemoveAllTimeTableTemplateEntryData();

	}
}
