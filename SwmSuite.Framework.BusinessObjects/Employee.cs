using System;
using System.Collections.Generic;

using System.Text;
using System.Security;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining an employee.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class Employee : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		public Guid UserSysId { get; set; }

		public string Name { get; set; }

		public string FirstName { get; set; }

		public string Address { get; set; }

		public ZipCode ZipCode { get; set; }

		public string PrivatePhoneNumber { get; set; }

		public string WorkPhoneNumber { get; set; }

		public string CellPhoneNumber { get; set; }

		public string EmailAddress1 { get; set; }

		public string EmailAddress2 { get; set; }

		public string EmailAddress3 { get; set; }

		public string EmailAddress4 { get; set; }

		public string EmailAddress5 { get; set; }

		public Avatar Avatar { get; set; }

		public EmployeeSettings Settings { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public bool Administrator { get; set; }

		[XmlIgnore]
		public string FullName {
			get {
				return this.FirstName + " " + this.Name;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Employee() {
		}

		#endregion

		#region -_ Validation _-

		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <returns></returns>
		public bool Validate() {
			bool valid = true;
			this.ValidationErrors.Clear();
			// Validate Name.
			if( String.IsNullOrEmpty( this.Name ) ) {
				valid = false;
				this.ValidationErrors.Add( "Naam is verplicht in te vullen." );
			}
			// Validate Firstname.
			if( String.IsNullOrEmpty( this.FirstName ) ) {
				valid = false;
				this.ValidationErrors.Add( "Voornaam is verplicht in te vullen." );
			}
			// Validate UserName.
			if( String.IsNullOrEmpty( this.UserName ) ) {
				valid = false;
				this.ValidationErrors.Add( "Gebruikersnaam is verplicht in te vullen." );
			}
			// Validate Password.
			if( String.IsNullOrEmpty( this.Password ) ) {
				valid = false;
				this.ValidationErrors.Add( "Wachtwoord is verplicht in te vullen." );
			}
			return valid;
		}

		#endregion

	}
}
