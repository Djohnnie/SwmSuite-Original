using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.AgendaModule;
using System.Globalization;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class AppointmentGuestUnitTestHelper {

		public static void AreEqual( AppointmentGuestDataCollection expected , AppointmentGuestDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " appointmentguests expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " appointmentguests actual!" );
			// Test individual appointmentguests.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].AppointmentSysId , actual[i].AppointmentSysId , "UT: expected AppointmentGuest.AppointmentSysId (" + expected[i].AppointmentSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual AppointmentGuest.AppointmentSysId (" + actual[i].AppointmentSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].EmployeeSysId , actual[i].EmployeeSysId , "UT: expected AppointmentGuest.EmployeeSysId (" + expected[i].EmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual AppointmentGuest.EmployeeSysId (" + actual[i].EmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( AppointmentGuestDataCollection appointmentguests ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , appointmentguests.Count , "UT: " + appointmentguests.Count.ToString( CultureInfo.InvariantCulture ) + " appointmentguests expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " appointmentguests found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new AppointmentGuestSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( appointmentguests[logDeletes.IndexOf( ld )].ToString( ) , ld.Info );
			}
		}

	}

}
