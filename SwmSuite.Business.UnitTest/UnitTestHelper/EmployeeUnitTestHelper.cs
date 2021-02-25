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

	public sealed class EmployeeUnitTestHelper {

		public static void AreEqual( EmployeeDataCollection expected , EmployeeDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " employees expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " employees actual!" );
			// Test individual employees.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].UserSysId , actual[i].UserSysId , "UT: expected Employee.UserSysId (" + expected[i].UserSysId.ToString( ) + ") <> actual Employee.UserSysId (" + actual[i].UserSysId.ToString( ) + ")!" );
				Assert.AreEqual( expected[i].Name , actual[i].Name , "UT: expected Employee.Name (" + expected[i].Name + ") <> actual Employee.Name (" + actual[i].Name + ")!" );
				Assert.AreEqual( expected[i].FirstName , actual[i].FirstName , "UT: expected Employee.FirstName (" + expected[i].FirstName + ") <> actual Employee.FirstName (" + actual[i].FirstName + ")!" );
				//Assert.AreEqual( expected[i].AddressSysId , actual[i].AddressSysId , "UT: expected Employee.AddressSysId (" + expected[i].AddressSysId.ToString( ) + ") <> actual Employee.AddressSysId (" + actual[i].AddressSysId.ToString(  ) + ")!" );
				Assert.AreEqual( expected[i].Address , actual[i].Address , "UT: expected Employee.Address (" + expected[i].Address + ") <> actual Employee.Address (" + actual[i].Address + ")!" );
				Assert.AreEqual( expected[i].PrivatePhoneNumber , actual[i].PrivatePhoneNumber , "UT: expected Employee.PrivatePhoneNumber (" + expected[i].PrivatePhoneNumber + ") <> actual Employee.PrivatePhoneNumber (" + actual[i].PrivatePhoneNumber + ")!" );
				Assert.AreEqual( expected[i].WorkPhoneNumber , actual[i].WorkPhoneNumber , "UT: expected Employee.WorkPhoneNumber (" + expected[i].WorkPhoneNumber + ") <> actual Employee.WorkPhoneNumber (" + actual[i].WorkPhoneNumber + ")!" );
				Assert.AreEqual( expected[i].CellPhoneNumber , actual[i].CellPhoneNumber , "UT: expected Employee.CellPhoneNumber (" + expected[i].CellPhoneNumber + ") <> actual Employee.CellPhoneNumber (" + actual[i].CellPhoneNumber + ")!" );
				Assert.AreEqual( expected[i].EmailAddress1 , actual[i].EmailAddress1 , "UT: expected Employee.EmailAddress1 (" + expected[i].EmailAddress1 + ") <> actual Employee.EmailAddress1 (" + actual[i].EmailAddress1 + ")!" );
				Assert.AreEqual( expected[i].EmailAddress2 , actual[i].EmailAddress2 , "UT: expected Employee.EmailAddress2 (" + expected[i].EmailAddress2 + ") <> actual Employee.EmailAddress2 (" + actual[i].EmailAddress2 + ")!" );
				Assert.AreEqual( expected[i].EmailAddress3 , actual[i].EmailAddress3 , "UT: expected Employee.EmailAddress3 (" + expected[i].EmailAddress3 + ") <> actual Employee.EmailAddress3 (" + actual[i].EmailAddress3 + ")!" );
				Assert.AreEqual( expected[i].EmailAddress4 , actual[i].EmailAddress4 , "UT: expected Employee.EmailAddress4 (" + expected[i].EmailAddress4 + ") <> actual Employee.EmailAddress4 (" + actual[i].EmailAddress4 + ")!" );
				Assert.AreEqual( expected[i].EmailAddress5 , actual[i].EmailAddress5 , "UT: expected Employee.EmailAddress5 (" + expected[i].EmailAddress5 + ") <> actual Employee.EmailAddress5 (" + actual[i].EmailAddress5 + ")!" );
				Assert.AreEqual( expected[i].AvatarSysId , actual[i].AvatarSysId , "UT: expected Employee.AvatarSysId (" + expected[i].AvatarSysId.ToString(  ) + ") <> actual Employee.AvatarSysId (" + actual[i].AvatarSysId.ToString( ) + ")!" );
				Assert.AreEqual( expected[i].ApplicationSettingsSysId , actual[i].ApplicationSettingsSysId , "UT: expected Employee.ApplicationSettingsSysId (" + expected[i].ApplicationSettingsSysId.ToString( ) + ") <> actual Employee.ApplicationSettingsSysId (" + actual[i].ApplicationSettingsSysId.ToString(  ) + ")!" );
				Assert.AreEqual( expected[i].EmployeeGroupSysId , actual[i].EmployeeGroupSysId , "UT: expected Employee.EmployeeGroupSysId (" + expected[i].EmployeeGroupSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual Employee.EmployeeGroupSysId (" + actual[i].EmployeeGroupSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( EmployeeDataCollection employees ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , employees.Count , "UT: " + employees.Count.ToString( CultureInfo.InvariantCulture ) + " employees expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " employees found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new EmployeeSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( employees[logDeletes.IndexOf( ld )].ToString( ) , ld.Info );
			}
		}

		public static void UpdateEmployees( EmployeeDataCollection employees ) {
			foreach( EmployeeData employee in employees ) {
				employee.FirstName = employee.FirstName + " -> EDITED!";
				employee.Name = employee.Name + " -> EDITED!";
				employee.PrivatePhoneNumber += " -> EDITED!";
				employee.WorkPhoneNumber += " -> EDITED!";
				employee.CellPhoneNumber += " -> EDITED!";
				employee.EmailAddress1 += " -> EDITED!";
				employee.EmailAddress2 += " -> EDITED!";
				employee.EmailAddress3 += " -> EDITED!";
				employee.EmailAddress4 += " -> EDITED!";
				employee.EmailAddress5 += " -> EDITED!";
			}
		}

		public static EmployeeDataCollection GetEmployeesTestData() {
			EmployeeDataCollection employeesToReturn = new EmployeeDataCollection();
			EmployeeBll bll = new EmployeeBll();
			// Get EmployeeGroup testdata.
			EmployeeGroupDataCollection employeeGroupTestData = EmployeeGroupUnitTestHelper.GetEmployeeGroupsTestData();
			foreach( EmployeeGroupData employeeGroup in employeeGroupTestData ) {
				EmployeeDataCollection employees = new EmployeeDataCollection();
				for( int i = 1 ; i < 6 ; i++ ) {
					employees.Add( new EmployeeData( Guid.Empty , "Name " + i , "FirstName " + i , employeeGroup.SysId ) );
				}
				employeesToReturn.Add( bll.InsertEmployeeData( employees ) );
			}
			return employeesToReturn;
		}

		public static EmployeeData GetEmployeeTestData() {
			EmployeeBll bll = new EmployeeBll();
			// Get EmployeeGroup testdata.
			EmployeeGroupData employeeGroupTestData = EmployeeGroupUnitTestHelper.GetEmployeeGroupTestData();
			EmployeeData employee = new EmployeeData( Guid.Empty , "Name" , "FirstName" , employeeGroupTestData.SysId );
			EmployeeDataCollection employees = EmployeeDataCollection.FromSingleEmployee( employee );
			EmployeeDataCollection employeesResult = 
				bll.InsertEmployeeData( employees );
			return employeesResult[0];
		}

		public static Employee GetTestEmployee( string userName ) {
			EmployeeBll bll = new EmployeeBll();
			// Get test employeegroup.
			EmployeeGroup testEmployeeGroup = EmployeeGroupUnitTestHelper.GetTestEmployeeGroup();
			Employee employeeToCreate = new Employee();
			employeeToCreate.Name = "Employee Name";
			employeeToCreate.FirstName = "Employee Firstname";
			employeeToCreate.UserName = userName;
			employeeToCreate.Password = "password";
			Employee employeeToReturn = bll.CreateEmployee( employeeToCreate , testEmployeeGroup );
			Assert.AreEqual( employeeToCreate.Name , employeeToReturn.Name );
			Assert.AreEqual( employeeToCreate.FirstName , employeeToReturn.FirstName );
			Assert.AreEqual( employeeToCreate.UserName , employeeToReturn.UserName );
			new UserBll().AuthenticateUser( employeeToCreate.UserName , employeeToCreate.Password );
			return employeeToReturn;
		}

		private EmployeeUnitTestHelper() {
		}

	}

}
