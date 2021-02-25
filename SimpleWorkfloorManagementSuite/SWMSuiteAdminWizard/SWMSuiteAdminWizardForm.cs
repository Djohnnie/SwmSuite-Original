using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Framework;
using SwmSuite.Data.BusinessObjects;
using System.Security;

namespace SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard {

	public partial class SwmSuiteAdminWizardForm : Form {

		#region -_ Private Members _-

		private int _wizardStep = -1;
		private Employee _employee;
		private EmployeeGroup _employeeGroup;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		public SwmSuiteAdminWizardForm() {
			InitializeComponent();
		}

		#endregion

		#region -_ Private Methods _-

		private void Next() {
			if( CheckWizard( _wizardStep ) ) {
				if( swmSuiteAdminWizardContent1.CurrentSelection == SwmSuiteAdminWizardContent1.Selection.Exit ) {
					this.DialogResult = DialogResult.Abort;
					this.Close();
				} else {
					_wizardStep++;
					SetWizard( _wizardStep );
				}
			}
		}

		private void Previous() {

			_wizardStep--;
			SetWizard( _wizardStep );
		}

		private void Finish() {

		}

		private void Cancel() {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void Help() {
			MessageBox.Show( "TODO: HelpFile" );
		}

		private bool CheckWizard( int step ) {
			bool toReturn = true;
			switch( step ) {
				case 0: {
					toReturn = swmSuiteAdminWizardContent1.CheckSelection();
					break;
				}
				case 1: {

					break;
				}
				case 2: {
					break;
				}
				case 3: {
					break;
				}
			}
			return toReturn;
		}

		private void SetWizard( int step ) {
			this.SuspendLayout();
			switch( step ) {
				case 0: {
					previousButton.Visible = false;
					nextButton.Visible = true;
					nextButton.Text = "&Volgende";
					swmSuiteAdminWizardContent1.Visible = true;
					swmSuiteAdminWizardContent2.Visible = false;
					swmSuiteAdminWizardContent3.Visible = false;
					swmSuiteAdminWizardContent4.Visible = false;
					swmSuiteAdminWizardContent5.Visible = false;
					swmSuiteAdminWizardContent1.Focus();
					break;
				}
				case 1: {
					previousButton.Visible = true;
					nextButton.Visible = true;
					nextButton.Text = "&Volgende";
					swmSuiteAdminWizardContent1.Visible = false;
					swmSuiteAdminWizardContent2.Visible = true;
					swmSuiteAdminWizardContent3.Visible = false;
					swmSuiteAdminWizardContent4.Visible = false;
					swmSuiteAdminWizardContent5.Visible = false;
					swmSuiteAdminWizardContent2.Focus();
					break;
				}
				case 2: {
					_employee = new Employee();
					_employee.FirstName = swmSuiteAdminWizardContent2.FirstName;
					_employee.Name = swmSuiteAdminWizardContent2.LastName;

					previousButton.Visible = true;
					nextButton.Visible = true;
					nextButton.Text = "&Volgende";
					swmSuiteAdminWizardContent1.Visible = false;
					swmSuiteAdminWizardContent2.Visible = false;
					swmSuiteAdminWizardContent3.Visible = true;
					swmSuiteAdminWizardContent4.Visible = false;
					swmSuiteAdminWizardContent5.Visible = false;
					swmSuiteAdminWizardContent3.Focus();
					break;
				}
				case 3: {
					_employee.UserName = swmSuiteAdminWizardContent3.UserName;
					_employee.Password = swmSuiteAdminWizardContent3.Password;
					_employee.Administrator = true;

					previousButton.Visible = true;
					nextButton.Visible = true;
					nextButton.Text = "&Voltooien";

					swmSuiteAdminWizardContent1.Visible = false;
					swmSuiteAdminWizardContent2.Visible = false;
					swmSuiteAdminWizardContent3.Visible = false;
					swmSuiteAdminWizardContent4.Visible = true;
					swmSuiteAdminWizardContent5.Visible = false;
					swmSuiteAdminWizardContent4.Focus();
					break;
				}
				case 4: {
					_employeeGroup = new EmployeeGroup();
					_employeeGroup.Name = swmSuiteAdminWizardContent4.EmployeeGroup;
					_employeeGroup.Description = swmSuiteAdminWizardContent4.EmployeeGroup;

					previousButton.Visible = false;
					nextButton.Visible = false;
					nextButton.Text = "&Voltooien";
					helpButton.Visible = false;
					cancelButton.Visible = false;

					swmSuiteAdminWizardContent1.Visible = false;
					swmSuiteAdminWizardContent2.Visible = false;
					swmSuiteAdminWizardContent3.Visible = false;
					swmSuiteAdminWizardContent4.Visible = false;
					swmSuiteAdminWizardContent5.Visible = true;
					swmSuiteAdminWizardContent5.Focus();

					swmSuiteAdminWizardContent5.Administrator = _employee;
					swmSuiteAdminWizardContent5.AdministratorGroup = _employeeGroup;
					swmSuiteAdminWizardContent5.Go();
					break;
				}
			}
			this.ResumeLayout( true );
		}

		#endregion

		#region -_ Form Events _-

		private void helpButton_Click( object sender , EventArgs e ) {
			Help();
		}

		private void previousButton_Click( object sender , EventArgs e ) {
			Previous();
		}

		private void nextButton_Click( object sender , EventArgs e ) {
			if( _wizardStep == 4 ) {
				Finish();
			} else {
				Next();
			}
		}

		private void cancelButton_Click( object sender , EventArgs e ) {
			Cancel();
		}

		private void SwmSuiteAdminWizardForm_Load( object sender , EventArgs e ) {
			// Load the first wizard step.
			Next();
		}

		#endregion

		private void swmSuiteAdminWizardContent5_Completed( object sender , EventArgs e ) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		
	}
}
