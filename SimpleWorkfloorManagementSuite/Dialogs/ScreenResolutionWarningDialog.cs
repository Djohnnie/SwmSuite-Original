using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	/// <summary>
	/// 
	/// </summary>
	public partial class ScreenResolutionWarningDialog : Form {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ScreenResolutionWarningDialog"/> class.
		/// </summary>
		public ScreenResolutionWarningDialog() {
			InitializeComponent();
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows the screen resolution warning dialog.
		/// </summary>
		public static void ShowScreenResolutionWarningDialog() {
			ScreenResolutionWarningDialog dialog = new ScreenResolutionWarningDialog();
			dialog.ShowDialog();
		}

		#endregion

	}

}
