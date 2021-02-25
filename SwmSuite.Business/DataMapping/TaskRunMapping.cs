using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class TaskRunMapping : Mapping {

		public static TaskRun FromDataObject( TaskRunData taskRunData ) {
			Mapping mapping = new TaskRunMapping();
			return mapping.FromDataObject( taskRunData ) as TaskRun;
		}

		public static TaskRunData FromBusinessObject( TaskRun taskRun ) {
			Mapping mapping = new TaskRunMapping();
			return mapping.FromBusinessObject( taskRun ) as TaskRunData;
		}

		public static TaskRunCollection FromDataObjectCollection( TaskRunDataCollection taskRunDataCollection ) {
			Mapping mapping = new TaskRunMapping();
			TaskRunCollection taskCollectionToReturn = new TaskRunCollection();
			foreach( TaskRunData taskRunData in taskRunDataCollection ) {
				taskCollectionToReturn.Add( FromDataObject( taskRunData ) );
			}
			return taskCollectionToReturn;
		}

		public static TaskRunDataCollection FromBusinessObjectCollection( TaskRunCollection taskRunCollection ) {
			Mapping mapping = new TaskRunMapping();
			TaskRunDataCollection taskDataCollectionToReturn = new TaskRunDataCollection();
			foreach( TaskRun taskRun in taskRunCollection ) {
				taskDataCollectionToReturn.Add( FromBusinessObject( taskRun ) );
			}
			return taskDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			TaskRunData taskRunData = dataObject as TaskRunData;
			TaskRun taskRunToReturn = new TaskRun();
			taskRunToReturn.SysId = taskRunData.SysId;
			taskRunToReturn.RowVersion = taskRunData.RowVersion;
			taskRunToReturn.Finished = taskRunData.DateTimeFinished;
			taskRunToReturn.Mode = taskRunData.TaskRunMode;
			taskRunToReturn.Remarks = taskRunData.Remarks;
			return taskRunToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			TaskRun taskRun = businessObject as TaskRun;
			TaskRunData taskRunDataToReturn = new TaskRunData();
			taskRunDataToReturn.SysId = taskRun.SysId;
			taskRunDataToReturn.RowVersion = taskRun.RowVersion;
			taskRunDataToReturn.DateTimeFinished = taskRun.Finished;
			taskRunDataToReturn.TaskRunMode = taskRun.Mode;
			taskRunDataToReturn.TaskSysId = taskRun.Task.SysId;
			taskRunDataToReturn.Remarks = taskRun.Remarks;
			return taskRunDataToReturn;
		}

		#endregion

	}

}
