using System;
using System.Collections.Generic;

using System.Text;

using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {
	
	public class LogDeleteBll {

		#region -_ Private Members _-

		private ILogDeleteDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateLogDeleteDal();

		#endregion

		#region -_ Crud Methods _-

		/// <summary>
		/// Get all logDeletes from the database.
		/// </summary>
		/// <returns>An LogDeleteCollection containing all logDeletes.</returns>
		public LogDeleteDataCollection GetLogDeleteData() {
			return dal.GetLogDeleteData();
		}

		/// <summary>
		/// Get a single logDelete from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the logDelete to retrieve.</param>
		/// <returns>An LogDeleteCollection containing the requested logDelete.</returns>
		public LogDeleteDataCollection GetLogDeleteDataBySysId( int sysId ) {
			return dal.GetLogDeleteDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple logDeletes from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the logDeletes to retrieve.</param>
		/// <returns>An LogDeleteCollection containing the requested logDeletes.</returns>
		public LogDeleteDataCollection GetLogDeleteDataBySysIds( int[] sysIds ) {
			return dal.GetLogDeleteDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more logDeletes to the database.
		/// </summary>
		/// <param name="logDeletes">An LogDeleteCollection containing the logDeletes to insert.</param>
		public void InsertLogDeleteData( LogDeleteDataCollection logDeletes ) {
			dal.InsertLogDeleteData( logDeletes );
		}

		/// <summary>
		/// Update one or more logDeletes in the database.
		/// </summary>
		/// <param name="logDeletes">An LogDeleteCollection containing the logDeletes to update.</param>
		public void UpdateLogDeleteData( LogDeleteDataCollection logDeletes ) {
			dal.UpdateLogDeleteData( logDeletes );
		}

		/// <summary>
		/// Remove one or more logDeletes from the database.
		/// </summary>
		/// <param name="logDeletes">An LogDeleteCollection containing the logDeletes to remove.</param>
		public void RemoveLogDeleteData( LogDeleteDataCollection logDeletes ) {
			dal.RemoveLogDeleteData( logDeletes );
		}

		/// <summary>
		/// Remove all logDeletes from the database.
		/// </summary>
		public void RemoveAllLogDeleteData() {
			dal.RemoveAllLogDeleteData( );
		}

		#endregion

	}

}
