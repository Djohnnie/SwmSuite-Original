using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class EmployeeMapping : Mapping {

		public static Employee FromDataObject( EmployeeData employeeData ) {
			Mapping mapping = new EmployeeMapping();
			return mapping.FromDataObject( employeeData ) as Employee;
		}

		public static EmployeeData FromBusinessObject( Employee employee ) {
			Mapping mapping = new EmployeeMapping();
			return mapping.FromBusinessObject( employee ) as EmployeeData;
		}

		public static EmployeeCollection FromDataObjectCollection( EmployeeDataCollection employeeDataCollection ) {
			Mapping mapping = new EmployeeMapping();
			EmployeeCollection employeeCollectionToReturn = new EmployeeCollection();
			foreach( EmployeeData employeeData in employeeDataCollection ) {
				employeeCollectionToReturn.Add( FromDataObject( employeeData ) );
			}
			return employeeCollectionToReturn;
		}

		public static EmployeeDataCollection FromBusinessObjectCollection( EmployeeCollection employeeCollection ) {
			Mapping mapping = new EmployeeMapping();
			EmployeeDataCollection employeeDataCollectionToReturn = new EmployeeDataCollection();
			foreach( Employee employee in employeeCollection ) {
				employeeDataCollectionToReturn.Add( FromBusinessObject( employee ) );
			}
			return employeeDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			EmployeeData employeeData = dataObject as EmployeeData;
			Employee employeeToReturn = new Employee();
			employeeToReturn.SysId = employeeData.SysId;
			employeeToReturn.RowVersion = employeeData.RowVersion;
			employeeToReturn.UserSysId = employeeData.UserSysId;
			employeeToReturn.UserName = new UserBll().GetUserNameFromSysId( employeeData.UserSysId );
			employeeToReturn.Name = employeeData.Name;
			employeeToReturn.FirstName = employeeData.FirstName;
			employeeToReturn.Address = employeeData.Address;
			employeeToReturn.PrivatePhoneNumber = employeeData.PrivatePhoneNumber;
			employeeToReturn.WorkPhoneNumber = employeeData.WorkPhoneNumber;
			employeeToReturn.CellPhoneNumber = employeeData.CellPhoneNumber;
			employeeToReturn.EmailAddress1 = employeeData.EmailAddress1;
			employeeToReturn.EmailAddress2 = employeeData.EmailAddress2;
			employeeToReturn.EmailAddress3 = employeeData.EmailAddress3;
			employeeToReturn.EmailAddress4 = employeeData.EmailAddress4;
			employeeToReturn.EmailAddress5 = employeeData.EmailAddress5;
			employeeToReturn.Administrator = employeeData.Administrator;
			if( employeeData.AvatarSysId.HasValue ) {
				employeeToReturn.Avatar = new AvatarBll().GetAvatar( employeeData.AvatarSysId.Value );
			}
			if( employeeData.ApplicationSettingsSysId.HasValue ) {
				employeeToReturn.Settings = new EmployeeSettingsBll().GetEmployeeSettings( employeeData.ApplicationSettingsSysId.Value );
			}
			return employeeToReturn;		
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			Employee employee = businessObject as Employee;
			EmployeeData employeeDataToReturn = new EmployeeData();
			employeeDataToReturn.SysId = employee.SysId;
			employeeDataToReturn.RowVersion = employee.RowVersion;
			employeeDataToReturn.UserSysId = employee.UserSysId;
			employeeDataToReturn.Name = employee.Name;
			employeeDataToReturn.FirstName = employee.FirstName;
			employeeDataToReturn.Address = employee.Address;
			employeeDataToReturn.PrivatePhoneNumber = employee.PrivatePhoneNumber;
			employeeDataToReturn.WorkPhoneNumber = employee.WorkPhoneNumber;
			employeeDataToReturn.CellPhoneNumber = employee.CellPhoneNumber;
			employeeDataToReturn.EmailAddress1 = employee.EmailAddress1;
			employeeDataToReturn.EmailAddress2 = employee.EmailAddress2;
			employeeDataToReturn.EmailAddress3 = employee.EmailAddress3;
			employeeDataToReturn.EmailAddress4 = employee.EmailAddress4;
			employeeDataToReturn.EmailAddress5 = employee.EmailAddress5;
			employeeDataToReturn.Administrator = employee.Administrator;
			if( employee.Avatar != null ) {
				employeeDataToReturn.AvatarSysId = employee.Avatar.SysId;
			}
			if( employee.Settings != null ) {
				employeeDataToReturn.ApplicationSettingsSysId = employee.Settings.SysId;
			}
			return employeeDataToReturn;
		}

		#endregion

	}

}
