using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Presentation.Common.Ribbon;
using SwmSuite.Presentation.Drawing.Office2007Renderer;

namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	public partial class MessageDetailDialog : Form {

		#region -_ Pulic Properties _-

		public SwmSuite.Data.BusinessObjects.Message Message { get; set; }

		public EmployeeCollection Employees { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="NewMessageDialog"/> class.
		/// </summary>
		public MessageDetailDialog() {
			InitializeComponent();
			this.Message = new SwmSuite.Data.BusinessObjects.Message();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NewMessageDialog"/> class.
		/// </summary>
		/// <param name="originalMessage">The original message.</param>
		public MessageDetailDialog( SwmSuite.Data.BusinessObjects.Message originalMessage ) {
			InitializeComponent();
			this.Message = new SwmSuite.Data.BusinessObjects.Message();
			InitializeReply( originalMessage );
		}

		private void InitializeReply( SwmSuite.Data.BusinessObjects.Message originalMessage ) {
			this.Message.Recipients.Add( originalMessage.Sender );
			employeeTextBox.Client.Text = originalMessage.Sender.FullName;
			subjectTextBox.Client.Text = "RE: " + originalMessage.Subject;
			richTextEditor.InitializeReply( originalMessage );
		}

		#endregion

		#region -_ Private Methods _-

		private static String EmployeeLinkCollectionToString( EmployeeCollection employeeLinks ) {
			String stringToReturn = "";
			foreach( Employee employee in employeeLinks ) {
				bool lastItem = employeeLinks.IndexOf( employee ) == employeeLinks.Count - 1;
				stringToReturn += employee.FirstName + " " + employee.Name + ( lastItem ? "" : "; " );
			}
			return stringToReturn;
		}

		#endregion

		#region -_ Event Handling _-

		/// <summary>
		/// Handles the Click event of the browseForEmployeeButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void browseForEmployeeButton_Click( object sender , EventArgs e ) {
			BrowserForEmployeeDialog dialog = new BrowserForEmployeeDialog( this.Message.Recipients );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				this.Message.Recipients = dialog.Employees;
				employeeTextBox.Client.Text = EmployeeLinkCollectionToString( this.Message.Recipients );
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.Message.Sender = SwmSuitePrincipal.CurrentEmployee;
			this.Message.Subject = subjectTextBox.Client.Text;
			this.Message.Date = DateTime.Now;
			this.Message.Contents = richTextEditor.Rtf;
		}

		/// <summary>
		/// Handles the Load event of the NewMessageDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void NewMessageDialog_Load( object sender , EventArgs e ) {
			Validate();
		}

		#endregion

		private void employeeTextBox_TextChanged( object sender , EventArgs e ) {
			Validate();
		}

		private void subjectTextBox_TextChanged( object sender , EventArgs e ) {
			Validate();
		}

		private void Validate() {
			bool employeeValid = ValidateEmployee();
			bool titleValid = ValidateSubject();
			okButton.Enabled = employeeValid && titleValid;
		}

		private bool ValidateEmployee() {
			bool valid = !String.IsNullOrEmpty( employeeTextBox.Client.Text );
			employeeTextBox.DoError( !valid );
			return valid;
		}

		private bool ValidateSubject() {
			bool valid = !String.IsNullOrEmpty( subjectTextBox.Client.Text );
			subjectTextBox.DoError( !valid );
			return valid;
		}

	}

}
