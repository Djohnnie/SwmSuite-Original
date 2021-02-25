using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.DataAccess.Sql.SqlHelper;
using SwmSuite.Business;
using System.Globalization;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {
	
	public sealed class EmployeeGroupUnitTestHelper {
		
		public static void AreEqual( EmployeeGroupDataCollection expected , EmployeeGroupDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " employeeGroups expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " employeeGroups actual!" );
			// Test individual alerts.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].Name , actual[i].Name , "UT: expected EmployeeGroup.Name (" + expected[i].Name.ToString( CultureInfo.InvariantCulture ) + ") <> actual EmployeeGroup.Name (" + actual[i].Name.ToString( CultureInfo.InvariantCulture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( EmployeeGroupDataCollection employeeGroups ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , employeeGroups.Count , "UT: " + employeeGroups.Count.ToString( CultureInfo.InvariantCulture ) + " employeeGroups expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " employeeGroups found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new EmployeeGroupSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( employeeGroups[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateEmployeeGroups( EmployeeGroupDataCollection employeeGroups ) {
			foreach( EmployeeGroupData employeeGroup in employeeGroups ) {
				employeeGroup.Name = employeeGroup.Name + " -> EDITED!";
			}
		}

		public static EmployeeGroupData GetEmployeeGroupTestData() {
			EmployeeGroupBll bll = new EmployeeGroupBll();
			EmployeeGroupData employeeGroup = new EmployeeGroupData( "EmployeeGroup" , "EmployeeGroupDescription" , true );
			EmployeeGroupDataCollection employeeGroups = EmployeeGroupDataCollection.FromSingleEmployeeGroup( employeeGroup );
			EmployeeGroupDataCollection employeeGroupsResult = 
				bll.InsertEmployeeGroupData( employeeGroups );
			return employeeGroupsResult[0];
		}

		public static EmployeeGroupDataCollection GetEmployeeGroupsTestData() {
			EmployeeGroupBll bll = new EmployeeGroupBll();
			EmployeeGroupDataCollection employeeGroups = new EmployeeGroupDataCollection();
			for( int i = 1 ; i < 6 ; i++ ) {
				employeeGroups.Add( new EmployeeGroupData( "Name " + i , "Description " + i , true ) );
			}
			EmployeeGroupDataCollection employeeGroupsResult = 
				bll.InsertEmployeeGroupData( employeeGroups );
			return employeeGroupsResult;
		}

		public static EmployeeGroup GetTestEmployeeGroup() {
			EmployeeGroupBll bll = new EmployeeGroupBll();
			EmployeeGroup employeeGroupToCreate = new EmployeeGroup();
			employeeGroupToCreate.Name = "TestGroup";
			employeeGroupToCreate.Description = "TestGroup Description";
			EmployeeGroup employeeGroupToReturn =
				bll.CreateEmployeeGroup( employeeGroupToCreate );
			Assert.AreEqual( employeeGroupToCreate.Name , employeeGroupToReturn.Name );
			Assert.AreEqual( employeeGroupToCreate.Description , employeeGroupToReturn.Description );
			return employeeGroupToReturn;
		}

		private EmployeeGroupUnitTestHelper() {
		}

	}

}
