using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class SendMailTestResultDialog : Form {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="SendMailTestResultDialog"/> class.
		/// </summary>
		private SendMailTestResultDialog( bool success ) {
			InitializeComponent();

			if( success ) {
				successLabel.Visible = true;
				failLabel.Visible = false;
				dialogHeaderControl.Scheme.BackgroundColor1 = Color.Green;
				dialogHeaderControl.Scheme.BackgroundColor2 = Color.FromArgb( 0 , 220 , 0 );
			} else {
				successLabel.Visible = false;
				failLabel.Visible = true;
				dialogHeaderControl.Scheme.BackgroundColor1 = Color.FromArgb( 115 , 10 , 10 );
				dialogHeaderControl.Scheme.BackgroundColor2 = Color.Red;
			}
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows the send mail test result dialog.
		/// </summary>
		/// <param name="success">if set to <c>true</c> [success].</param>
		public static void ShowSendMailTestResultDialog( bool success ) {
			SendMailTestResultDialog dialog = new SendMailTestResultDialog( success );
			dialog.ShowDialog();
		}

		#endregion

	}

}
