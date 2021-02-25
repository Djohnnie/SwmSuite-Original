using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Framework;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using System.Globalization;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the TaskRunBll methods.
	/// </summary>
	[TestClass()]
	public class TaskRunBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private TaskRunBll taskrunBll = new TaskRunBll();

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
		/// A test for InsertTaskRuns (insert a single taskRun).
		/// </summary>
		[TestMethod]
		public void Crud_InsertTaskRunTest() {
			TaskData taskData = TaskUnitTestHelper.GetTaskTestData();

			TaskRunBll bll = new TaskRunBll();
			TaskRunDataCollection taskRuns = TaskRunDataCollection.FromSingleTaskRun( new TaskRunData( taskData.SysId , DateTime.Today , "Remarks" , TaskRunMode.TaskFinished ) );
			bll.InsertTaskRunData( taskRuns );
			TaskRunDataCollection taskRunsResult = bll.GetTaskRunData();
			TaskRunUnitTestHelper.AreEqual( taskRuns , taskRunsResult );
		}

		/// <summary>
		/// A test for InsertTaskRuns (insert multiple taskRuns).
		/// </summary>
		[TestMethod]
		public void Crud_InsertTaskRunsTest() {
			EmployeeDataCollection employees = EmployeeUnitTestHelper.GetEmployeesTestData();
			TaskData taskData = TaskUnitTestHelper.GetTaskTestData();

			TaskRunBll bll = new TaskRunBll();
			TaskRunDataCollection taskRuns = new TaskRunDataCollection();
			foreach( EmployeeData employee in employees ) {
				taskRuns.Add( new TaskRunData( taskData.SysId , DateTime.Today.AddDays( employees.IndexOf( employee ) ) , "Remarks " + employees.IndexOf( employee ).ToString( CultureInfo.InvariantCulture ) , TaskRunMode.TaskFinished ) );
			}
			bll.InsertTaskRunData( taskRuns );
			TaskRunDataCollection taskRunsResult = bll.GetTaskRunData();
			TaskRunUnitTestHelper.AreEqual( taskRuns , taskRunsResult );
		}

		/// <summary>
		/// A test for UpdateTaskRuns (update a single taskRun).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTaskRunTest() {
			EmployeeData employee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			TaskData taskData1 = TaskUnitTestHelper.GetTaskTestData();
			TaskData taskData2 = TaskUnitTestHelper.GetTaskTestData();

			TaskRunBll bll = new TaskRunBll();
			TaskRunDataCollection taskRuns = TaskRunDataCollection.FromSingleTaskRun( new TaskRunData( taskData1.SysId , DateTime.Today , "Remarks" , TaskRunMode.TaskFinished ) );
			bll.InsertTaskRunData( taskRuns );
			TaskRunDataCollection taskRunsToUpdate = bll.GetTaskRunData();
			TaskRunUnitTestHelper.UpdateTaskRuns( taskRunsToUpdate );
			taskRunsToUpdate[0].TaskSysId = taskData2.SysId;
			bll.UpdateTaskRunData( taskRunsToUpdate );
			TaskRunDataCollection taskRunsResult = bll.GetTaskRunData();
			TaskRunUnitTestHelper.AreEqual( taskRunsToUpdate , taskRunsResult );
		}

		/// <summary>
		/// A test for UpdateTaskRuns (update multiple taskRuns).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTaskRunsTest() {
			EmployeeDataCollection employees1 = EmployeeUnitTestHelper.GetEmployeesTestData();
			EmployeeDataCollection employees2 = EmployeeUnitTestHelper.GetEmployeesTestData();
			TaskData taskData1 = TaskUnitTestHelper.GetTaskTestData();
			TaskData taskData2 = TaskUnitTestHelper.GetTaskTestData();

			TaskRunBll bll = new TaskRunBll();
			TaskRunDataCollection taskRuns = new TaskRunDataCollection();
			foreach( EmployeeData employee in employees1 ) {
				taskRuns.Add( new TaskRunData( taskData1.SysId , DateTime.Today.AddDays( employees1.IndexOf( employee ) ) , "Remarks " + employees1.IndexOf( employee ).ToString( CultureInfo.InvariantCulture ) , TaskRunMode.TaskFinished ) );
			}
			bll.InsertTaskRunData( taskRuns );
			TaskRunDataCollection taskRunsToUpdate = bll.GetTaskRunData();
			TaskRunUnitTestHelper.UpdateTaskRuns( taskRunsToUpdate );
			foreach( EmployeeData employee in employees2 ) {
				taskRunsToUpdate[employees2.IndexOf( employee )].TaskSysId = taskData2.SysId;
			}
			bll.UpdateTaskRunData( taskRunsToUpdate );
			TaskRunDataCollection taskRunsResult = bll.GetTaskRunData();
			TaskRunUnitTestHelper.AreEqual( taskRunsToUpdate , taskRunsResult );
		}

		/// <summary>
		/// A test for RemoveTaskRuns (remove a single taskRun).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTaskRunTest() {
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();
			TaskData taskData = TaskUnitTestHelper.GetTaskTestData();

			TaskRunBll bll = new TaskRunBll();
			TaskRunDataCollection taskRuns = TaskRunDataCollection.FromSingleTaskRun( new TaskRunData( taskData.SysId , DateTime.Today , "Remarks" , TaskRunMode.TaskFinished ) );
			bll.InsertTaskRunData( taskRuns );
			TaskRunDataCollection taskRunsToRemove = bll.GetTaskRunData();
			bll.RemoveTaskRunData( taskRunsToRemove );
			TaskRunDataCollection taskRunsResult = bll.GetTaskRunData();
			Assert.AreEqual( 0 , taskRunsResult.Count , "The taskRuns should be removed!" );
			TaskRunUnitTestHelper.AreInLogDeletes( taskRunsToRemove );
		}

		/// <summary>
		/// A test for RemoveTaskRuns (remove multiple taskRuns).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTaskRunsTest() {
			EmployeeDataCollection employees = EmployeeUnitTestHelper.GetEmployeesTestData();
			TaskData taskData = TaskUnitTestHelper.GetTaskTestData();

			TaskRunBll bll = new TaskRunBll();
			TaskRunDataCollection taskRuns = new TaskRunDataCollection();
			foreach( EmployeeData employee in employees ) {
				taskRuns.Add( new TaskRunData( taskData.SysId , DateTime.Today.AddDays( employees.IndexOf( employee ) ) , "Remarks " + employees.IndexOf( employee ).ToString( CultureInfo.InvariantCulture ) , TaskRunMode.TaskFinished ) );
			}
			bll.InsertTaskRunData( taskRuns );
			TaskRunDataCollection taskRunsToRemove = bll.GetTaskRunData();
			bll.RemoveTaskRunData( taskRunsToRemove );
			TaskRunDataCollection taskRunsResult = bll.GetTaskRunData();
			Assert.AreEqual( 0 , taskRunsResult.Count , "The taskRuns should be removed!" );
			TaskRunUnitTestHelper.AreInLogDeletes( taskRunsToRemove );
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
