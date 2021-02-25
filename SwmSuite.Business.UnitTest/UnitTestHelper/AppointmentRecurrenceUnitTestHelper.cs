using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class AppointmentRecurrenceUnitTestHelper {

		public static void AreEqual( AppointmentRecurrenceDataCollection expected , AppointmentRecurrenceDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " appointmentrecurrences expected, " + actual.Count.ToString() + " appointmentrecurrences actual!" );
			// Test individual appointmentrecurrences.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].AppointmentSysId , actual[i].AppointmentSysId , "UT: expected AppointmentRecurrence.AppointmentSysId (" + expected[i].AppointmentSysId.ToString() + ") <> actual AppointmentRecurrence.AppointmentSysId (" + actual[i].AppointmentSysId.ToString() + ")!" );
				Assert.AreEqual( expected[i].RecurrenceSysId , actual[i].RecurrenceSysId , "UT: expected AppointmentRecurrence.RecurrenceSysId (" + expected[i].RecurrenceSysId.ToString() + ") <> actual AppointmentRecurrence.RecurrenceSysId (" + actual[i].RecurrenceSysId.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( AppointmentRecurrenceDataCollection appointmentrecurrences ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , appointmentrecurrences.Count , "UT: " + appointmentrecurrences.Count.ToString() + " appointmentrecurrences expected in LogDeletes, " + logDeletes.Count.ToString() + " appointmentrecurrences found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new AppointmentRecurrenceSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( appointmentrecurrences[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

	}

}
