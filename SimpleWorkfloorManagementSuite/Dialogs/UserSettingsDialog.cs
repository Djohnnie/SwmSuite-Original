using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.Common;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;

using System.Globalization;
using SwmSuite.Framework.Exceptions;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class UserSettingsDialog : Form {

		#region -_ Private Members _-

		private bool _cancelClose;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="UserSettingsDialog"/> class.
		/// </summary>
		public UserSettingsDialog() {
			InitializeComponent();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the CheckedChanged event of the emailNotificationCheckBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void emailNotificationCheckBox_CheckedChanged( object sender , EventArgs e ) {
			emailPanel.Enabled = emailNotificationCheckBox.Checked;
		}

		/// <summary>
		/// Handles the CheckedChanged event of the usernamePasswordCheckBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void usernamePasswordCheckBox_CheckedChanged( object sender , EventArgs e ) {
			userNameTextBox.Enabled = usernamePasswordCheckBox.Checked;
			passwordTextBox.Enabled = usernamePasswordCheckBox.Checked;
		}

		/// <summary>
		/// Handles the Click event of the testMailButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void testMailButton_Click( object sender , EventArgs e ) {
			SwmSuiteNotificationMail mailTest = new SwmSuiteNotificationMail();
			mailTest.EmailAddress = emailAddressTextBox.Client.Text;
			mailTest.SmtpServer = smtpServerTextBox.Client.Text;
			int port = 25;
			if( !int.TryParse( portTextBox.Client.Text , out port ) ) {
				portTextBox.Client.Text = "25";
			}
			mailTest.SmtpPort = port;
			mailTest.SecureConnection = secureConnectionCheckBox.Checked;
			mailTest.Authentication = usernamePasswordCheckBox.Checked;
			mailTest.Username = userNameTextBox.Client.Text;
			mailTest.Password = passwordTextBox.Client.Text;
			mailTest.SendMailCallBack += new EventHandler<SwmSuiteNotificationMailEventArgs>( mailTest_SendMailCallBack );
			mailTest.SendMailAsync( "SwmSuite Testbericht" , "<html><head><style type=\"text/css\">h1 { font-family: Copperplate Gothic Light, Verdana; size: 24; color: blue } p { font-family: Copperplate Gothic Light, Verdana; size: 12; color: black }</style></head><body><h1>Simple Workfloor Management Suite</h1><p>Dit is een testbericht verstuurd vanuit de gebruikersinstellingen.</p></body></html>" );
		}

		/// <summary>
		/// Handles the SendMailCallBack event of the mailTest control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SwmSuite.Data.Common.SwmSuiteNotificationMailEventArgs"/> instance containing the event data.</param>
		void mailTest_SendMailCallBack( object sender , SwmSuiteNotificationMailEventArgs e ) {
			SendMailTestResultDialog.ShowSendMailTestResultDialog( e.Successful );
		}

		/// <summary>
		/// Handles the Load event of the UserSettingsDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void UserSettingsDialog_Load( object sender , EventArgs e ) {
			EmployeeSettings employeeSettings = GetCurrentEmployeeSettings();

			if( employeeSettings != null ) {

				// Automatic login.
				autoLoginCheckBox.Checked = employeeSettings.AutoLogon;
				if( employeeSettings.AutoLogon ) {
					autoLoginHostLabel.Text = employeeSettings.AutoLogonHost;
				} else {
					autoLoginHostLabel.Text = "";
				}

				// Automatic logout.
				logoutTimerTextBox.Client.Text = employeeSettings.LogoutTimeout.ToString( CultureInfo.CurrentCulture );

				// Email notification.
				emailNotificationCheckBox.Checked = employeeSettings.EmailNotification;
				emailAddressTextBox.Client.Text = employeeSettings.EmailAddress;
				smtpServerTextBox.Client.Text = employeeSettings.SmtpServer;
				portTextBox.Client.Text = employeeSettings.SmtpPort.HasValue ? employeeSettings.SmtpPort.Value.ToString( CultureInfo.CurrentCulture ) : "25";
				secureConnectionCheckBox.Checked = employeeSettings.SecureConnection;
				usernamePasswordCheckBox.Checked = employeeSettings.Authentication;
				userNameTextBox.Client.Text = employeeSettings.Username;
				passwordTextBox.Client.Text = employeeSettings.Password;

			} else {
				autoLoginHostLabel.Text = "";
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			try {
				Cursor.Current = Cursors.WaitCursor;

				EmployeeSettings employeeSettings = new EmployeeSettings();

				// Automatic login.
				employeeSettings.AutoLogon = autoLoginCheckBox.Checked;
				employeeSettings.AutoLogonHost = autoLoginHostLabel.Text;

				// Automatic logout.
				employeeSettings.LogoutTimeout = String.IsNullOrEmpty( logoutTimerTextBox.Client.Text ) ?
					2 :
					Int32.Parse( logoutTimerTextBox.Client.Text , CultureInfo.CurrentCulture );

				// Email notification.
				employeeSettings.EmailNotification = emailNotificationCheckBox.Checked;
				if( emailNotificationCheckBox.Checked ) {
					employeeSettings.EmailAddress = emailAddressTextBox.Client.Text;
					employeeSettings.SmtpServer = smtpServerTextBox.Client.Text;
					employeeSettings.SmtpPort = String.IsNullOrEmpty( portTextBox.Client.Text ) ?
						25 :
						Int32.Parse( portTextBox.Client.Text , CultureInfo.CurrentCulture );
					employeeSettings.SecureConnection = secureConnectionCheckBox.Checked;
					employeeSettings.Authentication = usernamePasswordCheckBox.Checked;
					employeeSettings.Username = userNameTextBox.Client.Text;
					employeeSettings.Password = passwordTextBox.Client.Text;
				}

				SwmSuiteFacade.EmployeeFacade.SetEmployeeSettingsForEmployee( employeeSettings , SwmSuitePrincipal.CurrentEmployee );
				_cancelClose = false;
			} catch( SwmSuiteException exception ) {
				if( exception.Error == SwmSuiteError.ValidationError ) {
					ErrorDialog.ShowErrorDialog( exception.Message );
					_cancelClose = true;
				} else {
					throw;
				}
			}
			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Handles the CheckedChanged event of the autoLoginCheckBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void autoLoginCheckBox_CheckedChanged( object sender , EventArgs e ) {
			if( autoLoginCheckBox.Checked ) {
				autoLoginHostLabel.Text = System.Environment.MachineName;
			} else {
				autoLoginHostLabel.Text = "";
			}
		}

		/// <summary>
		/// Handles the FormClosing event of the UserSettingsDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
		private void UserSettingsDialog_FormClosing( object sender , FormClosingEventArgs e ) {
			e.Cancel = _cancelClose;
		}

		#endregion

		#region -_ Private Methods _-

		private EmployeeSettings GetCurrentEmployeeSettings() {
			SwmSuitePrincipal.Settings = SwmSuiteFacade.EmployeeFacade.GetEmployeeSettingsForEmployee(
				SwmSuitePrincipal.CurrentEmployee );
			return SwmSuitePrincipal.Settings;
		}

		#endregion

	}
}
