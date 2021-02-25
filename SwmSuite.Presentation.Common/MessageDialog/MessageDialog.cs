using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.MessageDialog {
	
	public partial class MessageDialog : Form {

		#region -_ Static Members _-

		public static void Show( String title , String header , String message ) {
			MessageDialog dialog = new MessageDialog( title , header , message );
			dialog.ShowDialog();
			dialog.Dispose();
		}

		#endregion

		#region -_ Contruction _-

		public MessageDialog( String title , String header , String message ) {
			InitializeComponent();

			this.Text = title;
			this.dialogHeader.MainText = header;
			this.messageLabel.Text = message;
		}

		#endregion

		private void okButton_Click( object sender , EventArgs e ) {
			this.Close();
		}

	}

}
