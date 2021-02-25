using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class TaskDescriptionBll {

		#region -_ Private Members _-

		private ITaskDescriptionDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateTaskDescriptionDal();

		#endregion

		#region -_ Business Methods _-

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all taskdescriptions from the database.
		/// </summary>
		/// <returns>An TaskDescriptionCollection containing all taskdescriptions.</returns>
		public TaskDescriptionDataCollection GetTaskDescriptionData() {
			return dal.GetTaskDescriptionData();
		}

		/// <summary>
		/// Get a single taskdescription from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the taskdescription to retrieve.</param>
		/// <returns>An TaskDescriptionCollection containing the requested taskdescription.</returns>
		public TaskDescriptionDataCollection GetTaskDescriptionDataBySysId( int sysId ) {
			return dal.GetTaskDescriptionDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple taskdescriptions from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the taskdescriptions to retrieve.</param>
		/// <returns>An TaskDescriptionCollection containing the requested taskdescriptions.</returns>
		public TaskDescriptionDataCollection GetTaskDescriptionDataBySysIds( int[] sysIds ) {
			return dal.GetTaskDescriptionDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more taskdescriptions to the database.
		/// </summary>
		/// <param name="taskdescriptions">An TaskDescriptionCollection containing the taskdescriptions to insert.</param>
		/// <returns>An TaskDescriptionCollection containing the inserted taskdescriptions.</returns>
		public TaskDescriptionDataCollection InsertTaskDescriptionData( TaskDescriptionDataCollection taskdescriptions ) {
			return dal.InsertTaskDescriptionData( taskdescriptions );
		}

		/// <summary>
		/// Update one or more taskdescriptions in the database.
		/// </summary>
		/// <param name="taskdescriptions">An TaskDescriptionCollection containing the taskdescriptions to update.</param>
		/// <returns>An TaskDescriptionCollection containing the updated taskdescriptions.</returns>
		public TaskDescriptionDataCollection UpdateTaskDescriptionData( TaskDescriptionDataCollection taskdescriptions ) {
			return dal.UpdateTaskDescriptionData( taskdescriptions );
		}

		/// <summary>
		/// Remove one or more taskdescriptions from the database.
		/// </summary>
		/// <param name="taskdescriptions">An TaskDescriptionCollection containing the taskdescriptions to remove.</param>
		public void RemoveTaskDescriptionData( TaskDescriptionDataCollection taskdescriptions ) {
			dal.RemoveTaskDescriptionData( taskdescriptions );
		}

		/// <summary>
		/// Remove all taskdescriptions from the database.
		/// </summary>
		public void RemoveAllTaskDescriptionData() {
			dal.RemoveAllTaskDescriptionData();
		}

		#endregion

	}

}
