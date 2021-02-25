using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper.Main {
	
	public class ConnectionTestSqlHelper {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_ConnectionTest";

		private String _dbColumnReport = "Report";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the report column.
		/// </summary>
		/// <value>Columnname for the report column.</value>
		public String DBColumnReport { get { return _dbColumnReport; } }

		#endregion

		#region -_ Public Methods _-

		public bool ReportFromReader( SqlDataReader reader ) {
			return (bool)reader[this.DBColumnReport];
		}

		#endregion

		#region -_ Public SQL Methods _-

		/// <summary>
		/// Creates the sql base select command.
		/// </summary>
		/// <returns>
		/// A string representing the command string.
		/// </returns>
		public String CreateBaseSelect() {
			String selectCommand = "";
			selectCommand += "SELECT";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnReport;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		#endregion

	}

}
