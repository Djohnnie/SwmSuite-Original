using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Framework;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.Common;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the AgendaBll methods.
	/// </summary>
	[TestClass()]
	public class AgendaBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private AgendaBll _agendaBll = new AgendaBll();

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

		[TestMethod]
		public void Business_CreateAgendaTest() {
			Employee testEmployee = EmployeeUnitTestHelper.GetTestEmployee( "employee" );

			Agenda agenda = new Agenda( "Title" , "Description" , testEmployee , AppointmentVisibility.Public );
			Agenda createdAgenda =
				_agendaBll.CreateAgenda( agenda );

			Assert.AreEqual( agenda.Title , createdAgenda.Title );
			Assert.AreEqual( agenda.Description , createdAgenda.Description );
			Assert.AreEqual( agenda.OwnerEmployee.SysId , createdAgenda.OwnerEmployee.SysId );
			Assert.AreEqual( agenda.Visibility , createdAgenda.Visibility );
		}

		[TestMethod]
		public void Business_UpdateAgendaTest() {
			Employee testEmployee1 = EmployeeUnitTestHelper.GetTestEmployee( "employee1" );
			Employee testEmployee2 = EmployeeUnitTestHelper.GetTestEmployee( "employee2" );

			Agenda agenda = new Agenda( "Title" , "Description" , testEmployee1 , AppointmentVisibility.Public );
			Agenda createdAgenda =
				_agendaBll.CreateAgenda( agenda );

			createdAgenda.Title = "Title 2";
			createdAgenda.Description = "Description 2";
			createdAgenda.OwnerEmployee = testEmployee2;
			createdAgenda.Visibility = AppointmentVisibility.Private;

			Agenda updatedAgenda =
				_agendaBll.UpdateAgenda( createdAgenda );

			Assert.AreEqual( createdAgenda.Title , updatedAgenda.Title );
			Assert.AreEqual( createdAgenda.Description , updatedAgenda.Description );
			Assert.AreEqual( createdAgenda.OwnerEmployee.SysId , updatedAgenda.OwnerEmployee.SysId );
			Assert.AreEqual( createdAgenda.Visibility , updatedAgenda.Visibility );
		}

		[TestMethod]
		public void Business_DeleteAgendaTest() {
			Employee testEmployee = EmployeeUnitTestHelper.GetTestEmployee( "employee" );

			Agenda agenda = new Agenda( "Title" , "Description" , testEmployee , AppointmentVisibility.Public );
			Agenda createdAgenda =
				_agendaBll.CreateAgenda( agenda );

			// Database should contain 2 agendas (default one for employee and the one just inserted.)
			Assert.AreEqual( 2 , _agendaBll.GetAgendasForEmployee( testEmployee ).Count );

			_agendaBll.DeleteAgenda( createdAgenda );

			// Database should only contain the one default agenda for this employee.
			Assert.AreEqual( 1 , _agendaBll.GetAgendasForEmployee( testEmployee ).Count );
		}

		#endregion

		#region -_ Crud Test Methods _-

		/// <summary>
		/// A test for InsertAgendas (insert a single agenda).
		/// </summary>
		[TestMethod]
		public void Crud_InsertAgendaTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			AgendaData agenda = new AgendaData( "Title" , "Description" , testEmployee.SysId , AppointmentVisibility.Public , 0 );
			AgendaDataCollection agendas = AgendaDataCollection.FromSingleAgenda( agenda );
			_agendaBll.InsertAgendaData( agendas );
			AgendaDataCollection agendasResult = _agendaBll.GetAgendaData();
			AgendaUnitTestHelper.AreEqual( agendas , agendasResult );
		}

		/// <summary>
		/// A test for InsertAgendas (insert multiple agendas).
		/// </summary>
		[TestMethod]
		public void Crud_InsertAgendasTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			AgendaDataCollection agendas = new AgendaDataCollection();
			agendas.Add( new AgendaData( "Title 1" , "Description 1" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			agendas.Add( new AgendaData( "Title 2" , "Description 2" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			agendas.Add( new AgendaData( "Title 3" , "Description 3" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			_agendaBll.InsertAgendaData( agendas );
			AgendaDataCollection agendasResult = _agendaBll.GetAgendaData();
			AgendaUnitTestHelper.AreEqual( agendas , agendasResult );
		}

		/// <summary>
		/// A test for UpdateAgendas (update a single agenda).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateAgendaTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			AgendaData agenda = new AgendaData( "Title" , "Description" , testEmployee.SysId , AppointmentVisibility.Public , 0 );
			AgendaDataCollection agendas = AgendaDataCollection.FromSingleAgenda( agenda );
			_agendaBll.InsertAgendaData( agendas );
			AgendaDataCollection agendasToUpdate = _agendaBll.GetAgendaData();
			AgendaUnitTestHelper.AreEqual( agendas , agendasToUpdate );
			AgendaUnitTestHelper.UpdateAgendas( agendasToUpdate );
			_agendaBll.UpdateAgendaData( agendasToUpdate );
			AgendaDataCollection agendasResult = _agendaBll.GetAgendaData();
			AgendaUnitTestHelper.AreEqual( agendasToUpdate , agendasResult );
		}

		/// <summary>
		/// A test for UpdateAgendas (update multiple agendas).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateAgendasTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			AgendaDataCollection agendas = new AgendaDataCollection();
			agendas.Add( new AgendaData( "Title 1" , "Description 1" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			agendas.Add( new AgendaData( "Title 2" , "Description 2" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			agendas.Add( new AgendaData( "Title 3" , "Description 3" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			_agendaBll.InsertAgendaData( agendas );
			AgendaDataCollection agendasToUpdate = _agendaBll.GetAgendaData();
			AgendaUnitTestHelper.AreEqual( agendas , agendasToUpdate );
			AgendaUnitTestHelper.UpdateAgendas( agendasToUpdate );
			_agendaBll.UpdateAgendaData( agendasToUpdate );
			AgendaDataCollection agendasResult = _agendaBll.GetAgendaData();
			AgendaUnitTestHelper.AreEqual( agendasToUpdate , agendasResult );
		}

		/// <summary>
		/// A test for RemoveAgendas (remove a single agenda).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAgendaTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			AgendaData agenda = new AgendaData( "Title" , "Description" , testEmployee.SysId , AppointmentVisibility.Public , 0 );
			AgendaDataCollection agendas = AgendaDataCollection.FromSingleAgenda( agenda );
			_agendaBll.InsertAgendaData( agendas );
			AgendaDataCollection agendasToRemove = _agendaBll.GetAgendaData();
			AgendaUnitTestHelper.AreEqual( agendas , agendasToRemove );
			_agendaBll.RemoveAgendaData( agendasToRemove );
			AgendaDataCollection agendasResult = _agendaBll.GetAgendaData();
			Assert.AreEqual( 0 , agendasResult.Count , "Agendas are not removed from database!" );
			AgendaUnitTestHelper.AreInLogDeletes( agendasToRemove );
		}

		/// <summary>
		/// A test for RemoveAgendas (remove multiple agendas).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAgendasTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			AgendaDataCollection agendas = new AgendaDataCollection();
			agendas.Add( new AgendaData( "Title 1" , "Description 1" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			agendas.Add( new AgendaData( "Title 2" , "Description 2" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			agendas.Add( new AgendaData( "Title 3" , "Description 3" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			_agendaBll.InsertAgendaData( agendas );
			AgendaDataCollection agendasToRemove = _agendaBll.GetAgendaData();
			AgendaUnitTestHelper.AreEqual( agendas , agendasToRemove );
			_agendaBll.RemoveAgendaData( agendasToRemove );
			AgendaDataCollection agendasResult = _agendaBll.GetAgendaData();
			Assert.AreEqual( 0 , agendasResult.Count , "Agendas are not removed from database!" );
			AgendaUnitTestHelper.AreInLogDeletes( agendasToRemove );
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
