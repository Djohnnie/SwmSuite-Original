using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper.TaskModule {

	public class TaskSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private TaskDescriptionSqlHelper _taskDescriptionSqlHelper = new TaskDescriptionSqlHelper();
		private TaskRunSqlHelper _taskRunSqlHelper = new TaskRunSqlHelper();

		private String _dbTableName = "tbl_Tasks";

		private String _dbColumnEmployeeSysId = "EmployeeSysId";
		private String _dbColumnTaskDescriptionSysId = "TaskDescriptionSysId";

		private String _dbParameterEmployeeSysId = "@EmployeeSysId";
		private String _dbParameterTaskDescriptionSysId = "@TaskDescriptionSysId";

		private String _dbParameterYear = "@Year";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the employee sysid column.
		/// </summary>
		/// <value>Columnname for the employee sysid column.</value>
		public String DBColumnEmployeeSysId { get { return _dbColumnEmployeeSysId; } }
		/// <summary>
		/// Database columnname for the taskdescription sysid column.
		/// </summary>
		/// <value>Columnname for the taskdescription sysid column.</value>
		public String DBColumnTaskDescriptionSysId { get { return _dbColumnTaskDescriptionSysId; } }

		/// <summary>
		/// Database command parameter for the employee sysid column.
		/// </summary>
		/// <value>Command parameter for the employee sysid column.</value>
		public String DBParameterEmployeeSysId { get { return _dbParameterEmployeeSysId; } }
		/// <summary>
		/// Database command parameter for the taskdescription sysid column.
		/// </summary>
		/// <value>Command parameter for the taskdescription sysid column.</value>
		public String DBParameterTaskDescriptionSysId { get { return _dbParameterTaskDescriptionSysId; } }

		/// <summary>
		/// Database year command parameter.
		/// </summary>
		/// <value>The year database parameter.</value>
		public String DBParameterYear { get { return _dbParameterYear; } }

		#endregion

		#region -_ Public Methods _-

		public TaskData TaskFromReader( SqlDataReader reader ) {
			TaskData taskToReturn = new TaskData();
			taskToReturn.SysId = (int)reader[this.DBColumnSysId];
			taskToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			taskToReturn.EmployeeSysId = (int)reader[this.DBColumnEmployeeSysId];
			taskToReturn.TaskDescriptionSysId = (int)reader[this.DBColumnTaskDescriptionSysId];
			taskToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			taskToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				taskToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				taskToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return taskToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnTaskDescriptionSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		public String CreateSelectByEmployee() {
			String selectCommand = "";
			selectCommand += CreateBaseSelect();
			selectCommand += " INNER JOIN";
			selectCommand += " " + _taskDescriptionSqlHelper.DBTableName + " ON " + this.DBTableName + "." + this.DBColumnTaskDescriptionSysId + " = " + _taskDescriptionSqlHelper.DBTableName + "." + _taskDescriptionSqlHelper.DBColumnSysId;
			selectCommand += " LEFT OUTER JOIN";
			selectCommand += " " + _taskRunSqlHelper.DBTableName + " ON " + this.DBTableName + "." + this.DBColumnSysId + " = " + _taskRunSqlHelper.DBTableName + "." + _taskRunSqlHelper.DBColumnTaskSysId;
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
			selectCommand += " AND (";
			selectCommand += " YEAR( " + this.DBTableName + "." + this.DBColumnCreatedOn + " ) = " + this.DBParameterYear;
			selectCommand += " OR";
			selectCommand += " YEAR( " + _taskDescriptionSqlHelper.DBTableName + "." + _taskDescriptionSqlHelper.DBColumnDeadline + " ) = " + this.DBParameterYear;
			selectCommand += " OR";
			selectCommand += " YEAR( " + _taskRunSqlHelper.DBTableName + "." + _taskRunSqlHelper.DBColumnDateTimeFinished + " ) = " + this.DBParameterYear;
			selectCommand += " )";
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
			insertCommand += " (" + this.DBColumnEmployeeSysId + " , " + this.DBColumnTaskDescriptionSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterEmployeeSysId + " , " + this.DBParameterTaskDescriptionSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
			updateCommand += " , " + this.DBColumnTaskDescriptionSysId + " = " + this.DBParameterTaskDescriptionSysId;
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
