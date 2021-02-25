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
	
	public partial class LogoutNotificationDialog : Form {

		#region -_ Private Members _-

		private int _counter = 30;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="LogoutNotificationDialog"/> class.
		/// </summary>
		public LogoutNotificationDialog() {
			InitializeComponent();
		}

		#endregion

		#region -_ Form Event Handlers _-

		/// <summary>
		/// Handles the Load event of the LogoutNotificationDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void LogoutNotificationDialog_Load( object sender , EventArgs e ) {
			timer.Enabled = true;
			label2.Text = "U zal automatisch worden afgemeld over " + _counter.ToString() + " seconden.";
			dialogHeaderControl.MainText = SwmSuitePrincipal.CurrentEmployee.FullName + " afmelden";
		}

		/// <summary>
		/// Handles the Tick event of the timer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timer_Tick( object sender , EventArgs e ) {
			if( _counter > 0 ) {
				_counter--;
				label2.Text = "U zal automatisch worden afgemeld over " + _counter.ToString() + " seconden.";
			} else {
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows a new <see cref="LogoutNotificationDialog"/>.
		/// </summary>
		/// <returns>One of the <see cref="DialogResult"/> values.</returns>
		public static DialogResult Show() {
			LogoutNotificationDialog dialog = new LogoutNotificationDialog();
			return dialog.ShowDialog();
		}

		#endregion
	}
}
