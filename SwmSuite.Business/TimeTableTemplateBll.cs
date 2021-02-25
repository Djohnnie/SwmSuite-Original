using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;
using SwmSuite.Framework.Exceptions;
using System.Transactions;

namespace SwmSuite.Business {

	public class TimeTableTemplateBll {

		#region -_ Private Members _-

		private ITimeTableTemplateDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateTimeTableTemplateDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Gets the time table template.
		/// </summary>
		/// <param name="timeTableTemplateSysId">The time table template sys id.</param>
		/// <returns></returns>
		public TimeTableTemplate GetTimeTableTemplate( int timeTableTemplateSysId ) {
			TimeTableTemplate timeTableTemplateToReturn = null;
			TimeTableTemplateDataCollection timeTableTemplateData =
				GetTimeTableTemplateDataBySysId( timeTableTemplateSysId );
			if( timeTableTemplateData.Count == 1 ) {
				timeTableTemplateToReturn = TimeTableTemplateMapping.FromDataObject(
					timeTableTemplateData[0] );
			}
			return timeTableTemplateToReturn;
		}

		/// <summary>
		/// Get all timetable purposes for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the timetable purposes for.</param>
		/// <returns>A TimeTableTemplateCollection containing the requested timetable purposes.</returns>
		public TimeTableTemplateCollection GetTimeTableTemplatesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			TimeTableTemplateDataCollection timeTableTemplateData =
				this.GetTimeTableTemplateDataForEmployeeGroup( employeeGroup.SysId );
			return TimeTableTemplateMapping.FromDataObjectCollection( timeTableTemplateData );
		}

		/// <summary>
		/// Create a new timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTableTemplate">The timetable purpose to create.</param>
		/// <param name="employeeGroup">The employeegroup to create the new timetable purpose for.</param>
		/// <returns>The created timetable purpose.</returns>
		public TimeTableTemplate CreateTimeTableTemplate( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup ) {
			TimeTableTemplateData timeTableTemplateToInsert = TimeTableTemplateMapping.FromBusinessObject( timeTableTemplate );
			timeTableTemplateToInsert.EmployeeGroupSysId = employeeGroup.SysId;
			TimeTableTemplateDataCollection timeTableTemplateDataInserted =
				this.InsertTimeTableTemplateData( TimeTableTemplateDataCollection.FromSingleTimeTableTemplate( timeTableTemplateToInsert ) );
			return TimeTableTemplateMapping.FromDataObject( timeTableTemplateDataInserted[0] );
		}

		/// <summary>
		/// Update an existing timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTableTemplate">The timetable purpose to update.</param>
		/// <param name="employeeGroup">The new employeegroup to associate with the updated timetable purpose.</param>
		/// <returns>The updated timetable purpose.</returns>
		public TimeTableTemplate UpdateTimeTableTemplate( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup ) {
			TimeTableTemplateData timeTableTemplateToUpdate = TimeTableTemplateMapping.FromBusinessObject( timeTableTemplate );
			timeTableTemplateToUpdate.EmployeeGroupSysId = employeeGroup.SysId;
			TimeTableTemplateDataCollection timeTableTemplateDataUpdated =
				this.UpdateTimeTableTemplateData( TimeTableTemplateDataCollection.FromSingleTimeTableTemplate( timeTableTemplateToUpdate ) );
			return TimeTableTemplateMapping.FromDataObject( timeTableTemplateDataUpdated[0] );
		}

		/// <summary>
		/// Remove one or more timetable purposes.
		/// </summary>
		/// <param name="timeTableTemplates">The timetable purposes to remove.</param>
		public void RemoveTimeTableTemplates( TimeTableTemplateCollection timeTableTemplates ) {
			try {
				using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
					TimeTableTemplateEntryBll timeTableTemplateEntryBll = new TimeTableTemplateEntryBll();
					// First remove all entries...
					foreach( TimeTableTemplate timeTableTemplate in timeTableTemplates ) {
						timeTableTemplateEntryBll.RemoveTimeTableTemplateEntries(
							timeTableTemplateEntryBll.GetTimeTableTemplateEntries( timeTableTemplate ) );
					}
					// Remove template itself.
					this.RemoveTimeTableTemplateData( TimeTableTemplateMapping.FromBusinessObjectCollection( timeTableTemplates ) );
					scope.Complete();
				}
			} catch( Exception e ) {
				String message = "";
				if( timeTableTemplates.Count > 1 ) {
					message = "Uurrooster sjablonen kunnen niet worden verwijderd omdat minstens één sjabloon nog in gebruik is.";
				} else {
					message = "Uurrooster sjabloon kan niet worden verwijderd omdat het nog in gebruik is.";
				}
				throw new SwmSuiteException( e , SwmSuiteError.BusinessError , message );
			}
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all timetabletemplates from the database.
		/// </summary>
		/// <returns>An TimeTableTemplateCollection containing all timetabletemplates.</returns>
		public TimeTableTemplateDataCollection GetTimeTableTemplateData() {
			return dal.GetTimeTableTemplateData();
		}

		/// <summary>
		/// Get all timetabletemplatedatacollection from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the timetable templates for.</param>
		/// <returns>An TimeTableTemplateDataCollection containing all requested timetabletemplatedatacollection.</returns>
		public TimeTableTemplateDataCollection GetTimeTableTemplateDataForEmployeeGroup( int employeeGroupSysId ) {
			return dal.GetTimeTableTemplateDataForEmployeeGroup( employeeGroupSysId );
		}

		/// <summary>
		/// Get a single timetabletemplate from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetabletemplate to retrieve.</param>
		/// <returns>An TimeTableTemplateCollection containing the requested timetabletemplate.</returns>
		public TimeTableTemplateDataCollection GetTimeTableTemplateDataBySysId( int sysId ) {
			return dal.GetTimeTableTemplateDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple timetabletemplates from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetabletemplates to retrieve.</param>
		/// <returns>An TimeTableTemplateCollection containing the requested timetabletemplates.</returns>
		public TimeTableTemplateDataCollection GetTimeTableTemplateDataBySysIds( int[] sysIds ) {
			return dal.GetTimeTableTemplateDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more timetabletemplates to the database.
		/// </summary>
		/// <param name="timetabletemplates">An TimeTableTemplateCollection containing the timetabletemplates to insert.</param>
		/// <returns>An TimeTableTemplateCollection containing the inserted timetabletemplates.</returns>
		public TimeTableTemplateDataCollection InsertTimeTableTemplateData( TimeTableTemplateDataCollection timetabletemplates ) {
			return dal.InsertTimeTableTemplateData( timetabletemplates );
		}

		/// <summary>
		/// Update one or more timetabletemplates in the database.
		/// </summary>
		/// <param name="timetabletemplates">An TimeTableTemplateCollection containing the timetabletemplates to update.</param>
		/// <returns>An TimeTableTemplateCollection containing the updated timetabletemplates.</returns>
		public TimeTableTemplateDataCollection UpdateTimeTableTemplateData( TimeTableTemplateDataCollection timetabletemplates ) {
			return dal.UpdateTimeTableTemplateData( timetabletemplates );
		}

		/// <summary>
		/// Remove one or more timetabletemplates from the database.
		/// </summary>
		/// <param name="timetabletemplates">An TimeTableTemplateCollection containing the timetabletemplates to remove.</param>
		public void RemoveTimeTableTemplateData( TimeTableTemplateDataCollection timetabletemplates ) {
			dal.RemoveTimeTableTemplateData( timetabletemplates );
		}

		/// <summary>
		/// Remove all timetabletemplates from the database.
		/// </summary>
		public void RemoveAllTimeTableTemplateData() {
			dal.RemoveAllTimeTableTemplateData();
		}

		#endregion

	}

}
