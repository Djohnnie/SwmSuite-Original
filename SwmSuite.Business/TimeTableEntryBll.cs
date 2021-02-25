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

	public class TimeTableEntryBll {

		#region -_ Private Members _-

		private ITimeTableEntryDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateTimeTableEntryDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all timetable entries for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the time table entries for.</param>
		/// <param name="begin">The begindate of the period to get the timetable entries for.</param>
		/// <param name="end">The enddate of the period to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryCollection containing the requested timetable entries.</returns>
		public TimeTableEntryCollection GetTimeTableEntries( Employee employee , DateTime begin , DateTime end ) {
			TimeTableEntryDataCollection timeTableEntryData = new TimeTableEntryDataCollection();
			while( begin <= end ) {
				timeTableEntryData.Add( GetTimeTableEntryDataCollectionForEmployeeOnDate( employee.SysId , begin ) );
				begin = begin.AddDays( 1 );
			}
			return TimeTableEntryMapping.FromDataObjectCollection( timeTableEntryData );
		}

		/// <summary>
		/// Create a new timetable entry.
		/// </summary>
		/// <param name="timeTableEntry">The timetable entry to create.</param>
		/// <returns>The created timetable entry.</returns>
		public TimeTableEntry CreateTimeTableEntry( TimeTableEntry timeTableEntry ) {
			TimeTableEntry timeTableEntryToReturn = null;
			TimeTableEntryDataCollection timeTableEntryData = TimeTableEntryDataCollection.FromSingleTimeTableEntry(
				TimeTableEntryMapping.FromBusinessObject( timeTableEntry ) );
			TimeTableEntryDataCollection timeTableEntryDataResult =
				this.InsertTimeTableEntryDataCollection( timeTableEntryData );
			if( timeTableEntryDataResult.Count == 1 ) {
				timeTableEntryToReturn = TimeTableEntryMapping.FromDataObject( timeTableEntryDataResult[0] );
			}
			return timeTableEntryToReturn;
		}

		/// <summary>
		/// Update an existing timetable entry.
		/// </summary>
		/// <param name="timeTableEntry">The timetable entry to update.</param>
		/// <returns>The updated timetable entry.</returns>
		public TimeTableEntry UpdateTimeTableEntry( TimeTableEntry timeTableEntry ) {
			TimeTableEntry timeTableEntryToReturn = null;
			TimeTableEntryDataCollection timeTableEntryData = TimeTableEntryDataCollection.FromSingleTimeTableEntry(
				TimeTableEntryMapping.FromBusinessObject( timeTableEntry ) );
			TimeTableEntryDataCollection timeTableEntryDataResult =
				this.UpdateTimeTableEntryDataCollection( timeTableEntryData );
			if( timeTableEntryDataResult.Count == 1 ) {
				timeTableEntryToReturn = TimeTableEntryMapping.FromDataObject( timeTableEntryDataResult[0] );
			}
			return timeTableEntryToReturn;
		}

		/// <summary>
		/// Remove one or more timetable entries.
		/// </summary>
		/// <param name="timeTableEntries">A collection of timetable entries to remove.</param>
		public void RemoveTimeTableEntries( TimeTableEntryCollection timeTableEntries ) {
			try {
				RemoveTimeTableEntryDataCollection( TimeTableEntryMapping.FromBusinessObjectCollection( timeTableEntries ) );
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
		/// Get all timetableentrydatacollection from the database.
		/// </summary>
		/// <returns>An TimeTableEntryDataCollection containing all timetableentrydatacollection.</returns>
		public TimeTableEntryDataCollection GetTimeTableEntryDataCollection() {
			return dal.GetTimeTableEntryDataCollection();
		}

		/// <summary>
		/// Get all timetable entries from the database for a specific employee on a specific date.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the timetable entries for.</param>
		/// <param name="onDate">The date to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryDataCollection containing all requested timetables entries.</returns>
		public TimeTableEntryDataCollection GetTimeTableEntryDataCollectionForEmployeeOnDate(
			int employeeSysId , DateTime onDate ) {
			return dal.GetTimeTableEntryDataCollectionForEmployeeOnDate( employeeSysId , onDate );
		}

		/// <summary>
		/// Get all timetable entries from the database for a specific employee in a specific date period.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the timetable entries for.</param>
		/// <param name="periodStart">The startdate of the period to get the timetable entries for.</param>
		/// <param name="periodEnd">The enddate of the period to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryDataCollection containing all requested timetables entries.</returns>
		public TimeTableEntryDataCollection GetTimeTableEntryDataCollectionForEmployeeInPeriod(
			int employeeSysId , DateTime periodStart, DateTime periodEnd ) {
			DateTime start = new DateTime( periodStart.Year , periodStart.Month , periodStart.Day );
			DateTime end = new DateTime( periodEnd.Year , periodEnd.Month , periodEnd.Day );
			return dal.GetTimeTableEntryDataCollectionForEmployeeInPeriod( employeeSysId , start , end );
		}

		/// <summary>
		/// Get a single timetableentrydata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetableentrydata to retrieve.</param>
		/// <returns>An TimeTableEntryDataCollection containing the requested timetableentrydata.</returns>
		public TimeTableEntryDataCollection GetTimeTableEntryDataBySysId( int sysId ) {
			return dal.GetTimeTableEntryDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple timetableentrydatacollection from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetableentrydatacollection to retrieve.</param>
		/// <returns>An TimeTableEntryDataCollection containing the requested timetableentrydatacollection.</returns>
		public TimeTableEntryDataCollection GetTimeTableEntryDataCollectionBySysIds( int[] sysIds ) {
			return dal.GetTimeTableEntryDataCollectionBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more timetableentrydatacollection to the database.
		/// </summary>
		/// <param name="timetableentrydatacollection">An TimeTableEntryDataCollection containing the timetableentrydatacollection to insert.</param>
		/// <returns>An TimeTableEntryDataCollection containing the inserted timetableentrydatacollection.</returns>
		public TimeTableEntryDataCollection InsertTimeTableEntryDataCollection( TimeTableEntryDataCollection timetableentrydatacollection ) {
			return dal.InsertTimeTableEntryDataCollection( timetableentrydatacollection );
		}

		/// <summary>
		/// Update one or more timetableentrydatacollection in the database.
		/// </summary>
		/// <param name="timetableentrydatacollection">An TimeTableEntryDataCollection containing the timetableentrydatacollection to update.</param>
		/// <returns>An TimeTableEntryDataCollection containing the updated timetableentrydatacollection.</returns>
		public TimeTableEntryDataCollection UpdateTimeTableEntryDataCollection( TimeTableEntryDataCollection timetableentrydatacollection ) {
			return dal.UpdateTimeTableEntryDataCollection( timetableentrydatacollection );
		}

		/// <summary>
		/// Remove one or more timetableentrydatacollection from the database.
		/// </summary>
		/// <param name="timetableentrydatacollection">An TimeTableEntryDataCollection containing the timetableentrydatacollection to remove.</param>
		public void RemoveTimeTableEntryDataCollection( TimeTableEntryDataCollection timetableentrydatacollection ) {
			dal.RemoveTimeTableEntryDataCollection( timetableentrydatacollection );
		}

		/// <summary>
		/// Remove all timetableentrydatacollection from the database.
		/// </summary>
		public void RemoveAllTimeTableEntryDataCollection() {
			dal.RemoveAllTimeTableEntryDataCollection();
		}

		#endregion

	}

}
