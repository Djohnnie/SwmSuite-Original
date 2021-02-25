using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Framework;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the TimeTableEntryDataBll methods.
	/// </summary>
	[TestClass()]
	public class TimeTableEntryDataBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private TimeTableEntryBll _timeTableEntryBll = new TimeTableEntryBll();

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

		[TestMethod]
		public void Crud_InsertTimeTableEntryTest() {
			// Get employee testdata.
			EmployeeData testEmployeeData = EmployeeUnitTestHelper.GetEmployeeTestData();

			// Get timetable purpose testdata.
			TimeTablePurposeData testTimeTablePurposeData =
				TimeTablePurposeUnitTestHelper.GetTimeTablePurposeTestData();

			// Create a new timetable entry.
			TimeTableEntryData timeTableEntryData = new TimeTableEntryData(
				DateTime.Today ,
				testEmployeeData.SysId ,
				DateTime.Today.FromTime( 8 , 45 ) ,
				DateTime.Today.FromTime( 17 , 15 ) ,
				testTimeTablePurposeData.SysId );

			// Insert the new timetable entry.
			TimeTableEntryDataCollection timeTableEntryDataInserted =
				_timeTableEntryBll.InsertTimeTableEntryDataCollection(
					TimeTableEntryDataCollection.FromSingleTimeTableEntry( timeTableEntryData ) );

			// Verify the inserted timetable entry.
			TimeTableEntryDataUnitTestHelper.AreEqual(
				TimeTableEntryDataCollection.FromSingleTimeTableEntry( timeTableEntryData ) , timeTableEntryDataInserted );
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
