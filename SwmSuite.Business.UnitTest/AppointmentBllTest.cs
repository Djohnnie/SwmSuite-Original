using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Data.DataObjects;
using SwmSuite.Framework;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the AppointmentBll methods.
	/// </summary>
	[TestClass()]
	public class AppointmentBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private AppointmentBll _appointmentBll = new AppointmentBll();
		private AppointmentGuestBll _appointmentGuestBll = new AppointmentGuestBll();
		private AppointmentRecurrenceBll _appointmentRecurrenceBll = new AppointmentRecurrenceBll();
		private RecurrenceBll _recurrenceBll = new RecurrenceBll();

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		#endregion

		#region -_ Additional Test Attributes _-

		[ClassInitialize()]
		public static void MyClassInitialize( TestContext testContext ) {
		}

		[ClassCleanup()]
		public static void MyClassCleanup() {
		}

		[TestInitialize()]
		public void MyTestInitialize() {
			mainScope = new TransactionScope( TransactionScopeOption.Required );
			UnitTestUtils.ClearDatabase();
		}

		[TestCleanup()]
		public void MyTestCleanup() {
			//mainScope.Complete();
			mainScope.Dispose();
		}

		#endregion

		#region -_ Business Test Methods _-

		#endregion

		#region -_ Crud Test Methods _-

		/// <summary>
		/// A test for InsertAppointments (insert a single appointment).
		/// </summary>
		[TestMethod]
		public void Crud_InsertAppointmentTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			AppointmentDataCollection appointments = AppointmentDataCollection.FromSingleAppointment(
				new AppointmentData( "Title" , new DateTime( 2008 , 11 , 6 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 6 , 21 , 30 , 0 ) , "Home" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public ) );
			_appointmentBll.InsertAppointmentData( appointments );
			AppointmentDataCollection appointmentsResult = _appointmentBll.GetAppointmentData();
			AppointmentUnitTestHelper.AreEqual( appointments , appointmentsResult );
		}

		/// <summary>
		/// A test for InsertAppointments (insert multiple appointments).
		/// </summary>
		[TestMethod]
		public void Crud_InsertAppointmentsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			AppointmentDataCollection appointments = new AppointmentDataCollection();
			appointments.Add( new AppointmentData( "Title 1" , new DateTime( 2008 , 11 , 6 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 6 , 21 , 30 , 0 ) , "Home 1" , testEmployee.SysId , "Contents 1" , testAgenda.SysId , AppointmentVisibility.Public ) );
			appointments.Add( new AppointmentData( "Title 2" , new DateTime( 2008 , 11 , 7 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 7 , 21 , 30 , 0 ) , "Home 2" , testEmployee.SysId , "Contents 2" , testAgenda.SysId , AppointmentVisibility.Public ) );
			appointments.Add( new AppointmentData( "Title 3" , new DateTime( 2008 , 11 , 8 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 8 , 21 , 30 , 0 ) , "Home 3" , testEmployee.SysId , "Contents 3" , testAgenda.SysId , AppointmentVisibility.Public ) );
			_appointmentBll.InsertAppointmentData( appointments );
			AppointmentDataCollection appointmentsResult = _appointmentBll.GetAppointmentData();
			AppointmentUnitTestHelper.AreEqual( appointments , appointmentsResult );
		}

		/// <summary>
		/// A test for UpdateAppointments (update a single appointment).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateAppointmentTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			AppointmentDataCollection appointments = AppointmentDataCollection.FromSingleAppointment(
				new AppointmentData( "Title" , new DateTime( 2008 , 11 , 6 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 6 , 21 , 30 , 0 ) , "Home" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public ) );
			_appointmentBll.InsertAppointmentData( appointments );
			AppointmentDataCollection appointmentsToUpdate = _appointmentBll.GetAppointmentData();
			AppointmentUnitTestHelper.UpdateAppointments( appointmentsToUpdate );
			_appointmentBll.UpdateAppointmentData( appointmentsToUpdate );
			AppointmentDataCollection appointmentsResult = _appointmentBll.GetAppointmentData();
			AppointmentUnitTestHelper.AreEqual( appointmentsToUpdate , appointmentsResult );
		}

		/// <summary>
		/// A test for UpdateAppointments (update multiple appointments).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateAppointmentsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			AppointmentDataCollection appointments = new AppointmentDataCollection();
			appointments.Add( new AppointmentData( "Title 1" , new DateTime( 2008 , 11 , 6 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 6 , 21 , 30 , 0 ) , "Home 1" , testEmployee.SysId , "Contents 1" , testAgenda.SysId , AppointmentVisibility.Public ) );
			appointments.Add( new AppointmentData( "Title 2" , new DateTime( 2008 , 11 , 7 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 7 , 21 , 30 , 0 ) , "Home 2" , testEmployee.SysId , "Contents 2" , testAgenda.SysId , AppointmentVisibility.Public ) );
			appointments.Add( new AppointmentData( "Title 3" , new DateTime( 2008 , 11 , 8 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 8 , 21 , 30 , 0 ) , "Home 3" , testEmployee.SysId , "Contents 3" , testAgenda.SysId , AppointmentVisibility.Public ) );
			_appointmentBll.InsertAppointmentData( appointments );
			AppointmentDataCollection appointmentsToUpdate = _appointmentBll.GetAppointmentData();
			AppointmentUnitTestHelper.UpdateAppointments( appointmentsToUpdate );
			_appointmentBll.UpdateAppointmentData( appointmentsToUpdate );
			AppointmentDataCollection appointmentsResult = _appointmentBll.GetAppointmentData();
			AppointmentUnitTestHelper.AreEqual( appointmentsToUpdate , appointmentsResult );
		}

		/// <summary>
		/// A test for RemoveAppointments (remove a single appointment).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAppointmentTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			AppointmentDataCollection appointments = AppointmentDataCollection.FromSingleAppointment(
				new AppointmentData( "Title" , new DateTime( 2008 , 11 , 6 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 6 , 21 , 30 , 0 ) , "Home" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public ) );
			_appointmentBll.InsertAppointmentData( appointments );
			AppointmentDataCollection appointmentsToRemove = _appointmentBll.GetAppointmentData();
			_appointmentBll.RemoveAppointmentData( appointmentsToRemove );
			AppointmentDataCollection appointmentsResult = _appointmentBll.GetAppointmentData();
			Assert.AreEqual( 0 , appointmentsResult.Count , "Appointments are not removed from database!" );
			AppointmentUnitTestHelper.AreInLogDeletes( appointmentsToRemove );
		}

		/// <summary>
		/// A test for RemoveAppointments (remove multiple appointments).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAppointmentsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			AppointmentDataCollection appointments = new AppointmentDataCollection();
			appointments.Add( new AppointmentData( "Title 1" , new DateTime( 2008 , 11 , 6 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 6 , 21 , 30 , 0 ) , "Home 1" , testEmployee.SysId , "Contents 1" , testAgenda.SysId , AppointmentVisibility.Public ) );
			appointments.Add( new AppointmentData( "Title 2" , new DateTime( 2008 , 11 , 7 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 7 , 21 , 30 , 0 ) , "Home 2" , testEmployee.SysId , "Contents 2" , testAgenda.SysId , AppointmentVisibility.Public ) );
			appointments.Add( new AppointmentData( "Title 3" , new DateTime( 2008 , 11 , 8 , 20 , 0 , 0 ) , new DateTime( 2008 , 11 , 8 , 21 , 30 , 0 ) , "Home 3" , testEmployee.SysId , "Contents 3" , testAgenda.SysId , AppointmentVisibility.Public ) );
			_appointmentBll.InsertAppointmentData( appointments );
			AppointmentDataCollection appointmentsToRemove = _appointmentBll.GetAppointmentData();
			_appointmentBll.RemoveAppointmentData( appointmentsToRemove );
			AppointmentDataCollection appointmentsResult = _appointmentBll.GetAppointmentData();
			Assert.AreEqual( 0 , appointmentsResult.Count , "Appointments are not removed from database!" );
			AppointmentUnitTestHelper.AreInLogDeletes( appointmentsToRemove );
		}

		/// <summary>
		/// A test for GetAppointmentDataOnDate (get appointments for a given date).
		/// </summary>
		[TestMethod]
		public void Crud_GetAppoinmentDataOnDateSingleDayAppointmentsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			// Insert test data.
			AppointmentData appointment = new AppointmentData( "Title" , new DateTime( 2000 , 1 , 2 , 10 , 0 , 0 ) , new DateTime( 2000 , 1 , 2 , 18 , 0 , 0 ) , "Place" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public );
			_appointmentBll.InsertAppointmentData( AppointmentDataCollection.FromSingleAppointment( appointment ) );

			AppointmentDataCollection appointmentDataResult = null;
			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 1 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( -1 , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );
		}

		/// <summary>
		/// A test for GetAppointmentDataOnDate (get appointments for a given date).
		/// </summary>
		[TestMethod]
		public void Crud_GetAppoinmentDataOnDateMultipleDayAppointmentsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			// Insert test data.
			AppointmentData appointment = new AppointmentData( "Title" , new DateTime( 2000 , 1 , 2 , 10 , 0 , 0 ) , new DateTime( 2000 , 1 , 4 , 18 , 0 , 0 ) , "Place" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public );
			_appointmentBll.InsertAppointmentData( AppointmentDataCollection.FromSingleAppointment( appointment ) );

			AppointmentDataCollection appointmentDataResult = null;
			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 1 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 4 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 5 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( -1 , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );
		}

		/// <summary>
		/// A test for GetAppointmentDataOnDate (get appointments for a given date).
		/// </summary>
		[TestMethod]
		public void Crud_GetAppoinmentDataOnDateSingleDayAppointmentsBordersTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			// Insert test data.
			AppointmentData appointment = new AppointmentData( "Title" , new DateTime( 2000 , 1 , 2 , 0 , 0 , 0 ) , new DateTime( 2000 , 1 , 2 , 23 , 59 , 59 ) , "Place" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public );
			_appointmentBll.InsertAppointmentData( AppointmentDataCollection.FromSingleAppointment( appointment ) );

			AppointmentDataCollection appointmentDataResult = null;
			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 1 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( -1 , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );
		}

		/// <summary>
		/// A test for GetAppointmentDataOnDate (get appointments for a given date).
		/// </summary>
		[TestMethod]
		public void Crud_GetAppoinmentDataOnDateMultipleDayAppointmentsBordersTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			// Insert test data.
			AppointmentData appointment = new AppointmentData( "Title" , new DateTime( 2000 , 1 , 2 , 23 , 59 , 59 ) , new DateTime( 2000 , 1 , 4 , 0 , 0 , 0 ) , "Place" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public );
			_appointmentBll.InsertAppointmentData( AppointmentDataCollection.FromSingleAppointment( appointment ) );

			AppointmentDataCollection appointmentDataResult = null;
			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 1 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 4 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( testEmployee.SysId , new DateTime( 2000 , 1 , 5 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetAppointmentDataForEmployeeOnDate( -1 , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );
		}

		/// <summary>
		/// A test for GetGuestAppointmentDataForEmployeeOnDate (get guest appointments for a given date).
		/// </summary>
		[TestMethod]
		public void Crud_GetGuestAppoinmentDataOnDateSingleDayAppointmentsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testEmployeeGuest = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			// Insert test data.
			AppointmentData appointment = new AppointmentData( "Title" , new DateTime( 2000 , 1 , 2 , 10 , 0 , 0 ) , new DateTime( 2000 , 1 , 2 , 18 , 0 , 0 ) , "Place" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public );
			AppointmentDataCollection appointmentDataInserted =
				_appointmentBll.InsertAppointmentData( AppointmentDataCollection.FromSingleAppointment( appointment ) );
			Assert.AreEqual( 1 , appointmentDataInserted.Count );

			AppointmentGuestData appointmentGuest = new AppointmentGuestData( appointmentDataInserted[0].SysId , testEmployeeGuest.SysId );
			_appointmentGuestBll.InsertAppointmentGuestData( AppointmentGuestDataCollection.FromSingleAppointmentGuest( appointmentGuest ) );

			AppointmentDataCollection appointmentDataResult = null;
			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 1 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( -1 , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );
		}

		/// <summary>
		/// A test for GetGuestAppointmentDataForEmployeeOnDate (get guest appointments for a given date).
		/// </summary>
		[TestMethod]
		public void Crud_GetGuestAppoinmentDataOnDateMultipleDayAppointmentsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testEmployeeGuest = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			// Insert test data.
			AppointmentData appointment = new AppointmentData( "Title" , new DateTime( 2000 , 1 , 2 , 10 , 0 , 0 ) , new DateTime( 2000 , 1 , 4 , 18 , 0 , 0 ) , "Place" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public );
			AppointmentDataCollection appointmentDataInserted =
				_appointmentBll.InsertAppointmentData( AppointmentDataCollection.FromSingleAppointment( appointment ) );
			Assert.AreEqual( 1 , appointmentDataInserted.Count );

			AppointmentGuestData appointmentGuest = new AppointmentGuestData( appointmentDataInserted[0].SysId , testEmployeeGuest.SysId );
			_appointmentGuestBll.InsertAppointmentGuestData( AppointmentGuestDataCollection.FromSingleAppointmentGuest( appointmentGuest ) );

			AppointmentDataCollection appointmentDataResult = null;
			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 1 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 4 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 5 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( -1 , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );
		}

		/// <summary>
		/// A test for GetGuestAppointmentDataForEmployeeOnDate (get guest appointments for a given date).
		/// </summary>
		[TestMethod]
		public void Crud_GetGuestAppoinmentDataOnDateSingleDayAppointmentsBordersTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testEmployeeGuest = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			// Insert test data.
			AppointmentData appointment = new AppointmentData( "Title" , new DateTime( 2000 , 1 , 2 , 0 , 0 , 0 ) , new DateTime( 2000 , 1 , 2 , 23 , 59 , 59 ) , "Place" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public );
			AppointmentDataCollection appointmentDataInserted =
				_appointmentBll.InsertAppointmentData( AppointmentDataCollection.FromSingleAppointment( appointment ) );
			Assert.AreEqual( 1 , appointmentDataInserted.Count );

			AppointmentGuestData appointmentGuest = new AppointmentGuestData( appointmentDataInserted[0].SysId , testEmployeeGuest.SysId );
			_appointmentGuestBll.InsertAppointmentGuestData( AppointmentGuestDataCollection.FromSingleAppointmentGuest( appointmentGuest ) );

			AppointmentDataCollection appointmentDataResult = null;
			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 1 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( -1 , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );
		}

		/// <summary>
		/// A test for GetGuestAppointmentDataForEmployeeOnDate (get guest appointments for a given date).
		/// </summary>
		[TestMethod]
		public void Crud_GetGuestAppoinmentDataOnDateMultipleDayAppointmentsBordersTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testEmployeeGuest = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			// Insert test data.
			AppointmentData appointment = new AppointmentData( "Title" , new DateTime( 2000 , 1 , 2 , 23 , 59 , 59 ) , new DateTime( 2000 , 1 , 4 , 0 , 0 , 0 ) , "Place" , testEmployee.SysId , "Contents" , testAgenda.SysId , AppointmentVisibility.Public );
			AppointmentDataCollection appointmentDataInserted =
				_appointmentBll.InsertAppointmentData( AppointmentDataCollection.FromSingleAppointment( appointment ) );
			Assert.AreEqual( 1 , appointmentDataInserted.Count );

			AppointmentGuestData appointmentGuest = new AppointmentGuestData( appointmentDataInserted[0].SysId , testEmployeeGuest.SysId );
			_appointmentGuestBll.InsertAppointmentGuestData( AppointmentGuestDataCollection.FromSingleAppointmentGuest( appointmentGuest ) );

			AppointmentDataCollection appointmentDataResult = null;
			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 1 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 2 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 4 ) );
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointment.Title , appointmentDataResult[0].Title );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( testEmployeeGuest.SysId , new DateTime( 2000 , 1 , 5 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );

			appointmentDataResult =
				_appointmentBll.GetGuestAppointmentDataForEmployeeOnDate( -1 , new DateTime( 2000 , 1 , 3 ) );
			Assert.AreEqual( 0 , appointmentDataResult.Count );
		}

		[TestMethod]
		public void GetRecurrentAppointmentDataTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			// Insert test data.
			AppointmentDataCollection appointmentData = new AppointmentDataCollection();
			appointmentData.Add( new AppointmentData( "Title 1" , new DateTime( 2000 , 1 , 3 , 10 , 00 , 00 ) , new DateTime( 2000 , 1 , 3 , 19 , 0 , 0 ) , "Place 1" , testEmployee.SysId , "Contents 1" , testAgenda.SysId , AppointmentVisibility.Public ) );
			appointmentData.Add( new AppointmentData( "Title 2" , new DateTime( 2000 , 1 , 4 , 10 , 00 , 00 ) , new DateTime( 2000 , 1 , 4 , 19 , 0 , 0 ) , "Place 2" , testEmployee.SysId , "Contents 2" , testAgenda.SysId , AppointmentVisibility.Private ) );
			appointmentData.Add( new AppointmentData( "Title 3" , new DateTime( 2000 , 1 , 5 , 10 , 00 , 00 ) , new DateTime( 2000 , 1 , 5 , 19 , 0 , 0 ) , "Place 3" , testEmployee.SysId , "Contents 3" , testAgenda.SysId , AppointmentVisibility.Invisible ) );

			AppointmentDataCollection appointmentDataCollection =	_appointmentBll.InsertAppointmentData( appointmentData );
			Assert.AreEqual( 3 , appointmentDataCollection.Count );

			RecurrenceData recurrence = new RecurrenceData( RecurrenceMode.Daily , DateTime.Today );
			RecurrenceDataCollection recurrenceDataCollection =
				_recurrenceBll.InsertRecurrenceData( RecurrenceDataCollection.FromSingleRecurrence( recurrence ) );
			Assert.AreEqual( 1 , recurrenceDataCollection.Count );

			AppointmentRecurrenceData appointmentRecurrence =
				new AppointmentRecurrenceData( appointmentDataCollection[1].SysId , recurrenceDataCollection[0].SysId );
			_appointmentRecurrenceBll.InsertAppointmentRecurrenceData(
				AppointmentRecurrenceDataCollection.FromSingleAppointmentRecurrence( appointmentRecurrence ) );

			AppointmentDataCollection appointmentDataResult = _appointmentBll.GetRecurrentAppointmentData();
			Assert.AreEqual( 1 , appointmentDataResult.Count );
			Assert.AreEqual( appointmentDataCollection[1].SysId , appointmentDataResult[0].SysId );
		}

		#endregion

		#region -_ IDisposable Members _-

		public void Dispose() {
			Dispose( true );
			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// Corrected implementation
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose( bool disposing ) {
			if( disposing ) {
				// free managed resources
				if( mainScope != null ) {
					mainScope.Dispose();
					mainScope = null;
				}
			}
		}

		#endregion

	}


}
