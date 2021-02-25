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
	/// A dialog for picking colorschemes.
	/// </summary>
	public partial class ColorSelectionDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the first color.
		/// </summary>
		public Color Color1 { get; set; }

		/// <summary>
		/// Gets or sets the second color.
		/// </summary>
		public Color Color2 { get; set; }

		/// <summary>
		/// Gets or sets the third color.
		/// </summary>
		public Color Color3 { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ColorSelectionDialog"/> class.
		/// </summary>
		public ColorSelectionDialog() {
			InitializeComponent();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the colorBox01 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorBox01_Click( object sender , EventArgs e ) {
			this.Color1 = colorBox01.BorderColor;
			this.Color2 = colorBox01.BackgroundColor1;
			this.Color3 = colorBox01.BackgroundColor2;
			SelectClose();
		}

		/// <summary>
		/// Handles the Click event of the colorBox02 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorBox02_Click( object sender , EventArgs e ) {
			this.Color1 = colorBox02.BorderColor;
			this.Color2 = colorBox02.BackgroundColor1;
			this.Color3 = colorBox02.BackgroundColor2;
			SelectClose();
		}

		/// <summary>
		/// Handles the Click event of the colorBox03 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorBox03_Click( object sender , EventArgs e ) {
			this.Color1 = colorBox03.BorderColor;
			this.Color2 = colorBox03.BackgroundColor1;
			this.Color3 = colorBox03.BackgroundColor2;
			SelectClose();
		}

		/// <summary>
		/// Handles the Click event of the colorBox04 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorBox04_Click( object sender , EventArgs e ) {
			this.Color1 = colorBox04.BorderColor;
			this.Color2 = colorBox04.BackgroundColor1;
			this.Color3 = colorBox04.BackgroundColor2;
			SelectClose();
		}

		/// <summary>
		/// Handles the Click event of the colorBox05 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorBox05_Click( object sender , EventArgs e ) {
			this.Color1 = colorBox05.BorderColor;
			this.Color2 = colorBox05.BackgroundColor1;
			this.Color3 = colorBox05.BackgroundColor2;
			SelectClose();
		}

		/// <summary>
		/// Handles the Click event of the colorBox06 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorBox06_Click( object sender , EventArgs e ) {
			this.Color1 = colorBox06.BorderColor;
			this.Color2 = colorBox06.BackgroundColor1;
			this.Color3 = colorBox06.BackgroundColor2;
			SelectClose();
		}

		/// <summary>
		/// Handles the Click event of the colorBox07 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorBox07_Click( object sender , EventArgs e ) {
			this.Color1 = colorBox07.BorderColor;
			this.Color2 = colorBox07.BackgroundColor1;
			this.Color3 = colorBox07.BackgroundColor2;
			SelectClose();
		}

		/// <summary>
		/// Handles the Click event of the colorBox08 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorBox08_Click( object sender , EventArgs e ) {
			this.Color1 = colorBox08.BorderColor;
			this.Color2 = colorBox08.BackgroundColor1;
			this.Color3 = colorBox08.BackgroundColor2;
			SelectClose();
		}

		/// <summary>
		/// Handles the Click event of the colorBox09 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorBox09_Click( object sender , EventArgs e ) {
			this.Color1 = colorBox09.BorderColor;
			this.Color2 = colorBox09.BackgroundColor1;
			this.Color3 = colorBox09.BackgroundColor2;
			SelectClose();
		}

		/// <summary>
		/// Handles the Click event of the colorBox10 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void colorBox10_Click( object sender , EventArgs e ) {
			this.Color1 = colorBox10.BorderColor;
			this.Color2 = colorBox10.BackgroundColor1;
			this.Color3 = colorBox10.BackgroundColor2;
			SelectClose();
		}

		#endregion

		#region -_ Private Methods _-

		/// <summary>
		/// Close the dialog with an OK dialogresult.
		/// </summary>
		private void SelectClose() {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		#endregion

	}

}
