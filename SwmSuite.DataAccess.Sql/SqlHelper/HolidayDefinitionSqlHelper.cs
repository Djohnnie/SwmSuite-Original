using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql.SqlHelper {
	
	public class HolidayDefinitionSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_HolidayDefinitions";

		private String _dbColumnName = "Name";
		private String _dbColumnRecurringHoliday = "RecurringHoliday";
		private String _dbColumnDateStart = "DateStart";
		private String _dbColumnDateEnd = "DateEnd";

		private String _dbParameterName = "@Name";
		private String _dbParameterRecurringHoliday = "@RecurringHoliday";
		private String _dbParameterDateStart = "@DateStart";
		private String _dbParameterDateEnd = "@DateEnd";

		#endregion

		#region -_ Public Properties _-

		override public String DBTableName { get { return _dbTableName; } }

		public String DBColumnName { get { return _dbColumnName; } }
		public String DBColumnRecurringHoliday { get { return _dbColumnRecurringHoliday; } }
		public String DBColumnDateStart { get { return _dbColumnDateStart; } }
		public String DBColumnDateEnd { get { return _dbColumnDateEnd; } }

		public String DBParameterName { get { return _dbParameterName; } }
		public String DBParameterRecurringHoliday { get { return _dbParameterRecurringHoliday; } }
		public String DBParameterDateStart { get { return _dbParameterDateStart; } }
		public String DBParameterDateEnd { get { return _dbParameterDateEnd; } }

		#endregion

		#region -_ Public Methods _-

		public HolidayDefinitionData HolidayDefinitionFromReader( SqlDataReader reader ) {
			HolidayDefinitionData holidaydefinitionToReturn = new HolidayDefinitionData();
			holidaydefinitionToReturn.SysId = (int)reader[this.DBColumnSysId];
			holidaydefinitionToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			holidaydefinitionToReturn.Name = (string)reader[this.DBColumnName];
			holidaydefinitionToReturn.RecurringHoliday = (bool)reader[this.DBColumnRecurringHoliday];
			holidaydefinitionToReturn.DateStart = (DateTime)reader[this.DBColumnDateStart];
			holidaydefinitionToReturn.DateEnd = (DateTime)reader[this.DBColumnDateEnd];
			holidaydefinitionToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			holidaydefinitionToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				holidaydefinitionToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			} else {
				holidaydefinitionToReturn.EditedBy = Guid.Empty;
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				holidaydefinitionToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return holidaydefinitionToReturn;
		}

		#endregion

		#region -_ Public SQL Methods _-

		override public String CreateBaseSelect() {
			String selectCmd = "";
			selectCmd += "SELECT";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnName + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnRecurringHoliday + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDateStart + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDateEnd + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCmd += " FROM";
			selectCmd += " " + this.DBTableName;
			return selectCmd;
		}

		public String CreateInsertCommand() {
			String insertCmd = "";
			insertCmd += "INSERT INTO " + this.DBTableName;
			insertCmd += " (" + this.DBColumnName + " , " + this.DBColumnRecurringHoliday + " , " + this.DBColumnDateStart + " , " + this.DBColumnDateEnd + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCmd += " VALUES";
			insertCmd += " (" + this.DBParameterName + " , " + this.DBParameterRecurringHoliday + " , " + this.DBParameterDateStart + " , " + this.DBParameterDateEnd + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCmd += "  " + this.DBColumnName + " = " + this.DBParameterName;
			updateCmd += " , " + this.DBColumnRecurringHoliday + " = " + this.DBParameterRecurringHoliday;
			updateCmd += " , " + this.DBColumnDateStart + " = " + this.DBParameterDateStart;
			updateCmd += " , " + this.DBColumnDateEnd + " = " + this.DBParameterDateEnd;
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
