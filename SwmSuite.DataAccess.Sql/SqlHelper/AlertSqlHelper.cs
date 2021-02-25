using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql.SqlHelper.Main {

	public class AlertSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private EmployeeAlertSqlHelper _employeeAlertSqlHelper = new EmployeeAlertSqlHelper();
		private EmployeeGroupAlertSqlHelper _employeeGroupAlertSqlHelper = new EmployeeGroupAlertSqlHelper();

		private String _dbTableName = "tbl_Alerts";

		private String _dbColumnVisible = "Visible";
		private String _dbColumnMessage = "Message";

		private String _dbParameterVisible = "@Visible";
		private String _dbParameterMessage = "@Message";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the visible column.
		/// </summary>
		/// <value>Columnname for the visible column.</value>
		public String DBColumnVisible { get { return _dbColumnVisible; } }
		/// <summary>
		/// Database columnname for the message column.
		/// </summary>
		/// <value>Columnname for the message column.</value>
		public String DBColumnMessage { get { return _dbColumnMessage; } }

		/// <summary>
		/// Database command parameter for the visible column.
		/// </summary>
		/// <value>Command parameter for the visible column.</value>
		public String DBParameterVisible { get { return _dbParameterVisible; } }
		/// <summary>
		/// Database command parameter for the message column.
		/// </summary>
		/// <value>Command parameter for the message column.</value>
		public String DBParameterMessage { get { return _dbParameterMessage; } }

		#endregion

		#region -_ Public Methods _-

		public AlertData AlertFromReader( SqlDataReader reader ) {
			AlertData alertToReturn = new AlertData();
			alertToReturn.SysId = (int)reader[this.DBColumnSysId];
			alertToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			alertToReturn.Visible = (bool)reader[this.DBColumnVisible];
			alertToReturn.Message = (string)reader[this.DBColumnMessage];
			alertToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			alertToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				alertToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				alertToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return alertToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnVisible + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnMessage + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		public String CreateSelectForGlobalAlerts() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE (";
			selectCommand += " SELECT COUNT ( " + _employeeAlertSqlHelper.DBTableName + "." + _employeeAlertSqlHelper.DBColumnSysId + " )";
			selectCommand += " FROM " + _employeeAlertSqlHelper.DBTableName;
			selectCommand += " WHERE";
			selectCommand += " " + _employeeAlertSqlHelper.DBTableName + "." + _employeeAlertSqlHelper.DBColumnAlertSysId + " = " + this.DBTableName + "." + this.DBColumnSysId + " ) = 0";
			selectCommand += " AND ( ";
			selectCommand += " SELECT COUNT ( " + _employeeGroupAlertSqlHelper.DBTableName + "." + _employeeGroupAlertSqlHelper.DBColumnSysId + " )";
			selectCommand += " FROM " + _employeeGroupAlertSqlHelper.DBTableName;
			selectCommand += " WHERE";
			selectCommand += " " + _employeeGroupAlertSqlHelper.DBTableName + "." + _employeeGroupAlertSqlHelper.DBColumnAlertSysId + " = " + this.DBTableName + "." + this.DBColumnSysId + " ) = 0";
			return selectCommand;
		}

		public String CreateSelectByEmployee() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " LEFT OUTER JOIN";
			selectCommand += " " + _employeeAlertSqlHelper.DBTableName;
			selectCommand += " ON";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSysId + " = " + _employeeAlertSqlHelper.DBTableName + "." + _employeeAlertSqlHelper.DBColumnAlertSysId;
			selectCommand += " WHERE";
			selectCommand += " " + _employeeAlertSqlHelper.DBTableName + "." + _employeeAlertSqlHelper.DBColumnEmployeeSysId + " = " + _employeeAlertSqlHelper.DBParameterEmployeeSysId + ";";
			return selectCommand;
		}

		public String CreateSelectByEmployeeGroup() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " LEFT OUTER JOIN";
			selectCommand += " " + _employeeGroupAlertSqlHelper.DBTableName;
			selectCommand += " ON";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSysId + " = " + _employeeGroupAlertSqlHelper.DBTableName + "." + _employeeGroupAlertSqlHelper.DBColumnAlertSysId;
			selectCommand += " WHERE";
			selectCommand += " " + _employeeGroupAlertSqlHelper.DBTableName + "." + _employeeGroupAlertSqlHelper.DBColumnEmployeeGroupSysId + " = " + _employeeGroupAlertSqlHelper.DBParameterEmployeeGroupSysId + ";";
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
			insertCommand += " (" + this.DBColumnVisible + " , " + this.DBColumnMessage + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterVisible + " , " + this.DBParameterMessage + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += " " + this.DBColumnVisible + " = " + this.DBParameterVisible;
			updateCommand += " , " + this.DBColumnMessage + " = " + this.DBParameterMessage;
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
