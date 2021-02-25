using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class AlertDetailDialog : Form {

		#region -_ Private Members _-

		private bool _createFlag;

		private EmployeeCollection _employees;
		private EmployeeGroupCollection _employeeGroups;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the alert associated
		/// with this <see cref="AlertDetailDialog"/>.
		/// </summary>
		/// <value>The alert to get or set.</value>
		public Alert Alert { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AlertDetailDialog"/> class.
		/// </summary>
		public AlertDetailDialog() {
			_createFlag = true;
			InitializeComponent();
			this.Alert = new Alert();
			_employees = new EmployeeCollection();
			_employeeGroups = new EmployeeGroupCollection();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AlertDetailDialog"/> class.
		/// </summary>
		/// <param name="alert">The alert to use.</param>
		public AlertDetailDialog( Alert alert ) {
			_createFlag = false;
			InitializeComponent();
			this.Alert = alert;
			_employees = new EmployeeCollection();
			_employees.Add( alert.Employees );
			_employeeGroups = new EmployeeGroupCollection();
			_employeeGroups.Add( alert.EmployeeGroups );
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

		private static String EmployeeGroupLinkCollectionToString( EmployeeGroupCollection employeeGroupLinks ) {
			String stringToReturn = "";
			foreach( EmployeeGroup employeeGroup in employeeGroupLinks ) {
				bool lastItem = employeeGroupLinks.IndexOf( employeeGroup ) == employeeGroupLinks.Count - 1;
				stringToReturn += employeeGroup.Name + ( lastItem ? "" : "; " );
			}
			return stringToReturn;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the AlertDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void AlertDetailDialog_Load( object sender , EventArgs e ) {
			messageTextBox.Client.Text = this.Alert.Message;

			employeeTextBox.Client.Text = EmployeeLinkCollectionToString( _employees );
			employeeGroupTextBox.Client.Text = EmployeeGroupLinkCollectionToString( _employeeGroups );

			ValidateAll();
		}

		/// <summary>
		/// Handles the Click event of the browseForEmployeeButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void browseForEmployeeButton_Click( object sender , EventArgs e ) {
			BrowserForEmployeeDialog dialog = new BrowserForEmployeeDialog( _employees );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				_employees = dialog.Employees;
				employeeTextBox.Client.Text = EmployeeLinkCollectionToString( _employees );
			}
		}

		/// <summary>
		/// Handles the Click event of the browseForEmployeeGroupButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void browseForEmployeeGroupButton_Click( object sender , EventArgs e ) {
			BrowserForEmployeeGroupDialog dialog = new BrowserForEmployeeGroupDialog( _employeeGroups );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				_employeeGroups = dialog.EmployeeGroups;
				employeeGroupTextBox.Client.Text = EmployeeGroupLinkCollectionToString( _employeeGroups );
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.Alert.Message = messageTextBox.Client.Text;

			this.Alert.Employees = _employees;
			this.Alert.EmployeeGroups = _employeeGroups;
		}

		/// <summary>
		/// Handles the TextChanged event of the messageTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void messageTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		#endregion

		#region -_ Validation _-

		private void ValidateAll() {
			bool messageIsValid = ValidateMessage();
			bool linksAreValid = ValidateLinks();
			okButton.Enabled =
				messageIsValid &&
				linksAreValid;
		}

		/// <summary>
		/// Validate the "message" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateMessage() {
			bool valueToReturn = !String.IsNullOrEmpty( messageTextBox.Client.Text );
			messageTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private bool ValidateLinks() {
			return true;
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Adds a new alert.
		/// </summary>
		/// <returns>True if succesfull, false otherwise.</returns>
		public static bool AddAlert() {
			bool returnValue = false;
			AlertDetailDialog dialog = new AlertDetailDialog();
			dialog.dialogHeaderControl.MainText = " Nieuwe aankondiging maken.";
			if( dialog.ShowDialog() == DialogResult.OK ) {
				SwmSuiteFacade.Alert.CreateAlert( dialog.Alert );
				returnValue = true;
			}
			return returnValue;
		}

		/// <summary>
		/// Edits the given alert.
		/// </summary>
		/// <param name="alert">The alert.</param>
		/// <returns>True if succesfull, false otherwise.</returns>
		public static bool EditAlert( Alert alert ) {
			bool returnValue = false;
			AlertDetailDialog dialog = new AlertDetailDialog( alert );
			dialog.dialogHeaderControl.MainText = " Bestaande aankondiging aanpassen.";
			if( dialog.ShowDialog() == DialogResult.OK ) {
				SwmSuiteFacade.Alert.CreateAlert( dialog.Alert );
				returnValue = true;
			}
			return returnValue;
		}

		#endregion

	}

}