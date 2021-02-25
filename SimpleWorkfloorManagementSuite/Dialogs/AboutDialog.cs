using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	/// <summary>
	/// About dialog.
	/// </summary>
	public partial class AboutDialog : Form {

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AboutDialog() {
			InitializeComponent();

			splashControl1.Version = "Versie " + Application.ProductVersion;
			splashControl1.Copyright = "door Hooyberghs Johnny";
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the splashControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void splashControl_Click( object sender , EventArgs e ) {
			this.Close();
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Show this about dialog.
		/// </summary>
		public static void Show() {
			AboutDialog dialog = new AboutDialog();
			dialog.ShowDialog();
		}

		#endregion

	}

}