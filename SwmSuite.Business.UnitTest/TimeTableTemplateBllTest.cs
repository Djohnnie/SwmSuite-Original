using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the TimeTableTemplateBll methods.
	/// </summary>
	[TestClass()]
	public class TimeTableTemplateBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private TimeTableTemplateBll _timeTableTemplateBll = new TimeTableTemplateBll();

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
		/// Try to insert a single timetable purpose.
		/// </summary>
		[TestMethod]
		public void Crud_InsertTimeTableTemplateTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create a new purpose dataobject.
			TimeTableTemplateData timeTableTemplateToInsert =
				new TimeTableTemplateData( "Name" , "Description" , testEmployeeGroup.SysId );

			// Insert the new purpose.
			TimeTableTemplateDataCollection timeTableTemplateInserted =
				_timeTableTemplateBll.InsertTimeTableTemplateData(
					TimeTableTemplateDataCollection.FromSingleTimeTableTemplate( timeTableTemplateToInsert ) );

			// Verify the inserted data.
			TimeTableTemplateUnitTestHelper.AreEqual(
				TimeTableTemplateDataCollection.FromSingleTimeTableTemplate( timeTableTemplateToInsert ) , timeTableTemplateInserted );
		}

		/// <summary>
		/// Try to insert multiple timetable purposes.
		/// </summary>
		[TestMethod]
		public void Crud_InsertTimeTableTemplatesTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create new purpose dataobjects.
			TimeTableTemplateDataCollection timeTableTemplatesToInsert = new TimeTableTemplateDataCollection();
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_1" , "Description_1" , testEmployeeGroup.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_2" , "Description_2" , testEmployeeGroup.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_3" , "Description_3" , testEmployeeGroup.SysId ) );

			// Insert the new purpose.
			TimeTableTemplateDataCollection timeTableTemplateInserted =
				_timeTableTemplateBll.InsertTimeTableTemplateData( timeTableTemplatesToInsert );

			// Verify the inserted data.
			TimeTableTemplateUnitTestHelper.AreEqual( timeTableTemplatesToInsert , timeTableTemplateInserted );
		}

		/// <summary>
		/// Try to update a single timetable purpose.
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTimeTableTemplateTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup1 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData testEmployeeGroup2 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create a new purpose dataobject.
			TimeTableTemplateData timeTableTemplateToInsert =
				new TimeTableTemplateData( "Name" , "Description" , testEmployeeGroup1.SysId );

			// Insert the new purpose.
			TimeTableTemplateDataCollection timeTableTemplateInserted =
				_timeTableTemplateBll.InsertTimeTableTemplateData(
					TimeTableTemplateDataCollection.FromSingleTimeTableTemplate( timeTableTemplateToInsert ) );

			// Edit the purposes.
			TimeTableTemplateUnitTestHelper.UpdateTimeTableTemplateData( timeTableTemplateInserted );
			foreach( TimeTableTemplateData timeTableTemplateData in timeTableTemplateInserted ) {
				timeTableTemplateData.EmployeeGroupSysId = testEmployeeGroup2.SysId;
			}

			// Update the edited purpose.
			TimeTableTemplateDataCollection timeTableTemplateUpdated =
				_timeTableTemplateBll.UpdateTimeTableTemplateData( timeTableTemplateInserted );

			// Verify the inserted data.
			TimeTableTemplateUnitTestHelper.AreEqual( timeTableTemplateInserted , timeTableTemplateUpdated );
		}

		/// <summary>
		/// Try to update multiple timetable purposes.
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTimeTableTemplatesTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup1 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData testEmployeeGroup2 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create new purpose dataobjects.
			TimeTableTemplateDataCollection timeTableTemplatesToInsert = new TimeTableTemplateDataCollection();
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_1" , "Description_1" , testEmployeeGroup1.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_2" , "Description_2" , testEmployeeGroup1.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_3" , "Description_3" , testEmployeeGroup1.SysId ) );

			// Insert the new purpose.
			TimeTableTemplateDataCollection timeTableTemplateInserted =
				_timeTableTemplateBll.InsertTimeTableTemplateData( timeTableTemplatesToInsert );

			// Edit the purposes.
			TimeTableTemplateUnitTestHelper.UpdateTimeTableTemplateData( timeTableTemplateInserted );
			foreach( TimeTableTemplateData timeTableTemplateData in timeTableTemplateInserted ) {
				timeTableTemplateData.EmployeeGroupSysId = testEmployeeGroup2.SysId;
			}

			// Update the edited purpose.
			TimeTableTemplateDataCollection timeTableTemplateUpdated =
				_timeTableTemplateBll.UpdateTimeTableTemplateData( timeTableTemplateInserted );

			// Verify the inserted data.
			TimeTableTemplateUnitTestHelper.AreEqual( timeTableTemplateInserted , timeTableTemplateUpdated );
		}

		/// <summary>
		/// Try to get a single timetable purpose.
		/// </summary>
		[TestMethod]
		public void Crud_GetTimeTableTemplateTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create a new purpose dataobject.
			TimeTableTemplateData timeTableTemplateToInsert =
				new TimeTableTemplateData( "Name" , "Description" , testEmployeeGroup.SysId );

			// Insert the new purpose.
			TimeTableTemplateDataCollection timeTableTemplateInserted =
				_timeTableTemplateBll.InsertTimeTableTemplateData(
					TimeTableTemplateDataCollection.FromSingleTimeTableTemplate( timeTableTemplateToInsert ) );

			foreach( TimeTableTemplateData timeTableTemplateData in timeTableTemplateInserted ) {
				TimeTableTemplateDataCollection timeTableTemplatesRetrieved =
					_timeTableTemplateBll.GetTimeTableTemplateDataBySysId( timeTableTemplateData.SysId );
				// Verify the inserted data.
				TimeTableTemplateUnitTestHelper.AreEqual(
					TimeTableTemplateDataCollection.FromSingleTimeTableTemplate( timeTableTemplateData ) , timeTableTemplatesRetrieved );
			}
		}

		/// <summary>
		/// Try to get all time table purposes.
		/// </summary>
		[TestMethod]
		public void Crud_GetTimeTableTemplatesTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup1 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData testEmployeeGroup2 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create new purpose dataobjects.
			TimeTableTemplateDataCollection timeTableTemplatesToInsert = new TimeTableTemplateDataCollection();
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_1" , "Description_1" , testEmployeeGroup1.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_2" , "Description_2" , testEmployeeGroup1.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_3" , "Description_3" , testEmployeeGroup1.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_4" , "Description_4" , testEmployeeGroup2.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_5" , "Description_5" , testEmployeeGroup2.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_6" , "Description_6" , testEmployeeGroup2.SysId ) );

			// Insert the new purpose.
			TimeTableTemplateDataCollection timeTableTemplateInserted =
				_timeTableTemplateBll.InsertTimeTableTemplateData( timeTableTemplatesToInsert );

			// Get the purposes from the database.
			TimeTableTemplateDataCollection timeTableTemplatesRetrieved =
					_timeTableTemplateBll.GetTimeTableTemplateData();

			// Verify the retrieved data.
			TimeTableTemplateUnitTestHelper.AreEqual( timeTableTemplatesToInsert , timeTableTemplatesRetrieved );
		}

		///// <summary>
		///// Try to get all timetable purposes for a specific employeegroup.
		///// </summary>
		//[TestMethod]
		//public void Crud_GetTimeTableTemplatesForEmployeeGroupTest() {
		//  // Get a test employeegroup.
		//  EmployeeGroupData testEmployeeGroup1 =
		//    EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
		//  EmployeeGroupData testEmployeeGroup2 =
		//    EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

		//  // Create new purpose dataobjects.
		//  TimeTableTemplateDataCollection timeTableTemplatesToInsert = new TimeTableTemplateDataCollection();
		//  timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_1" , "Description_1" , testEmployeeGroup1.SysId ) );
		//  timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_2" , "Description_2" , testEmployeeGroup1.SysId ) );
		//  timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_3" , "Description_3" , testEmployeeGroup1.SysId ) );
		//  timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_4" , "Description_4" , testEmployeeGroup2.SysId ) );
		//  timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_5" , "Description_5" , testEmployeeGroup2.SysId ) );
		//  timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_6" , "Description_6" , testEmployeeGroup2.SysId ) );

		//  // Split the purposes by employeegroup for verifying.
		//  TimeTableTemplateDataCollection timeTableTemplatesForEmployeeGroup1 = new TimeTableTemplateDataCollection();
		//  timeTableTemplatesForEmployeeGroup1.Add( timeTableTemplatesToInsert[0] );
		//  timeTableTemplatesForEmployeeGroup1.Add( timeTableTemplatesToInsert[1] );
		//  timeTableTemplatesForEmployeeGroup1.Add( timeTableTemplatesToInsert[2] );
		//  TimeTableTemplateDataCollection timeTableTemplatesForEmployeeGroup2 = new TimeTableTemplateDataCollection();
		//  timeTableTemplatesForEmployeeGroup2.Add( timeTableTemplatesToInsert[3] );
		//  timeTableTemplatesForEmployeeGroup2.Add( timeTableTemplatesToInsert[4] );
		//  timeTableTemplatesForEmployeeGroup2.Add( timeTableTemplatesToInsert[5] );

		//  // Insert the new purpose.
		//  TimeTableTemplateDataCollection timeTableTemplateInserted =
		//    _timeTableTemplateBll.InsertTimeTableTemplateData( timeTableTemplatesToInsert );

		//  // Get the purposes from the database.
		//  TimeTableTemplateDataCollection timeTableTemplatesRetrievedForEmployeeGroup1 =
		//      _timeTableTemplateBll.GetTimeTableTemplateDataCollectionForEmployeeGroup( testEmployeeGroup1.SysId );
		//  TimeTableTemplateDataCollection timeTableTemplatesRetrievedForEmployeeGroup2 =
		//      _timeTableTemplateBll.GetTimeTableTemplateDataCollectionForEmployeeGroup( testEmployeeGroup2.SysId );

		//  // Verify the retrieved data.
		//  TimeTableTemplateUnitTestHelper.AreEqual( timeTableTemplatesForEmployeeGroup1 , timeTableTemplatesRetrievedForEmployeeGroup1 );
		//  TimeTableTemplateUnitTestHelper.AreEqual( timeTableTemplatesForEmployeeGroup2 , timeTableTemplatesRetrievedForEmployeeGroup2 );
		//}

		/// <summary>
		/// Try to remove a single timetable purpose.
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTimeTableTemplateTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create a new purpose dataobject.
			TimeTableTemplateData timeTableTemplateToInsert =
				new TimeTableTemplateData( "Name" , "Description" , testEmployeeGroup.SysId );

			// Insert the new purpose.
			TimeTableTemplateDataCollection timeTableTemplateInserted =
				_timeTableTemplateBll.InsertTimeTableTemplateData(
					TimeTableTemplateDataCollection.FromSingleTimeTableTemplate( timeTableTemplateToInsert ) );

			// Delete the inserted purpose.
			_timeTableTemplateBll.RemoveTimeTableTemplateData( timeTableTemplateInserted );

			// Verify the deleted data.
			TimeTableTemplateDataCollection timeTableTemplatesRetrieved =
				_timeTableTemplateBll.GetTimeTableTemplateData();
			Assert.AreEqual( 0 , timeTableTemplatesRetrieved.Count );
			TimeTableTemplateUnitTestHelper.AreInLogDeletes( timeTableTemplateInserted );
		}

		/// <summary>
		/// Try to remove multiple timetable purposes.
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTimeTableTemplatesTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create new purpose dataobjects.
			TimeTableTemplateDataCollection timeTableTemplatesToInsert = new TimeTableTemplateDataCollection();
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_1" , "Description_1" , testEmployeeGroup.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_2" , "Description_2" , testEmployeeGroup.SysId ) );
			timeTableTemplatesToInsert.Add( new TimeTableTemplateData( "Name_3" , "Description_3" , testEmployeeGroup.SysId ) );

			// Insert the new purpose.
			TimeTableTemplateDataCollection timeTableTemplateInserted =
				_timeTableTemplateBll.InsertTimeTableTemplateData( timeTableTemplatesToInsert );

			// Delete the inserted purpose.
			_timeTableTemplateBll.RemoveTimeTableTemplateData( timeTableTemplateInserted );

			// Verify the deleted data.
			TimeTableTemplateDataCollection timeTableTemplatesRetrieved =
				_timeTableTemplateBll.GetTimeTableTemplateData();
			Assert.AreEqual( 0 , timeTableTemplatesRetrieved.Count );
			TimeTableTemplateUnitTestHelper.AreInLogDeletes( timeTableTemplateInserted );
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
