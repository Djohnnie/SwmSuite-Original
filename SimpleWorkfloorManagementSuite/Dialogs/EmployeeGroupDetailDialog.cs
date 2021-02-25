using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	/// <summary>
	/// Class representing a dialog to add/edit an employeegroup.
	/// </summary>
	public partial class EmployeeGroupDetailDialog : Form {

		#region -_ Private Members _-

		private bool _createFlag;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the employeegroup associated
		/// with this <see cref="EmployeeGroupDetailDialog"/>.
		/// </summary>
		/// <value>The employeegroup to get or set.</value>
		public EmployeeGroup EmployeeGroup { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeGroupDetailDialog"/> class.
		/// </summary>
		public EmployeeGroupDetailDialog() {
			_createFlag = true;
			InitializeComponent();
			this.EmployeeGroup = new EmployeeGroup();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeGroupDetailDialog"/> class.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to use.</param>
		public EmployeeGroupDetailDialog( EmployeeGroup employeeGroup ){
			_createFlag = false;
			InitializeComponent();
			this.EmployeeGroup = employeeGroup;
		}

		#endregion

		#region -_ Form Event Handlers _-

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.EmployeeGroup.Name = nameTextBox.Client.Text;
			this.EmployeeGroup.Description = descriptionTextBox.Client.Text;
		}

		/// <summary>
		/// Handles the Load event of the EmployeeGroupDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void EmployeeGroupDetailDialog_Load( object sender , EventArgs e ) {
			nameTextBox.Client.Text = this.EmployeeGroup.Name;
			descriptionTextBox.Client.Text = this.EmployeeGroup.Description;

			dialogHeaderControl.MainText = _createFlag ? "Nieuwe personeelsgroep" : this.EmployeeGroup.Name;
			dialogHeaderControl.SubText = _createFlag ? "Een nieuwe personeelsgroep aanmaken..." : "Een bestaande personeelsgroep aanpassen...";

			ValidateAll();
		}

		/// <summary>
		/// Handles the TextChanged event of the nameTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nameTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		/// <summary>
		/// Handles the TextChanged event of the descriptionTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void descriptionTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		#endregion

		#region -_ Validation _-

		/// <summary>
		/// Validates all controls.
		/// </summary>
		private void ValidateAll() {
			bool nameIsValid = ValidateName();
			bool descriptionIsValid = ValidateDescription();
			okButton.Enabled = nameIsValid && descriptionIsValid;
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

		/// <summary>
		/// Validate the "description" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateDescription() {
			bool valueToReturn = !String.IsNullOrEmpty( descriptionTextBox.Client.Text );
			descriptionTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		#endregion

	}

}
