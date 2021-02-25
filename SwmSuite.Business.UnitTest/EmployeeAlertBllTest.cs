using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Framework;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Business;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the EmployeeAlertBll methods.
	/// </summary>
	[TestClass()]
	public class EmployeeAlertBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;
		private TransactionScope mainScope;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the test context which provides
		/// information about and functionality for the current test run.
		/// </summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		#endregion

		#region -_ Additional test attributes _-

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
			mainScope.Dispose();
		}

		#endregion

		#region -_ Crud Test Methods _-

		/// <summary>
		/// A test for InsertEmployeeAlerts (insert a single employeealert).
		/// </summary>
		[TestMethod]
		public void Crud_InsertEmployeeAlertTest() {
			AlertData alert = AlertUnitTestHelper.GetAlertTestData();
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();

			EmployeeAlertBll bll = new EmployeeAlertBll();
			EmployeeAlertDataCollection employeeAlerts = EmployeeAlertDataCollection.FromSingleAlert(
				new EmployeeAlertData( employee.SysId , alert.SysId ) );
			bll.InsertEmployeeAlertData( employeeAlerts );
			EmployeeAlertDataCollection employeeAlertsResult = bll.GetEmployeeAlertData();
			EmployeeAlertUnitTestHelper.AreEqual( employeeAlerts , employeeAlertsResult );
		}

		/// <summary>
		/// A test for InsertEmployeeAlerts (insert multiple employeealerts).
		/// </summary>
		[TestMethod]
		public void Crud_InsertEmployeeAlertsTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert3 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeData employee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee3 = EmployeeUnitTestHelper.GetEmployeeTestData();

			EmployeeAlertBll bll = new EmployeeAlertBll();
			EmployeeAlertDataCollection employeeAlerts = new EmployeeAlertDataCollection();
			employeeAlerts.Add( new EmployeeAlertData( employee1.SysId , alert1.SysId ) );
			employeeAlerts.Add( new EmployeeAlertData( employee2.SysId , alert2.SysId ) );
			employeeAlerts.Add( new EmployeeAlertData( employee3.SysId , alert3.SysId ) );
			bll.InsertEmployeeAlertData( employeeAlerts );
			EmployeeAlertDataCollection employeeAlertsResult = bll.GetEmployeeAlertData();
			EmployeeAlertUnitTestHelper.AreEqual( employeeAlerts , employeeAlertsResult );
		}

		/// <summary>
		/// A test for UpdateEmployeeAlerts (update a single employeealert).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateEmployeeAlertTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeData employee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee2 = EmployeeUnitTestHelper.GetEmployeeTestData();

			EmployeeAlertBll bll = new EmployeeAlertBll();
			EmployeeAlertDataCollection employeeAlerts = EmployeeAlertDataCollection.FromSingleAlert(
				new EmployeeAlertData( employee1.SysId , alert1.SysId ) );
			bll.InsertEmployeeAlertData( employeeAlerts );
			EmployeeAlertDataCollection employeeAlertsToUpdate = bll.GetEmployeeAlertData();
			employeeAlertsToUpdate[0].AlertSysId = alert2.SysId;
			employeeAlertsToUpdate[0].EmployeeSysId = employee2.SysId;
			bll.UpdateEmployeeAlertData( employeeAlertsToUpdate );
			EmployeeAlertDataCollection employeeAlertsResult = bll.GetEmployeeAlertData();
			EmployeeAlertUnitTestHelper.AreEqual( employeeAlertsToUpdate , employeeAlertsResult );
		}

		/// <summary>
		/// A test for UpdateEmployeeAlerts (update multiple employeealerts).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateEmployeeAlertsTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeData employee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee2 = EmployeeUnitTestHelper.GetEmployeeTestData();

			EmployeeAlertBll bll = new EmployeeAlertBll();
			EmployeeAlertDataCollection employeeAlerts = new EmployeeAlertDataCollection();
			employeeAlerts.Add( new EmployeeAlertData( employee1.SysId , alert1.SysId ) );
			employeeAlerts.Add( new EmployeeAlertData( employee2.SysId , alert2.SysId ) );
			bll.InsertEmployeeAlertData( employeeAlerts );
			EmployeeAlertDataCollection employeeAlertsToUpdate = bll.GetEmployeeAlertData();
			employeeAlertsToUpdate[0].AlertSysId = alert2.SysId;
			employeeAlertsToUpdate[0].EmployeeSysId = employee2.SysId;
			employeeAlertsToUpdate[1].AlertSysId = alert1.SysId;
			employeeAlertsToUpdate[1].EmployeeSysId = employee1.SysId;
			bll.UpdateEmployeeAlertData( employeeAlertsToUpdate );
			EmployeeAlertDataCollection employeeAlertsResult = bll.GetEmployeeAlertData();
			EmployeeAlertUnitTestHelper.AreEqual( employeeAlertsToUpdate , employeeAlertsResult );
		}

		/// <summary>
		/// A test for RemoveEmployeeAlerts (remove a single employeealert).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveEmployeeAlertTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeData employee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee2 = EmployeeUnitTestHelper.GetEmployeeTestData();

			EmployeeAlertBll bll = new EmployeeAlertBll();
			EmployeeAlertDataCollection employeeAlerts = EmployeeAlertDataCollection.FromSingleAlert(
				new EmployeeAlertData( employee1.SysId , alert1.SysId ) );
			bll.InsertEmployeeAlertData( employeeAlerts );
			EmployeeAlertDataCollection employeeAlertsToRemove = bll.GetEmployeeAlertData();
			bll.RemoveEmployeeAlertData( employeeAlertsToRemove );
			EmployeeAlertDataCollection employeeAlertsResult = bll.GetEmployeeAlertData();
			Assert.AreEqual( 0 , employeeAlertsResult.Count , "The employeealerts should be removed!" );
			EmployeeAlertUnitTestHelper.AreInLogDeletes( employeeAlertsToRemove );
		}

		/// <summary>
		/// A test for RemoveEmployeeAlerts (remove multiple employeealerts).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveEmployeeAlertsTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeData employee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee2 = EmployeeUnitTestHelper.GetEmployeeTestData();

			EmployeeAlertBll bll = new EmployeeAlertBll();
			EmployeeAlertDataCollection employeeAlerts = new EmployeeAlertDataCollection();
			employeeAlerts.Add( new EmployeeAlertData( employee1.SysId , alert1.SysId ) );
			employeeAlerts.Add( new EmployeeAlertData( employee2.SysId , alert2.SysId ) );
			bll.InsertEmployeeAlertData( employeeAlerts );
			EmployeeAlertDataCollection employeeAlertsToRemove = bll.GetEmployeeAlertData();
			bll.RemoveEmployeeAlertData( employeeAlertsToRemove );
			EmployeeAlertDataCollection employeeAlertsResult = bll.GetEmployeeAlertData();
			Assert.AreEqual( 0 , employeeAlertsResult.Count , "The employeealerts should be removed!" );
			EmployeeAlertUnitTestHelper.AreInLogDeletes( employeeAlertsToRemove );
		}

		/// <summary>
		/// A test for GetEmployeeAlertsForAlert.
		/// </summary>
		[TestMethod]
		public void Crud_GetEmployeeAlertsForAlertTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert3 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();

			EmployeeAlertBll bll = new EmployeeAlertBll();
			EmployeeAlertDataCollection employeeAlerts = new EmployeeAlertDataCollection();
			employeeAlerts.Add( new EmployeeAlertData( employee.SysId , alert1.SysId ) );
			employeeAlerts.Add( new EmployeeAlertData( employee.SysId , alert2.SysId ) );
			employeeAlerts.Add( new EmployeeAlertData( employee.SysId , alert3.SysId ) );
			bll.InsertEmployeeAlertData( employeeAlerts );

			EmployeeAlertDataCollection employeeAlertsResult = bll.GetEmployeeAlertDataForAlert( alert2.SysId );
			Assert.AreEqual( 1 , employeeAlertsResult.Count , "There should only be 1 employeealert found." );
			Assert.AreEqual( alert2.SysId , employeeAlertsResult[0].AlertSysId );
		}

		/// <summary>
		/// A test for GetEmployeeAlertsForEmployee.
		/// </summary>
		[TestMethod]
		public void Crud_GetEmployeeAlertsForEmployeeTest() {
			AlertData alert = AlertUnitTestHelper.GetAlertTestData();
			EmployeeData employee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee3 = EmployeeUnitTestHelper.GetEmployeeTestData();

			EmployeeAlertBll bll = new EmployeeAlertBll();
			EmployeeAlertDataCollection employeeAlerts = new EmployeeAlertDataCollection();
			employeeAlerts.Add( new EmployeeAlertData( employee1.SysId , alert.SysId ) );
			employeeAlerts.Add( new EmployeeAlertData( employee2.SysId , alert.SysId ) );
			employeeAlerts.Add( new EmployeeAlertData( employee3.SysId , alert.SysId ) );
			bll.InsertEmployeeAlertData( employeeAlerts );

			EmployeeAlertDataCollection employeeAlertsResult = bll.GetEmployeeAlertDataForEmployee( employee2.SysId );
			Assert.AreEqual( 1 , employeeAlertsResult.Count , "There should only be 1 employeealert found." );
			Assert.AreEqual( employee2.SysId , employeeAlertsResult[0].EmployeeSysId );
		}

		/// <summary>
		/// A test for GetEmployeeAlertsForAlertAndEmployee.
		/// </summary>
		[TestMethod]
		public void Crud_GetEmployeeAlertsForAlertAndEmployeeTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert3 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeData employee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee3 = EmployeeUnitTestHelper.GetEmployeeTestData();

			EmployeeAlertBll bll = new EmployeeAlertBll();
			EmployeeAlertDataCollection employeeAlerts = new EmployeeAlertDataCollection();
			employeeAlerts.Add( new EmployeeAlertData( employee1.SysId , alert1.SysId ) );
			employeeAlerts.Add( new EmployeeAlertData( employee2.SysId , alert2.SysId ) );
			employeeAlerts.Add( new EmployeeAlertData( employee3.SysId , alert3.SysId ) );
			bll.InsertEmployeeAlertData( employeeAlerts );

			EmployeeAlertDataCollection employeeAlertsResult = bll.GetEmployeeAlertDataForAlertAndEmployee( alert2.SysId , employee2.SysId );
			Assert.AreEqual( 1 , employeeAlertsResult.Count , "There should only be 1 employeealert found." );
			Assert.AreEqual( alert2.SysId , employeeAlertsResult[0].AlertSysId );
			Assert.AreEqual( employee2.SysId , employeeAlertsResult[0].EmployeeSysId );
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
