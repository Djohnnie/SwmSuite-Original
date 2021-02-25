using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the ConnectionLogService methods.
	/// </summary>
	public interface IConnectionLogDal {

		/// <summary>
		/// Get all connectionlogs from the database.
		/// </summary>
		/// <returns>A ConnectionLogCollection containing all connectionlogs.</returns>
		ConnectionLogDataCollection GetConnectionLogData();

		/// <summary>
		/// Get all connectionlogs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the connectionlogs for.</param>
		/// <param name="month">The month to get the connectionlogs for.</param>
		/// <returns>An LoginLogDataCollection containing all requested connectionlogs.</returns>
		ConnectionLogDataCollection GetConnectionLogDataByMonth( int year , int month );

		/// <summary>
		/// Get a single connectionlog from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the connectionlog to retrieve.</param>
		/// <returns>An ConnectionLogCollection containing the requested connectionlog.</returns>
		ConnectionLogDataCollection GetConnectionLogDataBySysId( int sysId );

		/// <summary>
		/// Get multiple connectionlogs from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the connectionlogs to retrieve.</param>
		/// <returns>An ConnectionLogCollection containing the requested connectionlogs.</returns>
		ConnectionLogDataCollection GetConnectionLogDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more connectionlogs to the database.
		/// </summary>
		/// <param name="connectionLogData">An ConnectionLogCollection containing the connectionlogs to insert.</param>
		/// <returns>An ConnectionLogCollection containing the inserted connectionlogs.</returns>
		ConnectionLogDataCollection InsertConnectionLogData( ConnectionLogDataCollection connectionLogData );

		/// <summary>
		/// Update one or more connectionlogs in the database.
		/// </summary>
		/// <param name="connectionLogData">An ConnectionLogCollection containing the connectionlogs to update.</param>
		/// <returns>An ConnectionLogCollection containing the updated connectionlogs.</returns>
		ConnectionLogDataCollection UpdateConnectionLogData( ConnectionLogDataCollection connectionLogData );

		/// <summary>
		/// Remove one or more connectionlogs from the database.
		/// </summary>
		/// <param name="connectionLogData">An ConnectionLogCollection containing the connectionlogs to remove.</param>
		void RemoveConnectionLogData( ConnectionLogDataCollection connectionLogData );

		/// <summary>
		/// Remove all connectionlogs from the database.
		/// </summary>
		void RemoveAllConnectionLogData();

	}

}
