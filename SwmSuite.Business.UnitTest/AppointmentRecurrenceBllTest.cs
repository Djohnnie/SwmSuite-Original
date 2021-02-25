using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the AppointmentRecurrenceBll methods.
	/// </summary>
	[TestClass()]
	public class AppointmentRecurrenceBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private AppointmentRecurrenceBll appointmentrecurrenceBll = new AppointmentRecurrenceBll();

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
		/// A test for InsertAppointmentRecurrences (insert a single appointmentrecurrence).
		/// </summary>
		[TestMethod]
		public void Crud_InsertAppointmentRecurrenceTest() {
			AppointmentData appointment = AppointmentUnitTestHelper.GetAppointmentTestData();
			RecurrenceData recurrence = RecurrenceUnitTestHelper.GetRecurrenceTestData();

			AppointmentRecurrenceBll bll = new AppointmentRecurrenceBll();
			AppointmentRecurrenceDataCollection appointmentRecurrences = AppointmentRecurrenceDataCollection.FromSingleAppointmentRecurrence(
				new AppointmentRecurrenceData( appointment.SysId , recurrence.SysId ) );
			bll.InsertAppointmentRecurrenceData( appointmentRecurrences );
			AppointmentRecurrenceDataCollection appointmentRecurrencesResult = bll.GetAppointmentRecurrenceData();
			AppointmentRecurrenceUnitTestHelper.AreEqual( appointmentRecurrences , appointmentRecurrencesResult );
		}

		/// <summary>
		/// A test for InsertAppointmentRecurrences (insert multiple appointmentrecurrences).
		/// </summary>
		[TestMethod]
		public void Crud_InsertAppointmentRecurrencesTest() {
			AppointmentDataCollection appointments = AppointmentUnitTestHelper.GetAppointmentsTestData();
			RecurrenceDataCollection recurrences = RecurrenceUnitTestHelper.GetRecurrencesTestData();

			AppointmentRecurrenceBll bll = new AppointmentRecurrenceBll();
			AppointmentRecurrenceDataCollection appointmentRecurrences = new AppointmentRecurrenceDataCollection();
			foreach( RecurrenceData recurrence in recurrences ) {
				AppointmentData appointment = appointments[recurrences.IndexOf( recurrence )];
				appointmentRecurrences.Add( new AppointmentRecurrenceData( appointment.SysId , recurrence.SysId ) );
			}
			bll.InsertAppointmentRecurrenceData( appointmentRecurrences );
			AppointmentRecurrenceDataCollection appointmentRecurrencesResult = bll.GetAppointmentRecurrenceData();
			AppointmentRecurrenceUnitTestHelper.AreEqual( appointmentRecurrences , appointmentRecurrencesResult );
		}

		/// <summary>
		/// A test for UpdateAppointmentRecurrences (update a single appointmentrecurrence).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateAppointmentRecurrenceTest() {
			AppointmentData appointment1 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentData appointment2 = AppointmentUnitTestHelper.GetAppointmentTestData();
			RecurrenceData recurrence1 = RecurrenceUnitTestHelper.GetRecurrenceTestData();
			RecurrenceData recurrence2 = RecurrenceUnitTestHelper.GetRecurrenceTestData();

			AppointmentRecurrenceBll bll = new AppointmentRecurrenceBll();
			AppointmentRecurrenceDataCollection appointmentRecurrences = AppointmentRecurrenceDataCollection.FromSingleAppointmentRecurrence(
				new AppointmentRecurrenceData( appointment1.SysId , recurrence1.SysId ) );
			bll.InsertAppointmentRecurrenceData( appointmentRecurrences );
			AppointmentRecurrenceDataCollection appointmentRecurrencesToUpdate = bll.GetAppointmentRecurrenceData();
			appointmentRecurrencesToUpdate[0].AppointmentSysId = appointment2.SysId;
			appointmentRecurrencesToUpdate[0].RecurrenceSysId = recurrence2.SysId;
			bll.UpdateAppointmentRecurrenceData( appointmentRecurrencesToUpdate );
			AppointmentRecurrenceDataCollection appointmentRecurrencesResult = bll.GetAppointmentRecurrenceData();
			AppointmentRecurrenceUnitTestHelper.AreEqual( appointmentRecurrencesToUpdate , appointmentRecurrencesResult );
		}

		/// <summary>
		/// A test for UpdateAppointmentRecurrences (update multiple appointmentrecurrences).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateAppointmentRecurrencesTest() {
			AppointmentDataCollection appointments1 = AppointmentUnitTestHelper.GetAppointmentsTestData();
			AppointmentDataCollection appointments2 = AppointmentUnitTestHelper.GetAppointmentsTestData();
			RecurrenceDataCollection recurrences1 = RecurrenceUnitTestHelper.GetRecurrencesTestData();
			RecurrenceDataCollection recurrences2 = RecurrenceUnitTestHelper.GetRecurrencesTestData();

			AppointmentRecurrenceBll bll = new AppointmentRecurrenceBll();
			AppointmentRecurrenceDataCollection appointmentRecurrences = new AppointmentRecurrenceDataCollection();
			foreach( RecurrenceData recurrence in recurrences1 ) {
				AppointmentData appointment = appointments1[recurrences1.IndexOf( recurrence )];
				appointmentRecurrences.Add( new AppointmentRecurrenceData( appointment.SysId , recurrence.SysId ) );
			}
			bll.InsertAppointmentRecurrenceData( appointmentRecurrences );
			AppointmentRecurrenceDataCollection appointmentRecurrencesToUpdate = bll.GetAppointmentRecurrenceData();
			foreach( AppointmentRecurrenceData appointmentRecurrence in appointmentRecurrencesToUpdate ) {
				AppointmentData appointment = appointments2[appointmentRecurrencesToUpdate.IndexOf( appointmentRecurrence )];
				RecurrenceData recurrence = recurrences2[appointmentRecurrencesToUpdate.IndexOf( appointmentRecurrence )];
				appointmentRecurrence.AppointmentSysId = appointment.SysId;
				appointmentRecurrence.RecurrenceSysId = recurrence.SysId;
			}
			bll.UpdateAppointmentRecurrenceData( appointmentRecurrencesToUpdate );
			AppointmentRecurrenceDataCollection appointmentRecurrencesResult = bll.GetAppointmentRecurrenceData();
			AppointmentRecurrenceUnitTestHelper.AreEqual( appointmentRecurrencesToUpdate , appointmentRecurrencesResult );
		}

		/// <summary>
		/// A test for RemoveAppointmentRecurrences (remove a single appointmentrecurrence).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAppointmentRecurrenceTest() {
			AppointmentData appointment1 = AppointmentUnitTestHelper.GetAppointmentTestData();
			AppointmentData appointment2 = AppointmentUnitTestHelper.GetAppointmentTestData();
			RecurrenceData recurrence1 = RecurrenceUnitTestHelper.GetRecurrenceTestData();
			RecurrenceData recurrence2 = RecurrenceUnitTestHelper.GetRecurrenceTestData();

			AppointmentRecurrenceBll bll = new AppointmentRecurrenceBll();
			AppointmentRecurrenceDataCollection appointmentRecurrences = AppointmentRecurrenceDataCollection.FromSingleAppointmentRecurrence(
				new AppointmentRecurrenceData( appointment1.SysId , recurrence1.SysId ) );
			bll.InsertAppointmentRecurrenceData( appointmentRecurrences );
			AppointmentRecurrenceDataCollection appointmentRecurrencesToRemove = bll.GetAppointmentRecurrenceData();
			bll.RemoveAppointmentRecurrenceData( appointmentRecurrencesToRemove );
			AppointmentRecurrenceDataCollection appointmentRecurrencesResult = bll.GetAppointmentRecurrenceData();
			Assert.AreEqual( 0 , appointmentRecurrencesResult.Count , "The appointmentrecurrences should be removed!" );
			AppointmentRecurrenceUnitTestHelper.AreInLogDeletes( appointmentRecurrencesToRemove );
		}

		/// <summary>
		/// A test for RemoveAppointmentRecurrences (remove multiple appointmentrecurrences).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAppointmentRecurrencesTest() {
			AppointmentDataCollection appointments1 = AppointmentUnitTestHelper.GetAppointmentsTestData();
			AppointmentDataCollection appointments2 = AppointmentUnitTestHelper.GetAppointmentsTestData();
			RecurrenceDataCollection recurrences1 = RecurrenceUnitTestHelper.GetRecurrencesTestData();
			RecurrenceDataCollection recurrences2 = RecurrenceUnitTestHelper.GetRecurrencesTestData();

			AppointmentRecurrenceBll bll = new AppointmentRecurrenceBll();
			AppointmentRecurrenceDataCollection appointmentRecurrences = new AppointmentRecurrenceDataCollection();
			foreach( RecurrenceData recurrence in recurrences1 ) {
				AppointmentData appointment = appointments1[recurrences1.IndexOf( recurrence )];
				appointmentRecurrences.Add( new AppointmentRecurrenceData( appointment.SysId , recurrence.SysId ) );
			}
			bll.InsertAppointmentRecurrenceData( appointmentRecurrences );
			AppointmentRecurrenceDataCollection appointmentRecurrencesToRemove = bll.GetAppointmentRecurrenceData();
			bll.RemoveAppointmentRecurrenceData( appointmentRecurrencesToRemove );
			AppointmentRecurrenceDataCollection appointmentRecurrencesResult = bll.GetAppointmentRecurrenceData();
			Assert.AreEqual( 0 , appointmentRecurrencesResult.Count , "The appointmentrecurrences should be removed!" );
			AppointmentRecurrenceUnitTestHelper.AreInLogDeletes( appointmentRecurrencesToRemove );
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
