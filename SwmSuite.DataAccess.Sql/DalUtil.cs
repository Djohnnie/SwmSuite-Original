using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Globalization;

namespace SwmSuite.DataAccess.Sql {
	
	public static class DalUtil {

		public static String ConvertIntArrayToString( int[] array ){
			String stringToReturn = "";
			foreach( int i in array ){
				stringToReturn += i.ToString( CultureInfo.InvariantCulture );
				// only add a comma if this is not the last entry.
				if( Array.IndexOf( array , i ) != array.Length - 1 ){
					stringToReturn += ",";
				}
			}
			return stringToReturn;
		}

		public static String CreateLogDeleteCommand() {
			String logDeleteCmd = "";
			logDeleteCmd += "INSERT INTO";
			logDeleteCmd += " tbl_LogDelete";
			logDeleteCmd += " (TableName,Info,DeletedBy,DeletedOn)";
			logDeleteCmd += " VALUES";
			logDeleteCmd += " (@TableName,@Info,@DeletedBy,@DeletedOn)";
			return logDeleteCmd;
		}

		public static void CreateLogDeleteParameters( SqlParameterCollection parameterCollection , String tableName , String info , Guid deletedBy , DateTime deletedOn ) {
			parameterCollection.AddWithValue( "@TableName" , tableName );
			parameterCollection.AddWithValue( "@Info" , info );
			parameterCollection.AddWithValue( "@DeletedBy" , deletedBy );
			parameterCollection.AddWithValue( "@DeletedOn" , deletedOn );
		}

	}

}
