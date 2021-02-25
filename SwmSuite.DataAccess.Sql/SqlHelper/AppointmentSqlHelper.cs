using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Data.Common;

namespace SwmSuite.DataAccess.Sql.SqlHelper.AgendaModule {

	public class AppointmentSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private AppointmentGuestSqlHelper _appointmentGuestSqlHelper = new AppointmentGuestSqlHelper();
		private AppointmentRecurrenceSqlHelper _appointmentRecurrenceSqlHelper = new AppointmentRecurrenceSqlHelper();

		private String _dbTableName = "tbl_Appointments";

		private String _dbColumnTitle = "Title";
		private String _dbColumnDateTimeStart = "DateTimeStart";
		private String _dbColumnDateTimeEnd = "DateTimeEnd";
		private String _dbColumnPlace = "Place";
		private String _dbColumnOwnerEmployeeSysId = "OwnerEmployeeSysId";
		private String _dbColumnContents = "Contents";
		private String _dbColumnAgendaSysId = "AgendaSysId";
		private String _dbColumnVisibility = "Visibility";

		private String _dbParameterTitle = "@Title";
		private String _dbParameterDateTimeStart = "@DateTimeStart";
		private String _dbParameterDateTimeEnd = "@DateTimeEnd";
		private String _dbParameterPlace = "@Place";
		private String _dbParameterOwnerEmployeeSysId = "@OwnerEmployeeSysId";
		private String _dbParameterContents = "@Contents";
		private String _dbParameterAgendaSysId = "@AgendaSysId";
		private String _dbParameterVisibility = "@Visibility";

		private String _dbParameterEmployee = "@Employee";
		private String _dbParameterOnDate = "@OnDate";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the title column.
		/// </summary>
		/// <value>Columnname for the title column.</value>
		public String DBColumnTitle { get { return _dbColumnTitle; } }
		/// <summary>
		/// Database columnname for the date time start column.
		/// </summary>
		/// <value>Columnname for the date time start column.</value>
		public String DBColumnDateTimeStart { get { return _dbColumnDateTimeStart; } }
		/// <summary>
		/// Database columnname for the date time end column.
		/// </summary>
		/// <value>Columnname for the date time end column.</value>
		public String DBColumnDateTimeEnd { get { return _dbColumnDateTimeEnd; } }
		/// <summary>
		/// Database columnname for the place column.
		/// </summary>
		/// <value>Columnname for the place column.</value>
		public String DBColumnPlace { get { return _dbColumnPlace; } }
		/// <summary>
		/// Database columnname for the owner employee sysid column.
		/// </summary>
		/// <value>Columnname for the owner employee sysid column.</value>
		public String DBColumnOwnerEmployeeSysId { get { return _dbColumnOwnerEmployeeSysId; } }
		/// <summary>
		/// Database columnname for the contents column.
		/// </summary>
		/// <value>Columnname for the contents column.</value>
		public String DBColumnContents { get { return _dbColumnContents; } }
		/// <summary>
		/// Database columnname for the agenda sysid column.
		/// </summary>
		/// <value>Columnname for the agenda sysid column.</value>
		public String DBColumnAgendaSysId { get { return _dbColumnAgendaSysId; } }
		/// <summary>
		/// Database columnname for the visibility column.
		/// </summary>
		/// <value>Columnname for the visibility column.</value>
		public String DBColumnVisibility { get { return _dbColumnVisibility; } }

		/// <summary>
		/// Database command parameter for the title column.
		/// </summary>
		/// <value>Command parameter for the title column.</value>
		public String DBParameterTitle { get { return _dbParameterTitle; } }
		/// <summary>
		/// Database command parameter for the date time start column.
		/// </summary>
		/// <value>Command parameter for the date time start column.</value>
		public String DBParameterDateTimeStart { get { return _dbParameterDateTimeStart; } }
		/// <summary>
		/// Database command parameter for the date time end column.
		/// </summary>
		/// <value>Command parameter for the date time end column.</value>
		public String DBParameterDateTimeEnd { get { return _dbParameterDateTimeEnd; } }
		/// <summary>
		/// Database command parameter for the place column.
		/// </summary>
		/// <value>Command parameter for the place column.</value>
		public String DBParameterPlace { get { return _dbParameterPlace; } }
		/// <summary>
		/// Database command parameter for the owner employee sysid column.
		/// </summary>
		/// <value>Command parameter for the owner employee sysid column.</value>
		public String DBParameterOwnerEmployeeSysId { get { return _dbParameterOwnerEmployeeSysId; } }
		/// <summary>
		/// Database command parameter for the contents column.
		/// </summary>
		/// <value>Command parameter for the contents column.</value>
		public String DBParameterContents { get { return _dbParameterContents; } }
		/// <summary>
		/// Database command parameter for the agenda sysid column.
		/// </summary>
		/// <value>Command parameter for the agenda sysid column.</value>
		public String DBParameterAgendaSysId { get { return _dbParameterAgendaSysId; } }
		/// <summary>
		/// Database command parameter for the visibility column.
		/// </summary>
		/// <value>Command parameter for the visibility column.</value>
		public String DBParameterVisibility { get { return _dbParameterVisibility; } }

		/// <summary>
		/// Database command parameter for the employee parameter.
		/// </summary>
		public String DBParameterEmployee { get { return _dbParameterEmployee; } }

		/// <summary>
		/// Database command parameter for the ondate parameter.
		/// </summary>
		public String DBParameterOnDate { get { return _dbParameterOnDate; } }

		#endregion

		#region -_ Public Methods _-

		public AppointmentData AppointmentFromReader( SqlDataReader reader ) {
			AppointmentData appointmentToReturn = new AppointmentData();
			appointmentToReturn.SysId = (int)reader[this.DBColumnSysId];
			appointmentToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			appointmentToReturn.Title = (string)reader[this.DBColumnTitle];
			appointmentToReturn.DateTimeStart = (DateTime)reader[this.DBColumnDateTimeStart];
			appointmentToReturn.DateTimeEnd = (DateTime)reader[this.DBColumnDateTimeEnd];
			if( reader[this.DBColumnPlace] != DBNull.Value ) {
				appointmentToReturn.Place = (string)reader[this.DBColumnPlace];
			} else {
				appointmentToReturn.Place = null;
			}
			appointmentToReturn.OwnerEmployeeSysId = (int)reader[this.DBColumnOwnerEmployeeSysId];
			if( reader[this.DBColumnContents] != DBNull.Value ) {
				appointmentToReturn.Contents = (string)reader[this.DBColumnContents];
			} else {
				appointmentToReturn.Contents = null;
			}
			appointmentToReturn.AgendaSysId = (int)reader[this.DBColumnAgendaSysId];
			appointmentToReturn.Visibility = (AppointmentVisibility)(byte)reader[this.DBColumnVisibility];
			appointmentToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			appointmentToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				appointmentToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				appointmentToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return appointmentToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnTitle + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDateTimeStart + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDateTimeEnd + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnPlace + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnOwnerEmployeeSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnContents + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnAgendaSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnVisibility + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		/// <summary>
		/// Creates the sql select command if recurrent.
		/// </summary>
		/// <returns>A string representing the command string.</returns>
		public String CreateSelectIfRecurrent() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " INNER JOIN";
			selectCommand += " " + _appointmentRecurrenceSqlHelper.DBTableName;
			selectCommand += " ON";
			selectCommand += " " + _appointmentRecurrenceSqlHelper.DBTableName + "." + _appointmentRecurrenceSqlHelper.DBColumnAppointmentSysId;
			selectCommand += " =";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSysId;
			return selectCommand;
		}

		/// <summary>
		/// Creates the sql select command on date for guest.
		/// </summary>
		/// <returns>A string representing the command string.</returns>
		public String CreateSelectOnDateGuest() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " INNER JOIN";
			selectCommand += " " + _appointmentGuestSqlHelper.DBTableName;
			selectCommand += " ON";
			selectCommand += " " + _appointmentGuestSqlHelper.DBTableName + "." + _appointmentGuestSqlHelper.DBColumnAppointmentSysId;
			selectCommand += " =";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSysId;
			selectCommand += " AND";
			selectCommand += " " + _appointmentGuestSqlHelper.DBTableName + "." + _appointmentGuestSqlHelper.DBColumnEmployeeSysId;
			selectCommand += " =";
			selectCommand += " " + this.DBParameterEmployee;			
			selectCommand += " WHERE";
			selectCommand += " " + this.DBParameterOnDate + " >= " + "dbo.DateTime( YEAR( " + this.DBTableName + "." + this.DBColumnDateTimeStart + " ) , " + "MONTH( " + this.DBTableName + "." + this.DBColumnDateTimeStart + " ) , " + "DAY( " + this.DBTableName + "." + this.DBColumnDateTimeStart + " ) , 0 , 0 , 0 )";
			selectCommand += " AND";
			selectCommand += " " + this.DBParameterOnDate + " <= " + "dbo.DateTime( YEAR( " + this.DBTableName + "." + this.DBColumnDateTimeEnd + " ) , " + "MONTH( " + this.DBTableName + "." + this.DBColumnDateTimeEnd + " ) , " + "DAY( " + this.DBTableName + "." + this.DBColumnDateTimeEnd + " ) , 23 , 59 , 59 )";
			return selectCommand;
		}

		/// <summary>
		/// Creates the sql select command on date.
		/// </summary>
		/// <returns>A string representing the command string.</returns>
		public String CreateSelectOnDate() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnOwnerEmployeeSysId + " = " + this.DBParameterEmployee;
			selectCommand += " AND";
			selectCommand += " " + this.DBParameterOnDate + " >= " + "dbo.DateTime( YEAR( " + this.DBTableName + "." + this.DBColumnDateTimeStart + " ) , " + "MONTH( " + this.DBTableName + "." + this.DBColumnDateTimeStart + " ) , " + "DAY( " + this.DBTableName + "." + this.DBColumnDateTimeStart + " ) , 0 , 0 , 0 )";
			selectCommand += " AND";
			selectCommand += " " + this.DBParameterOnDate + " <= " + "dbo.DateTime( YEAR( " + this.DBTableName + "." + this.DBColumnDateTimeEnd + " ) , " + "MONTH( " + this.DBTableName + "." + this.DBColumnDateTimeEnd + " ) , " + "DAY( " + this.DBTableName + "." + this.DBColumnDateTimeEnd + " ) , 23 , 59 , 59 )";
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
			insertCommand += " (" + this.DBColumnTitle + " , " + this.DBColumnDateTimeStart + " , " + this.DBColumnDateTimeEnd + " , " + this.DBColumnPlace + " , " + this.DBColumnOwnerEmployeeSysId + " , " + this.DBColumnContents + " , " + this.DBColumnAgendaSysId + " , " + this.DBColumnVisibility + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterTitle + " , " + this.DBParameterDateTimeStart + " , " + this.DBParameterDateTimeEnd + " , " + this.DBParameterPlace + " , " + this.DBParameterOwnerEmployeeSysId + " , " + this.DBParameterContents + " , " + this.DBParameterAgendaSysId + " , " + this.DBParameterVisibility + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnTitle + " = " + this.DBParameterTitle;
			updateCommand += " , " + this.DBColumnDateTimeStart + " = " + this.DBParameterDateTimeStart;
			updateCommand += " , " + this.DBColumnDateTimeEnd + " = " + this.DBParameterDateTimeEnd;
			updateCommand += " , " + this.DBColumnPlace + " = " + this.DBParameterPlace;
			updateCommand += " , " + this.DBColumnOwnerEmployeeSysId + " = " + this.DBParameterOwnerEmployeeSysId;
			updateCommand += " , " + this.DBColumnContents + " = " + this.DBParameterContents;
			updateCommand += " , " + this.DBColumnAgendaSysId + " = " + this.DBParameterAgendaSysId;
			updateCommand += " , " + this.DBColumnVisibility + " = " + this.DBParameterVisibility;
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
