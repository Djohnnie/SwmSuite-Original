using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.DataAccess.Sql.SqlHelper {
	
	public abstract class SqlHelperBase {

		#region -_ Private Members _-

		private String _dbColumnSysId = "SysId";
		private String _dbColumnRowVersion = "RowVersion";
		private String _dbColumnCreatedBy = "CreatedBy";
		private String _dbColumnCreatedOn = "CreatedOn";
		private String _dbColumnEditedBy = "EditedBy";
		private String _dbColumnEditedOn = "EditedOn";

		private String _dbParameterSysId = "@SysId";
		private String _dbParameterRowVersion = "@RowVersion";
		private String _dbParameterCreatedBy = "@CreatedBy";
		private String _dbParameterCreatedOn = "@CreatedOn";
		private String _dbParameterEditedBy = "@EditedBy";
		private String _dbParameterEditedOn = "@EditedOn";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		public abstract String DBTableName { get; }

		/// <summary>
		/// Database columnname for the sysid column.
		/// </summary>
		/// <value>Columnname for the sysid column.</value>
		public String DBColumnSysId { get { return _dbColumnSysId; } }
		/// <summary>
		/// Database columnname for the rowversion column.
		/// </summary>
		/// <value>Columnname for the rowversion column.</value>
		public String DBColumnRowVersion { get { return _dbColumnRowVersion; } }
		/// <summary>
		/// Database columnname for the created by column.
		/// </summary>
		/// <value>Columnname for the created by column.</value>
		public String DBColumnCreatedBy { get { return _dbColumnCreatedBy; } }
		/// <summary>
		/// Database columnname for the created on column.
		/// </summary>
		/// <value>Columnname for the created on column.</value>
		public String DBColumnCreatedOn { get { return _dbColumnCreatedOn; } }
		/// <summary>
		/// Database columnname for the edited by column.
		/// </summary>
		/// <value>Columnname for the edited by column.</value>
		public String DBColumnEditedBy { get { return _dbColumnEditedBy; } }
		/// <summary>
		/// Database columnname for the edited on column.
		/// </summary>
		/// <value>Columnname for the edited on column.</value>
		public String DBColumnEditedOn { get { return _dbColumnEditedOn; } }

		/// <summary>
		/// Database command parameter for the sysid column.
		/// </summary>
		/// <value>Command parameter for the sysid column.</value>
		public String DBParameterSysId { get { return _dbParameterSysId; } }
		/// <summary>
		/// Database command parameter for the rowversion column.
		/// </summary>
		/// <value>Command parameter for the rowversion column.</value>
		public String DBParameterRowVersion { get { return _dbParameterRowVersion; } }
		/// <summary>
		/// Database command parameter for the created by column.
		/// </summary>
		/// <value>Command parameter for the created by column.</value>
		public String DBParameterCreatedBy { get { return _dbParameterCreatedBy; } }
		/// <summary>
		/// Database command parameter for the created on column.
		/// </summary>
		/// <value>Command parameter for the created on column.</value>
		public String DBParameterCreatedOn { get { return _dbParameterCreatedOn; } }
		/// <summary>
		/// Database command parameter for the edited by column.
		/// </summary>
		/// <value>Command parameter for the edited by column.</value>
		public String DBParameterEditedBy { get { return _dbParameterEditedBy; } }
		/// <summary>
		/// Database command parameter for the edited on column.
		/// </summary>
		/// <value>Command parameter for the edited on column.</value>
		public String DBParameterEditedOn { get { return _dbParameterEditedOn; } }

		#endregion

		#region -_ Public SQL Methods _-

		/// <summary>
		/// Creates the sql base select command.
		/// </summary>
		/// <returns>
		/// A string representing the command string.
		/// </returns>
		public abstract String CreateBaseSelect();

		/// <summary>
		/// Creates the sql select by sysids command.
		/// </summary>
		/// <param name="sysIds">The internal ids to select.</param>
		/// <returns>A string representing the sql commandstring.</returns>
		public String CreateSelectBySysIds( int[] sysIds ) {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnSysId;
			selectCommand += " IN (";
			selectCommand += DalUtil.ConvertIntArrayToString( sysIds );
			selectCommand += ")";
			return selectCommand;
		}

		/// <summary>
		/// Creates the sql delete command.
		/// </summary>
		/// <returns>A string representing the sql commandstring.</returns>
		public String CreateDeleteCommand() {
			String deleteCmd = "";
			deleteCmd += "DELETE FROM " + this.DBTableName;
			deleteCmd += " WHERE " + this.DBColumnSysId + " = " + this.DBParameterSysId;
			deleteCmd += " AND " + this.DBColumnRowVersion + " = " + this.DBParameterRowVersion;
			deleteCmd += ";";
			deleteCmd += DalUtil.CreateLogDeleteCommand();
			return deleteCmd;
		}

		/// <summary>
		/// Creates the sql delete all command.
		/// </summary>
		/// <returns>A string representing the sql commandstring.</returns>
		public String CreateDeleteAllCommand() {
			String deleteCmd = "";
			deleteCmd += "DELETE FROM " + this.DBTableName;
			return deleteCmd;
		}

		#endregion

	}
}
