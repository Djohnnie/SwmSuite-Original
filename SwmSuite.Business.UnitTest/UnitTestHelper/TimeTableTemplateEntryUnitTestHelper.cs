using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {
	
	public class TimeTableTemplateEntryUnitTestHelper {

		public static void AreEqual( TimeTableTemplateEntryDataCollection expected , TimeTableTemplateEntryDataCollection actual ) {
		// Test collection size.
		Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " timetabletemplateentries expected, " + actual.Count.ToString() + " timetabletemplateentries actual!" );
		// Test individual timetabletemplateentries.
		for( int i = 0 ; i < expected.Count ; i++ ) {
			Assert.AreEqual( expected[i].Date , actual[i].Date , "UT: expected TimeTableTemplateEntryData.Date (" + expected[i].Date.ToString() + ") <> actual TimeTableTemplateEntryData.Date (" + actual[i].Date.ToString() + ")!" );
			Assert.AreEqual( expected[i].TimeTableTemplateSysId , actual[i].TimeTableTemplateSysId , "UT: expected TimeTableTemplateEntryData.TimeTableTemplateSysId (" + expected[i].TimeTableTemplateSysId.ToString() + ") <> actual TimeTableTemplateEntryData.TimeTableTemplateSysId (" + actual[i].TimeTableTemplateSysId.ToString() + ")!" );
			Assert.AreEqual( expected[i].From , actual[i].From , "UT: expected TimeTableTemplateEntryData.From (" + expected[i].From.ToString() + ") <> actual TimeTableTemplateEntryData.From (" + actual[i].From.ToString() + ")!" );
			Assert.AreEqual( expected[i].To , actual[i].To , "UT: expected TimeTableTemplateEntryData.To (" + expected[i].To.ToString() + ") <> actual TimeTableTemplateEntryData.To (" + actual[i].To.ToString() + ")!" );
			Assert.AreEqual( expected[i].TimeTablePurposeSysId , actual[i].TimeTablePurposeSysId , "UT: expected TimeTableTemplateEntryData.TimeTablePusposeSysId (" + expected[i].TimeTablePurposeSysId.ToString() + ") <> actual TimeTableTemplateEntryData.TimeTablePusposeSysId (" + actual[i].TimeTablePurposeSysId.ToString() + ")!" );
		}
	}

		public static void AreInLogDeletes( TimeTableTemplateEntryDataCollection timetabletemplateentries ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , timetabletemplateentries.Count , "UT: " + timetabletemplateentries.Count.ToString() + " timetabletemplateentries expected in LogDeletes, " + logDeletes.Count.ToString() + " timetabletemplateentries found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new TimeTableTemplateEntrySqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( timetabletemplateentries[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateTimeTableTemplateEntries( TimeTableTemplateEntryDataCollection timetabletemplateentries ) {
			foreach( TimeTableTemplateEntryData timetabletemplateentry in timetabletemplateentries ) {
				timetabletemplateentry.Date = timetabletemplateentry.Date.AddDays( 1 );
				timetabletemplateentry.From = timetabletemplateentry.From.AddMinutes( 10 );
				timetabletemplateentry.To = timetabletemplateentry.To.AddMinutes( 10 );
			}
		}

	}

}
