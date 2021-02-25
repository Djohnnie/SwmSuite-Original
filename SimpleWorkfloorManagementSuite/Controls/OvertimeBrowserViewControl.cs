using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	public partial class OvertimeBrowserViewControl : UserControl {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Events _-

		/// <summary>
		/// Occurs when the overtime selection has changed.
		/// </summary>
		public event EventHandler<SelectedOvertimeEntryChangedEventArgs> SelectedOvertimeEntryChanged;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="OvertimeBrowserViewControl"/> class.
		/// </summary>
		public OvertimeBrowserViewControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Associate a collection of overtime entries with this <see cref="OvertimeBrowserViewControl"/>.
		/// </summary>
		/// <param name="overtimeEntries">The collection of overtime entries to set</param>
		public void SetOvertimeEntries( OvertimeEntryCollection overtimeEntries ) {
			browserViewControl.Items.Clear();
			foreach( OvertimeEntry overtimeEntry in overtimeEntries ) {
				ListViewItem newListViewItem = new ListViewItem();
				switch( overtimeEntry.OvertimeStatus ) {
					case SwmSuite.Data.Common.OvertimeStatus.Pending: {
							newListViewItem.ImageIndex = 0;
							break;
						}
					case SwmSuite.Data.Common.OvertimeStatus.Accepted: {
							newListViewItem.ImageIndex = 1;
							break;
						}
					case SwmSuite.Data.Common.OvertimeStatus.Denied: {
							newListViewItem.ImageIndex = 2;
							break;
						}
				}
				newListViewItem.SubItems.Add( overtimeEntry.DateTimeStart.ToShortDateString() );
				newListViewItem.SubItems.Add( overtimeEntry.DateTimeStart.ToShortTimeString() + " - " + overtimeEntry.DateTimeEnd.ToShortTimeString() );
				if( overtimeEntry.Commissioner != null ) {
					newListViewItem.SubItems.Add( overtimeEntry.Commissioner.FullName );
				} else {
					newListViewItem.SubItems.Add( "" );
				}
				newListViewItem.Tag = overtimeEntry;
				this.browserViewControl.Items.Add( newListViewItem );
			}
		}

		#endregion

		#region -_ Event Handling _-

		/// <summary>
		/// Handles the SelectedIndexChanged event of the browserViewControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void browserViewControl_SelectedIndexChanged( object sender , EventArgs e ) {
			if( browserViewControl.SelectedItems.Count == 1 ) {
				OvertimeEntry overtimeEntry = (OvertimeEntry)browserViewControl.SelectedItems[0].Tag;
				if( this.SelectedOvertimeEntryChanged != null ) {
					SelectedOvertimeEntryChanged( this , new SelectedOvertimeEntryChangedEventArgs( overtimeEntry ) );
				}
			} else {
				if( this.SelectedOvertimeEntryChanged != null ) {
					SelectedOvertimeEntryChanged( this , new SelectedOvertimeEntryChangedEventArgs( null ) );
				}
			}
		}

		#endregion

	}

}
