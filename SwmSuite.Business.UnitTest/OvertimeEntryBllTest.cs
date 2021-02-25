using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the OvertimeEntryDataBll methods.
	/// </summary>
	[TestClass()]
	public class OvertimeEntryBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private OvertimeEntryBll _overtimeEntryBll = new OvertimeEntryBll();

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
		/// A test for InsertOvertimeEntrys (insert a single overtimeEntry).
		/// </summary>
		[TestMethod]
		public void Crud_InsertOvertimeEntryTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testCommissioner = EmployeeUnitTestHelper.GetEmployeeTestData();
			OvertimeEntryDataCollection overtimeEntrys =
				OvertimeEntryDataCollection.FromSingleOvertimeEntry(
				new OvertimeEntryData( "Description" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 10 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			_overtimeEntryBll.InsertOvertimeEntryData( overtimeEntrys );
			OvertimeEntryDataCollection overtimeEntrysResult = _overtimeEntryBll.GetOvertimeEntryData();
			OvertimeEntryUnitTestHelper.AreEqual( overtimeEntrys , overtimeEntrysResult );
		}

		/// <summary>
		/// A test for InsertOvertimeEntrys (insert multiple overtimeEntrys).
		/// </summary>
		[TestMethod]
		public void Crud_InsertOvertimeEntriesTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testCommissioner = EmployeeUnitTestHelper.GetEmployeeTestData();
			OvertimeEntryDataCollection overtimeEntrys = new OvertimeEntryDataCollection();
			overtimeEntrys.Add( new OvertimeEntryData( "Description1" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 10 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			overtimeEntrys.Add( new OvertimeEntryData( "Description2" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 12 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			overtimeEntrys.Add( new OvertimeEntryData( "Description3" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 12 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 13 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			_overtimeEntryBll.InsertOvertimeEntryData( overtimeEntrys );
			OvertimeEntryDataCollection overtimeEntrysResult = _overtimeEntryBll.GetOvertimeEntryData();
			OvertimeEntryUnitTestHelper.AreEqual( overtimeEntrys , overtimeEntrysResult );
		}

		/// <summary>
		/// A test for UpdateOvertimeEntrys (update a single overtimeEntry).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateOvertimeEntryTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testCommissioner = EmployeeUnitTestHelper.GetEmployeeTestData();
			OvertimeEntryDataCollection overtimeEntrys =
				OvertimeEntryDataCollection.FromSingleOvertimeEntry( new OvertimeEntryData( "Description" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 10 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			_overtimeEntryBll.InsertOvertimeEntryData( overtimeEntrys );
			OvertimeEntryDataCollection overtimeEntrysToUpdate = _overtimeEntryBll.GetOvertimeEntryData();
			OvertimeEntryUnitTestHelper.UpdateOvertimeEntryData( overtimeEntrysToUpdate );
			_overtimeEntryBll.UpdateOvertimeEntryData( overtimeEntrysToUpdate );
			OvertimeEntryDataCollection overtimeEntrysResult = _overtimeEntryBll.GetOvertimeEntryData();
			OvertimeEntryUnitTestHelper.AreEqual( overtimeEntrysToUpdate , overtimeEntrysResult );
		}

		/// <summary>
		/// A test for UpdateOvertimeEntrys (update multiple overtimeEntrys).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateOvertimeEntriesTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testCommissioner = EmployeeUnitTestHelper.GetEmployeeTestData();
			OvertimeEntryDataCollection overtimeEntrys = new OvertimeEntryDataCollection();
			overtimeEntrys.Add( new OvertimeEntryData( "Description1" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 10 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			overtimeEntrys.Add( new OvertimeEntryData( "Description2" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 12 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			overtimeEntrys.Add( new OvertimeEntryData( "Description3" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 12 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 13 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			_overtimeEntryBll.InsertOvertimeEntryData( overtimeEntrys );
			OvertimeEntryDataCollection overtimeEntrysToUpdate = _overtimeEntryBll.GetOvertimeEntryData();
			OvertimeEntryUnitTestHelper.UpdateOvertimeEntryData( overtimeEntrysToUpdate );
			_overtimeEntryBll.UpdateOvertimeEntryData( overtimeEntrysToUpdate );
			OvertimeEntryDataCollection overtimeEntrysResult = _overtimeEntryBll.GetOvertimeEntryData();
			OvertimeEntryUnitTestHelper.AreEqual( overtimeEntrysToUpdate , overtimeEntrysResult );
		}

		/// <summary>
		/// A test for RemoveOvertimeEntrys (remove a single overtimeEntry).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveOvertimeEntryTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testCommissioner = EmployeeUnitTestHelper.GetEmployeeTestData();
			OvertimeEntryDataCollection overtimeEntrys =
				OvertimeEntryDataCollection.FromSingleOvertimeEntry( new OvertimeEntryData( "Description" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 10 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			_overtimeEntryBll.InsertOvertimeEntryData( overtimeEntrys );
			OvertimeEntryDataCollection overtimeEntrysToRemove = _overtimeEntryBll.GetOvertimeEntryData();
			_overtimeEntryBll.RemoveOvertimeEntryData( overtimeEntrysToRemove );
			OvertimeEntryDataCollection overtimeEntrysResult = _overtimeEntryBll.GetOvertimeEntryData();
			Assert.AreEqual( 0 , overtimeEntrysResult.Count , "The overtimeEntrys should be removed!" );
			OvertimeEntryUnitTestHelper.AreInLogDeletes( overtimeEntrysToRemove );
		}

		/// <summary>
		/// A test for RemoveOvertimeEntrys (remove multiple overtimeEntrys).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveOvertimeEntrysTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testCommissioner = EmployeeUnitTestHelper.GetEmployeeTestData();
			OvertimeEntryDataCollection overtimeEntrys = new OvertimeEntryDataCollection();
			overtimeEntrys.Add( new OvertimeEntryData( "Description1" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 10 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			overtimeEntrys.Add( new OvertimeEntryData( "Description2" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 12 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			overtimeEntrys.Add( new OvertimeEntryData( "Description3" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 12 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 13 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			_overtimeEntryBll.InsertOvertimeEntryData( overtimeEntrys );
			OvertimeEntryDataCollection overtimeEntrysToRemove = _overtimeEntryBll.GetOvertimeEntryData();
			_overtimeEntryBll.RemoveOvertimeEntryData( overtimeEntrysToRemove );
			OvertimeEntryDataCollection overtimeEntrysResult = _overtimeEntryBll.GetOvertimeEntryData();
			Assert.AreEqual( 0 , overtimeEntrysResult.Count , "The overtimeEntrys should be removed!" );
			OvertimeEntryUnitTestHelper.AreInLogDeletes( overtimeEntrysToRemove );
		}

		/// <summary>
		/// A test for GetOvertimeEntryDataByEmployeeAndYear (get overtime entries by employee and year)
		/// </summary>
		[TestMethod]
		public void Crud_GetOvertimeEntryDataByEmployeeAndYearTest() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			EmployeeData testCommissioner = EmployeeUnitTestHelper.GetEmployeeTestData();
			OvertimeEntryDataCollection overtimeEntries = new OvertimeEntryDataCollection();
			overtimeEntries.Add( new OvertimeEntryData( "Description1" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 10 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			overtimeEntries.Add( new OvertimeEntryData( "Description2" ,
					new DateTime( DateTime.Today.Year + 1 , DateTime.Today.Month , DateTime.Today.Day , 11 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year + 1 , DateTime.Today.Month , DateTime.Today.Day , 12 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			overtimeEntries.Add( new OvertimeEntryData( "Description3" ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 12 , 0 , 0 ) ,
					new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , 13 , 0 , 0 ) ,
					testEmployee.SysId , OvertimeStatus.Pending , testCommissioner.SysId ) );
			_overtimeEntryBll.InsertOvertimeEntryData( overtimeEntries );
			OvertimeEntryDataCollection overtimeEntrysToUpdate = _overtimeEntryBll.GetOvertimeEntryDataByEmployeeAndYear( testEmployee.SysId , DateTime.Today.Year );
			Assert.AreEqual( 2 , overtimeEntrysToUpdate.Count );
			Assert.AreEqual( "Description1" , overtimeEntrysToUpdate[0].Description );
			Assert.AreEqual( "Description3" , overtimeEntrysToUpdate[1].Description );
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
