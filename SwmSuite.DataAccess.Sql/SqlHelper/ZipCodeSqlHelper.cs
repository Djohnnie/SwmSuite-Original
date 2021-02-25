using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;

namespace SwmSuite.DataAccess.Sql.SqlHelper.Main {

	public class ZipCodeSqlHelper : SqlHelperBase {

		#region -_ Private Members _-

		private String _dbTableName = "tbl_ZipCodes";

		private String _dbColumnCode = "Code";
		private String _dbColumnCity = "City";
		private String _dbColumnCountrySysId = "CountrySysId";

		private String _dbParameterCode = "@Code";
		private String _dbParameterCity = "@City";
		private String _dbParameterCountrySysId = "@CountrySysId";

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the name of the Sql table.
		/// </summary>
		/// <value>The name of the Sql table.</value>
		override public String DBTableName { get { return _dbTableName; } }

		/// <summary>
		/// Database columnname for the code column.
		/// </summary>
		/// <value>Columnname for the code column.</value>
		public String DBColumnCode { get { return _dbColumnCode; } }
		/// <summary>
		/// Database columnname for the city column.
		/// </summary>
		/// <value>Columnname for the city column.</value>
		public String DBColumnCity { get { return _dbColumnCity; } }
		/// <summary>
		/// Database columnname for the country sysid column.
		/// </summary>
		/// <value>Columnname for the country sysid column.</value>
		public String DBColumnCountrySysId { get { return _dbColumnCountrySysId; } }

		/// <summary>
		/// Database command parameter for the code column.
		/// </summary>
		/// <value>Command parameter for the code column.</value>
		public String DBParameterCode { get { return _dbParameterCode; } }
		/// <summary>
		/// Database command parameter for the city column.
		/// </summary>
		/// <value>Command parameter for the city column.</value>
		public String DBParameterCity { get { return _dbParameterCity; } }
		/// <summary>
		/// Database command parameter for the country sysid column.
		/// </summary>
		/// <value>Command parameter for the country sysid column.</value>
		public String DBParameterCountrySysId { get { return _dbParameterCountrySysId; } }

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Gets zipcode dataobject from sql datareader.
		/// </summary>
		/// <param name="reader">The sql datareader.</param>
		/// <returns>Zipcode dataobject.</returns>
		public ZipCodeData ZipCodeFromReader( SqlDataReader reader ) {
			ZipCodeData zipcodeToReturn = new ZipCodeData();
			zipcodeToReturn.SysId = (int)reader[this.DBColumnSysId];
			zipcodeToReturn.RowVersion = (int)reader[this.DBColumnRowVersion];
			zipcodeToReturn.Code = (string)reader[this.DBColumnCode];
			zipcodeToReturn.City = (string)reader[this.DBColumnCity];
			zipcodeToReturn.CountrySysId = (int)reader[this.DBColumnCountrySysId];
			zipcodeToReturn.CreatedBy = (Guid)reader[this.DBColumnCreatedBy];
			zipcodeToReturn.CreatedOn = (DateTime)reader[this.DBColumnCreatedOn];
			if( reader[this.DBColumnEditedBy] != DBNull.Value ) {
				zipcodeToReturn.EditedBy = (Guid)reader[this.DBColumnEditedBy];
			}
			if( reader[this.DBColumnEditedOn] != DBNull.Value ) {
				zipcodeToReturn.EditedOn = (DateTime)reader[this.DBColumnEditedOn];
			}
			return zipcodeToReturn;
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
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCode + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCity + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCountrySysId + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCreatedOn + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedBy + ",";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnEditedOn;
			selectCommand += " FROM";
			selectCommand += " " + this.DBTableName;
			return selectCommand;
		}

		public String CreateSelectByCountry() {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " " + this.DBTableName + "." + this.DBColumnCountrySysId + " = " + this.DBParameterCountrySysId + ";";
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
			insertCommand += " (" + this.DBColumnCode + " , " + this.DBColumnCity + " , " + this.DBColumnCountrySysId + " , " + this.DBColumnCreatedBy + " , " + this.DBColumnCreatedOn + " )";
			insertCommand += " VALUES";
			insertCommand += " (" + this.DBParameterCode + " , " + this.DBParameterCity + " , " + this.DBParameterCountrySysId + " , " + this.DBParameterCreatedBy + " , " + this.DBParameterCreatedOn + " )";
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
			updateCommand += "  " + this.DBColumnCode + " = " + this.DBParameterCode;
			updateCommand += " , " + this.DBColumnCity + " = " + this.DBParameterCity;
			updateCommand += " , " + this.DBColumnCountrySysId + " = " + this.DBParameterCountrySysId;
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
