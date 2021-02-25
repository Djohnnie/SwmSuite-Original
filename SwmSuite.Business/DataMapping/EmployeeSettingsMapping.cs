using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class EmployeeSettingsMapping : Mapping {

		public static EmployeeSettings FromDataObject( EmployeeSettingsData employeeSettingsData ) {
			Mapping mapping = new EmployeeSettingsMapping();
			return mapping.FromDataObject( employeeSettingsData ) as EmployeeSettings;
		}

		public static EmployeeSettingsData FromBusinessObject( EmployeeSettings employeeSettings ) {
			Mapping mapping = new EmployeeSettingsMapping();
			return mapping.FromBusinessObject( employeeSettings ) as EmployeeSettingsData;
		}

		public static EmployeeSettingsCollection FromDataObjectCollection( EmployeeSettingsDataCollection employeeSettingsDataCollection ) {
			Mapping mapping = new EmployeeSettingsMapping();
			EmployeeSettingsCollection employeeSettingsCollectionToReturn = new EmployeeSettingsCollection();
			foreach( EmployeeSettingsData employeeSettingsData in employeeSettingsDataCollection ) {
				employeeSettingsCollectionToReturn.Add( FromDataObject( employeeSettingsData ) );
			}
			return employeeSettingsCollectionToReturn;
		}

		public static EmployeeSettingsDataCollection FromBusinessObjectCollection( EmployeeSettingsCollection employeeSettingsCollection ) {
			Mapping mapping = new EmployeeSettingsMapping();
			EmployeeSettingsDataCollection employeeSettingsDataCollectionToReturn = new EmployeeSettingsDataCollection();
			foreach( EmployeeSettings employeeSettings in employeeSettingsCollection ) {
				employeeSettingsDataCollectionToReturn.Add( FromBusinessObject( employeeSettings ) );
			}
			return employeeSettingsDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			EmployeeSettingsData employeeSettingsData = dataObject as EmployeeSettingsData;
			EmployeeSettings employeeSettingsToReturn = new EmployeeSettings();
			employeeSettingsToReturn.SysId = employeeSettingsData.SysId;
			employeeSettingsToReturn.RowVersion = employeeSettingsData.RowVersion;
			employeeSettingsToReturn.AutoLogon = employeeSettingsData.AutoLogon;
			employeeSettingsToReturn.AutoLogonHost = employeeSettingsData.AutoLogonHost;
			employeeSettingsToReturn.LogoutTimeout = employeeSettingsData.LogoutTimeout;
			employeeSettingsToReturn.EmailNotification = employeeSettingsData.EmailNotification;
			employeeSettingsToReturn.EmailAddress = employeeSettingsData.EmailAddress;
			employeeSettingsToReturn.SmtpServer = employeeSettingsData.SmtpServer;
			employeeSettingsToReturn.SmtpPort = employeeSettingsData.SmtpPort;
			employeeSettingsToReturn.SecureConnection = employeeSettingsData.SecureConnection;
			employeeSettingsToReturn.Authentication = employeeSettingsData.Authentication;
			employeeSettingsToReturn.Username = employeeSettingsData.Username;
			employeeSettingsToReturn.Password = employeeSettingsData.Password;
			return employeeSettingsToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			EmployeeSettings employeeSettings = businessObject as EmployeeSettings;
			EmployeeSettingsData employeeSettingsDataToReturn = new EmployeeSettingsData();
			employeeSettingsDataToReturn.SysId = employeeSettings.SysId;
			employeeSettingsDataToReturn.SysId = employeeSettings.SysId;
			employeeSettingsDataToReturn.RowVersion = employeeSettings.RowVersion;
			employeeSettingsDataToReturn.AutoLogon = employeeSettings.AutoLogon;
			employeeSettingsDataToReturn.AutoLogonHost = employeeSettings.AutoLogonHost;
			employeeSettingsDataToReturn.LogoutTimeout = employeeSettings.LogoutTimeout;
			employeeSettingsDataToReturn.EmailNotification = employeeSettings.EmailNotification;
			employeeSettingsDataToReturn.EmailAddress = employeeSettings.EmailAddress;
			employeeSettingsDataToReturn.SmtpServer = employeeSettings.SmtpServer;
			employeeSettingsDataToReturn.SmtpPort = employeeSettings.SmtpPort;
			employeeSettingsDataToReturn.SecureConnection = employeeSettings.SecureConnection;
			employeeSettingsDataToReturn.Authentication = employeeSettings.Authentication;
			employeeSettingsDataToReturn.Username = employeeSettings.Username;
			employeeSettingsDataToReturn.Password = employeeSettings.Password;
			return employeeSettingsDataToReturn;
		}

		#endregion

	}

}
