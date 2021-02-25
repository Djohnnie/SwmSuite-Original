using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class LoginLogUnitTestHelper {

		public static void AreEqual( LoginLogDataCollection expected , LoginLogDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " loginlogdata expected, " + actual.Count.ToString() + " loginlogdata actual!" );
			// Test individual loginlogdata.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].DateTime , actual[i].DateTime , "UT: expected LoginLogData.DateTime (" + expected[i].DateTime.ToString() + ") <> actual LoginLogData.DateTime (" + actual[i].DateTime.ToString() + ")!" );
				Assert.AreEqual( expected[i].EmployeeSysId , actual[i].EmployeeSysId , "UT: expected LoginLogData.EmployeeSysId (" + expected[i].EmployeeSysId.ToString() + ") <> actual LoginLogData.EmployeeSysId (" + actual[i].EmployeeSysId.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( LoginLogDataCollection loginlogdata ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , loginlogdata.Count , "UT: " + loginlogdata.Count.ToString() + " loginlogdata expected in LogDeletes, " + logDeletes.Count.ToString() + " loginlogdata found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new LoginLogSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( loginlogdata[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateLoginLogData( LoginLogDataCollection loginlogdata ) {
			foreach( LoginLogData loginlog in loginlogdata ) {
				loginlog.DateTime = loginlog.DateTime.AddDays( 1 );
			}
		}

	}

}
