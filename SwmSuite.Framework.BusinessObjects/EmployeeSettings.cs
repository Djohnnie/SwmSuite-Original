using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining the employee settings.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class EmployeeSettings : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets a value indicating whether [auto logon].
		/// </summary>
		/// <value><c>true</c> if [auto logon]; otherwise, <c>false</c>.</value>
		public bool AutoLogon { get; set; }

		/// <summary>
		/// Gets or sets the auto logon host.
		/// </summary>
		/// <value>The auto logon host.</value>
		public String AutoLogonHost { get; set; }

		/// <summary>
		/// Gets or sets the logout timeout.
		/// </summary>
		/// <value>The logout timeout.</value>
		public int LogoutTimeout { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [notification email].
		/// </summary>
		/// <value><c>true</c> if [notification email]; otherwise, <c>false</c>.</value>
		public bool EmailNotification { get; set; }

		/// <summary>
		/// Gets or sets the email address.
		/// </summary>
		/// <value>The email address.</value>
		public String EmailAddress { get; set; }

		/// <summary>
		/// Gets or sets the SMTP server.
		/// </summary>
		/// <value>The SMTP server.</value>
		public String SmtpServer { get; set; }

		/// <summary>
		/// Gets or sets the SMTP port.
		/// </summary>
		/// <value>The SMTP port.</value>
		public int? SmtpPort { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [secure connection].
		/// </summary>
		/// <value><c>true</c> if [secure connection]; otherwise, <c>false</c>.</value>
		public bool SecureConnection { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="EmployeeSettings"/> is authentication.
		/// </summary>
		/// <value><c>true</c> if authentication; otherwise, <c>false</c>.</value>
		public bool Authentication { get; set; }

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>The username.</value>
		public String Username { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public String Password { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeSettings"/> class.
		/// </summary>
		public EmployeeSettings() {
		}

		#endregion

		#region -_ Validation _-

		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <returns>Returns true if valid, false otherwise.</returns>
		public bool Validate() {
			bool valid = base.Validate();
			if( this.LogoutTimeout < 2 || this.LogoutTimeout > 30 ) {
				valid = false;
				this.ValidationErrors.Add( "Automatisch afmelden mag niet minder dan 2 minuten en niet meer dan 30 minuten bedragen." );
			}
			return valid;
		}

		#endregion

	}

}
