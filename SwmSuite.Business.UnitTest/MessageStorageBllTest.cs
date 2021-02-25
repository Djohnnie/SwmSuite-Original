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
	/// Unittestclass to test the MessageStorageBll methods.
	/// </summary>
	[TestClass()]
	public class MessageStorageBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private MessageStorageBll bll = new MessageStorageBll();

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
		/// A test for InsertMessageStorages (insert a single messagestorage).
		/// </summary>
		[TestMethod]
		public void Crud_InsertMessageStorageTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test messagefolder.
			MessageFolderData testMessageFolder = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Inbox );
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageStorageDataCollection messageStorages = new MessageStorageDataCollection();
			messageStorages.Add( new MessageStorageData( testMessage.SysId , testMessageFolder.SysId , false , false ) );
			bll.InsertMessageStorageData( messageStorages );
			MessageStorageDataCollection messageStoragesResult = bll.GetMessageStorageData();
			MessageStorageUnitTestHelper.AreEqual( messageStorages , messageStoragesResult );
		}

		/// <summary>
		/// A test for InsertMessageStorages (insert multiple messagestorages).
		/// </summary>
		[TestMethod]
		public void Crud_InsertMessageStoragesTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test messagefolder.
			MessageFolderData testMessageFolder1 = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Inbox );
			MessageFolderData testMessageFolder2 = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Outbox );
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageStorageDataCollection messageStorages = new MessageStorageDataCollection();
			messageStorages.Add( new MessageStorageData( testMessage.SysId , testMessageFolder1.SysId , false , false ) );
			messageStorages.Add( new MessageStorageData( testMessage.SysId , testMessageFolder2.SysId , false , false ) );
			bll.InsertMessageStorageData( messageStorages );
			MessageStorageDataCollection messageStoragesResult = bll.GetMessageStorageData();
			MessageStorageUnitTestHelper.AreEqual( messageStorages , messageStoragesResult );
		}

		/// <summary>
		/// A test for UpdateMessageStorages (update a single messagestorage).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateMessageStorageTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test messagefolder.
			MessageFolderData testMessageFolder1 = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Inbox );
			MessageFolderData testMessageFolder2 = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Archive );
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageStorageDataCollection messageStorages = new MessageStorageDataCollection();
			messageStorages.Add( new MessageStorageData( testMessage.SysId , testMessageFolder1.SysId , false , false ) );
			bll.InsertMessageStorageData( messageStorages );
			MessageStorageDataCollection messageStoragesToUpdate = bll.GetMessageStorageData();
			messageStoragesToUpdate[0].MessageFolderSysId = testMessageFolder2.SysId;
			bll.UpdateMessageStorageData( messageStoragesToUpdate );
			MessageStorageDataCollection messageStoragesResult = bll.GetMessageStorageData();
			MessageStorageUnitTestHelper.AreEqual( messageStoragesToUpdate , messageStoragesResult );
		}

		/// <summary>
		/// A test for UpdateMessageStorages (update multiple messagestorages).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateMessageStoragesTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test messagefolder.
			MessageFolderData testMessageFolder1 = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Inbox );
			MessageFolderData testMessageFolder2 = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Archive );
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageStorageDataCollection messageStorages = new MessageStorageDataCollection();
			messageStorages.Add( new MessageStorageData( testMessage.SysId , testMessageFolder1.SysId , false , false ) );
			messageStorages.Add( new MessageStorageData( testMessage.SysId , testMessageFolder2.SysId , false , false ) );
			bll.InsertMessageStorageData( messageStorages );
			MessageStorageDataCollection messageStoragesToUpdate = bll.GetMessageStorageData();
			messageStoragesToUpdate[0].MessageFolderSysId = testMessageFolder2.SysId;
			messageStoragesToUpdate[1].MessageFolderSysId = testMessageFolder1.SysId;
			bll.UpdateMessageStorageData( messageStoragesToUpdate );
			MessageStorageDataCollection messageStoragesResult = bll.GetMessageStorageData();
			MessageStorageUnitTestHelper.AreEqual( messageStoragesToUpdate , messageStoragesResult );
		}

		/// <summary>
		/// A test for RemoveMessageStorages (remove a single messagestorage).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveMessageStorageTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test messagefolder.
			MessageFolderData testMessageFolder = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Inbox );
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageStorageDataCollection messageStorages = new MessageStorageDataCollection();
			messageStorages.Add( new MessageStorageData( testMessage.SysId , testMessageFolder.SysId , false , false ) );
			bll.InsertMessageStorageData( messageStorages );
			MessageStorageDataCollection messageStoragesToRemove = bll.GetMessageStorageData();
			bll.RemoveMessageStorageData( messageStoragesToRemove );
			MessageStorageUnitTestHelper.AreInLogDeletes( messageStoragesToRemove );
		}

		/// <summary>
		/// A test for RemoveMessageStorages (remove multiple messagestorages).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveMessageStoragesTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test messagefolder.
			MessageFolderData testMessageFolder1 = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Inbox );
			MessageFolderData testMessageFolder2 = MessageFolderUnitTestHelper.GetRootMessageFolderTestData( MessageSpecialFolder.Outbox );
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageStorageDataCollection messageStorages = new MessageStorageDataCollection();
			messageStorages.Add( new MessageStorageData( testMessage.SysId , testMessageFolder1.SysId , false , false ) );
			messageStorages.Add( new MessageStorageData( testMessage.SysId , testMessageFolder2.SysId , false , false ) );
			bll.InsertMessageStorageData( messageStorages );
			MessageStorageDataCollection messageStoragesToRemove = bll.GetMessageStorageData();
			bll.RemoveMessageStorageData( messageStoragesToRemove );
			MessageStorageUnitTestHelper.AreInLogDeletes( messageStoragesToRemove );
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
