using System;
using System.Collections.Generic;

using System.Text;

using System.Data.SqlClient;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql.SqlHelper.Main {

	public class EmployeeGroupSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_EmployeeGroups";

		private String _dbColumnName = "Name";
		private String _dbColumnDescription = "Description";
		private String _dbColumnVisible = "Visible";

		private String _dbParameterName = "@Name";
		private String _dbParameterDescription = "@Description";
		private String _dbParameterVisible = "@Visible";

		private String _dbParameterEmployeeSysId = "@EmployeeSysId";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the name column.
		/// </summary>
		/// <value>Columnname for the name column.</value>
		public String DBColumnName { get { return _dbColumnName; } }
		/// <summary>
		/// Database columnname for the description column.
		/// </summary>
		/// <value>Columnname for the description column.</value>
		public String DBColumnDescription { get { return _dbColumnDescription; } }
		/// <summary>
		/// Database columnname for the visible column.
		/// </summary>
		/// <value>Columnname for the visible column.</value>
		public String DBColumnVisible { get { return _dbColumnVisible; } }

		/// <summary>
		/// Database command parameter for the name column.
		/// </summary>
		/// <value>Command parameter for the name column.</value>
		public String DBParameterName { get { return _dbParameterName; } }
		/// <summary>
		/// Database command parameter for the description column.
		/// </summary>
		/// <value>Command parameter for the description column.</value>
		public String DBParameterDescription { get { return _dbParameterDescription; } }
		/// <summary>
		/// Database command parameter for the visible column.
		/// </summary>
		/// <value>Command parameter for the visible column.</value>
		public String DBParameterVisible { get { return _dbParameterVisible; } }

		/// <summary>
		/// Database command parameter for the employee sysid column.
		/// </summary>
		/// <value>Command parameter for the employee sysid column.</value>
		public String DBParameterEmployeeSysId { get { return _dbParameterEmployeeSysId; } }
		
		#endregion

		#region -_ Public Methods _-

		public EmployeeGroupData EmployeeGroupFromReader( SqlDataReader reader ) {
			EmployeeGroupData employeegroupToReturn = new EmployeeGroupData();
			employeegroupToReturn.SysId = (int)reader[this.DBColumnSysId];
			employeegroupToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			employeegroupToReturn.Name = (string)reader[this.DBColumnName];
			if( reader[this.DBColumnDescription] != DBNull.Value ) {
				employeegroupToReturn.Description = (string)reader[this.DBColumnDescription];
			} else {
				employeegroupToReturn.Description = null;
			}
			employeegroupToReturn.Visible = (bool)reader[this.DBColumnVisible];
			employeegroupToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			employeegroupToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				employeegroupToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				employeegroupToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return employeegroupToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnName + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDescription + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnVisible + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		public String CreateSelectByEmployee() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " INNER JOIN";
			selectCommand += " " + EmployeeSqlHelper.SqlHelper.DBTableName;
			selectCommand += " ON";
			selectCommand += " " + EmployeeSqlHelper.SqlHelper.DBTableName + "." + EmployeeSqlHelper.SqlHelper.DBColumnEmployeeGroupSysId + " = " + this.DBTableName + "." + this.DBColumnSysId;
			selectCommand += " WHERE";
			selectCommand += " " + EmployeeSqlHelper.SqlHelper.DBTableName + "." + EmployeeSqlHelper.SqlHelper.DBColumnSysId + " = " + this.DBParameterEmployeeSysId;
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
			insertCommand += " (" + this.DBColumnName + " , " + this.DBColumnDescription + " , " + this.DBColumnVisible + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterName + " , " + this.DBParameterDescription + " , " + this.DBParameterVisible + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnName + " = " + this.DBParameterName;
			updateCommand += " , " + this.DBColumnDescription + " = " + this.DBParameterDescription;
			updateCommand += " , " + this.DBColumnVisible + " = " + this.DBParameterVisible;
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

		public String CreateCountCommand() {
			String countCmd = "";
			countCmd += "SELECT COUNT(*)";
			countCmd += " FROM";
			countCmd += " " + this.DBTableName;
			return countCmd;
		}

		#endregion

	}

}
