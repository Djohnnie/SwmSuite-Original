using SwmSuite.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using System;
using System.Transactions;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	///This is a test class for LogDeleteBllTest and is intended
	///to contain all LogDeleteBllTest Unit Tests
	///</summary>
	[TestClass()]
	public class LogDeleteBllTest : IDisposable {


		private TestContext testContextInstance;

		private TransactionScope mainScope;

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

		#region Additional test attributes

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
		///A test for InsertLogDeletes (insert a single logdelete).
		///</summary>
		[TestMethod]
		public void Crud_InsertLogDeleteTest() {
			LogDeleteBll bll = new LogDeleteBll();
			LogDeleteData logDelete = new LogDeleteData( "tbl_Test" , "INFO" , Guid.Empty , DateTime.Today );
			LogDeleteDataCollection logDeletes = new LogDeleteDataCollection();
			logDeletes.Add( logDelete );
			bll.InsertLogDeleteData( logDeletes );
			LogDeleteDataCollection logDeletesResult = bll.GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , logDeletesResult.Count );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( ld.TableName , logDeletesResult[logDeletes.IndexOf( ld )].TableName );
				Assert.AreEqual( ld.Info , logDeletesResult[logDeletes.IndexOf( ld )].Info );
				Assert.AreEqual( ld.DeletedBy , logDeletesResult[logDeletes.IndexOf( ld )].DeletedBy );
				Assert.AreEqual( ld.DeletedOn , logDeletesResult[logDeletes.IndexOf( ld )].DeletedOn );
			}
		}

		/// <summary>
		///A test for InsertLogDeletes (insert multiple logdeletes).
		///</summary>
		[TestMethod]
		public void Crud_InsertLogDeletesTest() {
			LogDeleteBll bll = new LogDeleteBll();
			LogDeleteData logDelete1 = new LogDeleteData( "tbl_Test1" , "INFO - 1" , Guid.Empty , DateTime.Today );
			LogDeleteData logDelete2 = new LogDeleteData( "tbl_Test2" , "INFO - 2" , Guid.Empty , DateTime.Today.AddDays( 1 ) );
			LogDeleteDataCollection logDeletes = new LogDeleteDataCollection();
			logDeletes.Add( logDelete1 );
			logDeletes.Add( logDelete2 );
			bll.InsertLogDeleteData( logDeletes );
			LogDeleteDataCollection logDeletesResult = bll.GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , logDeletesResult.Count );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( ld.TableName , logDeletesResult[logDeletes.IndexOf( ld )].TableName );
				Assert.AreEqual( ld.Info , logDeletesResult[logDeletes.IndexOf( ld )].Info );
				Assert.AreEqual( ld.DeletedBy , logDeletesResult[logDeletes.IndexOf( ld )].DeletedBy );
				Assert.AreEqual( ld.DeletedOn , logDeletesResult[logDeletes.IndexOf( ld )].DeletedOn );
			}
		}

		/// <summary>
		///A test for UpdateLogDeletes (update a single logDelete).
		///</summary>
		[TestMethod]
		public void Crud_UpdateLogDeleteTest() {
			LogDeleteBll bll = new LogDeleteBll();
			LogDeleteData logDelete = new LogDeleteData( "tbl_Test1" , "INFO - 1" , Guid.Empty , DateTime.Today );
			LogDeleteDataCollection logDeletes = new LogDeleteDataCollection();
			logDeletes.Add( logDelete );
			bll.InsertLogDeleteData( logDeletes );
			LogDeleteDataCollection logDeletesToUpdate = bll.GetLogDeleteData();
			foreach( LogDeleteData ld in logDeletesToUpdate ) {
				ld.TableName += "-EDITED";
				ld.Info += "-EDITED";
				ld.DeletedOn = DateTime.Today.AddMonths( 1 );
			}
			bll.UpdateLogDeleteData( logDeletesToUpdate );
			LogDeleteDataCollection logDeletesResult = bll.GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , logDeletesResult.Count );
			foreach( LogDeleteData ld in logDeletesToUpdate ) {
				Assert.AreEqual( ld.TableName , logDeletesResult[logDeletesToUpdate.IndexOf( ld )].TableName );
				Assert.AreEqual( ld.Info , logDeletesResult[logDeletesToUpdate.IndexOf( ld )].Info );
				Assert.AreEqual( ld.DeletedBy , logDeletesResult[logDeletesToUpdate.IndexOf( ld )].DeletedBy );
				Assert.AreEqual( ld.DeletedOn , logDeletesResult[logDeletesToUpdate.IndexOf( ld )].DeletedOn );
			}
		}

		/// <summary>
		///A test for UpdateLogDeletes (update multiple logDeletes).
		///</summary>
		[TestMethod]
		public void Crud_UpdateLogDeletesTest() {
			LogDeleteBll bll = new LogDeleteBll();
			LogDeleteData logDelete1 = new LogDeleteData( "tbl_Test1" , "INFO - 1" , Guid.Empty , DateTime.Today );
			LogDeleteData logDelete2 = new LogDeleteData( "tbl_Test2" , "INFO - 2" , Guid.Empty , DateTime.Today.AddDays( 1 ) );
			LogDeleteDataCollection logDeletes = new LogDeleteDataCollection();
			logDeletes.Add( logDelete1 );
			logDeletes.Add( logDelete2 );
			bll.InsertLogDeleteData( logDeletes );
			LogDeleteDataCollection logDeletesToUpdate = bll.GetLogDeleteData();
			foreach( LogDeleteData ld in logDeletesToUpdate ) {
				ld.TableName += "-EDITED";
				ld.Info += "-EDITED";
				ld.DeletedOn = DateTime.Today.AddMonths( 1 );
			}
			bll.UpdateLogDeleteData( logDeletesToUpdate );
			LogDeleteDataCollection logDeletesResult = bll.GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , logDeletesResult.Count );
			foreach( LogDeleteData ld in logDeletesToUpdate ) {
				Assert.AreEqual( ld.TableName , logDeletesResult[logDeletesToUpdate.IndexOf( ld )].TableName );
				Assert.AreEqual( ld.Info , logDeletesResult[logDeletesToUpdate.IndexOf( ld )].Info );
				Assert.AreEqual( ld.DeletedBy , logDeletesResult[logDeletesToUpdate.IndexOf( ld )].DeletedBy );
				Assert.AreEqual( ld.DeletedOn , logDeletesResult[logDeletesToUpdate.IndexOf( ld )].DeletedOn );
			}
		}

		/// <summary>
		///A test for RemoveLogDeletes (remove a single logDelete).
		///</summary>
		[TestMethod]
		public void Crud_RemoveLogDeleteTest() {
			LogDeleteBll bll = new LogDeleteBll();
			LogDeleteData logDelete = new LogDeleteData( "tbl_Test" , "INFO" , Guid.Empty , DateTime.Today );
			LogDeleteDataCollection logDeletes = new LogDeleteDataCollection();
			logDeletes.Add( logDelete );
			bll.InsertLogDeleteData( logDeletes );
			LogDeleteDataCollection logDeletesToRemove = bll.GetLogDeleteData();
			bll.RemoveLogDeleteData( logDeletesToRemove );
			LogDeleteDataCollection logDeletesResult = bll.GetLogDeleteData();
			Assert.AreEqual( 0 , logDeletesResult.Count );
		}

		/// <summary>
		///A test for RemoveLogDeletes (remove multiple logDeletes).
		///</summary>
		[TestMethod]
		public void Crud_RemoveLogDeletesTest() {
			LogDeleteBll bll = new LogDeleteBll();
			LogDeleteData logDelete1 = new LogDeleteData( "tbl_Test1" , "INFO - 1" , Guid.Empty , DateTime.Today );
			LogDeleteData logDelete2 = new LogDeleteData( "tbl_Test2" , "INFO - 2" , Guid.Empty , DateTime.Today.AddDays( 1 ) );
			LogDeleteDataCollection logDeletes = new LogDeleteDataCollection();
			logDeletes.Add( logDelete1 );
			logDeletes.Add( logDelete2 );
			bll.InsertLogDeleteData( logDeletes );
			LogDeleteDataCollection logDeletesToRemove = bll.GetLogDeleteData();
			bll.RemoveLogDeleteData( logDeletesToRemove );
			LogDeleteDataCollection logDeletesResult = bll.GetLogDeleteData();
			Assert.AreEqual( 0 , logDeletesResult.Count );
		}

		#endregion

		#region IDisposable Members

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
