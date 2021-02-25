using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper.Main {

	public class EmployeeAlertSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_EmployeeAlerts";

		private String _dbColumnEmployeeSysId = "EmployeeSysId";
		private String _dbColumnAlertSysId = "AlertSysId";

		private String _dbParameterEmployeeSysId = "@EmployeeSysId";
		private String _dbParameterAlertSysId = "@AlertSysId";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the employee sysid column.
		/// </summary>
		/// <value>Columnname for the employee sysid column.</value>
		public String DBColumnEmployeeSysId { get { return _dbColumnEmployeeSysId; } }
		/// <summary>
		/// Database columnname for the alert sysid column.
		/// </summary>
		/// <value>Columnname for the alert sysid column.</value>
		public String DBColumnAlertSysId { get { return _dbColumnAlertSysId; } }

		/// <summary>
		/// Database command parameter for the employee sysid column.
		/// </summary>
		/// <value>Command parameter for the employee sysid column.</value>
		public String DBParameterEmployeeSysId { get { return _dbParameterEmployeeSysId; } }
		/// <summary>
		/// Database command parameter for the alert sysid column.
		/// </summary>
		/// <value>Command parameter for the alert sysid column.</value>
		public String DBParameterAlertSysId { get { return _dbParameterAlertSysId; } }

		#endregion

		#region -_ Public Methods _-

		public EmployeeAlertData EmployeeAlertFromReader( SqlDataReader reader ) {
			EmployeeAlertData employeealertToReturn = new EmployeeAlertData();
			employeealertToReturn.SysId = (int)reader[this.DBColumnSysId];
			employeealertToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			employeealertToReturn.EmployeeSysId = (int)reader[this.DBColumnEmployeeSysId];
			employeealertToReturn.AlertSysId = (int)reader[this.DBColumnAlertSysId];
			employeealertToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			employeealertToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				employeealertToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				employeealertToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return employeealertToReturn;
		}

		#endregion

		#region -_ Public SQL Methods _-

		/// <summary>
		/// Creates the sql base select command.
		/// </summary>
		/// <returns>
		/// A string representing the command string.
		/// </returns>
		override public String CreateBaseSelect() {
			String selectCommand = "";
			selectCommand += "SELECT";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnAlertSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		public String CreateSelectByAlert() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnAlertSysId + " = " + this.DBParameterAlertSysId + ";";
			return selectCommand;
		}

		public String CreateSelectByEmployee() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId + ";";
			return selectCommand;
		}

		public String CreateSelectByAlertAndEmployee() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnAlertSysId + " = " + this.DBParameterAlertSysId;
			selectCommand += " AND";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId + ";";
			return selectCommand;
		}

		/// <summary>
		/// Creates the sql insert command.
		/// </summary>
		/// <returns>
		/// A string representing the command string.
		/// </returns>
		public String CreateInsertCommand() {
			String insertCommand = "";
			insertCommand += "INSERT INTO " + this.DBTableName;
			insertCommand += " (" + this.DBColumnEmployeeSysId + " , " + this.DBColumnAlertSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterEmployeeSysId + " , " + this.DBParameterAlertSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
			insertCommand += "; ";
			insertCommand += CreateBaseSelect();
			insertCommand += " WHERE";
			insertCommand += " " + this.DBTableName + "." + this.DBColumnSysId + " = SCOPE_IDENTITY()";
			return insertCommand;
		}

		/// <summary>
		/// Creates the sql update command.
		/// </summary>
		/// <returns>
		/// A string representing the command string.
		/// </returns>
		public String CreateUpdateCommand() {
			String updateCommand = "";
			updateCommand += "UPDATE " + this.DBTableName;
			updateCommand += " SET";
			updateCommand += "  " + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
			updateCommand += " , " + this.DBColumnAlertSysId + " = " + this.DBParameterAlertSysId;
			updateCommand += " , " + this.DBColumnEditedBy + " = " + this.DBParameterEditedBy;
			updateCommand += " , " + this.DBColumnEditedOn + " = " + this.DBParameterEditedOn;
			updateCommand += " WHERE " + this.DBColumnSysId + " = " + this.DBParameterSysId;
			updateCommand += " AND " + this.DBColumnRowVersion + " = " + this.DBParameterRowVersion;
			updateCommand += "; ";
			updateCommand += CreateBaseSelect();
			updateCommand += " WHERE";
			updateCommand += " " + this.DBTableName + "." + this.DBColumnSysId + " = " + this.DBParameterSysId;
			return updateCommand;
		}

		#endregion

	}

}
