using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the RecurrenceService methods.
	/// </summary>
	public interface IRecurrenceDal {

		/// <summary>
		/// Get all recurrences from the database for a specific appointment.
		/// </summary>
		/// <param name="appointmentSysId">The internal id of the appointment to get the recurrences for.</param>
		/// <returns>A RecurrenceCollection containing the requested recurrence.</returns>
		RecurrenceDataCollection GetRecurrenceDataForAppointment( int appointmentSysId );

		/// <summary>
		/// Get all recurrences from the database for a specific task.
		/// </summary>
		/// <param name="taskSysId">The internal id of the task to get the recurrences for.</param>
		/// <returns>A RecurrenceCollection containing the requested recurrence.</returns>
		RecurrenceDataCollection GetRecurrenceDataForTask( int taskSysId );

		/// <summary>
		/// Get all recurrences from the database.
		/// </summary>
		/// <returns>A RecurrenceCollection containing all recurrences.</returns>
		RecurrenceDataCollection GetRecurrenceData();

		/// <summary>
		/// Get a single recurrence from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the recurrence to retrieve.</param>
		/// <returns>An RecurrenceCollection containing the requested recurrence.</returns>
		RecurrenceDataCollection GetRecurrenceDataBySysId( int sysId );

		/// <summary>
		/// Get multiple recurrences from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the recurrences to retrieve.</param>
		/// <returns>An RecurrenceCollection containing the requested recurrences.</returns>
		RecurrenceDataCollection GetRecurrenceDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more recurrences to the database.
		/// </summary>
		/// <param name="recurrences">An RecurrenceCollection containing the recurrences to insert.</param>
		/// <returns>An RecurrenceCollection containing the inserted recurrences.</returns>
		RecurrenceDataCollection InsertRecurrenceData( RecurrenceDataCollection recurrences );

		/// <summary>
		/// Update one or more recurrences in the database.
		/// </summary>
		/// <param name="recurrences">An RecurrenceCollection containing the recurrences to update.</param>
		/// <returns>An RecurrenceCollection containing the updated recurrences.</returns>
		RecurrenceDataCollection UpdateRecurrenceData( RecurrenceDataCollection recurrences );

		/// <summary>
		/// Remove one or more recurrences from the database.
		/// </summary>
		/// <param name="recurrences">An RecurrenceCollection containing the recurrences to remove.</param>
		void RemoveRecurrenceData( RecurrenceDataCollection recurrences );

		/// <summary>
		/// Remove all recurrences from the database.
		/// </summary>
		void RemoveAllRecurrenceData();

	}

}
