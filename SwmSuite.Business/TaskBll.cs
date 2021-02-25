using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Business;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;
using SwmSuite.Data.Common;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Business {

	public class TaskBll {

		#region -_ Private Members _-

		private ITaskDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateTaskDal();

		private TaskDescriptionBll _taskDescriptionBll = new TaskDescriptionBll();
		private TaskRecurrenceBll _taskRecurrenceBll = new TaskRecurrenceBll();
		private RecurrenceBll _recurrenceBll = new RecurrenceBll();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing all tasks.</returns>
		public TaskCollection GetTasksForEmployee( Employee employee , int year ) {
			TaskDataCollection taskData =
				this.GetTaskDataByEmployee( employee.SysId , year );
			TaskCollection tasksToReturn = TaskMapping.FromDataObjectCollection( taskData );
			foreach( Task task in tasksToReturn ) {
				task.Employee = employee;
			}
			return tasksToReturn;
		}

		/// <summary>
		/// Get all pending tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the pending tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		public TaskCollection GetPendingTasksForEmployee( Employee employee , int year ) {
			TaskDataCollection taskData =
				this.GetTaskDataByEmployee( employee.SysId , year );
			TaskCollection tasks = TaskMapping.FromDataObjectCollection( taskData );
			TaskCollection tasksToReturn = new TaskCollection();
			foreach( Task task in tasks ) {
				if( task.IsPending ) {
					tasksToReturn.Add( task );
					task.Employee = employee;
				}
			}
			return tasksToReturn;
		}

		/// <summary>
		/// Get all completed tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the completed tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		public TaskCollection GetCompletedTasksForEmployee( Employee employee , int year ) {
			TaskDataCollection taskData =
				this.GetTaskDataByEmployee( employee.SysId , year );
			TaskCollection tasks = TaskMapping.FromDataObjectCollection( taskData );
			TaskCollection tasksToReturn = new TaskCollection();
			foreach( Task task in tasks ) {
				if( task.IsFinished ) {
					tasksToReturn.Add( task );
					task.Employee = employee;
				}
			}
			return tasksToReturn;
		}

		/// <summary>
		/// Get all failed tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the failed tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		public TaskCollection GetFailedTasksForEmployee( Employee employee , int year ) {
			TaskDataCollection taskData =
				this.GetTaskDataByEmployee( employee.SysId , year );
			TaskCollection tasks = TaskMapping.FromDataObjectCollection( taskData );
			TaskCollection tasksToReturn = new TaskCollection();
			foreach( Task task in tasks ) {
				if( task.IsFailed ) {
					tasksToReturn.Add( task );
					task.Employee = employee;
				}
			}
			return tasksToReturn;
		}

		/// <summary>
		/// Get all overdue tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the overdue tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		public TaskCollection GetOverDueTasksForEmployee( Employee employee , int year ) {
			TaskDataCollection taskData =
				this.GetTaskDataByEmployee( employee.SysId , year );
			TaskCollection tasks = TaskMapping.FromDataObjectCollection( taskData );
			TaskCollection tasksToReturn = new TaskCollection();
			foreach( Task task in tasks ) {
				if( task.IsOverDue ) {
					tasksToReturn.Add( task );
					task.Employee = employee;
				}
			}
			return tasksToReturn;
		}

		/// <summary>
		/// Create a new task.
		/// </summary>
		/// <param name="task">The task to create.</param>
		public void CreateTask( Task task ) {
			int taskDescriptionSysId;
			//int taskRecurrenceSysId;

			//
			// Create taskdescription to describe the new task.
			//
			TaskDescriptionData taskDescription = new TaskDescriptionData(
				task.Title , task.CreationDate , task.Description , task.Deadline , task.Commissioner.SysId );
			// Insert the new taskdescription in the database.
			TaskDescriptionDataCollection taskDescriptionsInserted =
				_taskDescriptionBll.InsertTaskDescriptionData( TaskDescriptionDataCollection.FromSingleTaskDescription( taskDescription ) );
			// Get the sysid for the inserted taskdescription.
			taskDescriptionSysId = taskDescriptionsInserted[0].SysId;

			////
			//// Create the recurrence.
			////
			//if( task.Recurrence != null ) {
			//  RecurrenceData recurrenceData =
			//    new RecurrenceData( task.Recurrence.RecurrenceMode , task.Recurrence.EndDate );
			//  RecurrenceDataCollection recurrences =
			//    _recurrenceBll.InsertRecurrenceData( RecurrenceDataCollection.FromSingleRecurrence( recurrenceData ) );
			//  taskRecurrenceSysId = recurrences[0].SysId;

			//  //
			//  // Create the task <-> recurrence link.
			//  //

			//  TaskRecurrenceData taskRecurrenceData = new TaskRecurrenceData( taskDescriptionSysId , taskRecurrenceSysId );
			//  _taskRecurrenceBll.InsertTaskRecurrenceData( TaskRecurrenceDataCollection.FromSingleTaskRecurrence( taskRecurrenceData ) );
			//}

			// Create the tasks.
			TaskDataCollection tasks = new TaskDataCollection();
			foreach( Employee employee in task.Employees ) {
				tasks.Add( new TaskData(
					employee.SysId , taskDescriptionSysId ) );
			}
			// Insert the tasks in the database.
			this.InsertTaskData( tasks );
		}

		/// <summary>
		/// Complete a task given the specified taskrun.
		/// </summary>
		/// <param name="taskRun">The taskrun that defines the completed task.</param>
		public void CompleteTask( TaskRun taskRun ) {
			TaskRunBll taskRunBll = new TaskRunBll();
			TaskRunDataCollection existingTaskRunData = taskRunBll.GetTaskRunDataByTask( taskRun.Task.SysId );
			if( existingTaskRunData.Count == 0 ) {
				TaskRunData taskRunData = TaskRunMapping.FromBusinessObject( taskRun );
				new TaskRunBll().InsertTaskRunData( TaskRunDataCollection.FromSingleTaskRun( taskRunData ) );
			} else {
				throw new SwmSuiteException( null , SwmSuiteError.ValidationError , "Taak \"" + taskRun.Task.Title + "\" is reeds afgepunt." );
			}
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all tasks from the database.
		/// </summary>
		/// <returns>An TaskCollection containing all tasks.</returns>
		public TaskDataCollection GetTaskData() {
			return dal.GetTaskData();
		}

		/// <summary>
		/// Get a single task from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the task to retrieve.</param>
		/// <returns>An TaskCollection containing the requested task.</returns>
		public TaskDataCollection GetTaskDataBySysId( int sysId ) {
			return dal.GetTaskDataBySysId( sysId );
		}

		/// <summary>
		/// Get all tasks from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the tasks for.</param>
		/// <param name="year">The year to get the task data for.</param>
		/// <returns>A TaskDataCollection containing the requested tasks.</returns>
		public TaskDataCollection GetTaskDataByEmployee( int employeeSysId , int year ) {
			return dal.GetTaskDataByEmployee( employeeSysId , year );
		}

		/// <summary>
		/// Get multiple tasks from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the tasks to retrieve.</param>
		/// <returns>An TaskCollection containing the requested tasks.</returns>
		public TaskDataCollection GetTaskDataBySysIds( int[] sysIds ) {
			return dal.GetTaskDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more tasks to the database.
		/// </summary>
		/// <param name="tasks">An TaskCollection containing the tasks to insert.</param>
		/// <returns>An TaskCollection containing the inserted tasks.</returns>
		public TaskDataCollection InsertTaskData( TaskDataCollection tasks ) {
			return dal.InsertTaskData( tasks );
		}

		/// <summary>
		/// Update one or more tasks in the database.
		/// </summary>
		/// <param name="tasks">An TaskCollection containing the tasks to update.</param>
		/// <returns>An TaskCollection containing the updated tasks.</returns>
		public TaskDataCollection UpdateTaskData( TaskDataCollection tasks ) {
			return dal.UpdateTaskData( tasks );
		}

		/// <summary>
		/// Remove one or more tasks from the database.
		/// </summary>
		/// <param name="tasks">An TaskCollection containing the tasks to remove.</param>
		public void RemoveTaskData( TaskDataCollection tasks ) {
			dal.RemoveTaskData( tasks );
		}

		/// <summary>
		/// Remove all tasks from the database.
		/// </summary>
		public void RemoveAllTaskData() {
			dal.RemoveAllTaskData();
		}

		#endregion

	}

}
