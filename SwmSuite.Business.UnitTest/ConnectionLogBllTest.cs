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
	/// Unittestclass to test the ConnectionLogBll methods.
	/// </summary>
	[TestClass()]
	public class ConnectionLogBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private ConnectionLogBll _connectionLogBll = new ConnectionLogBll();

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
		/// A test for InsertConnectionLogs (insert a single connectionLog).
		/// </summary>
		[TestMethod]
		public void Crud_InsertConnectionLogTest() {
			ConnectionLogDataCollection connectionLogs =
				ConnectionLogDataCollection.FromSingleConnectionLog( new ConnectionLogData( DateTime.Today , "localhost" ) );
			_connectionLogBll.InsertConnectionLogData( connectionLogs );
			ConnectionLogDataCollection connectionLogsResult = _connectionLogBll.GetConnectionLogData();
			ConnectionLogUnitTestHelper.AreEqual( connectionLogs , connectionLogsResult );
		}

		/// <summary>
		/// A test for InsertConnectionLogs (insert multiple connectionLogs).
		/// </summary>
		[TestMethod]
		public void Crud_InsertConnectionLogsTest() {
			ConnectionLogDataCollection connectionLogs = new ConnectionLogDataCollection();
			connectionLogs.Add( new ConnectionLogData( DateTime.Today.AddMonths( 2 ) , "localhost3" ) );
			connectionLogs.Add( new ConnectionLogData( DateTime.Today.AddMonths( 1 ) , "localhost2" ) );
			connectionLogs.Add( new ConnectionLogData( DateTime.Today , "localhost1" ) );
			_connectionLogBll.InsertConnectionLogData( connectionLogs );
			ConnectionLogDataCollection connectionLogsResult = _connectionLogBll.GetConnectionLogData();
			ConnectionLogUnitTestHelper.AreEqual( connectionLogs , connectionLogsResult );
		}

		/// <summary>
		/// A test for UpdateConnectionLogs (update a single connectionLog).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateConnectionLogTest() {
			ConnectionLogDataCollection connectionLogs =
				ConnectionLogDataCollection.FromSingleConnectionLog( new ConnectionLogData( DateTime.Now , "localhost" ) );
			_connectionLogBll.InsertConnectionLogData( connectionLogs );
			ConnectionLogDataCollection connectionLogsToUpdate = _connectionLogBll.GetConnectionLogData();
			ConnectionLogUnitTestHelper.UpdateConnectionLogs( connectionLogsToUpdate );
			_connectionLogBll.UpdateConnectionLogData( connectionLogsToUpdate );
			ConnectionLogDataCollection connectionLogsResult = _connectionLogBll.GetConnectionLogData();
			ConnectionLogUnitTestHelper.AreEqual( connectionLogsToUpdate , connectionLogsResult );
		}

		/// <summary>
		/// A test for UpdateConnectionLogs (update multiple connectionLogs).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateConnectionLogsTest() {
			ConnectionLogDataCollection connectionLogs = new ConnectionLogDataCollection();
			connectionLogs.Add( new ConnectionLogData( DateTime.Today , "localhost1" ) );
			connectionLogs.Add( new ConnectionLogData( DateTime.Today.AddMonths( 1 ) , "localhost2" ) );
			connectionLogs.Add( new ConnectionLogData( DateTime.Today.AddMonths( 2 ) , "localhost3" ) );
			_connectionLogBll.InsertConnectionLogData( connectionLogs );
			ConnectionLogDataCollection connectionLogsToUpdate = _connectionLogBll.GetConnectionLogData();
			ConnectionLogUnitTestHelper.UpdateConnectionLogs( connectionLogsToUpdate );
			_connectionLogBll.UpdateConnectionLogData( connectionLogsToUpdate );
			ConnectionLogDataCollection connectionLogsResult = _connectionLogBll.GetConnectionLogData();
			ConnectionLogUnitTestHelper.AreEqual( connectionLogsToUpdate , connectionLogsResult );
		}

		/// <summary>
		/// A test for RemoveConnectionLogs (remove a single connectionLog).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveConnectionLogTest() {
			ConnectionLogDataCollection connectionLogs =
				ConnectionLogDataCollection.FromSingleConnectionLog( new ConnectionLogData( DateTime.Now , "localhost" ) );
			_connectionLogBll.InsertConnectionLogData( connectionLogs );
			ConnectionLogDataCollection connectionLogsToRemove = _connectionLogBll.GetConnectionLogData();
			_connectionLogBll.RemoveConnectionLogData( connectionLogsToRemove );
			ConnectionLogDataCollection connectionLogsResult = _connectionLogBll.GetConnectionLogData();
			Assert.AreEqual( 0 , connectionLogsResult.Count , "The connectionLogs should be removed!" );
			ConnectionLogUnitTestHelper.AreInLogDeletes( connectionLogsToRemove );
		}

		/// <summary>
		/// A test for RemoveConnectionLogs (remove multiple connectionLogs).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveConnectionLogsTest() {
			ConnectionLogDataCollection connectionLogs = new ConnectionLogDataCollection();
			connectionLogs.Add( new ConnectionLogData( DateTime.Today , "localhost1" ) );
			connectionLogs.Add( new ConnectionLogData( DateTime.Today.AddMonths( 1 ) , "localhost2" ) );
			connectionLogs.Add( new ConnectionLogData( DateTime.Today.AddMonths( 2 ) , "localhost3" ) );
			_connectionLogBll.InsertConnectionLogData( connectionLogs );
			ConnectionLogDataCollection connectionLogsToRemove = _connectionLogBll.GetConnectionLogData();
			_connectionLogBll.RemoveConnectionLogData( connectionLogsToRemove );
			ConnectionLogDataCollection connectionLogsResult = _connectionLogBll.GetConnectionLogData();
			Assert.AreEqual( 0 , connectionLogsResult.Count , "The connectionLogs should be removed!" );
			ConnectionLogUnitTestHelper.AreInLogDeletes( connectionLogsToRemove );
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
