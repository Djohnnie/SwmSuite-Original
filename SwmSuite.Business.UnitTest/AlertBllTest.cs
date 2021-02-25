using SwmSuite.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using System.Transactions;
using System;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the AlertBll methods.
	/// </summary>
	[TestClass()]
	public class AlertBllTest : IDisposable {

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

		#region -_ Business Test Methods _-

		[TestMethod]
		public void Business_GetAlertsTest(){
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeGroupData testEmployeeGroup = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
		}

		[TestMethod]
		public void Business_GetGlobalAlertsTest() {
		}

		[TestMethod]
		public void Business_GetAlertsForEmployeeTest() {
		}

		[TestMethod]
		public void Business_GetAlertsForEmployeeGroupTest() {
		}

		/// <summary>
		/// Test for the CreateAlert method.
		/// </summary>
		/// <remarks>
		/// The alerts created will be coupled to employees and employeegroups.
		/// </remarks>
		[TestMethod]
		public void Business_CreateAlertTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeGroupData testEmployeeGroup = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			
			Alert newAlert = new Alert();
			newAlert.Visible = true;
			newAlert.Message = "Alert";
			newAlert.Employees.Add( new Employee() { SysId = testEmployee.SysId } );
			newAlert.EmployeeGroups.Add( new EmployeeGroup() { SysId = testEmployeeGroup.SysId } );

			AlertBll bll = new AlertBll();
			bll.CreateAlert( newAlert );

			AlertDataCollection alertDataResult = bll.GetAlertData();
			EmployeeAlertDataCollection employeeAlertDataResult = 
				new EmployeeAlertBll().GetEmployeeAlertData();
			EmployeeGroupAlertDataCollection employeeGroupAlertDataResult =
				new EmployeeGroupAlertBll().GetEmployeeGroupAlerts();

			Assert.AreEqual( 1 , alertDataResult.Count , "There should be 1 alert in the database!" );
			Assert.AreEqual( 1 , employeeAlertDataResult.Count , "There should be 1 employeealert in the database!" );
			Assert.AreEqual( testEmployee.SysId , employeeAlertDataResult[0].EmployeeSysId );
			Assert.AreEqual( 1 , employeeGroupAlertDataResult.Count , "There should be 1 employeegroupalert in the database!" );
			Assert.AreEqual( testEmployeeGroup.SysId , employeeGroupAlertDataResult[0].EmployeeGroupSysId );
		}

		[TestMethod]
		public void Business_UpdateAlertTest() {
			EmployeeData testEmployee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testEmployee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeGroupData testEmployeeGroup1 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData testEmployeeGroup2 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			Alert newAlert = new Alert();
			newAlert.Visible = true;
			newAlert.Message = "Alert";
			newAlert.Employees.Add( new Employee() { SysId = testEmployee1.SysId } );
			newAlert.EmployeeGroups.Add( new EmployeeGroup() { SysId = testEmployeeGroup1.SysId } );

			AlertBll bll = new AlertBll();
			bll.CreateAlert( newAlert );

			AlertDataCollection alertDataToUpdate = bll.GetAlertData();
			Alert alertToUpdate = new Alert();
			alertToUpdate.SysId = alertDataToUpdate[0].SysId;
			alertToUpdate.RowVersion = alertDataToUpdate[0].RowVersion;
			alertToUpdate.Visible = false;
			alertToUpdate.Message = "Update Alert";
			alertToUpdate.Employees.Add( new Employee() { SysId = testEmployee2.SysId } );
			alertToUpdate.EmployeeGroups.Add( new EmployeeGroup() { SysId = testEmployeeGroup2.SysId } );
			bll.UpdateAlert( alertToUpdate );

			AlertDataCollection alertDataResult = bll.GetAlertData();
			EmployeeAlertDataCollection employeeAlertDataResult =
				new EmployeeAlertBll().GetEmployeeAlertData();
			EmployeeGroupAlertDataCollection employeeGroupAlertDataResult =
				new EmployeeGroupAlertBll().GetEmployeeGroupAlerts();

			Assert.AreEqual( 1 , alertDataResult.Count , "There should be 1 alert in the database!" );
			Assert.AreEqual( false , alertDataResult[0].Visible );
			Assert.AreEqual( "Update Alert" , alertDataResult[0].Message );
			Assert.AreEqual( 1 , employeeAlertDataResult.Count , "There should be 1 employeealert in the database!" );
			Assert.AreEqual( testEmployee2.SysId , employeeAlertDataResult[0].EmployeeSysId );
			Assert.AreEqual( 1 , employeeGroupAlertDataResult.Count , "There should be 1 employeegroupalert in the database!" );
			Assert.AreEqual( testEmployeeGroup2.SysId , employeeGroupAlertDataResult[0].EmployeeGroupSysId );
		}

		[TestMethod]
		public void Business_RemoveAlertsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeGroupData testEmployeeGroup = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			Alert newAlert = new Alert();
			newAlert.Visible = true;
			newAlert.Message = "Alert";
			newAlert.Employees.Add( new Employee() { SysId = testEmployee.SysId } );
			newAlert.EmployeeGroups.Add( new EmployeeGroup() { SysId = testEmployeeGroup.SysId } );

			AlertBll bll = new AlertBll();
			bll.CreateAlert( newAlert );

			AlertDataCollection alertDataToRemove = bll.GetAlertData();
			Alert alertToRemove = new Alert();
			alertToRemove.SysId = alertDataToRemove[0].SysId;
			alertToRemove.RowVersion = alertDataToRemove[0].RowVersion;
			alertToRemove.Visible = alertDataToRemove[0].Visible;
			alertToRemove.Message = alertDataToRemove[0].Message;
			bll.RemoveAlerts( AlertCollection.FromSingleAlert( alertToRemove ) );

			AlertDataCollection alertDataResult = bll.GetAlertData();
			EmployeeAlertDataCollection employeeAlertDataResult =
				new EmployeeAlertBll().GetEmployeeAlertData();
			EmployeeGroupAlertDataCollection employeeGroupAlertDataResult =
				new EmployeeGroupAlertBll().GetEmployeeGroupAlerts();
			Assert.AreEqual( 0 , alertDataResult.Count , "The alert should have been deleted!" );
			Assert.AreEqual( 0 , employeeAlertDataResult.Count , "The employeealert links should be deleted!" );
			Assert.AreEqual( 0 , employeeGroupAlertDataResult.Count , "The employeegroupalert links should be deleted!" );
		}

		#endregion

		#region -_ Crud Test Methods _-

		/// <summary>
		///A test for InsertAlerts (insert a single alert).
		///</summary>
		[TestMethod]
		public void Crud_InsertAlertTest() {
			AlertBll bll = new AlertBll();
			AlertDataCollection alerts = AlertDataCollection.FromSingleAlert( new AlertData( true , "--- Alert ---" ) );
			bll.InsertAlertData( alerts );
			AlertDataCollection alertsResult = bll.GetAlertData();
			AlertUnitTestHelper.AreEqual( alerts , alertsResult );
		}

		/// <summary>
		///A test for InsertAlerts (insert multiple alerts).
		///</summary>
		[TestMethod]
		public void Crud_InsertAlertsTest() {
			AlertBll bll = new AlertBll();
			AlertDataCollection alerts = new AlertDataCollection();
			alerts.Add( new AlertData( true , "--- Alert 1 ---" ) );
			alerts.Add( new AlertData( true , "--- Alert 2 ---" ) );
			alerts.Add( new AlertData( true , "--- Alert 3 ---" ) );
			AlertDataCollection alertsInsertResult = bll.InsertAlertData( alerts );
			AlertDataCollection alertsResult = bll.GetAlertData();
			AlertUnitTestHelper.AreEqual( alertsResult , alertsInsertResult );
			AlertUnitTestHelper.AreEqual( alerts , alertsResult );
		}

		/// <summary>
		///A test for UpdateAlerts (update a single alert).
		///</summary>
		[TestMethod]
		public void Crud_UpdateAlertTest() {
			AlertBll bll = new AlertBll();
			AlertDataCollection alerts = AlertDataCollection.FromSingleAlert( new AlertData( true , "--- Alert ---" ) );
			bll.InsertAlertData( alerts );
			AlertDataCollection alertsToUpdate = bll.GetAlertData();
			AlertUnitTestHelper.AreEqual( alerts , alertsToUpdate );
			AlertUnitTestHelper.UpdateAlerts( alertsToUpdate );
			bll.UpdateAlertData( alertsToUpdate );
			AlertDataCollection alertsResult = bll.GetAlertData();
			AlertUnitTestHelper.AreEqual( alertsToUpdate , alertsResult );
		}

		/// <summary>
		///A test for UpdateAlerts (update multiple alerts).
		///</summary>
		[TestMethod]
		public void Crud_UpdateAlertsTest() {
			AlertBll bll = new AlertBll();
			AlertDataCollection alerts = new AlertDataCollection();
			alerts.Add( new AlertData( true , "--- Alert 1 ---" ) );
			alerts.Add( new AlertData( true , "--- Alert 2 ---" ) );
			alerts.Add( new AlertData( true , "--- Alert 3 ---" ) );
			bll.InsertAlertData( alerts );
			AlertDataCollection alertsToUpdate = bll.GetAlertData();
			AlertUnitTestHelper.AreEqual( alerts , alertsToUpdate );
			AlertUnitTestHelper.UpdateAlerts( alertsToUpdate );
			bll.UpdateAlertData( alertsToUpdate );
			AlertDataCollection alertsResult = bll.GetAlertData();
			AlertUnitTestHelper.AreEqual( alertsToUpdate , alertsResult );
		}

		/// <summary>
		///A test for RemoveAlerts (remove a single alert).
		///</summary>
		[TestMethod]
		public void Crud_RemoveAlertTest() {
			AlertBll bll = new AlertBll();
			AlertDataCollection alerts = AlertDataCollection.FromSingleAlert( new AlertData( true , "--- Alert ---" ) );
			bll.InsertAlertData( alerts );
			AlertDataCollection alertsToRemove = bll.GetAlertData();
			bll.RemoveAlertData( alertsToRemove );
			AlertDataCollection alertsResult = bll.GetAlertData();
			Assert.AreEqual( 0 , alertsResult.Count , "RemoveAlerts did not remove all rows!" );
			AlertUnitTestHelper.AreInLogDeletes( alertsToRemove );
		}

		/// <summary>
		/// A test for RemoveAlerts (remove multiple alerts).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAlertsTest() {
			AlertBll bll = new AlertBll();
			AlertDataCollection alerts = new AlertDataCollection();
			alerts.Add( new AlertData( true , "--- Alert 1 ---" ) );
			alerts.Add( new AlertData( true , "--- Alert 2 ---" ) );
			alerts.Add( new AlertData( true , "--- Alert 3 ---" ) );
			bll.InsertAlertData( alerts );
			AlertDataCollection alertsToRemove = bll.GetAlertData();
			bll.RemoveAlertData( alertsToRemove );
			AlertDataCollection alertsResult = bll.GetAlertData();
			Assert.AreEqual( 0 , alertsResult.Count , "RemoveAlerts did not remove all rows!" );
			AlertUnitTestHelper.AreInLogDeletes( alertsToRemove );
		}

		[TestMethod]
		public void Crud_GetGlobalAlertsTest() {
			AlertBll bll = new AlertBll();

			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert3 = AlertUnitTestHelper.GetAlertTestData();
			
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeGroupData employeeGroup = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeAlertDataCollection employeeAlerts = EmployeeAlertDataCollection.FromSingleAlert(
				new EmployeeAlertData( employee.SysId , alert1.SysId ) );
			new EmployeeAlertBll().InsertEmployeeAlertData( employeeAlerts );

			EmployeeGroupAlertDataCollection employeeGroupAlerts = EmployeeGroupAlertDataCollection.FromSingleEmployeeGroupAlert(
				new EmployeeGroupAlertData( employeeGroup.SysId , alert2.SysId ) );
			new EmployeeGroupAlertBll().InsertEmployeeGroupAlerts( employeeGroupAlerts );

			AlertDataCollection alertsResult = bll.GetGlobalAlertData();

			Assert.AreEqual( 1 , alertsResult.Count , "There should only be one global alert in the database!" );
			Assert.AreEqual( alert3.SysId , alertsResult[0].SysId , "The global alert should be the last test alert created!" );
		}

		[TestMethod]
		public void Crud_GetAlertsForEmployeeTest() {
			AlertBll bll = new AlertBll();

			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert3 = AlertUnitTestHelper.GetAlertTestData();

			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeGroupData employeeGroup = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeAlertDataCollection employeeAlerts = EmployeeAlertDataCollection.FromSingleAlert(
				new EmployeeAlertData( employee.SysId , alert1.SysId ) );
			new EmployeeAlertBll().InsertEmployeeAlertData( employeeAlerts );

			EmployeeGroupAlertDataCollection employeeGroupAlerts = EmployeeGroupAlertDataCollection.FromSingleEmployeeGroupAlert(
				new EmployeeGroupAlertData( employeeGroup.SysId , alert2.SysId ) );
			new EmployeeGroupAlertBll().InsertEmployeeGroupAlerts( employeeGroupAlerts );

			AlertDataCollection alertsResult = bll.GetAlertDataForEmployee( employee.SysId );

			Assert.AreEqual( 1 , alertsResult.Count , "There should only be one employeealert in the database!" );
			Assert.AreEqual( alert1.SysId , alertsResult[0].SysId , "The employeealert should be the last test alert created!" );
		}

		[TestMethod]
		public void Crud_GetAlertsForEmployeeGroupTest() {
			AlertBll bll = new AlertBll();

			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert3 = AlertUnitTestHelper.GetAlertTestData();

			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeGroupData employeeGroup = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeAlertDataCollection employeeAlerts = EmployeeAlertDataCollection.FromSingleAlert(
				new EmployeeAlertData( employee.SysId , alert1.SysId ) );
			new EmployeeAlertBll().InsertEmployeeAlertData( employeeAlerts );

			EmployeeGroupAlertDataCollection employeeGroupAlerts = EmployeeGroupAlertDataCollection.FromSingleEmployeeGroupAlert(
				new EmployeeGroupAlertData( employeeGroup.SysId , alert2.SysId ) );
			new EmployeeGroupAlertBll().InsertEmployeeGroupAlerts( employeeGroupAlerts );

			AlertDataCollection alertsResult = bll.GetAlertDataForEmployeeGroup( employeeGroup.SysId );

			Assert.AreEqual( 1 , alertsResult.Count , "There should only be one employeegroupalert in the database!" );
			Assert.AreEqual( alert2.SysId , alertsResult[0].SysId , "The employeegroupalert should be the last test alert created!" );
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