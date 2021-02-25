using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using System.Text.RegularExpressions;

namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	public partial class EmployeeDetailDialog : Form {

		#region -_ Private Members _-

		private bool _createFlag;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the employeegroup associated
		/// with this <see cref="EmployeeGroupDetailDialog"/>.
		/// </summary>
		/// <value>The employee to get or set.</value>
		public Employee Employee { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeDetailDialog"/> class.
		/// </summary>
		public EmployeeDetailDialog() {
			_createFlag = true;
			InitializeComponent();
			this.Employee = new Employee();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeDetailDialog"/> class.
		/// </summary>
		/// <param name="employee">The employee to use.</param>
		public EmployeeDetailDialog( Employee employee ) {
			_createFlag = false;
			InitializeComponent();
			this.Employee = employee;
		}

		#endregion

		#region -_ Form Event Handlers _-

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.Employee.Name = nameTextBox.Client.Text;
			this.Employee.FirstName = firstNameTextBox.Client.Text;
			this.Employee.Address = addressTextBox.Client.Text;

			this.Employee.PrivatePhoneNumber = privatePhoneTextBox.Client.Text;
			this.Employee.WorkPhoneNumber = workPhoneTextBox.Client.Text;
			this.Employee.CellPhoneNumber = cellPhoneTextBox.Client.Text;

			this.Employee.EmailAddress1 = email1TextBox.Client.Text;
			this.Employee.EmailAddress2 = email2TextBox.Client.Text;
			this.Employee.EmailAddress3 = email3TextBox.Client.Text;
			this.Employee.EmailAddress4 = email4TextBox.Client.Text;
			this.Employee.EmailAddress5 = email5TextBox.Client.Text;

			this.Employee.UserName = userNameTextBox.Client.Text;
			this.Employee.Password = password1TextBox.Client.Text;

			this.Employee.Administrator = administratorCheckBox.Checked;
		}

		/// <summary>
		/// Handles the Load event of the EmployeeDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void EmployeeDetailDialog_Load( object sender , EventArgs e ) {
			nameTextBox.Client.Text = this.Employee.Name;
			firstNameTextBox.Client.Text = this.Employee.FirstName;
			addressTextBox.Client.Text = this.Employee.Address;

			privatePhoneTextBox.Client.Text = this.Employee.PrivatePhoneNumber;
			workPhoneTextBox.Client.Text = this.Employee.WorkPhoneNumber;
			cellPhoneTextBox.Client.Text = this.Employee.CellPhoneNumber;

			email1TextBox.Client.Text = this.Employee.EmailAddress1;
			email2TextBox.Client.Text = this.Employee.EmailAddress2;
			email3TextBox.Client.Text = this.Employee.EmailAddress3;
			email4TextBox.Client.Text = this.Employee.EmailAddress4;
			email5TextBox.Client.Text = this.Employee.EmailAddress5;

			administratorCheckBox.Checked = this.Employee.Administrator;

			dialogHeaderControl.MainText = _createFlag ? "Nieuwe personeelslid" : this.Employee.FirstName + " " + this.Employee.Name;
			dialogHeaderControl.SubText = _createFlag ? "Een nieuw personeelslid aanmaken..." : "Een bestaand personeelslid aanpassen...";

			ValidateAll();
		}

		#endregion

		#region -_ Validation _-

		private void ValidateAll() {
			bool nameIsValid = ValidateName();
			bool firstNameIsValid = ValidateFirstName();
			bool userNameIsValid = ValidateUserName();
			bool passwordIsValid = ValidatePassword();
			bool addressIsValid = ValidateAddress();
			bool privatePhoneIsValid = ValidatePrivatePhone();
			bool workPhoneIsValid = ValidateWorkPhone();
			bool cellPhoneIsValid = ValidateCellPhone();
			bool email1IsValid = ValidateEmail1();
			bool email2IsValid = ValidateEmail2();
			bool email3IsValid = ValidateEmail3();
			bool email4IsValid = ValidateEmail4();
			bool email5IsValid = ValidateEmail5();
			okButton.Enabled =
				nameIsValid &&
				firstNameIsValid &&
				userNameIsValid &&
				passwordIsValid &&
				addressIsValid &&
				privatePhoneIsValid &&
				workPhoneIsValid &&
				cellPhoneIsValid &&
				email1IsValid &&
				email2IsValid &&
				email3IsValid &&
				email4IsValid &&
				email5IsValid;
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
		/// Validate the "firstname" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateFirstName() {
			bool valueToReturn = !String.IsNullOrEmpty( firstNameTextBox.Client.Text );
			firstNameTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "username" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateUserName() {
			bool valueToReturn = _createFlag ? 
				!String.IsNullOrEmpty( userNameTextBox.Client.Text ) : true;
			userNameTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "password" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidatePassword() {
			bool valueToReturn = _createFlag ?
				!String.IsNullOrEmpty( password1TextBox.Client.Text ) && !String.IsNullOrEmpty( password2TextBox.Client.Text ) && password2TextBox.Client.Text.Equals( password1TextBox.Client.Text )
				:
				password2TextBox.Client.Text.Equals( password1TextBox.Client.Text );
			password1TextBox.DoError( !valueToReturn );
			password2TextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "address" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateAddress() {
			bool valueToReturn = true;
			addressTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "private phone" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidatePrivatePhone() {
			bool valueToReturn = true;
			privatePhoneTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "work phone" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateWorkPhone() {
			bool valueToReturn = true;
			workPhoneTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "cell phone" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateCellPhone() {
			bool valueToReturn = true;
			cellPhoneTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "email1" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateEmail1() {
			bool valueToReturn =
				String.IsNullOrEmpty( email1TextBox.Client.Text ) ||
				Regex.IsMatch( email1TextBox.Client.Text , @"^.+?@.+?\..+?$" );
			email1TextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "email1" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateEmail2() {
			bool valueToReturn =
				String.IsNullOrEmpty( email2TextBox.Client.Text ) ||
				Regex.IsMatch( email2TextBox.Client.Text , @"^.+?@.+?\..+?$" );
			email2TextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "email1" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateEmail3() {
			bool valueToReturn =
				String.IsNullOrEmpty( email3TextBox.Client.Text ) ||
				Regex.IsMatch( email3TextBox.Client.Text , @"^.+?@.+?\..+?$" );
			email3TextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "email1" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateEmail4() {
			bool valueToReturn =
				String.IsNullOrEmpty( email4TextBox.Client.Text ) ||
				Regex.IsMatch( email4TextBox.Client.Text , @"^.+?@.+?\..+?$" );
			email4TextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "email1" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateEmail5() {
			bool valueToReturn = 
				String.IsNullOrEmpty( email5TextBox.Client.Text ) ||
				Regex.IsMatch( email5TextBox.Client.Text , @"^.+?@.+?\..+?$" );
			email5TextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		#endregion

		private void nameTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void firstNameTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void userNameTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void password1TextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void password2TextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void addressTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void privatePhoneTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void workPhoneTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void cellPhoneTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void email1TextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void email2TextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void email3TextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void email4TextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void email5TextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}
	}
}
