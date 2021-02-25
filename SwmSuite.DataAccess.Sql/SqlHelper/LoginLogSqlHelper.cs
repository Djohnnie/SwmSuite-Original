using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper {

	public class LoginLogSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_LoginLogs";

		private String _dbColumnDateTime = "DateTime";
		private String _dbColumnEmployeeSysId = "EmployeeSysId";

		private String _dbParameterDateTime = "@DateTime";
		private String _dbParameterEmployeeSysId = "@EmployeeSysId";

		private String _dbParameterYear = "@Year";
		private String _dbParameterMonth = "@Month";

		#endregion

		#region -_ Public Properties _-

		override public String DBTableName { get { return _dbTableName; } }

		public String DBColumnDateTime { get { return _dbColumnDateTime; } }
		public String DBColumnEmployeeSysId { get { return _dbColumnEmployeeSysId; } }

		public String DBParameterDateTime { get { return _dbParameterDateTime; } }
		public String DBParameterEmployeeSysId { get { return _dbParameterEmployeeSysId; } }

		public String DBParameterYear { get { return _dbParameterYear; } }
		public String DBParameterMonth { get { return _dbParameterMonth; } }

		#endregion

		#region -_ Public Methods _-

		public LoginLogData LoginLogDataFromReader( SqlDataReader reader ) {
			LoginLogData loginlogdataToReturn = new LoginLogData();
			loginlogdataToReturn.SysId = (int)reader[this.DBColumnSysId];
			loginlogdataToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			loginlogdataToReturn.DateTime = (DateTime)reader[this.DBColumnDateTime];
			loginlogdataToReturn.EmployeeSysId = (int)reader[this.DBColumnEmployeeSysId];
			loginlogdataToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			loginlogdataToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				loginlogdataToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			} else {
				loginlogdataToReturn.EditedBy = Guid.Empty;
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				loginlogdataToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return loginlogdataToReturn;
		}

		#endregion

		#region -_ Public SQL Methods _-

		override public String CreateBaseSelect() {
			String selectCmd = "";
			selectCmd += "SELECT";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDateTime + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + ",";
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
			insertCmd += " (" + this.DBColumnDateTime + " , " + this.DBColumnEmployeeSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCmd += " VALUES";
			insertCmd += " (" + this.DBParameterDateTime + " , " + this.DBParameterEmployeeSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCmd += " , " + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
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
