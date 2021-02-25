using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the TaskService methods.
	/// </summary>
	public interface ITaskDal {

		/// <summary>
		/// Get all tasks from the database.
		/// </summary>
		/// <returns>A TaskCollection containing all tasks.</returns>
		TaskDataCollection GetTaskData();

		/// <summary>
		/// Get a single task from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the task to retrieve.</param>
		/// <returns>An TaskCollection containing the requested task.</returns>
		TaskDataCollection GetTaskDataBySysId( int sysId );

		/// <summary>
		/// Get all tasks from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the tasks for.</param>
		/// <param name="year">The year to get the task data for.</param>
		/// <returns>A TaskDataCollection containing the requested tasks.</returns>
		TaskDataCollection GetTaskDataByEmployee( int employeeSysId , int year );

		/// <summary>
		/// Get multiple tasks from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the tasks to retrieve.</param>
		/// <returns>An TaskCollection containing the requested tasks.</returns>
		TaskDataCollection GetTaskDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more tasks to the database.
		/// </summary>
		/// <param name="tasks">An TaskCollection containing the tasks to insert.</param>
		/// <returns>An TaskCollection containing the inserted tasks.</returns>
		TaskDataCollection InsertTaskData( TaskDataCollection tasks );

		/// <summary>
		/// Update one or more tasks in the database.
		/// </summary>
		/// <param name="tasks">An TaskCollection containing the tasks to update.</param>
		/// <returns>An TaskCollection containing the updated tasks.</returns>
		TaskDataCollection UpdateTaskData( TaskDataCollection tasks );

		/// <summary>
		/// Remove one or more tasks from the database.
		/// </summary>
		/// <param name="tasks">An TaskCollection containing the tasks to remove.</param>
		void RemoveTaskData( TaskDataCollection tasks );

		/// <summary>
		/// Remove all tasks from the database.
		/// </summary>
		void RemoveAllTaskData();

	}

}
