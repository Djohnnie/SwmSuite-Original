using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard {

	public partial class SwmSuiteAdminWizardContent4 : UserControl {

		public string EmployeeGroup {
			get {
				return employeeGroupTextBox.Text;
			}
		}
		
		public SwmSuiteAdminWizardContent4() {
			InitializeComponent();
		}

		private void employeeGroupTextBox_TextChanged( object sender , EventArgs e ) {
			employeeGroupValidationControl.Valid = !String.IsNullOrEmpty( employeeGroupTextBox.Text );
		}
	}
}
