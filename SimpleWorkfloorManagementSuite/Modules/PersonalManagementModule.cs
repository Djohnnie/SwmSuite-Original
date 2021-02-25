using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Proxy.Interface;
using SwmSuite.Framework;
using SwmSuite.Data.BusinessObjects;
using System.Threading;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SimpleWorkfloorManagementSuite.Dialogs;
using System.Collections.Specialized;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class PersonalManagementModule : UserControl {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="PersonalManagementModule"/> class.
		/// </summary>
		public PersonalManagementModule() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		#endregion

		#region -_ Public Methods _-

		public void RefreshData() {
			Employee employee = ServiceBroker.CreateBroker().CreateEmployeeFacade().GetEmployeeDetail( SwmSuitePrincipal.CurrentEmployee.SysId );

			// Load countries.
			CountryCollection countries = ServiceBroker.CreateBroker().CreateCountryFacade().GetCountries();
			foreach( Country country in countries ) {
				countryComboBox.Client.Items.Add( country );
			}

			// Select country.
			if( employee.ZipCode != null ) {
				foreach( Country country in countryComboBox.Client.Items ) {
					if( country.Name == employee.ZipCode.Country ) {
						countryComboBox.Client.SelectedItem = country;
					}
				}
			} else {
				//countryComboBox.Client.SelectedIndex = 0;
			}

			nameTextBox.Client.Text = employee.Name;
			firstNameTextBox.Client.Text = employee.FirstName;
			addressTextBox.Client.Text = employee.Address;

			privatePhoneTextBox.Client.Text = employee.PrivatePhoneNumber;
			workPhoneTextBox.Client.Text = employee.WorkPhoneNumber;
			cellPhoneTextBox.Client.Text = employee.CellPhoneNumber;
			email1TextBox.Client.Text = employee.EmailAddress1;
			email2TextBox.Client.Text = employee.EmailAddress2;
			email3TextBox.Client.Text = employee.EmailAddress3;
			email4TextBox.Client.Text = employee.EmailAddress4;
			email5TextBox.Client.Text = employee.EmailAddress5;

			//avatarBrowser.Visible = false;
			circularProgressControl.Visible = true;
			getAvatarsBackgroundWorker.RunWorkerAsync();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the PersonalManagementModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void PersonalManagementModule_Load( object sender , EventArgs e ) {
			personalDataPanel.Visible = true;
			userDataPanel.Visible = false;
			avatarPanel.Visible = false;
		}

		/// <summary>
		/// Handles the DoWork event of the getAvatarsBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void getAvatarsBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			Thread.Sleep( 2500 );
			AvatarCollection avatars = SwmSuiteFacade.AvatarFacade.GetAvatars();
			e.Result = avatars;
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the getAvatarsBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void getAvatarsBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			avatarBrowser.ClearImages();
			AvatarCollection avatars = (AvatarCollection)e.Result;
			int currentAvatarSysId = -1;
			if( SwmSuitePrincipal.CurrentEmployee.Avatar != null ) {
				currentAvatarSysId = SwmSuitePrincipal.CurrentEmployee.Avatar.SysId;
			}
			foreach( Avatar avatar in avatars ) {
				avatar.Image.Tag = avatar;
				avatarBrowser.AddImage( avatar.Image , avatar , avatar.SysId == currentAvatarSysId );
			}
			circularProgressControl.Visible = false;
			avatarBrowser.Visible = true;
		}

		/// <summary>
		/// Handles the Click event of the saveButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void saveButton_Click( object sender , EventArgs e ) {
			//Employee employee = SwmSuitePrincipal.CurrentEmployee;
			//employee.Name = nameTextBox.Client.Text;
			//employee.FirstName = firstNameTextBox.Client.Text;

			//employee.Address = addressTextBox.Client.Text;
			////employee.ZipCode = 

			//employee.PrivatePhoneNumber = privatePhoneTextBox.Client.Text;
			//employee.WorkPhoneNumber = workPhoneTextBox.Client.Text;
			//employee.CellPhoneNumber = cellPhoneTextBox.Client.Text;
			//employee.EmailAddress1 = email1TextBox.Client.Text;
			//employee.EmailAddress2 = email2TextBox.Client.Text;
			//employee.EmailAddress3 = email3TextBox.Client.Text;
			//employee.EmailAddress4 = email4TextBox.Client.Text;
			//employee.EmailAddress5 = email5TextBox.Client.Text;

			//if( avatarBrowser.SelectedImage != null ) {
			//   employee.Avatar = (Avatar)avatarBrowser.SelectedImage.Tag;
			//}

			//ServiceBroker.CreateBroker().CreateEmployeeFacade().UpdateEmployee( employee , SwmSuitePrincipal.CurrentEmployeeGroup );
		}

		/// <summary>
		/// Handles the Click event of the personalDataToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void personalDataToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllToolstripButton();
			personalDataToolStripButton.Checked = true;
			personalDataPanel.Visible = true;
			userDataPanel.Visible = false;
			avatarPanel.Visible = false;
		}

		/// <summary>
		/// Handles the Click event of the userDataToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void userDataToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllToolstripButton();
			userDataToolStripButton.Checked = true;
			personalDataPanel.Visible = false;
			userDataPanel.Visible = true;
			avatarPanel.Visible = false;
		}

		/// <summary>
		/// Handles the Click event of the avatarToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void avatarToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllToolstripButton();
			avatarToolStripButton.Checked = true;
			personalDataPanel.Visible = false;
			userDataPanel.Visible = false;
			avatarPanel.Visible = true;
		}

		/// <summary>
		/// Handles the Click event of the savePersonalDataButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void savePersonalDataButton_Click( object sender , EventArgs e ) {
			Cursor.Current = Cursors.WaitCursor;
			Employee employee = SwmSuitePrincipal.CurrentEmployee;

			employee.Name = nameTextBox.Client.Text;
			employee.FirstName = firstNameTextBox.Client.Text;
			employee.Address = addressTextBox.Client.Text;
			employee.PrivatePhoneNumber = privatePhoneTextBox.Client.Text;
			employee.WorkPhoneNumber = workPhoneTextBox.Client.Text;
			employee.CellPhoneNumber = cellPhoneTextBox.Client.Text;

			employee.EmailAddress1 = email1TextBox.Client.Text;
			employee.EmailAddress2 = email2TextBox.Client.Text;
			employee.EmailAddress3 = email3TextBox.Client.Text;
			employee.EmailAddress4 = email4TextBox.Client.Text;
			employee.EmailAddress5 = email5TextBox.Client.Text;

			//employee.ZipCode = 

			SwmSuitePrincipal.CurrentEmployee =
				ServiceBroker.CreateBroker().CreateEmployeeFacade().UpdateEmployee( employee , SwmSuitePrincipal.CurrentEmployeeGroup );
			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Handles the Click event of the saveUserData control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void saveUserData_Click( object sender , EventArgs e ) {
			if( password1TextBox.Client.Text.Equals( password2TextBox.Client.Text ) ) {
				if( !SwmSuiteFacade.EmployeeFacade.ChangePassword(
					SwmSuitePrincipal.CurrentEmployee.UserName , oldPasswordTextBox.Client.Text , password1TextBox.Client.Text ) ) {
					ErrorDialog.ShowErrorDialog( "Wijzigen wachtwoord is misslukt" );
				} else {
					oldPasswordTextBox.Client.Text = String.Empty;
					password1TextBox.Client.Text = String.Empty;
					password2TextBox.Client.Text = String.Empty;
				}
			} else {
				ErrorDialog.ShowErrorDialog( "Nieuw wachtwoord bevestiging komt niet overeen." );
			}
		}

		/// <summary>
		/// Handles the Click event of the saveAvatarButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void saveAvatarButton_Click( object sender , EventArgs e ) {
			Cursor.Current = Cursors.WaitCursor;
			Employee employee = SwmSuitePrincipal.CurrentEmployee;
			if( avatarBrowser.SelectedImage != null ) {
				employee.Avatar = (Avatar)avatarBrowser.SelectedImage.Tag;
			}
			SwmSuitePrincipal.CurrentEmployee =
				ServiceBroker.CreateBroker().CreateEmployeeFacade().UpdateEmployee( employee , SwmSuitePrincipal.CurrentEmployeeGroup );
			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region -_ Private Methods _-

		private void UncheckAllToolstripButton() {
			personalDataToolStripButton.Checked = false;
			userDataToolStripButton.Checked = false;
			avatarToolStripButton.Checked = false;
		}

		#endregion

		/// <summary>
		/// Handles the TextChanged event of the zipcodeTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void zipcodeTextBox_TextChanged( object sender , EventArgs e ) {
			if( String.IsNullOrEmpty( cityTextBox.Client.Text ) ) {
				Country country = countryComboBox.Client.SelectedItem as Country;
				if( country != null ) {
					ZipCodeCollection zipcodes = SearchZipCodeByCode( country , zipcodeTextBox.Client.Text );
					AutoCompleteStringCollection cities = new AutoCompleteStringCollection();
					foreach( ZipCode zipcode in zipcodes ) {
						cities.Add( zipcode.City );
					}
					zipcodeTextBox.Client.AutoCompleteCustomSource = cities;
				}
			}
		}

		/// <summary>
		/// Handles the TextChanged event of the cityTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void cityTextBox_TextChanged( object sender , EventArgs e ) {
			if( String.IsNullOrEmpty( zipcodeTextBox.Client.Text ) ) {
				Country country = countryComboBox.Client.SelectedItem as Country;
				if( country != null ) {
					ZipCodeCollection zipcodes = SearchZipCodeByCity( country , cityTextBox.Client.Text );
					foreach( ZipCode zipcode in zipcodes ) {
						zipcodeTextBox.Client.Text = zipcode.Code;
					}
				}
			}
		}

		private ZipCodeCollection SearchZipCodeByCode( Country country , String code ) {
			ZipCodeCollection zipcodes = new ZipCodeCollection();
			foreach( ZipCode zipcode in country.ZipCodes ) {
				if( zipcode.Code.Equals( code ) ) {
					zipcodes.Add( zipcode );
				}
			}
			return zipcodes;
		}

		private ZipCodeCollection SearchZipCodeByCity( Country country , String city ) {
			ZipCodeCollection zipcodes = new ZipCodeCollection();
			foreach( ZipCode zipcode in country.ZipCodes ) {
				if( zipcode.City.Equals( city ) ) {
					zipcodes.Add( zipcode );
				}
			}
			return zipcodes;
		}

	}

}
