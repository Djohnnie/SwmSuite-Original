using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the TaskRecurrenceService methods.
	/// </summary>
	public interface ITaskRecurrenceDal {

		/// <summary>
		/// Get all taskrecurrences from the database.
		/// </summary>
		/// <returns>A TaskRecurrenceCollection containing all taskrecurrences.</returns>
		TaskRecurrenceDataCollection GetTaskRecurrenceData();

		/// <summary>
		/// Get a single taskrecurrence from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the taskrecurrence to retrieve.</param>
		/// <returns>An TaskRecurrenceCollection containing the requested taskrecurrence.</returns>
		TaskRecurrenceDataCollection GetTaskRecurrenceDataBySysId( int sysId );

		/// <summary>
		/// Get multiple taskrecurrences from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the taskrecurrences to retrieve.</param>
		/// <returns>An TaskRecurrenceCollection containing the requested taskrecurrences.</returns>
		TaskRecurrenceDataCollection GetTaskRecurrenceDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more taskrecurrences to the database.
		/// </summary>
		/// <param name="taskrecurrences">An TaskRecurrenceCollection containing the taskrecurrences to insert.</param>
		/// <returns>An TaskRecurrenceCollection containing the inserted taskrecurrences.</returns>
		TaskRecurrenceDataCollection InsertTaskRecurrenceData( TaskRecurrenceDataCollection taskrecurrences );

		/// <summary>
		/// Update one or more taskrecurrences in the database.
		/// </summary>
		/// <param name="taskrecurrences">An TaskRecurrenceCollection containing the taskrecurrences to update.</param>
		/// <returns>An TaskRecurrenceCollection containing the updated taskrecurrences.</returns>
		TaskRecurrenceDataCollection UpdateTaskRecurrenceData( TaskRecurrenceDataCollection taskrecurrences );

		/// <summary>
		/// Remove one or more taskrecurrences from the database.
		/// </summary>
		/// <param name="taskrecurrences">An TaskRecurrenceCollection containing the taskrecurrences to remove.</param>
		void RemoveTaskRecurrenceData( TaskRecurrenceDataCollection taskrecurrences );

		/// <summary>
		/// Remove all taskrecurrences from the database.
		/// </summary>
		void RemoveAllTaskRecurrenceData();

	}

}
