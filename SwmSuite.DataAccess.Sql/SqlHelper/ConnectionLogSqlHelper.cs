using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper {

	public class ConnectionLogSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_ConnectionLogs";

		private String _dbColumnDateTime = "DateTime";
		private String _dbColumnClient = "Client";

		private String _dbParameterDateTime = "@DateTime";
		private String _dbParameterClient = "@Client";

		private String _dbParameterYear = "@Year";
		private String _dbParameterMonth = "@Month";

		#endregion

		#region -_ Public Properties _-

		override public String DBTableName { get { return _dbTableName; } }

		public String DBColumnDateTime { get { return _dbColumnDateTime; } }
		public String DBColumnClient { get { return _dbColumnClient; } }

		public String DBParameterDateTime { get { return _dbParameterDateTime; } }
		public String DBParameterClient { get { return _dbParameterClient; } }

		public String DBParameterYear { get { return _dbParameterYear; } }
		public String DBParameterMonth { get { return _dbParameterMonth; } }

		#endregion

		#region -_ Public Methods _-

		public ConnectionLogData ConnectionLogFromReader( SqlDataReader reader ) {
			ConnectionLogData connectionlogToReturn = new ConnectionLogData();
			connectionlogToReturn.SysId = (int)reader[this.DBColumnSysId];
			connectionlogToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			connectionlogToReturn.DateTime = (DateTime)reader[this.DBColumnDateTime];
			connectionlogToReturn.Client = (string)reader[this.DBColumnClient];
			connectionlogToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			connectionlogToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				connectionlogToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			} else {
				connectionlogToReturn.EditedBy = Guid.Empty;
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				connectionlogToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return connectionlogToReturn;
		}

		#endregion

		#region -_ Public SQL Methods _-

		override public String CreateBaseSelect() {
			String selectCmd = "";
			selectCmd += "SELECT";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDateTime + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnClient + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCmd += " FROM";
			selectCmd += " " + this.DBTableName;
			return selectCmd;
		}

		public String CreateSelect() {
			String selectCmd = CreateBaseSelect();
			selectCmd += " ORDER BY";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDateTime + " DESC";
			return selectCmd;
		}

		public String CreateSelectByYearAndMonth() {
			String selectCmd = CreateBaseSelect();
			selectCmd += " WHERE";
			selectCmd += " YEAR( " + this.DBTableName + "." + this.DBColumnDateTime + " ) = " + this.DBParameterYear;
			selectCmd += " AND";
			selectCmd += " MONTH( " + this.DBTableName + "." + this.DBColumnDateTime + " ) = " + this.DBParameterMonth;
			selectCmd += " ORDER BY";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDateTime + " DESC";
			return selectCmd;
		}

		public String CreateInsertCommand() {
			String insertCmd = "";
			insertCmd += "INSERT INTO " + this.DBTableName;
			insertCmd += " (" + this.DBColumnDateTime + " , " + this.DBColumnClient + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCmd += " VALUES";
			insertCmd += " (" + this.DBParameterDateTime + " , " + this.DBParameterClient + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
			insertCmd += "; ";
			insertCmd += CreateBaseSelect();
			insertCmd += " WHERE";
			insertCmd += " " + this.DBTableName + "." + this.DBColumnSysId + " = SCOPE_IDENTITY()";
			return insertCmd;
		}

		public String CreateUpdateCommand() {
			String updateCmd = "";
			updateCmd += "UPDATE " + this.DBTableName;
			updateCmd += " SET";
			updateCmd += "  " + this.DBColumnDateTime + " = " + this.DBParameterDateTime;
			updateCmd += " , " + this.DBColumnClient + " = " + this.DBParameterClient;
			updateCmd += " , " + this.DBColumnEditedBy + " = " + this.DBParameterEditedBy;
			updateCmd += " , " + this.DBColumnEditedOn + " = " + this.DBParameterEditedOn;
			updateCmd += " WHERE " + this.DBColumnSysId + " = " + this.DBParameterSysId;
			updateCmd += " AND " + this.DBColumnRowVersion + " = " + this.DBParameterRowVersion;
			updateCmd += "; ";
			updateCmd += CreateBaseSelect();
			updateCmd += " WHERE";
			updateCmd += " " + this.DBTableName + "." + this.DBColumnSysId + " = " + this.DBParameterSysId;
			return updateCmd;
		}

		#endregion

	}

}
