using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper {
	
	public class TimeTablePurposeSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_TimeTablePurposes";

		private String _dbColumnEmployeeGroupSysId = "EmployeeGroupSysId";
		private String _dbColumnPurposeDescription = "PurposeDescription";
		private String _dbColumnLegendaColor1 = "LegendaColor1";
		private String _dbColumnLegendaColor2 = "LegendaColor2";
		private String _dbColumnLegendaColor3 = "LegendaColor3";

		private String _dbParameterEmployeeGroupSysId = "@EmployeeGroupSysId";
		private String _dbParameterPurposeDescription = "@PurposeDescription";
		private String _dbParameterLegendaColor1 = "@LegendaColor1";
		private String _dbParameterLegendaColor2 = "@LegendaColor2";
		private String _dbParameterLegendaColor3 = "@LegendaColor3";

		#endregion

		#region -_ Public Properties _-

		override public String DBTableName { get { return _dbTableName; } }

		public String DBColumnEmployeeGroupSysId { get { return _dbColumnEmployeeGroupSysId; } }
		public String DBColumnPurposeDescription { get { return _dbColumnPurposeDescription; } }
		public String DBColumnLegendaColor1 { get { return _dbColumnLegendaColor1; } }
		public String DBColumnLegendaColor2 { get { return _dbColumnLegendaColor2; } }
		public String DBColumnLegendaColor3 { get { return _dbColumnLegendaColor3; } }

		public String DBParameterEmployeeGroupSysId { get { return _dbParameterEmployeeGroupSysId; } }
		public String DBParameterPurposeDescription { get { return _dbParameterPurposeDescription; } }
		public String DBParameterLegendaColor1 { get { return _dbParameterLegendaColor1; } }
		public String DBParameterLegendaColor2 { get { return _dbParameterLegendaColor2; } }
		public String DBParameterLegendaColor3 { get { return _dbParameterLegendaColor3; } }

		#endregion

		#region -_ Public Methods _-

		public TimeTablePurposeData TimeTablePurposeFromReader( SqlDataReader reader ) {
			TimeTablePurposeData timetablepurposedataToReturn = new TimeTablePurposeData();
			timetablepurposedataToReturn.SysId = (int)reader[this.DBColumnSysId];
			timetablepurposedataToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			timetablepurposedataToReturn.EmployeeGroupSysId = (int)reader[this.DBColumnEmployeeGroupSysId];
			if( reader[this.DBColumnPurposeDescription] != DBNull.Value ){
				timetablepurposedataToReturn.Description = (string)reader[this.DBColumnPurposeDescription];
			}
			timetablepurposedataToReturn.LegendaColor1 = (int)reader[this.DBColumnLegendaColor1];
			timetablepurposedataToReturn.LegendaColor2 = (int)reader[this.DBColumnLegendaColor2];
			timetablepurposedataToReturn.LegendaColor3 = (int)reader[this.DBColumnLegendaColor3];
			timetablepurposedataToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			timetablepurposedataToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ){
				timetablepurposedataToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ){
				timetablepurposedataToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return timetablepurposedataToReturn;
		}

		#endregion

		#region -_ Public SQL Methods _-

		override public String CreateBaseSelect() {
			String selectCmd = "";
			selectCmd += "SELECT";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmployeeGroupSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnPurposeDescription + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnLegendaColor1 + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnLegendaColor2 + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnLegendaColor3 + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCmd += " FROM";
			selectCmd += " " + this.DBTableName;
			return selectCmd;
		}

		public String CreateSelectByEmployeeGroup() {
			String selectCmd = CreateBaseSelect();
			selectCmd += " WHERE";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmployeeGroupSysId + " = " + this.DBParameterEmployeeGroupSysId;
			return selectCmd;
		}

		public String CreateInsertCommand() {
			String insertCmd = "";
			insertCmd += "INSERT INTO " + this.DBTableName;
			insertCmd += " (" + this.DBColumnEmployeeGroupSysId + " , " + this.DBColumnPurposeDescription + " , " + this.DBColumnLegendaColor1 + " , " + this.DBColumnLegendaColor2 + " , " + this.DBColumnLegendaColor3 + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCmd += " VALUES";
			insertCmd += " (" + this.DBParameterEmployeeGroupSysId + " , " + this.DBParameterPurposeDescription + " , " + this.DBParameterLegendaColor1 + " , " + this.DBParameterLegendaColor2 + " , " + this.DBParameterLegendaColor3 + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCmd += "  " + this.DBColumnEmployeeGroupSysId + " = " + this.DBParameterEmployeeGroupSysId;
			updateCmd += " , " + this.DBColumnPurposeDescription + " = " + this.DBParameterPurposeDescription;
			updateCmd += " , " + this.DBColumnLegendaColor1 + " = " + this.DBParameterLegendaColor1;
			updateCmd += " , " + this.DBColumnLegendaColor2 + " = " + this.DBParameterLegendaColor2;
			updateCmd += " , " + this.DBColumnLegendaColor3 + " = " + this.DBParameterLegendaColor3;
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