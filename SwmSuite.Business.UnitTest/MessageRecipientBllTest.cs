using SwmSuite.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using System.Transactions;
using System;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Business.UnitTest.UnitTestHelper;

namespace SwmSuite.Business.UnitTest {
	
	/// <summary>
	/// Unittestclass to test the MessageBll methods.
	/// </summary>
	[TestClass()]
	public class MessageRecipientBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private MessageRecipientBll bll = new MessageRecipientBll();

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
		/// A test for InsertMessageRecipients (insert a single messagerecipient).
		/// </summary>
		[TestMethod]
		public void Crud_InsertMessageRecipientTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test recipient employee.
			EmployeeData testRecipientEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageRecipientDataCollection messageRecipients = new MessageRecipientDataCollection();
			messageRecipients.Add( new MessageRecipientData( testMessage.SysId , testRecipientEmployee.SysId ) );
			bll.InsertMessageRecipientData( messageRecipients );
			MessageRecipientDataCollection messageRecipientsResult = bll.GetMessageRecipientData();
			MessageRecipientUnitTestHelper.AreEqual( messageRecipients , messageRecipientsResult );
		}

		/// <summary>
		/// A test for InsertMessageRecipients (insert multiple messagerecipients).
		/// </summary>
		[TestMethod]
		public void Crud_InsertMessageRecipientsTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test recipient employee.
			EmployeeData testRecipientEmployee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testRecipientEmployee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageRecipientDataCollection messageRecipients = new MessageRecipientDataCollection();
			messageRecipients.Add( new MessageRecipientData( testMessage.SysId , testRecipientEmployee1.SysId ) );
			messageRecipients.Add( new MessageRecipientData( testMessage.SysId , testRecipientEmployee2.SysId ) );
			bll.InsertMessageRecipientData( messageRecipients );
			MessageRecipientDataCollection messageRecipientsResult = bll.GetMessageRecipientData();
			MessageRecipientUnitTestHelper.AreEqual( messageRecipients , messageRecipientsResult );
		}

		/// <summary>
		/// A test for UpdateMessageRecipients (update a single messagerecipient).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateMessageRecipientTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test recipient employee.
			EmployeeData testRecipientEmployee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testRecipientEmployee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageRecipientDataCollection messageRecipients = new MessageRecipientDataCollection();
			messageRecipients.Add( new MessageRecipientData( testMessage.SysId , testRecipientEmployee1.SysId ) );
			bll.InsertMessageRecipientData( messageRecipients );
			MessageRecipientDataCollection messageRecipientsToUpdate = bll.GetMessageRecipientData();
			messageRecipientsToUpdate[0].EmployeeSysId = testRecipientEmployee2.SysId;
			bll.UpdateMessageRecipientData( messageRecipientsToUpdate );
			MessageRecipientDataCollection messageRecipientsResult = bll.GetMessageRecipientData();
			MessageRecipientUnitTestHelper.AreEqual( messageRecipientsToUpdate , messageRecipientsResult );
		}

		/// <summary>
		/// A test for UpdateMessageRecipients (update multiple messagerecipients).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateMessageRecipientsTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test recipient employee.
			EmployeeData testRecipientEmployee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testRecipientEmployee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageRecipientDataCollection messageRecipients = new MessageRecipientDataCollection();
			messageRecipients.Add( new MessageRecipientData( testMessage.SysId , testRecipientEmployee1.SysId ) );
			messageRecipients.Add( new MessageRecipientData( testMessage.SysId , testRecipientEmployee2.SysId ) );
			bll.InsertMessageRecipientData( messageRecipients );
			MessageRecipientDataCollection messageRecipientsToUpdate = bll.GetMessageRecipientData();
			messageRecipientsToUpdate[0].EmployeeSysId = testRecipientEmployee2.SysId;
			messageRecipientsToUpdate[1].EmployeeSysId = testRecipientEmployee1.SysId;
			bll.UpdateMessageRecipientData( messageRecipientsToUpdate );
			MessageRecipientDataCollection messageRecipientsResult = bll.GetMessageRecipientData();
			MessageRecipientUnitTestHelper.AreEqual( messageRecipientsToUpdate , messageRecipientsResult );
		}

		/// <summary>
		/// A test for RemoveMessageRecipients (remove a single messagerecipient).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveMessageRecipientTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test recipient employee.
			EmployeeData testRecipientEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageRecipientDataCollection messageRecipients = new MessageRecipientDataCollection();
			messageRecipients.Add( new MessageRecipientData( testMessage.SysId , testRecipientEmployee.SysId ) );
			bll.InsertMessageRecipientData( messageRecipients );
			MessageRecipientDataCollection messageRecipientsToRemove = bll.GetMessageRecipientData();
			bll.RemoveMessageRecipientData( messageRecipientsToRemove );
			MessageRecipientUnitTestHelper.AreInLogDeletes( messageRecipientsToRemove );
		}

		/// <summary>
		/// A test for RemoveMessageRecipients (remove multiple messagerecipients).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveMessageRecipientsTest() {
			// Create a test message.
			MessageData testMessage = MessageUnitTestHelper.GetMessageTestData();
			// Create a test recipient employee.
			EmployeeData testRecipientEmployee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testRecipientEmployee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			// Create a messagestorage storing the test message in the test messagefolder.
			MessageRecipientDataCollection messageRecipients = new MessageRecipientDataCollection();
			messageRecipients.Add( new MessageRecipientData( testMessage.SysId , testRecipientEmployee1.SysId ) );
			messageRecipients.Add( new MessageRecipientData( testMessage.SysId , testRecipientEmployee2.SysId ) );
			bll.InsertMessageRecipientData( messageRecipients );
			MessageRecipientDataCollection messageRecipientsToRemove = bll.GetMessageRecipientData();
			bll.RemoveMessageRecipientData( messageRecipientsToRemove );
			MessageRecipientUnitTestHelper.AreInLogDeletes( messageRecipientsToRemove );
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
