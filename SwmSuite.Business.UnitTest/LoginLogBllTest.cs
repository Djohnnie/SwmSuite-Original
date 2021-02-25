using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the LoginLogDataBll methods.
	/// </summary>
	[TestClass()]
	public class LoginLogBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private LoginLogBll _loginLogBll = new LoginLogBll();

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
		/// A test for InsertLoginLogs (insert a single loginLog).
		/// </summary>
		[TestMethod]
		public void Crud_InsertLoginLogTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			LoginLogDataCollection loginLogs =
				LoginLogDataCollection.FromSingleLoginLog( new LoginLogData( DateTime.Today , testEmployee.SysId ) );
			_loginLogBll.InsertLoginLogData( loginLogs );
			LoginLogDataCollection loginLogsResult = _loginLogBll.GetLoginLogData();
			LoginLogUnitTestHelper.AreEqual( loginLogs , loginLogsResult );
		}

		/// <summary>
		/// A test for InsertLoginLogs (insert multiple loginLogs).
		/// </summary>
		[TestMethod]
		public void Crud_InsertLoginLogsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			LoginLogDataCollection loginLogs = new LoginLogDataCollection();
			loginLogs.Add( new LoginLogData( DateTime.Today.AddMonths( 2 ) , testEmployee.SysId ) );
			loginLogs.Add( new LoginLogData( DateTime.Today.AddMonths( 1 ) , testEmployee.SysId ) );
			loginLogs.Add( new LoginLogData( DateTime.Today , testEmployee.SysId ) );
			_loginLogBll.InsertLoginLogData( loginLogs );
			LoginLogDataCollection loginLogsResult = _loginLogBll.GetLoginLogData();
			LoginLogUnitTestHelper.AreEqual( loginLogs , loginLogsResult );
		}

		/// <summary>
		/// A test for UpdateLoginLogs (update a single loginLog).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateLoginLogTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			LoginLogDataCollection loginLogs =
				LoginLogDataCollection.FromSingleLoginLog( new LoginLogData( DateTime.Now , testEmployee.SysId ) );
			_loginLogBll.InsertLoginLogData( loginLogs );
			LoginLogDataCollection loginLogsToUpdate = _loginLogBll.GetLoginLogData();
			LoginLogUnitTestHelper.UpdateLoginLogData( loginLogsToUpdate );
			_loginLogBll.UpdateLoginLogData( loginLogsToUpdate );
			LoginLogDataCollection loginLogsResult = _loginLogBll.GetLoginLogData();
			LoginLogUnitTestHelper.AreEqual( loginLogsToUpdate , loginLogsResult );
		}

		/// <summary>
		/// A test for UpdateLoginLogs (update multiple loginLogs).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateLoginLogsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			LoginLogDataCollection loginLogs = new LoginLogDataCollection();
			loginLogs.Add( new LoginLogData( DateTime.Today , testEmployee.SysId ) );
			loginLogs.Add( new LoginLogData( DateTime.Today.AddMonths( 1 ) , testEmployee.SysId ) );
			loginLogs.Add( new LoginLogData( DateTime.Today.AddMonths( 2 ) , testEmployee.SysId ) );
			_loginLogBll.InsertLoginLogData( loginLogs );
			LoginLogDataCollection loginLogsToUpdate = _loginLogBll.GetLoginLogData();
			LoginLogUnitTestHelper.UpdateLoginLogData( loginLogsToUpdate );
			_loginLogBll.UpdateLoginLogData( loginLogsToUpdate );
			LoginLogDataCollection loginLogsResult = _loginLogBll.GetLoginLogData();
			LoginLogUnitTestHelper.AreEqual( loginLogsToUpdate , loginLogsResult );
		}

		/// <summary>
		/// A test for RemoveLoginLogs (remove a single loginLog).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveLoginLogTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			LoginLogDataCollection loginLogs =
				LoginLogDataCollection.FromSingleLoginLog( new LoginLogData( DateTime.Now , testEmployee.SysId ) );
			_loginLogBll.InsertLoginLogData( loginLogs );
			LoginLogDataCollection loginLogsToRemove = _loginLogBll.GetLoginLogData();
			_loginLogBll.RemoveLoginLogData( loginLogsToRemove );
			LoginLogDataCollection loginLogsResult = _loginLogBll.GetLoginLogData();
			Assert.AreEqual( 0 , loginLogsResult.Count , "The loginLogs should be removed!" );
			LoginLogUnitTestHelper.AreInLogDeletes( loginLogsToRemove );
		}

		/// <summary>
		/// A test for RemoveLoginLogs (remove multiple loginLogs).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveLoginLogsTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			LoginLogDataCollection loginLogs = new LoginLogDataCollection();
			loginLogs.Add( new LoginLogData( DateTime.Today , testEmployee.SysId ) );
			loginLogs.Add( new LoginLogData( DateTime.Today.AddMonths( 1 ) , testEmployee.SysId ) );
			loginLogs.Add( new LoginLogData( DateTime.Today.AddMonths( 2 ) , testEmployee.SysId ) );
			_loginLogBll.InsertLoginLogData( loginLogs );
			LoginLogDataCollection loginLogsToRemove = _loginLogBll.GetLoginLogData();
			_loginLogBll.RemoveLoginLogData( loginLogsToRemove );
			LoginLogDataCollection loginLogsResult = _loginLogBll.GetLoginLogData();
			Assert.AreEqual( 0 , loginLogsResult.Count , "The loginLogs should be removed!" );
			LoginLogUnitTestHelper.AreInLogDeletes( loginLogsToRemove );
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
