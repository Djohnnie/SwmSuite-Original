using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {

	public class TaskFacade : ITaskFacade {

		/// <summary>
		/// Get all tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing all tasks.</returns>
		TaskCollection ITaskFacade.GetTasksForEmployee( Employee employee , int year ) {
			return new TaskBll().GetTasksForEmployee( employee , year );
		}

		/// <summary>
		/// Get all pending tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the pending tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection ITaskFacade.GetPendingTasksForEmployee( Employee employee , int year ) {
			return new TaskBll().GetPendingTasksForEmployee( employee , year );
		}

		/// <summary>
		/// Get all completed tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the completed tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection ITaskFacade.GetCompletedTasksForEmployee( Employee employee , int year ) {
			return new TaskBll().GetCompletedTasksForEmployee( employee , year );
		}

		/// <summary>
		/// Get all failed tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the failed tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection ITaskFacade.GetFailedTasksForEmployee( Employee employee , int year ) {
			return new TaskBll().GetFailedTasksForEmployee( employee , year );
		}

		/// <summary>
		/// Get all overdue tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the overdue tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection ITaskFacade.GetOverDueTasksForEmployee( Employee employee , int year ) {
			return new TaskBll().GetOverDueTasksForEmployee( employee , year );
		}

		/// <summary>
		/// Create a new task.
		/// </summary>
		/// <param name="task">The task to create.</param>
		void ITaskFacade.CreateTask( Task task ) {
			new TaskBll().CreateTask( task );
		}

		/// <summary>
		/// Complete a task given the specified taskrun.
		/// </summary>
		/// <param name="taskRun">The taskrun that defines the completed task.</param>
		void ITaskFacade.CompleteTask( TaskRun taskRun ) {
			new TaskBll().CompleteTask( taskRun );
		}

	}

}
