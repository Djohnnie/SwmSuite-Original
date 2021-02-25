using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper {
	
	public class TimeTableTemplateEntrySqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_TimeTableTemplateEntries";

		private String _dbColumnDate = "Date";
		private String _dbColumnTimeTableTemplateSysId = "TimeTableTemplateSysId";
		private String _dbColumnFrom = "From";
		private String _dbColumnTo = "To";
		private String _dbColumnTimeTablePusposeSysId = "TimeTablePusposeSysId";

		private String _dbParameterDate = "@Date";
		private String _dbParameterTimeTableTemplateSysId = "@TimeTableTemplateSysId";
		private String _dbParameterFrom = "@From";
		private String _dbParameterTo = "@To";
		private String _dbParameterTimeTablePusposeSysId = "@TimeTablePusposeSysId";

		#endregion

		#region -_ Public Properties _-

		override public String DBTableName { get { return _dbTableName; } }

		public String DBColumnDate { get { return _dbColumnDate; } }
		public String DBColumnTimeTableTemplateSysId { get { return _dbColumnTimeTableTemplateSysId; } }
		public String DBColumnFrom { get { return _dbColumnFrom; } }
		public String DBColumnTo { get { return _dbColumnTo; } }
		public String DBColumnTimeTablePusposeSysId { get { return _dbColumnTimeTablePusposeSysId; } }

		public String DBParameterDate { get { return _dbParameterDate; } }
		public String DBParameterTimeTableTemplateSysId { get { return _dbParameterTimeTableTemplateSysId; } }
		public String DBParameterFrom { get { return _dbParameterFrom; } }
		public String DBParameterTo { get { return _dbParameterTo; } }
		public String DBParameterTimeTablePusposeSysId { get { return _dbParameterTimeTablePusposeSysId; } }

		#endregion

		#region -_ Public Methods _-

		public TimeTableTemplateEntryData TimeTableTemplateEntryFromReader( SqlDataReader reader ) {
			TimeTableTemplateEntryData timetabletemplateentryToReturn = new TimeTableTemplateEntryData();
			timetabletemplateentryToReturn.SysId = (int)reader[this.DBColumnSysId];
			timetabletemplateentryToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			timetabletemplateentryToReturn.Date = (DateTime)reader[this.DBColumnDate];
			timetabletemplateentryToReturn.TimeTableTemplateSysId = (int)reader[this.DBColumnTimeTableTemplateSysId];
			timetabletemplateentryToReturn.From = (DateTime)reader[this.DBColumnFrom];
			timetabletemplateentryToReturn.To = (DateTime)reader[this.DBColumnTo];
			timetabletemplateentryToReturn.TimeTablePurposeSysId = (int)reader[this.DBColumnTimeTablePusposeSysId];
			timetabletemplateentryToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			timetabletemplateentryToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ){
				timetabletemplateentryToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			} else {
				timetabletemplateentryToReturn.EditedBy = Guid.Empty;
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ){
				timetabletemplateentryToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return timetabletemplateentryToReturn;
		}

		#endregion

		#region -_ Public SQL Methods _-

		override public String CreateBaseSelect() {
			String selectCmd = "";
			selectCmd += "SELECT";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDate + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnTimeTableTemplateSysId + ",";
			selectCmd += " " + this.DBTableName + ".[" + this.DBColumnFrom + "],";
			selectCmd += " " + this.DBTableName + ".[" + this.DBColumnTo + "],";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnTimeTablePusposeSysId + ",";
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
			selectCmd += " ORDER BY " + this.DBTableName + ".[" + this.DBColumnFrom + "] ASC";
			return selectCmd;
		}

		public String CreateSelectByTemplateOnDate() {
			String selectCmd = CreateBaseSelect();
			selectCmd += " WHERE";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnTimeTableTemplateSysId + " = " + this.DBParameterTimeTableTemplateSysId;
			selectCmd += " ORDER BY " + this.DBTableName + ".[" + this.DBColumnFrom + "] ASC";
			return selectCmd;
		}

		public String CreateInsertCommand() {
			String insertCmd = "";
			insertCmd += "INSERT INTO " + this.DBTableName;
			insertCmd += " (" + this.DBColumnDate + " , " + this.DBColumnTimeTableTemplateSysId + " , [" + this.DBColumnFrom + "] , [" + this.DBColumnTo + "] , " + this.DBColumnTimeTablePusposeSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCmd += " VALUES";
			insertCmd += " (" + this.DBParameterDate + " , " + this.DBParameterTimeTableTemplateSysId + " , " + this.DBParameterFrom + " , " + this.DBParameterTo + " , " + this.DBParameterTimeTablePusposeSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
			insertCmd += "; ";
			insertCmd += CreateBaseSelect();
			insertCmd += " WHERE";
			insertCmd += " " + this.DBTableName + "." + this.DBColumnSysId + " = SCOPE_IDENTITY()";
			insertCmd += " ORDER BY " + this.DBTableName + ".[" + this.DBColumnFrom + "] ASC";
			return insertCmd;
		}

		public String CreateUpdateCommand() {
			String updateCmd = "";
			updateCmd += "UPDATE " + this.DBTableName;
			updateCmd += " SET";
			updateCmd += "  " + this.DBColumnDate + " = " + this.DBParameterDate;
			//updateCmd += " , " + this.DBColumnTimeTableTemplateSysId + " = " + this.DBParameterTimeTableTemplateSysId;
			updateCmd += " , [" + this.DBColumnFrom + "] = " + this.DBParameterFrom;
			updateCmd += " , [" + this.DBColumnTo + "] = " + this.DBParameterTo;
			updateCmd += " , " + this.DBColumnTimeTablePusposeSysId + " = " + this.DBParameterTimeTablePusposeSysId;
			updateCmd += " , " + this.DBColumnEditedBy + " = " + this.DBParameterEditedBy;
			updateCmd += " , " + this.DBColumnEditedOn + " = " + this.DBParameterEditedOn;
			updateCmd += " WHERE " + this.DBColumnSysId + " = " + this.DBParameterSysId;
			updateCmd += " AND " + this.DBColumnRowVersion + " = " + this.DBParameterRowVersion;
			updateCmd += "; ";
			updateCmd += CreateBaseSelect();
			updateCmd += " WHERE";
			updateCmd += " " + this.DBTableName + "." + this.DBColumnSysId + " = " + this.DBParameterSysId;
			updateCmd += " ORDER BY " + this.DBTableName + ".[" + this.DBColumnFrom + "] ASC";
			return updateCmd;
		}

		#endregion

	}

}
