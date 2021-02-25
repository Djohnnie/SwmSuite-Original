using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper {

	//public class TimeTableAdjustmentSqlHelper : ObjectBaseSqlHelper {

	//    #region -_ Private Members _-

	//    private String _dbTableName = "tbl_TimeTableAdjustments";

	//    private String _dbColumnEmployeeSysId = "EmployeeSysId";

	//    private String _dbParameterEmployeeSysId = "@EmployeeSysId";

	//    #endregion

	//    #region -_ Public Properties _-

	//    override public String DBTableName { get { return _dbTableName; } }

	//    public String DBColumnEmployeeSysId { get { return _dbColumnEmployeeSysId; } }

	//    public String DBParameterEmployeeSysId { get { return _dbParameterEmployeeSysId; } }

	//    #endregion

	//    #region -_ Public Methods _-

	//    public TimeTableAdjustmentData TimeTableAdjustmentFromReader( SqlDataReader reader ) {
	//        TimeTableAdjustmentData timetableadjustmentdataToReturn = new TimeTableAdjustmentData();
	//        timetableadjustmentdataToReturn.SysId = (int)reader[this.DBColumnSysId];
	//        timetableadjustmentdataToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
	//        timetableadjustmentdataToReturn.EmployeeSysId = (int)reader[this.DBColumnEmployeeSysId];
	//        timetableadjustmentdataToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
	//        timetableadjustmentdataToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
	//        if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
	//            timetableadjustmentdataToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
	//        }
	//        if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
	//            timetableadjustmentdataToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
	//        }
	//        return timetableadjustmentdataToReturn;
	//    }

	//    #endregion

	//    #region -_ Public SQL Methods _-

	//    override public String CreateBaseSelect() {
	//        String selectCmd = "";
	//        selectCmd += "SELECT";
	//        selectCmd += " " + this.DBTableName + "." + this.DBColumnSysId + ",";
	//        selectCmd += " " + this.DBTableName + "." + this.DBColumnRowVersion + ",";
	//        selectCmd += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + ",";
	//        selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
	//        selectCmd += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
	//        selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
	//        selectCmd += " " + this.DBTableName + "." + this.DBColumnEditedOn;
	//        selectCmd += " FROM";
	//        selectCmd += " " + this.DBTableName;
	//        return selectCmd;
	//    }

	//    public String CreateInsertCommand() {
	//        String insertCmd = "";
	//        insertCmd += "INSERT INTO " + this.DBTableName;
	//        insertCmd += " (" + this.DBColumnEmployeeSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
	//        insertCmd += " VALUES";
	//        insertCmd += " (" + this.DBParameterEmployeeSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
	//        insertCmd += "; ";
	//        insertCmd += CreateBaseSelect();
	//        insertCmd += " WHERE";
	//        insertCmd += " " + this.DBTableName + "." + this.DBColumnSysId + " = SCOPE_IDENTITY()";
	//        return insertCmd;
	//    }

	//    public String CreateUpdateCommand() {
	//        String updateCmd = "";
	//        updateCmd += "UPDATE " + this.DBTableName;
	//        updateCmd += " SET";
	//        updateCmd += "  " + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
	//        updateCmd += " , " + this.DBColumnEditedBy + " = " + this.DBParameterEditedBy;
	//        updateCmd += " , " + this.DBColumnEditedOn + " = " + this.DBParameterEditedOn;
	//        updateCmd += " WHERE " + this.DBColumnSysId + " = " + this.DBParameterSysId;
	//        updateCmd += " AND " + this.DBColumnRowVersion + " = " + this.DBParameterRowVersion;
	//        updateCmd += "; ";
	//        updateCmd += CreateBaseSelect();
	//        updateCmd += " WHERE";
	//        updateCmd += " " + this.DBTableName + "." + this.DBColumnSysId + " = " + this.DBParameterSysId;
	//        return updateCmd;
	//    }

	//    #endregion

	//}

}
