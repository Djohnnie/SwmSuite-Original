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
	/// Unittestclass to test the EmployeeGroupAlertBll methods.
	/// </summary>
	[TestClass()]
	public class EmployeeGroupAlertBllTest : IDisposable {

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

		#region -_ TestMethods _-

		/// <summary>
		/// A test for InsertEmployeeGroupAlerts (insert a single employeegroupalert).
		/// </summary>
		[TestMethod]
		public void Crud_InsertEmployeeGroupAlertTest() {
			AlertData alert = AlertUnitTestHelper.GetAlertTestData();
			EmployeeGroupData employeeGroup = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeGroupAlertBll bll = new EmployeeGroupAlertBll();
			EmployeeGroupAlertDataCollection employeeGroupAlerts = EmployeeGroupAlertDataCollection.FromSingleEmployeeGroupAlert(
				new EmployeeGroupAlertData( employeeGroup.SysId , alert.SysId ) );
			bll.InsertEmployeeGroupAlerts( employeeGroupAlerts );
			EmployeeGroupAlertDataCollection employeeGroupAlertsResult = bll.GetEmployeeGroupAlerts();
			EmployeeGroupAlertUnitTestHelper.AreEqual( employeeGroupAlerts , employeeGroupAlertsResult );
		}

		/// <summary>
		/// A test for InsertEmployeeGroupAlerts (insert multiple employeegroupalerts).
		/// </summary>
		[TestMethod]
		public void Crud_InsertEmployeeGroupAlertsTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert3 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeGroupData employeeGroup1 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData employeeGroup2 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData employeeGroup3 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeGroupAlertBll bll = new EmployeeGroupAlertBll();
			EmployeeGroupAlertDataCollection employeeGroupAlerts = new EmployeeGroupAlertDataCollection();
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup1.SysId , alert1.SysId ) );
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup2.SysId , alert2.SysId ) );
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup3.SysId , alert3.SysId ) );
			bll.InsertEmployeeGroupAlerts( employeeGroupAlerts );
			EmployeeGroupAlertDataCollection employeeGroupAlertsResult = bll.GetEmployeeGroupAlerts();
			EmployeeGroupAlertUnitTestHelper.AreEqual( employeeGroupAlerts , employeeGroupAlertsResult );
		}

		/// <summary>
		/// A test for UpdateEmployeeGroupAlerts (update a single employeegroupalert).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateEmployeeGroupAlertTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeGroupData employeeGroup1 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData employeeGroup2 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeGroupAlertBll bll = new EmployeeGroupAlertBll();
			EmployeeGroupAlertDataCollection employeeGroupAlerts = EmployeeGroupAlertDataCollection.FromSingleEmployeeGroupAlert(
				new EmployeeGroupAlertData( employeeGroup1.SysId , alert1.SysId ) );
			bll.InsertEmployeeGroupAlerts( employeeGroupAlerts );
			EmployeeGroupAlertDataCollection employeeGroupAlertsToUpdate = bll.GetEmployeeGroupAlerts();
			employeeGroupAlertsToUpdate[0].AlertSysId = alert2.SysId;
			employeeGroupAlertsToUpdate[0].EmployeeGroupSysId = employeeGroup2.SysId;
			bll.UpdateEmployeeGroupAlerts( employeeGroupAlertsToUpdate );
			EmployeeGroupAlertDataCollection employeeGroupAlertsResult = bll.GetEmployeeGroupAlerts();
			EmployeeGroupAlertUnitTestHelper.AreEqual( employeeGroupAlertsToUpdate , employeeGroupAlertsResult );
		}

		/// <summary>
		/// A test for UpdateEmployeeGroupAlerts (update multiple employeegroupalerts).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateEmployeeGroupAlertsTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeGroupData employeeGroup1 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData employeeGroup2 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeGroupAlertBll bll = new EmployeeGroupAlertBll();
			EmployeeGroupAlertDataCollection employeeGroupAlerts = new EmployeeGroupAlertDataCollection();
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup1.SysId , alert1.SysId ) );
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup2.SysId , alert2.SysId ) );
			bll.InsertEmployeeGroupAlerts( employeeGroupAlerts );
			EmployeeGroupAlertDataCollection employeeGroupAlertsToUpdate = bll.GetEmployeeGroupAlerts();
			employeeGroupAlertsToUpdate[0].AlertSysId = alert2.SysId;
			employeeGroupAlertsToUpdate[0].EmployeeGroupSysId = employeeGroup2.SysId;
			employeeGroupAlertsToUpdate[1].AlertSysId = alert1.SysId;
			employeeGroupAlertsToUpdate[1].EmployeeGroupSysId = employeeGroup1.SysId;
			bll.UpdateEmployeeGroupAlerts( employeeGroupAlertsToUpdate );
			EmployeeGroupAlertDataCollection employeeGroupAlertsResult = bll.GetEmployeeGroupAlerts();
			EmployeeGroupAlertUnitTestHelper.AreEqual( employeeGroupAlertsToUpdate , employeeGroupAlertsResult );
		}

		/// <summary>
		/// A test for RemoveEmployeeGroupAlerts (remove a single employeegroupalert).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveEmployeeGroupAlertTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeGroupData employeeGroup1 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData employeeGroup2 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeGroupAlertBll bll = new EmployeeGroupAlertBll();
			EmployeeGroupAlertDataCollection employeeGroupAlerts = EmployeeGroupAlertDataCollection.FromSingleEmployeeGroupAlert(
				new EmployeeGroupAlertData( employeeGroup1.SysId , alert1.SysId ) );
			bll.InsertEmployeeGroupAlerts( employeeGroupAlerts );
			EmployeeGroupAlertDataCollection employeeGroupAlertsToRemove = bll.GetEmployeeGroupAlerts();
			bll.RemoveEmployeeGroupAlerts( employeeGroupAlertsToRemove );
			EmployeeGroupAlertDataCollection employeeGroupAlertsResult = bll.GetEmployeeGroupAlerts();
			Assert.AreEqual( 0 , employeeGroupAlertsResult.Count , "The employeealerts should be removed!" );
			EmployeeGroupAlertUnitTestHelper.AreInLogDeletes( employeeGroupAlertsToRemove );
		}

		/// <summary>
		/// A test for RemoveEmployeeGroupAlerts (remove multiple employeegroupalerts).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveEmployeeGroupAlertsTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeGroupData employeeGroup1 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData employeeGroup2 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeGroupAlertBll bll = new EmployeeGroupAlertBll();
			EmployeeGroupAlertDataCollection employeeGroupAlerts = new EmployeeGroupAlertDataCollection();
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup1.SysId , alert1.SysId ) );
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup2.SysId , alert2.SysId ) );
			bll.InsertEmployeeGroupAlerts( employeeGroupAlerts );
			EmployeeGroupAlertDataCollection employeeGroupAlertsToRemove = bll.GetEmployeeGroupAlerts();
			bll.RemoveEmployeeGroupAlerts( employeeGroupAlertsToRemove );
			EmployeeGroupAlertDataCollection employeeGroupAlertsResult = bll.GetEmployeeGroupAlerts();
			Assert.AreEqual( 0 , employeeGroupAlertsResult.Count , "The employeealerts should be removed!" );
			EmployeeGroupAlertUnitTestHelper.AreInLogDeletes( employeeGroupAlertsToRemove );
		}

		/// <summary>
		/// A test for GetEmployeeGroupAlertsForAlert.
		/// </summary>
		[TestMethod]
		public void Crud_GetEmployeeGroupAlertsForAlertTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert3 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeGroupData employeeGroup = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeGroupAlertBll bll = new EmployeeGroupAlertBll();
			EmployeeGroupAlertDataCollection employeeGroupAlerts = new EmployeeGroupAlertDataCollection();
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup.SysId , alert1.SysId ) );
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup.SysId , alert2.SysId ) );
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup.SysId , alert3.SysId ) );
			bll.InsertEmployeeGroupAlerts( employeeGroupAlerts );

			EmployeeGroupAlertDataCollection employeeGroupAlertsResult = bll.GetEmployeeGroupAlertsForAlert( alert2.SysId );
			Assert.AreEqual( 1 , employeeGroupAlertsResult.Count , "There should only be 1 employeegroupalert found." );
			Assert.AreEqual( alert2.SysId , employeeGroupAlertsResult[0].AlertSysId );
		}

		/// <summary>
		/// A test for GetEmployeeGroupAlertsForEmployeeGroup.
		/// </summary>
		[TestMethod]
		public void Crud_GetEmployeeGroupAlertsForEmployeeGroupTest() {
			AlertData alert = AlertUnitTestHelper.GetAlertTestData();
			EmployeeGroupData employeeGroup1 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData employeeGroup2 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData employeeGroup3 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeGroupAlertBll bll = new EmployeeGroupAlertBll();
			EmployeeGroupAlertDataCollection employeeGroupAlerts = new EmployeeGroupAlertDataCollection();
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup1.SysId , alert.SysId ) );
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup2.SysId , alert.SysId ) );
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup3.SysId , alert.SysId ) );
			bll.InsertEmployeeGroupAlerts( employeeGroupAlerts );

			EmployeeGroupAlertDataCollection employeeGroupAlertsResult = bll.GetEmployeeGroupAlertsForEmployeeGroup( employeeGroup2.SysId );
			Assert.AreEqual( 1 , employeeGroupAlertsResult.Count , "There should only be 1 employeegroupalert found." );
			Assert.AreEqual( employeeGroup2.SysId , employeeGroupAlertsResult[0].EmployeeGroupSysId );
		}

		/// <summary>
		/// A test for GetEmployeeGroupAlertsForAlertAndEmployeeGroup.
		/// </summary>
		[TestMethod]
		public void Crud_GetEmployeeGroupAlertsForAlertAndEmployeeGroupTest() {
			AlertData alert1 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert2 = AlertUnitTestHelper.GetAlertTestData();
			AlertData alert3 = AlertUnitTestHelper.GetAlertTestData();
			EmployeeGroupData employeeGroup1 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData employeeGroup2 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData employeeGroup3 = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			EmployeeGroupAlertBll bll = new EmployeeGroupAlertBll();
			EmployeeGroupAlertDataCollection employeeGroupAlerts = new EmployeeGroupAlertDataCollection();
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup1.SysId , alert1.SysId ) );
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup2.SysId , alert2.SysId ) );
			employeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup3.SysId , alert3.SysId ) );
			bll.InsertEmployeeGroupAlerts( employeeGroupAlerts );

			EmployeeGroupAlertDataCollection employeeGroupAlertsResult = bll.GetEmployeeGroupAlertsForAlertAndEmployeeGroup( alert2.SysId , employeeGroup2.SysId );
			Assert.AreEqual( 1 , employeeGroupAlertsResult.Count , "There should only be 1 employeealert found." );
			Assert.AreEqual( alert2.SysId , employeeGroupAlertsResult[0].AlertSysId );
			Assert.AreEqual( employeeGroup2.SysId , employeeGroupAlertsResult[0].EmployeeGroupSysId );
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
