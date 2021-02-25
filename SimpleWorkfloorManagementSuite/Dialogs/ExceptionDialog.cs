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
	/// 
	/// </summary>
	public partial class ExceptionDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the exception.
		/// </summary>
		/// <value>The exception.</value>
		public Exception Exception { get; set; }

		/// <summary>
		/// Gets or sets the result.
		/// </summary>
		/// <value>The result.</value>
		public ExceptionDialogResult Result { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ExceptionDialog"/> class.
		/// </summary>
		/// <param name="exception">The exception.</param>
		public ExceptionDialog( Exception exception ) {
			InitializeComponent();

			this.Exception = exception;
		}

		#endregion

		#region -_ Static Methods _-

		public static ExceptionDialogResult Show( Exception e ) {
			ExceptionDialog dialog = new ExceptionDialog( e );
			dialog.ShowDialog();
			return dialog.Result;
		}

		#endregion

		/// <summary>
		/// Handles the Click event of the continueButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void continueButton_Click( object sender , EventArgs e ) {
			this.Result = ExceptionDialogResult.Continue;
			this.Close();
		}

		/// <summary>
		/// Handles the Click event of the exitButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void exitButton_Click( object sender , EventArgs e ) {
			this.Result = ExceptionDialogResult.Exit;
			this.Close();
		}

		/// <summary>
		/// Handles the Click event of the restartButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void restartButton_Click( object sender , EventArgs e ) {
			this.Result = ExceptionDialogResult.Restart;
			this.Close();
		}

		/// <summary>
		/// Handles the Click event of the detailsButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void detailsButton_Click( object sender , EventArgs e ) {
			//this.Result = ExceptionDialogResult.Details;
			//this.Close();
			ExceptionDetailDialog.Show( this.Exception );
		}


	}

}
