using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql.SqlHelper {

	public class TimeTableEntrySqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_TimeTableEntries";

		private String _dbColumnDate = "Date";
		private String _dbColumnEmployeeSysId = "EmployeeSysId";
		private String _dbColumnFrom = "[From]";
		private String _dbColumnTo = "[To]";
		private String _dbColumnTimeTablePurposeSysId = "TimeTablePurposeSysId";

		private String _dbParameterDate = "@Date";
		private String _dbParameterEmployeeSysId = "@EmployeeSysId";
		private String _dbParameterFrom = "@From";
		private String _dbParameterTo = "@To";
		private String _dbParameterTimeTablePurposeSysId = "@TimeTablePurposeSysId";
		private String _dbParameterPeriodStart = "@PeriodStart";
		private String _dbParameterPeriodEnd = "@PeriodEnd";

		#endregion

		#region -_ Public Properties _-

		override public String DBTableName { get { return _dbTableName; } }

		public String DBColumnDate { get { return _dbColumnDate; } }
		public String DBColumnEmployeeSysId { get { return _dbColumnEmployeeSysId; } }
		public String DBColumnFrom { get { return _dbColumnFrom; } }
		public String DBColumnTo { get { return _dbColumnTo; } }
		public String DBColumnTimeTablePurposeSysId { get { return _dbColumnTimeTablePurposeSysId; } }

		public String DBParameterDate { get { return _dbParameterDate; } }
		public String DBParameterEmployeeSysId { get { return _dbParameterEmployeeSysId; } }
		public String DBParameterFrom { get { return _dbParameterFrom; } }
		public String DBParameterTo { get { return _dbParameterTo; } }
		public String DBParameterTimeTablePurposeSysId { get { return _dbParameterTimeTablePurposeSysId; } }
		public String DBParameterPeriodStart { get { return _dbParameterPeriodStart; } }
		public String DBParameterPeriodEnd { get { return _dbParameterPeriodEnd; } }

		#endregion

		#region -_ Public Methods _-

		public TimeTableEntryData TimeTableEntryFromReader( SqlDataReader reader ) {
			TimeTableEntryData timetableentrydataToReturn = new TimeTableEntryData();
			timetableentrydataToReturn.SysId = (int)reader[this.DBColumnSysId];
			timetableentrydataToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			timetableentrydataToReturn.Date = (DateTime)reader[this.DBColumnDate];
			timetableentrydataToReturn.EmployeeSysId = (int)reader[this.DBColumnEmployeeSysId];
			timetableentrydataToReturn.From = (DateTime)reader[this.DBColumnFrom.Replace( "[" , "" ).Replace( "]" , "" )];
			timetableentrydataToReturn.To = (DateTime)reader[this.DBColumnTo.Replace( "[" , "" ).Replace( "]" , "" )];
			timetableentrydataToReturn.TimeTablePurposeSysId = (int)reader[this.DBColumnTimeTablePurposeSysId];
			timetableentrydataToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			timetableentrydataToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				timetableentrydataToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				timetableentrydataToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return timetableentrydataToReturn;
		}

		#endregion

		#region -_ Public SQL Methods _-

		override public String CreateBaseSelect() {
			String selectCmd = "";
			selectCmd += "SELECT";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDate + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnFrom + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnTo + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnTimeTablePurposeSysId + ",";
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
			selectCmd += " ORDER BY " + this.DBTableName + "." + this.DBColumnFrom + " ASC";
			return selectCmd;
		}

		public String CreateSelectByEmployeeOnDate() {
			String selectCmd = CreateBaseSelect();
			selectCmd += " WHERE";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
			selectCmd += " AND";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDate + " = " + this.DBParameterDate;
			selectCmd += " ORDER BY " + this.DBTableName + "." + this.DBColumnFrom + " ASC";
			return selectCmd;
		}

		public String CreateSelectByEmployeeInPeriod() {
			String selectCmd = CreateBaseSelect();
			selectCmd += " WHERE";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
			selectCmd += " AND";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDate + " >= " + this.DBParameterPeriodStart;
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDate + " <= " + this.DBParameterPeriodEnd;
			selectCmd += " ORDER BY " + this.DBTableName + "." + this.DBColumnFrom + " ASC";
			return selectCmd;
		}

		public String CreateInsertCommand() {
			String insertCmd = "";
			insertCmd += "INSERT INTO " + this.DBTableName;
			insertCmd += " (" + this.DBColumnDate + " , " + this.DBColumnEmployeeSysId + " , " + this.DBColumnFrom + " , " + this.DBColumnTo + " , " + this.DBColumnTimeTablePurposeSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCmd += " VALUES";
			insertCmd += " (" + this.DBParameterDate + " , " + this.DBParameterEmployeeSysId + " , " + this.DBParameterFrom + " , " + this.DBParameterTo + " , " + this.DBParameterTimeTablePurposeSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
			insertCmd += "; ";
			insertCmd += CreateBaseSelect();
			insertCmd += " WHERE";
			insertCmd += " " + this.DBTableName + "." + this.DBColumnSysId + " = SCOPE_IDENTITY()";
			insertCmd += " ORDER BY " + this.DBTableName + "." + this.DBColumnFrom + " ASC";
			return insertCmd;
		}

		public String CreateUpdateCommand() {
			String updateCmd = "";
			updateCmd += "UPDATE " + this.DBTableName;
			updateCmd += " SET";
			updateCmd += "  " + this.DBColumnDate + " = " + this.DBParameterDate;
			updateCmd += " , " + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
			updateCmd += " , " + this.DBColumnFrom + " = " + this.DBParameterFrom;
			updateCmd += " , " + this.DBColumnTo + " = " + this.DBParameterTo;
			updateCmd += " , " + this.DBColumnTimeTablePurposeSysId + " = " + this.DBParameterTimeTablePurposeSysId;
			updateCmd += " , " + this.DBColumnEditedBy + " = " + this.DBParameterEditedBy;
			updateCmd += " , " + this.DBColumnEditedOn + " = " + this.DBParameterEditedOn;
			updateCmd += " WHERE " + this.DBColumnSysId + " = " + this.DBParameterSysId;
			updateCmd += " AND " + this.DBColumnRowVersion + " = " + this.DBParameterRowVersion;
			updateCmd += "; ";
			updateCmd += CreateBaseSelect();
			updateCmd += " WHERE";
			updateCmd += " " + this.DBTableName + "." + this.DBColumnSysId + " = " + this.DBParameterSysId;
			updateCmd += " ORDER BY " + this.DBTableName + "." + this.DBColumnFrom + " ASC";
			return updateCmd;
		}

		#endregion

	}

}
