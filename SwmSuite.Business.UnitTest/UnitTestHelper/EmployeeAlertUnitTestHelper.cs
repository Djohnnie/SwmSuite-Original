using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {
	
	public class EmployeeAlertUnitTestHelper {

		public static void AreEqual( EmployeeAlertDataCollection expected , EmployeeAlertDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " employeealerts expected, " + actual.Count.ToString() + " employeealerts actual!" );
			// Test individual employeealerts.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].EmployeeSysId , actual[i].EmployeeSysId , "UT: expected EmployeeAlert.EmployeeSysId (" + expected[i].EmployeeSysId.ToString() + ") <> actual EmployeeAlert.EmployeeSysId (" + actual[i].EmployeeSysId.ToString() + ")!" );
				Assert.AreEqual( expected[i].AlertSysId , actual[i].AlertSysId , "UT: expected EmployeeAlert.AlertSysId (" + expected[i].AlertSysId.ToString() + ") <> actual EmployeeAlert.AlertSysId (" + actual[i].AlertSysId.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( EmployeeAlertDataCollection employeealerts ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , employeealerts.Count , "UT: " + employeealerts.Count.ToString() + " employeealerts expected in LogDeletes, " + logDeletes.Count.ToString() + " employeealerts found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new EmployeeAlertSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( employeealerts[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateEmployeeAlerts( EmployeeAlertDataCollection employeealerts ) {
			foreach( EmployeeAlertData employeealert in employeealerts ) {
				// TODO: Update code...
			}
		}

	}

}
