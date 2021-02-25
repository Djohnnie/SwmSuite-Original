using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Sql.SqlHelper;
using System.Drawing;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class TimeTablePurposeUnitTestHelper {

		public static void AreEqual( TimeTablePurposeDataCollection expected , TimeTablePurposeDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " timetablepurposedatacollection expected, " + actual.Count.ToString() + " timetablepurposedatacollection actual!" );
			// Test individual timetablepurposedatacollection.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].EmployeeGroupSysId , actual[i].EmployeeGroupSysId , "UT: expected TimeTablePurposeData.EmployeeGroupSysId (" + expected[i].EmployeeGroupSysId.ToString() + ") <> actual TimeTablePurposeData.EmployeeGroupSysId (" + actual[i].EmployeeGroupSysId.ToString() + ")!" );
				Assert.AreEqual( expected[i].Description , actual[i].Description , "UT: expected TimeTablePurposeData.Description (" + expected[i].Description + ") <> actual TimeTablePurposeData.Description (" + actual[i].Description + ")!" );
				Assert.AreEqual( expected[i].LegendaColor1 , actual[i].LegendaColor1 , "UT: expected TimeTablePurposeData.LegendaColor (" + expected[i].LegendaColor1.ToString() + ") <> actual TimeTablePurposeData.LegendaColor (" + actual[i].LegendaColor1.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( TimeTablePurposeDataCollection timetablepurposedatacollection ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , timetablepurposedatacollection.Count , "UT: " + timetablepurposedatacollection.Count.ToString() + " timetablepurposedatacollection expected in LogDeletes, " + logDeletes.Count.ToString() + " timetablepurposedatacollection found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new TimeTablePurposeSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( timetablepurposedatacollection[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateTimeTablePurposeDataCollection( TimeTablePurposeDataCollection timetablepurposedatacollection ) {
			foreach( TimeTablePurposeData timetablepurposedata in timetablepurposedatacollection ) {
				timetablepurposedata.Description += " -> EDITED!";
				timetablepurposedata.LegendaColor1 += 1;
			}
		}

		public static TimeTablePurposeData GetTimeTablePurposeTestData() {
			TimeTablePurposeBll bll = new TimeTablePurposeBll();
			// Get employeegroup testdata.
			EmployeeGroupData testEmployeeGroupData = 
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			TimeTablePurposeData timeTablePurposeData =
				new TimeTablePurposeData( testEmployeeGroupData.SysId , "Purpose" , Color.Red.ToArgb() );
			TimeTablePurposeDataCollection insertedTimeTablePurposeData =
				bll.InsertTimeTablePurposeDataCollection( 
					TimeTablePurposeDataCollection.FromSingleTimeTablePurpose( timeTablePurposeData ) );
			Assert.AreEqual( 1 , insertedTimeTablePurposeData.Count );
			return insertedTimeTablePurposeData[0];
		}

	}

}
