using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the RecurrenceBll methods.
	/// </summary>
	[TestClass()]
	public class RecurrenceBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private RecurrenceBll _recurrenceBll = new RecurrenceBll();
		private AppointmentBll _appointmentBll = new AppointmentBll();
		private AppointmentGuestBll _appointmentGuestBll = new AppointmentGuestBll();
		private AppointmentRecurrenceBll _appointmentRecurrenceBll = new AppointmentRecurrenceBll();

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
		/// A test for InsertRecurrences (insert a single recurrence).
		/// </summary>
		[TestMethod]
		public void Crud_InsertRecurrenceTest() {
			RecurrenceDataCollection recurrences =
				RecurrenceDataCollection.FromSingleRecurrence( new RecurrenceData( RecurrenceMode.Daily , DateTime.Today ) );
			_recurrenceBll.InsertRecurrenceData( recurrences );
			RecurrenceDataCollection recurrencesResult = _recurrenceBll.GetRecurrenceData();
			RecurrenceUnitTestHelper.AreEqual( recurrences , recurrencesResult );
		}

		/// <summary>
		/// A test for InsertRecurrences (insert multiple recurrences).
		/// </summary>
		[TestMethod]
		public void Crud_InsertRecurrencesTest() {
			RecurrenceDataCollection recurrences = new RecurrenceDataCollection();
			recurrences.Add( new RecurrenceData( RecurrenceMode.Daily , DateTime.Today.AddYears( 1 ) ) );
			recurrences.Add( new RecurrenceData( RecurrenceMode.Weekly , DateTime.Today.AddYears( 2 ) ) );
			recurrences.Add( new RecurrenceData( RecurrenceMode.Monthly , DateTime.Today.AddYears( 3 ) ) );
			_recurrenceBll.InsertRecurrenceData( recurrences );
			RecurrenceDataCollection recurrencesResult = _recurrenceBll.GetRecurrenceData();
			RecurrenceUnitTestHelper.AreEqual( recurrences , recurrencesResult );
		}

		/// <summary>
		/// A test for UpdateRecurrences (update a single recurrence).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateRecurrenceTest() {
			RecurrenceDataCollection recurrences =
				RecurrenceDataCollection.FromSingleRecurrence( new RecurrenceData( RecurrenceMode.Daily , DateTime.Today ) );
			_recurrenceBll.InsertRecurrenceData( recurrences );
			RecurrenceDataCollection recurrencesToUpdate = _recurrenceBll.GetRecurrenceData();
			RecurrenceUnitTestHelper.UpdateRecurrences( recurrencesToUpdate );
			_recurrenceBll.UpdateRecurrenceData( recurrencesToUpdate );
			RecurrenceDataCollection recurrencesResult = _recurrenceBll.GetRecurrenceData();
			RecurrenceUnitTestHelper.AreEqual( recurrencesToUpdate , recurrencesResult );
		}

		/// <summary>
		/// A test for UpdateRecurrences (update multiple recurrences).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateRecurrencesTest() {
			RecurrenceDataCollection recurrences = new RecurrenceDataCollection();
			recurrences.Add( new RecurrenceData( RecurrenceMode.Daily , DateTime.Today.AddYears( 1 ) ) );
			recurrences.Add( new RecurrenceData( RecurrenceMode.Weekly , DateTime.Today.AddYears( 2 ) ) );
			recurrences.Add( new RecurrenceData( RecurrenceMode.Monthly , DateTime.Today.AddYears( 3 ) ) );
			_recurrenceBll.InsertRecurrenceData( recurrences );
			RecurrenceDataCollection recurrencesToUpdate = _recurrenceBll.GetRecurrenceData();
			RecurrenceUnitTestHelper.UpdateRecurrences( recurrencesToUpdate );
			_recurrenceBll.UpdateRecurrenceData( recurrencesToUpdate );
			RecurrenceDataCollection recurrencesResult = _recurrenceBll.GetRecurrenceData();
			RecurrenceUnitTestHelper.AreEqual( recurrencesToUpdate , recurrencesResult );
		}

		/// <summary>
		/// A test for RemoveRecurrences (remove a single recurrence).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveRecurrenceTest() {
			RecurrenceDataCollection recurrences =
				RecurrenceDataCollection.FromSingleRecurrence( new RecurrenceData( RecurrenceMode.Daily , DateTime.Today ) );
			_recurrenceBll.InsertRecurrenceData( recurrences );
			RecurrenceDataCollection recurrencesToRemove = _recurrenceBll.GetRecurrenceData();
			_recurrenceBll.RemoveRecurrenceData( recurrencesToRemove );
			RecurrenceDataCollection recurrencesResult = _recurrenceBll.GetRecurrenceData();
			Assert.AreEqual( 0 , recurrencesResult.Count , "The recurrences should be removed!" );
			RecurrenceUnitTestHelper.AreInLogDeletes( recurrencesToRemove );
		}

		/// <summary>
		/// A test for RemoveRecurrences (remove multiple recurrences).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveRecurrencesTest() {
			RecurrenceDataCollection recurrences = new RecurrenceDataCollection();
			recurrences.Add( new RecurrenceData( RecurrenceMode.Daily , DateTime.Today.AddYears( 1 ) ) );
			recurrences.Add( new RecurrenceData( RecurrenceMode.Weekly , DateTime.Today.AddYears( 2 ) ) );
			recurrences.Add( new RecurrenceData( RecurrenceMode.Monthly , DateTime.Today.AddYears( 3 ) ) );
			_recurrenceBll.InsertRecurrenceData( recurrences );
			RecurrenceDataCollection recurrencesToRemove = _recurrenceBll.GetRecurrenceData();
			_recurrenceBll.RemoveRecurrenceData( recurrencesToRemove );
			RecurrenceDataCollection recurrencesResult = _recurrenceBll.GetRecurrenceData();
			Assert.AreEqual( 0 , recurrencesResult.Count , "The recurrences should be removed!" );
			RecurrenceUnitTestHelper.AreInLogDeletes( recurrencesToRemove );
		}

		/// <summary>
		/// A test for GetRecurrenceDataForAppointment.
		/// </summary>
		[TestMethod]
		public void Crud_GetRecurrenceDataForAppointmentTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaData testAgenda = AgendaUnitTestHelper.GetAgendaTestData();
			// Insert test data.
			AppointmentDataCollection appointmentData = new AppointmentDataCollection();
			appointmentData.Add( new AppointmentData( "Title 1" , new DateTime( 2000 , 1 , 3 , 10 , 00 , 00 ) , new DateTime( 2000 , 1 , 3 , 19 , 0 , 0 ) , "Place 1" , testEmployee.SysId , "Contents 1" , testAgenda.SysId , AppointmentVisibility.Public ) );
			
			AppointmentDataCollection appointmentDataCollection = _appointmentBll.InsertAppointmentData( appointmentData );
			Assert.AreEqual( 1 , appointmentDataCollection.Count );

			RecurrenceDataCollection recurrenceDataToInsert = new RecurrenceDataCollection();
			recurrenceDataToInsert.Add( new RecurrenceData( RecurrenceMode.Daily , DateTime.Today ) );
			recurrenceDataToInsert.Add( new RecurrenceData( RecurrenceMode.Weekly , DateTime.Today ) );
			recurrenceDataToInsert.Add( new RecurrenceData( RecurrenceMode.Monthly , DateTime.Today ) );
			RecurrenceDataCollection recurrenceDataCollection =
				_recurrenceBll.InsertRecurrenceData( recurrenceDataToInsert );
			Assert.AreEqual( 3 , recurrenceDataCollection.Count );

			AppointmentRecurrenceData appointmentRecurrence =
				new AppointmentRecurrenceData( appointmentDataCollection[0].SysId , recurrenceDataCollection[1].SysId );
			_appointmentRecurrenceBll.InsertAppointmentRecurrenceData(
				AppointmentRecurrenceDataCollection.FromSingleAppointmentRecurrence( appointmentRecurrence ) );

			RecurrenceDataCollection recurrenceDataResult =
				_recurrenceBll.GetRecurrenceDataForAppointment( appointmentDataCollection[0].SysId );
			Assert.AreEqual( 1 , recurrenceDataResult.Count );
			Assert.AreEqual( RecurrenceMode.Weekly , recurrenceDataResult[0].RecurrenceMode );
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
