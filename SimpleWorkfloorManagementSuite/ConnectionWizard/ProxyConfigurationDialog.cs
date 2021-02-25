using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.ConnectionWizard {

	public partial class ProxyConfigurationDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the proxy address.
		/// </summary>
		/// <value>The proxy address.</value>
		public String ProxyAddress { get; set; }

		/// <summary>
		/// Gets or sets the proxy port.
		/// </summary>
		/// <value>The proxy port.</value>
		public String ProxyPort { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ProxyConfigurationDialog"/> class.
		/// </summary>
		public ProxyConfigurationDialog() {
			InitializeComponent();
		}

		#endregion

		#region -_ Form Events _-

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.ProxyAddress = proxyAddressTextBox.Client.Text;
			this.ProxyPort = portTextBox.Client.Text;
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
		/// Handles the Load event of the ProxyConfigurationDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void ProxyConfigurationDialog_Load( object sender , EventArgs e ) {
			proxyAddressTextBox.Client.Text = this.ProxyAddress;
			portTextBox.Client.Text = this.ProxyPort;
		}

		#endregion

		
	}
}
