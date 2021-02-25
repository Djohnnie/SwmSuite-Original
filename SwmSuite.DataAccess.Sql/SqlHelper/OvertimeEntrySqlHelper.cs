using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Data.Common;

namespace SwmSuite.DataAccess.Sql.SqlHelper {

	public class OvertimeEntrySqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_OvertimeEntries";

		private String _dbColumnDescription = "Description";
		private String _dbColumnDateTimeStart = "DateTimeStart";
		private String _dbColumnDateTimeEnd = "DateTimeEnd";
		private String _dbColumnEmployeeSysId = "EmployeeSysId";
		private String _dbColumnOvertimeStatus = "OvertimeStatus";
		private String _dbColumnCommissionerSysId = "CommissionerSysId";

		private String _dbParameterDescription = "@Description";
		private String _dbParameterDateTimeStart = "@DateTimeStart";
		private String _dbParameterDateTimeEnd = "@DateTimeEnd";
		private String _dbParameterEmployeeSysId = "@EmployeeSysId";
		private String _dbParameterOvertimeStatus = "@OvertimeStatus";
		private String _dbParameterCommissionerSysId = "@CommissionerSysId";

		private String _dbParameterYear = "@Year";

		#endregion

		#region -_ Public Properties _-

		override public String DBTableName { get { return _dbTableName; } }

		public String DBColumnDescription { get { return _dbColumnDescription; } }
		public String DBColumnDateTimeStart { get { return _dbColumnDateTimeStart; } }
		public String DBColumnDateTimeEnd { get { return _dbColumnDateTimeEnd; } }
		public String DBColumnEmployeeSysId { get { return _dbColumnEmployeeSysId; } }
		public String DBColumnOvertimeStatus { get { return _dbColumnOvertimeStatus; } }
		public String DBColumnCommissionerSysId { get { return _dbColumnCommissionerSysId; } }

		public String DBParameterDescription { get { return _dbParameterDescription; } }
		public String DBParameterDateTimeStart { get { return _dbParameterDateTimeStart; } }
		public String DBParameterDateTimeEnd { get { return _dbParameterDateTimeEnd; } }
		public String DBParameterEmployeeSysId { get { return _dbParameterEmployeeSysId; } }
		public String DBParameterOvertimeStatus { get { return _dbParameterOvertimeStatus; } }
		public String DBParameterCommissionerSysId { get { return _dbParameterCommissionerSysId; } }

		public String DBParameterYear { get { return _dbParameterYear; } }

		#endregion

		#region -_ Public Methods _-

		public OvertimeEntryData OvertimeEntryDataFromReader( SqlDataReader reader ) {
			OvertimeEntryData overtimeentrydataToReturn = new OvertimeEntryData();
			overtimeentrydataToReturn.SysId = (int)reader[this.DBColumnSysId];
			overtimeentrydataToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			overtimeentrydataToReturn.Description = (string)reader[this.DBColumnDescription];
			overtimeentrydataToReturn.DateTimeStart = (DateTime)reader[this.DBColumnDateTimeStart];
			overtimeentrydataToReturn.DateTimeEnd = (DateTime)reader[this.DBColumnDateTimeEnd];
			overtimeentrydataToReturn.EmployeeSysId = (int)reader[this.DBColumnEmployeeSysId];
			overtimeentrydataToReturn.OvertimeStatus = (OvertimeStatus)(byte)reader[this.DBColumnOvertimeStatus];
			overtimeentrydataToReturn.CommissionerSysId = (int)reader[this.DBColumnCommissionerSysId];
			overtimeentrydataToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			overtimeentrydataToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				overtimeentrydataToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			} else {
				overtimeentrydataToReturn.EditedBy = Guid.Empty;
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				overtimeentrydataToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return overtimeentrydataToReturn;
		}

		#endregion

		#region -_ Public SQL Methods _-

		override public String CreateBaseSelect() {
			String selectCmd = "";
			selectCmd += "SELECT";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDescription + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDateTimeStart + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnDateTimeEnd + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnOvertimeStatus + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCommissionerSysId + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCmd += " FROM";
			selectCmd += " " + this.DBTableName;
			return selectCmd;
		}

		public String CreateSelectByEmployeeAndYear() {
			String selectCmd = CreateBaseSelect();
			selectCmd += " WHERE";
			selectCmd += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
			selectCmd += " AND";
			selectCmd += " YEAR( " + this.DBTableName + "." + this.DBColumnDateTimeStart + " ) = " + this.DBParameterYear;
			return selectCmd;
		}

		public String CreateInsertCommand() {
			String insertCmd = "";
			insertCmd += "INSERT INTO " + this.DBTableName;
			insertCmd += " (" + this.DBColumnDescription + " , " + this.DBColumnDateTimeStart + " , " + this.DBColumnDateTimeEnd + " , " + this.DBColumnEmployeeSysId + " , " + this.DBColumnOvertimeStatus + " , " + this.DBColumnCommissionerSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCmd += " VALUES";
			insertCmd += " (" + this.DBParameterDescription + " , " + this.DBParameterDateTimeStart + " , " + this.DBParameterDateTimeEnd + " , " + this.DBParameterEmployeeSysId + " , " + this.DBParameterOvertimeStatus + " , " + this.DBParameterCommissionerSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCmd += "  " + this.DBColumnDescription + " = " + this.DBParameterDescription;
			updateCmd += " , " + this.DBColumnDateTimeStart + " = " + this.DBParameterDateTimeStart;
			updateCmd += " , " + this.DBColumnDateTimeEnd + " = " + this.DBParameterDateTimeEnd;
			updateCmd += " , " + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
			updateCmd += " , " + this.DBColumnOvertimeStatus + " = " + this.DBParameterOvertimeStatus;
			updateCmd += " , " + this.DBColumnCommissionerSysId + " = " + this.DBParameterCommissionerSysId;
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
