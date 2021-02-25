using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard {
	
	public partial class SwmSuiteAdminWizardContent1 : UserControl {

		#region -_ Child Definitions _-

		public enum Selection {

			None,

			Register,

			Exit
			
		}

		#endregion

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		public Selection CurrentSelection { get; set; }

		#endregion

		#region -_ Construction _-

		public SwmSuiteAdminWizardContent1() {
			InitializeComponent();
			this.CurrentSelection = Selection.None;
		}

		#endregion

		#region -_ Public Methods _-

		public bool CheckSelection() {
			bool toReturn = false;
			switch( this.CurrentSelection ) {
				case Selection.None: {
					MessageBox.Show( "Je moet een selectie maken." , "SwmSuite Opmerking" , MessageBoxButtons.OK , MessageBoxIcon.Information );
					break;
				}
				case Selection.Register: {
					toReturn = true;
					break;
				}
				case Selection.Exit: {
					toReturn = true;
					break;
				}
			}
			return toReturn;
		}

		#endregion

		#region -_ Events _-

		private void registerRadioButton_CheckedChanged( object sender , EventArgs e ) {
			if( registerRadioButton.Checked ) {
				this.CurrentSelection = Selection.Register;
			}
		}

		private void exitRadioButton_CheckedChanged( object sender , EventArgs e ) {
			if( exitRadioButton.Checked ) {
				this.CurrentSelection = Selection.Exit;
			}
		}

		#endregion
	}
}
