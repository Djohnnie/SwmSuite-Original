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
	/// Unittestclass to test the MessageBll methods.
	/// </summary>
	[TestClass()]
	public class MessageBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private EmployeeGroupBll employeeGroupBll = new EmployeeGroupBll();
		private EmployeeBll employeeBll = new EmployeeBll();
		private MessageBll messageBll = new MessageBll();
		private MessageFolderBll messageFolderBll = new MessageFolderBll();

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

		/// <summary>
		/// A test for SendMessage (send a message).
		/// </summary>
		[TestMethod]
		public void Business_SendMessageTest() {
			//// Send a message from one employee to 3 other employees.
			//// From JEF to JOS, JOHNNY and JOSEPH.

			////
			//// Create the employee group.
			////
			//EmployeeGroupData staff = new EmployeeGroupData( "Staff" , "Staff Description" , true );
			//EmployeeGroupDataCollection employeeGroups =
			//    employeeGroupBll.InsertEmployeeGroups( EmployeeGroupDataCollection.FromSingleEmployeeGroup( staff ) );
			//staff = employeeGroups[0];

			////
			//// Create the employees.
			////
			//EmployeeData jef = new EmployeeData( Guid.Empty , "JEF" , "Jef" , staff.SysId );
			//EmployeeData jos = new EmployeeData( Guid.Empty , "JOS" , "Jos" , staff.SysId );
			//EmployeeData johnny = new EmployeeData( Guid.Empty , "JOHNNY" , "Johnny" , staff.SysId );
			//EmployeeData joseph = new EmployeeData( Guid.Empty , "JOSEPH" , "Joseph" , staff.SysId );
			//EmployeeDataCollection employees = new EmployeeDataCollection();
			//employees.Add( jef );
			//employees.Add( jos );
			//employees.Add( johnny );
			//employees.Add( joseph );
			//employees = employeeBll.CreateEmployees( employees );
			//jef = employees[0];
			//jos = employees[1];
			//johnny = employees[2];
			//joseph = employees[3];

			////
			//// Create the message.
			////
			//MessageData message = new MessageData( jef.SysId , DateTime.Now , "Test from " + jef.FirstName + "." , jef.ToString( ) + " says hello!" , MessagePriority.Normal , false );

			////
			//// Create the recipients.
			////
			//EmployeeDataCollection recipients = new EmployeeDataCollection();
			//recipients.Add( jos );
			//recipients.Add( johnny );
			//recipients.Add( joseph );

			////
			//// Send the message.
			////
			//messageBll.SendMessage( message , recipients );

			////
			//// Check if all data is correct.
			////
			//MessageFolderDataCollection jefFolders = messageFolderBll.GetSpecialMessageFoldersForEmployee( jef.SysId , MessageSpecialFolder.Outbox );
			//MessageFolderDataCollection josFolders = messageFolderBll.GetSpecialMessageFoldersForEmployee( jos.SysId , MessageSpecialFolder.Inbox );
			//MessageFolderDataCollection johnnyFolders = messageFolderBll.GetSpecialMessageFoldersForEmployee( johnny.SysId , MessageSpecialFolder.Inbox );
			//MessageFolderDataCollection josephFolders = messageFolderBll.GetSpecialMessageFoldersForEmployee( joseph.SysId , MessageSpecialFolder.Inbox );

			//MessageDataCollection jefMessages = messageBll.GetMessagesInMessageFolder( jefFolders[0].SysId );
			//MessageDataCollection josMessages = messageBll.GetMessagesInMessageFolder( josFolders[0].SysId );
			//MessageDataCollection johnnyMessages = messageBll.GetMessagesInMessageFolder( johnnyFolders[0].SysId );
			//MessageDataCollection josephMessages = messageBll.GetMessagesInMessageFolder( josephFolders[0].SysId );

			//Assert.AreEqual( 1 , jefMessages.Count , "Jef should have one message in his Outbox!" );
			//Assert.AreEqual( 1 , josMessages.Count , "Jos should have one message in his Inbox!" );
			//Assert.AreEqual( 1 , johnnyMessages.Count , "Johnny should have one message in his Inbox!" );
			//Assert.AreEqual( 1 , josephMessages.Count , "Joseph should have one message in his Inbox!" );
		}

		/// <summary>
		/// A test for MoveMessage (move a message from one folder to another).
		/// </summary>
		[TestMethod]
		public void Business_MoveMessageTest() {

		}

		#endregion

		#region -_ Crud Test Methods _-

		/// <summary>
		/// A test for InsertMessages (insert a single message).
		/// </summary>
		[TestMethod]
		public void Crud_InsertMessageTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			MessageBll bll = new MessageBll();
			MessageData message = new MessageData( testEmployee.SysId , DateTime.Today , "Subject" , "Content" , MessagePriority.Normal , true );
			MessageDataCollection messages = MessageDataCollection.FromSingleMessage( message );
			bll.InsertMessageData( messages );
			MessageDataCollection messagesResult = bll.GetMessageData();
			MessageUnitTestHelper.AreEqual( messages , messagesResult );
		}

		/// <summary>
		/// A test for InsertMessages (insert multiple messages).
		/// </summary>
		[TestMethod]
		public void Crud_InsertMessagesTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			MessageBll bll = new MessageBll();
			MessageDataCollection messages = new MessageDataCollection();
			messages.Add( new MessageData( testEmployee.SysId , DateTime.Today.AddDays( 2.0f ) , "Subject 3" , "Content 3" , MessagePriority.High , true ) );
			messages.Add( new MessageData( testEmployee.SysId , DateTime.Today.AddDays( 1.0f ) , "Subject 2" , "Content 2" , MessagePriority.Normal , true ) );
			messages.Add( new MessageData( testEmployee.SysId , DateTime.Today , "Subject 1" , "Content 1" , MessagePriority.Low , true ) );
			bll.InsertMessageData( messages );
			MessageDataCollection messagesResult = bll.GetMessageData();
			MessageUnitTestHelper.AreEqual( messages , messagesResult );
		}

		/// <summary>
		/// A test for InsertMessages (insert multiple messages for multiple employees ).
		/// </summary>
		[TestMethod]
		public void Crud_InsertMessagesForEmployeeTest() {
			EmployeeDataCollection testEmployees = EmployeeUnitTestHelper.GetEmployeesTestData();

			MessageBll bll = new MessageBll();
			MessageDataCollection messages = new MessageDataCollection();
			messages.Add( new MessageData( testEmployees[0].SysId , DateTime.Today.AddDays( 2.0f ) , "Subject 3" , "Content 3" , MessagePriority.High , true ) );
			messages.Add( new MessageData( testEmployees[0].SysId , DateTime.Today.AddDays( 1.0f ) , "Subject 2" , "Content 2" , MessagePriority.Normal , true ) );
			messages.Add( new MessageData( testEmployees[0].SysId , DateTime.Today , "Subject 1" , "Content 1" , MessagePriority.Low , true ) );
			MessageDataCollection dummyMessages = MessageDataCollection.FromSingleMessage(
				new MessageData( testEmployees[1].SysId , DateTime.Today.AddDays( 3.0f ) , "Subject 4" , "Content 4" , MessagePriority.Low , true ) );
			bll.InsertMessageData( messages );
			bll.InsertMessageData( dummyMessages );
			MessageDataCollection messagesResult = bll.GetMessageDataForEmployee( testEmployees[0].SysId );
			MessageUnitTestHelper.AreEqual( messages , messagesResult );
		}

		/// <summary>
		/// A test for UpdateMessages (update a single message).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateMessageTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			MessageBll bll = new MessageBll();
			MessageData message = new MessageData( testEmployee.SysId , DateTime.Today , "Subject" , "Content" , MessagePriority.Normal , true );
			MessageDataCollection messages = MessageDataCollection.FromSingleMessage( message );
			bll.InsertMessageData( messages );
			MessageDataCollection messagesToUpdate = bll.GetMessageData();
			MessageUnitTestHelper.AreEqual( messages , messagesToUpdate );
			MessageUnitTestHelper.UpdateMessages( messagesToUpdate );
			bll.UpdateMessageData( messagesToUpdate );
			MessageDataCollection messagesResult = bll.GetMessageData();
			MessageUnitTestHelper.AreEqual( messagesResult , messagesToUpdate );
		}

		/// <summary>
		/// A test for UpdateMessages (update multiple messages).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateMessagesTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			MessageBll bll = new MessageBll();
			MessageDataCollection messages = new MessageDataCollection();
			messages.Add( new MessageData( testEmployee.SysId , DateTime.Today.AddDays( 2.0f ) , "Subject 3" , "Content 3" , MessagePriority.High , true ) );
			messages.Add( new MessageData( testEmployee.SysId , DateTime.Today.AddDays( 1.0f ) , "Subject 2" , "Content 2" , MessagePriority.Normal , true ) );
			messages.Add( new MessageData( testEmployee.SysId , DateTime.Today , "Subject 1" , "Content 1" , MessagePriority.Low , true ) );
			bll.InsertMessageData( messages );
			MessageDataCollection messagesToUpdate = bll.GetMessageData();
			MessageUnitTestHelper.AreEqual( messages , messagesToUpdate );
			MessageUnitTestHelper.UpdateMessages( messagesToUpdate );
			bll.UpdateMessageData( messagesToUpdate );
			MessageDataCollection messagesResult = bll.GetMessageData();
			MessageUnitTestHelper.AreEqual( messagesResult , messagesToUpdate );
		}

		/// <summary>
		/// A test for RemoveMessages (remove a single message).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveMessageTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			MessageBll bll = new MessageBll();
			MessageData message = new MessageData( testEmployee.SysId , DateTime.Today , "Subject" , "Content" , MessagePriority.Normal , true );
			MessageDataCollection messages = MessageDataCollection.FromSingleMessage( message );
			bll.InsertMessageData( messages );
			MessageDataCollection messagesToRemove = bll.GetMessageData();
			bll.RemoveMessageData( messagesToRemove );
			MessageUnitTestHelper.AreInLogDeletes( messagesToRemove );
		}

		/// <summary>
		/// A test for RemoveMessages (remove multiple messages).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveMessagesTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();

			MessageBll bll = new MessageBll();
			MessageDataCollection messages = new MessageDataCollection();
			messages.Add( new MessageData( testEmployee.SysId , DateTime.Today , "Subject 1" , "Content 1" , MessagePriority.Low , true ) );
			messages.Add( new MessageData( testEmployee.SysId , DateTime.Today.AddDays( 1.0f ) , "Subject 2" , "Content 2" , MessagePriority.Normal , true ) );
			messages.Add( new MessageData( testEmployee.SysId , DateTime.Today.AddDays( 2.0f ) , "Subject 3" , "Content 3" , MessagePriority.High , true ) );
			bll.InsertMessageData( messages );
			MessageDataCollection messagesToRemove = bll.GetMessageData();
			bll.RemoveMessageData( messagesToRemove );
			MessageUnitTestHelper.AreInLogDeletes( messagesToRemove );
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
