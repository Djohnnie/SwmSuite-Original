using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class HolidayDefinitionUnitTestHelper {

		public static void AreEqual( HolidayDefinitionDataCollection expected , HolidayDefinitionDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " holidaydefinitions expected, " + actual.Count.ToString() + " holidaydefinitions actual!" );
			// Test individual holidaydefinitions.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].Name , actual[i].Name , "UT: expected HolidayDefinition.Name (" + expected[i].Name + ") <> actual HolidayDefinition.Name (" + actual[i].Name + ")!" );
				Assert.AreEqual( expected[i].RecurringHoliday , actual[i].RecurringHoliday , "UT: expected HolidayDefinition.RecurringHoliday (" + expected[i].RecurringHoliday.ToString() + ") <> actual HolidayDefinition.RecurringHoliday (" + actual[i].RecurringHoliday.ToString() + ")!" );
				Assert.AreEqual( expected[i].DateStart , actual[i].DateStart , "UT: expected HolidayDefinition.DateStart (" + expected[i].DateStart.ToString() + ") <> actual HolidayDefinition.DateStart (" + actual[i].DateStart.ToString() + ")!" );
				Assert.AreEqual( expected[i].DateEnd , actual[i].DateEnd , "UT: expected HolidayDefinition.DateEnd (" + expected[i].DateEnd.ToString() + ") <> actual HolidayDefinition.DateEnd (" + actual[i].DateEnd.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( HolidayDefinitionDataCollection holidayDefinitionData ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , holidayDefinitionData.Count , "UT: " + holidayDefinitionData.Count.ToString() + " holidaydefinitions expected in LogDeletes, " + logDeletes.Count.ToString() + " holidaydefinitions found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new HolidayDefinitionSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( holidayDefinitionData[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateHolidayDefinitions( HolidayDefinitionDataCollection holidayDefinitionData ) {
			foreach( HolidayDefinitionData holidayDefinition in holidayDefinitionData ) {
				holidayDefinition.Name += "-> EDITED!";
				holidayDefinition.RecurringHoliday = !holidayDefinition.RecurringHoliday;
				holidayDefinition.DateStart = holidayDefinition.DateStart.AddMonths( 1 );
				holidayDefinition.DateEnd = holidayDefinition.DateEnd.AddMonths( 1 );
			}
		}

	}

}
