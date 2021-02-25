using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SwmSuite.Presentation.Common.RadioGroup;
using SwmSuite.Presentation.Common.MessageDialog;
using System.Collections.ObjectModel;
using System.Net;
using System.Security.Principal;
using SwmSuite.Framework.Application;

namespace SwmSuite.Presentation.ConnectionWizard {

	public partial class SqlServerConnectionStringDialog : Form {

		#region -_ Private Members _-

		private bool _parameterConfiguration;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the connection string.
		/// </summary>
		/// <value>The connection string.</value>
		public SwmSuiteConnectionStringConfiguration ConnectionString { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="SqlServerConnectionStringDialog"/> class.
		/// </summary>
		public SqlServerConnectionStringDialog() {
			_parameterConfiguration = false;
			InitializeComponent();
			this.ConnectionString = new SwmSuiteConnectionStringConfiguration();
			this.ConnectionString.ConfigurationChanged += new EventHandler<EventArgs>( ConnectionString_ConfigurationChanged );
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SqlServerConnectionStringDialog"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public SqlServerConnectionStringDialog( SwmSuiteConnectionStringConfiguration configuration )
			: this() {
			_parameterConfiguration = true;
			this.ConnectionString = configuration;
			this.ConnectionString.ConfigurationChanged += new EventHandler<EventArgs>( ConnectionString_ConfigurationChanged );
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the SqlServerConnectionStringDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void SqlServerConnectionStringDialog_Load( object sender , EventArgs e ) {
			if( _parameterConfiguration ) {
				serverTextBox.Client.Text = this.ConnectionString.Server;
				switch( this.ConnectionString.Authentication ) {
					case AuthenticationMode.Windows: {
							windowsAuthenticationRadioButton.Checked = true;
							break;
						}
					case AuthenticationMode.SqlServer: {
							sqlAuthenticationRadioButton.Checked = true;
							nameTextBox.Client.Text = this.ConnectionString.Username;
							passwordTextBox.Client.Text = this.ConnectionString.Password;
							break;
						}
				}
				if( !String.IsNullOrEmpty( this.ConnectionString.Server ) ) {
					StartConnectionTest();
				}
			}
		}

		/// <summary>
		/// Handles the ConfigurationChanged event of the ConnectionString control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void ConnectionString_ConfigurationChanged( object sender , EventArgs e ) {
			resultTextBox.Client.Text = this.ConnectionString.ToString();
		}

		/// <summary>
		/// Handles the Click event of the testButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void testButton_Click( object sender , EventArgs e ) {
			StartConnectionTest();
		}

		/// <summary>
		/// Handles the DoWork event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			SwmSuiteConnectionStringConfiguration configuration = (SwmSuiteConnectionStringConfiguration)e.Argument;

			Collection<RadioGroupItem> radioGroupItems = new Collection<RadioGroupItem>();
			String connectionString = configuration.ToStringNoDatabase();
			try {
				using( SqlConnection connection = new SqlConnection( connectionString ) ) {
					connection.Open();
					DataTable databasesDataTable = connection.GetSchema( "Databases" );
					connection.Close();

					foreach( DataRow row in databasesDataTable.Rows ) {
						radioGroupItems.Add( new RadioGroupItem( row["database_name"].ToString() ) );
					}
					connection.Close();
				}
				e.Result = radioGroupItems;
			} catch( SqlException ex ) {
				e.Result = ex.Message;
			}
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			circularProgressControl.Visible = false;
			databasesRadioGroup.Items.Clear();
			testButton.Enabled = true;
			if( e.Result is String ) {
				MessageDialog.Show( "Simple Workfloor Management Suite" , "Sql Server connectie onmogelijk" , "Connectie met de opgegeven Sql Server is niet gelukt. " + e.Result.ToString() );
			} else {
				databasesRadioGroup.Visible = true;
				Collection<RadioGroupItem> radioGroupItems = (Collection<RadioGroupItem>)e.Result;
				foreach( RadioGroupItem item in radioGroupItems ) {
					if( item.Text != "master" && item.Text != "model" && item.Text != "msdb" && item.Text != "tempdb" ) {
						if( item.Text.Equals( this.ConnectionString.Database ) ) {
							item.Checked = true;
						}
						if( item.Text.Equals( "swms" ) ) {
							item.Checked = true;
						}
						databasesRadioGroup.Items.Add( item );
					}
				}
				databasesRadioGroup.RefreshRadioButtons();
				this.ConnectionString.Database = databasesRadioGroup.GetCheckedItem();
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the windowsAuthenticationRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void windowsAuthenticationRadioButton_CheckedChanged( object sender , EventArgs e ) {
			if( windowsAuthenticationRadioButton.Checked ) {
				nameTextBox.Client.Text = WindowsIdentity.GetCurrent().Name;
				nameTextBox.Enabled = false;
				passwordTextBox.Client.Text = "";
				passwordTextBox.Enabled = false;
				this.ConnectionString.Authentication = AuthenticationMode.Windows;
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the sqlAuthenticationRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void sqlAuthenticationRadioButton_CheckedChanged( object sender , EventArgs e ) {
			if( sqlAuthenticationRadioButton.Checked ) {
				nameTextBox.Client.Text = "";
				nameTextBox.Enabled = true;
				passwordTextBox.Client.Text = "";
				passwordTextBox.Enabled = true;
				this.ConnectionString.Authentication = AuthenticationMode.SqlServer;
			}
		}

		/// <summary>
		/// Handles the SelectionChanged event of the databasesRadioGroup control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SwmSuite.Presentation.Common.RadioGroup.RadioGroupSelectionChangedEventArgs"/> instance containing the event data.</param>
		private void databasesRadioGroup_SelectionChanged( object sender , RadioGroupSelectionChangedEventArgs e ) {
			this.ConnectionString.Database = e.Item.Text;
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// Handles the Click event of the cancelButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void cancelButton_Click( object sender , EventArgs e ) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		/// <summary>
		/// Handles the TextChanged event of the serverTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void serverTextBox_TextChanged( object sender , EventArgs e ) {
			this.ConnectionString.Server = serverTextBox.Client.Text;
		}

		/// <summary>
		/// Handles the TextChanged event of the nameTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nameTextBox_TextChanged( object sender , EventArgs e ) {
			this.ConnectionString.Username = nameTextBox.Client.Text;
		}

		/// <summary>
		/// Handles the TextChanged event of the passwordTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void passwordTextBox_TextChanged( object sender , EventArgs e ) {
			this.ConnectionString.Password = passwordTextBox.Client.Text;
		}

		#endregion

		#region -_ Private Methods _-

		private void StartConnectionTest() {
			databasesRadioGroup.Visible = false;
			circularProgressControl.Visible = true;
			testButton.Enabled = false;
			backgroundWorker.RunWorkerAsync( this.ConnectionString );
		}

		#endregion

	}

}
