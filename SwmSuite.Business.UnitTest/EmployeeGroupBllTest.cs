using System;
using System.Collections.Generic;

using System.Text;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.UnitTest {
	
	/// <summary>
	///This is a test class for EmployeeGroupBllTest and is intended
	///to contain all EmployeeGroupBllTest Unit Tests
	///</summary>
	[TestClass()]
	public class EmployeeGroupBllTest : IDisposable {

		private TestContext testContextInstance;

		private TransactionScope mainScope;


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

		#region Additional test attributes

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
			mainScope.Dispose();
		}

		#endregion

		/// <summary>
		///A test for EmployeeGroupAvailability.
		///</summary>
		[TestMethod]
		public void Crud_EmployeeGroupAvailabilityTest() {
			EmployeeGroupBll bll = new EmployeeGroupBll();
			Assert.IsFalse( bll.EmployeeGroupsAvailable() );
			EmployeeGroupData employeeGroup = new EmployeeGroupData( "Group" , "GroupDescription" , true );
			EmployeeGroupDataCollection employeeGroups = new EmployeeGroupDataCollection();
			employeeGroups.Add( employeeGroup );
			bll.InsertEmployeeGroupData( employeeGroups );
			Assert.IsTrue( bll.EmployeeGroupsAvailable() );
		}

		/// <summary>
		///A test for InsertEmployeeGroups (insert a single employeeGroup).
		///</summary>
		[TestMethod]
		public void Crud_InsertEmployeeGroupTest() {
			EmployeeGroupBll bll = new EmployeeGroupBll();
			EmployeeGroupData employeeGroup = new EmployeeGroupData( "Group" , "GroupDescription" , true );
			EmployeeGroupDataCollection employeeGroups = new EmployeeGroupDataCollection();
			employeeGroups.Add( employeeGroup );
			bll.InsertEmployeeGroupData( employeeGroups );
			EmployeeGroupDataCollection employeeGroupsResult = bll.GetEmployeeGroupData();
			Assert.AreEqual( employeeGroups.Count , employeeGroupsResult.Count );
			foreach( EmployeeGroupData e in employeeGroups ) {
				Assert.AreEqual( e.Name , employeeGroupsResult[employeeGroups.IndexOf( e )].Name );
			}
		}

		/// <summary>
		///A test for InsertEmployeeGroups (insert multiple employeeGroups).
		///</summary>
		[TestMethod]
		public void Crud_InsertEmployeeGroupsTest() {
			EmployeeGroupBll bll = new EmployeeGroupBll();
			EmployeeGroupData employeeGroup1 = new EmployeeGroupData( "Group 1" , "GroupDescription 1" , true );
			EmployeeGroupData employeeGroup2 = new EmployeeGroupData( "Group 2" , "GroupDescription 2" , true );
			EmployeeGroupDataCollection employeeGroups = new EmployeeGroupDataCollection();
			employeeGroups.Add( employeeGroup1 );
			employeeGroups.Add( employeeGroup2 );
			bll.InsertEmployeeGroupData( employeeGroups );
			EmployeeGroupDataCollection employeeGroupsResult = bll.GetEmployeeGroupData();
			Assert.AreEqual( employeeGroups.Count , employeeGroupsResult.Count );
			foreach( EmployeeGroupData e in employeeGroups ) {
				Assert.AreEqual( e.Name , employeeGroupsResult[employeeGroups.IndexOf( e )].Name );
			}
		}

		/// <summary>
		///A test for UpdateEmployeeGroups (update a single employeeGroup).
		///</summary>
		[TestMethod]
		public void Crud_UpdateEmployeeGroupTest() {
			EmployeeGroupBll bll = new EmployeeGroupBll();
			EmployeeGroupData employeeGroup = new EmployeeGroupData( "Group" , "GroupDescription" , true );
			EmployeeGroupDataCollection employeeGroups = new EmployeeGroupDataCollection();
			employeeGroups.Add( employeeGroup );
			bll.InsertEmployeeGroupData( employeeGroups );
			EmployeeGroupDataCollection employeeGroupsToUpdate = bll.GetEmployeeGroupData();
			foreach( EmployeeGroupData e in employeeGroupsToUpdate ) {
				e.Name += "-EDITED";
			}
			bll.UpdateEmployeeGroupData( employeeGroupsToUpdate );
			EmployeeGroupDataCollection employeeGroupsResult = bll.GetEmployeeGroupData();
			Assert.AreEqual( employeeGroups.Count , employeeGroupsResult.Count );
			foreach( EmployeeGroupData e in employeeGroupsToUpdate ) {
				Assert.AreEqual( e.Name , employeeGroupsResult[employeeGroupsToUpdate.IndexOf( e )].Name );
			}
		}

		/// <summary>
		///A test for UpdateEmployeeGroups (update multiple employeeGroups).
		///</summary>
		[TestMethod]
		public void Crud_UpdateEmployeeGroupsTest() {
			EmployeeGroupBll bll = new EmployeeGroupBll();
			EmployeeGroupData employeeGroup1 = new EmployeeGroupData( "Group 1" , "GroupDescription 1" , true );
			EmployeeGroupData employeeGroup2 = new EmployeeGroupData( "Group 2" , "GroupDescription 2" , true );
			EmployeeGroupDataCollection employeeGroups = new EmployeeGroupDataCollection();
			employeeGroups.Add( employeeGroup1 );
			employeeGroups.Add( employeeGroup2 );
			bll.InsertEmployeeGroupData( employeeGroups );
			EmployeeGroupDataCollection employeeGroupsToUpdate = bll.GetEmployeeGroupData();
			foreach( EmployeeGroupData e in employeeGroupsToUpdate ) {
				e.Name += "-EDITED";
			}
			bll.UpdateEmployeeGroupData( employeeGroupsToUpdate );
			EmployeeGroupDataCollection employeeGroupsResult = bll.GetEmployeeGroupData();
			Assert.AreEqual( employeeGroups.Count , employeeGroupsResult.Count );
			foreach( EmployeeGroupData e in employeeGroupsToUpdate ) {
				Assert.AreEqual( e.Name , employeeGroupsResult[employeeGroupsToUpdate.IndexOf( e )].Name );
			}
		}

		/// <summary>
		///A test for RemoveEmployeeGroups (remove a single employeeGroup).
		///</summary>
		[TestMethod]
		public void Crud_RemoveEmployeeGroupTest() {
			EmployeeGroupBll bll = new EmployeeGroupBll();
			EmployeeGroupData employeeGroup = new EmployeeGroupData( "Group" , "GroupDescription" , true );
			EmployeeGroupDataCollection employeeGroups = new EmployeeGroupDataCollection();
			employeeGroups.Add( employeeGroup );
			bll.InsertEmployeeGroupData( employeeGroups );
			EmployeeGroupDataCollection employeeGroupsToRemove = bll.GetEmployeeGroupData();
			bll.RemoveEmployeeGroupData( employeeGroupsToRemove );
			EmployeeGroupDataCollection employeeGroupsResult = bll.GetEmployeeGroupData();
			Assert.AreEqual( 0 , employeeGroupsResult.Count );

			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( employeeGroups.Count , logDeletes.Count );
		}

		/// <summary>
		///A test for RemoveEmployeeGroups (remove multiple employeeGroups).
		///</summary>
		[TestMethod]
		public void Crud_RemoveEmployeeGroupsTest() {
			EmployeeGroupBll bll = new EmployeeGroupBll();
			EmployeeGroupData employeeGroup1 = new EmployeeGroupData( "Group 1" , "GroupDescription 1" , true );
			EmployeeGroupData employeeGroup2 = new EmployeeGroupData( "Group 2" , "GroupDescription 2" , true );
			EmployeeGroupDataCollection employeeGroups = new EmployeeGroupDataCollection();
			employeeGroups.Add( employeeGroup1 );
			employeeGroups.Add( employeeGroup2 );
			bll.InsertEmployeeGroupData( employeeGroups );
			EmployeeGroupDataCollection employeeGroupsToRemove = bll.GetEmployeeGroupData();
			bll.RemoveEmployeeGroupData( employeeGroupsToRemove );
			EmployeeGroupDataCollection employeeGroupsResult = bll.GetEmployeeGroupData();
			Assert.AreEqual( 0 , employeeGroupsResult.Count );

			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( employeeGroups.Count , logDeletes.Count );
		}

		#region -_ Helper Methods _-

		public static EmployeeGroupDataCollection GetEmployeeGroupTestData(){
			EmployeeGroupBll bll = new EmployeeGroupBll();
			EmployeeGroupData newEmployeeGroup = new EmployeeGroupData( "Test" , "Test Description" , true );
			return bll.InsertEmployeeGroupData( EmployeeGroupDataCollection.FromSingleEmployeeGroup( newEmployeeGroup ) );
		}

		#endregion

		#region IDisposable Members

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
