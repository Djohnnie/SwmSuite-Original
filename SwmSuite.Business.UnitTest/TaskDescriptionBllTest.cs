using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Data.DataObjects;
using SwmSuite.Framework;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Business.UnitTest.UnitTestHelper;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the TaskDescriptionBll methods.
	/// </summary>
	[TestClass()]
	public class TaskDescriptionBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private TaskDescriptionBll taskdescriptionBll = new TaskDescriptionBll();

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
		/// A test for InsertTaskDescription (insert a single taskdescription).
		/// </summary>
		[TestMethod]
		public void Crud_InsertTaskDescriptionTest() {
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();

			TaskDescriptionBll bll = new TaskDescriptionBll();
			TaskDescriptionDataCollection taskDescriptions = TaskDescriptionDataCollection.FromSingleTaskDescription( new TaskDescriptionData( "Title" , DateTime.Today , "Description" , DateTime.Today.AddDays( 7 ) , employee.SysId ) );
			bll.InsertTaskDescriptionData( taskDescriptions );
			TaskDescriptionDataCollection taskDescriptionsResult = bll.GetTaskDescriptionData();
			TaskDescriptionUnitTestHelper.AreEqual( taskDescriptions , taskDescriptionsResult );
		}

		/// <summary>
		/// A test for InsertTaskDescription (insert multiple taskdescriptions).
		/// </summary>
		[TestMethod]
		public void Crud_InsertTaskDescriptionsTest() {
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();

			TaskDescriptionBll bll = new TaskDescriptionBll();
			TaskDescriptionDataCollection taskDescriptions = new TaskDescriptionDataCollection();
			taskDescriptions.Add( new TaskDescriptionData( "Title 1" , DateTime.Today , "Description 1" , DateTime.Today.AddDays( 7 ) , employee.SysId ) );
			taskDescriptions.Add( new TaskDescriptionData( "Title 2" , DateTime.Today.AddYears( 1 ) , "Description 2" , DateTime.Today.AddYears( 1 ).AddDays( 7 ) , employee.SysId ) );
			taskDescriptions.Add( new TaskDescriptionData( "Title 3" , DateTime.Today.AddYears( 2 ) , "Description 3" , DateTime.Today.AddYears( 2 ).AddDays( 7 ) , employee.SysId ) );
			bll.InsertTaskDescriptionData( taskDescriptions );
			TaskDescriptionDataCollection taskDescriptionsResult = bll.GetTaskDescriptionData();
			Assert.AreEqual( taskDescriptions.Count , taskDescriptionsResult.Count );
			TaskDescriptionUnitTestHelper.AreEqual( taskDescriptions , taskDescriptionsResult );
		}

		/// <summary>
		/// A test for UpdateTaskDescriptions (update a single taskdescription).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTaskDescriptionTest() {
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();

			TaskDescriptionBll bll = new TaskDescriptionBll();
			TaskDescriptionDataCollection taskDescriptions = TaskDescriptionDataCollection.FromSingleTaskDescription( new TaskDescriptionData( "Title" , DateTime.Today , "Description" , DateTime.Today.AddDays( 7 ) , employee.SysId ) );
			bll.InsertTaskDescriptionData( taskDescriptions );
			TaskDescriptionDataCollection taskDescriptionsToUpdate = bll.GetTaskDescriptionData();
			TaskDescriptionUnitTestHelper.AreEqual( taskDescriptions , taskDescriptionsToUpdate );
			TaskDescriptionUnitTestHelper.UpdateTaskDescriptions( taskDescriptionsToUpdate );
			bll.UpdateTaskDescriptionData( taskDescriptionsToUpdate );
			TaskDescriptionDataCollection taskDescriptionsResult = bll.GetTaskDescriptionData();
			TaskDescriptionUnitTestHelper.AreEqual( taskDescriptionsToUpdate , taskDescriptionsResult );
		}

		/// <summary>
		/// A test for UpdateTaskDescriptions (update multiple taskdescriptions).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTaskDescriptionsTest() {
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();

			TaskDescriptionBll bll = new TaskDescriptionBll();
			TaskDescriptionDataCollection taskDescriptions = new TaskDescriptionDataCollection();
			taskDescriptions.Add( new TaskDescriptionData( "Title 1" , DateTime.Today , "Description 1" , DateTime.Today.AddDays( 7 ) , employee.SysId ) );
			taskDescriptions.Add( new TaskDescriptionData( "Title 2" , DateTime.Today.AddYears( 1 ) , "Description 2" , DateTime.Today.AddYears( 1 ).AddDays( 7 ) , employee.SysId ) );
			taskDescriptions.Add( new TaskDescriptionData( "Title 3" , DateTime.Today.AddYears( 2 ) , "Description 3" , DateTime.Today.AddYears( 2 ).AddDays( 7 ) , employee.SysId ) );
			bll.InsertTaskDescriptionData( taskDescriptions );
			TaskDescriptionDataCollection taskDescriptionsToUpdate = bll.GetTaskDescriptionData();
			TaskDescriptionUnitTestHelper.AreEqual( taskDescriptions , taskDescriptionsToUpdate );
			TaskDescriptionUnitTestHelper.UpdateTaskDescriptions( taskDescriptionsToUpdate );
			bll.UpdateTaskDescriptionData( taskDescriptionsToUpdate );
			TaskDescriptionDataCollection taskDescriptionsResult = bll.GetTaskDescriptionData();
			TaskDescriptionUnitTestHelper.AreEqual( taskDescriptionsToUpdate , taskDescriptionsResult );
		}

		/// <summary>
		/// A test for RemoveTaskDescriptions (remove a single taskdescription).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTaskDescriptionTest() {
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();

			TaskDescriptionBll bll = new TaskDescriptionBll();
			TaskDescriptionDataCollection taskDescriptions = TaskDescriptionDataCollection.FromSingleTaskDescription( new TaskDescriptionData( "Title" , DateTime.Today , "Description" , DateTime.Today.AddDays( 7 ) , employee.SysId ) );
			bll.InsertTaskDescriptionData( taskDescriptions );
			TaskDescriptionDataCollection taskDescriptionsToRemove = bll.GetTaskDescriptionData();
			TaskDescriptionUnitTestHelper.AreEqual( taskDescriptions , taskDescriptionsToRemove );
			TaskDescriptionUnitTestHelper.UpdateTaskDescriptions( taskDescriptionsToRemove );
			bll.RemoveTaskDescriptionData( taskDescriptionsToRemove );
			TaskDescriptionDataCollection taskDescriptionsResult = bll.GetTaskDescriptionData();
			Assert.AreEqual( 0 , taskDescriptionsResult.Count , "The taskdescriptions should be removed!" );
			TaskDescriptionUnitTestHelper.AreInLogDeletes( taskDescriptionsToRemove );
		}

		/// <summary>
		/// A test for RemoveTaskDescriptions (remove multiple taskdescriptions).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTaskDescriptionsTest() {
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();

			TaskDescriptionBll bll = new TaskDescriptionBll();
			TaskDescriptionDataCollection taskDescriptions = new TaskDescriptionDataCollection();
			taskDescriptions.Add( new TaskDescriptionData( "Title 1" , DateTime.Today , "Description 1" , DateTime.Today.AddDays( 7 ) , employee.SysId ) );
			taskDescriptions.Add( new TaskDescriptionData( "Title 2" , DateTime.Today.AddYears( 1 ) , "Description 2" , DateTime.Today.AddYears( 1 ).AddDays( 7 ) , employee.SysId ) );
			taskDescriptions.Add( new TaskDescriptionData( "Title 3" , DateTime.Today.AddYears( 2 ) , "Description 3" , DateTime.Today.AddYears( 2 ).AddDays( 7 ) , employee.SysId ) );
			bll.InsertTaskDescriptionData( taskDescriptions );
			TaskDescriptionDataCollection taskDescriptionsToRemove = bll.GetTaskDescriptionData();
			TaskDescriptionUnitTestHelper.AreEqual( taskDescriptions , taskDescriptionsToRemove );
			TaskDescriptionUnitTestHelper.UpdateTaskDescriptions( taskDescriptionsToRemove );
			bll.RemoveTaskDescriptionData( taskDescriptionsToRemove );
			TaskDescriptionDataCollection taskDescriptionsResult = bll.GetTaskDescriptionData();
			Assert.AreEqual( 0 , taskDescriptionsResult.Count , "The taskdescriptions should be removed!" );
			TaskDescriptionUnitTestHelper.AreInLogDeletes( taskDescriptionsToRemove );
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
