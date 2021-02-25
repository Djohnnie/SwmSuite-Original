using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {
	
	public class EmployeeSettingsUnitTestHelper {

		public static void AreEqual( EmployeeSettingsDataCollection expected , EmployeeSettingsDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " employeesettings expected, " + actual.Count.ToString() + " employeesettings actual!" );
			// Test individual employeesettings.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].LogoutTimeout , actual[i].LogoutTimeout , "UT: expected EmployeeSettings.LogoutTimeout (" + expected[i].LogoutTimeout.ToString() + ") <> actual EmployeeSettings.LogoutTimeout (" + actual[i].LogoutTimeout.ToString() + ")!" );
				Assert.AreEqual( expected[i].EmailNotification , actual[i].EmailNotification , "UT: expected EmployeeSettings.EmailNotification (" + expected[i].EmailNotification.ToString() + ") <> actual EmployeeSettings.EmailNotification (" + actual[i].EmailNotification.ToString() + ")!" );
				Assert.AreEqual( expected[i].EmailAddress , actual[i].EmailAddress , "UT: expected EmployeeSettings.EmailAddress (" + expected[i].EmailAddress + ") <> actual EmployeeSettings.EmailAddress (" + actual[i].EmailAddress + ")!" );
				Assert.AreEqual( expected[i].SmtpServer , actual[i].SmtpServer , "UT: expected EmployeeSettings.SmtpServer (" + expected[i].SmtpServer + ") <> actual EmployeeSettings.SmtpServer (" + actual[i].SmtpServer + ")!" );
				Assert.AreEqual( expected[i].SmtpPort , actual[i].SmtpPort , "UT: expected EmployeeSettings.SmtpPort (" + expected[i].SmtpPort.ToString() + ") <> actual EmployeeSettings.SmtpPort (" + actual[i].SmtpPort.ToString() + ")!" );
				Assert.AreEqual( expected[i].SecureConnection , actual[i].SecureConnection , "UT: expected EmployeeSettings.SecureConnection (" + expected[i].SecureConnection.ToString() + ") <> actual EmployeeSettings.SecureConnection (" + actual[i].SecureConnection.ToString() + ")!" );
				Assert.AreEqual( expected[i].Authentication , actual[i].Authentication , "UT: expected EmployeeSettings.Authentication (" + expected[i].Authentication.ToString() + ") <> actual EmployeeSettings.Authentication (" + actual[i].Authentication.ToString() + ")!" );
				Assert.AreEqual( expected[i].Username , actual[i].Username , "UT: expected EmployeeSettings.Username (" + expected[i].Username + ") <> actual EmployeeSettings.Username (" + actual[i].Username + ")!" );
				Assert.AreEqual( expected[i].Password , actual[i].Password , "UT: expected EmployeeSettings.Password (" + expected[i].Password + ") <> actual EmployeeSettings.Password (" + actual[i].Password + ")!" );
				Assert.AreEqual( expected[i].AutoLogon , actual[i].AutoLogon , "UT: expected EmployeeSettings.AutoLogon (" + expected[i].AutoLogon.ToString() + ") <> actual EmployeeSettings.AutoLogon (" + actual[i].AutoLogon.ToString() + ")!" );
				Assert.AreEqual( expected[i].AutoLogonHost , actual[i].AutoLogonHost , "UT: expected EmployeeSettings.AutoLogonHost (" + expected[i].AutoLogonHost + ") <> actual EmployeeSettings.AutoLogonHost (" + actual[i].AutoLogonHost + ")!" );
			}
		}

		public static void AreInLogDeletes( EmployeeSettingsDataCollection employeeSettingsData ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , employeeSettingsData.Count , "UT: " + employeeSettingsData.Count.ToString() + " employeesettings expected in LogDeletes, " + logDeletes.Count.ToString() + " employeesettings found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new EmployeeSettingsSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( employeeSettingsData[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateEmployeeSettings( EmployeeSettingsDataCollection employeeSettingsData ) {
			foreach( EmployeeSettingsData settings in employeeSettingsData ) {
				// TODO: Update code...
			}
		}

		public static EmployeeSettingsData GetEmployeeSettingsData() {
			EmployeeSettingsData employeeSettingsDataToReturn = new EmployeeSettingsData();
			employeeSettingsDataToReturn.AutoLogon = true;
			employeeSettingsDataToReturn.AutoLogonHost = "HOST";
			employeeSettingsDataToReturn.LogoutTimeout = 2;
			employeeSettingsDataToReturn.EmailNotification = true;
			employeeSettingsDataToReturn.EmailAddress = "info@swmsuite.com";
			employeeSettingsDataToReturn.SmtpServer = "smtp.swmsuite.com";
			employeeSettingsDataToReturn.SmtpPort = 25;
			employeeSettingsDataToReturn.SecureConnection = true;
			employeeSettingsDataToReturn.Authentication = true;
			employeeSettingsDataToReturn.Username = "SwmSuite";
			employeeSettingsDataToReturn.Password = "SwmSuite";
			return employeeSettingsDataToReturn;
		}

	}

}
