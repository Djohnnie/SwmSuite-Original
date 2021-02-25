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
	
	public partial class CountryDetailDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		/// <value>The country.</value>
		public Country Country { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="CountryDetailDialog"/> class.
		/// </summary>
		public CountryDetailDialog() {
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CountryDetailDialog"/> class.
		/// </summary>
		/// <param name="country">The country.</param>
		public CountryDetailDialog( Country country )
			: this() {
			this.Country = country;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the CountryDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void CountryDetailDialog_Load( object sender , EventArgs e ) {
			if( this.Country != null ) {
				nameTextBox.Client.Text = this.Country.Name;
			}

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
			this.Country.Name = nameTextBox.Client.Text;
		}

		#endregion

		#region -_ Validation _-

		private void Validate() {
			okButton.Enabled = ValidateName();
		}

		private bool ValidateName() {
			bool valid = !String.IsNullOrEmpty( nameTextBox.Client.Text );
			nameTextBox.DoError( !valid );
			return valid;
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows the country detail dialog for adding.
		/// </summary>
		/// <returns>True if succesfull, false otherwise.</returns>
		public static bool ShowCountryDetailDialogForAdding() {
			bool result = false;
			CountryDetailDialog dialog = new CountryDetailDialog( new Country() );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				try {
					SwmSuiteFacade.CountryFacade.CreateCountry( dialog.Country );
					result = true;
				} catch( SwmSuiteException e ) {
					ErrorDialog.ShowErrorDialog( e.Message );
				} catch {
				}
			}
			return result;
		}

		/// <summary>
		/// Shows the country detail dialog for editing.
		/// </summary>
		/// <param name="country">The country.</param>
		/// <returns>True if succesfull, false otherwise.</returns>
		public static bool ShowCountryDetailDialogForEditing( Country country ) {
			bool result = false;
			CountryDetailDialog dialog = new CountryDetailDialog( country );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				try {
					SwmSuiteFacade.CountryFacade.UpdateCountry( dialog.Country );
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
