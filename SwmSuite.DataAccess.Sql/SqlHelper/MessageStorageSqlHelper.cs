using System;
using System.Collections.Generic;

using System.Text;

using System.Data.SqlClient;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql.SqlHelper {

	public class MessageStorageSqlHelper : SqlHelperBase {

		#region -_ Singleton Pattern _-

		private static MessageStorageSqlHelper _messageStorageSqlHelper;

		/// <summary>
		/// Gets the SQL helper.
		/// </summary>
		/// <value>The SQL helper.</value>
		public static MessageStorageSqlHelper SqlHelper {
			get {
				if( _messageStorageSqlHelper == null ) {
					_messageStorageSqlHelper = new MessageStorageSqlHelper();
				}
				return _messageStorageSqlHelper;
			}
		}

		#endregion

		#region -_ Private Members _-

		private String _dbTableName = "tbl_MessageStorage";

		private String _dbColumnMessageSysId = "MessageSysId";
		private String _dbColumnMessageFolderSysId = "MessageFolderSysId";
		private String _dbColumnIsRead = "IsRead";
		private String _dbColumnIsNew = "IsNew";
		

		private String _dbParameterMessageSysId = "@MessageSysId";
		private String _dbParameterMessageFolderSysId = "@MessageFolderSysId";
		private String _dbParameterIsRead = "@IsRead";
		private String _dbParameterIsNew = "@IsNew";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the message sysid column.
		/// </summary>
		/// <value>Columnname for the message sysid column.</value>
		public String DBColumnMessageSysId { get { return _dbColumnMessageSysId; } }
		/// <summary>
		/// Database columnname for the message folder sysid column.
		/// </summary>
		/// <value>Columnname for the message folder sysid column.</value>
		public String DBColumnMessageFolderSysId { get { return _dbColumnMessageFolderSysId; } }
		/// <summary>
		/// Database columnname for the is read column.
		/// </summary>
		/// <value>Columnname for the is read column.</value>
		public String DBColumnIsRead { get { return _dbColumnIsRead; } }
		/// <summary>
		/// Database columnname for the is new column.
		/// </summary>
		/// <value>Columnname for the is new column.</value>
		public String DBColumnIsNew { get { return _dbColumnIsNew; } }

		/// <summary>
		/// Database command parameter for the message sysid column.
		/// </summary>
		/// <value>Command parameter for the message sysid column.</value>
		public String DBParameterMessageSysId { get { return _dbParameterMessageSysId; } }
		/// <summary>
		/// Database command parameter for the message folder sysid column.
		/// </summary>
		/// <value>Command parameter for the message folder sysid column.</value>
		public String DBParameterMessageFolderSysId { get { return _dbParameterMessageFolderSysId; } }
		/// <summary>
		/// Database command parameter for the is read column.
		/// </summary>
		/// <value>Command parameter for the is read column.</value>
		public String DBParameterIsRead { get { return _dbParameterIsRead; } }
		/// <summary>
		/// Database command parameter for the is new column.
		/// </summary>
		/// <value>Command parameter for the is new column.</value>
		public String DBParameterIsNew { get { return _dbParameterIsNew; } }

		#endregion

		#region -_ Public Methods _-

		public MessageStorageData MessageStorageFromReader( SqlDataReader reader ) {
			MessageStorageData messagestorageToReturn = new MessageStorageData();
			messagestorageToReturn.SysId = (int)reader[this.DBColumnSysId];
			messagestorageToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			messagestorageToReturn.MessageSysId = (int)reader[this.DBColumnMessageSysId];
			messagestorageToReturn.MessageFolderSysId = (int)reader[this.DBColumnMessageFolderSysId];
			messagestorageToReturn.IsRead = (bool)reader[this.DBColumnIsRead];
			messagestorageToReturn.IsNew = (bool)reader[this.DBColumnIsNew];
			messagestorageToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			messagestorageToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ){
				messagestorageToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ){
				messagestorageToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return messagestorageToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnMessageSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnMessageFolderSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnIsRead + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnIsNew + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		public String CreateSelectByMessageAndMessageFolder() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnMessageSysId + " = " + this.DBParameterMessageSysId;
			selectCommand += " AND";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnMessageFolderSysId + " = " + this.DBParameterMessageFolderSysId + ";";
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
			insertCommand += " (" + this.DBColumnMessageSysId + " , " + this.DBColumnMessageFolderSysId + " , " + this.DBColumnIsRead + " , " + this.DBColumnIsNew + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterMessageSysId + " , " + this.DBParameterMessageFolderSysId + " , " + this.DBParameterIsRead + " , " + this.DBParameterIsNew + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnMessageSysId + " = " + this.DBParameterMessageSysId;
			updateCommand += " , " + this.DBColumnMessageFolderSysId + " = " + this.DBParameterMessageFolderSysId;
			updateCommand += " , " + this.DBColumnIsRead + "=" + this.DBParameterIsRead;
			updateCommand += " , " + this.DBColumnIsNew + "=" + this.DBParameterIsNew;
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

		/// <summary>
		/// Creates the sql update read flag command.
		/// </summary>
		/// <returns>A string representing the command string.</returns>
		public String CreateUpdateReadFlag(){
			String updateCommand = "";
			updateCommand += "UPDATE " + this.DBTableName;
			updateCommand += " SET";
			updateCommand += " " + this.DBColumnIsRead + " = " + this.DBParameterIsRead;
			updateCommand += " WHERE " + this.DBColumnMessageSysId + " = " + this.DBParameterMessageSysId;
			updateCommand += " AND " + this.DBColumnMessageFolderSysId + " = " + this.DBParameterMessageFolderSysId;
			return updateCommand;
		}

		/// <summary>
		/// Creates the sql update new flag command.
		/// </summary>
		/// <returns>A string representing the command string.</returns>
		public String CreateUpdateNewFlag() {
			String updateCommand = "";
			updateCommand += "UPDATE " + this.DBTableName;
			updateCommand += " SET";
			updateCommand += " " + this.DBColumnIsNew + " = " + this.DBParameterIsNew;
			updateCommand += " WHERE " + this.DBColumnMessageSysId + " = " + this.DBParameterMessageSysId;
			updateCommand += " AND " + this.DBColumnMessageFolderSysId + " = " + this.DBParameterMessageFolderSysId;
			return updateCommand;
		}

		#endregion

	}

}
