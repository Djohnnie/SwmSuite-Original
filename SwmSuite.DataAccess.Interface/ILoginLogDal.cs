using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the LoginLogDataService methods.
	/// </summary>
	public interface ILoginLogDataDal {

		/// <summary>
		/// Get all loginlogdata from the database.
		/// </summary>
		/// <returns>A LoginLogDataCollection containing all loginlogdata.</returns>
		LoginLogDataCollection GetLoginLogData();

		/// <summary>
		/// Get all loginlogdata from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the loginlogs for.</param>
		/// <param name="month">The month to get the loginlogs for.</param>
		/// <returns>An LoginLogDataCollection containing all requested loginlogdata.</returns>
		LoginLogDataCollection GetLoginLogDataByMonth( int year , int month );

		/// <summary>
		/// Get a single loginlogdata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the loginlogdata to retrieve.</param>
		/// <returns>An LoginLogDataCollection containing the requested loginlogdata.</returns>
		LoginLogDataCollection GetLoginLogDataBySysId( int sysId );

		/// <summary>
		/// Get multiple loginlogdata from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the loginlogdata to retrieve.</param>
		/// <returns>An LoginLogDataCollection containing the requested loginlogdata.</returns>
		LoginLogDataCollection GetLoginLogDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more loginlogdata to the database.
		/// </summary>
		/// <param name="loginlogdata">An LoginLogDataCollection containing the loginlogdata to insert.</param>
		/// <returns>An LoginLogDataCollection containing the inserted loginlogdata.</returns>
		LoginLogDataCollection InsertLoginLogData( LoginLogDataCollection loginlogdata );

		/// <summary>
		/// Update one or more loginlogdata in the database.
		/// </summary>
		/// <param name="loginlogdata">An LoginLogDataCollection containing the loginlogdata to update.</param>
		/// <returns>An LoginLogDataCollection containing the updated loginlogdata.</returns>
		LoginLogDataCollection UpdateLoginLogData( LoginLogDataCollection loginlogdata );

		/// <summary>
		/// Remove one or more loginlogdata from the database.
		/// </summary>
		/// <param name="loginlogdata">An LoginLogDataCollection containing the loginlogdata to remove.</param>
		void RemoveLoginLogData( LoginLogDataCollection loginlogdata );

		/// <summary>
		/// Remove all loginlogdata from the database.
		/// </summary>
		void RemoveAllLoginLogData();

	}

}
