using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class OvertimeEntryUnitTestHelper {

		public static void AreEqual( OvertimeEntryDataCollection expected , OvertimeEntryDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " overtimeentrydata expected, " + actual.Count.ToString() + " overtimeentrydata actual!" );
			// Test individual overtimeentrydata.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].Description , actual[i].Description , "UT: expected OvertimeEntryData.Description (" + expected[i].Description + ") <> actual OvertimeEntryData.Description (" + actual[i].Description + ")!" );
				Assert.AreEqual( expected[i].DateTimeStart , actual[i].DateTimeStart , "UT: expected OvertimeEntryData.DateTimeStart (" + expected[i].DateTimeStart.ToString() + ") <> actual OvertimeEntryData.DateTimeStart (" + actual[i].DateTimeStart.ToString() + ")!" );
				Assert.AreEqual( expected[i].DateTimeEnd , actual[i].DateTimeEnd , "UT: expected OvertimeEntryData.DateTimeEnd (" + expected[i].DateTimeEnd.ToString() + ") <> actual OvertimeEntryData.DateTimeEnd (" + actual[i].DateTimeEnd.ToString() + ")!" );
				Assert.AreEqual( expected[i].EmployeeSysId , actual[i].EmployeeSysId , "UT: expected OvertimeEntryData.EmployeeSysId (" + expected[i].EmployeeSysId.ToString() + ") <> actual OvertimeEntryData.EmployeeSysId (" + actual[i].EmployeeSysId.ToString() + ")!" );
				Assert.AreEqual( expected[i].OvertimeStatus , actual[i].OvertimeStatus , "UT: expected OvertimeEntryData.OvertimeStatus (" + expected[i].OvertimeStatus.ToString() + ") <> actual OvertimeEntryData.OvertimeStatus (" + actual[i].OvertimeStatus.ToString() + ")!" );
				Assert.AreEqual( expected[i].CommissionerSysId , actual[i].CommissionerSysId , "UT: expected OvertimeEntryData.CommissionerSysId (" + expected[i].CommissionerSysId.ToString() + ") <> actual OvertimeEntryData.CommissionerSysId (" + actual[i].CommissionerSysId.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( OvertimeEntryDataCollection overtimeentrydata ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , overtimeentrydata.Count , "UT: " + overtimeentrydata.Count.ToString() + " overtimeentrydata expected in LogDeletes, " + logDeletes.Count.ToString() + " overtimeentrydata found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new OvertimeEntrySqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( overtimeentrydata[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateOvertimeEntryData( OvertimeEntryDataCollection overtimeEntryData ) {
			foreach( OvertimeEntryData overtimeEntry in overtimeEntryData ) {
				overtimeEntry.Description += " -> EDITED!";
				overtimeEntry.DateTimeStart = overtimeEntry.DateTimeStart.AddDays( 1 );
				overtimeEntry.DateTimeEnd = overtimeEntry.DateTimeEnd.AddDays( 1 );
			}
		}

	}

}
