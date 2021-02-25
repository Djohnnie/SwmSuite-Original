using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the TaskDescriptionService methods.
	/// </summary>
	public interface ITaskDescriptionDal {

		/// <summary>
		/// Get all taskdescriptions from the database.
		/// </summary>
		/// <returns>A TaskDescriptionCollection containing all taskdescriptions.</returns>
		TaskDescriptionDataCollection GetTaskDescriptionData();

		/// <summary>
		/// Get a single taskdescription from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the taskdescription to retrieve.</param>
		/// <returns>An TaskDescriptionCollection containing the requested taskdescription.</returns>
		TaskDescriptionDataCollection GetTaskDescriptionDataBySysId( int sysId );

		/// <summary>
		/// Get multiple taskdescriptions from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the taskdescriptions to retrieve.</param>
		/// <returns>An TaskDescriptionCollection containing the requested taskdescriptions.</returns>
		TaskDescriptionDataCollection GetTaskDescriptionDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more taskdescriptions to the database.
		/// </summary>
		/// <param name="taskdescriptions">An TaskDescriptionCollection containing the taskdescriptions to insert.</param>
		/// <returns>An TaskDescriptionCollection containing the inserted taskdescriptions.</returns>
		TaskDescriptionDataCollection InsertTaskDescriptionData( TaskDescriptionDataCollection taskdescriptions );

		/// <summary>
		/// Update one or more taskdescriptions in the database.
		/// </summary>
		/// <param name="taskdescriptions">An TaskDescriptionCollection containing the taskdescriptions to update.</param>
		/// <returns>An TaskDescriptionCollection containing the updated taskdescriptions.</returns>
		TaskDescriptionDataCollection UpdateTaskDescriptionData( TaskDescriptionDataCollection taskdescriptions );

		/// <summary>
		/// Remove one or more taskdescriptions from the database.
		/// </summary>
		/// <param name="taskdescriptions">An TaskDescriptionCollection containing the taskdescriptions to remove.</param>
		void RemoveTaskDescriptionData( TaskDescriptionDataCollection taskdescriptions );

		/// <summary>
		/// Remove all taskdescriptions from the database.
		/// </summary>
		void RemoveAllTaskDescriptionData();

	}

}
