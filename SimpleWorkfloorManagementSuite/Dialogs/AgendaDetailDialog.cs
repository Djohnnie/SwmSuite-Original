using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;


namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	public partial class AgendaDetailDialog : Form {
	
		#region -_ Private Members _-

		private bool _createFlag;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the agenda associated
		/// with this <see cref="AgendaDetailDialog"/>.
		/// </summary>
		/// <value>The agenda to get or set.</value>
		public Agenda Agenda { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AgendaDetailDialog"/> class.
		/// </summary>
		public AgendaDetailDialog() {
			_createFlag = true;
			InitializeComponent();
			this.Agenda = new Agenda();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AgendaDetailDialog"/> class.
		/// </summary>
		/// <param name="agendaf">The alert to use.</param>
		public AgendaDetailDialog( Agenda agenda ) {
			_createFlag = false;
			InitializeComponent();
			this.Agenda = agenda;
		}

		#endregion

		#region -_ Private Methods _-

		#endregion

		#region -_ Validation _-

		private void ValidateAll() {
			bool titleIsValid = ValidateTitle();
			bool descriptionIsValid = ValidateDescription();
			okButton.Enabled =
				titleIsValid &&
				descriptionIsValid;
		}

		/// <summary>
		/// Validate the "title" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateTitle() {
			bool valueToReturn = !String.IsNullOrEmpty( titleTextBox.Client.Text );
			titleTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "description" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateDescription() {
			bool valueToReturn = !String.IsNullOrEmpty( titleTextBox.Client.Text );
			titleTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		#endregion

		private void titleTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void descriptionTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void okButton_Click( object sender , EventArgs e ) {
			this.Agenda.Title = titleTextBox.Client.Text;
			this.Agenda.Description = descriptionTextBox.Client.Text;
			if( publicCheckBox.Checked ) {
				this.Agenda.Visibility = AppointmentVisibility.Public;
			}
			if( visibleCheckBox.Checked ) {
				this.Agenda.Visibility = AppointmentVisibility.Visible;
			}
			if( privateCheckBox.Checked ) {
				this.Agenda.Visibility = AppointmentVisibility.Private;
			}
			if( invisibleCheckBox.Checked ) {
				this.Agenda.Visibility = AppointmentVisibility.Invisible;
			}
			this.Agenda.OwnerEmployee = SwmSuitePrincipal.CurrentEmployee;
		}

		private void AgendaDetailDialog_Load( object sender , EventArgs e ) {
			titleTextBox.Client.Text = this.Agenda.Title;
			descriptionTextBox.Client.Text = this.Agenda.Description;
			switch( this.Agenda.Visibility ) {
				case AppointmentVisibility.Public: {
						publicCheckBox.Checked = true;
						break;
					}
				case AppointmentVisibility.Visible: {
						visibleCheckBox.Checked = true;
						break;
					}
				case AppointmentVisibility.Private: {
						privateCheckBox.Checked = true;
						break;
					}
				case AppointmentVisibility.Invisible: {
						invisibleCheckBox.Checked = true;
						break;
					}					
			}
			if( this.Agenda.Color1 == Color.White ) {
				colorPickerBox.BorderColor = Color.Black;
			} else {
				colorPickerBox.BorderColor = this.Agenda.Color1;
			}
			colorPickerBox.BackgroundColor1 = this.Agenda.Color2;
			colorPickerBox.BackgroundColor2 = this.Agenda.Color3;
			colorPickerBox.Invalidate();
			ValidateAll();
		}

		private void colorPickerBox_Click( object sender , EventArgs e ) {
			ColorSelectionDialog colorDialog = new ColorSelectionDialog();
			if( colorDialog.ShowDialog() == DialogResult.OK ) {
				this.Agenda.Color1 = colorDialog.Color1;
				this.Agenda.Color2 = colorDialog.Color2;
				this.Agenda.Color3 = colorDialog.Color3;
				colorPickerBox.BorderColor = colorDialog.Color1;
				colorPickerBox.BackgroundColor1 = colorDialog.Color2;
				colorPickerBox.BackgroundColor2 = colorDialog.Color3;
				colorPickerBox.Invalidate();
			}
		}

	}

}
