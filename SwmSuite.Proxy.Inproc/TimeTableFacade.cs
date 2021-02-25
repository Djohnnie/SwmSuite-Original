using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {

	public sealed class TimeTableFacade : ITimeTableFacade {

		/// <summary>
		/// Get all timetable purposes for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the timetable purposes for.</param>
		/// <returns>A TimeTablePurposeCollection containing the requested timetable purposes.</returns>
		TimeTablePurposeCollection ITimeTableFacade.GetTimeTablePurposesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			return new TimeTablePurposeBll().GetTimeTablePurposesForEmployeeGroup( employeeGroup );
		}

		/// <summary>
		/// Create a new timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTablePurpose">The timetable purpose to create.</param>
		/// <param name="employeeGroup">The employeegroup to create the new timetable purpose for.</param>
		/// <returns>The created timetable purpose.</returns>
		TimeTablePurpose ITimeTableFacade.CreateTimeTablePurpose( TimeTablePurpose timeTablePurpose , EmployeeGroup employeeGroup ) {
			return new TimeTablePurposeBll().CreateTimeTablePurpose( timeTablePurpose , employeeGroup );
		}

		/// <summary>
		/// Update an existing timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTablePurpose">The timetable purpose to update.</param>
		/// <param name="employeeGroup">The new employeegroup to associate with the updated timetable purpose.</param>
		/// <returns>The updated timetable purpose.</returns>
		TimeTablePurpose ITimeTableFacade.UpdateTimeTablePurpose( TimeTablePurpose timeTablePurpose , EmployeeGroup employeeGroup ) {
			return new TimeTablePurposeBll().UpdateTimeTablePurpose( timeTablePurpose , employeeGroup );
		}

		/// <summary>
		/// Remove one or more timetable purposes.
		/// </summary>
		/// <param name="timeTablePurposes">The timetable purposes to remove.</param>
		void ITimeTableFacade.RemoveTimeTablePurposes( TimeTablePurposeCollection timeTablePurposes ) {
			new TimeTablePurposeBll().RemoveTimeTablePurposes( timeTablePurposes );
		}

		/// <summary>
		/// Get all timetable entries for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the time table entries for.</param>
		/// <param name="begin">The begindate of the period to get the timetable entries for.</param>
		/// <param name="end">The enddate of the period to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryCollection containing the requested timetable entries.</returns>
		TimeTableEntryCollection ITimeTableFacade.GetTimeTableEntries( Employee employee , DateTime begin , DateTime end ) {
			return new TimeTableEntryBll().GetTimeTableEntries( employee , begin , end );
		}

		/// <summary>
		/// Create a new timetable entry.
		/// </summary>
		/// <param name="timeTableEntry">The timetable entry to create.</param>
		/// <returns>The created timetable entry.</returns>
		TimeTableEntry ITimeTableFacade.CreateTimeTableEntry( TimeTableEntry timeTableEntry ) {
			return new TimeTableEntryBll().CreateTimeTableEntry( timeTableEntry );
		}

		/// <summary>
		/// Update an existing timetable entry.
		/// </summary>
		/// <param name="timeTableEntry">The timetable entry to update.</param>
		/// <returns>The updated timetable entry.</returns>
		TimeTableEntry ITimeTableFacade.UpdateTimeTableEntry( TimeTableEntry timeTableEntry ) {
			return new TimeTableEntryBll().UpdateTimeTableEntry( timeTableEntry );
		}

		/// <summary>
		/// Remove one or more timetable entries.
		/// </summary>
		/// <param name="timeTableEntries">A collection of timetable entries to remove.</param>
		void ITimeTableFacade.RemoveTimeTableEntries( TimeTableEntryCollection timeTableEntries ) {
			new TimeTableEntryBll().RemoveTimeTableEntries( timeTableEntries );
		}

		/// <summary>
		/// Gets the time table template.
		/// </summary>
		/// <param name="timeTableTemplateSysId">The time table template sys id.</param>
		/// <returns></returns>
		TimeTableTemplate ITimeTableFacade.GetTimeTableTemplate( int timeTableTemplateSysId ) {
			return new TimeTableTemplateBll().GetTimeTableTemplate( timeTableTemplateSysId );
		}

		/// <summary>
		/// Get all timetable purposes for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the timetable purposes for.</param>
		/// <returns>A TimeTableTemplateCollection containing the requested timetable purposes.</returns>
		TimeTableTemplateCollection ITimeTableFacade.GetTimeTableTemplatesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			return new TimeTableTemplateBll().GetTimeTableTemplatesForEmployeeGroup( employeeGroup );
		}

		/// <summary>
		/// Create a new timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTableTemplate">The timetable purpose to create.</param>
		/// <param name="employeeGroup">The employeegroup to create the new timetable purpose for.</param>
		/// <returns>The created timetable purpose.</returns>
		TimeTableTemplate ITimeTableFacade.CreateTimeTableTemplate( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup ) {
			return new TimeTableTemplateBll().CreateTimeTableTemplate( timeTableTemplate , employeeGroup );
		}

		/// <summary>
		/// Update an existing timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTableTemplate">The timetable purpose to update.</param>
		/// <param name="employeeGroup">The new employeegroup to associate with the updated timetable purpose.</param>
		/// <returns>The updated timetable purpose.</returns>
		TimeTableTemplate ITimeTableFacade.UpdateTimeTableTemplate( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup ) {
			return new TimeTableTemplateBll().UpdateTimeTableTemplate( timeTableTemplate , employeeGroup );
		}

		/// <summary>
		/// Remove one or more timetable purposes.
		/// </summary>
		/// <param name="timeTableTemplates">The timetable purposes to remove.</param>
		void ITimeTableFacade.RemoveTimeTableTemplates( TimeTableTemplateCollection timeTableTemplates ) {
			new TimeTableTemplateBll().RemoveTimeTableTemplates( timeTableTemplates );
		}

		/// <summary>
		/// Get all timetable entries for a specific employee.
		/// </summary>
		/// <param name="timeTableTemplate">The employee to get the time table entries for.</param>
		/// <returns>A TimeTableTemplateEntryCollection containing the requested timetable entries.</returns>
		TimeTableTemplateEntryCollection ITimeTableFacade.GetTimeTableTemplateEntries( TimeTableTemplate timeTableTemplate  ) {
			return new TimeTableTemplateEntryBll().GetTimeTableTemplateEntries( timeTableTemplate );
		}

		/// <summary>
		/// Create a new timetable entry.
		/// </summary>
		/// <param name="timeTableTemplateEntry">The timetable entry to create.</param>
		/// <param name="timeTableTemplate">The time table template to add this entry to.</param>
		/// <returns>The created timetable entry.</returns>
		TimeTableTemplateEntry ITimeTableFacade.CreateTimeTableTemplateEntry( TimeTableTemplateEntry timeTableTemplateEntry , TimeTableTemplate timeTableTemplate ) {
			return new TimeTableTemplateEntryBll().CreateTimeTableTemplateEntry( timeTableTemplateEntry , timeTableTemplate );
		}

		/// <summary>
		/// Update an existing timetable entry.
		/// </summary>
		/// <param name="timeTableTemplateEntry">The timetable entry to update.</param>
		/// <returns>The updated timetable entry.</returns>
		TimeTableTemplateEntry ITimeTableFacade.UpdateTimeTableTemplateEntry( TimeTableTemplateEntry timeTableTemplateEntry ) {
			return new TimeTableTemplateEntryBll().UpdateTimeTableTemplateEntry( timeTableTemplateEntry );
		}

		/// <summary>
		/// Remove one or more timetable entries.
		/// </summary>
		/// <param name="timeTableTemplateEntries">A collection of timetable entries to remove.</param>
		void ITimeTableFacade.RemoveTimeTableTemplateEntries( TimeTableTemplateEntryCollection timeTableTemplateEntries ) {
			new TimeTableTemplateEntryBll().RemoveTimeTableTemplateEntries( timeTableTemplateEntries );
		}

	}
}
