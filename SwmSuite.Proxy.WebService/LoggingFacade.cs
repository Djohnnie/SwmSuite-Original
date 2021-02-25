using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public sealed class LoggingFacade :
		ServiceFacade<LoggingService.LoggingService , LoggingService.SwmSuiteSoapHeader> ,
		ILoggingFacade {

		/// <summary>
		/// Get all connectionlogs from the database.
		/// </summary>
		/// <returns>A ConnectionLogCollection containing all connection logs.</returns>
		ConnectionLogCollection ILoggingFacade.GetConnectionLogs() {
			try {
				ConnectionLogCollection connectionLogs = new ConnectionLogCollection();
				foreach( LoggingService.ConnectionLog connectionLog in GetService().GetConnectionLogs() ) {
					connectionLogs.Add( (ConnectionLog)XmlSerialization.ConvertObject( connectionLog , typeof( LoggingService.ConnectionLog ) , typeof( ConnectionLog ) ) );
				}
				return connectionLogs;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all connection logs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the connection logs for.</param>
		/// <param name="month">The month to get the connection logs for.</param>
		/// <returns>A ConnectionLogCollection containing all requested connection logs.</returns>
		ConnectionLogCollection ILoggingFacade.GetConnectionLogsByMonth( int year , int month ) {
			try {
				ConnectionLogCollection connectionLogs = new ConnectionLogCollection();
				foreach( LoggingService.ConnectionLog connectionLog in GetService().GetConnectionLogsByMonth( year , month ) ) {
					connectionLogs.Add( (ConnectionLog)XmlSerialization.ConvertObject( connectionLog , typeof( LoggingService.ConnectionLog ) , typeof( ConnectionLog ) ) );
				}
				return connectionLogs;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Log the given connectionlog to the database.
		/// </summary>
		/// <param name="connectionLog">The connection log to log.</param>
		void ILoggingFacade.LogConnection( ConnectionLog connectionLog ) {
			try {
				LoggingService.ConnectionLog connectionLogParameter =
				(LoggingService.ConnectionLog)XmlSerialization.ConvertObject( connectionLog , typeof( ConnectionLog ) , typeof( LoggingService.ConnectionLog ) );
				GetService().LogConnection( connectionLogParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all login logs from the database.
		/// </summary>
		/// <returns>A LoginLogCollection containing all login logs.</returns>
		LoginLogCollection ILoggingFacade.GetLoginLogs() {
			try {
				LoginLogCollection loginLogs = new LoginLogCollection();
				foreach( LoggingService.LoginLog loginLog in GetService().GetLoginLogs() ) {
					loginLogs.Add( (LoginLog)XmlSerialization.ConvertObject( loginLog , typeof( LoggingService.LoginLog ) , typeof( LoginLog ) ) );
				}
				return loginLogs;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all loginlogs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the loginlogs for.</param>
		/// <param name="month">The month to get the loginlogs for.</param>
		/// <returns>A LoginLogCollection containing all requested login logs.</returns>
		LoginLogCollection ILoggingFacade.GetLoginLogsByMonth( int year , int month ) {
			try {
				LoginLogCollection loginLogs = new LoginLogCollection();
				foreach( LoggingService.LoginLog loginLog in GetService().GetLoginLogsByMonth( year , month ) ) {
					loginLogs.Add( (LoginLog)XmlSerialization.ConvertObject( loginLog , typeof( LoggingService.LoginLog ) , typeof( LoginLog ) ) );
				}
				return loginLogs;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Log the given login log to the database.
		/// </summary>
		/// <param name="loginLog">The login log to log.</param>
		void ILoggingFacade.LogLogin( LoginLog loginLog ) {
			try {
				LoggingService.LoginLog loginLogParameter =
				(LoggingService.LoginLog)XmlSerialization.ConvertObject( loginLog , typeof( LoginLog ) , typeof( LoggingService.LoginLog ) );
				GetService().LogLogin( loginLogParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

	}
}
