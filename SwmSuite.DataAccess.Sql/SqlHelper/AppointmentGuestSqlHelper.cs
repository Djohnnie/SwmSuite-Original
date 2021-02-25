using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper.AgendaModule {

	public class AppointmentGuestSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_AppointmentGuests";

		private String _dbColumnAppointmentSysId = "AppointmentSysId";
		private String _dbColumnEmployeeSysId = "EmployeeSysId";

		private String _dbParameterAppointmentSysId = "@AppointmentSysId";
		private String _dbParameterEmployeeSysId = "@EmployeeSysId";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the appointment sysid column.
		/// </summary>
		/// <value>Columnname for the appointment sysid column.</value>
		public String DBColumnAppointmentSysId { get { return _dbColumnAppointmentSysId; } }
		/// <summary>
		/// Database columnname for the employee sysid column.
		/// </summary>
		/// <value>Columnname for the employee sysid column.</value>
		public String DBColumnEmployeeSysId { get { return _dbColumnEmployeeSysId; } }

		/// <summary>
		/// Database command parameter for the appointment sysid column.
		/// </summary>
		/// <value>Command parameter for the appointment sysid column.</value>
		public String DBParameterAppointmentSysId { get { return _dbParameterAppointmentSysId; } }
		/// <summary>
		/// Database command parameter for the employee sysid column.
		/// </summary>
		/// <value>Command parameter for the employee sysid column.</value>
		public String DBParameterEmployeeSysId { get { return _dbParameterEmployeeSysId; } }

		#endregion

		#region -_ Public Methods _-

		public AppointmentGuestData AppointmentGuestFromReader( SqlDataReader reader ) {
			AppointmentGuestData appointmentguestToReturn = new AppointmentGuestData();
			appointmentguestToReturn.SysId = (int)reader[this.DBColumnSysId];
			appointmentguestToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			appointmentguestToReturn.AppointmentSysId = (int)reader[this.DBColumnAppointmentSysId];
			appointmentguestToReturn.EmployeeSysId = (int)reader[this.DBColumnEmployeeSysId];
			appointmentguestToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			appointmentguestToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				appointmentguestToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				appointmentguestToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return appointmentguestToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnAppointmentSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		public String CreateSelectByAppointment() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnAppointmentSysId + " = " + this.DBParameterAppointmentSysId;
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
			insertCommand += " (" + this.DBColumnAppointmentSysId + " , " + this.DBColumnEmployeeSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterAppointmentSysId + " , " + this.DBParameterEmployeeSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnAppointmentSysId + " = " + this.DBParameterAppointmentSysId;
			updateCommand += " , " + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
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