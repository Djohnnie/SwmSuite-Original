using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Business {

	public class TimeTableTemplateEntryBll {

		#region -_ Private Members _-

		private ITimeTableTemplateEntryDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateTimeTableTemplateEntryDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all timetable entries for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the time table entries for.</param>
		/// <param name="begin">The begindate of the period to get the timetable entries for.</param>
		/// <param name="end">The enddate of the period to get the timetable entries for.</param>
		/// <returns>A TimeTableTemplateEntryCollection containing the requested timetable entries.</returns>
		public TimeTableTemplateEntryCollection GetTimeTableTemplateEntries( TimeTableTemplate timeTableTemplate ) {
			TimeTableTemplateEntryDataCollection timeTableTemplateEntryData = new TimeTableTemplateEntryDataCollection();
			timeTableTemplateEntryData.Add( GetTimeTableTemplateEntryDataForTemplateOnDate( timeTableTemplate.SysId ) );
			return TimeTableTemplateEntryMapping.FromDataObjectCollection( timeTableTemplateEntryData );
		}

		/// <summary>
		/// Create a new timetable entry.
		/// </summary>
		/// <param name="timeTableTemplateEntry">The timetable entry to create.</param>
		/// <param name="timeTableTemplate">The time table template to add this entry to.</param>
		/// <returns>The created timetable entry.</returns>
		public TimeTableTemplateEntry CreateTimeTableTemplateEntry( TimeTableTemplateEntry timeTableTemplateEntry , TimeTableTemplate timeTableTemplate ) {
			TimeTableTemplateEntry timeTableTemplateEntryToReturn = null;
			TimeTableTemplateEntryData timeTableTemplateEntryData = TimeTableTemplateEntryMapping.FromBusinessObject( timeTableTemplateEntry );
			timeTableTemplateEntryData.TimeTableTemplateSysId = timeTableTemplate.SysId;
			TimeTableTemplateEntryDataCollection timeTableTemplateEntryDataResult =
				this.InsertTimeTableTemplateEntryData( TimeTableTemplateEntryDataCollection.FromSingleTimeTableTemplateEntry( timeTableTemplateEntryData ) );
			if( timeTableTemplateEntryDataResult.Count == 1 ) {
				timeTableTemplateEntryToReturn = TimeTableTemplateEntryMapping.FromDataObject( timeTableTemplateEntryDataResult[0] );
			}
			return timeTableTemplateEntryToReturn;
		}

		/// <summary>
		/// Update an existing timetable entry.
		/// </summary>
		/// <param name="timeTableTemplateEntry">The timetable entry to update.</param>
		/// <returns>The updated timetable entry.</returns>
		public TimeTableTemplateEntry UpdateTimeTableTemplateEntry( TimeTableTemplateEntry timeTableTemplateEntry ) {
			TimeTableTemplateEntry timeTableTemplateEntryToReturn = null;
			TimeTableTemplateEntryDataCollection timeTableTemplateEntryData = TimeTableTemplateEntryDataCollection.FromSingleTimeTableTemplateEntry(
				TimeTableTemplateEntryMapping.FromBusinessObject( timeTableTemplateEntry ) );
			TimeTableTemplateEntryDataCollection timeTableTemplateEntryDataResult =
				this.UpdateTimeTableTemplateEntryData( timeTableTemplateEntryData );
			if( timeTableTemplateEntryDataResult.Count == 1 ) {
				timeTableTemplateEntryToReturn = TimeTableTemplateEntryMapping.FromDataObject( timeTableTemplateEntryDataResult[0] );
			}
			return timeTableTemplateEntryToReturn;
		}

		/// <summary>
		/// Remove one or more timetable entries.
		/// </summary>
		/// <param name="timeTableEntries">A collection of timetable entries to remove.</param>
		public void RemoveTimeTableTemplateEntries( TimeTableTemplateEntryCollection timeTableEntries ) {
			try {
				RemoveTimeTableTemplateEntryData( TimeTableTemplateEntryMapping.FromBusinessObjectCollection( timeTableEntries ) );
			} catch( Exception e ) {
				String message = "";
				if( timeTableEntries.Count > 1 ) {
					message = "Uurrooster inschrijvingen kunnen niet worden verwijderd omdat minstens één inschrijving nog in gebruik is.";
				} else {
					message = "Uurrooster inschrijving kan niet worden verwijderd omdat ze nog in gebruik is.";
				}
				throw new SwmSuiteException( e , SwmSuiteError.BusinessError , message );
			}
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all timetabletemplateentries from the database.
		/// </summary>
		/// <returns>An TimeTableTemplateEntryCollection containing all timetabletemplateentries.</returns>
		public TimeTableTemplateEntryDataCollection GetTimeTableTemplateEntryData() {
			return dal.GetTimeTableTemplateEntryData();
		}

		/// <summary>
		/// Get all timetable entries from the database for a specific employee on a specific date.
		/// </summary>
		/// <param name="timeTableTemplateSysId">The internal id of the employee to get the timetable entries for.</param>
		/// <returns>A TimeTableTemplateEntryDataCollection containing all requested timetables entries.</returns>
		public TimeTableTemplateEntryDataCollection GetTimeTableTemplateEntryDataForTemplateOnDate(
			int timeTableTemplateSysId ) {
			return dal.GetTimeTableTemplateEntryDataForTemplateOnDate( timeTableTemplateSysId );
		}

		/// <summary>
		/// Get a single timetabletemplateentry from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetabletemplateentry to retrieve.</param>
		/// <returns>An TimeTableTemplateEntryCollection containing the requested timetabletemplateentry.</returns>
		public TimeTableTemplateEntryDataCollection GetTimeTableTemplateEntryDataBySysId( int sysId ) {
			return dal.GetTimeTableTemplateEntryDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple timetabletemplateentries from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetabletemplateentries to retrieve.</param>
		/// <returns>An TimeTableTemplateEntryCollection containing the requested timetabletemplateentries.</returns>
		public TimeTableTemplateEntryDataCollection GetTimeTableTemplateEntryDataBySysIds( int[] sysIds ) {
			return dal.GetTimeTableTemplateEntryDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more timetabletemplateentries to the database.
		/// </summary>
		/// <param name="timetabletemplateentries">An TimeTableTemplateEntryCollection containing the timetabletemplateentries to insert.</param>
		/// <returns>An TimeTableTemplateEntryCollection containing the inserted timetabletemplateentries.</returns>
		public TimeTableTemplateEntryDataCollection InsertTimeTableTemplateEntryData( TimeTableTemplateEntryDataCollection timetabletemplateentries ) {
			return dal.InsertTimeTableTemplateEntryData( timetabletemplateentries );
		}

		/// <summary>
		/// Update one or more timetabletemplateentries in the database.
		/// </summary>
		/// <param name="timetabletemplateentries">An TimeTableTemplateEntryCollection containing the timetabletemplateentries to update.</param>
		/// <returns>An TimeTableTemplateEntryCollection containing the updated timetabletemplateentries.</returns>
		public TimeTableTemplateEntryDataCollection UpdateTimeTableTemplateEntryData( TimeTableTemplateEntryDataCollection timetabletemplateentries ) {
			return dal.UpdateTimeTableTemplateEntryData( timetabletemplateentries );
		}

		/// <summary>
		/// Remove one or more timetabletemplateentries from the database.
		/// </summary>
		/// <param name="timetabletemplateentries">An TimeTableTemplateEntryCollection containing the timetabletemplateentries to remove.</param>
		public void RemoveTimeTableTemplateEntryData( TimeTableTemplateEntryDataCollection timetabletemplateentries ) {
			dal.RemoveTimeTableTemplateEntryData( timetabletemplateentries );
		}

		/// <summary>
		/// Remove all timetabletemplateentries from the database.
		/// </summary>
		public void RemoveAllTimeTableTemplateEntryData() {
			dal.RemoveAllTimeTableTemplateEntryData();
		}

		#endregion

	}

}
