using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {

	public class LoggingFacade : ILoggingFacade {

		/// <summary>
		/// Get all connectionlogs from the database.
		/// </summary>
		/// <returns>A ConnectionLogCollection containing all connection logs.</returns>
		ConnectionLogCollection ILoggingFacade.GetConnectionLogs() {
			return new ConnectionLogBll().GetConnectionLogs();
		}

		/// <summary>
		/// Get all connection logs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the connection logs for.</param>
		/// <param name="month">The month to get the connection logs for.</param>
		/// <returns>A ConnectionLogCollection containing all requested connection logs.</returns>
		ConnectionLogCollection ILoggingFacade.GetConnectionLogsByMonth( int year , int month ) {
			return new ConnectionLogBll().GetConnectionLogsByMonth( year , month );
		}

		/// <summary>
		/// Log the given connectionlog to the database.
		/// </summary>
		/// <param name="connectionLog">The connection log to log.</param>
		void ILoggingFacade.LogConnection( ConnectionLog connectionLog ) {
			new ConnectionLogBll().LogConnection( connectionLog );
		}

		/// <summary>
		/// Get all login logs from the database.
		/// </summary>
		/// <returns>A LoginLogCollection containing all login logs.</returns>
		LoginLogCollection ILoggingFacade.GetLoginLogs() {
			return new LoginLogBll().GetLoginLogs();
		}

		/// <summary>
		/// Get all loginlogs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the loginlogs for.</param>
		/// <param name="month">The month to get the loginlogs for.</param>
		/// <returns>A LoginLogCollection containing all requested login logs.</returns>
		LoginLogCollection ILoggingFacade.GetLoginLogsByMonth( int year , int month ) {
			return new LoginLogBll().GetLoginLogsByMonth( year , month );
		}

		/// <summary>
		/// Log the given login log to the database.
		/// </summary>
		/// <param name="loginLog">The login log to log.</param>
		void ILoggingFacade.LogLogin( LoginLog loginLog ) {
			new LoginLogBll().LogLogin( loginLog );
		}

	}
}
