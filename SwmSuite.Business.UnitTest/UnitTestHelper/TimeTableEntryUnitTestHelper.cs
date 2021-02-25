using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class TimeTableEntryDataUnitTestHelper {

		public static void AreEqual( TimeTableEntryDataCollection expected , TimeTableEntryDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " timetableentrydatacollection expected, " + actual.Count.ToString() + " timetableentrydatacollection actual!" );
			// Test individual timetableentrydatacollection.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].Date , actual[i].Date , "UT: expected TimeTableEntryData.Date (" + expected[i].Date.ToString() + ") <> actual TimeTableEntryData.Date (" + actual[i].Date.ToString() + ")!" );
				Assert.AreEqual( expected[i].EmployeeSysId , actual[i].EmployeeSysId , "UT: expected TimeTableEntryData.EmployeeSysId (" + expected[i].EmployeeSysId.ToString() + ") <> actual TimeTableEntryData.EmployeeSysId (" + actual[i].EmployeeSysId.ToString() + ")!" );
				Assert.AreEqual( expected[i].From , actual[i].From , "UT: expected TimeTableEntryData.From (" + expected[i].From.ToString() + ") <> actual TimeTableEntryData.From (" + actual[i].From.ToString() + ")!" );
				Assert.AreEqual( expected[i].To , actual[i].To , "UT: expected TimeTableEntryData.To (" + expected[i].To.ToString() + ") <> actual TimeTableEntryData.To (" + actual[i].To.ToString() + ")!" );
				Assert.AreEqual( expected[i].TimeTablePurposeSysId , actual[i].TimeTablePurposeSysId , "UT: expected TimeTableEntryData.TimeTablePurposeSysId (" + expected[i].TimeTablePurposeSysId.ToString() + ") <> actual TimeTableEntryData.TimeTablePurposeSysId (" + actual[i].TimeTablePurposeSysId.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( TimeTableEntryDataCollection timetableentrydatacollection ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , timetableentrydatacollection.Count , "UT: " + timetableentrydatacollection.Count.ToString() + " timetableentrydatacollection expected in LogDeletes, " + logDeletes.Count.ToString() + " timetableentrydatacollection found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new TimeTableEntrySqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( timetableentrydatacollection[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateTimeTableEntryDataCollection( TimeTableEntryDataCollection timetableentrydatacollection ) {
			foreach( TimeTableEntryData timetableentrydata in timetableentrydatacollection ) {
				// TODO: Update code...
			}
		}

	}

}
