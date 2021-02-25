using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;

namespace SwmSuite.Business {

	public class ConnectionLogBll {

		#region -_ Private Members _-

		private IConnectionLogDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateConnectionLogDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all connectionlogs from the database.
		/// </summary>
		/// <returns>A ConnectionLogCollection containing all connection logs.</returns>
		public ConnectionLogCollection GetConnectionLogs() {
			return ConnectionLogMapping.FromDataObjectCollection(
				GetConnectionLogData() );
		}

		/// <summary>
		/// Get all connectionlogs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the connection logs for.</param>
		/// <param name="month">The month to get the connection logs for.</param>
		/// <returns>A ConnectionLogCollection containing all requested connection logs.</returns>
		public ConnectionLogCollection GetConnectionLogsByMonth( int year , int month ) {
			return ConnectionLogMapping.FromDataObjectCollection(
				GetConnectionLogDataByMonth( year , month ) );
		}

		/// <summary>
		/// Log the given connectionlog to the database.
		/// </summary>
		/// <param name="connectionLog">The connection log to log.</param>
		public void LogConnection( ConnectionLog connectionLog ) {
			InsertConnectionLogData( ConnectionLogDataCollection.FromSingleConnectionLog(
				ConnectionLogMapping.FromBusinessObject( connectionLog ) ) );
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all connectionlogs from the database.
		/// </summary>
		/// <returns>An ConnectionLogCollection containing all connectionlogs.</returns>
		public ConnectionLogDataCollection GetConnectionLogData() {
			return dal.GetConnectionLogData();
		}

		/// <summary>
		/// Get all connectionlogs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the connectionlogs for.</param>
		/// <param name="month">The month to get the connectionlogs for.</param>
		/// <returns>An LoginLogDataCollection containing all requested connectionlogs.</returns>
		public ConnectionLogDataCollection GetConnectionLogDataByMonth( int year , int month ) {
			return dal.GetConnectionLogDataByMonth( year , month );
		}

		/// <summary>
		/// Get a single connectionlog from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the connectionlog to retrieve.</param>
		/// <returns>An ConnectionLogCollection containing the requested connectionlog.</returns>
		public ConnectionLogDataCollection GetConnectionLogDataBySysId( int sysId ) {
			return dal.GetConnectionLogDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple connectionlogs from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the connectionlogs to retrieve.</param>
		/// <returns>An ConnectionLogCollection containing the requested connectionlogs.</returns>
		public ConnectionLogDataCollection GetConnectionLogDataBySysIds( int[] sysIds ) {
			return dal.GetConnectionLogDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more connectionlogs to the database.
		/// </summary>
		/// <param name="connectionLogData">An ConnectionLogCollection containing the connectionlogs to insert.</param>
		/// <returns>An ConnectionLogCollection containing the inserted connectionlogs.</returns>
		public ConnectionLogDataCollection InsertConnectionLogData( ConnectionLogDataCollection connectionLogData ) {
			return dal.InsertConnectionLogData( connectionLogData );
		}

		/// <summary>
		/// Update one or more connectionlogs in the database.
		/// </summary>
		/// <param name="connectionLogData">An ConnectionLogCollection containing the connectionlogs to update.</param>
		/// <returns>An ConnectionLogCollection containing the updated connectionlogs.</returns>
		public ConnectionLogDataCollection UpdateConnectionLogData( ConnectionLogDataCollection connectionLogData ) {
			return dal.UpdateConnectionLogData( connectionLogData );
		}

		/// <summary>
		/// Remove one or more connectionlogs from the database.
		/// </summary>
		/// <param name="connectionLogData">An ConnectionLogCollection containing the connectionlogs to remove.</param>
		public void RemoveConnectionLogData( ConnectionLogDataCollection connectionLogData ) {
			dal.RemoveConnectionLogData( connectionLogData );
		}

		/// <summary>
		/// Remove all connectionlogs from the database.
		/// </summary>
		public void RemoveAllConnectionLogData() {
			dal.RemoveAllConnectionLogData();
		}

		#endregion

	}

}
