using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Data.Common;


namespace SwmSuite.DataAccess.Sql.SqlHelper.MessageModule {

	public class MessageFolderSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_MessageFolders";

		private String _dbColumnOwnerEmployeeSysId = "OwnerEmployeeSysId";
		private String _dbColumnParentMessageFolderSysId = "ParentMessageFolderSysId";
		private String _dbColumnSpecialFolder = "SpecialFolder";
		private String _dbColumnName = "Name";
		private String _dbColumnVisible = "Visible";
		
		private String _dbParameterOwnerEmployeeSysId = "@OwnerEmployeeSysId";
		private String _dbParameterParentMessageFolderSysId = "@ParentMessageFolderSysId";
		private String _dbParameterSpecialFolder = "@SpecialFolder";
		private String _dbParameterName = "@Name";
		private String _dbParameterVisible = "@Visible";

		private String _dbParameterMessageSysId = "@MessageSysId";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the owner employee sysid column.
		/// </summary>
		/// <value>Columnname for the owner employee sysid column.</value>
		public String DBColumnOwnerEmployeeSysId { get { return _dbColumnOwnerEmployeeSysId; } }
		/// <summary>
		/// Database columnname for the parent messagefolder sysid column.
		/// </summary>
		/// <value>Columnname for the parent messagefolder sysid column.</value>
		public String DBColumnParentMessageFolderSysId { get { return _dbColumnParentMessageFolderSysId; } }
		/// <summary>
		/// Database columnname for the special folder column.
		/// </summary>
		/// <value>Columnname for the special folder column.</value>
		public String DBColumnSpecialFolder { get { return _dbColumnSpecialFolder; } }
		/// <summary>
		/// Database columnname for the name column.
		/// </summary>
		/// <value>Columnname for the name column.</value>
		public String DBColumnName { get { return _dbColumnName; } }
		/// <summary>
		/// Database columnname for the visible column.
		/// </summary>
		/// <value>Columnname for the visible column.</value>
		public String DBColumnVisible { get { return _dbColumnVisible; } }

		/// <summary>
		/// Database command parameter for the owner employee sysid column.
		/// </summary>
		/// <value>Command parameter for the owner employee sysid column.</value>
		public String DBParameterOwnerEmployeeSysId { get { return _dbParameterOwnerEmployeeSysId; } }
		/// <summary>
		/// Database command parameter for the parent messagefolder sysid column.
		/// </summary>
		/// <value>Command parameter for the parent messagefolder sysid column.</value>
		public String DBParameterParentMessageFolderSysId { get { return _dbParameterParentMessageFolderSysId; } }
		/// <summary>
		/// Database command parameter for the special folder column.
		/// </summary>
		/// <value>Command parameter for the special folder column.</value>
		public String DBParameterSpecialFolder { get { return _dbParameterSpecialFolder; } }
		/// <summary>
		/// Database command parameter for the name column.
		/// </summary>
		/// <value>Command parameter for the name column.</value>
		public String DBParameterName { get { return _dbParameterName; } }
		/// <summary>
		/// Database command parameter for the visible column.
		/// </summary>
		/// <value>Command parameter for the visible column.</value>
		public String DBParameterVisible { get { return _dbParameterVisible; } }

		/// <summary>
		/// Database command parameter for the message sysid column.
		/// </summary>
		/// <value>Command parameter for the message sysid column.</value>
		public String DBParameterMessageSysId { get { return _dbParameterMessageSysId; } }

		#endregion

		#region -_ Public Methods _-

		public MessageFolderData MessageFolderFromReader( SqlDataReader reader ) {
			MessageFolderData messagefolderToReturn = new MessageFolderData();
			messagefolderToReturn.SysId = (int)reader[this.DBColumnSysId];
			messagefolderToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			messagefolderToReturn.OwnerEmployeeSysId = (int)reader[this.DBColumnOwnerEmployeeSysId];
			if( reader[this.DBColumnParentMessageFolderSysId] != DBNull.Value ){
				messagefolderToReturn.ParentMessageFolderSysId = (int?)reader[this.DBColumnParentMessageFolderSysId];
			} else {
				messagefolderToReturn.ParentMessageFolderSysId = null;
			}
			messagefolderToReturn.SpecialFolder = (MessageSpecialFolder)(byte)reader[this.DBColumnSpecialFolder];
			messagefolderToReturn.Name = (string)reader[this.DBColumnName];
			messagefolderToReturn.Visible = (bool)reader[this.DBColumnVisible];
			messagefolderToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			messagefolderToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ){
				messagefolderToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ){
				messagefolderToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return messagefolderToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnOwnerEmployeeSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnParentMessageFolderSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSpecialFolder + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnName + ",";
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
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnOwnerEmployeeSysId + " = " + this.DBParameterOwnerEmployeeSysId + ";";
			return selectCommand;
		}

		public String CreateSelectByFolder() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnParentMessageFolderSysId + " = " + this.DBParameterParentMessageFolderSysId + ";";
			return selectCommand;
		}

		public String CreateSelectByMessage() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " INNER JOIN";
			selectCommand += " " + MessageStorageSqlHelper.SqlHelper.DBTableName;
			selectCommand += " ON";
			selectCommand += " " + MessageStorageSqlHelper.SqlHelper.DBTableName + "." + MessageStorageSqlHelper.SqlHelper.DBColumnMessageFolderSysId + " = " + this.DBTableName + "." + this.DBColumnSysId;
			selectCommand += " WHERE";
			selectCommand += " " + MessageStorageSqlHelper.SqlHelper.DBTableName + "." + MessageStorageSqlHelper.SqlHelper.DBColumnMessageSysId + " = " + this.DBParameterMessageSysId;
			selectCommand += " AND";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnOwnerEmployeeSysId + " = " + this.DBParameterOwnerEmployeeSysId;
			return selectCommand;
		}

		public String CreateSelectByEmployeeAndSpecialFolder() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnOwnerEmployeeSysId + " = " + this.DBParameterOwnerEmployeeSysId;
			selectCommand += " AND";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSpecialFolder + " = " + this.DBParameterSpecialFolder;
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
			insertCommand += " (" + this.DBColumnOwnerEmployeeSysId + " , " + this.DBColumnParentMessageFolderSysId + " , " + this.DBColumnSpecialFolder + " , " + this.DBColumnName + " , " + this.DBColumnVisible + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterOwnerEmployeeSysId + " , " + this.DBParameterParentMessageFolderSysId + " , " + this.DBParameterSpecialFolder + " , " + this.DBParameterName + " , " + this.DBParameterVisible + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnOwnerEmployeeSysId + " = " + this.DBParameterOwnerEmployeeSysId;
			updateCommand += " , " + this.DBColumnParentMessageFolderSysId + " = " + this.DBParameterParentMessageFolderSysId;
			updateCommand += " , " + this.DBColumnSpecialFolder + " = " + this.DBParameterSpecialFolder;
			updateCommand += " , " + this.DBColumnName + " = " + this.DBParameterName;
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

		#endregion

	}

}
