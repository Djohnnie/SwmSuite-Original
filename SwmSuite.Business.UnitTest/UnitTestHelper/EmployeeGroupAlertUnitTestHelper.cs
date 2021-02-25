using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class EmployeeGroupAlertUnitTestHelper {

		public static void AreEqual( EmployeeGroupAlertDataCollection expected , EmployeeGroupAlertDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " employeegroupalerts expected, " + actual.Count.ToString() + " employeegroupalerts actual!" );
			// Test individual employeegroupalerts.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].EmployeeGroupSysId , actual[i].EmployeeGroupSysId , "UT: expected EmployeeGroupAlert.EmployeeGroupSysId (" + expected[i].EmployeeGroupSysId.ToString() + ") <> actual EmployeeGroupAlert.EmployeeGroupSysId (" + actual[i].EmployeeGroupSysId.ToString() + ")!" );
				Assert.AreEqual( expected[i].AlertSysId , actual[i].AlertSysId , "UT: expected EmployeeGroupAlert.AlertSysId (" + expected[i].AlertSysId.ToString() + ") <> actual EmployeeGroupAlert.AlertSysId (" + actual[i].AlertSysId.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( EmployeeGroupAlertDataCollection employeegroupalerts ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , employeegroupalerts.Count , "UT: " + employeegroupalerts.Count.ToString() + " employeegroupalerts expected in LogDeletes, " + logDeletes.Count.ToString() + " employeegroupalerts found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new EmployeeGroupAlertSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( employeegroupalerts[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateEmployeeGroupAlerts( EmployeeGroupAlertDataCollection employeegroupalerts ) {
			foreach( EmployeeGroupAlertData employeegroupalert in employeegroupalerts ) {
				// TODO: Update code...
			}
		}

	}

}