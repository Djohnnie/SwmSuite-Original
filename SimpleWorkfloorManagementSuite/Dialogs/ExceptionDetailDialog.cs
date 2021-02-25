using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using SwmSuite.Data.Common;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class ExceptionDetailDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the exception.
		/// </summary>
		/// <value>The exception.</value>
		public Exception Exception { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ExceptionDetailDialog"/> class.
		/// </summary>
		/// <param name="exception">The exception.</param>
		public ExceptionDetailDialog( Exception exception ) {
			InitializeComponent();
			this.Exception = exception;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the saveButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void saveButton_Click( object sender , EventArgs e ) {
			SaveErrorReport();
			this.Close();
		}

		/// <summary>
		/// Handles the Click event of the sendButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void sendButton_Click( object sender , EventArgs e ) {
			ExceptionSendDialog.ShowExceptionSendDialog( this.Exception );
			this.Close();
		}

		/// <summary>
		/// Handles the Load event of the ExceptionDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void ExceptionDetailDialog_Load( object sender , EventArgs e ) {
			exceptionTextBox.Client.Text = this.Exception.Message + "\n\n\n" + this.Exception.ToString() + ( this.Exception.InnerException != null ? "\n\n\n<INNER EXCEPTION>\n\n\n" + this.Exception.InnerException.Message + "\n\n\n" + this.Exception.InnerException.ToString() : "" );
		}

		#endregion

		#region -_ Static Methods _-

		public static void Show( Exception e ) {
			ExceptionDetailDialog dialog = new ExceptionDetailDialog( e );
			dialog.ShowDialog();
		}

		#endregion

		#region -_ Helper Methods _-

		/// <summary>
		/// Saves the error report.
		/// </summary>
		private void SaveErrorReport() {
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "XML Bestand (*.xml)|*.xml";
			if( dialog.ShowDialog() == DialogResult.OK ) {
				String contents = CreateErrorReport();
				File.WriteAllText( dialog.FileName , contents );
			}
		}

		/// <summary>
		/// Creates the error report.
		/// </summary>
		/// <returns></returns>
		private string CreateErrorReport() {
			return this.Exception.ToString();
		}

		#endregion

	}

}
