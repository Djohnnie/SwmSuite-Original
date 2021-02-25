using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard {

	public partial class SwmSuiteAdminWizardContent2 : UserControl {

		public string FirstName {
			get {
				return firstNameTextBox.Text;
			}
		}

		public string LastName {
			get {
				return nameTextBox.Text;
			}
		}
		
		public SwmSuiteAdminWizardContent2() {
			InitializeComponent();
		}

		private void nameTextBox_TextChanged( object sender , EventArgs e ) {
			nameValidationControl.Valid = !String.IsNullOrEmpty( nameTextBox.Text );
		}

		private void firstNameTextBox_TextChanged( object sender , EventArgs e ) {
			firstNameValidationControl.Valid = !String.IsNullOrEmpty( firstNameTextBox.Text );
		}
	}
}
