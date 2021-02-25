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
	/// Unittestclass to test the TimeTableTemplateEntryBll methods.
	/// </summary>
	[TestClass()]
	public class TimeTableTemplateEntryBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private TimeTableTemplateEntryBll _timeTableTemplateEntryBll = new TimeTableTemplateEntryBll();

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
		public void Crud_InsertTimeTableTemplateEntryTest() {
			// Get timetable template testdata.
			TimeTableTemplateData testTimeTableTemplateData =
				TimeTableTemplateUnitTestHelper.GetTimeTableTemplateTestData();

			// Get timetable purpose testdata.
			TimeTablePurposeData testTimeTablePurposeData =
				TimeTablePurposeUnitTestHelper.GetTimeTablePurposeTestData();

			// Create a new timetable entry.
			TimeTableTemplateEntryData timeTableTemplateEntryData = new TimeTableTemplateEntryData(
				DateTime.Today ,
				testTimeTableTemplateData.SysId ,
				DateTime.Today.FromTime( 8 , 45 ) ,
				DateTime.Today.FromTime( 17 , 15 ) ,
				testTimeTablePurposeData.SysId );

			// Insert the new timetable entry.
			TimeTableTemplateEntryDataCollection timeTableEntryDataInserted =
				_timeTableTemplateEntryBll.InsertTimeTableTemplateEntryData(
					TimeTableTemplateEntryDataCollection.FromSingleTimeTableTemplateEntry( timeTableTemplateEntryData ) );

			// Verify the inserted timetable entry.
			TimeTableTemplateEntryUnitTestHelper.AreEqual(
				TimeTableTemplateEntryDataCollection.FromSingleTimeTableTemplateEntry( timeTableTemplateEntryData ) , timeTableEntryDataInserted );
		}

		[TestMethod]
		public void Crud_InsertTimeTableTemplateEntriesTest() {
			// Get timetable template testdata.
			TimeTableTemplateData testTimeTableTemplateData =
				TimeTableTemplateUnitTestHelper.GetTimeTableTemplateTestData();

			// Get timetable purpose testdata.
			TimeTablePurposeData testTimeTablePurposeData =
				TimeTablePurposeUnitTestHelper.GetTimeTablePurposeTestData();

			TimeTableTemplateEntryDataCollection timeTableTemplateEntryDataToInsert = new TimeTableTemplateEntryDataCollection();
			timeTableTemplateEntryDataToInsert.Add( new TimeTableTemplateEntryData(
				DateTime.Today ,
				testTimeTableTemplateData.SysId ,
				DateTime.Today.FromTime( 8 , 45 ) ,
				DateTime.Today.FromTime( 17 , 15 ) ,
				testTimeTablePurposeData.SysId ) );
			timeTableTemplateEntryDataToInsert.Add( new TimeTableTemplateEntryData(
				DateTime.Today.AddDays( 1 ) ,
				testTimeTableTemplateData.SysId ,
				DateTime.Today.FromTime( 8 , 45 ) ,
				DateTime.Today.FromTime( 17 , 15 ) ,
				testTimeTablePurposeData.SysId ) );
			timeTableTemplateEntryDataToInsert.Add( new TimeTableTemplateEntryData(
				DateTime.Today.AddDays( 2 ) ,
				testTimeTableTemplateData.SysId ,
				DateTime.Today.FromTime( 8 , 45 ) ,
				DateTime.Today.FromTime( 17 , 15 ) ,
				testTimeTablePurposeData.SysId ) );

			// Insert the new timetable entry.
			TimeTableTemplateEntryDataCollection timeTableEntryDataInserted =
				_timeTableTemplateEntryBll.InsertTimeTableTemplateEntryData( timeTableTemplateEntryDataToInsert );

			// Verify the inserted timetable entry.
			TimeTableTemplateEntryUnitTestHelper.AreEqual(
				timeTableTemplateEntryDataToInsert , timeTableEntryDataInserted );
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
