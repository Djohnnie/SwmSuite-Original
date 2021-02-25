using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class UserPasswordDialog : Form {

		#region -_ Public Properties _-

		public String Password { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="UserPasswordDialog"/> class.
		/// </summary>
		public UserPasswordDialog( String userFullName ) {
			InitializeComponent();
			dialogHeader.MainText = "  Welkom " + userFullName;
		}

		#endregion

		#region -_ Form Events _-

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.Password = passwordTextBox.Client.Text;
			//this.DialogResult = DialogResult.OK;
			//this.Close();
		}

		/// <summary>
		/// Handles the Click event of the cancelButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void cancelButton_Click( object sender , EventArgs e ) {
			//this.DialogResult = DialogResult.Cancel;
			//this.Close();
		}

		/// <summary>
		/// Handles the Load event of the UserPasswordDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void UserPasswordDialog_Load( object sender , EventArgs e ) {
			passwordTextBox.Focus();
		}

		#endregion

	}

}