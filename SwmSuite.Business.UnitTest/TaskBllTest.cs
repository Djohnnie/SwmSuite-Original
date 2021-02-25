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
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the TaskBll methods.
	/// </summary>
	[TestClass()]
	public class TaskBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private TaskBll _taskBll = new TaskBll();
		private TaskDescriptionBll _taskDescriptionBll = new TaskDescriptionBll();
		private TaskRecurrenceBll _taskRecurrenceBll = new TaskRecurrenceBll();
		private TaskRunBll _taskRunBll = new TaskRunBll();
		private RecurrenceBll _recurrenceBll = new RecurrenceBll();

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

		//[TestMethod]
		//public void Business_CreateTaskWithoutRecurrenceTest() {
		//  //
		//  // Create the test comissioner.
		//  //
		//  EmployeeData comissionerTestData = EmployeeUnitTestHelper.GetEmployeeTestData();
			
		//  Employee employee = new Employee(){
		//    SysId = comissionerTestData.SysId
		//  };

		//  //
		//  // Create the test employees.
		//  //
		//  EmployeeDataCollection employeesTestData = EmployeeUnitTestHelper.GetEmployeesTestData();

		//  EmployeeCollection employees = new EmployeeCollection();
		//  foreach( EmployeeData ed in employeesTestData ) {
		//    employees.Add( new Employee() {
		//      SysId = ed.SysId
		//    } );
		//  }
			
		//  //
		//  // Create the task object.
		//  //
		//  Task newTask = new Task() {
		//    Title = "New Task" ,
		//    Description = "New Task Description" ,
		//    CreationDate = DateTime.Now ,
		//    Deadline = DateTime.Today.AddDays( 7 ) ,
		//    Commissioner = employee ,
		//    Employees = employees
		//  };

		//  _taskBll.CreateTask( newTask );

		//  //
		//  // Check if all necessary data has been created.
		//  //
		//  TaskDescriptionDataCollection taskDescriptionsFound =
		//    _taskDescriptionBll.GetTaskDescriptionData();
		//  Assert.AreEqual( 1 , taskDescriptionsFound.Count , "There should be 1 taskdescription in the database." );

		//  TaskRecurrenceDataCollection taskRecurrencesFound =
		//    _taskRecurrenceBll.GetTaskRecurrenceData();
		//  Assert.AreEqual( 0 , taskRecurrencesFound.Count , "There shouldn't be any taskrecurrences in the database." );

		//  RecurrenceDataCollection recurrencesFound =
		//    _recurrenceBll.GetRecurrenceData();
		//  Assert.AreEqual( 0 , recurrencesFound.Count , "There shouldn't be any recurrences in the database." );

		//  TaskDataCollection tasksFound =
		//    _taskBll.GetTaskData();
		//  Assert.AreEqual( employeesTestData.Count , tasksFound.Count , "There should be as many tasks in the database as there are employees used to create the task." );
		//}

		//[TestMethod]
		//public void Business_CreateTaskWithRecurrenceTest() {
		//  //
		//  // Create the test comissioner.
		//  //
		//  EmployeeData comissionerTestData = EmployeeUnitTestHelper.GetEmployeeTestData();

		//  Employee employee = new Employee() {
		//    SysId = comissionerTestData.SysId
		//  };

		//  //
		//  // Create the test employees.
		//  //
		//  EmployeeDataCollection employeesTestData = EmployeeUnitTestHelper.GetEmployeesTestData();

		//  EmployeeCollection employees = new EmployeeCollection();
		//  foreach( EmployeeData ed in employeesTestData ) {
		//    employees.Add( new Employee() {
		//      SysId = ed.SysId
		//    } );
		//  }

		//  Recurrence recurrence = new Recurrence() {
		//    RecurrenceMode = RecurrenceMode.Daily ,
		//    EndDate = DateTime.Today.AddYears( 1 )
		//  };

		//  //
		//  // Create the task object.
		//  //
		//  Task newTask = new Task() {
		//    Title = "New Task" ,
		//    Description = "New Task Description" ,
		//    CreationDate = DateTime.Now ,
		//    Deadline = DateTime.Today.AddDays( 7 ) ,
		//    Commissioner = employee ,
		//    Employees = employees,
		//    Recurrence = recurrence
		//  };

		//  _taskBll.CreateTask( newTask );

		//  //
		//  // Check if all necessary data has been created.
		//  //
		//  TaskDescriptionDataCollection taskDescriptionsFound =
		//    _taskDescriptionBll.GetTaskDescriptionData();
		//  Assert.AreEqual( 1 , taskDescriptionsFound.Count , "There should be 1 taskdescription in the database." );

		//  TaskRecurrenceDataCollection taskRecurrencesFound =
		//    _taskRecurrenceBll.GetTaskRecurrenceData();
		//  Assert.AreEqual( 1 , taskRecurrencesFound.Count , "There should be 1 taskrecurrences in the database." );

		//  RecurrenceDataCollection recurrencesFound =
		//    _recurrenceBll.GetRecurrenceData();
		//  Assert.AreEqual( 1 , recurrencesFound.Count , "There should be 1 recurrences in the database." );

		//  TaskDataCollection tasksFound =
		//    _taskBll.GetTaskData();
		//  Assert.AreEqual( employeesTestData.Count , tasksFound.Count , "There should be as many tasks in the database as there are employees used to create the task." );
		//}

		#endregion

		#region -_ Crud Test Methods _-

		/// <summary>
		/// A test for InsertTasks (insert a single task).
		/// </summary>
		[TestMethod]
		public void Crud_InsertTaskTest() {
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();
			TaskDescriptionData taskDescription = TaskDescriptionUnitTestHelper.GetTaskDescriptionTestData();

			TaskBll bll = new TaskBll();
			TaskDataCollection tasks = TaskDataCollection.FromSingleTask( new TaskData( employee.SysId , taskDescription.SysId ) );
			bll.InsertTaskData( tasks );
			TaskDataCollection tasksResult = bll.GetTaskData();
			TaskUnitTestHelper.AreEqual( tasks , tasksResult );
		}

		/// <summary>
		/// A test for InsertTasks (insert multiple tasks).
		/// </summary>
		[TestMethod]
		public void Crud_InsertTasksTest() {
			EmployeeDataCollection employees = EmployeeUnitTestHelper.GetEmployeesTestData();
			TaskDescriptionData taskDescription = TaskDescriptionUnitTestHelper.GetTaskDescriptionTestData();

			TaskBll bll = new TaskBll();
			TaskDataCollection tasks = new TaskDataCollection();
			foreach( EmployeeData employee in employees ) {
				tasks.Add( new TaskData( employee.SysId , taskDescription.SysId ) );
			}
			bll.InsertTaskData( tasks );
			TaskDataCollection tasksResult = bll.GetTaskData();
			TaskUnitTestHelper.AreEqual( tasks , tasksResult );
		}

		/// <summary>
		/// A test for UpdateTasks (update a single task).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTaskTest() {
			EmployeeData employee1 = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData employee2 = EmployeeUnitTestHelper.GetEmployeeTestData();
			TaskDescriptionData taskDescription1 = TaskDescriptionUnitTestHelper.GetTaskDescriptionTestData();
			TaskDescriptionData taskDescription2 = TaskDescriptionUnitTestHelper.GetTaskDescriptionTestData();

			TaskBll bll = new TaskBll();
			TaskDataCollection tasks = TaskDataCollection.FromSingleTask( new TaskData( employee1.SysId , taskDescription1.SysId ) );
			bll.InsertTaskData( tasks );
			TaskDataCollection tasksToUpdate = bll.GetTaskData();
			tasksToUpdate[0].EmployeeSysId = employee2.SysId;
			tasksToUpdate[0].TaskDescriptionSysId = taskDescription2.SysId;
			bll.UpdateTaskData( tasksToUpdate );
			TaskDataCollection tasksResult = bll.GetTaskData();
			TaskUnitTestHelper.AreEqual( tasksToUpdate , tasksResult );
		}

		/// <summary>
		/// A test for UpdateTasks (update multiple tasks).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTasksTest() {
			EmployeeDataCollection employees1 = EmployeeUnitTestHelper.GetEmployeesTestData();
			EmployeeDataCollection employees2 = EmployeeUnitTestHelper.GetEmployeesTestData();
			TaskDescriptionData taskDescription1 = TaskDescriptionUnitTestHelper.GetTaskDescriptionTestData();
			TaskDescriptionData taskDescription2 = TaskDescriptionUnitTestHelper.GetTaskDescriptionTestData();

			TaskBll bll = new TaskBll();
			TaskDataCollection tasks = new TaskDataCollection();
			foreach( EmployeeData employee in employees1 ) {
				tasks.Add( new TaskData( employee.SysId , taskDescription1.SysId ) );
			}
			bll.InsertTaskData( tasks );
			TaskDataCollection tasksToUpdate = bll.GetTaskData();
			foreach( EmployeeData employee in employees2 ) {
				tasksToUpdate[employees2.IndexOf( employee )].EmployeeSysId = employee.SysId;
				tasksToUpdate[employees2.IndexOf( employee )].TaskDescriptionSysId = taskDescription2.SysId;
			}
			bll.UpdateTaskData( tasksToUpdate );
			TaskDataCollection tasksResult = bll.GetTaskData();
			TaskUnitTestHelper.AreEqual( tasksToUpdate , tasksResult );
		}

		/// <summary>
		/// A test for RemoveTasks (remove a single task).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTaskTest() {
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();
			TaskDescriptionData taskDescription = TaskDescriptionUnitTestHelper.GetTaskDescriptionTestData();

			TaskBll bll = new TaskBll();
			TaskDataCollection tasks = TaskDataCollection.FromSingleTask( new TaskData( employee.SysId , taskDescription.SysId ) );
			bll.InsertTaskData( tasks );
			TaskDataCollection tasksToRemove = bll.GetTaskData();
			bll.RemoveTaskData( tasksToRemove );
			TaskDataCollection tasksResult = bll.GetTaskData();
			Assert.AreEqual( 0 , tasksResult.Count , "The tasks should be removed!" );
			TaskUnitTestHelper.AreInLogDeletes( tasksToRemove );
		}

		/// <summary>
		/// A test for RemoveTasks (remove multiple tasks).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTasksTest() {
			EmployeeDataCollection employees = EmployeeUnitTestHelper.GetEmployeesTestData();
			TaskDescriptionData taskDescription = TaskDescriptionUnitTestHelper.GetTaskDescriptionTestData();

			TaskBll bll = new TaskBll();
			TaskDataCollection tasks = new TaskDataCollection();
			foreach( EmployeeData employee in employees ) {
				tasks.Add( new TaskData( employee.SysId , taskDescription.SysId ) );
			}
			bll.InsertTaskData( tasks );
			TaskDataCollection tasksToRemove = bll.GetTaskData();
			bll.RemoveTaskData( tasksToRemove );
			TaskDataCollection tasksResult = bll.GetTaskData();
			Assert.AreEqual( 0 , tasksResult.Count , "The tasks should be removed!" );
			TaskUnitTestHelper.AreInLogDeletes( tasksToRemove );
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
