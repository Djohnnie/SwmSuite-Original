using SwmSuite.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using System.Transactions;
using System;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the MessageFolderBll methods.
	/// </summary>
	[TestClass()]
	public class MessageFolderBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private MessageFolderBll bll = new MessageFolderBll();

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
			mainScope.Dispose();
		}

		#endregion

		#region -_ Test Methods _-

		/// <summary>
		/// A test for InsertMessageFolders (insert a single root messageFolder).
		/// </summary>
		[TestMethod]
		public void Crud_InsertRootMessageFolderTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			MessageFolderData messageFolder = new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Inbox , "Inbox" , true );
			MessageFolderDataCollection messageFolders = MessageFolderDataCollection.FromSingleMessageFolder( messageFolder );
			bll.InsertMessageFolderData( messageFolders );
			MessageFolderDataCollection messageFoldersResult = bll.GetMessageFolderData();
			MessageFolderUnitTestHelper.AreEqual( messageFolders , messageFoldersResult );
		}

		/// <summary>
		/// A test for InsertMessageFolders (insert multiple root messageFolders).
		/// </summary>
		[TestMethod]
		public void Crud_InsertRootMessageFoldersTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			MessageFolderDataCollection messageFolders = new MessageFolderDataCollection();
			messageFolders.Add( new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Inbox , "Inbox" , true ) );
			messageFolders.Add( new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Outbox , "Outbox" , true ) );
			messageFolders.Add( new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Archive , "Archive" , true ) );
			bll.InsertMessageFolderData( messageFolders );
			MessageFolderDataCollection messageFoldersResult = bll.GetMessageFolderData();
			MessageFolderUnitTestHelper.AreEqual( messageFolders , messageFoldersResult );
		}

		/// <summary>
		/// A test for InsertMessageFolders (insert a single messageFolder).
		/// </summary>
		[TestMethod]
		public void Crud_InsertMessageFolderTest() {
			MessageFolderData rootMessageFolder = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Inbox );
			MessageFolderDataCollection messageFolders = new MessageFolderDataCollection();
			messageFolders.Add( new MessageFolderData( rootMessageFolder.OwnerEmployeeSysId , rootMessageFolder.SysId , MessageSpecialFolder.None , "Folder" , true ) );
			bll.InsertMessageFolderData( messageFolders );
			MessageFolderDataCollection messageFoldersResult = bll.GetMessageFolderDataForFolder( rootMessageFolder.SysId);
			MessageFolderUnitTestHelper.AreEqual( messageFolders , messageFoldersResult );
		}

		/// <summary>
		/// A test for InsertMessageFolders (insert multiple messageFolders).
		/// </summary>
		[TestMethod]
		public void Crud_InsertMessageFoldersTest() {
			MessageFolderData rootMessageFolder = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Inbox );
			MessageFolderDataCollection messageFolders = new MessageFolderDataCollection();
			messageFolders.Add( new MessageFolderData( rootMessageFolder.OwnerEmployeeSysId , rootMessageFolder.SysId , MessageSpecialFolder.None , "Folder 1" , true ) );
			messageFolders.Add( new MessageFolderData( rootMessageFolder.OwnerEmployeeSysId , rootMessageFolder.SysId , MessageSpecialFolder.None , "Folder 2" , true ) );
			messageFolders.Add( new MessageFolderData( rootMessageFolder.OwnerEmployeeSysId , rootMessageFolder.SysId , MessageSpecialFolder.None , "Folder 3" , true ) );
			bll.InsertMessageFolderData( messageFolders );
			MessageFolderDataCollection messageFoldersResult = bll.GetMessageFolderDataForFolder( rootMessageFolder.SysId );
			MessageFolderUnitTestHelper.AreEqual( messageFolders , messageFoldersResult );
		}

		/// <summary>
		/// A test for UpdateMessageFolders (update a single root messageFolder).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateRootMessageFolderTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			MessageFolderData messageFolder = new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Inbox , "Inbox" , true );
			MessageFolderDataCollection messageFolders = MessageFolderDataCollection.FromSingleMessageFolder( messageFolder );
			bll.InsertMessageFolderData( messageFolders );
			MessageFolderDataCollection messageFoldersToUpdate = bll.GetMessageFolderData();
			MessageFolderUnitTestHelper.UpdateMessageFolders( messageFoldersToUpdate );
			bll.UpdateMessageFolderData( messageFoldersToUpdate );
			MessageFolderDataCollection messageFoldersResult = bll.GetMessageFolderData();
			MessageFolderUnitTestHelper.AreEqual( messageFoldersToUpdate , messageFoldersResult );
		}

		/// <summary>
		/// A test for UpdateMessageFolders (update multiple root messageFolders).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateRootMessageFoldersTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			MessageFolderDataCollection messageFolders = new MessageFolderDataCollection();
			messageFolders.Add( new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Inbox , "Inbox" , true ) );
			messageFolders.Add( new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Outbox , "Outbox" , true ) );
			messageFolders.Add( new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Archive , "Archive" , true ) );
			bll.InsertMessageFolderData( messageFolders );
			MessageFolderDataCollection messageFoldersToUpdate = bll.GetMessageFolderData();
			MessageFolderUnitTestHelper.UpdateMessageFolders( messageFoldersToUpdate );
			bll.UpdateMessageFolderData( messageFoldersToUpdate );
			MessageFolderDataCollection messageFoldersResult = bll.GetMessageFolderData();
			MessageFolderUnitTestHelper.AreEqual( messageFoldersToUpdate , messageFoldersResult );
		}

		/// <summary>
		/// A test for RemoveMessageFolders (remove a single root messageFolder).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveRootMessageFolderTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			MessageFolderData messageFolder = new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Inbox , "Inbox" , true );
			MessageFolderDataCollection messageFolders = MessageFolderDataCollection.FromSingleMessageFolder( messageFolder );
			bll.InsertMessageFolderData( messageFolders );
			MessageFolderDataCollection messageFoldersToRemove = bll.GetMessageFolderData();
			bll.RemoveMessageFolderData( messageFoldersToRemove );
			MessageFolderUnitTestHelper.AreInLogDeletes( messageFoldersToRemove );
		}

		/// <summary>
		/// A test for RemoveMessageFolders (remove multiple root messageFolders).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveRootMessageFoldersTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			MessageFolderDataCollection messageFolders = new MessageFolderDataCollection();
			messageFolders.Add( new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Inbox , "Inbox" , true ) );
			messageFolders.Add( new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Outbox , "Outbox" , true ) );
			messageFolders.Add( new MessageFolderData( testEmployee.SysId , null , MessageSpecialFolder.Archive , "Archive" , true ) );
			bll.InsertMessageFolderData( messageFolders );
			MessageFolderDataCollection messageFoldersToRemove = bll.GetMessageFolderData();
			bll.RemoveMessageFolderData( messageFoldersToRemove );
			MessageFolderUnitTestHelper.AreInLogDeletes( messageFoldersToRemove );
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
