using System;
using System.Collections.Generic;

using System.Text;

using System.Data.SqlClient;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql.SqlHelper {

	public class EmployeeSqlHelper : SqlHelperBase {

		#region -_ Singleton Pattern _-

		private static EmployeeSqlHelper _employeeSqlHelper;

		/// <summary>
		/// Gets the SQL helper.
		/// </summary>
		/// <value>The SQL helper.</value>
		public static EmployeeSqlHelper SqlHelper {
			get {
				if( _employeeSqlHelper == null ) {
					_employeeSqlHelper = new EmployeeSqlHelper();
				}
				return _employeeSqlHelper;
			}
		}

		#endregion

		#region -_ Private Members _-

		private String _dbTableName = "tbl_Employees";

		private String _dbColumnUserSysId = "UserSysId";
		private String _dbColumnName = "Name";
		private String _dbColumnFirstName = "FirstName";
		private String _dbColumnZipCodeSysId = "ZipCodeSysId";
		private String _dbColumnAddress = "Address";
		private String _dbColumnPrivatePhoneNumber = "PrivatePhoneNumber";
		private String _dbColumnWorkPhoneNumber = "WorkPhoneNumber";
		private String _dbColumnCellPhoneNumber = "CellPhoneNumber";
		private String _dbColumnEmailAddress1 = "EmailAddress1";
		private String _dbColumnEmailAddress2 = "EmailAddress2";
		private String _dbColumnEmailAddress3 = "EmailAddress3";
		private String _dbColumnEmailAddress4 = "EmailAddress4";
		private String _dbColumnEmailAddress5 = "EmailAddress5";
		private String _dbColumnAvatarSysId = "AvatarSysId";
		private String _dbColumnApplicationSettingsSysId = "ApplicationSettingsSysId";
		private String _dbColumnEmployeeGroupSysId = "EmployeeGroupSysId";
		private String _dbColumnAdministrator = "Administrator";

		private String _dbParameterUserSysId = "@UserSysId";
		private String _dbParameterName = "@Name";
		private String _dbParameterFirstName = "@FirstName";
		private String _dbParameterZipCodeSysId = "@ZipCodeSysId";
		private String _dbParameterAddress = "@Address";
		private String _dbParameterPrivatePhoneNumber = "@PrivatePhoneNumber";
		private String _dbParameterWorkPhoneNumber = "@WorkPhoneNumber";
		private String _dbParameterCellPhoneNumber = "@CellPhoneNumber";
		private String _dbParameterEmailAddress1 = "@EmailAddress1";
		private String _dbParameterEmailAddress2 = "@EmailAddress2";
		private String _dbParameterEmailAddress3 = "@EmailAddress3";
		private String _dbParameterEmailAddress4 = "@EmailAddress4";
		private String _dbParameterEmailAddress5 = "@EmailAddress5";
		private String _dbParameterAvatarSysId = "@AvatarSysId";
		private String _dbParameterApplicationSettingsSysId = "@ApplicationSettingsSysId";
		private String _dbParameterEmployeeGroupSysId = "@EmployeeGroupSysId";
		private String _dbParameterAdministrator = "@Administrator";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the user sysid column.
		/// </summary>
		/// <value>Columnname for the user sysid column.</value>
		public String DBColumnUserSysId { get { return _dbColumnUserSysId; } }
		/// <summary>
		/// Database columnname for the name column.
		/// </summary>
		/// <value>Columnname for the name column.</value>
		public String DBColumnName { get { return _dbColumnName; } }
		/// <summary>
		/// Database columnname for the firstname column.
		/// </summary>
		/// <value>Columnname for the firstname column.</value>
		public String DBColumnFirstName { get { return _dbColumnFirstName; } }
		/// <summary>
		/// Database columnname for the zipcode sysid column.
		/// </summary>
		/// <value>Columnname for the zipcode sysid column.</value>
		public String DBColumnZipCodeSysId { get { return _dbColumnZipCodeSysId; } }
		/// <summary>
		/// Database columnname for the address column.
		/// </summary>
		/// <value>Columnname for the address column.</value>
		public String DBColumnAddress { get { return _dbColumnAddress; } }
		/// <summary>
		/// Database columnname for the private phone number column.
		/// </summary>
		/// <value>Columnname for the private phone number column.</value>
		public String DBColumnPrivatePhoneNumber { get { return _dbColumnPrivatePhoneNumber; } }
		/// <summary>
		/// Database columnname for the work phone number column.
		/// </summary>
		/// <value>Columnname for the work phone number column.</value>
		public String DBColumnWorkPhoneNumber { get { return _dbColumnWorkPhoneNumber; } }
		/// <summary>
		/// Database columnname for the cell phone number column.
		/// </summary>
		/// <value>Columnname for the cell phone number column.</value>
		public String DBColumnCellPhoneNumber { get { return _dbColumnCellPhoneNumber; } }
		/// <summary>
		/// Database columnname for the emailaddress1 column.
		/// </summary>
		/// <value>Columnname for the emailaddress1 column.</value>
		public String DBColumnEmailAddress1 { get { return _dbColumnEmailAddress1; } }
		/// <summary>
		/// Database columnname for the emailaddress2 column.
		/// </summary>
		/// <value>Columnname for the emailaddress2 column.</value>
		public String DBColumnEmailAddress2 { get { return _dbColumnEmailAddress2; } }
		/// <summary>
		/// Database columnname for the emailaddress3 column.
		/// </summary>
		/// <value>Columnname for the emailaddress3 column.</value>
		public String DBColumnEmailAddress3 { get { return _dbColumnEmailAddress3; } }
		/// <summary>
		/// Database columnname for the emailaddress4 column.
		/// </summary>
		/// <value>Columnname for the emailaddress4 column.</value>
		public String DBColumnEmailAddress4 { get { return _dbColumnEmailAddress4; } }
		/// <summary>
		/// Database columnname for the emailaddress5 column.
		/// </summary>
		/// <value>Columnname for the emailaddress5 column.</value>
		public String DBColumnEmailAddress5 { get { return _dbColumnEmailAddress5; } }
		/// <summary>
		/// Database columnname for the avatar sysid column.
		/// </summary>
		/// <value>Columnname for the avatar sysid column.</value>
		public String DBColumnAvatarSysId { get { return _dbColumnAvatarSysId; } }
		/// <summary>
		/// Database columnname for the application settings sysid column.
		/// </summary>
		/// <value>Columnname for the application settings sysid column.</value>
		public String DBColumnApplicationSettingsSysId { get { return _dbColumnApplicationSettingsSysId; } }
		/// <summary>
		/// Database columnname for the employeegroup sysid column.
		/// </summary>
		/// <value>Columnname for the employeegroup sysid column.</value>
		public String DBColumnEmployeeGroupSysId { get { return _dbColumnEmployeeGroupSysId; } }
		/// <summary>
		/// Database columnname for the administrator column.
		/// </summary>
		/// <value>Columnname for the administrator column.</value>
		public String DBColumnAdministrator { get { return _dbColumnAdministrator; } }

		/// <summary>
		/// Database command parameter for the user sysid column.
		/// </summary>
		/// <value>Command parameter for the user sysid column.</value>
		public String DBParameterUserSysId { get { return _dbParameterUserSysId; } }
		/// <summary>
		/// Database command parameter for the name column.
		/// </summary>
		/// <value>Command parameter for the name column.</value>
		public String DBParameterName { get { return _dbParameterName; } }
		/// <summary>
		/// Database command parameter for the firstname column.
		/// </summary>
		/// <value>Command parameter for the firstname column.</value>
		public String DBParameterFirstName { get { return _dbParameterFirstName; } }
		/// <summary>
		/// Database command parameter for the zipcode sysid column.
		/// </summary>
		/// <value>Command parameter for the zipcode sysid column.</value>
		public String DBParameterZipCodeSysId { get { return _dbParameterZipCodeSysId; } }
		/// <summary>
		/// Database command parameter for the address column.
		/// </summary>
		/// <value>Command parameter for the address column.</value>
		public String DBParameterAddress { get { return _dbParameterAddress; } }
		/// <summary>
		/// Database command parameter for the private phone number column.
		/// </summary>
		/// <value>Command parameter for the private phone number column.</value>
		public String DBParameterPrivatePhoneNumber { get { return _dbParameterPrivatePhoneNumber; } }
		/// <summary>
		/// Database command parameter for the work phone number column.
		/// </summary>
		/// <value>Command parameter for the work phone number column.</value>
		public String DBParameterWorkPhoneNumber { get { return _dbParameterWorkPhoneNumber; } }
		/// <summary>
		/// Database command parameter for the cell phone number column.
		/// </summary>
		/// <value>Command parameter for the cell phone number column.</value>
		public String DBParameterCellPhoneNumber { get { return _dbParameterCellPhoneNumber; } }
		/// <summary>
		/// Database command parameter for the emailaddress1 column.
		/// </summary>
		/// <value>Command parameter for the emailaddress1 column.</value>
		public String DBParameterEmailAddress1 { get { return _dbParameterEmailAddress1; } }
		/// <summary>
		/// Database command parameter for the emailaddress2 column.
		/// </summary>
		/// <value>Command parameter for the emailaddress2 column.</value>
		public String DBParameterEmailAddress2 { get { return _dbParameterEmailAddress2; } }
		/// <summary>
		/// Database command parameter for the emailaddress3 column.
		/// </summary>
		/// <value>Command parameter for the emailaddress3 column.</value>
		public String DBParameterEmailAddress3 { get { return _dbParameterEmailAddress3; } }
		/// <summary>
		/// Database command parameter for the emailaddress4 column.
		/// </summary>
		/// <value>Command parameter for the emailaddress4 column.</value>
		public String DBParameterEmailAddress4 { get { return _dbParameterEmailAddress4; } }
		/// <summary>
		/// Database command parameter for the emailaddress5 column.
		/// </summary>
		/// <value>Command parameter for the emailaddress5 column.</value>
		public String DBParameterEmailAddress5 { get { return _dbParameterEmailAddress5; } }
		/// <summary>
		/// Database command parameter for the avatar sysid column.
		/// </summary>
		/// <value>Command parameter for the avatar sysid column.</value>
		public String DBParameterAvatarSysId { get { return _dbParameterAvatarSysId; } }
		/// <summary>
		/// Database command parameter for the application settings sysid column.
		/// </summary>
		/// <value>Command parameter for the application settings sysid column.</value>
		public String DBParameterApplicationSettingsSysId { get { return _dbParameterApplicationSettingsSysId; } }
		/// <summary>
		/// Database command parameter for the employeegroup sysid column.
		/// </summary>
		/// <value>Command parameter for the employeegroup sysid column.</value>
		public String DBParameterEmployeeGroupSysId { get { return _dbParameterEmployeeGroupSysId; } }
		/// <summary>
		/// Database command parameter for the administrator column.
		/// </summary>
		/// <value>Command parameter for the administrator column.</value>
		public String DBParameterAdministrator { get { return _dbParameterAdministrator; } }

		#endregion

		#region -_ Public Methods _-

		public EmployeeData EmployeeFromReader( SqlDataReader reader ) {
			EmployeeData employeeToReturn = new EmployeeData();
			employeeToReturn.SysId = (int)reader[this.DBColumnSysId];
			employeeToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			employeeToReturn.UserSysId = (Guid)reader[this.DBColumnUserSysId];
			employeeToReturn.Name = (string)reader[this.DBColumnName];
			employeeToReturn.FirstName = (string)reader[this.DBColumnFirstName];
			if( reader[this.DBColumnAddress] != DBNull.Value ) {
				employeeToReturn.Address = (string)reader[this.DBColumnAddress];
			}
			if( reader[this.DBColumnZipCodeSysId] != DBNull.Value ) {
				employeeToReturn.ZipCodeSysId = (int)reader[this.DBColumnZipCodeSysId];
			}
			if( reader[this.DBColumnPrivatePhoneNumber] != DBNull.Value ) {
				employeeToReturn.PrivatePhoneNumber = (string)reader[this.DBColumnPrivatePhoneNumber];
			}
			if( reader[this.DBColumnWorkPhoneNumber] != DBNull.Value ) {
				employeeToReturn.WorkPhoneNumber = (string)reader[this.DBColumnWorkPhoneNumber];
			}
			if( reader[this.DBColumnCellPhoneNumber] != DBNull.Value ) {
				employeeToReturn.CellPhoneNumber = (string)reader[this.DBColumnCellPhoneNumber];
			}
			if( reader[this.DBColumnEmailAddress1] != DBNull.Value ) {
				employeeToReturn.EmailAddress1 = (string)reader[this.DBColumnEmailAddress1];
			}
			if( reader[this.DBColumnEmailAddress2] != DBNull.Value ) {
				employeeToReturn.EmailAddress2 = (string)reader[this.DBColumnEmailAddress2];
			}
			if( reader[this.DBColumnEmailAddress3] != DBNull.Value ) {
				employeeToReturn.EmailAddress3 = (string)reader[this.DBColumnEmailAddress3];
			}
			if( reader[this.DBColumnEmailAddress4] != DBNull.Value ) {
				employeeToReturn.EmailAddress4 = (string)reader[this.DBColumnEmailAddress4];
			}
			if( reader[this.DBColumnEmailAddress5] != DBNull.Value ) {
				employeeToReturn.EmailAddress5 = (string)reader[this.DBColumnEmailAddress5];
			}
			if( reader[this.DBColumnAvatarSysId] != DBNull.Value ) {
				employeeToReturn.AvatarSysId = (int?)reader[this.DBColumnAvatarSysId];
			}
			if( reader[this.DBColumnApplicationSettingsSysId] != DBNull.Value ) {
				employeeToReturn.ApplicationSettingsSysId = (int?)reader[this.DBColumnApplicationSettingsSysId];
			}
			employeeToReturn.EmployeeGroupSysId = (int)reader[this.DBColumnEmployeeGroupSysId];
			employeeToReturn.Administrator = (bool)reader[this.DBColumnAdministrator];
			employeeToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			employeeToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				employeeToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				employeeToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return employeeToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnUserSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnName + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnFirstName + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnAddress + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnZipCodeSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnPrivatePhoneNumber + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnWorkPhoneNumber + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCellPhoneNumber + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmailAddress1 + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmailAddress2 + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmailAddress3 + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmailAddress4 + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmailAddress5 + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnAvatarSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnApplicationSettingsSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmployeeGroupSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnAdministrator + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		public String CreateSelectByGroup() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmployeeGroupSysId + " = " + this.DBParameterEmployeeGroupSysId + ";";
			return selectCommand;
		}

		public String CreateSelectByMachine() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " INNER JOIN";
			selectCommand += " " + EmployeeSettingsSqlHelper.SqlHelper.DBTableName;
			selectCommand += " ON";
			selectCommand += " " + EmployeeSettingsSqlHelper.SqlHelper.DBTableName + "." + EmployeeSettingsSqlHelper.SqlHelper.DBColumnSysId + " = " + this.DBTableName + "." + this.DBColumnApplicationSettingsSysId;			
			selectCommand += " WHERE";
			selectCommand += " " + EmployeeSettingsSqlHelper.SqlHelper.DBTableName + "." + EmployeeSettingsSqlHelper.SqlHelper.DBColumnAutoLogon + " = 'TRUE'";
			selectCommand += " AND";
			selectCommand += " " + EmployeeSettingsSqlHelper.SqlHelper.DBTableName + "." + EmployeeSettingsSqlHelper.SqlHelper.DBColumnAutoLogonHost + " = " + EmployeeSettingsSqlHelper.SqlHelper.DBParameterAutoLogonHost;
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
			insertCommand += " (" + this.DBColumnUserSysId + " , " + this.DBColumnName + " , " + this.DBColumnFirstName + " , " + this.DBColumnAddress + " , " + this.DBColumnZipCodeSysId + " , " + this.DBColumnPrivatePhoneNumber + " , " + this.DBColumnWorkPhoneNumber + " , " + this.DBColumnCellPhoneNumber + " , " + this.DBColumnEmailAddress1 + " , " + this.DBColumnEmailAddress2 + " , " + this.DBColumnEmailAddress3 + " , " + this.DBColumnEmailAddress4 + " , " + this.DBColumnEmailAddress5 + " , " + this.DBColumnAvatarSysId + " , " + this.DBColumnApplicationSettingsSysId + " , " + this.DBColumnEmployeeGroupSysId + " , " + this.DBColumnAdministrator + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterUserSysId + " , " + this.DBParameterName + " , " + this.DBParameterFirstName + " , " + this.DBParameterAddress + " , " + this.DBParameterZipCodeSysId + " , " + this.DBParameterPrivatePhoneNumber + " , " + this.DBParameterWorkPhoneNumber + " , " + this.DBParameterCellPhoneNumber + " , " + this.DBParameterEmailAddress1 + " , " + this.DBParameterEmailAddress2 + " , " + this.DBParameterEmailAddress3 + " , " + this.DBParameterEmailAddress4 + " , " + this.DBParameterEmailAddress5 + " , " + this.DBParameterAvatarSysId + " , " + this.DBParameterApplicationSettingsSysId + " , " + this.DBParameterEmployeeGroupSysId + " , " + this.DBParameterAdministrator + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnUserSysId + " = " + this.DBParameterUserSysId;
			updateCommand += " , " + this.DBColumnName + " = " + this.DBParameterName;
			updateCommand += " , " + this.DBColumnFirstName + " = " + this.DBParameterFirstName;
			updateCommand += " , " + this.DBColumnAddress + " = " + this.DBParameterAddress;
			updateCommand += " , " + this.DBColumnZipCodeSysId + " = " + this.DBParameterZipCodeSysId;
			updateCommand += " , " + this.DBColumnPrivatePhoneNumber + " = " + this.DBParameterPrivatePhoneNumber;
			updateCommand += " , " + this.DBColumnWorkPhoneNumber + " = " + this.DBParameterWorkPhoneNumber;
			updateCommand += " , " + this.DBColumnCellPhoneNumber + " = " + this.DBParameterCellPhoneNumber;
			updateCommand += " , " + this.DBColumnEmailAddress1 + " = " + this.DBParameterEmailAddress1;
			updateCommand += " , " + this.DBColumnEmailAddress2 + " = " + this.DBParameterEmailAddress2;
			updateCommand += " , " + this.DBColumnEmailAddress3 + " = " + this.DBParameterEmailAddress3;
			updateCommand += " , " + this.DBColumnEmailAddress4 + " = " + this.DBParameterEmailAddress4;
			updateCommand += " , " + this.DBColumnEmailAddress5 + " = " + this.DBParameterEmailAddress5;
			updateCommand += " , " + this.DBColumnAvatarSysId + " = " + this.DBParameterAvatarSysId;
			updateCommand += " , " + this.DBColumnApplicationSettingsSysId + " = " + this.DBParameterApplicationSettingsSysId;
			updateCommand += " , " + this.DBColumnEmployeeGroupSysId + " = " + this.DBParameterEmployeeGroupSysId;
			updateCommand += " , " + this.DBColumnAdministrator + " = " + this.DBParameterAdministrator;
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
