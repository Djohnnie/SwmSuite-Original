using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using System.Data.SqlClient;
using SwmSuite.Configuration;

namespace SwmSuite.DataAccess.Sql {

	public sealed class ConnectionTestDal : IConnectionTestDal {

		#region -_ Private Members _-

		private ConnectionTestSqlHelper _sqlHelper = new ConnectionTestSqlHelper();

		#endregion

		#region -_ IAddressDal Members _-

		/// <summary>
		/// Check the connection by returing the value in the ConnectionTest table.
		/// </summary>
		/// <returns></returns>
		bool IConnectionTestDal.CheckConnection(){
			bool reportToReturn = false;
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							reportToReturn = _sqlHelper.ReportFromReader( reader );
						}
					}
				}
				conn.Close();
			}
			return reportToReturn;
		}

		#endregion

	}

}