using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class TaskRunBll {

		#region -_ Private Members _-

		private ITaskRunDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateTaskRunDal();

		#endregion

		#region -_ Business Methods _-

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all taskruns from the database.
		/// </summary>
		/// <returns>An TaskRunCollection containing all taskruns.</returns>
		public TaskRunDataCollection GetTaskRunData() {
			return dal.GetTaskRunData();
		}

		/// <summary>
		/// Get all taskruns from the database for a specific task.
		/// </summary>
		/// <param name="taskSysId">The internal id of the task to get the taskruns for.</param>
		/// <returns>A TaskRunCollection containing the requested taskruns.</returns>
		public TaskRunDataCollection GetTaskRunDataByTask( int taskSysId ) {
			return dal.GetTaskRunDataByTask( taskSysId );
		}

		/// <summary>
		/// Get a single taskrun from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the taskrun to retrieve.</param>
		/// <returns>An TaskRunCollection containing the requested taskrun.</returns>
		public TaskRunDataCollection GetTaskRunDataBySysId( int sysId ) {
			return dal.GetTaskRunDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple taskruns from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the taskruns to retrieve.</param>
		/// <returns>An TaskRunCollection containing the requested taskruns.</returns>
		public TaskRunDataCollection GetTaskRunDataBySysIds( int[] sysIds ) {
			return dal.GetTaskRunDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more taskruns to the database.
		/// </summary>
		/// <param name="taskruns">An TaskRunCollection containing the taskruns to insert.</param>
		/// <returns>An TaskRunCollection containing the inserted taskruns.</returns>
		public TaskRunDataCollection InsertTaskRunData( TaskRunDataCollection taskruns ) {
			return dal.InsertTaskRunData( taskruns );
		}

		/// <summary>
		/// Update one or more taskruns in the database.
		/// </summary>
		/// <param name="taskruns">An TaskRunCollection containing the taskruns to update.</param>
		/// <returns>An TaskRunCollection containing the updated taskruns.</returns>
		public TaskRunDataCollection UpdateTaskRunData( TaskRunDataCollection taskruns ) {
			return dal.UpdateTaskRunData( taskruns );
		}

		/// <summary>
		/// Remove one or more taskruns from the database.
		/// </summary>
		/// <param name="taskruns">An TaskRunCollection containing the taskruns to remove.</param>
		public void RemoveTaskRunData( TaskRunDataCollection taskruns ) {
			dal.RemoveTaskRunData( taskruns );
		}

		/// <summary>
		/// Remove all taskruns from the database.
		/// </summary>
		public void RemoveAllTaskRunData() {
			dal.RemoveAllTaskRunData();
		}

		#endregion

	}


}
