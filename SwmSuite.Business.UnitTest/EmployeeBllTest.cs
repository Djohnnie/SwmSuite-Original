using SwmSuite.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using System.Transactions;
using System;
using SwmSuite.Business;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using System.Security;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest {
	
	/// <summary>
	/// Unittestclass to test the EmployeeBll methods.
	/// </summary>
	[TestClass()]
	public class EmployeeBllTest : IDisposable {

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

		/// <summary>
		/// A test for CreateEmployee (create a new user).
		/// </summary>
		[TestMethod]
		public void Business_CreateEmployeeTest() {
			//
			// Create the employee group.
			//
			EmployeeGroupData staff = new EmployeeGroupData( "Staff" , "Staff Description" , true );
			EmployeeGroupDataCollection employeeGroups =
				employeeGroupBll.InsertEmployeeGroupData( EmployeeGroupDataCollection.FromSingleEmployeeGroup( staff ) );
			staff = employeeGroups[0];

			//
			// Create new employee named Jan Janssens.
			//
			Employee jan = new Employee() {
				Name = "Janssens",
				FirstName = "Jan",
				Password = "0",
				UserName = "test"
			};

			EmployeeGroup employeeGroup = new EmployeeGroup() {
				SysId = staff.SysId
			};

			employeeBll.CreateEmployee( jan , employeeGroup);

			//
			// Check if all necessary data has been created.
			//
			EmployeeDataCollection employees = employeeBll.GetEmployeeData();
			Assert.AreEqual( 1 , employees.Count , "There should be one employee in the database!" );

			MessageFolderDataCollection messageFolders = messageFolderBll.GetMessageFolderDataForEmployee( employees[0].SysId );
			Assert.AreEqual( 3 , messageFolders.Count , "There should be 3 messagefolders in the database!" );
			bool inboxFound = false;
			bool outboxFound = false;
			bool archiveFound = false;
			foreach( MessageFolderData messageFolder in messageFolders ) {
				switch( messageFolder.SpecialFolder ){
					case MessageSpecialFolder.Inbox: {
						inboxFound = true;
						break;
					}
					case MessageSpecialFolder.Outbox: {
						outboxFound = true;
						break;
					}
					case MessageSpecialFolder.Archive: {
						archiveFound = true;
						break;
					}
				}
			}
			Assert.IsTrue( inboxFound , "No INBOX folder has been found!" );
			Assert.IsTrue( outboxFound , "No OUTBOX folder has been found!" );
			Assert.IsTrue( archiveFound , "No ARCHIVE folder has been found!" );
		}

		#endregion

		#region -_ Crud Test Methods _-

		/// <summary>
		///A test for InsertEmployees (insert a single employee).
		///</summary>
		[TestMethod]
		public void Crud_InsertEmployeeTest() {
			EmployeeGroupDataCollection employeeGroups = EmployeeGroupBllTest.GetEmployeeGroupTestData();
			int employeeGroupSysId = employeeGroups[0].SysId;

			EmployeeBll bll = new EmployeeBll();
			EmployeeData employee = new EmployeeData( Guid.Empty , "Hooyberghs" , "Johnny" , employeeGroupSysId );
			EmployeeDataCollection employees = new EmployeeDataCollection();
			employees.Add( employee );
			bll.InsertEmployeeData( employees );
			EmployeeDataCollection employeesResult = bll.GetEmployeeData();
			Assert.AreEqual( employees.Count , employeesResult.Count );
			foreach( EmployeeData e in employees ) {
				Assert.AreEqual( e.FirstName , employeesResult[employees.IndexOf(e)].FirstName );
				Assert.AreEqual( e.Name , employeesResult[employees.IndexOf( e )].Name );
			}
		}

		/// <summary>
		///A test for InsertEmployees (insert multiple employees).
		///</summary>
		[TestMethod]
		public void Crud_InsertEmployeesTest() {
			EmployeeGroupDataCollection employeeGroups = EmployeeGroupBllTest.GetEmployeeGroupTestData();
			int employeeGroupSysId = employeeGroups[0].SysId;
			
			EmployeeBll bll = new EmployeeBll();
			EmployeeData employee1 = new EmployeeData( Guid.Empty , "Hooyberghs" , "Johnny" , employeeGroupSysId );
			EmployeeData employee2 = new EmployeeData( Guid.Empty , "Van Bogaert" , "Jelle" , employeeGroupSysId );
			EmployeeDataCollection employees = new EmployeeDataCollection();
			employees.Add( employee1 );
			employees.Add( employee2 );
			bll.InsertEmployeeData( employees );
			EmployeeDataCollection employeesResult = bll.GetEmployeeData();
			Assert.AreEqual( employees.Count , employeesResult.Count );
			foreach( EmployeeData e in employees ) {
				Assert.AreEqual( e.FirstName , employeesResult[employees.IndexOf( e )].FirstName );
				Assert.AreEqual( e.Name , employeesResult[employees.IndexOf( e )].Name );
			}
		}

		/// <summary>
		///A test for UpdateEmployees (update a single employee).
		///</summary>
		[TestMethod]
		public void Crud_UpdateEmployeeTest() {
			EmployeeGroupDataCollection employeeGroups = EmployeeGroupBllTest.GetEmployeeGroupTestData();
			int employeeGroupSysId = employeeGroups[0].SysId;
			
			EmployeeBll bll = new EmployeeBll();
			EmployeeData employee = new EmployeeData( Guid.Empty , "Hooyberghs" , "Johnny" , employeeGroupSysId );
			EmployeeDataCollection employees = new EmployeeDataCollection();
			employees.Add( employee );
			bll.InsertEmployeeData( employees );
			EmployeeDataCollection employeesToUpdate = bll.GetEmployeeDataForEmployeeGroup( employeeGroupSysId );
			foreach( EmployeeData e in employeesToUpdate ) {
				e.Name += "-EDITED";
				e.FirstName += "-EDITED";
			}
			bll.UpdateEmployeeData( employeesToUpdate );
			EmployeeDataCollection employeesResult = bll.GetEmployeeData();
			Assert.AreEqual( employees.Count , employeesResult.Count );
			foreach( EmployeeData e in employeesToUpdate ) {
				Assert.AreEqual( e.FirstName , employeesResult[employeesToUpdate.IndexOf( e )].FirstName );
				Assert.AreEqual( e.Name , employeesResult[employeesToUpdate.IndexOf( e )].Name );
			}
		}

		/// <summary>
		///A test for UpdateEmployees (update multiple employees).
		///</summary>
		[TestMethod]
		public void Crud_UpdateEmployeesTest() {
			EmployeeGroupDataCollection employeeGroups = EmployeeGroupBllTest.GetEmployeeGroupTestData();
			int employeeGroupSysId = employeeGroups[0].SysId;

			EmployeeBll bll = new EmployeeBll();
			EmployeeData employee1 = new EmployeeData( Guid.Empty , "Hooyberghs" , "Johnny" , employeeGroupSysId );
			EmployeeData employee2 = new EmployeeData( Guid.Empty , "Van Bogaert" , "Jelle" , employeeGroupSysId );
			EmployeeDataCollection employees = new EmployeeDataCollection();
			employees.Add( employee1 );
			employees.Add( employee2 );
			bll.InsertEmployeeData( employees );
			EmployeeDataCollection employeesToUpdate = bll.GetEmployeeData();
			foreach( EmployeeData e in employeesToUpdate ) {
				e.Name += "-EDITED";
				e.FirstName += "-EDITED";
			}
			bll.UpdateEmployeeData( employeesToUpdate );
			EmployeeDataCollection employeesResult = bll.GetEmployeeData();
			Assert.AreEqual( employees.Count , employeesResult.Count );
			foreach( EmployeeData e in employeesToUpdate ) {
				Assert.AreEqual( e.FirstName , employeesResult[employeesToUpdate.IndexOf( e )].FirstName );
				Assert.AreEqual( e.Name , employeesResult[employeesToUpdate.IndexOf( e )].Name );
			}
		}

		/// <summary>
		///A test for RemoveEmployees (remove a single employee).
		///</summary>
		[TestMethod]
		public void Crud_RemoveEmployeeTest() {
			EmployeeGroupDataCollection employeeGroups = EmployeeGroupBllTest.GetEmployeeGroupTestData();
			int employeeGroupSysId = employeeGroups[0].SysId;

			EmployeeBll bll = new EmployeeBll();
			EmployeeData employee = new EmployeeData( Guid.Empty , "Hooyberghs" , "Johnny" , employeeGroupSysId );
			EmployeeDataCollection employees = new EmployeeDataCollection();
			employees.Add( employee );
			bll.InsertEmployeeData( employees );
			EmployeeDataCollection employeesToRemove = bll.GetEmployeeData();
			bll.RemoveEmployeeData( employeesToRemove );
			EmployeeDataCollection employeesResult = bll.GetEmployeeData();
			Assert.AreEqual( 0 , employeesResult.Count );

			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( employees.Count , logDeletes.Count );
		}

		/// <summary>
		///A test for RemoveEmployees (remove multiple employees).
		///</summary>
		[TestMethod]
		public void Crud_RemoveEmployeesTest() {
			EmployeeGroupDataCollection employeeGroups = EmployeeGroupBllTest.GetEmployeeGroupTestData();
			int employeeGroupSysId = employeeGroups[0].SysId;

			EmployeeBll bll = new EmployeeBll();
			EmployeeData employee1 = new EmployeeData( Guid.Empty , "Hooyberghs" , "Johnny" , employeeGroupSysId );
			EmployeeData employee2 = new EmployeeData( Guid.Empty , "Van Bogaert" , "Jelle" , employeeGroupSysId );
			EmployeeDataCollection employees = new EmployeeDataCollection();
			employees.Add( employee1 );
			employees.Add( employee2 );
			bll.InsertEmployeeData( employees );
			EmployeeDataCollection employeesToRemove = bll.GetEmployeeData();
			bll.RemoveEmployeeData( employeesToRemove );
			EmployeeDataCollection employeesResult = bll.GetEmployeeData();
			Assert.AreEqual( 0 , employeesResult.Count );

			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( employees.Count , logDeletes.Count );
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