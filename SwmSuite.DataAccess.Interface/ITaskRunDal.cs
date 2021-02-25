using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the TaskRunService methods.
	/// </summary>
	public interface ITaskRunDal {

		/// <summary>
		/// Get all taskruns from the database.
		/// </summary>
		/// <returns>A TaskRunCollection containing all taskruns.</returns>
		TaskRunDataCollection GetTaskRunData();

		/// <summary>
		/// Get all taskruns from the database for a specific task.
		/// </summary>
		/// <param name="taskSysId">The internal id of the task to get the taskruns for.</param>
		/// <returns>A TaskRunCollection containing the requested taskruns.</returns>
		TaskRunDataCollection GetTaskRunDataByTask( int taskSysId );

		/// <summary>
		/// Get a single taskrun from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the taskrun to retrieve.</param>
		/// <returns>A TaskRunCollection containing the requested taskrun.</returns>
		TaskRunDataCollection GetTaskRunDataBySysId( int sysId );

		/// <summary>
		/// Get multiple taskruns from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the taskruns to retrieve.</param>
		/// <returns>A TaskRunCollection containing the requested taskruns.</returns>
		TaskRunDataCollection GetTaskRunDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more taskruns to the database.
		/// </summary>
		/// <param name="taskruns">An TaskRunCollection containing the taskruns to insert.</param>
		/// <returns>A TaskRunCollection containing the inserted taskruns.</returns>
		TaskRunDataCollection InsertTaskRunData( TaskRunDataCollection taskruns );

		/// <summary>
		/// Update one or more taskruns in the database.
		/// </summary>
		/// <param name="taskruns">An TaskRunCollection containing the taskruns to update.</param>
		/// <returns>A TaskRunCollection containing the updated taskruns.</returns>
		TaskRunDataCollection UpdateTaskRunData( TaskRunDataCollection taskruns );

		/// <summary>
		/// Remove one or more taskruns from the database.
		/// </summary>
		/// <param name="taskruns">A TaskRunCollection containing the taskruns to remove.</param>
		void RemoveTaskRunData( TaskRunDataCollection taskruns );

		/// <summary>
		/// Remove all taskruns from the database.
		/// </summary>
		void RemoveAllTaskRunData();

	}

}
