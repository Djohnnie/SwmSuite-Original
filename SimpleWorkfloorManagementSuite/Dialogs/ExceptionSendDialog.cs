using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.Common;
using System.IO;

namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	public partial class ExceptionSendDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the exception.
		/// </summary>
		/// <value>The exception.</value>
		public Exception Exception { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ExceptionSendDialog"/> class.
		/// </summary>
		public ExceptionSendDialog() {
			InitializeComponent();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the ExceptionSendDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void ExceptionSendDialog_Load( object sender , EventArgs e ) {
			SendErrorReport();
		}

		#endregion

		#region -_ Helper Methods _-

		/// <summary>
		/// Sends the error report.
		/// </summary>
		private void SendErrorReport() {
			SwmSuiteNotificationMail errorMail = new SwmSuiteNotificationMail();
			errorMail.EmailAddress = "swmsuite@gmail.com";
			errorMail.SmtpServer = "smtp.gmail.com";
			errorMail.SmtpPort = 587;
			errorMail.SecureConnection = true;
			errorMail.Authentication = true;
			errorMail.Username = "swmsuite";
			errorMail.Password = "SimpleWorkfloorManagementSuite";
			String contents = CreateErrorReport();
			String fileName = Path.GetTempPath() + "\\swmsuiteer.xml";
			File.WriteAllText( fileName , contents );
			errorMail.SendMailCallBack += new EventHandler<SwmSuiteNotificationMailEventArgs>( errorMail_SendMailCallBack );
			errorMail.SendErrorMailAsync( "SwmSuite error report" , CreateMailBody() , fileName );
		}

		void errorMail_SendMailCallBack( object sender , SwmSuiteNotificationMailEventArgs e ) {
			this.Close();
		}

		/// <summary>
		/// Creates the mail body.
		/// </summary>
		/// <returns></returns>
		private string CreateMailBody() {
			return "<html><body><h1>SwmSuite error report</h1><p>" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "</p><p>" + this.Exception.ToString() + "</p></body></html>";
		}

		/// <summary>
		/// Creates the error report.
		/// </summary>
		/// <returns></returns>
		private string CreateErrorReport() {
			return this.Exception.ToString();
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows the exception send dialog.
		/// </summary>
		/// <param name="exception">The exception.</param>
		public static void ShowExceptionSendDialog( Exception exception ) {
			ExceptionSendDialog dialog = new ExceptionSendDialog();
			dialog.Exception = exception;
			dialog.ShowDialog();
		}

		#endregion

	}

}
