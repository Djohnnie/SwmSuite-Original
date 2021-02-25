using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Data.Common;


namespace SwmSuite.DataAccess.Sql.SqlHelper {

	public class RecurrenceSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private AppointmentRecurrenceSqlHelper _appointmentRecurrenceSqlHelper = new AppointmentRecurrenceSqlHelper();
		private TaskRecurrenceSqlHelper _taskRecurrenceSqlHelper = new TaskRecurrenceSqlHelper();

		private String _dbTableName = "tbl_Recurrences";

		private String _dbColumnRecurrenceMode = "RecurrenceMode";
		private String _dbColumnEvery = "Every";
		private String _dbColumnEveryWeekDay = "EveryWeekDay";
		private String _dbColumnMonday = "Monday";
		private String _dbColumnTuesday = "Tuesday";
		private String _dbColumnWednesday = "Wednesday";
		private String _dbColumnThursday = "Thursday";
		private String _dbColumnFriday = "Friday";
		private String _dbColumnSaturday = "Saturday";
		private String _dbColumnSunday = "Sunday";
		private String _dbColumnDayOfMonth = "DayOfMonth";
		private String _dbColumnOccurrence = "Occurrence";
		private String _dbColumnDay = "Day";
		private String _dbColumnMonth = "Month";
		private String _dbColumnChoice = "Choice";
		private String _dbColumnStartDate = "StartDate";
		private String _dbColumnEndMode = "EndMode";
		private String _dbColumnOccurrences = "Occurrences";
		private String _dbColumnEndDate = "EndDate";
		private String _dbColumnDescription = "Description";

		private String _dbParameterRecurrenceMode = "@RecurrenceMode";
		private String _dbParameterEvery = "@Every";
		private String _dbParameterEveryWeekDay = "@EveryWeekDay";
		private String _dbParameterMonday = "@Monday";
		private String _dbParameterTuesday = "@Tuesday";
		private String _dbParameterWednesday = "@Wednesday";
		private String _dbParameterThursday = "@Thursday";
		private String _dbParameterFriday = "@Friday";
		private String _dbParameterSaturday = "@Saturday";
		private String _dbParameterSunday = "@Sunday";
		private String _dbParameterDayOfMonth = "@DayOfMonth";
		private String _dbParameterOccurrence = "@Occurrence";
		private String _dbParameterDay = "@Day";
		private String _dbParameterMonth = "@Month";
		private String _dbParameterChoice = "@Choice";
		private String _dbParameterStartDate = "@StartDate";
		private String _dbParameterEndMode = "@EndMode";
		private String _dbParameterOccurrences = "@Occurrences";
		private String _dbParameterEndDate = "@EndDate";
		private String _dbParameterDescription = "@Description";

		private String _dbParameterAppointment = "@Appointment";
		private String _dbParameterTask = "@Task";

		#endregion

		#region -_ Public Properties _-

		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the recurrence mode column.
		/// </summary>
		/// <value>Columnname for the recurrence mode column.</value>
		public String DBColumnRecurrenceMode { get { return _dbColumnRecurrenceMode; } }
		/// <summary>
		/// Database columnname for the every column.
		/// </summary>
		/// <value>Columnname for the every column.</value>
		public String DBColumnEvery { get { return _dbColumnEvery; } }
		/// <summary>
		/// Database columnname for the every weekday column.
		/// </summary>
		/// <value>Columnname for the every weekday column.</value>
		public String DBColumnEveryWeekDay { get { return _dbColumnEveryWeekDay; } }
		/// <summary>
		/// Database columnname for the monday column.
		/// </summary>
		/// <value>Columnname for the monday column.</value>
		public String DBColumnMonday { get { return _dbColumnMonday; } }
		/// <summary>
		/// Database columnname for the tuesday column.
		/// </summary>
		/// <value>Columnname for the tuesday column.</value>
		public String DBColumnTuesday { get { return _dbColumnTuesday; } }
		/// <summary>
		/// Database columnname for the wednesday column.
		/// </summary>
		/// <value>Columnname for the wednesday column.</value>
		public String DBColumnWednesday { get { return _dbColumnWednesday; } }
		/// <summary>
		/// Database columnname for the thursday column.
		/// </summary>
		/// <value>Columnname for the thursday column.</value>
		public String DBColumnThursday { get { return _dbColumnThursday; } }
		/// <summary>
		/// Database columnname for the friday column.
		/// </summary>
		/// <value>Columnname for the friday column.</value>
		public String DBColumnFriday { get { return _dbColumnFriday; } }
		/// <summary>
		/// Database columnname for the saturday column.
		/// </summary>
		/// <value>Columnname for the saturday column.</value>
		public String DBColumnSaturday { get { return _dbColumnSaturday; } }
		/// <summary>
		/// Database columnname for the sunday column.
		/// </summary>
		/// <value>Columnname for the sunday column.</value>
		public String DBColumnSunday { get { return _dbColumnSunday; } }
		/// <summary>
		/// Database columnname for the day of month column.
		/// </summary>
		/// <value>Columnname for the day of month column.</value>
		public String DBColumnDayOfMonth { get { return _dbColumnDayOfMonth; } }
		/// <summary>
		/// Database columnname for the occurrence column.
		/// </summary>
		/// <value>Columnname for the occurrence column.</value>
		public String DBColumnOccurrence { get { return _dbColumnOccurrence; } }
		/// <summary>
		/// Database columnname for the day column.
		/// </summary>
		/// <value>Columnname for the day column.</value>
		public String DBColumnDay { get { return _dbColumnDay; } }
		/// <summary>
		/// Database columnname for the month column.
		/// </summary>
		/// <value>Columnname for the month column.</value>
		public String DBColumnMonth { get { return _dbColumnMonth; } }
		/// <summary>
		/// Database columnname for the choice column.
		/// </summary>
		/// <value>Columnname for the choice column.</value>
		public String DBColumnChoice { get { return _dbColumnChoice; } }
		/// <summary>
		/// Database columnname for the start date column.
		/// </summary>
		/// <value>Columnname for the start date column.</value>
		public String DBColumnStartDate { get { return _dbColumnStartDate; } }
		/// <summary>
		/// Database columnname for the end mode column.
		/// </summary>
		/// <value>Columnname for the end mode column.</value>
		public String DBColumnEndMode { get { return _dbColumnEndMode; } }
		/// <summary>
		/// Database columnname for the occurrences column.
		/// </summary>
		/// <value>Columnname for the occurrences column.</value>
		public String DBColumnOccurrences { get { return _dbColumnOccurrences; } }
		/// <summary>
		/// Database columnname for the end date column.
		/// </summary>
		/// <value>Columnname for the end date column.</value>
		public String DBColumnEndDate { get { return _dbColumnEndDate; } }
		/// <summary>
		/// Database columnname for the description column.
		/// </summary>
		/// <value>Columnname for the description column.</value>
		public String DBColumnDescription { get { return _dbColumnDescription; } }

		/// <summary>
		/// Database command parameter for the recurrence mode column.
		/// </summary>
		/// <value>Command parameter for the recurrence mode column.</value>
		public String DBParameterRecurrenceMode { get { return _dbParameterRecurrenceMode; } }
		/// <summary>
		/// Database command parameter for the every column.
		/// </summary>
		/// <value>Command parameter for the every column.</value>
		public String DBParameterEvery { get { return _dbParameterEvery; } }
		/// <summary>
		/// Database command parameter for the every weekday column.
		/// </summary>
		/// <value>Command parameter for the every weekday column.</value>
		public String DBParameterEveryWeekDay { get { return _dbParameterEveryWeekDay; } }
		/// <summary>
		/// Database command parameter for the monday column.
		/// </summary>
		/// <value>Command parameter for the monday column.</value>
		public String DBParameterMonday { get { return _dbParameterMonday; } }
		/// <summary>
		/// Database command parameter for the tuesday column.
		/// </summary>
		/// <value>Command parameter for the tuesday column.</value>
		public String DBParameterTuesday { get { return _dbParameterTuesday; } }
		/// <summary>
		/// Database command parameter for the wednesday column.
		/// </summary>
		/// <value>Command parameter for the wednesday column.</value>
		public String DBParameterWednesday { get { return _dbParameterWednesday; } }
		/// <summary>
		/// Database command parameter for the thursday column.
		/// </summary>
		/// <value>Command parameter for the thursday column.</value>
		public String DBParameterThursday { get { return _dbParameterThursday; } }
		/// <summary>
		/// Database command parameter for the friday column.
		/// </summary>
		/// <value>Command parameter for the friday column.</value>
		public String DBParameterFriday { get { return _dbParameterFriday; } }
		/// <summary>
		/// Database command parameter for the saturday column.
		/// </summary>
		/// <value>Command parameter for the saturday column.</value>
		public String DBParameterSaturday { get { return _dbParameterSaturday; } }
		/// <summary>
		/// Database command parameter for the sunday column.
		/// </summary>
		/// <value>Command parameter for the sunday column.</value>
		public String DBParameterSunday { get { return _dbParameterSunday; } }
		/// <summary>
		/// Database command parameter for the day of month column.
		/// </summary>
		/// <value>Command parameter for the day of month column.</value>
		public String DBParameterDayOfMonth { get { return _dbParameterDayOfMonth; } }
		/// <summary>
		/// Database command parameter for the occurrence column.
		/// </summary>
		/// <value>Command parameter for the occurrence column.</value>
		public String DBParameterOccurrence { get { return _dbParameterOccurrence; } }
		/// <summary>
		/// Database command parameter for the day column.
		/// </summary>
		/// <value>Command parameter for the day column.</value>
		public String DBParameterDay { get { return _dbParameterDay; } }
		/// <summary>
		/// Database command parameter for the month column.
		/// </summary>
		/// <value>Command parameter for the month column.</value>
		public String DBParameterMonth { get { return _dbParameterMonth; } }
		/// <summary>
		/// Database command parameter for the choice column.
		/// </summary>
		/// <value>Command parameter for the choice column.</value>
		public String DBParameterChoice { get { return _dbParameterChoice; } }
		/// <summary>
		/// Database command parameter for the start date column.
		/// </summary>
		/// <value>Command parameter for the start date column.</value>
		public String DBParameterStartDate { get { return _dbParameterStartDate; } }
		/// <summary>
		/// Database command parameter for the end mode column.
		/// </summary>
		/// <value>Command parameter for the end mode column.</value>
		public String DBParameterEndMode { get { return _dbParameterEndMode; } }
		/// <summary>
		/// Database command parameter for the occurrences column.
		/// </summary>
		/// <value>Command parameter for the occurrences column.</value>
		public String DBParameterOccurrences { get { return _dbParameterOccurrences; } }
		/// <summary>
		/// Database command parameter for the end date column.
		/// </summary>
		/// <value>Command parameter for the end date column.</value>
		public String DBParameterEndDate { get { return _dbParameterEndDate; } }
		/// <summary>
		/// Database command parameter for the description column.
		/// </summary>
		/// <value>Command parameter for the description column.</value>
		public String DBParameterDescription { get { return _dbParameterDescription; } }

		/// <summary>
		/// Database command parameter for the appointment parameter.
		/// </summary>
		public String DBParameterAppointment { get { return _dbParameterAppointment; } }

		/// <summary>
		/// Database command parameter for the task parameter.
		/// </summary>
		public String DBParameterTask { get { return _dbParameterTask; } }

		#endregion

		#region -_ Public Methods _-

		public RecurrenceData RecurrenceFromReader( SqlDataReader reader ) {
			RecurrenceData recurrenceToReturn = new RecurrenceData();
			recurrenceToReturn.SysId = (int)reader[this.DBColumnSysId];
			recurrenceToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			recurrenceToReturn.RecurrenceMode = (RecurrenceMode)(byte)reader[this.DBColumnRecurrenceMode];
			recurrenceToReturn.Every = (int)reader[this.DBColumnEvery];
			recurrenceToReturn.EveryWeekDay = (bool)reader[this.DBColumnEveryWeekDay];
			recurrenceToReturn.Monday = (bool)reader[this.DBColumnMonday];
			recurrenceToReturn.Tuesday = (bool)reader[this.DBColumnTuesday];
			recurrenceToReturn.Wednesday = (bool)reader[this.DBColumnWednesday];
			recurrenceToReturn.Thursday = (bool)reader[this.DBColumnThursday];
			recurrenceToReturn.Friday = (bool)reader[this.DBColumnFriday];
			recurrenceToReturn.Saturday = (bool)reader[this.DBColumnSaturday];
			recurrenceToReturn.Sunday = (bool)reader[this.DBColumnSunday];
			recurrenceToReturn.DayOfMonth = (int)reader[this.DBColumnDayOfMonth];
			recurrenceToReturn.Occurrence = (Occurrence)(byte)reader[this.DBColumnOccurrence];
			recurrenceToReturn.Day = (Days)(byte)reader[this.DBColumnDay];
			recurrenceToReturn.Month = (Months)(byte)reader[this.DBColumnMonth];
			recurrenceToReturn.Choice = (bool)reader[this.DBColumnChoice];
			recurrenceToReturn.StartDate = (DateTime)reader[this.DBColumnStartDate];
			recurrenceToReturn.EndMode = (RecurrenceEndMode)(byte)reader[this.DBColumnEndMode];
			recurrenceToReturn.Occurrences = (int)reader[this.DBColumnOccurrences];
			recurrenceToReturn.EndDate = (DateTime)reader[this.DBColumnEndDate];
			if( reader[this.DBColumnDescription] != DBNull.Value ) {
				recurrenceToReturn.Description = (string)reader[this.DBColumnDescription];
			}
			recurrenceToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			recurrenceToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				recurrenceToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				recurrenceToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return recurrenceToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnRecurrenceMode + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEvery + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEveryWeekDay + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnMonday + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnTuesday + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnWednesday + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnThursday + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnFriday + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSaturday + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSunday + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDayOfMonth + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnOccurrence + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDay + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnMonth + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnChoice + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnStartDate + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEndMode + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnOccurrences + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEndDate + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDescription + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		/// <summary>
		/// Creates the sql select command by appointment.
		/// </summary>
		/// <returns>A string representing the command string.</returns>
		public String CreateSelectByAppointment() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " INNER JOIN";
			selectCommand += " " + _appointmentRecurrenceSqlHelper.DBTableName;
			selectCommand += " ON";
			selectCommand += " " + _appointmentRecurrenceSqlHelper.DBTableName + "." + _appointmentRecurrenceSqlHelper.DBColumnRecurrenceSysId;
			selectCommand += " =";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSysId;
			selectCommand += " WHERE";
			selectCommand += " " + _appointmentRecurrenceSqlHelper.DBTableName + "." + _appointmentRecurrenceSqlHelper.DBColumnAppointmentSysId;
			selectCommand += " =";
			selectCommand += " " + this.DBParameterAppointment;
			return selectCommand;
		}

		/// <summary>
		/// Creates the sql select command by task.
		/// </summary>
		/// <returns>A string representing the command string.</returns>
		public String CreateSelectByTask() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " INNER JOIN";
			selectCommand += " " + _taskRecurrenceSqlHelper.DBTableName;
			selectCommand += " ON";
			selectCommand += " " + _taskRecurrenceSqlHelper.DBTableName + "." + _taskRecurrenceSqlHelper.DBColumnRecurrenceSysId;
			selectCommand += " =";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSysId;
			selectCommand += " WHERE";
			selectCommand += " " + _taskRecurrenceSqlHelper.DBTableName + "." + _taskRecurrenceSqlHelper.DBColumnTaskDescriptionSysId;
			selectCommand += " =";
			selectCommand += " " + this.DBParameterTask;
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
			insertCommand += " (" + this.DBColumnRecurrenceMode + " , " + this.DBColumnEvery + " , " + this.DBColumnEveryWeekDay + " , " + this.DBColumnMonday + " , " + this.DBColumnTuesday + " , " + this.DBColumnWednesday + " , " + this.DBColumnThursday + " , " + this.DBColumnFriday + " , " + this.DBColumnSaturday + " , " + this.DBColumnSunday + " , " + this.DBColumnDayOfMonth + " , " + this.DBColumnOccurrence + " , " + this.DBColumnDay + " , " + this.DBColumnMonth + " , " + this.DBColumnChoice + " , " + this.DBColumnStartDate + " , " + this.DBColumnEndMode + " , " + this.DBColumnOccurrences + " , " + this.DBColumnEndDate + " , " + this.DBColumnDescription + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterRecurrenceMode + " , " + this.DBParameterEvery + " , " + this.DBParameterEveryWeekDay + " , " + this.DBParameterMonday + " , " + this.DBParameterTuesday + " , " + this.DBParameterWednesday + " , " + this.DBParameterThursday + " , " + this.DBParameterFriday + " , " + this.DBParameterSaturday + " , " + this.DBParameterSunday + " , " + this.DBParameterDayOfMonth + " , " + this.DBParameterOccurrence + " , " + this.DBParameterDay + " , " + this.DBParameterMonth + " , " + this.DBParameterChoice + " , " + this.DBParameterStartDate + " , " + this.DBParameterEndMode + " , " + this.DBParameterOccurrences + " , " + this.DBParameterEndDate + " , " + this.DBParameterDescription + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnRecurrenceMode + " = " + this.DBParameterRecurrenceMode;
			updateCommand += " , " + this.DBColumnEvery + " = " + this.DBParameterEvery;
			updateCommand += " , " + this.DBColumnEveryWeekDay + " = " + this.DBParameterEveryWeekDay;
			updateCommand += " , " + this.DBColumnMonday + " = " + this.DBParameterMonday;
			updateCommand += " , " + this.DBColumnTuesday + " = " + this.DBParameterTuesday;
			updateCommand += " , " + this.DBColumnWednesday + " = " + this.DBParameterWednesday;
			updateCommand += " , " + this.DBColumnThursday + " = " + this.DBParameterThursday;
			updateCommand += " , " + this.DBColumnFriday + " = " + this.DBParameterFriday;
			updateCommand += " , " + this.DBColumnSaturday + " = " + this.DBParameterSaturday;
			updateCommand += " , " + this.DBColumnSunday + " = " + this.DBParameterSunday;
			updateCommand += " , " + this.DBColumnDayOfMonth + " = " + this.DBParameterDayOfMonth;
			updateCommand += " , " + this.DBColumnOccurrence + " = " + this.DBParameterOccurrence;
			updateCommand += " , " + this.DBColumnDay + " = " + this.DBParameterDay;
			updateCommand += " , " + this.DBColumnMonth + " = " + this.DBParameterMonth;
			updateCommand += " , " + this.DBColumnChoice + " = " + this.DBParameterChoice;
			updateCommand += " , " + this.DBColumnStartDate + " = " + this.DBParameterStartDate;
			updateCommand += " , " + this.DBColumnEndMode + " = " + this.DBParameterEndMode;
			updateCommand += " , " + this.DBColumnOccurrences + " = " + this.DBParameterOccurrences;
			updateCommand += " , " + this.DBColumnEndDate + " = " + this.DBParameterEndDate;
			updateCommand += " , " + this.DBColumnDescription + " = " + this.DBParameterDescription;
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
