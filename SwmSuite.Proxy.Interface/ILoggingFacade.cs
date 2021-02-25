using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Proxy.Interface {
	
	public interface ILoggingFacade {

		/// <summary>
		/// Get all connectionlogs from the database.
		/// </summary>
		/// <returns>A ConnectionLogCollection containing all connection logs.</returns>
		ConnectionLogCollection GetConnectionLogs();

		/// <summary>
		/// Get all connection logs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the connection logs for.</param>
		/// <param name="month">The month to get the connection logs for.</param>
		/// <returns>A ConnectionLogCollection containing all requested connection logs.</returns>
		ConnectionLogCollection GetConnectionLogsByMonth( int year , int month );

		/// <summary>
		/// Log the given connectionlog to the database.
		/// </summary>
		/// <param name="connectionLog">The connection log to log.</param>
		void LogConnection( ConnectionLog connectionLog );

		/// <summary>
		/// Get all login logs from the database.
		/// </summary>
		/// <returns>A LoginLogCollection containing all login logs.</returns>
		LoginLogCollection GetLoginLogs();

		/// <summary>
		/// Get all loginlogs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the loginlogs for.</param>
		/// <param name="month">The month to get the loginlogs for.</param>
		/// <returns>A LoginLogCollection containing all requested login logs.</returns>
		LoginLogCollection GetLoginLogsByMonth( int year , int month );

		/// <summary>
		/// Log the given login log to the database.
		/// </summary>
		/// <param name="loginLog">The login log to log.</param>
		void LogLogin( LoginLog loginLog );

	}

}
