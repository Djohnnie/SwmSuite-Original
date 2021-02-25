using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	public partial class MessageFolderDetailDialog : Form {

		#region -_ Public Properties _-

		public MessageFolder MessageFolder { get; set; }

		#endregion

		#region -_ Construction _-

		public MessageFolderDetailDialog() {
			InitializeComponent();
			this.MessageFolder = new MessageFolder();
			this.Text = "SwmSuite";
			dialogHeaderControl.MainText = "Nieuwe map aanmaken";
		}

		public MessageFolderDetailDialog( MessageFolder messageFolder ) {
			InitializeComponent();
			this.MessageFolder = messageFolder;
			this.Text = "SwmSuite";
			dialogHeaderControl.MainText = "Mapnaam wijzigen";
		}

		#endregion

		/// <summary>
		/// Handles the Load event of the MessageFolderDetailDialog form.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MessageFolderDetailDialog_Load( object sender , EventArgs e ) {
			nameTextBox.Client.Text = this.MessageFolder.Name;
			
			ValidateAll();
		}

		#region -_ Validation _-

		private void ValidateAll() {
			bool nameIsValid = ValidateName();
			okButton.Enabled = nameIsValid;
		}

		/// <summary>
		/// Validate the "name" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateName() {
			bool valueToReturn = !String.IsNullOrEmpty( nameTextBox.Client.Text );
			nameTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		#endregion

		/// <summary>
		/// Handles the TextChanged event of the nameTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nameTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void okButton_Click( object sender , EventArgs e ) {
			this.MessageFolder.Name = nameTextBox.Client.Text;
		}

	}

}
