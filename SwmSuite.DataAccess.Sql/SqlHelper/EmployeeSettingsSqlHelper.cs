using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql.SqlHelper {
	
	public class EmployeeSettingsSqlHelper : SqlHelperBase {

		#region -_ Singleton Pattern _-

		private static EmployeeSettingsSqlHelper _employeeSettingsSqlHelper;

		public static EmployeeSettingsSqlHelper SqlHelper {
			get {
				if( _employeeSettingsSqlHelper == null ) {
					_employeeSettingsSqlHelper = new EmployeeSettingsSqlHelper();
				}
				return _employeeSettingsSqlHelper;
			}
		}

		#endregion

		#region -_ Private Members _-

		private String _dbTableName = "tbl_EmployeeSettings";

		private String _dbColumnLogoutTimeout = "LogoutTimeout";
		private String _dbColumnEmailNotification = "EmailNotification";
		private String _dbColumnEmailAddress = "EmailAddress";
		private String _dbColumnSmtpServer = "SmtpServer";
		private String _dbColumnSmtpPort = "SmtpPort";
		private String _dbColumnSecureConnection = "SecureConnection";
		private String _dbColumnAuthentication = "Authentication";
		private String _dbColumnUsername = "Username";
		private String _dbColumnPassword = "Password";
		private String _dbColumnAutoLogon = "AutoLogon";
		private String _dbColumnAutoLogonHost = "AutoLogonHost";

		private String _dbParameterLogoutTimeout = "@LogoutTimeout";
		private String _dbParameterEmailNotification = "@EmailNotification";
		private String _dbParameterEmailAddress = "@EmailAddress";
		private String _dbParameterSmtpServer = "@SmtpServer";
		private String _dbParameterSmtpPort = "@SmtpPort";
		private String _dbParameterSecureConnection = "@SecureConnection";
		private String _dbParameterAuthentication = "@Authentication";
		private String _dbParameterUsername = "@Username";
		private String _dbParameterPassword = "@Password";
		private String _dbParameterAutoLogon = "@AutoLogon";
		private String _dbParameterAutoLogonHost = "@AutoLogonHost";

		private String _dbParameterEmployeeSysId = "@EmployeeSysId";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the timeout column.
		/// </summary>
		/// <value>Columnname for the timeout column.</value>
		public String DBColumnLogoutTimeout { get { return _dbColumnLogoutTimeout; } }
		/// <summary>
		/// Database columnname for the notification column.
		/// </summary>
		/// <value>Columnname for the notification column.</value>
		public String DBColumnEmailNotification { get { return _dbColumnEmailNotification; } }
		/// <summary>
		/// Database columnname for the address column.
		/// </summary>
		/// <value>Columnname for the address column.</value>
		public String DBColumnEmailAddress { get { return _dbColumnEmailAddress; } }
		/// <summary>
		/// Database columnname for the server column.
		/// </summary>
		/// <value>Columnname for the server column.</value>
		public String DBColumnSmtpServer { get { return _dbColumnSmtpServer; } }
		/// <summary>
		/// Database columnname for the port column.
		/// </summary>
		/// <value>Columnname for the port column.</value>
		public String DBColumnSmtpPort { get { return _dbColumnSmtpPort; } }
		/// <summary>
		/// Database columnname for the connection column.
		/// </summary>
		/// <value>Columnname for the connection column.</value>
		public String DBColumnSecureConnection { get { return _dbColumnSecureConnection; } }
		/// <summary>
		/// Database columnname for the authentication column.
		/// </summary>
		/// <value>Columnname for the authentication column.</value>
		public String DBColumnAuthentication { get { return _dbColumnAuthentication; } }
		/// <summary>
		/// Database columnname for the username column.
		/// </summary>
		/// <value>Columnname for the username column.</value>
		public String DBColumnUsername { get { return _dbColumnUsername; } }
		/// <summary>
		/// Database columnname for the password column.
		/// </summary>
		/// <value>Columnname for the password column.</value>
		public String DBColumnPassword { get { return _dbColumnPassword; } }
		/// <summary>
		/// Database columnname for the logon column.
		/// </summary>
		/// <value>Columnname for the logon column.</value>
		public String DBColumnAutoLogon { get { return _dbColumnAutoLogon; } }
		/// <summary>
		/// Database columnname for the host column.
		/// </summary>
		/// <value>Columnname for the host column.</value>
		public String DBColumnAutoLogonHost { get { return _dbColumnAutoLogonHost; } }

		/// <summary>
		/// Database command parameter for the timeout column.
		/// </summary>
		/// <value>Command parameter for the timeout column.</value>
		public String DBParameterLogoutTimeout { get { return _dbParameterLogoutTimeout; } }
		/// <summary>
		/// Database command parameter for the notification column.
		/// </summary>
		/// <value>Command parameter for the notification column.</value>
		public String DBParameterEmailNotification { get { return _dbParameterEmailNotification; } }
		/// <summary>
		/// Database command parameter for the address column.
		/// </summary>
		/// <value>Command parameter for the address column.</value>
		public String DBParameterEmailAddress { get { return _dbParameterEmailAddress; } }
		/// <summary>
		/// Database command parameter for the server column.
		/// </summary>
		/// <value>Command parameter for the server column.</value>
		public String DBParameterSmtpServer { get { return _dbParameterSmtpServer; } }
		/// <summary>
		/// Database command parameter for the port column.
		/// </summary>
		/// <value>Command parameter for the port column.</value>
		public String DBParameterSmtpPort { get { return _dbParameterSmtpPort; } }
		/// <summary>
		/// Database command parameter for the connection column.
		/// </summary>
		/// <value>Command parameter for the connection column.</value>
		public String DBParameterSecureConnection { get { return _dbParameterSecureConnection; } }
		/// <summary>
		/// Database command parameter for the authentication column.
		/// </summary>
		/// <value>Command parameter for the authentication column.</value>
		public String DBParameterAuthentication { get { return _dbParameterAuthentication; } }
		/// <summary>
		/// Database command parameter for the username column.
		/// </summary>
		/// <value>Command parameter for the username column.</value>
		public String DBParameterUsername { get { return _dbParameterUsername; } }
		/// <summary>
		/// Database command parameter for the password column.
		/// </summary>
		/// <value>Command parameter for the password column.</value>
		public String DBParameterPassword { get { return _dbParameterPassword; } }
		/// <summary>
		/// Database command parameter for the logon column.
		/// </summary>
		/// <value>Command parameter for the logon column.</value>
		public String DBParameterAutoLogon { get { return _dbParameterAutoLogon; } }
		/// <summary>
		/// Database command parameter for the host column.
		/// </summary>
		/// <value>Command parameter for the host column.</value>
		public String DBParameterAutoLogonHost { get { return _dbParameterAutoLogonHost; } }

		/// <summary>
		/// Database command parameter for the employee sysid column.
		/// </summary>
		/// <value>Command parameter for the employee sysid column.</value>
		public String DBParameterEmployeeSysId { get { return _dbParameterEmployeeSysId; } }

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Create an EmployeeSettings datastructure from a given SqlDataReader.
		/// </summary>
		/// <param name="reader">The SqlDataReader to read from.</param>
		/// <returns>An EmployeeSettings datastructure.</returns>
		public EmployeeSettingsData EmployeeSettingsFromReader( SqlDataReader reader ) {
			EmployeeSettingsData employeesettingsToReturn = new EmployeeSettingsData();
			employeesettingsToReturn.SysId = (int)reader[this.DBColumnSysId];
			employeesettingsToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			employeesettingsToReturn.LogoutTimeout = (int)reader[this.DBColumnLogoutTimeout];
			employeesettingsToReturn.EmailNotification = (bool)reader[this.DBColumnEmailNotification];
			if( reader[this.DBColumnEmailAddress] != DBNull.Value ) {
				employeesettingsToReturn.EmailAddress = (string)reader[this.DBColumnEmailAddress];
			} else {
				employeesettingsToReturn.EmailAddress = null;
			}
			if( reader[this.DBColumnSmtpServer] != DBNull.Value ) {
				employeesettingsToReturn.SmtpServer = (string)reader[this.DBColumnSmtpServer];
			} else {
				employeesettingsToReturn.SmtpServer = null;
			}
			if( reader[this.DBColumnSmtpPort] != DBNull.Value ) {
				employeesettingsToReturn.SmtpPort = (int?)reader[this.DBColumnSmtpPort];
			} else {
				employeesettingsToReturn.SmtpPort = null;
			}
			employeesettingsToReturn.SecureConnection = (bool)reader[this.DBColumnSecureConnection];
			employeesettingsToReturn.Authentication = (bool)reader[this.DBColumnAuthentication];
			if( reader[this.DBColumnUsername] != DBNull.Value ) {
				employeesettingsToReturn.Username = (string)reader[this.DBColumnUsername];
			} else {
				employeesettingsToReturn.Username = null;
			}
			if( reader[this.DBColumnPassword] != DBNull.Value ) {
				employeesettingsToReturn.Password = (string)reader[this.DBColumnPassword];
			} else {
				employeesettingsToReturn.Password = null;
			}
			employeesettingsToReturn.AutoLogon = (bool)reader[this.DBColumnAutoLogon];
			if( reader[this.DBColumnAutoLogonHost] != DBNull.Value ) {
				employeesettingsToReturn.AutoLogonHost = (string)reader[this.DBColumnAutoLogonHost];
			} else {
				employeesettingsToReturn.AutoLogonHost = null;
			}
			employeesettingsToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			employeesettingsToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				employeesettingsToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			} else {
				employeesettingsToReturn.EditedBy = Guid.Empty;
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				employeesettingsToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return employeesettingsToReturn;
		}

		#endregion

		#region -_ Public SQL Methods _-

		override public String CreateBaseSelect() {
			String selectCmd = "";
			selectCmd += "SELECT";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnLogoutTimeout + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmailNotification + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmailAddress + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSmtpServer + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSmtpPort + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSecureConnection + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnAuthentication + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnUsername + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnPassword + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnAutoLogon + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnAutoLogonHost + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCmd += " FROM";
			selectCmd += " " + this.DBTableName;
			return selectCmd;
		}

		public String CreateSelectForEmployee() {
			String selectCmd = CreateBaseSelect();
			selectCmd += " INNER JOIN";
			//selectCmd += " " + EmployeeSqlHelper.SqlHelper.DBTableName + " ON " + EmployeeSqlHelper.SqlHelper.DBTableName + "." + EmployeeSqlHelper.SqlHelper.DBColumnSysId + " = " + this.DBParameterEmployeeSysId;
			selectCmd += " " + EmployeeSqlHelper.SqlHelper.DBTableName;
			selectCmd += " ON";
			selectCmd += " " + EmployeeSqlHelper.SqlHelper.DBTableName + "." + EmployeeSqlHelper.SqlHelper.DBColumnApplicationSettingsSysId + " = " + this.DBTableName + "." + this.DBColumnSysId;
			selectCmd += " WHERE";
			selectCmd += " " + EmployeeSqlHelper.SqlHelper.DBTableName + "." + EmployeeSqlHelper.SqlHelper.DBColumnSysId + " = " + this.DBParameterEmployeeSysId;
			return selectCmd;
		}

		public String CreateInsertCommand() {
			String insertCmd = "";
			insertCmd += "INSERT INTO " + this.DBTableName;
			insertCmd += " (" + this.DBColumnLogoutTimeout + " , " + this.DBColumnEmailNotification + " , " + this.DBColumnEmailAddress + " , " + this.DBColumnSmtpServer + " , " + this.DBColumnSmtpPort + " , " + this.DBColumnSecureConnection + " , " + this.DBColumnAuthentication + " , " + this.DBColumnUsername + " , " + this.DBColumnPassword + " , " + this.DBColumnAutoLogon + " , " + this.DBColumnAutoLogonHost + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCmd += " VALUES";
			insertCmd += " (" + this.DBParameterLogoutTimeout + " , " + this.DBParameterEmailNotification + " , " + this.DBParameterEmailAddress + " , " + this.DBParameterSmtpServer + " , " + this.DBParameterSmtpPort + " , " + this.DBParameterSecureConnection + " , " + this.DBParameterAuthentication + " , " + this.DBParameterUsername + " , " + this.DBParameterPassword + " , " + this.DBParameterAutoLogon + " , " + this.DBParameterAutoLogonHost + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCmd += "  " + this.DBColumnLogoutTimeout + " = " + this.DBParameterLogoutTimeout;
			updateCmd += " , " + this.DBColumnEmailNotification + " = " + this.DBParameterEmailNotification;
			updateCmd += " , " + this.DBColumnEmailAddress + " = " + this.DBParameterEmailAddress;
			updateCmd += " , " + this.DBColumnSmtpServer + " = " + this.DBParameterSmtpServer;
			updateCmd += " , " + this.DBColumnSmtpPort + " = " + this.DBParameterSmtpPort;
			updateCmd += " , " + this.DBColumnSecureConnection + " = " + this.DBParameterSecureConnection;
			updateCmd += " , " + this.DBColumnAuthentication + " = " + this.DBParameterAuthentication;
			updateCmd += " , " + this.DBColumnUsername + " = " + this.DBParameterUsername;
			updateCmd += " , " + this.DBColumnPassword + " = " + this.DBParameterPassword;
			updateCmd += " , " + this.DBColumnAutoLogon + " = " + this.DBParameterAutoLogon;
			updateCmd += " , " + this.DBColumnAutoLogonHost + " = " + this.DBParameterAutoLogonHost;
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
