using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper {

	public class TimeTableTemplateSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_TimeTableTemplates";

		private String _dbColumnName = "Name";
		private String _dbColumnDescription = "Description";
		private String _dbColumnEmployeeGroupSysId = "EmployeeGroupSysId";

		private String _dbParameterName = "@Name";
		private String _dbParameterDescription = "@Description";
		private String _dbParameterEmployeeGroupSysId = "@EmployeeGroupSysId";

		#endregion

		#region -_ Public Properties _-

		override public String DBTableName { get { return _dbTableName; } }

		public String DBColumnName { get { return _dbColumnName; } }
		public String DBColumnDescription { get { return _dbColumnDescription; } }
		public String DBColumnEmployeeGroupSysId { get { return _dbColumnEmployeeGroupSysId; } }

		public String DBParameterName { get { return _dbParameterName; } }
		public String DBParameterDescription { get { return _dbParameterDescription; } }
		public String DBParameterEmployeeGroupSysId { get { return _dbParameterEmployeeGroupSysId; } }

		#endregion

		#region -_ Public Methods _-

		public TimeTableTemplateData TimeTableTemplateFromReader( SqlDataReader reader ) {
			TimeTableTemplateData timetabletemplateToReturn = new TimeTableTemplateData();
			timetabletemplateToReturn.SysId = (int)reader[this.DBColumnSysId];
			timetabletemplateToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			timetabletemplateToReturn.Name = (string)reader[this.DBColumnName];
			if( reader[this.DBColumnDescription] != DBNull.Value ) {
				timetabletemplateToReturn.Description = (string)reader[this.DBColumnDescription];
			}
			timetabletemplateToReturn.EmployeeGroupSysId = (int)reader[this.DBColumnEmployeeGroupSysId];
			timetabletemplateToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			timetabletemplateToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				timetabletemplateToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			} else {
				timetabletemplateToReturn.EditedBy = Guid.Empty;
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				timetabletemplateToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return timetabletemplateToReturn;
		}

		#endregion

		#region -_ Public SQL Methods _-

		override public String CreateBaseSelect() {
			String selectCmd = "";
			selectCmd += "SELECT";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnName + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDescription + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmployeeGroupSysId + ",";
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
			insertCmd += " (" + this.DBColumnName + " , " + this.DBColumnDescription + " , " + this.DBColumnEmployeeGroupSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCmd += " VALUES";
			insertCmd += " (" + this.DBParameterName + " , " + this.DBParameterDescription + " , " + this.DBParameterEmployeeGroupSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCmd += " , " + this.DBColumnDescription + " = " + this.DBParameterDescription;
			updateCmd += " , " + this.DBColumnEmployeeGroupSysId + " = " + this.DBParameterEmployeeGroupSysId;
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
