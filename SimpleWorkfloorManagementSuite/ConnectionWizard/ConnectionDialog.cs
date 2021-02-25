using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Proxy.Interface;
using SwmSuite.Presentation.Common.MessageDialog;
using SwmSuite.Framework.Application;

namespace SwmSuite.Presentation.ConnectionWizard {

	public partial class ConnectionDialog : Form {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionDialog"/> class.
		/// </summary>
		public ConnectionDialog() {
			InitializeComponent();
			SwmSuiteSettings.ConnectionSettings.DalFactory = "SwmSuite.DataAccess.Sql.DalFactory,SwmSuite.DataAccess.Sql";
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the ConnectionDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void ConnectionDialog_Load( object sender , EventArgs e ) {
			if( SwmSuiteSettings.ConnectionSettings != null ) {
				switch( SwmSuiteSettings.ConnectionSettings.ConnectionMode ) {
					case SwmSuiteConnectionMode.FatClient: {
							inprocRadioButton.Checked = true;
							connectionStringTextBox.Client.Text = SwmSuiteSettings.ConnectionSettings.ConnectionString;
							break;
						}
					case SwmSuiteConnectionMode.SmartClient: {
							webservicesRadioButton.Checked = true;
							webAddressTextBox.Client.Text = SwmSuiteSettings.ConnectionSettings.ConnectionTarget;
							break;
						}
				}
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the inprocRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void inprocRadioButton_CheckedChanged( object sender , EventArgs e ) {
			if( inprocRadioButton.Checked ) {
				SwmSuiteSettings.ConnectionSettings.ConnectionMode = SwmSuiteConnectionMode.FatClient;
				inprocGroup.Visible = true;
				webserviceGroup.Visible = false;
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the webservicesRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void webservicesRadioButton_CheckedChanged( object sender , EventArgs e ) {
			if( webservicesRadioButton.Checked ) {
				SwmSuiteSettings.ConnectionSettings.ConnectionMode = SwmSuiteConnectionMode.SmartClient;
				webserviceGroup.Visible = true;
				inprocGroup.Visible = true;
			}
		}

		/// <summary>
		/// Handles the Click event of the connectionStringButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void connectionStringButton_Click( object sender , EventArgs e ) {
			SqlServerConnectionStringDialog dialog;// = new SqlServerConnectionStringDialog();
			if( SwmSuiteSettings.ConnectionSettings.ConnectionStringConfiguration == null ) {
				dialog = new SqlServerConnectionStringDialog();
			} else {
				dialog = new SqlServerConnectionStringDialog( SwmSuiteSettings.ConnectionSettings.ConnectionStringConfiguration );
			}
			if( dialog.ShowDialog() == DialogResult.OK ) {
				SwmSuiteSettings.ConnectionSettings.ConnectionStringConfiguration = dialog.ConnectionString;
				connectionStringTextBox.Client.Text = SwmSuiteSettings.ConnectionSettings.ConnectionString;
			}
		}

		/// <summary>
		/// Handles the Click event of the proxyButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void proxyButton_Click( object sender , EventArgs e ) {
			ProxyConfigurationDialog dialog = new ProxyConfigurationDialog();
			dialog.ProxyAddress = SwmSuiteSettings.ConnectionSettings.ConnectionProxyAddress;
			dialog.ProxyPort = SwmSuiteSettings.ConnectionSettings.ConnectionProxyPort;
			if( dialog.ShowDialog() == DialogResult.OK ) {
				SwmSuiteSettings.ConnectionSettings.ConnectionProxyAddress = dialog.ProxyAddress;
				SwmSuiteSettings.ConnectionSettings.ConnectionProxyPort = dialog.ProxyPort;
			}

		}

		/// <summary>
		/// Handles the Click event of the connectionTestButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void connectionTestButton_Click( object sender , EventArgs e ) {
			circularProgressControl.Visible = true;
			resultLabel.Visible = false;
			backgroundWorker.RunWorkerAsync();
		}

		/// <summary>
		/// Handles the DoWork event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			SwmSuiteFacade.ClearFacade();
			e.Result = SwmSuiteFacade.ConnectionTestFacade.CheckConnection();
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			circularProgressControl.Visible = false;
			resultLabel.Text = (bool)e.Result ? "Gelukt" : "Niet gelukt";
			resultLabel.ForeColor = (bool)e.Result ? Color.Green : Color.Red;
			resultLabel.Visible = true;
		}

		/// <summary>
		/// Handles the Click event of the saveButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void saveButton_Click( object sender , EventArgs e ) {
			SwmSuiteSettings.ConnectionSettings.Save( "settings.xml" );
			this.Close();
		}

		/// <summary>
		/// Handles the TextChanged event of the webAddressTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void webAddressTextBox_TextChanged( object sender , EventArgs e ) {
			SwmSuiteSettings.ConnectionSettings.ConnectionTarget = webAddressTextBox.Client.Text;
		}

		#endregion

	}
}