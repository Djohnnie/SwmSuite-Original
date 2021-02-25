using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.TaskModule;
using SwmSuite.Business;
using System.Globalization;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class TaskDescriptionUnitTestHelper {

		public static void AreEqual( TaskDescriptionDataCollection expected , TaskDescriptionDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " taskdescriptions expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " taskdescriptions actual!" );
			// Test individual taskdescriptions.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].Title , actual[i].Title , "UT: expected TaskDescription.Title (" + expected[i].Title + ") <> actual TaskDescription.Title (" + actual[i].Title + ")!" );
				Assert.AreEqual( expected[i].CreationDate , actual[i].CreationDate , "UT: expected TaskDescription.CreationDate (" + expected[i].CreationDate.ToString( CultureInfo.InvariantCulture ) + ") <> actual TaskDescription.CreationDate (" + actual[i].CreationDate.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].Description , actual[i].Description , "UT: expected TaskDescription.Description (" + expected[i].Description + ") <> actual TaskDescription.Description (" + actual[i].Description + ")!" );
				Assert.AreEqual( expected[i].Deadline , actual[i].Deadline , "UT: expected TaskDescription.Deadline (" + expected[i].Deadline.ToString( ) + ") <> actual TaskDescription.Deadline (" + actual[i].Deadline.ToString( ) + ")!" );
				Assert.AreEqual( expected[i].CommissionerEmployeeSysId , actual[i].CommissionerEmployeeSysId , "UT: expected TaskDescription.CommissionerEmployeeSysId (" + expected[i].CommissionerEmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual TaskDescription.CommissionerEmployeeSysId (" + actual[i].CommissionerEmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( TaskDescriptionDataCollection taskdescriptions ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , taskdescriptions.Count , "UT: " + taskdescriptions.Count.ToString( CultureInfo.InvariantCulture ) + " taskdescriptions expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " taskdescriptions found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new TaskDescriptionSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( taskdescriptions[logDeletes.IndexOf( ld )].ToString( ) , ld.Info );
			}
		}

		public static void UpdateTaskDescriptions( TaskDescriptionDataCollection taskdescriptions ) {
			foreach( TaskDescriptionData taskdescription in taskdescriptions ) {
				taskdescription.Title += " -> EDITED!";
				taskdescription.CreationDate = taskdescription.CreationDate.AddDays( 7 );
				if( taskdescription.Deadline.HasValue ) {
					taskdescription.Deadline = taskdescription.Deadline.Value.AddDays( 7 );
				}
				taskdescription.Description += " -> EDITED!";
			}
		}

		public static TaskDescriptionData GetTaskDescriptionTestData() {
			TaskDescriptionBll bll = new TaskDescriptionBll();

			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();

			TaskDescriptionDataCollection taskDescriptions = TaskDescriptionDataCollection.FromSingleTaskDescription( new TaskDescriptionData( "Title" , DateTime.Today , "Description" , DateTime.Today.AddDays( 7 ) , employee.SysId ) );
			TaskDescriptionDataCollection taskDescriptionsResult = 
				bll.InsertTaskDescriptionData( taskDescriptions );
			return taskDescriptionsResult[0];
		}

		public static TaskDescriptionDataCollection GetTaskDescriptionsTestData() {
			TaskDescriptionBll bll = new TaskDescriptionBll();

			EmployeeData employee = EmployeeUnitTestHelper.GetEmployeeTestData();

			TaskDescriptionDataCollection taskDescriptions = new TaskDescriptionDataCollection();
			taskDescriptions.Add( new TaskDescriptionData( "Title 1" , DateTime.Today , "Description 1" , DateTime.Today.AddDays( 7 ) , employee.SysId ) );
			taskDescriptions.Add( new TaskDescriptionData( "Title 2" , DateTime.Today.AddYears( 1 ) , "Description 2" , DateTime.Today.AddYears( 1 ).AddDays( 7 ) , employee.SysId ) );
			taskDescriptions.Add( new TaskDescriptionData( "Title 3" , DateTime.Today.AddYears( 2 ) , "Description 3" , DateTime.Today.AddYears( 2 ).AddDays( 7 ) , employee.SysId ) );
			TaskDescriptionDataCollection taskDescriptionsResult =
				bll.InsertTaskDescriptionData( taskDescriptions );
			return taskDescriptionsResult;
		}

	}

}
