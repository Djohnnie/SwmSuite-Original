using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.DataObjects;
using SwmSuite.Framework;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using System.Globalization;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the TaskRecurrenceBll methods.
	/// </summary>
	[TestClass()]
	public class TaskRecurrenceBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private TaskRecurrenceBll taskrecurrenceBll = new TaskRecurrenceBll();

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
		/// A test for InsertTaskRecurrences (insert a single taskrecurrence).
		/// </summary>
		[TestMethod]
		public void Crud_InsertTaskRecurrenceTest() {
			TaskData task = TaskUnitTestHelper.GetTaskTestData();
			RecurrenceData recurrence = RecurrenceUnitTestHelper.GetRecurrenceTestData();

			TaskRecurrenceBll bll = new TaskRecurrenceBll();
			TaskRecurrenceDataCollection taskRecurrences = TaskRecurrenceDataCollection.FromSingleTaskRecurrence(
				new TaskRecurrenceData( task.TaskDescriptionSysId , recurrence.SysId ) );
			bll.InsertTaskRecurrenceData( taskRecurrences );
			TaskRecurrenceDataCollection taskRecurrencesResult = bll.GetTaskRecurrenceData();
			TaskRecurrenceUnitTestHelper.AreEqual( taskRecurrences , taskRecurrencesResult );
		}

		/// <summary>
		/// A test for InsertTaskRecurrences (insert multiple taskrecurrences).
		/// </summary>
		[TestMethod]
		public void Crud_InsertTaskRecurrencesTest() {
			TaskDataCollection tasks = TaskUnitTestHelper.GetTasksTestData();
			RecurrenceDataCollection recurrences = RecurrenceUnitTestHelper.GetRecurrencesTestData();

			TaskRecurrenceBll bll = new TaskRecurrenceBll();
			TaskRecurrenceDataCollection taskRecurrences = new TaskRecurrenceDataCollection();
			foreach( RecurrenceData recurrence in recurrences ) {
				TaskData task = tasks[recurrences.IndexOf( recurrence )];
				taskRecurrences.Add( new TaskRecurrenceData( task.TaskDescriptionSysId , recurrence.SysId ) );
			}
			bll.InsertTaskRecurrenceData( taskRecurrences );
			TaskRecurrenceDataCollection taskRecurrencesResult = bll.GetTaskRecurrenceData();
			TaskRecurrenceUnitTestHelper.AreEqual( taskRecurrences , taskRecurrencesResult );
		}

		/// <summary>
		/// A test for UpdateTaskRecurrences (update a single taskrecurrence).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTaskRecurrenceTest() {
			TaskData task1 = TaskUnitTestHelper.GetTaskTestData();
			TaskData task2 = TaskUnitTestHelper.GetTaskTestData();
			RecurrenceData recurrence1 = RecurrenceUnitTestHelper.GetRecurrenceTestData();
			RecurrenceData recurrence2 = RecurrenceUnitTestHelper.GetRecurrenceTestData();

			TaskRecurrenceBll bll = new TaskRecurrenceBll();
			TaskRecurrenceDataCollection taskRecurrences = TaskRecurrenceDataCollection.FromSingleTaskRecurrence(
				new TaskRecurrenceData( task1.TaskDescriptionSysId , recurrence1.SysId ) );
			bll.InsertTaskRecurrenceData( taskRecurrences );
			TaskRecurrenceDataCollection taskRecurrencesToUpdate = bll.GetTaskRecurrenceData();
			taskRecurrencesToUpdate[0].TaskDescriptionSysId = task2.TaskDescriptionSysId;
			taskRecurrencesToUpdate[0].RecurrenceSysId = recurrence2.SysId;
			bll.UpdateTaskRecurrenceData( taskRecurrencesToUpdate );
			TaskRecurrenceDataCollection taskRecurrencesResult = bll.GetTaskRecurrenceData();
			TaskRecurrenceUnitTestHelper.AreEqual( taskRecurrencesToUpdate , taskRecurrencesResult );
		}

		/// <summary>
		/// A test for UpdateTaskRecurrences (update multiple taskrecurrences).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTaskRecurrencesTest() {
			TaskDataCollection tasks1 = TaskUnitTestHelper.GetTasksTestData();
			TaskDataCollection tasks2 = TaskUnitTestHelper.GetTasksTestData();
			RecurrenceDataCollection recurrences1 = RecurrenceUnitTestHelper.GetRecurrencesTestData();
			RecurrenceDataCollection recurrences2 = RecurrenceUnitTestHelper.GetRecurrencesTestData();

			TaskRecurrenceBll bll = new TaskRecurrenceBll();
			TaskRecurrenceDataCollection taskRecurrences = new TaskRecurrenceDataCollection();
			foreach( RecurrenceData recurrence in recurrences1 ) {
				TaskData task = tasks1[recurrences1.IndexOf(recurrence)];
				taskRecurrences.Add( new TaskRecurrenceData( task.TaskDescriptionSysId , recurrence.SysId ) );
			}
			bll.InsertTaskRecurrenceData( taskRecurrences );
			TaskRecurrenceDataCollection taskRecurrencesToUpdate = bll.GetTaskRecurrenceData();
			foreach( TaskRecurrenceData taskRecurrence in taskRecurrencesToUpdate ) {
				TaskData task = tasks2[taskRecurrencesToUpdate.IndexOf(taskRecurrence)];
				RecurrenceData recurrence = recurrences2[taskRecurrencesToUpdate.IndexOf(taskRecurrence)];
				taskRecurrence.TaskDescriptionSysId = task.TaskDescriptionSysId;
				taskRecurrence.RecurrenceSysId = recurrence.SysId;
			}
			bll.UpdateTaskRecurrenceData( taskRecurrencesToUpdate );
			TaskRecurrenceDataCollection taskRecurrencesResult = bll.GetTaskRecurrenceData();
			TaskRecurrenceUnitTestHelper.AreEqual( taskRecurrencesToUpdate , taskRecurrencesResult );
		}

		/// <summary>
		/// A test for RemoveTaskRecurrences (remove a single taskrecurrence).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTaskRecurrenceTest() {
			TaskData task1 = TaskUnitTestHelper.GetTaskTestData();
			TaskData task2 = TaskUnitTestHelper.GetTaskTestData();
			RecurrenceData recurrence1 = RecurrenceUnitTestHelper.GetRecurrenceTestData();
			RecurrenceData recurrence2 = RecurrenceUnitTestHelper.GetRecurrenceTestData();

			TaskRecurrenceBll bll = new TaskRecurrenceBll();
			TaskRecurrenceDataCollection taskRecurrences = TaskRecurrenceDataCollection.FromSingleTaskRecurrence(
				new TaskRecurrenceData( task1.TaskDescriptionSysId , recurrence1.SysId ) );
			bll.InsertTaskRecurrenceData( taskRecurrences );
			TaskRecurrenceDataCollection taskRecurrencesToRemove = bll.GetTaskRecurrenceData();
			bll.RemoveTaskRecurrenceData( taskRecurrencesToRemove );
			TaskRecurrenceDataCollection taskRecurrencesResult = bll.GetTaskRecurrenceData();
			Assert.AreEqual( 0 , taskRecurrencesResult.Count , "The taskrecurrences should be removed!" );
			TaskRecurrenceUnitTestHelper.AreInLogDeletes( taskRecurrencesToRemove );
		}

		/// <summary>
		/// A test for RemoveTaskRecurrences (remove multiple taskrecurrences).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTaskRecurrencesTest() {
			TaskDataCollection tasks1 = TaskUnitTestHelper.GetTasksTestData();
			TaskDataCollection tasks2 = TaskUnitTestHelper.GetTasksTestData();
			RecurrenceDataCollection recurrences1 = RecurrenceUnitTestHelper.GetRecurrencesTestData();
			RecurrenceDataCollection recurrences2 = RecurrenceUnitTestHelper.GetRecurrencesTestData();

			TaskRecurrenceBll bll = new TaskRecurrenceBll();
			TaskRecurrenceDataCollection taskRecurrences = new TaskRecurrenceDataCollection();
			foreach( RecurrenceData recurrence in recurrences1 ) {
				TaskData task = tasks1[recurrences1.IndexOf( recurrence )];
				taskRecurrences.Add( new TaskRecurrenceData( task.TaskDescriptionSysId , recurrence.SysId ) );
			}
			bll.InsertTaskRecurrenceData( taskRecurrences );
			TaskRecurrenceDataCollection taskRecurrencesToRemove = bll.GetTaskRecurrenceData();
			bll.RemoveTaskRecurrenceData( taskRecurrencesToRemove );
			TaskRecurrenceDataCollection taskRecurrencesResult = bll.GetTaskRecurrenceData();
			Assert.AreEqual( 0 , taskRecurrencesResult.Count , "The taskrecurrences should be removed!" );
			TaskRecurrenceUnitTestHelper.AreInLogDeletes( taskRecurrencesToRemove );
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
