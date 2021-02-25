using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.DataAccess.Sql.SqlHelper.AgendaModule;
using System.Globalization;
using SwmSuite.Business;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class AppointmentUnitTestHelper {

		public static void AreEqual( AppointmentDataCollection expected , AppointmentDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " appointments expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " appointments actual!" );
			// Test individual appointments.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].Title , actual[i].Title , "UT: expected Appointment.Title (" + expected[i].Title + ") <> actual Appointment.Title (" + actual[i].Title + ")!" );
				Assert.AreEqual( expected[i].DateTimeStart , actual[i].DateTimeStart , "UT: expected Appointment.DateTimeStart (" + expected[i].DateTimeStart.ToString( CultureInfo.InvariantCulture ) + ") <> actual Appointment.DateTimeStart (" + actual[i].DateTimeStart.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].DateTimeEnd , actual[i].DateTimeEnd , "UT: expected Appointment.DateTimeEnd (" + expected[i].DateTimeEnd.ToString( CultureInfo.InvariantCulture ) + ") <> actual Appointment.DateTimeEnd (" + actual[i].DateTimeEnd.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].Place , actual[i].Place , "UT: expected Appointment.Place (" + expected[i].Place + ") <> actual Appointment.Place (" + actual[i].Place + ")!" );
				Assert.AreEqual( expected[i].OwnerEmployeeSysId , actual[i].OwnerEmployeeSysId , "UT: expected Appointment.OwnerEmployeeSysId (" + expected[i].OwnerEmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual Appointment.OwnerEmployeeSysId (" + actual[i].OwnerEmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].Contents , actual[i].Contents , "UT: expected Appointment.Contents (" + expected[i].Contents + ") <> actual Appointment.Contents (" + actual[i].Contents + ")!" );
				Assert.AreEqual( expected[i].AgendaSysId , actual[i].AgendaSysId , "UT: expected Appointment.AgendaSysId (" + expected[i].AgendaSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual Appointment.AgendaSysId (" + actual[i].AgendaSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( AppointmentDataCollection appointments ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , appointments.Count , "UT: " + appointments.Count.ToString( CultureInfo.InvariantCulture ) + " appointments expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " appointments found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new AppointmentSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( appointments[logDeletes.IndexOf( ld )].ToString(  ) , ld.Info );
			}
		}

		public static void UpdateAppointments( AppointmentDataCollection appointments ) {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			foreach( AppointmentData appointment in appointments ) {
				appointment.OwnerEmployeeSysId = testEmployee.SysId;
				appointment.AgendaSysId = testAgenda.SysId;
				appointment.Contents += " -> EDITED!";
				appointment.Title += " -> EDITED!";
				appointment.Place += " -> EDITED!";
				appointment.DateTimeStart = appointment.DateTimeStart.AddDays( 1 );
				appointment.DateTimeEnd = appointment.DateTimeEnd.AddDays( 1 );
			}
		}

		public static AppointmentData GetAppointmentTestData() {
			AppointmentBll bll = new AppointmentBll();
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			AppointmentDataCollection appointments = AppointmentDataCollection.FromSingleAppointment(
				new AppointmentData( "Title" , new DateTime( 2008 , 11 , 6 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 6 , 21 , 30 , 0 ) , "Home" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public) );
			AppointmentDataCollection appointmentsResult = bll.InsertAppointmentData( appointments );
			return appointmentsResult[0];
		}

		public static AppointmentDataCollection GetAppointmentsTestData() {
			AppointmentBll bll = new AppointmentBll();
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			AppointmentDataCollection appointments = new AppointmentDataCollection();
			appointments.Add( new AppointmentData( "Title 1" , new DateTime( 2008 , 11 , 6 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 6 , 21 , 30 , 0 ) , "Home 1" , testEmployee.SysId , "Contents 1" , testAgenda.SysId , AppointmentVisibility.Public ) );
			appointments.Add( new AppointmentData( "Title 2" , new DateTime( 2008 , 11 , 7 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 7 , 21 , 30 , 0 ) , "Home 2" , testEmployee.SysId , "Contents 2" , testAgenda.SysId , AppointmentVisibility.Public ) );
			appointments.Add( new AppointmentData( "Title 3" , new DateTime( 2008 , 11 , 8 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 8 , 21 , 30 , 0 ) , "Home 3" , testEmployee.SysId , "Contents 3" , testAgenda.SysId , AppointmentVisibility.Public ) );
			AppointmentDataCollection appointmentsResult = bll.InsertAppointmentData( appointments );
			return appointmentsResult;
		}

	}

}
