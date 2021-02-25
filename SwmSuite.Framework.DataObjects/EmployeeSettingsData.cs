using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class EmployeeSettingsData : DataObjectBase {

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
		/// Initializes a new instance of the <see cref="EmployeeSettingsData"/> class.
		/// </summary>
		public EmployeeSettingsData() {
		}

		#endregion

	}

}
