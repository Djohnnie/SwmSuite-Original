/***********
 * Employee.cs
 * 
 * 08/08/2008 - Created
 * 
 */

using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using System.Security;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class EmployeeData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		public Guid UserSysId { get; set; }

		public string Name { get; set; }

		public string FirstName { get; set; }

		public int? ZipCodeSysId { get; set; }

		public string Address { get; set; }

		public string PrivatePhoneNumber { get; set; }

		public string WorkPhoneNumber { get; set; }

		public string CellPhoneNumber { get; set; }

		public string EmailAddress1 { get; set; }

		public string EmailAddress2 { get; set; }

		public string EmailAddress3 { get; set; }

		public string EmailAddress4 { get; set; }

		public string EmailAddress5 { get; set; }

		public int? AvatarSysId { get; set; }

		public int? ApplicationSettingsSysId { get; set; }

		public int EmployeeGroupSysId { get; set; }

		#region -_ Extra _-

		public string UserName { get; set; }

		public bool Administrator { get; set; }

		#endregion

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public EmployeeData() {
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="userSysId"></param>
		/// <param name="name"></param>
		/// <param name="firstName"></param>
		/// <param name="employeeGroupSysId"></param>
		public EmployeeData( Guid userSysId , String name , String firstName , int employeeGroupSysId ) {
			this.RowVersion = 0;
			this.UserSysId = userSysId;
			this.Name = name;
			this.FirstName = firstName;
			this.EmployeeGroupSysId = employeeGroupSysId;
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="userSysId"></param>
		/// <param name="name"></param>
		/// <param name="firstName"></param>
		/// <param name="zipCodeSysId"></param>
		/// <param name="address"></param>
		/// <param name="privatePhoneNumber"></param>
		/// <param name="workPhoneNumber"></param>
		/// <param name="cellPhoneNumber"></param>
		/// <param name="email1"></param>
		/// <param name="email2"></param>
		/// <param name="email3"></param>
		/// <param name="email4"></param>
		/// <param name="email5"></param>
		/// <param name="avatarSysId"></param>
		/// <param name="applicationSettingsSysId"></param>
		/// <param name="employeeGroupSysId"></param>
		public EmployeeData( Guid userSysId , String name , String firstName , int? zipCodeSysId , string address , string privatePhoneNumber , string workPhoneNumber , string cellPhoneNumber , string email1 , string email2 , string email3 , string email4 , string email5 , int? avatarSysId , int? applicationSettingsSysId , int employeeGroupSysId ) {
			this.RowVersion = 0;
			this.UserSysId = userSysId;
			this.Name = name;
			this.FirstName = firstName;
			this.Address = address;
			this.ZipCodeSysId = zipCodeSysId;
			this.PrivatePhoneNumber = privatePhoneNumber;
			this.WorkPhoneNumber = workPhoneNumber;
			this.CellPhoneNumber = cellPhoneNumber;
			this.EmailAddress1 = email1;
			this.EmailAddress2 = email2;
			this.EmailAddress3 = email3;
			this.EmailAddress4 = email4;
			this.EmailAddress5 = email5;
			this.AvatarSysId = avatarSysId;
			this.ApplicationSettingsSysId = applicationSettingsSysId;
			this.EmployeeGroupSysId = employeeGroupSysId;
		}

		#endregion

		#region -_ Public Methods _-

		public override string ToString() {
			return this.FirstName + " " + this.Name;
		}

		#endregion

	}
}
