using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public class TaskFacade :
		ServiceFacade<TaskService.TaskService , TaskService.SwmSuiteSoapHeader> ,
		ITaskFacade {

		/// <summary>
		/// Get all tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing all tasks.</returns>
		TaskCollection ITaskFacade.GetTasksForEmployee( Employee employee , int year ) {
			try {
				TaskService.Employee employeeParameter = (TaskService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( TaskService.Employee ) );
				TaskCollection tasksToReturn = new TaskCollection();
				foreach( TaskService.Task task in GetService().GetTasksForEmployee( employeeParameter , year ) ) {
					tasksToReturn.Add( (Task)XmlSerialization.ConvertObject( task , typeof( TaskService.Task ) , typeof( Task ) ) );
				}
				return tasksToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all pending tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the pending tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection ITaskFacade.GetPendingTasksForEmployee( Employee employee , int year ) {
			try {
				TaskService.Employee employeeParameter = (TaskService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( TaskService.Employee ) );
				TaskCollection tasksToReturn = new TaskCollection();
				foreach( TaskService.Task task in GetService().GetPendingTasksForEmployee( employeeParameter , year ) ) {
					tasksToReturn.Add( (Task)XmlSerialization.ConvertObject( task , typeof( TaskService.Task ) , typeof( Task ) ) );
				}
				return tasksToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all completed tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the completed tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection ITaskFacade.GetCompletedTasksForEmployee( Employee employee , int year ) {
			try {
				TaskService.Employee employeeParameter = (TaskService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( TaskService.Employee ) );
				TaskCollection tasksToReturn = new TaskCollection();
				foreach( TaskService.Task task in GetService().GetCompletedTasksForEmployee( employeeParameter , year ) ) {
					tasksToReturn.Add( (Task)XmlSerialization.ConvertObject( task , typeof( TaskService.Task ) , typeof( Task ) ) );
				}
				return tasksToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all failed tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the failed tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection ITaskFacade.GetFailedTasksForEmployee( Employee employee , int year ) {
			try {
				TaskService.Employee employeeParameter = (TaskService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( TaskService.Employee ) );
				TaskCollection tasksToReturn = new TaskCollection();
				foreach( TaskService.Task task in GetService().GetFailedTasksForEmployee( employeeParameter , year ) ) {
					tasksToReturn.Add( (Task)XmlSerialization.ConvertObject( task , typeof( TaskService.Task ) , typeof( Task ) ) );
				}
				return tasksToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all overdue tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the overdue tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		TaskCollection ITaskFacade.GetOverDueTasksForEmployee( Employee employee , int year ) {
			try {
				TaskService.Employee employeeParameter = (TaskService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( TaskService.Employee ) );
				TaskCollection tasksToReturn = new TaskCollection();
				foreach( TaskService.Task task in GetService().GetOverDueTasksForEmployee( employeeParameter , year ) ) {
					tasksToReturn.Add( (Task)XmlSerialization.ConvertObject( task , typeof( TaskService.Task ) , typeof( Task ) ) );
				}
				return tasksToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Create a new task.
		/// </summary>
		/// <param name="task">The task to create.</param>
		void ITaskFacade.CreateTask( Task task ) {
			try {
				TaskService.Task taskParameter = (TaskService.Task)XmlSerialization.ConvertObject( task , typeof( Task ) , typeof( TaskService.Task ) );
				GetService().CreateTask( taskParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Complete a task given the specified taskrun.
		/// </summary>
		/// <param name="taskRun">The taskrun that defines the completed task.</param>
		void ITaskFacade.CompleteTask( TaskRun taskRun ) {
			try {
				TaskService.TaskRun taskRunParameter = (TaskService.TaskRun)XmlSerialization.ConvertObject( taskRun , typeof( TaskRun ) , typeof( TaskService.TaskRun ) );
				GetService().CompleteTask( taskRunParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

	}

}
