using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Proxy.Interface {
	
	public interface ITimeTableFacade {

		/// <summary>
		/// Get all timetable purposes for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the timetable purposes for.</param>
		/// <returns>A TimeTablePurposeCollection containing the requested timetable purposes.</returns>
		TimeTablePurposeCollection GetTimeTablePurposesForEmployeeGroup( EmployeeGroup employeeGroup );

		/// <summary>
		/// Create a new timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTablePurpose">The timetable purpose to create.</param>
		/// <param name="employeeGroup">The employeegroup to create the new timetable purpose for.</param>
		/// <returns>The created timetable purpose.</returns>
		TimeTablePurpose CreateTimeTablePurpose( TimeTablePurpose timeTablePurpose , EmployeeGroup employeeGroup );

		/// <summary>
		/// Update an existing timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTablePurpose">The timetable purpose to update.</param>
		/// <param name="employeeGroup">The new employeegroup to associate with the updated timetable purpose.</param>
		/// <returns>The updated timetable purpose.</returns>
		TimeTablePurpose UpdateTimeTablePurpose( TimeTablePurpose timeTablePurpose , EmployeeGroup employeeGroup );

		/// <summary>
		/// Remove one or more timetable purposes.
		/// </summary>
		/// <param name="timeTablePurposes">The timetable purposes to remove.</param>
		void RemoveTimeTablePurposes( TimeTablePurposeCollection timeTablePurposes );

		/// <summary>
		/// Get all timetable entries for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the time table entries for.</param>
		/// <param name="begin">The begindate of the period to get the timetable entries for.</param>
		/// <param name="end">The enddate of the period to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryCollection containing the requested timetable entries.</returns>
		TimeTableEntryCollection GetTimeTableEntries( Employee employee , DateTime begin , DateTime end );

		/// <summary>
		/// Create a new timetable entry.
		/// </summary>
		/// <param name="timeTableEntry">The timetable entry to create.</param>
		/// <returns>The created timetable entry.</returns>
		TimeTableEntry CreateTimeTableEntry( TimeTableEntry timeTableEntry );

		/// <summary>
		/// Update an existing timetable entry.
		/// </summary>
		/// <param name="timeTableEntry">The timetable entry to update.</param>
		/// <returns>The updated timetable entry.</returns>
		TimeTableEntry UpdateTimeTableEntry( TimeTableEntry timeTableEntry );

		/// <summary>
		/// Remove one or more timetable entries.
		/// </summary>
		/// <param name="timeTableEntries">A collection of timetable entries to remove.</param>
		void RemoveTimeTableEntries( TimeTableEntryCollection timeTableEntries );

		/// <summary>
		/// Gets the time table template.
		/// </summary>
		/// <param name="timeTableTemplateSysId">The time table template sys id.</param>
		/// <returns></returns>
		TimeTableTemplate GetTimeTableTemplate( int timeTableTemplateSysId );

		/// <summary>
		/// Get all timetable purposes for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the timetable purposes for.</param>
		/// <returns>A TimeTableTemplateCollection containing the requested timetable purposes.</returns>
		TimeTableTemplateCollection GetTimeTableTemplatesForEmployeeGroup( EmployeeGroup employeeGroup );

		/// <summary>
		/// Create a new timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTableTemplate">The timetable purpose to create.</param>
		/// <param name="employeeGroup">The employeegroup to create the new timetable purpose for.</param>
		/// <returns>The created timetable purpose.</returns>
		TimeTableTemplate CreateTimeTableTemplate( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup );

		/// <summary>
		/// Update an existing timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTableTemplate">The timetable purpose to update.</param>
		/// <param name="employeeGroup">The new employeegroup to associate with the updated timetable purpose.</param>
		/// <returns>The updated timetable purpose.</returns>
		TimeTableTemplate UpdateTimeTableTemplate( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup );

		/// <summary>
		/// Remove one or more timetable purposes.
		/// </summary>
		/// <param name="timeTableTemplates">The timetable purposes to remove.</param>
		void RemoveTimeTableTemplates( TimeTableTemplateCollection timeTableTemplates );

		/// <summary>
		/// Get all timetable entries for a specific employee.
		/// </summary>
		/// <param name="timeTableTemplate">The employee to get the time table entries for.</param>
		/// <returns>A TimeTableTemplateEntryCollection containing the requested timetable entries.</returns>
		TimeTableTemplateEntryCollection GetTimeTableTemplateEntries( TimeTableTemplate timeTableTemplate );

		/// <summary>
		/// Create a new timetable entry.
		/// </summary>
		/// <param name="timeTableTemplateEntry">The timetable entry to create.</param>
		/// <param name="timeTableTemplate">The time table template to add this entry to.</param>
		/// <returns>The created timetable entry.</returns>
		TimeTableTemplateEntry CreateTimeTableTemplateEntry( TimeTableTemplateEntry timeTableTemplateEntry , TimeTableTemplate timeTableTemplate );

		/// <summary>
		/// Update an existing timetable entry.
		/// </summary>
		/// <param name="timeTableTemplateEntry">The timetable entry to update.</param>
		/// <returns>The updated timetable entry.</returns>
		TimeTableTemplateEntry UpdateTimeTableTemplateEntry( TimeTableTemplateEntry timeTableTemplateEntry );

		/// <summary>
		/// Remove one or more timetable entries.
		/// </summary>
		/// <param name="timeTableTemplateEntries">A collection of timetable entries to remove.</param>
		void RemoveTimeTableTemplateEntries( TimeTableTemplateEntryCollection timeTableTemplateEntries );

	}

}
