using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class TimeTableTemplateUnitTestHelper {

		public static void AreEqual( TimeTableTemplateDataCollection expected , TimeTableTemplateDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " timetabletemplates expected, " + actual.Count.ToString() + " timetabletemplates actual!" );
			// Test individual timetabletemplates.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].Name , actual[i].Name , "UT: expected TimeTableTemplateData.Name (" + expected[i].Name + ") <> actual TimeTableTemplateData.Name (" + actual[i].Name + ")!" );
				Assert.AreEqual( expected[i].Description , actual[i].Description , "UT: expected TimeTableTemplateData.Description (" + expected[i].Description + ") <> actual TimeTableTemplateData.Description (" + actual[i].Description + ")!" );
				Assert.AreEqual( expected[i].EmployeeGroupSysId , actual[i].EmployeeGroupSysId , "UT: expected TimeTableTemplateData.EmployeeGroupSysId (" + expected[i].EmployeeGroupSysId.ToString() + ") <> actual TimeTableTemplateData.EmployeeGroupSysId (" + actual[i].EmployeeGroupSysId.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( TimeTableTemplateDataCollection timetabletemplates ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , timetabletemplates.Count , "UT: " + timetabletemplates.Count.ToString() + " timetabletemplates expected in LogDeletes, " + logDeletes.Count.ToString() + " timetabletemplates found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new TimeTableTemplateSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( timetabletemplates[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateTimeTableTemplateData( TimeTableTemplateDataCollection timetabletemplates ) {
			foreach( TimeTableTemplateData timetabletemplate in timetabletemplates ) {
				timetabletemplate.Name += "-> EDITED!";
				timetabletemplate.Description += "-> EDITED!";
			}
		}


		public static TimeTableTemplateData GetTimeTableTemplateTestData() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			// Create a new purpose dataobject.
			TimeTableTemplateData timeTableTemplateToInsert =
				new TimeTableTemplateData( "Name" , "Description" , testEmployeeGroup.SysId );

			// Insert the new purpose.
			TimeTableTemplateDataCollection timeTableTemplateInserted =
				new TimeTableTemplateBll().InsertTimeTableTemplateData(
					TimeTableTemplateDataCollection.FromSingleTimeTableTemplate( timeTableTemplateToInsert ) );
			Assert.AreEqual( 1 , timeTableTemplateInserted.Count );
			return timeTableTemplateInserted[0];
		}
	}

}
