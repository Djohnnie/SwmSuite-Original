using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {

	public class TaskMapping : Mapping {

		public static Task FromDataObject( TaskData taskData ) {
			Mapping mapping = new TaskMapping();
			return mapping.FromDataObject( taskData ) as Task;
		}

		public static TaskData FromBusinessObject( Task task ) {
			Mapping mapping = new TaskMapping();
			return mapping.FromBusinessObject( task ) as TaskData;
		}

		public static TaskCollection FromDataObjectCollection( TaskDataCollection taskDataCollection ) {
			Mapping mapping = new TaskMapping();
			TaskCollection taskCollectionToReturn = new TaskCollection();
			foreach( TaskData taskData in taskDataCollection ) {
				taskCollectionToReturn.Add( FromDataObject( taskData ) );
			}
			return taskCollectionToReturn;
		}

		public static TaskDataCollection FromBusinessObjectCollection( TaskCollection taskCollection ) {
			Mapping mapping = new TaskMapping();
			TaskDataCollection taskDataCollectionToReturn = new TaskDataCollection();
			foreach( Task task in taskCollection ) {
				taskDataCollectionToReturn.Add( FromBusinessObject( task ) );
			}
			return taskDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			TaskData taskData = dataObject as TaskData;
			Task taskToReturn = new Task();
			taskToReturn.SysId = taskData.SysId;
			taskToReturn.RowVersion = taskData.RowVersion;

			TaskDescriptionDataCollection taskDescriptionData =
				new TaskDescriptionBll().GetTaskDescriptionDataBySysId( taskData.TaskDescriptionSysId );
			if( taskDescriptionData.Count == 1 ) {
				taskToReturn.Description = taskDescriptionData[0].Description;
				taskToReturn.Deadline = taskDescriptionData[0].Deadline;
				taskToReturn.Title = taskDescriptionData[0].Title;
				taskToReturn.CreationDate = taskDescriptionData[0].CreationDate;

				taskToReturn.Commissioner =
					new EmployeeBll().GetEmployeeDetail( taskDescriptionData[0].CommissionerEmployeeSysId );
			}

			TaskRunDataCollection taskRunData =
				new TaskRunBll().GetTaskRunDataByTask( taskData.SysId );
			if( taskRunData.Count == 1 ) {
				taskToReturn.TaskRun = new TaskRun();
				taskToReturn.TaskRun.SysId = taskRunData[0].SysId;
				taskToReturn.TaskRun.Finished = taskRunData[0].DateTimeFinished;
				taskToReturn.TaskRun.Remarks = taskRunData[0].Remarks;
				taskToReturn.TaskRun.Mode = taskRunData[0].TaskRunMode;
			}

			return taskToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			Task task = businessObject as Task;
			TaskData taskDataToReturn = new TaskData();
			taskDataToReturn.SysId = task.SysId;
			taskDataToReturn.RowVersion = task.RowVersion;
			return taskDataToReturn;
		}

		#endregion

	}

}
