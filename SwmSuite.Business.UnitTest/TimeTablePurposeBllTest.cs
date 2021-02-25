using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.DataObjects;
using System.Drawing;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the TimeTablePurposeDataBll methods.
	/// </summary>
	[TestClass()]
	public class TimeTablePurposeBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private TimeTablePurposeBll _timeTablePurposeBll = new TimeTablePurposeBll();

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
		public void Crud_InsertTimeTablePurposeTest(){
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			
			// Create a new purpose dataobject.
			TimeTablePurposeData timeTablePurposeToInsert = 
				new TimeTablePurposeData( testEmployeeGroup.SysId , "Purspose" , Color.Green.ToArgb() );

			// Insert the new purpose.
			TimeTablePurposeDataCollection timeTablePurposeInserted =
				_timeTablePurposeBll.InsertTimeTablePurposeDataCollection( 
					TimeTablePurposeDataCollection.FromSingleTimeTablePurpose( timeTablePurposeToInsert ) );

			// Verify the inserted data.
			TimeTablePurposeUnitTestHelper.AreEqual( 
				TimeTablePurposeDataCollection.FromSingleTimeTablePurpose( timeTablePurposeToInsert ) , timeTablePurposeInserted );
		}

		/// <summary>
		/// Try to insert multiple timetable purposes.
		/// </summary>
		[TestMethod]
		public void Crud_InsertTimeTablePurposesTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create new purpose dataobjects.
			TimeTablePurposeDataCollection timeTablePurposesToInsert = new TimeTablePurposeDataCollection();
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup.SysId , "Purspose 1" , Color.Red.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup.SysId , "Purspose 2" , Color.Green.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup.SysId , "Purspose 3" , Color.Blue.ToArgb() ) );

			// Insert the new purpose.
			TimeTablePurposeDataCollection timeTablePurposeInserted =
				_timeTablePurposeBll.InsertTimeTablePurposeDataCollection( timeTablePurposesToInsert );

			// Verify the inserted data.
			TimeTablePurposeUnitTestHelper.AreEqual( timeTablePurposesToInsert , timeTablePurposeInserted );
		}

		/// <summary>
		/// Try to update a single timetable purpose.
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTimeTablePurposeTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup1 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData testEmployeeGroup2 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create a new purpose dataobject.
			TimeTablePurposeData timeTablePurposeToInsert =
				new TimeTablePurposeData( testEmployeeGroup1.SysId , "Purspose" , Color.Green.ToArgb() );

			// Insert the new purpose.
			TimeTablePurposeDataCollection timeTablePurposeInserted =
				_timeTablePurposeBll.InsertTimeTablePurposeDataCollection(
					TimeTablePurposeDataCollection.FromSingleTimeTablePurpose( timeTablePurposeToInsert ) );
			
			// Edit the purposes.
			TimeTablePurposeUnitTestHelper.UpdateTimeTablePurposeDataCollection( timeTablePurposeInserted );
			foreach( TimeTablePurposeData timeTablePurposeData in timeTablePurposeInserted ) {
				timeTablePurposeData.EmployeeGroupSysId = testEmployeeGroup2.SysId;
			}

			// Update the edited purpose.
			TimeTablePurposeDataCollection timeTablePurposeUpdated =
				_timeTablePurposeBll.UpdateTimeTablePurposeDataCollection( timeTablePurposeInserted );

			// Verify the inserted data.
			TimeTablePurposeUnitTestHelper.AreEqual( timeTablePurposeInserted , timeTablePurposeUpdated );
		}

		/// <summary>
		/// Try to update multiple timetable purposes.
		/// </summary>
		[TestMethod]
		public void Crud_UpdateTimeTablePurposesTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup1 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData testEmployeeGroup2 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create new purpose dataobjects.
			TimeTablePurposeDataCollection timeTablePurposesToInsert = new TimeTablePurposeDataCollection();
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup1.SysId , "Purspose 1" , Color.Red.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup1.SysId , "Purspose 2" , Color.Green.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup1.SysId , "Purspose 3" , Color.Blue.ToArgb() ) );

			// Insert the new purpose.
			TimeTablePurposeDataCollection timeTablePurposeInserted =
				_timeTablePurposeBll.InsertTimeTablePurposeDataCollection( timeTablePurposesToInsert );

			// Edit the purposes.
			TimeTablePurposeUnitTestHelper.UpdateTimeTablePurposeDataCollection( timeTablePurposeInserted );
			foreach( TimeTablePurposeData timeTablePurposeData in timeTablePurposeInserted ) {
				timeTablePurposeData.EmployeeGroupSysId = testEmployeeGroup2.SysId;
			}

			// Update the edited purpose.
			TimeTablePurposeDataCollection timeTablePurposeUpdated =
				_timeTablePurposeBll.UpdateTimeTablePurposeDataCollection( timeTablePurposeInserted );

			// Verify the inserted data.
			TimeTablePurposeUnitTestHelper.AreEqual( timeTablePurposeInserted , timeTablePurposeUpdated );
		}

		/// <summary>
		/// Try to get a single timetable purpose.
		/// </summary>
		[TestMethod]
		public void Crud_GetTimeTablePurposeTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create a new purpose dataobject.
			TimeTablePurposeData timeTablePurposeToInsert =
				new TimeTablePurposeData( testEmployeeGroup.SysId , "Purspose" , Color.Green.ToArgb() );

			// Insert the new purpose.
			TimeTablePurposeDataCollection timeTablePurposeInserted =
				_timeTablePurposeBll.InsertTimeTablePurposeDataCollection(
					TimeTablePurposeDataCollection.FromSingleTimeTablePurpose( timeTablePurposeToInsert ) );

			foreach( TimeTablePurposeData timeTablePurposeData in timeTablePurposeInserted ) {
				TimeTablePurposeDataCollection timeTablePurposesRetrieved =
					_timeTablePurposeBll.GetTimeTablePurposeDataBySysId( timeTablePurposeData.SysId );
				// Verify the inserted data.
				TimeTablePurposeUnitTestHelper.AreEqual(
					TimeTablePurposeDataCollection.FromSingleTimeTablePurpose( timeTablePurposeData ) , timeTablePurposesRetrieved );
			}
		}

		/// <summary>
		/// Try to get all time table purposes.
		/// </summary>
		[TestMethod]
		public void Crud_GetTimeTablePurposesTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup1 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData testEmployeeGroup2 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create new purpose dataobjects.
			TimeTablePurposeDataCollection timeTablePurposesToInsert = new TimeTablePurposeDataCollection();
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup1.SysId , "Purspose 1" , Color.Red.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup1.SysId , "Purspose 2" , Color.Green.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup1.SysId , "Purspose 3" , Color.Blue.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup2.SysId , "Purspose 4" , Color.DarkRed.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup2.SysId , "Purspose 5" , Color.DarkGreen.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup2.SysId , "Purspose 6" , Color.DarkBlue.ToArgb() ) );

			// Insert the new purpose.
			TimeTablePurposeDataCollection timeTablePurposeInserted =
				_timeTablePurposeBll.InsertTimeTablePurposeDataCollection( timeTablePurposesToInsert );

			// Get the purposes from the database.
			TimeTablePurposeDataCollection timeTablePurposesRetrieved =
					_timeTablePurposeBll.GetTimeTablePurposeDataCollection();

			// Verify the retrieved data.
			TimeTablePurposeUnitTestHelper.AreEqual( timeTablePurposesToInsert , timeTablePurposesRetrieved );
		}

		/// <summary>
		/// Try to get all timetable purposes for a specific employeegroup.
		/// </summary>
		[TestMethod]
		public void Crud_GetTimeTablePurposesForEmployeeGroupTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup1 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeGroupData testEmployeeGroup2 =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create new purpose dataobjects.
			TimeTablePurposeDataCollection timeTablePurposesToInsert = new TimeTablePurposeDataCollection();
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup1.SysId , "Purspose 1" , Color.Red.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup1.SysId , "Purspose 2" , Color.Green.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup1.SysId , "Purspose 3" , Color.Blue.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup2.SysId , "Purspose 4" , Color.DarkRed.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup2.SysId , "Purspose 5" , Color.DarkGreen.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup2.SysId , "Purspose 6" , Color.DarkBlue.ToArgb() ) );

			// Split the purposes by employeegroup for verifying.
			TimeTablePurposeDataCollection timeTablePurposesForEmployeeGroup1 = new TimeTablePurposeDataCollection();
			timeTablePurposesForEmployeeGroup1.Add( timeTablePurposesToInsert[0] );
			timeTablePurposesForEmployeeGroup1.Add( timeTablePurposesToInsert[1] );
			timeTablePurposesForEmployeeGroup1.Add( timeTablePurposesToInsert[2] );
			TimeTablePurposeDataCollection timeTablePurposesForEmployeeGroup2 = new TimeTablePurposeDataCollection();
			timeTablePurposesForEmployeeGroup2.Add( timeTablePurposesToInsert[3] );
			timeTablePurposesForEmployeeGroup2.Add( timeTablePurposesToInsert[4] );
			timeTablePurposesForEmployeeGroup2.Add( timeTablePurposesToInsert[5] );

			// Insert the new purpose.
			TimeTablePurposeDataCollection timeTablePurposeInserted =
				_timeTablePurposeBll.InsertTimeTablePurposeDataCollection( timeTablePurposesToInsert );

			// Get the purposes from the database.
			TimeTablePurposeDataCollection timeTablePurposesRetrievedForEmployeeGroup1 =
					_timeTablePurposeBll.GetTimeTablePurposeDataCollectionForEmployeeGroup( testEmployeeGroup1.SysId );
			TimeTablePurposeDataCollection timeTablePurposesRetrievedForEmployeeGroup2 =
					_timeTablePurposeBll.GetTimeTablePurposeDataCollectionForEmployeeGroup( testEmployeeGroup2.SysId );

			// Verify the retrieved data.
			TimeTablePurposeUnitTestHelper.AreEqual( timeTablePurposesForEmployeeGroup1 , timeTablePurposesRetrievedForEmployeeGroup1 );
			TimeTablePurposeUnitTestHelper.AreEqual( timeTablePurposesForEmployeeGroup2 , timeTablePurposesRetrievedForEmployeeGroup2 );
		}

		/// <summary>
		/// Try to remove a single timetable purpose.
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTimeTablePurposeTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create a new purpose dataobject.
			TimeTablePurposeData timeTablePurposeToInsert =
				new TimeTablePurposeData( testEmployeeGroup.SysId , "Purspose" , Color.Green.ToArgb() );

			// Insert the new purpose.
			TimeTablePurposeDataCollection timeTablePurposeInserted =
				_timeTablePurposeBll.InsertTimeTablePurposeDataCollection(
					TimeTablePurposeDataCollection.FromSingleTimeTablePurpose( timeTablePurposeToInsert ) );

			// Delete the inserted purpose.
			_timeTablePurposeBll.RemoveTimeTablePurposeDataCollection( timeTablePurposeInserted );

			// Verify the deleted data.
			TimeTablePurposeDataCollection timeTablePurposesRetrieved =
				_timeTablePurposeBll.GetTimeTablePurposeDataCollection();
			Assert.AreEqual( 0 , timeTablePurposesRetrieved.Count );
			TimeTablePurposeUnitTestHelper.AreInLogDeletes( timeTablePurposeInserted );
		}

		/// <summary>
		/// Try to remove multiple timetable purposes.
		/// </summary>
		[TestMethod]
		public void Crud_RemoveTimeTablePurposesTest() {
			// Get a test employeegroup.
			EmployeeGroupData testEmployeeGroup =
				EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();

			// Create new purpose dataobjects.
			TimeTablePurposeDataCollection timeTablePurposesToInsert = new TimeTablePurposeDataCollection();
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup.SysId , "Purspose 1" , Color.Red.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup.SysId , "Purspose 2" , Color.Green.ToArgb() ) );
			timeTablePurposesToInsert.Add( new TimeTablePurposeData( testEmployeeGroup.SysId , "Purspose 3" , Color.Blue.ToArgb() ) );

			// Insert the new purpose.
			TimeTablePurposeDataCollection timeTablePurposeInserted =
				_timeTablePurposeBll.InsertTimeTablePurposeDataCollection( timeTablePurposesToInsert );

			// Delete the inserted purpose.
			_timeTablePurposeBll.RemoveTimeTablePurposeDataCollection( timeTablePurposeInserted );

			// Verify the deleted data.
			TimeTablePurposeDataCollection timeTablePurposesRetrieved =
				_timeTablePurposeBll.GetTimeTablePurposeDataCollection();
			Assert.AreEqual( 0 , timeTablePurposesRetrieved.Count );
			TimeTablePurposeUnitTestHelper.AreInLogDeletes( timeTablePurposeInserted );
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
