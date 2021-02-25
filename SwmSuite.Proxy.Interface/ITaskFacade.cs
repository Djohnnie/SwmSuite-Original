using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Proxy.Interface {

	public interface ITaskFacade {

		/// <summary>
		/// Get all tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing all tasks.</returns>
		TaskCollection GetTasksForEmployee( Employee employee , int year );

		/// <summary>
		/// Get all pending tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the pending tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection GetPendingTasksForEmployee( Employee employee , int year );

		/// <summary>
		/// Get all completed tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the completed tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection GetCompletedTasksForEmployee( Employee employee , int year );

		/// <summary>
		/// Get all failed tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the failed tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection GetFailedTasksForEmployee( Employee employee , int year );

		/// <summary>
		/// Get all overdue tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the overdue tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection GetOverDueTasksForEmployee( Employee employee , int year );

		/// <summary>
		/// Create a new task.
		/// </summary>
		/// <param name="task">The task to create.</param>
		void CreateTask( Task task );

		/// <summary>
		/// Complete a task given the specified taskrun.
		/// </summary>
		/// <param name="taskRun">The taskrun that defines the completed task.</param>
		void CompleteTask( TaskRun taskRun );

	}

}
