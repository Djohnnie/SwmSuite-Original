using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	public partial class TimeTablePurposeDetailDialog : Form {

		#region -_ Private Members _-

		private bool _createFlag;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the timetable purpose associated
		/// with this <see cref="TimeTablePurposeDetailDialog"/>.
		/// </summary>
		/// <value>The agenda to get or set.</value>
		public TimeTablePurpose TimeTablePurpose { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTablePurposeDetailDialog"/> class.
		/// </summary>
		public TimeTablePurposeDetailDialog() {
			_createFlag = true;
			InitializeComponent();
			this.TimeTablePurpose = new TimeTablePurpose();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTablePurposeDetailDialog"/> class.
		/// </summary>
		/// <param name="timeTablePurpose">The time table purpose.</param>
		public TimeTablePurposeDetailDialog( TimeTablePurpose timeTablePurpose ) {
			_createFlag = false;
			InitializeComponent();
			this.TimeTablePurpose = timeTablePurpose;
		}

		#endregion

		#region -_ Event Handling _-

		/// <summary>
		/// Handles the Click event of the colorPickerBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorPickerBox_Click( object sender , EventArgs e ) {
			ColorSelectionDialog colorDialog = new ColorSelectionDialog();
			if( colorDialog.ShowDialog() == DialogResult.OK ) {
				this.TimeTablePurpose.Color1 = colorDialog.Color1;
				this.TimeTablePurpose.Color2 = colorDialog.Color2;
				this.TimeTablePurpose.Color3 = colorDialog.Color3;
				colorPickerBox.BorderColor = colorDialog.Color1;
				colorPickerBox.BackgroundColor1 = colorDialog.Color2;
				colorPickerBox.BackgroundColor2 = colorDialog.Color3;
				colorPickerBox.Invalidate();
			}
		}

		/// <summary>
		/// Handles the Load event of the TimeTablePurposeDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTablePurposeDetailDialog_Load( object sender , EventArgs e ) {
			descriptionTextBox.Client.Text = this.TimeTablePurpose.Description;
			if( this.TimeTablePurpose.Color1 == Color.White ) {
				colorPickerBox.BorderColor = Color.Black;
			} else {
				colorPickerBox.BorderColor = this.TimeTablePurpose.Color1;
			}
			colorPickerBox.BackgroundColor1 = this.TimeTablePurpose.Color2;
			colorPickerBox.BackgroundColor2 = this.TimeTablePurpose.Color3;
			colorPickerBox.Invalidate();
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

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.TimeTablePurpose.Description = descriptionTextBox.Client.Text;
			this.TimeTablePurpose.Color1 = colorPickerBox.BorderColor;
			this.TimeTablePurpose.Color2 = colorPickerBox.BackgroundColor1;
			this.TimeTablePurpose.Color3 = colorPickerBox.BackgroundColor2;
		}

		#endregion

		#region -_ Validation _-

		private void ValidateAll() {
			bool descriptionIsValid = ValidateDescription();
			okButton.Enabled = descriptionIsValid;
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
