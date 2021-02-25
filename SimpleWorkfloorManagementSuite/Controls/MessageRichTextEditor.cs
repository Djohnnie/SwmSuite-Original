using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Presentation.Drawing.Office2007Renderer;

namespace SimpleWorkfloorManagementSuite.Controls {

	public partial class MessageRichTextEditor : UserControl {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the RTF.
		/// </summary>
		/// <value>The RTF.</value>
		public String Rtf {
			get {
				return richTextBox.Rtf;
			}
			set {
				richTextBox.Rtf = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="MessageRichTextEditor"/> class.
		/// </summary>
		public MessageRichTextEditor() {
			InitializeComponent();
			toolStrip.Renderer = new Office2007Renderer();
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Initializes the reply.
		/// </summary>
		/// <param name="originalMessage">The original message.</param>
		public void InitializeReply( SwmSuite.Data.BusinessObjects.Message originalMessage ) {
			richTextBox.Rtf = originalMessage.Contents;
			richTextBox.Select( 0 , 0 );
			richTextBox.SelectedText = "\n\n\n----- Origineel Bericht ----\n\n";
			richTextBox.Select( 0 , 0 );
			richTextBox.Select();
		}

		#endregion

		#region -_ Event Handling _-

		/// <summary>
		/// Handles the Click event of the cutToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void cutToolStripButton_Click( object sender , EventArgs e ) {
			richTextBox.Cut();
		}

		/// <summary>
		/// Handles the Click event of the copyToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void copyToolStripButton_Click( object sender , EventArgs e ) {
			richTextBox.Copy();
		}

		/// <summary>
		/// Handles the Click event of the pasteToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void pasteToolStripButton_Click( object sender , EventArgs e ) {
			richTextBox.Paste();
		}

		/// <summary>
		/// Handles the Click event of the boldToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void boldToolStripButton_Click( object sender , EventArgs e ) {
			boldToolStripButton.Checked = !boldToolStripButton.Checked;
			SetFontStyle( FontStyle.Bold , boldToolStripButton.Checked );
		}

		/// <summary>
		/// Handles the Click event of the italicToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void italicToolStripButton_Click( object sender , EventArgs e ) {
			italicToolStripButton.Checked = !italicToolStripButton.Checked;
			SetFontStyle( FontStyle.Italic , italicToolStripButton.Checked );
		}

		/// <summary>
		/// Handles the Click event of the underlineToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void underlineToolStripButton_Click( object sender , EventArgs e ) {
			underlineToolStripButton.Checked = !underlineToolStripButton.Checked;
			SetFontStyle( FontStyle.Underline , underlineToolStripButton.Checked );
		}

		/// <summary>
		/// Handles the Click event of the justifyLeftToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void justifyLeftToolStripButton_Click( object sender , EventArgs e ) {
			richTextBox.SelectionAlignment = HorizontalAlignment.Left;
			justifyLeftToolStripButton.Checked = true;
			justifyCenterToolStripButton.Checked = false;
			justifyRightToolStripButton.Checked = false;
		}

		/// <summary>
		/// Handles the Click event of the justifyCenterToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void justifyCenterToolStripButton_Click( object sender , EventArgs e ) {
			richTextBox.SelectionAlignment = HorizontalAlignment.Center;
			justifyLeftToolStripButton.Checked = false;
			justifyCenterToolStripButton.Checked = true;
			justifyRightToolStripButton.Checked = false;
		}

		/// <summary>
		/// Handles the Click event of the justifyRightToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void justifyRightToolStripButton_Click( object sender , EventArgs e ) {
			richTextBox.SelectionAlignment = HorizontalAlignment.Right;
			justifyLeftToolStripButton.Checked = false;
			justifyCenterToolStripButton.Checked = false;
			justifyRightToolStripButton.Checked = true;
		}

		/// <summary>
		/// Handles the Click event of the bulletsToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void bulletsToolStripButton_Click( object sender , EventArgs e ) {
			bulletsToolStripButton.Checked = !bulletsToolStripButton.Checked;
			richTextBox.SelectionBullet = bulletsToolStripButton.Checked;
		}

		/// <summary>
		/// Handles the Click event of the textColorToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void textColorToolStripButton_Click( object sender , EventArgs e ) {
			ColorDialog colorDialog = new ColorDialog();
			if( colorDialog.ShowDialog() == DialogResult.OK ) {
				richTextBox.SelectionColor = colorDialog.Color;
			}
		}

		/// <summary>
		/// Handles the Click event of the backgroundColorToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void backgroundColorToolStripButton_Click( object sender , EventArgs e ) {
			ColorDialog colorDialog = new ColorDialog();
			if( colorDialog.ShowDialog() == DialogResult.OK ) {
				richTextBox.SelectionBackColor = colorDialog.Color;
			}
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the fontToolStripComboBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void fontToolStripComboBox_SelectedIndexChanged( object sender , EventArgs e ) {
			SetFont( fontToolStripComboBox.Text );
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the sizeToolStripComboBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void sizeToolStripComboBox_SelectedIndexChanged( object sender , EventArgs e ) {
			SetFontSize( float.Parse( sizeToolStripComboBox.Text ) );
		}

		/// <summary>
		/// Handles the Load event of the MessageRichTextEditor control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MessageRichTextEditor_Load( object sender , EventArgs e ) {
			sizeToolStripComboBox.Items.AddRange( new string[] { "8" , "9" , "10" , "11" , "12" , "14" , "16" , "18" , "20" , "22" , "24" , "26" , "28" , "36" , "48" , "72" } );
		}

		/// <summary>
		/// Handles the SelectionChanged event of the richTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void richTextBox_SelectionChanged( object sender , EventArgs e ) {
			UpdateToolbar();
		}

		#endregion

		#region -_ Helper Methods _-

		private void UpdateToolbar() {
			// Get the font, fontsize and style to apply to the toolbar buttons
			Font selectionFont = GetFontDetails();
			// Set font style buttons to the styles applying to the entire selection
			FontStyle selectionStyle = selectionFont.Style;

			//Set all the style buttons using the gathered style
			boldToolStripButton.Checked = selectionFont.Bold; //bold button
			italicToolStripButton.Checked = selectionFont.Italic; //italic button
			underlineToolStripButton.Checked = selectionFont.Underline; //underline button
			justifyLeftToolStripButton.Checked = ( richTextBox.SelectionAlignment == HorizontalAlignment.Left ); //justify left
			justifyCenterToolStripButton.Checked = ( richTextBox.SelectionAlignment == HorizontalAlignment.Center ); //justify center
			justifyRightToolStripButton.Checked = ( richTextBox.SelectionAlignment == HorizontalAlignment.Right ); //justify right

			//Check the correct font
			fontToolStripComboBox.SelectedItem = selectionFont.FontFamily.Name;
			
			//Check the correct font size
			sizeToolStripComboBox.SelectedItem = selectionFont.SizeInPoints.ToString();
		}

		private Font GetFontDetails() {
			RichTextBox tempRichTextBox = new RichTextBox();

			int selectionStart = richTextBox.SelectionStart;
			int selectionLength = richTextBox.SelectionLength;
			int rtbTempStart = 0;

			if( selectionLength <= 1 ) {
				// Return the selection or default font
				if( richTextBox.SelectionFont != null )
					return richTextBox.SelectionFont;
				else
					return richTextBox.Font;
			}

			// Step through the selected text one char at a time	
			// after setting defaults from first char
			tempRichTextBox.Rtf = richTextBox.SelectedRtf;

			//Turn everything on so we can turn it off one by one
			FontStyle replystyle =
				FontStyle.Bold | FontStyle.Italic | FontStyle.Strikeout | FontStyle.Underline;

			// Set reply font, size and style to that of first char in selection.
			tempRichTextBox.Select( rtbTempStart , 1 );
			string replyfont = tempRichTextBox.SelectionFont.Name;
			float replyfontsize = tempRichTextBox.SelectionFont.Size;
			replystyle = replystyle & tempRichTextBox.SelectionFont.Style;

			// Search the rest of the selection
			for( int i = 1 ; i < selectionLength ; ++i ) {
				tempRichTextBox.Select( rtbTempStart + i , 1 );

				// Check reply for different style
				replystyle = replystyle & tempRichTextBox.SelectionFont.Style;

				// Check font
				if( replyfont != tempRichTextBox.SelectionFont.FontFamily.Name )
					replyfont = "";

				// Check font size
				if( replyfontsize != tempRichTextBox.SelectionFont.Size )
					replyfontsize = (float)0.0;
			}

			// Now set font and size if more than one font or font size was selected
			if( replyfont == "" )
				replyfont = tempRichTextBox.Font.FontFamily.Name;

			if( replyfontsize == 0.0 )
				replyfontsize = tempRichTextBox.Font.Size;

			// generate reply font
			Font reply
				= new Font( replyfont , replyfontsize , replystyle );

			return reply;
		}

		private void SetFontStyle( FontStyle style , bool set ) {
			RichTextBox tempRichTextBox = new RichTextBox();

			int selectionStart = richTextBox.SelectionStart;
			int selectionLength = richTextBox.SelectionLength;
			int rtbTempStart = 0;

			if( selectionLength <= 1 && richTextBox.SelectionFont != null ) {
				//add or remove style 
				if( set ) {
					richTextBox.SelectionFont = new Font( richTextBox.SelectionFont , richTextBox.SelectionFont.Style | style );
				} else {
					richTextBox.SelectionFont = new Font( richTextBox.SelectionFont , richTextBox.SelectionFont.Style & ~style );
				}
				return;
			}

			tempRichTextBox.Rtf = richTextBox.SelectedRtf;
			for( int i = 0 ; i < selectionLength ; ++i ) {
				tempRichTextBox.Select( rtbTempStart + i , 1 );
				if( set ) {
					tempRichTextBox.SelectionFont = new Font( tempRichTextBox.SelectionFont , tempRichTextBox.SelectionFont.Style | style );
				} else {
					tempRichTextBox.SelectionFont = new Font( tempRichTextBox.SelectionFont , tempRichTextBox.SelectionFont.Style & ~style );
				}
			}

			// Replace & reselect
			tempRichTextBox.Select( rtbTempStart , selectionLength );
			richTextBox.SelectedRtf = tempRichTextBox.SelectedRtf;
			richTextBox.Select( selectionStart , selectionLength );
			richTextBox.Focus();
		}

		private void SetFont( String fontFamily ) {
			RichTextBox tempRichTextBox = new RichTextBox();

			int selectionStart = richTextBox.SelectionStart;
			int selectionLength = richTextBox.SelectionLength;
			int rtbTempStart = 0;

			if( selectionLength <= 1 && richTextBox.SelectionFont != null ) {
				richTextBox.SelectionFont =
					new Font( fontFamily , richTextBox.SelectionFont.Size , richTextBox.SelectionFont.Style );
				return;
			}

			tempRichTextBox.Rtf = richTextBox.SelectedRtf;
			for( int i = 0 ; i < selectionLength ; ++i ) {
				tempRichTextBox.Select( rtbTempStart + i , 1 );
				tempRichTextBox.SelectionFont = new Font( fontFamily , tempRichTextBox.SelectionFont.Size , tempRichTextBox.SelectionFont.Style );
			}

			// Replace & reselect
			tempRichTextBox.Select( rtbTempStart , selectionLength );
			richTextBox.SelectedRtf = tempRichTextBox.SelectedRtf;
			richTextBox.Select( selectionStart , selectionLength );
			richTextBox.Focus();
		}

		private void SetFontSize( float size ) {
			RichTextBox tempRichTextBox = new RichTextBox();

			int selectionStart = richTextBox.SelectionStart;
			int selectionLength = richTextBox.SelectionLength;
			int rtbTempStart = 0;

			if( selectionLength <= 1 && richTextBox.SelectionFont != null ) {
				richTextBox.SelectionFont =
					new Font( richTextBox.SelectionFont.FontFamily , size , richTextBox.SelectionFont.Style );
				return;
			}

			tempRichTextBox.Rtf = richTextBox.SelectedRtf;
			for( int i = 0 ; i < selectionLength ; ++i ) {
				tempRichTextBox.Select( rtbTempStart + i , 1 );
				tempRichTextBox.SelectionFont = new Font( tempRichTextBox.SelectionFont.FontFamily , size , tempRichTextBox.SelectionFont.Style );
			}

			// Replace & reselect
			tempRichTextBox.Select( rtbTempStart , selectionLength );
			richTextBox.SelectedRtf = tempRichTextBox.SelectedRtf;
			richTextBox.Select( selectionStart , selectionLength );
			richTextBox.Focus();
		}

		#endregion

	}

}