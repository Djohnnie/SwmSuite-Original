using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper {

	public class AppointmentRecurrenceSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_AppointmentRecurrences";

		private String _dbColumnAppointmentSysId = "AppointmentSysId";
		private String _dbColumnRecurrenceSysId = "RecurrenceSysId";

		private String _dbParameterAppointmentSysId = "@AppointmentSysId";
		private String _dbParameterRecurrenceSysId = "@RecurrenceSysId";

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
		/// Database columnname for the recurrence sysid column.
		/// </summary>
		/// <value>Columnname for the recurrence sysid column.</value>
		public String DBColumnRecurrenceSysId { get { return _dbColumnRecurrenceSysId; } }

		/// <summary>
		/// Database command parameter for the appointment sysid column.
		/// </summary>
		/// <value>Command parameter for the appointment sysid column.</value>
		public String DBParameterAppointmentSysId { get { return _dbParameterAppointmentSysId; } }
		/// <summary>
		/// Database command parameter for the recurrence sysid column.
		/// </summary>
		/// <value>Command parameter for the recurrence sysid column.</value>
		public String DBParameterRecurrenceSysId { get { return _dbParameterRecurrenceSysId; } }

		#endregion

		#region -_ Public Methods _-

		public AppointmentRecurrenceData AppointmentRecurrenceFromReader( SqlDataReader reader ) {
			AppointmentRecurrenceData appointmentrecurrenceToReturn = new AppointmentRecurrenceData();
			appointmentrecurrenceToReturn.SysId = (int)reader[this.DBColumnSysId];
			appointmentrecurrenceToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			appointmentrecurrenceToReturn.AppointmentSysId = (int)reader[this.DBColumnAppointmentSysId];
			appointmentrecurrenceToReturn.RecurrenceSysId = (int)reader[this.DBColumnRecurrenceSysId];
			appointmentrecurrenceToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			appointmentrecurrenceToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				appointmentrecurrenceToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				appointmentrecurrenceToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return appointmentrecurrenceToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnRecurrenceSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
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
			insertCommand += " (" + this.DBColumnAppointmentSysId + " , " + this.DBColumnRecurrenceSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterAppointmentSysId + " , " + this.DBParameterRecurrenceSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += " , " + this.DBColumnRecurrenceSysId + " = " + this.DBParameterRecurrenceSysId;
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
