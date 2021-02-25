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
	/// Form representing an error dialog.
	/// </summary>
	public partial class ErrorDialog : Form {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ErrorDialog"/> class.
		/// </summary>
		public ErrorDialog( String message ) {
			InitializeComponent();
			errorLabel.Text = message;
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows the error dialog.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void ShowErrorDialog( String message ){
			ErrorDialog errorDialog = new ErrorDialog( message );
			errorDialog.ShowDialog();
		}

		#endregion

	}

}
