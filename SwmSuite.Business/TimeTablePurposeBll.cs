using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Business {

	public class TimeTablePurposeBll {

		#region -_ Private Members _-

		private ITimeTablePurposeDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateTimeTablePurposeDal();

		#endregion

		#region -_ Business Methods _-

		public TimeTablePurpose GetTimeTablePurpose( int timeTablePurposeSysId ) {
			TimeTablePurpose timeTablePurposeToReturn = null;
			TimeTablePurposeDataCollection timeTablePurposeData =
				GetTimeTablePurposeDataBySysId( timeTablePurposeSysId );
			if( timeTablePurposeData.Count == 1 ) {
				timeTablePurposeToReturn = TimeTablePurposeMapping.FromDataObject(
					timeTablePurposeData[0] );
			}
			return timeTablePurposeToReturn;
		}

		/// <summary>
		/// Get all timetable purposes for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the timetable purposes for.</param>
		/// <returns>A TimeTablePurposeCollection containing the requested timetable purposes.</returns>
		public TimeTablePurposeCollection GetTimeTablePurposesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			TimeTablePurposeDataCollection timeTablePurposeData =
				this.GetTimeTablePurposeDataCollectionForEmployeeGroup( employeeGroup.SysId );
			return TimeTablePurposeMapping.FromDataObjectCollection( timeTablePurposeData );
		}

		/// <summary>
		/// Create a new timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTablePurpose">The timetable purpose to create.</param>
		/// <param name="employeeGroup">The employeegroup to create the new timetable purpose for.</param>
		/// <returns>The created timetable purpose.</returns>
		public TimeTablePurpose CreateTimeTablePurpose( TimeTablePurpose timeTablePurpose , EmployeeGroup employeeGroup ) {
			TimeTablePurposeData timeTablePurposeToInsert = TimeTablePurposeMapping.FromBusinessObject( timeTablePurpose );
			timeTablePurposeToInsert.EmployeeGroupSysId = employeeGroup.SysId;
			TimeTablePurposeDataCollection timeTablePurposeDataInserted =
				this.InsertTimeTablePurposeDataCollection( TimeTablePurposeDataCollection.FromSingleTimeTablePurpose( timeTablePurposeToInsert ) );
			return TimeTablePurposeMapping.FromDataObject( timeTablePurposeDataInserted[0] );
		}

		/// <summary>
		/// Update an existing timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTablePurpose">The timetable purpose to update.</param>
		/// <param name="employeeGroup">The new employeegroup to associate with the updated timetable purpose.</param>
		/// <returns>The updated timetable purpose.</returns>
		public TimeTablePurpose UpdateTimeTablePurpose( TimeTablePurpose timeTablePurpose , EmployeeGroup employeeGroup ) {
			TimeTablePurposeData timeTablePurposeToUpdate = TimeTablePurposeMapping.FromBusinessObject( timeTablePurpose );
			timeTablePurposeToUpdate.EmployeeGroupSysId = employeeGroup.SysId;
			TimeTablePurposeDataCollection timeTablePurposeDataUpdated =
				this.UpdateTimeTablePurposeDataCollection( TimeTablePurposeDataCollection.FromSingleTimeTablePurpose( timeTablePurposeToUpdate ) );
			return TimeTablePurposeMapping.FromDataObject( timeTablePurposeDataUpdated[0] );
		}

		/// <summary>
		/// Remove one or more timetable purposes.
		/// </summary>
		/// <param name="timeTablePurposes">The timetable purposes to remove.</param>
		public void RemoveTimeTablePurposes( TimeTablePurposeCollection timeTablePurposes ) {
			try {
				this.RemoveTimeTablePurposeDataCollection( TimeTablePurposeMapping.FromBusinessObjectCollection( timeTablePurposes ) );
			} catch( Exception e ) {
				String message = "";
				if( timeTablePurposes.Count > 1 ) {
					message = "Uurrooster categoriën kunnen niet worden verwijderd omdat minstens één categorie nog in gebruik is.";
				} else {
					message = "Uurrooster categorie kan niet worden verwijderd omdat ze nog in gebruik is.";
				}
				throw new SwmSuiteException( e , SwmSuiteError.BusinessError , message );
			}
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all timetablepurposedatacollection from the database.
		/// </summary>
		/// <returns>An TimeTablePurposeDataCollection containing all timetablepurposedatacollection.</returns>
		public TimeTablePurposeDataCollection GetTimeTablePurposeDataCollection() {
			return dal.GetTimeTablePurposeDataCollection();
		}

		/// <summary>
		/// Get all timetablepurposedatacollection from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the timetable purposes for.</param>
		/// <returns>An TimeTablePurposeDataCollection containing all requested timetablepurposedatacollection.</returns>
		public TimeTablePurposeDataCollection GetTimeTablePurposeDataCollectionForEmployeeGroup( int employeeGroupSysId ) {
			return dal.GetTimeTablePurposeDataCollectionForEmployeeGroup( employeeGroupSysId );
		}

		/// <summary>
		/// Get a single timetablepurposedata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetablepurposedata to retrieve.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the requested timetablepurposedata.</returns>
		public TimeTablePurposeDataCollection GetTimeTablePurposeDataBySysId( int sysId ) {
			return dal.GetTimeTablePurposeDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple timetablepurposedatacollection from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetablepurposedatacollection to retrieve.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the requested timetablepurposedatacollection.</returns>
		public TimeTablePurposeDataCollection GetTimeTablePurposeDataCollectionBySysIds( int[] sysIds ) {
			return dal.GetTimeTablePurposeDataCollectionBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more timetablepurposedatacollection to the database.
		/// </summary>
		/// <param name="timetablepurposedatacollection">An TimeTablePurposeDataCollection containing the timetablepurposedatacollection to insert.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the inserted timetablepurposedatacollection.</returns>
		public TimeTablePurposeDataCollection InsertTimeTablePurposeDataCollection( TimeTablePurposeDataCollection timetablepurposedatacollection ) {
			return dal.InsertTimeTablePurposeDataCollection( timetablepurposedatacollection );
		}

		/// <summary>
		/// Update one or more timetablepurposedatacollection in the database.
		/// </summary>
		/// <param name="timetablepurposedatacollection">An TimeTablePurposeDataCollection containing the timetablepurposedatacollection to update.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the updated timetablepurposedatacollection.</returns>
		public TimeTablePurposeDataCollection UpdateTimeTablePurposeDataCollection( TimeTablePurposeDataCollection timetablepurposedatacollection ) {
			return dal.UpdateTimeTablePurposeDataCollection( timetablepurposedatacollection );
		}

		/// <summary>
		/// Remove one or more timetablepurposedatacollection from the database.
		/// </summary>
		/// <param name="timetablepurposedatacollection">An TimeTablePurposeDataCollection containing the timetablepurposedatacollection to remove.</param>
		public void RemoveTimeTablePurposeDataCollection( TimeTablePurposeDataCollection timetablepurposedatacollection ) {
			dal.RemoveTimeTablePurposeDataCollection( timetablepurposedatacollection );
		}

		/// <summary>
		/// Remove all timetablepurposedatacollection from the database.
		/// </summary>
		public void RemoveAllTimeTablePurposeDataCollection() {
			dal.RemoveAllTimeTablePurposeDataCollection();
		}

		#endregion

	}

}
