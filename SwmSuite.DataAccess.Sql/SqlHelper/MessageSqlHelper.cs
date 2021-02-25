using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Data.Common;


namespace SwmSuite.DataAccess.Sql.SqlHelper.MessageModule {

	public class MessageSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private MessageStorageSqlHelper _messageStorageSqlHelper = new MessageStorageSqlHelper();

		private String _dbTableName = "tbl_Messages";

		private String _dbColumnDate = "Date";
		private String _dbColumnSubject = "Subject";
		private String _dbColumnContent = "Content";
		private String _dbColumnFromEmployeeSysId = "FromEmployeeSysId";
		private String _dbColumnPriority = "Priority";
		private String _dbColumnVisible = "Visible";

		private String _dbParameterDate = "@Date";
		private String _dbParameterSubject = "@Subject";
		private String _dbParameterContent = "@Content";
		private String _dbParameterFromEmployeeSysId = "@FromEmployeeSysId";
		private String _dbParameterPriority = "@Priority";
		private String _dbParameterVisible = "@Visible";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the date column.
		/// </summary>
		/// <value>Columnname for the date column.</value>
		public String DBColumnDate { get { return _dbColumnDate; } }
		/// <summary>
		/// Database columnname for the subject column.
		/// </summary>
		/// <value>Columnname for the subject column.</value>
		public String DBColumnSubject { get { return _dbColumnSubject; } }
		/// <summary>
		/// Database columnname for the content column.
		/// </summary>
		/// <value>Columnname for the content column.</value>
		public String DBColumnContent { get { return _dbColumnContent; } }
		/// <summary>
		/// Database columnname for the from employee sysid column.
		/// </summary>
		/// <value>Columnname for the from employee sysid column.</value>
		public String DBColumnFromEmployeeSysId { get { return _dbColumnFromEmployeeSysId; } }
		/// <summary>
		/// Database columnname for the priority column.
		/// </summary>
		/// <value>Columnname for the priority column.</value>
		public String DBColumnPriority { get { return _dbColumnPriority; } }
		/// <summary>
		/// Database columnname for the visible column.
		/// </summary>
		/// <value>Columnname for the visible column.</value>
		public String DBColumnVisible { get { return _dbColumnVisible; } }

		/// <summary>
		/// Database command parameter for the date column.
		/// </summary>
		/// <value>Command parameter for the date column.</value>
		public String DBParameterDate { get { return _dbParameterDate; } }
		/// <summary>
		/// Database command parameter for the subject column.
		/// </summary>
		/// <value>Command parameter for the subject column.</value>
		public String DBParameterSubject { get { return _dbParameterSubject; } }
		/// <summary>
		/// Database command parameter for the content column.
		/// </summary>
		/// <value>Command parameter for the content column.</value>
		public String DBParameterContent { get { return _dbParameterContent; } }
		/// <summary>
		/// Database command parameter for the from employee sysid column.
		/// </summary>
		/// <value>Command parameter for the from employee sysid column.</value>
		public String DBParameterFromEmployeeSysId { get { return _dbParameterFromEmployeeSysId; } }
		/// <summary>
		/// Database command parameter for the priority column.
		/// </summary>
		/// <value>Command parameter for the priority column.</value>
		public String DBParameterPriority { get { return _dbParameterPriority; } }
		/// <summary>
		/// Database command parameter for the visible column.
		/// </summary>
		/// <value>Command parameter for the visible column.</value>
		public String DBParameterVisible { get { return _dbParameterVisible; } }

		#endregion

		#region -_ Public Methods _-

		public MessageData MessageFromReader( SqlDataReader reader ) {
			MessageData messageToReturn = new MessageData();
			messageToReturn.SysId = (int)reader[this.DBColumnSysId];
			messageToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			messageToReturn.Date = (DateTime)reader[this.DBColumnDate];
			if( reader[this.DBColumnSubject] != DBNull.Value ) {
				messageToReturn.Subject = (string)reader[this.DBColumnSubject];
			} else {
				messageToReturn.Subject = null;
			}
			if( reader[this.DBColumnContent] != DBNull.Value ) {
				messageToReturn.Content = (string)reader[this.DBColumnContent];
			} else {
				messageToReturn.Content = null;
			}
			messageToReturn.FromEmployeeSysId = (int)reader[this.DBColumnFromEmployeeSysId];
			messageToReturn.Priority = (MessagePriority)(byte)reader[this.DBColumnPriority];
			messageToReturn.Visible = (bool)reader[this.DBColumnVisible];
			messageToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			messageToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				messageToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				messageToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return messageToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDate + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSubject + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnContent + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnFromEmployeeSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnPriority + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnVisible + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		public String CreateSelect() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " ORDER BY";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDate + " DESC";
			return selectCommand;
		}

		public String CreateSelectByEmployee() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnFromEmployeeSysId + " = " + this.DBParameterFromEmployeeSysId;
			selectCommand += " ORDER BY";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDate + " DESC";
			return selectCommand;
		}

		public String CreateSelectByMessageFolder() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " LEFT OUTER JOIN";
			selectCommand += " " + _messageStorageSqlHelper.DBTableName;
			selectCommand += " ON";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSysId + " = " + _messageStorageSqlHelper.DBTableName + "." + _messageStorageSqlHelper.DBColumnMessageSysId;
			selectCommand += " WHERE";
			selectCommand += " " + _messageStorageSqlHelper.DBTableName + "." + _messageStorageSqlHelper.DBColumnMessageFolderSysId + " = " + _messageStorageSqlHelper.DBParameterMessageFolderSysId;
			selectCommand += " ORDER BY";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDate + " DESC";
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
			insertCommand += " (" + this.DBColumnDate + " , " + this.DBColumnSubject + " , " + this.DBColumnContent + " , " + this.DBColumnFromEmployeeSysId + " , " + this.DBColumnPriority + " , " + this.DBColumnVisible + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterDate + " , " + this.DBParameterSubject + " , " + this.DBParameterContent + " , " + this.DBParameterFromEmployeeSysId + " , " + this.DBParameterPriority + " , " + this.DBParameterVisible + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnDate + " = " + this.DBParameterDate;
			updateCommand += " , " + this.DBColumnSubject + " = " + this.DBParameterSubject;
			updateCommand += " , " + this.DBColumnContent + " = " + this.DBParameterContent;
			updateCommand += " , " + this.DBColumnFromEmployeeSysId + " = " + this.DBParameterFromEmployeeSysId;
			updateCommand += " , " + this.DBColumnPriority + " = " + this.DBParameterPriority;
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