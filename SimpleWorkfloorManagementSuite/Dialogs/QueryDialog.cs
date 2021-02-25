using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	public partial class QueryDialog : Form {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="QueryDialog"/> class.
		/// </summary>
		public QueryDialog() {
			InitializeComponent();
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows the query dialog.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="question">The question.</param>
		/// <returns></returns>
		public static DialogResult ShowQueryDialog( String title , String question ) {
			QueryDialog dialog = new QueryDialog();
			dialog.dialogHeaderControl.MainText = " " + title;
			dialog.errorLabel.Text = question;
			return dialog.ShowDialog();
		}

		#endregion

	}

}
