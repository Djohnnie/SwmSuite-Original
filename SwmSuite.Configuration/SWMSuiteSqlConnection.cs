using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using SwmSuite.Framework.Application;

namespace SwmSuite.Configuration {
	public static class SwmSuiteSqlConnection {

		public static SqlConnection CreateConnection() {
			if( SwmSuiteSettings.ConnectionSettings != null ) {
				return new SqlConnection( SwmSuiteSettings.ConnectionSettings.ConnectionString );
			} else {
				return new SqlConnection( ConfigUtil.GetConfigString( ConfigUtil.ConnectionString ) );
			}
		}

	}
}
