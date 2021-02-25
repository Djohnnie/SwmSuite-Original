using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard {

	public partial class SwmSuiteAdminWizardContent3 : UserControl {

		public string UserName {
			get {
				return userNameTextBox.Text;
			}
		}

		public string Password {
			get {
				return password1TextBox.Text;
			}
		}

		public SwmSuiteAdminWizardContent3() {
			InitializeComponent();
		}

		public bool PasswordOk() {
			return password1TextBox.Text.Equals( password2TextBox.Text );
		}

		private void userNameTextBox_TextChanged( object sender , EventArgs e ) {
			userNameValidationControl.Valid = !String.IsNullOrEmpty( userNameTextBox.Text );
		}

		private void password1TextBox_TextChanged( object sender , EventArgs e ) {
			password1ValidationControl.Valid = !String.IsNullOrEmpty( password1TextBox.Text ) && password1TextBox.Text.Equals( password2TextBox.Text );
			password2ValidationControl.Valid = !String.IsNullOrEmpty( password2TextBox.Text ) && password1TextBox.Text.Equals( password2TextBox.Text );
		}

		private void password2TextBox_TextChanged( object sender , EventArgs e ) {
			password1ValidationControl.Valid = !String.IsNullOrEmpty( password1TextBox.Text ) && password1TextBox.Text.Equals( password2TextBox.Text );
			password2ValidationControl.Valid = !String.IsNullOrEmpty( password2TextBox.Text ) && password1TextBox.Text.Equals( password2TextBox.Text );
		}
	}
}
