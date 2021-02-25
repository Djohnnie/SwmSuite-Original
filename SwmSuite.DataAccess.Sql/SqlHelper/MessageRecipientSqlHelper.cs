using System;
using System.Collections.Generic;

using System.Text;

using System.Data.SqlClient;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql.SqlHelper.MessageModule {

	public class MessageRecipientSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_MessageRecipients";

		private String _dbColumnMessageSysId = "MessageSysId";
		private String _dbColumnEmployeeSysId = "EmployeeSysId";
		
		private String _dbParameterMessageSysId = "@MessageSysId";
		private String _dbParameterEmployeeSysId = "@EmployeeSysId";

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
		/// Database columnname for the employee sysid column.
		/// </summary>
		/// <value>Columnname for the employee sysid column.</value>
		public String DBColumnEmployeeSysId { get { return _dbColumnEmployeeSysId; } }

		/// <summary>
		/// Database command parameter for the message sysid column.
		/// </summary>
		/// <value>Command parameter for the message sysid column.</value>
		public String DBParameterMessageSysId { get { return _dbParameterMessageSysId; } }
		/// <summary>
		/// Database command parameter for the employee sysid column.
		/// </summary>
		/// <value>Command parameter for the employee sysid column.</value>
		public String DBParameterEmployeeSysId { get { return _dbParameterEmployeeSysId; } }

		#endregion

		#region -_ Public Methods _-

		public MessageRecipientData MessageRecipientFromReader( SqlDataReader reader ) {
			MessageRecipientData messagerecipientToReturn = new MessageRecipientData();
			messagerecipientToReturn.SysId = (int)reader[this.DBColumnSysId];
			messagerecipientToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			messagerecipientToReturn.MessageSysId = (int)reader[this.DBColumnMessageSysId];
			messagerecipientToReturn.EmployeeSysId = (int)reader[this.DBColumnEmployeeSysId];
			messagerecipientToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			messagerecipientToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ){
				messagerecipientToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ){
				messagerecipientToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return messagerecipientToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + ",";
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId + ";";
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
			insertCommand += " (" + this.DBColumnMessageSysId + " , " + this.DBColumnEmployeeSysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterMessageSysId + " , " + this.DBParameterEmployeeSysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += " , " + this.DBColumnEmployeeSysId + " = " + this.DBParameterEmployeeSysId;
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
