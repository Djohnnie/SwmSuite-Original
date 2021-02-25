using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;
using SimpleWorkfloorManagementSuite.Dialogs;
using SwmSuite.Framework.Exceptions;

namespace SwmSuiteZipCodeManagement {

	public partial class MainForm : Form {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// </summary>
		public MainForm() {
			InitializeComponent();
			countryToolStrip.Renderer = new WindowsVistaRenderer();
			zipcodeToolStrip.Renderer = new WindowsVistaRenderer();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the MainForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MainForm_Load( object sender , EventArgs e ) {
			CountryCollection countries = SwmSuiteFacade.CountryFacade.GetCountries();
			RefreshCountries( countries );
		}

		/// <summary>
		/// Handles the Click event of the addEmployeeGroupToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void addEmployeeGroupToolstripButton_Click( object sender , EventArgs e ) {
			if( CountryDetailDialog.ShowCountryDetailDialogForAdding() ) {
				RefreshCountries( SwmSuiteFacade.CountryFacade.GetCountries() );
			}
		}

		/// <summary>
		/// Handles the Click event of the editEmployeeGroupToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editEmployeeGroupToolstripButton_Click( object sender , EventArgs e ) {
			if( countryBrowserView.SelectedItems.Count == 1 ) {
				Country selectedCountry = (Country)countryBrowserView.SelectedItems[0].Tag;
				if( CountryDetailDialog.ShowCountryDetailDialogForEditing( selectedCountry ) ) {
					RefreshCountries( SwmSuiteFacade.CountryFacade.GetCountries() );
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the deleteEmployeeGroupToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void deleteEmployeeGroupToolstripButton_Click( object sender , EventArgs e ) {
			if( countryBrowserView.SelectedItems.Count > 0 ) {
				if( QueryDialog.ShowQueryDialog( "Land(en)" , "bent u zeker dat u de geselecteerde landen wilt verwijderen?" ) == DialogResult.Yes ) {
					CountryCollection countries = new CountryCollection();
					foreach( ListViewItem selectedItem in countryBrowserView.SelectedItems ) {
						countries.Add( (Country)selectedItem.Tag );
					}
					try {
						SwmSuiteFacade.CountryFacade.RemoveCountries( countries );
						RefreshCountries( SwmSuiteFacade.CountryFacade.GetCountries() );
					} catch( SwmSuiteException exception ) {
						ErrorDialog.ShowErrorDialog( exception.Message );
					} catch {
					}
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the importToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void importToolStripButton_Click( object sender , EventArgs e ) {
			if( countryBrowserView.SelectedItems.Count == 1 ) {
				Country country = (Country)countryBrowserView.SelectedItems[0].Tag;
				OpenFileDialog dialog = new OpenFileDialog();
				if( dialog.ShowDialog() == DialogResult.OK ) {
					ZipCodeCollection zipcodes = ImportZipCode.ImportZipCodes( dialog.FileName );
					foreach( ZipCode zipcode in zipcodes ) {
						try {
							SwmSuiteFacade.ZipCodeFacade.CreateZipCode( zipcode , country );
						} catch {
						}
					}
					RefreshZipcodes( SwmSuiteFacade.ZipCodeFacade.GetZipCodesByCountry( country ) );
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the addEmployeeToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void addEmployeeToolstripButton_Click( object sender , EventArgs e ) {
			if( countryBrowserView.SelectedItems.Count == 1 ) {
				Country country = (Country)countryBrowserView.SelectedItems[0].Tag;
				if( ZipCodeDetailDialog.ShowZipCodeDetailDialogForAdding( country ) ) {
					RefreshZipcodes( SwmSuiteFacade.ZipCodeFacade.GetZipCodesByCountry( country ) );
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the editEmployeeToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editEmployeeToolstripButton_Click( object sender , EventArgs e ) {
			if( countryBrowserView.SelectedItems.Count == 1 ) {
				Country country = (Country)countryBrowserView.SelectedItems[0].Tag;
				if( zipcodeBrowserView.SelectedItems.Count == 1 ) {
					ZipCode selectedZipCode = (ZipCode)zipcodeBrowserView.SelectedItems[0].Tag;
					if( ZipCodeDetailDialog.ShowZipCodeDetailDialogForEditing( selectedZipCode , country ) ) {
						RefreshZipcodes( SwmSuiteFacade.ZipCodeFacade.GetZipCodesByCountry( country ) );
					}
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the deleteEmployeeToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void deleteEmployeeToolstripButton_Click( object sender , EventArgs e ) {
			if( countryBrowserView.SelectedItems.Count == 1 ) {
				Country country = (Country)countryBrowserView.SelectedItems[0].Tag;
				if( zipcodeBrowserView.SelectedItems.Count > 0 ) {
					if( QueryDialog.ShowQueryDialog( "Postcode(s)" , "bent u zeker dat u de geselecteerde postcodes wilt verwijderen?" ) == DialogResult.Yes ) {
						ZipCodeCollection zipcodes = new ZipCodeCollection();
						foreach( ListViewItem selectedItem in zipcodeBrowserView.SelectedItems ) {
							zipcodes.Add( (ZipCode)selectedItem.Tag );
						}
						try {
							SwmSuiteFacade.ZipCodeFacade.RemoveZipCodes( zipcodes );
							RefreshZipcodes( SwmSuiteFacade.ZipCodeFacade.GetZipCodesByCountry( country ) );
						} catch( SwmSuiteException exception ) {
							ErrorDialog.ShowErrorDialog( exception.Message );
						} catch {
						}
					}
				}
			}
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the employeeGroupBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void employeeGroupBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			if( countryBrowserView.SelectedItems.Count == 1 ) {
				addZipcodeToolstripButton.Enabled = true;
				editZipcodeToolstripButton.Enabled = false;
				deleteZipcodeToolstripButton.Enabled = false;
				importToolStripButton.Enabled = true;
			} else {
				addZipcodeToolstripButton.Enabled = false;
				editZipcodeToolstripButton.Enabled = false;
				deleteZipcodeToolstripButton.Enabled = false;
				importToolStripButton.Enabled = false;
			}

			if( countryBrowserView.SelectedItems.Count == 0 ) {
				addCountryToolstripButton.Enabled = true;
				editCountryToolstripButton.Enabled = false;
				deleteCountryToolstripButton.Enabled = false;
			} else if( countryBrowserView.SelectedItems.Count == 1 ) {
				addCountryToolstripButton.Enabled = true;
				editCountryToolstripButton.Enabled = true;
				deleteCountryToolstripButton.Enabled = true;
			} else {
				addCountryToolstripButton.Enabled = true;
				editCountryToolstripButton.Enabled = false;
				deleteCountryToolstripButton.Enabled = true;
			}

			if( countryBrowserView.SelectedItems.Count == 1 ) {
				Country country = (Country)countryBrowserView.SelectedItems[0].Tag;
				RefreshZipcodes( country.ZipCodes );
			} else {
				RefreshZipcodes( null );
			}
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the employeeBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void employeeBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			if( zipcodeBrowserView.SelectedItems.Count == 0 ) {
				addZipcodeToolstripButton.Enabled = true;
				editZipcodeToolstripButton.Enabled = false;
				deleteZipcodeToolstripButton.Enabled = false;
			} else if( zipcodeBrowserView.SelectedItems.Count == 1 ) {
				addZipcodeToolstripButton.Enabled = true;
				editZipcodeToolstripButton.Enabled = true;
				deleteZipcodeToolstripButton.Enabled = true;
			} else {
				addZipcodeToolstripButton.Enabled = true;
				editZipcodeToolstripButton.Enabled = false;
				deleteZipcodeToolstripButton.Enabled = true;
			}
		}

		/// <summary>
		/// Handles the DoWork event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {

		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {

		}

		#endregion

		#region -_ Helper Methods _-

		private void RefreshCountries( CountryCollection countries ) {
			countryBrowserView.Items.Clear();
			if( countries != null ) {
				foreach( Country country in countries ) {
					ListViewItem newCountryItem = new ListViewItem( country.Name );
					newCountryItem.Tag = country;
					countryBrowserView.Items.Add( newCountryItem );
				}
			}
		}

		private void RefreshZipcodes( ZipCodeCollection zipcodes ) {
			zipcodeBrowserView.Items.Clear();
			if( zipcodes != null ) {
				foreach( ZipCode zipcode in zipcodes ) {
					ListViewItem newCountryItem = new ListViewItem( new String[] { zipcode.Code , zipcode.City } );
					newCountryItem.Tag = zipcode;
					zipcodeBrowserView.Items.Add( newCountryItem );
				}
			}
		}

		#endregion

	}

}
