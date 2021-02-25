using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.DataAccess.Sql.SqlHelper {

	public class AgendaSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_Agendas";

		private String _dbColumnTitle = "Title";
		private String _dbColumnDescription = "Description";
		private String _dbColumnOwnerEmployeeSysId = "OwnerEmployeeSysId";
		private String _dbColumnVisibility = "Visibility";
		private String _dbColumnColor1 = "Color1";
		private String _dbColumnColor2 = "Color2";
		private String _dbColumnColor3 = "Color3";

		private String _dbParameterTitle = "@Title";
		private String _dbParameterDescription = "@Description";
		private String _dbParameterOwnerEmployeeSysId = "@OwnerEmployeeSysId";
		private String _dbParameterVisibility = "@Visibility";
		private String _dbParameterColor1 = "@Color1";
		private String _dbParameterColor2 = "@Color2";
		private String _dbParameterColor3 = "@Color3";

		#endregion

		#region -_ Public Properties _-

		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the title column.
		/// </summary>
		/// <value>Columnname for the title column.</value>
		public String DBColumnTitle { get { return _dbColumnTitle; } }
		/// <summary>
		/// Database columnname for the description column.
		/// </summary>
		/// <value>Columnname for the description column.</value>
		public String DBColumnDescription { get { return _dbColumnDescription; } }
		/// <summary>
		/// Database columnname for the employeeSysId column.
		/// </summary>
		/// <value>Columnname for the employeeSysId column.</value>
		public String DBColumnOwnerEmployeeSysId { get { return _dbColumnOwnerEmployeeSysId; } }
		/// <summary>
		/// Database columnname for the visibility column.
		/// </summary>
		/// <value>Columnname for the visibility column.</value>
		public String DBColumnVisibility { get { return _dbColumnVisibility; } }
		/// <summary>
		/// Database columnname for the color1 column.
		/// </summary>
		public String DBColumnColor1 { get { return _dbColumnColor1; } }
		/// <summary>
		/// Database columnname for the color2 column.
		/// </summary>
		public String DBColumnColor2 { get { return _dbColumnColor2; } }
		/// <summary>
		/// Database columnname for the color3 column.
		/// </summary>
		public String DBColumnColor3 { get { return _dbColumnColor3; } }

		/// <summary>
		/// Database command parameter for the title column.
		/// </summary>
		/// <value>Command parameter for the title column.</value>
		public String DBParameterTitle { get { return _dbParameterTitle; } }
		/// <summary>
		/// Database command parameter for the description column.
		/// </summary>
		/// <value>Command parameter for the description column.</value>
		public String DBParameterDescription { get { return _dbParameterDescription; } }
		/// <summary>
		/// Database command parameter for the employeeSysId column.
		/// </summary>
		/// <value>Command parameter for the employeeSysId column.</value>
		public String DBParameterOwnerEmployeeSysId { get { return _dbParameterOwnerEmployeeSysId; } }
		/// <summary>
		/// Database command parameter for the visibility column.
		/// </summary>
		/// <value>Command parameter for the visibility column.</value>
		public String DBParameterVisibility { get { return _dbParameterVisibility; } }
		/// <summary>
		/// Database command parameter for the color1 column.
		/// </summary>
		public String DBParameterColor1 { get { return _dbParameterColor1; } }
		/// <summary>
		/// Database command parameter for the color2 column.
		/// </summary>
		public String DBParameterColor2 { get { return _dbParameterColor2; } }
		/// <summary>
		/// Database command parameter for the color3 column.
		/// </summary>
		public String DBParameterColor3 { get { return _dbParameterColor3; } }

		#endregion

		#region -_ Public Methods _-

		public AgendaData AgendaFromReader( SqlDataReader reader ) {
			AgendaData agendaToReturn = new AgendaData();
			agendaToReturn.SysId = (int)reader[this.DBColumnSysId];
			agendaToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			agendaToReturn.Title = (string)reader[this.DBColumnTitle];
			if( reader[this.DBColumnDescription] != DBNull.Value ) {
				agendaToReturn.Description = (string)reader[this.DBColumnDescription];
			} else {
				agendaToReturn.Description = null;
			}
			agendaToReturn.OwnerEmployeeSysId = (int)reader[this.DBColumnOwnerEmployeeSysId];
			agendaToReturn.Visibility = (AppointmentVisibility)(byte)reader[this.DBColumnVisibility];
			agendaToReturn.Color1 = (int)reader[this.DBColumnColor1];
			agendaToReturn.Color2 = (int)reader[this.DBColumnColor2];
			agendaToReturn.Color3 = (int)reader[this.DBColumnColor3];
			agendaToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			agendaToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				agendaToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				agendaToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return agendaToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnDescription + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnOwnerEmployeeSysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnVisibility + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnColor1 + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnColor2 + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnColor3 + ",";
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

		/// <summary>
		/// Creates the sql insert command.
		/// </summary>
		/// <returns>
		/// A string representing the command string.
		/// </returns>
		public String CreateInsertCommand() {
			String insertCommand = "";
			insertCommand += "INSERT INTO " + this.DBTableName;
			insertCommand += " (" + this.DBColumnTitle + " , " + this.DBColumnDescription + " , " + this.DBColumnOwnerEmployeeSysId + " , " + this.DBColumnVisibility + " , " + this.DBColumnColor1 + " , " + this.DBColumnColor2 + " , " + this.DBColumnColor3 + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterTitle + " , " + this.DBParameterDescription + " , " + this.DBParameterOwnerEmployeeSysId + " , " + this.DBParameterVisibility + " , " + this.DBParameterColor1 + " , " + this.DBParameterColor2 + " , " + this.DBParameterColor3 + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += " , " + this.DBColumnDescription + " = " + this.DBParameterDescription;
			updateCommand += " , " + this.DBColumnOwnerEmployeeSysId + " = " + this.DBParameterOwnerEmployeeSysId;
			updateCommand += " , " + this.DBColumnVisibility + " = " + this.DBParameterVisibility;
			updateCommand += " , " + this.DBColumnColor1 + " = " + this.DBParameterColor1;
			updateCommand += " , " + this.DBColumnColor2 + " = " + this.DBParameterColor2;
			updateCommand += " , " + this.DBColumnColor3 + " = " + this.DBParameterColor3;
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