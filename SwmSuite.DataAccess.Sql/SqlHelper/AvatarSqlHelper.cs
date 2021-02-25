using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper.Main {

	public class AvatarSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_Avatars";

		private String _dbColumnPicture = "Picture";

		private String _dbParameterPicture = "@Picture";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the picture column.
		/// </summary>
		/// <value>Columnname for the picture column.</value>
		public String DBColumnPicture { get { return _dbColumnPicture; } }

		/// <summary>
		/// Database command parameter for the picture column.
		/// </summary>
		/// <value>Command parameter for the picture column.</value>
		public String DBParameterPicture { get { return _dbParameterPicture; } }

		#endregion

		#region -_ Public Methods _-

		public AvatarData AvatarFromReader( SqlDataReader reader ) {
			AvatarData avatarToReturn = new AvatarData();
			avatarToReturn.SysId = (int)reader[this.DBColumnSysId];
			avatarToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			avatarToReturn.Picture = (byte[])reader[this.DBColumnPicture];
			avatarToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			avatarToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				avatarToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				avatarToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return avatarToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnPicture + ",";
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
			insertCommand += " (" + this.DBColumnPicture + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterPicture + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnPicture + " = " + this.DBParameterPicture;
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
