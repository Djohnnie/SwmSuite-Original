using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using System;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;
using System.Globalization;
using SwmSuite.Framework;

namespace SwmSuite.Business {

	public class RecurrenceBll {

		#region -_ Private Members _-

		private IRecurrenceDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateRecurrenceDal();

		#endregion

		#region -_ Business Methods _-

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all recurrences from the database for a specific appointment.
		/// </summary>
		/// <param name="appointmentSysId">The internal id of the appointment to get the recurrences for.</param>
		/// <returns>A RecurrenceCollection containing the requested recurrence.</returns>
		public RecurrenceDataCollection GetRecurrenceDataForAppointment( int appointmentSysId ) {
			return dal.GetRecurrenceDataForAppointment( appointmentSysId );
		}

		/// <summary>
		/// Get all recurrences from the database for a specific task.
		/// </summary>
		/// <param name="taskSysId">The internal id of the task to get the recurrences for.</param>
		/// <returns>A RecurrenceCollection containing the requested recurrence.</returns>
		public RecurrenceDataCollection GetRecurrenceDataForTask( int taskSysId ) {
			return dal.GetRecurrenceDataForTask( taskSysId );
		}

		/// <summary>
		/// Get all recurrences from the database.
		/// </summary>
		/// <returns>A RecurrenceCollection containing all recurrences.</returns>
		public RecurrenceDataCollection GetRecurrenceData() {
			return dal.GetRecurrenceData();
		}

		/// <summary>
		/// Get a single recurrence from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the recurrence to retrieve.</param>
		/// <returns>An RecurrenceCollection containing the requested recurrence.</returns>
		public RecurrenceDataCollection GetRecurrenceDataBySysId( int sysId ) {
			return dal.GetRecurrenceDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple recurrences from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the recurrences to retrieve.</param>
		/// <returns>An RecurrenceCollection containing the requested recurrences.</returns>
		public RecurrenceDataCollection GetRecurrenceDataBySysIds( int[] sysIds ) {
			return dal.GetRecurrenceDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more recurrences to the database.
		/// </summary>
		/// <param name="recurrences">An RecurrenceCollection containing the recurrences to insert.</param>
		/// <returns>An RecurrenceCollection containing the inserted recurrences.</returns>
		public RecurrenceDataCollection InsertRecurrenceData( RecurrenceDataCollection recurrences ) {
			return dal.InsertRecurrenceData( recurrences );
		}

		/// <summary>
		/// Update one or more recurrences in the database.
		/// </summary>
		/// <param name="recurrences">An RecurrenceCollection containing the recurrences to update.</param>
		/// <returns>An RecurrenceCollection containing the updated recurrences.</returns>
		public RecurrenceDataCollection UpdateRecurrenceData( RecurrenceDataCollection recurrences ) {
			return dal.UpdateRecurrenceData( recurrences );
		}

		/// <summary>
		/// Remove one or more recurrences from the database.
		/// </summary>
		/// <param name="recurrences">An RecurrenceCollection containing the recurrences to remove.</param>
		public void RemoveRecurrenceData( RecurrenceDataCollection recurrences ) {
			dal.RemoveRecurrenceData( recurrences );
		}

		/// <summary>
		/// Remove all recurrences from the database.
		/// </summary>
		public void RemoveAllRecurrenceData() {
			dal.RemoveAllRecurrenceData();
		}

		#endregion

	}

}
