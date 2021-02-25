using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Data.DataObjects;
using SwmSuite.Framework;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Business.UnitTest.UnitTestHelper;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the AppointmentGuestBll methods.
	/// </summary>
	[TestClass()]
	public class AppointmentGuestBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private AppointmentGuestBll _appointmentGuestBll = new AppointmentGuestBll();

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
		/// A test for InsertAppointmentGuests (insert a single appointmentguest).
		/// </summary>
		[TestMethod]
		public void Crud_InsertAppointmentGuestTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AppointmentData testAppointment = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentGuestDataCollection appointmentGuests = AppointmentGuestDataCollection.FromSingleAppointmentGuest(
				new AppointmentGuestData( testAppointment.SysId , testEmployee.SysId ) );
			_appointmentGuestBll.InsertAppointmentGuestData( appointmentGuests );
			AppointmentGuestDataCollection appointmentGuestsResult = _appointmentGuestBll.GetAppointmentGuestData();
			AppointmentGuestUnitTestHelper.AreEqual( appointmentGuests , appointmentGuestsResult );
		}

		/// <summary>
		/// A test for InsertAppointmentGuests (insert multiple appointmentguests).
		/// </summary>
		[TestMethod]
		public void Crud_InsertAppointmentGuestsTest() {
			EmployeeData testEmployee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testEmployee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			AppointmentData testAppointment1 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentData testAppointment2 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentGuestDataCollection appointmentGuests = new AppointmentGuestDataCollection();
			appointmentGuests.Add( new AppointmentGuestData( testAppointment1.SysId , testEmployee1.SysId ) );
			appointmentGuests.Add( new AppointmentGuestData( testAppointment2.SysId , testEmployee2.SysId ) );
			_appointmentGuestBll.InsertAppointmentGuestData( appointmentGuests );
			AppointmentGuestDataCollection appointmentGuestsResult = _appointmentGuestBll.GetAppointmentGuestData();
			AppointmentGuestUnitTestHelper.AreEqual( appointmentGuests , appointmentGuestsResult );
		}

		/// <summary>
		/// A test for UpdateAppointmentGuests (update a single appointmentguest).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateAppointmentGuestTest() {
			EmployeeData testEmployee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testEmployee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			AppointmentData testAppointment1 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentData testAppointment2 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentGuestDataCollection appointmentGuests = AppointmentGuestDataCollection.FromSingleAppointmentGuest(
				new AppointmentGuestData( testAppointment1.SysId , testEmployee2.SysId ) );
			_appointmentGuestBll.InsertAppointmentGuestData( appointmentGuests );
			AppointmentGuestDataCollection appointmentGuestsToUpdate = _appointmentGuestBll.GetAppointmentGuestData();
			appointmentGuestsToUpdate[0].AppointmentSysId = testAppointment2.SysId;
			appointmentGuestsToUpdate[0].EmployeeSysId = testEmployee2.SysId;
			_appointmentGuestBll.UpdateAppointmentGuestData( appointmentGuestsToUpdate );
			AppointmentGuestDataCollection appointmentGuestsResult = _appointmentGuestBll.GetAppointmentGuestData();
			AppointmentGuestUnitTestHelper.AreEqual( appointmentGuestsToUpdate , appointmentGuestsResult );
		}

		/// <summary>
		/// A test for UpdateAppointmentGuests (update multiple appointmentguests).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateAppointmentGuestsTest() {
			EmployeeData testEmployee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testEmployee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			AppointmentData testAppointment1 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentData testAppointment2 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentGuestDataCollection appointmentGuests = new AppointmentGuestDataCollection();
			appointmentGuests.Add( new AppointmentGuestData( testAppointment1.SysId , testEmployee1.SysId ) );
			appointmentGuests.Add( new AppointmentGuestData( testAppointment2.SysId , testEmployee2.SysId ) );
			_appointmentGuestBll.InsertAppointmentGuestData( appointmentGuests );
			AppointmentGuestDataCollection appointmentGuestsToUpdate = _appointmentGuestBll.GetAppointmentGuestData();
			appointmentGuestsToUpdate[0].AppointmentSysId = testAppointment2.SysId;
			appointmentGuestsToUpdate[0].EmployeeSysId = testEmployee2.SysId;
			appointmentGuestsToUpdate[1].AppointmentSysId = testAppointment1.SysId;
			appointmentGuestsToUpdate[1].EmployeeSysId = testEmployee1.SysId;
			_appointmentGuestBll.UpdateAppointmentGuestData( appointmentGuestsToUpdate );
			AppointmentGuestDataCollection appointmentGuestsResult = _appointmentGuestBll.GetAppointmentGuestData();
			AppointmentGuestUnitTestHelper.AreEqual( appointmentGuestsToUpdate , appointmentGuestsResult );
		}

		/// <summary>
		/// A test for RemoveAppointmentGuests (remove a single appointmentguest).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAppointmentGuestTest() {
			EmployeeData testEmployee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testEmployee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			AppointmentData testAppointment1 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentData testAppointment2 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentGuestDataCollection appointmentGuests = AppointmentGuestDataCollection.FromSingleAppointmentGuest(
				new AppointmentGuestData( testAppointment1.SysId , testEmployee2.SysId ) );
			_appointmentGuestBll.InsertAppointmentGuestData( appointmentGuests );
			AppointmentGuestDataCollection appointmentGuestsToRemove = _appointmentGuestBll.GetAppointmentGuestData();
			_appointmentGuestBll.RemoveAppointmentGuestData( appointmentGuestsToRemove );
			AppointmentGuestDataCollection appointmentGuestsResult = _appointmentGuestBll.GetAppointmentGuestData();
			Assert.AreEqual( 0 , appointmentGuestsResult.Count , "Appointmentguests are not removed from database!" );
			AppointmentGuestUnitTestHelper.AreInLogDeletes( appointmentGuestsToRemove );
		}

		/// <summary>
		/// A test for RemoveAppointmentGuests (remove multiple appointmentguests).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAppointmentGuestsTest() {
			EmployeeData testEmployee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testEmployee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			AppointmentData testAppointment1 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentData testAppointment2 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentGuestDataCollection appointmentGuests = new AppointmentGuestDataCollection();
			appointmentGuests.Add( new AppointmentGuestData( testAppointment1.SysId , testEmployee1.SysId ) );
			appointmentGuests.Add( new AppointmentGuestData( testAppointment2.SysId , testEmployee2.SysId ) );
			_appointmentGuestBll.InsertAppointmentGuestData( appointmentGuests );
			AppointmentGuestDataCollection appointmentGuestsToRemove = _appointmentGuestBll.GetAppointmentGuestData();
			_appointmentGuestBll.RemoveAppointmentGuestData( appointmentGuestsToRemove );
			AppointmentGuestDataCollection appointmentGuestsResult = _appointmentGuestBll.GetAppointmentGuestData();
			Assert.AreEqual( 0 , appointmentGuestsResult.Count , "Appointmentguests are not removed from database!" );
			AppointmentGuestUnitTestHelper.AreInLogDeletes( appointmentGuestsToRemove );
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
