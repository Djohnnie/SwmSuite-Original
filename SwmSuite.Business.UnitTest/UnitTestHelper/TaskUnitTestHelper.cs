using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.TaskModule;
using System.Globalization;
using SwmSuite.Business;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class TaskUnitTestHelper {

		public static void AreEqual( TaskDataCollection expected , TaskDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " tasks expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " tasks actual!" );
			// Test individual tasks.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].EmployeeSysId , actual[i].EmployeeSysId , "UT: expected Task.EmployeeSysId (" + expected[i].EmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual Task.EmployeeSysId (" + actual[i].EmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].TaskDescriptionSysId , actual[i].TaskDescriptionSysId , "UT: expected Task.TaskDescriptionSysId (" + expected[i].TaskDescriptionSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual Task.TaskDescriptionSysId (" + actual[i].TaskDescriptionSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( TaskDataCollection tasks ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , tasks.Count , "UT: " + tasks.Count.ToString( CultureInfo.InvariantCulture ) + " tasks expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " tasks found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new TaskSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( tasks[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static TaskData GetTaskTestData() {
			TaskBll bll = new TaskBll();
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();
			TaskDescriptionData taskDescription = TaskDescriptionUnitTestHelper.GetTaskDescriptionTestData();
			TaskDataCollection tasks = TaskDataCollection.FromSingleTask( 
				new TaskData( employee.SysId , taskDescription.SysId ) );
			TaskDataCollection tasksResult = bll.InsertTaskData( tasks );
			return tasksResult[0];
		}

		public static TaskDataCollection GetTasksTestData() {
			TaskBll bll = new TaskBll();
			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();
			TaskDescriptionDataCollection taskDescriptions = TaskDescriptionUnitTestHelper.GetTaskDescriptionsTestData();
			TaskDataCollection tasks = new TaskDataCollection();
			foreach( TaskDescriptionData taskDescription in taskDescriptions ){
				tasks.Add( new TaskData( employee.SysId , taskDescription.SysId ) );
			}
			TaskDataCollection tasksResult = bll.InsertTaskData( tasks );
			return tasksResult;
		}

	}

}
