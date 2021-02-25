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
	/// Unittestclass to test the EmployeeSettingsBll methods.
	/// </summary>
	[TestClass()]
	public class EmployeeSettingsBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private EmployeeSettingsBll _employeeSettingsBll = new EmployeeSettingsBll();

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
		/// A test for InsertEmployeeSettings (insert a single employeeSettings).
		/// </summary>
		[TestMethod]
		public void Crud_InsertEmployeeSettingsTest() {
			EmployeeSettingsDataCollection employeeSettings =
				EmployeeSettingsDataCollection.FromSingleEmployeeSettings( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			_employeeSettingsBll.InsertEmployeeSettingsData( employeeSettings );
			EmployeeSettingsDataCollection employeeSettingsResult = _employeeSettingsBll.GetEmployeeSettingsData();
			EmployeeSettingsUnitTestHelper.AreEqual( employeeSettings , employeeSettingsResult );
		}

		/// <summary>
		/// A test for InsertEmployeeSettings (insert multiple employeeSettings).
		/// </summary>
		[TestMethod]
		public void Crud_InsertMultipleEmployeeSettingsTest() {
			EmployeeSettingsDataCollection employeeSettings = new EmployeeSettingsDataCollection();
			employeeSettings.Add( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			employeeSettings.Add( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			employeeSettings.Add( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			_employeeSettingsBll.InsertEmployeeSettingsData( employeeSettings );
			EmployeeSettingsDataCollection employeeSettingsResult = _employeeSettingsBll.GetEmployeeSettingsData();
			EmployeeSettingsUnitTestHelper.AreEqual( employeeSettings , employeeSettingsResult );
		}

		/// <summary>
		/// A test for UpdateEmployeeSettings (update a single employeeSettings).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateEmployeeSettingsTest() {
			EmployeeSettingsDataCollection employeeSettings =
				EmployeeSettingsDataCollection.FromSingleEmployeeSettings( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			_employeeSettingsBll.InsertEmployeeSettingsData( employeeSettings );
			EmployeeSettingsDataCollection employeeSettingsToUpdate = _employeeSettingsBll.GetEmployeeSettingsData();
			EmployeeSettingsUnitTestHelper.UpdateEmployeeSettings( employeeSettingsToUpdate );
			_employeeSettingsBll.UpdateEmployeeSettingsData( employeeSettingsToUpdate );
			EmployeeSettingsDataCollection employeeSettingsResult = _employeeSettingsBll.GetEmployeeSettingsData();
			EmployeeSettingsUnitTestHelper.AreEqual( employeeSettingsToUpdate , employeeSettingsResult );
		}

		/// <summary>
		/// A test for UpdateEmployeeSettings (update multiple employeeSettings).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateMultipleEmployeeSettingsTest() {
			EmployeeSettingsDataCollection employeeSettings = new EmployeeSettingsDataCollection();
			employeeSettings.Add( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			employeeSettings.Add( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			employeeSettings.Add( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			_employeeSettingsBll.InsertEmployeeSettingsData( employeeSettings );
			EmployeeSettingsDataCollection employeeSettingsToUpdate = _employeeSettingsBll.GetEmployeeSettingsData();
			EmployeeSettingsUnitTestHelper.UpdateEmployeeSettings( employeeSettingsToUpdate );
			_employeeSettingsBll.UpdateEmployeeSettingsData( employeeSettingsToUpdate );
			EmployeeSettingsDataCollection employeeSettingsResult = _employeeSettingsBll.GetEmployeeSettingsData();
			EmployeeSettingsUnitTestHelper.AreEqual( employeeSettingsToUpdate , employeeSettingsResult );
		}

		/// <summary>
		/// A test for RemoveEmployeeSettings (remove a single employeeSettings).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveEmployeeSettingsTest() {
			EmployeeSettingsDataCollection employeeSettings =
				EmployeeSettingsDataCollection.FromSingleEmployeeSettings( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			_employeeSettingsBll.InsertEmployeeSettingsData( employeeSettings );
			EmployeeSettingsDataCollection employeeSettingsToRemove = _employeeSettingsBll.GetEmployeeSettingsData();
			_employeeSettingsBll.RemoveEmployeeSettingsData( employeeSettingsToRemove );
			EmployeeSettingsDataCollection employeeSettingsResult = _employeeSettingsBll.GetEmployeeSettingsData();
			Assert.AreEqual( 0 , employeeSettingsResult.Count , "The employeeSettings should be removed!" );
			EmployeeSettingsUnitTestHelper.AreInLogDeletes( employeeSettingsToRemove );
		}

		/// <summary>
		/// A test for RemoveEmployeeSettings (remove multiple employeeSettings).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveMultipleEmployeeSettingsTest() {
			EmployeeSettingsDataCollection employeeSettings = new EmployeeSettingsDataCollection();
			employeeSettings.Add( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			employeeSettings.Add( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			employeeSettings.Add( EmployeeSettingsUnitTestHelper.GetEmployeeSettingsData() );
			_employeeSettingsBll.InsertEmployeeSettingsData( employeeSettings );
			EmployeeSettingsDataCollection employeeSettingsToRemove = _employeeSettingsBll.GetEmployeeSettingsData();
			_employeeSettingsBll.RemoveEmployeeSettingsData( employeeSettingsToRemove );
			EmployeeSettingsDataCollection employeeSettingsResult = _employeeSettingsBll.GetEmployeeSettingsData();
			Assert.AreEqual( 0 , employeeSettingsResult.Count , "The employeeSettings should be removed!" );
			EmployeeSettingsUnitTestHelper.AreInLogDeletes( employeeSettingsToRemove );
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
