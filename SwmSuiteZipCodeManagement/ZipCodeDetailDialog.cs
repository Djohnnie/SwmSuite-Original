using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;
using SwmSuite.Framework.Exceptions;
using SimpleWorkfloorManagementSuite.Dialogs;

namespace SwmSuiteZipCodeManagement {

	public partial class ZipCodeDetailDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the zip code.
		/// </summary>
		/// <value>The zip code.</value>
		public ZipCode ZipCode { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ZipCodeDetailDialog"/> class.
		/// </summary>
		public ZipCodeDetailDialog() {
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZipCodeDetailDialog"/> class.
		/// </summary>
		/// <param name="zipcode">The zipcode.</param>
		public ZipCodeDetailDialog( ZipCode zipcode )
			: this() {
			this.ZipCode = zipcode;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the ZipCodeDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void ZipCodeDetailDialog_Load( object sender , EventArgs e ) {
			if( this.ZipCode != null ) {
				codeTextBox.Client.Text = this.ZipCode.Code;
				nameTextBox.Client.Text = this.ZipCode.City;
			}

			Validate();
		}

		/// <summary>
		/// Handles the TextChanged event of the codeTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void codeTextBox_TextChanged( object sender , EventArgs e ) {
			Validate();
		}

		/// <summary>
		/// Handles the TextChanged event of the nameTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nameTextBox_TextChanged( object sender , EventArgs e ) {
			Validate();
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			if( this.ZipCode == null ) {
				this.ZipCode = new ZipCode();
			}
			this.ZipCode.Code = codeTextBox.Client.Text;
			this.ZipCode.City = nameTextBox.Client.Text;
		}

		#endregion

		#region -_ Validation _-

		private void Validate() {
			bool codeIsValid = ValidateCode();
			bool nameIsValid = ValidateName();
			okButton.Enabled = codeIsValid && nameIsValid;
		}

		private bool ValidateCode() {
			bool valid = !String.IsNullOrEmpty( codeTextBox.Client.Text );
			codeTextBox.DoError( !valid );
			return valid;
		}

		private bool ValidateName() {
			bool valid = !String.IsNullOrEmpty( nameTextBox.Client.Text );
			nameTextBox.DoError( !valid );
			return valid;
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows the zipcode detail dialog for adding.
		/// </summary>
		/// <returns>True if succesfull, false otherwise.</returns>
		public static bool ShowZipCodeDetailDialogForAdding( Country country ) {
			bool result = false;
			ZipCode zipcode = new ZipCode();
			ZipCodeDetailDialog dialog = new ZipCodeDetailDialog( zipcode );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				try {
					SwmSuiteFacade.ZipCodeFacade.CreateZipCode( dialog.ZipCode , country);
					result = true;
				} catch( SwmSuiteException e ) {
					ErrorDialog.ShowErrorDialog( e.Message );
				} catch {
				}
			}
			return result;
		}

		/// <summary>
		/// Shows the zipcode detail dialog for editing.
		/// </summary>
		/// <param name="zipcode">The zipcode.</param>
		/// <param name="country">The country.</param>
		/// <returns>True if succesfull, false otherwise.</returns>
		public static bool ShowZipCodeDetailDialogForEditing( ZipCode zipcode , Country country ) {
			bool result = false;
			ZipCodeDetailDialog dialog = new ZipCodeDetailDialog( zipcode );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				try {
					SwmSuiteFacade.ZipCodeFacade.UpdateZipCode( dialog.ZipCode,country );
					result = true;
				} catch( SwmSuiteException e ) {
					ErrorDialog.ShowErrorDialog( e.Message );
				} catch {
				}
			}
			return result;
		}

		#endregion

	}

}
