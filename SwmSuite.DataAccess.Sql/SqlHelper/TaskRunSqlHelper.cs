using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Data.Common;

namespace SwmSuite.DataAccess.Sql.SqlHelper.TaskModule {

	public class TaskRunSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_TaskRuns";

		private String _dbColumnTaskSysId = "TaskSysId";
		private String _dbColumnDateTimeFinished = "DateTimeFinished";
		private String _dbColumnRemarks = "Remarks";
		private String _dbColumnTaskRunMode = "TaskRunMode";

		private String _dbParameterTaskSysId = "@TaskSysId";
		private String _dbParameterDateTimeFinished = "@DateTimeFinished";
		private String _dbParameterRemarks = "@Remarks";
		private String _dbParameterTaskRunMode = "@TaskRunMode";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the task sysid column.
		/// </summary>
		/// <value>Columnname for the task sysid column.</value>
		public String DBColumnTaskSysId { get { return _dbColumnTaskSysId; } }
		/// <summary>
		/// Database columnname for the date time finished column.
		/// </summary>
		/// <value>Columnname for the date time finished column.</value>
		public String DBColumnDateTimeFinished { get { return _dbColumnDateTimeFinished; } }
		/// <summary>
		/// Database columnname for the remarks column.
		/// </summary>
		/// <value>Columnname for the remarks column.</value>
		public String DBColumnRemarks { get { return _dbColumnRemarks; } }
		/// <summary>
		/// Database columnname for the taskrun mode column.
		/// </summary>
		/// <value>Columnname for the taskrun mode column.</value>
		public String DBColumnTaskRunMode { get { return _dbColumnTaskRunMode; } }

		/// <summary>
		/// Database command parameter for the task sysid column.
		/// </summary>
		/// <value>Command parameter for the task sysid column.</value>
		public String DBParameterTaskSysId { get { return _dbParameterTaskSysId; } }
		/// <summary>
		/// Database command parameter for the date time finished column.
		/// </summary>
		/// <value>Command parameter for the date time finished column.</value>
		public String DBParameterDateTimeFinished { get { return _dbParameterDateTimeFinished; } }
		/// <summary>
		/// Database command parameter for the remarks column.
		/// </summary>
		/// <value>Command parameter for the remarks column.</value>
		public String DBParameterRemarks { get { return _dbParameterRemarks; } }
		/// <summary>
		/// Database command parameter for the taskrun mode column.
		/// </summary>
		/// <value>Command parameter for the taskrun mode column.</value>
		public String DBParameterTaskRunMode { get { return _dbParameterTaskRunMode; } }

		#endregion

		#region -_ Public Methods _-

		public TaskRunData TaskRunFromReader( SqlDataReader reader ) {
			TaskRunData taskrunToReturn = new TaskRunData();
			taskrunToReturn.SysId = (int)reader[this.DBColumnSysId];
			taskrunToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			taskrunToReturn.TaskSysId = (int)reader[this.DBColumnTaskSysId];
			taskrunToReturn.DateTimeFinished = (DateTime)reader[this.DBColumnDateTimeFinished];
			taskrunToReturn.Remarks = (string)reader[this.DBColumnRemarks];
			taskrunToReturn.TaskRunMode = (TaskRunMode)(byte)reader[this.DBColumnTaskRunMode];
			taskrunToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			taskrunToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				taskrunToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				taskrunToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return taskrunToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnTaskSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDateTimeFinished + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnRemarks + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnTaskRunMode + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		public String CreateSelectByTask() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnTaskSysId;
			selectCommand += " =";
			selectCommand += " " + this.DBParameterTaskSysId;
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
			insertCommand += " (" + this.DBColumnTaskSysId + " , " + this.DBColumnDateTimeFinished + " , " + this.DBColumnRemarks + " , " + this.DBColumnTaskRunMode + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterTaskSysId + " , " + this.DBParameterDateTimeFinished + " , " + this.DBParameterRemarks + " , " + this.DBParameterTaskRunMode + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += " " + this.DBColumnTaskSysId + " = " + this.DBParameterTaskSysId;
			updateCommand += " , " + this.DBColumnDateTimeFinished + " = " + this.DBParameterDateTimeFinished;
			updateCommand += " , " + this.DBColumnRemarks + " = " + this.DBParameterRemarks;
			updateCommand += " , " + this.DBColumnTaskRunMode + " = " + this.DBParameterTaskRunMode;
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
