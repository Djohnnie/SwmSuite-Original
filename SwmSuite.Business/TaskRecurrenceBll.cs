using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class TaskRecurrenceBll {

		#region -_ Private Members _-

		private ITaskRecurrenceDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateTaskRecurrenceDal();

		#endregion

		#region -_ Business Methods _-

		///// <summary>
		///// Get all taskrecurrences from the database.
		///// </summary>
		///// <returns>A RecurrenceCollection containing the requested task recurrences.</returns>
		//public RecurrenceCollection GetTaskRecurrences() {
		//  RecurrenceCollection recurrencesToReturn = new RecurrenceCollection();
		//  TaskRecurrenceDataCollection taskRecurrenceDataCollection = this.GetTaskRecurrenceData();
		//  foreach( TaskRecurrenceData taskRecurrenceData in taskRecurrenceDataCollection ) {
		//    RecurrenceData recurrenceData = new RecurrenceBll().GetRecurrenceDataBySysId(taskRe
		//  }
		//  return recurrencesToReturn;
		//}

		///// <summary>
		///// Get the task recurrences from the database on a specific date.
		///// </summary>
		///// <param name="onDate">The date to get the task recurrences for.</param>
		///// <returns>A RecurrenceCollection containing the requested task recurrences.</returns>
		//public RecurrenceCollection GetTaskRecurrencesOnDate( DateTime onDate ) {
		//  RecurrenceCollection recurrencesToReturn = new RecurrenceCollection();

		//  return recurrencesToReturn;
		//}

		///// <summary>
		///// Get the task recurrences from the database in a specific period of time.
		///// </summary>
		///// <param name="startPeriod">The start date of the period to get the task recurrences for.</param>
		///// <param name="endPeriod">The end date of the period to get the task recurrences for.</param>
		///// <returns>A RecurrenceCollection containing the requested task recurrences.</returns>
		//public RecurrenceCollection GetTaskRecurrencesInPeriod( DateTime startPeriod , DateTime endPeriod ) {
		//  RecurrenceCollection recurrencesToReturn = new RecurrenceCollection();
		//  DateTime onDate = startPeriod;
		//  while( onDate < endPeriod ) {
		//    recurrencesToReturn.Add( GetTaskRecurrencesOnDate( onDate ) );
		//    onDate = onDate.AddDays( 1 );
		//  }
		//  return recurrencesToReturn;
		//}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all taskrecurrences from the database.
		/// </summary>
		/// <returns>An TaskRecurrenceCollection containing all taskrecurrences.</returns>
		public TaskRecurrenceDataCollection GetTaskRecurrenceData() {
			return dal.GetTaskRecurrenceData();
		}

		/// <summary>
		/// Get a single taskrecurrence from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the taskrecurrence to retrieve.</param>
		/// <returns>An TaskRecurrenceCollection containing the requested taskrecurrence.</returns>
		public TaskRecurrenceDataCollection GetTaskRecurrenceDataBySysId( int sysId ) {
			return dal.GetTaskRecurrenceDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple taskrecurrences from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the taskrecurrences to retrieve.</param>
		/// <returns>An TaskRecurrenceCollection containing the requested taskrecurrences.</returns>
		public TaskRecurrenceDataCollection GetTaskRecurrenceDataBySysIds( int[] sysIds ) {
			return dal.GetTaskRecurrenceDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more taskrecurrences to the database.
		/// </summary>
		/// <param name="taskrecurrences">An TaskRecurrenceCollection containing the taskrecurrences to insert.</param>
		/// <returns>An TaskRecurrenceCollection containing the inserted taskrecurrences.</returns>
		public TaskRecurrenceDataCollection InsertTaskRecurrenceData( TaskRecurrenceDataCollection taskrecurrences ) {
			return dal.InsertTaskRecurrenceData( taskrecurrences );
		}

		/// <summary>
		/// Update one or more taskrecurrences in the database.
		/// </summary>
		/// <param name="taskrecurrences">An TaskRecurrenceCollection containing the taskrecurrences to update.</param>
		/// <returns>An TaskRecurrenceCollection containing the updated taskrecurrences.</returns>
		public TaskRecurrenceDataCollection UpdateTaskRecurrenceData( TaskRecurrenceDataCollection taskrecurrences ) {
			return dal.UpdateTaskRecurrenceData( taskrecurrences );
		}

		/// <summary>
		/// Remove one or more taskrecurrences from the database.
		/// </summary>
		/// <param name="taskrecurrences">An TaskRecurrenceCollection containing the taskrecurrences to remove.</param>
		public void RemoveTaskRecurrenceData( TaskRecurrenceDataCollection taskrecurrences ) {
			dal.RemoveTaskRecurrenceData( taskrecurrences );
		}

		/// <summary>
		/// Remove all taskrecurrences from the database.
		/// </summary>
		public void RemoveAllTaskRecurrenceData() {
			dal.RemoveAllTaskRecurrenceData();
		}

		#endregion

	}

}
