using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;

namespace SwmSuite.Business {

	public class LoginLogBll {

		#region -_ Private Members _-

		private ILoginLogDataDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateLoginLogDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all login logs from the database.
		/// </summary>
		/// <returns>A LoginLogCollection containing all login logs.</returns>
		public LoginLogCollection GetLoginLogs() {
			return LoginLogMapping.FromDataObjectCollection(
				GetLoginLogData() );
		}

		/// <summary>
		///  Get all loginlogdata from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the loginlogs for.</param>
		/// <param name="month">The month to get the loginlogs for.</param>
		/// <returns>A LoginLogCollection containing all requested login logs.</returns>
		public LoginLogCollection GetLoginLogsByMonth( int year , int month ) {
			return LoginLogMapping.FromDataObjectCollection(
				GetLoginLogDataByMonth( year , month ) );
		}

		/// <summary>
		/// Log the given login log to the database.
		/// </summary>
		/// <param name="loginLog">The login log to log.</param>
		public void LogLogin( LoginLog loginLog ) {
			InsertLoginLogData( LoginLogDataCollection.FromSingleLoginLog(
					LoginLogMapping.FromBusinessObject( loginLog ) ) );
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all loginlogdata from the database.
		/// </summary>
		/// <returns>An LoginLogDataCollection containing all loginlogdata.</returns>
		public LoginLogDataCollection GetLoginLogData() {
			return dal.GetLoginLogData();
		}

		/// <summary>
		/// Get all loginlogdata from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the loginlogs for.</param>
		/// <param name="month">The month to get the loginlogs for.</param>
		/// <returns>An LoginLogDataCollection containing all requested loginlogdata.</returns>
		public LoginLogDataCollection GetLoginLogDataByMonth( int year , int month ) {
			return dal.GetLoginLogDataByMonth( year , month );
		}

		/// <summary>
		/// Get a single loginlogdata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the loginlogdata to retrieve.</param>
		/// <returns>An LoginLogDataCollection containing the requested loginlogdata.</returns>
		public LoginLogDataCollection GetLoginLogDataBySysId( int sysId ) {
			return dal.GetLoginLogDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple loginlogdata from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the loginlogdata to retrieve.</param>
		/// <returns>An LoginLogDataCollection containing the requested loginlogdata.</returns>
		public LoginLogDataCollection GetLoginLogDataBySysIds( int[] sysIds ) {
			return dal.GetLoginLogDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more loginlogdata to the database.
		/// </summary>
		/// <param name="loginlogdata">An LoginLogDataCollection containing the loginlogdata to insert.</param>
		/// <returns>An LoginLogDataCollection containing the inserted loginlogdata.</returns>
		public LoginLogDataCollection InsertLoginLogData( LoginLogDataCollection loginlogdata ) {
			return dal.InsertLoginLogData( loginlogdata );
		}

		/// <summary>
		/// Update one or more loginlogdata in the database.
		/// </summary>
		/// <param name="loginlogdata">An LoginLogDataCollection containing the loginlogdata to update.</param>
		/// <returns>An LoginLogDataCollection containing the updated loginlogdata.</returns>
		public LoginLogDataCollection UpdateLoginLogData( LoginLogDataCollection loginlogdata ) {
			return dal.UpdateLoginLogData( loginlogdata );
		}

		/// <summary>
		/// Remove one or more loginlogdata from the database.
		/// </summary>
		/// <param name="loginlogdata">An LoginLogDataCollection containing the loginlogdata to remove.</param>
		public void RemoveLoginLogData( LoginLogDataCollection loginlogdata ) {
			dal.RemoveLoginLogData( loginlogdata );
		}

		/// <summary>
		/// Remove all loginlogdata from the database.
		/// </summary>
		public void RemoveAllLoginLogData() {
			dal.RemoveAllLoginLogData();
		}

		#endregion

	}

}
