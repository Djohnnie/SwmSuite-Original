using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper.TaskModule {

	public class TaskDescriptionSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_TaskDescriptions";

		private String _dbColumnTitle = "Title";
		private String _dbColumnCreationDate = "CreationDate";
		private String _dbColumnDescription = "Description";
		private String _dbColumnDeadline = "Deadline";
		private String _dbColumnCommissionerEmployeeSysId = "CommissionerEmployeeSysId";

		private String _dbParameterTitle = "@Title";
		private String _dbParameterCreationDate = "@CreationDate";
		private String _dbParameterDescription = "@Description";
		private String _dbParameterDeadline = "@Deadline";
		private String _dbParameterCommissionerEmployeeSysId = "@CommissionerEmployeeSysId";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the title column.
		/// </summary>
		/// <value>Columnname for the title column.</value>
		public String DBColumnTitle { get { return _dbColumnTitle; } }
		/// <summary>
		/// Database columnname for the creation date column.
		/// </summary>
		/// <value>Columnname for the creation date column.</value>
		public String DBColumnCreationDate { get { return _dbColumnCreationDate; } }
		/// <summary>
		/// Database columnname for the description column.
		/// </summary>
		/// <value>Columnname for the description column.</value>
		public String DBColumnDescription { get { return _dbColumnDescription; } }
		/// <summary>
		/// Database columnname for the deadline column.
		/// </summary>
		/// <value>Columnname for the deadline column.</value>
		public String DBColumnDeadline { get { return _dbColumnDeadline; } }
		/// <summary>
		/// Database columnname for the commissioner employee sysid column.
		/// </summary>
		/// <value>Columnname for the commissioner employee sysid column.</value>
		public String DBColumnCommissionerEmployeeSysId { get { return _dbColumnCommissionerEmployeeSysId; } }

		/// <summary>
		/// Database command parameter for the title column.
		/// </summary>
		/// <value>Command parameter for the title column.</value>
		public String DBParameterTitle { get { return _dbParameterTitle; } }
		/// <summary>
		/// Database command parameter for the creation date column.
		/// </summary>
		/// <value>Command parameter for the creation date column.</value>
		public String DBParameterCreationDate { get { return _dbParameterCreationDate; } }
		/// <summary>
		/// Database command parameter for the description column.
		/// </summary>
		/// <value>Command parameter for the description column.</value>
		public String DBParameterDescription { get { return _dbParameterDescription; } }
		/// <summary>
		/// Database command parameter for the deadline column.
		/// </summary>
		/// <value>Command parameter for the deadline column.</value>
		public String DBParameterDeadline { get { return _dbParameterDeadline; } }
		/// <summary>
		/// Database command parameter for the commissioner employee sysid column.
		/// </summary>
		/// <value>Command parameter for the commissioner employee sysid column.</value>
		public String DBParameterCommissionerEmployeeSysId { get { return _dbParameterCommissionerEmployeeSysId; } }

		#endregion

		#region -_ Public Methods _-

		public TaskDescriptionData TaskDescriptionFromReader( SqlDataReader reader ) {
			TaskDescriptionData taskdescriptionToReturn = new TaskDescriptionData();
			taskdescriptionToReturn.SysId = (int)reader[this.DBColumnSysId];
			taskdescriptionToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			taskdescriptionToReturn.Title = (string)reader[this.DBColumnTitle];
			taskdescriptionToReturn.CreationDate = (DateTime)reader[this.DBColumnCreationDate];
			if( reader[this.DBColumnDescription] != DBNull.Value ) {
				taskdescriptionToReturn.Description = (string)reader[this.DBColumnDescription];
			} else {
				taskdescriptionToReturn.Description = null;
			}
			if( reader[this.DBColumnDeadline] != DBNull.Value ) {
				taskdescriptionToReturn.Deadline = (DateTime?)reader[this.DBColumnDeadline];
			} else {
				taskdescriptionToReturn.Deadline = null;
			}
			taskdescriptionToReturn.CommissionerEmployeeSysId = (int)reader[this.DBColumnCommissionerEmployeeSysId];
			taskdescriptionToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			taskdescriptionToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				taskdescriptionToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				taskdescriptionToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return taskdescriptionToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnTitle + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreationDate + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDescription + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDeadline + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCommissionerEmployeeSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
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
			insertCommand += " (" + this.DBColumnTitle + " , " + this.DBColumnCreationDate + " , " + this.DBColumnDescription + " , " + this.DBColumnDeadline + " , " + this.DBColumnCommissionerEmployeeSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterTitle + " , " + this.DBParameterCreationDate + " , " + this.DBParameterDescription + " , " + this.DBParameterDeadline + " , " + this.DBParameterCommissionerEmployeeSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnTitle + " = " + this.DBParameterTitle;
			updateCommand += " , " + this.DBColumnCreationDate + " = " + this.DBParameterCreationDate;
			updateCommand += " , " + this.DBColumnDescription + " = " + this.DBParameterDescription;
			updateCommand += " , " + this.DBColumnDeadline + " = " + this.DBParameterDeadline;
			updateCommand += " , " + this.DBColumnCommissionerEmployeeSysId + " = " + this.DBParameterCommissionerEmployeeSysId;
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
