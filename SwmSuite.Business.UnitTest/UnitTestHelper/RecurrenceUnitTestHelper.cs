using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Business;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class RecurrenceUnitTestHelper {

		public static void AreEqual( RecurrenceDataCollection expected , RecurrenceDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " recurrences expected, " + actual.Count.ToString() + " recurrences actual!" );
			// Test individual recurrences.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].RecurrenceMode , actual[i].RecurrenceMode , "UT: expected Recurrence.RecurrenceMode (" + expected[i].RecurrenceMode.ToString() + ") <> actual Recurrence.RecurrenceMode (" + actual[i].RecurrenceMode.ToString() + ")!" );
				Assert.AreEqual( expected[i].Every , actual[i].Every , "UT: expected Recurrence.Every (" + expected[i].Every.ToString() + ") <> actual Recurrence.Every (" + actual[i].Every.ToString() + ")!" );
				Assert.AreEqual( expected[i].EveryWeekDay , actual[i].EveryWeekDay , "UT: expected Recurrence.EveryWeekDay (" + expected[i].EveryWeekDay.ToString() + ") <> actual Recurrence.EveryWeekDay (" + actual[i].EveryWeekDay.ToString() + ")!" );
				Assert.AreEqual( expected[i].Monday , actual[i].Monday , "UT: expected Recurrence.Monday (" + expected[i].Monday.ToString() + ") <> actual Recurrence.Monday (" + actual[i].Monday.ToString() + ")!" );
				Assert.AreEqual( expected[i].Tuesday , actual[i].Tuesday , "UT: expected Recurrence.Tuesday (" + expected[i].Tuesday.ToString() + ") <> actual Recurrence.Tuesday (" + actual[i].Tuesday.ToString() + ")!" );
				Assert.AreEqual( expected[i].Wednesday , actual[i].Wednesday , "UT: expected Recurrence.Wednesday (" + expected[i].Wednesday.ToString() + ") <> actual Recurrence.Wednesday (" + actual[i].Wednesday.ToString() + ")!" );
				Assert.AreEqual( expected[i].Thursday , actual[i].Thursday , "UT: expected Recurrence.Thursday (" + expected[i].Thursday.ToString() + ") <> actual Recurrence.Thursday (" + actual[i].Thursday.ToString() + ")!" );
				Assert.AreEqual( expected[i].Friday , actual[i].Friday , "UT: expected Recurrence.Friday (" + expected[i].Friday.ToString() + ") <> actual Recurrence.Friday (" + actual[i].Friday.ToString() + ")!" );
				Assert.AreEqual( expected[i].Saturday , actual[i].Saturday , "UT: expected Recurrence.Saturday (" + expected[i].Saturday.ToString() + ") <> actual Recurrence.Saturday (" + actual[i].Saturday.ToString() + ")!" );
				Assert.AreEqual( expected[i].Sunday , actual[i].Sunday , "UT: expected Recurrence.Sunday (" + expected[i].Sunday.ToString() + ") <> actual Recurrence.Sunday (" + actual[i].Sunday.ToString() + ")!" );
				Assert.AreEqual( expected[i].DayOfMonth , actual[i].DayOfMonth , "UT: expected Recurrence.DayOfMonth (" + expected[i].DayOfMonth.ToString() + ") <> actual Recurrence.DayOfMonth (" + actual[i].DayOfMonth.ToString() + ")!" );
				Assert.AreEqual( expected[i].Occurrence , actual[i].Occurrence , "UT: expected Recurrence.Occurrence (" + expected[i].Occurrence.ToString() + ") <> actual Recurrence.Occurrence (" + actual[i].Occurrence.ToString() + ")!" );
				Assert.AreEqual( expected[i].Day , actual[i].Day , "UT: expected Recurrence.Day (" + expected[i].Day.ToString() + ") <> actual Recurrence.Day (" + actual[i].Day.ToString() + ")!" );
				Assert.AreEqual( expected[i].Month , actual[i].Month , "UT: expected Recurrence.Month (" + expected[i].Month.ToString() + ") <> actual Recurrence.Month (" + actual[i].Month.ToString() + ")!" );
				Assert.AreEqual( expected[i].StartDate , actual[i].StartDate , "UT: expected Recurrence.StartDate (" + expected[i].StartDate.ToString() + ") <> actual Recurrence.StartDate (" + actual[i].StartDate.ToString() + ")!" );
				Assert.AreEqual( expected[i].EndMode , actual[i].EndMode , "UT: expected Recurrence.EndMode (" + expected[i].EndMode.ToString() + ") <> actual Recurrence.EndMode (" + actual[i].EndMode.ToString() + ")!" );
				Assert.AreEqual( expected[i].Occurrences , actual[i].Occurrences , "UT: expected Recurrence.Occurrences (" + expected[i].Occurrences.ToString() + ") <> actual Recurrence.Occurrences (" + actual[i].Occurrences.ToString() + ")!" );
				Assert.AreEqual( expected[i].EndDate , actual[i].EndDate , "UT: expected Recurrence.EndDate (" + expected[i].EndDate.ToString() + ") <> actual Recurrence.EndDate (" + actual[i].EndDate.ToString() + ")!" );
				Assert.AreEqual( expected[i].Description , actual[i].Description , "UT: expected Recurrence.Description (" + expected[i].Description + ") <> actual Recurrence.Description (" + actual[i].Description + ")!" );
			}
		}

		public static void AreInLogDeletes( RecurrenceDataCollection recurrences ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , recurrences.Count , "UT: " + recurrences.Count.ToString() + " recurrences expected in LogDeletes, " + logDeletes.Count.ToString() + " recurrences found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new RecurrenceSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( recurrences[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}


		public static void UpdateRecurrences( RecurrenceDataCollection recurrences ) {
			foreach( RecurrenceData recurrence in recurrences ) {
				recurrence.RecurrenceMode = RecurrenceMode.Yearly;
				recurrence.EndDate = recurrence.EndDate.AddDays( 7 );
			}
		}

		public static RecurrenceData GetRecurrenceTestData() {
			RecurrenceBll bll = new RecurrenceBll();
			RecurrenceDataCollection recurrences = RecurrenceDataCollection.FromSingleRecurrence(
				new RecurrenceData( RecurrenceMode.Daily , DateTime.Today.AddYears( 1 ) ) );
			RecurrenceDataCollection recurrencesResult = bll.InsertRecurrenceData( recurrences );
			return recurrencesResult[0];
		}

		public static RecurrenceDataCollection GetRecurrencesTestData() {
			RecurrenceBll bll = new RecurrenceBll();
			RecurrenceDataCollection recurrences = new RecurrenceDataCollection();
			recurrences.Add( new RecurrenceData( RecurrenceMode.Daily , DateTime.Today.AddYears( 1 ) ) );
			recurrences.Add( new RecurrenceData( RecurrenceMode.Weekly , DateTime.Today.AddYears( 2 ) ) );
			recurrences.Add( new RecurrenceData( RecurrenceMode.Monthly , DateTime.Today.AddYears( 3 ) ) );
			RecurrenceDataCollection recurrencesResult = bll.InsertRecurrenceData( recurrences );
			return recurrencesResult;
		}

	}

}
