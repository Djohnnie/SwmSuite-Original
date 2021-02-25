using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the LogDelete methods.
	/// </summary>
	public interface ILogDeleteDal {

		/// <summary>
		/// Get all logdeletes from the database.
		/// </summary>
		/// <returns>A LogDeleteCollection containing all logdeletes.</returns>
		LogDeleteDataCollection GetLogDeleteData();

		/// <summary>
		/// Get a single logdelete from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the logdelete to retrieve.</param>
		/// <returns>A LogDeleteCollection containing the requested logdelete.</returns>
		LogDeleteDataCollection GetLogDeleteDataBySysId( int sysId );

		/// <summary>
		/// Get multiple logdeletes from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the logdeletes to retrieve.</param>
		/// <returns>A LogDeleteCollection containing the requested logdeletes.</returns>
		LogDeleteDataCollection GetLogDeleteDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more logdeletes to the database.
		/// </summary>
		/// <param name="logDeletes">A LogDeleteCollection containing the logdeletes to insert.</param>
		void InsertLogDeleteData( LogDeleteDataCollection logDeletes );

		/// <summary>
		/// Update one or more logdeletes in the database.
		/// </summary>
		/// <param name="logDeletes">A LogDeleteCollection containing the logdeletes to update.</param>
		void UpdateLogDeleteData( LogDeleteDataCollection logDeletes );

		/// <summary>
		/// Remove one or more logdeletes from the database.
		/// </summary>
		/// <param name="logDeletes">A LogDeleteCollection containing the logdeletes to remove.</param>
		void RemoveLogDeleteData( LogDeleteDataCollection logDeletes );

		/// <summary>
		/// Remove one or more logdeletes from the database.
		/// </summary>
		void RemoveAllLogDeleteData();

	}

}
