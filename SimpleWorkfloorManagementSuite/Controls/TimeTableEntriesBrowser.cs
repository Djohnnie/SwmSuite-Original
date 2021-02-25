using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Presentation.Common.BrowserView;
using SwmSuite.Data.BusinessObjects;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	public class TimeTableEntriesBrowser : BrowserViewControl {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableEntriesBrowser"/> class.
		/// </summary>
		public TimeTableEntriesBrowser() {
		}

		#endregion

		#region -_ Helper Methods _-

		#endregion

		#region -_ Event Handlers _-

		protected override void OnDrawSubItem( DrawListViewSubItemEventArgs e ) {
			TimeTableEntry timeTableEntry = e.Item.Tag as TimeTableEntry;
			if( timeTableEntry != null ) {
				if( timeTableEntry.TimeTablePurpose != null ) {
					e.SubItem.BackColor = timeTableEntry.TimeTablePurpose.Color2;
					e.SubItem.Tag = timeTableEntry.TimeTablePurpose.Color3;
				}
				base.OnDrawSubItem( e );
			}
			TimeTableTemplateEntry timeTableTemplateEntry = e.Item.Tag as TimeTableTemplateEntry;
			if( timeTableTemplateEntry != null ) {
				if( timeTableTemplateEntry.TimeTablePurpose != null ) {
					e.SubItem.BackColor = timeTableTemplateEntry.TimeTablePurpose.Color2;
					e.SubItem.Tag = timeTableTemplateEntry.TimeTablePurpose.Color3;
				}
				base.OnDrawSubItem( e );
			}
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Sets the time table data.
		/// </summary>
		/// <param name="timeTableEntries">The time table entries.</param>
		public void SetTimeTableData( TimeTableEntryCollection timeTableEntries ) {
			this.Items.Clear();
			foreach( TimeTableEntry entry in timeTableEntries ) {
				ListViewItem newListViewItem = new ListViewItem(
					new string[] { entry.From.ToShortTimeString() , entry.To.ToShortTimeString() , entry.TimeTablePurpose.Description } );
				newListViewItem.Tag = entry;
				this.Items.Add( newListViewItem );
			}
		}

		/// <summary>
		/// Sets the time table data.
		/// </summary>
		/// <param name="timeTableEntries">The time table entries.</param>
		public void SetTimeTableData( TimeTableTemplateEntryCollection timeTableEntries ) {
			this.Items.Clear();
			foreach( TimeTableTemplateEntry entry in timeTableEntries ) {
				ListViewItem newListViewItem = new ListViewItem(
					new string[] { entry.From.ToShortTimeString() , entry.To.ToShortTimeString() , entry.TimeTablePurpose.Description } );
				newListViewItem.Tag = entry;
				this.Items.Add( newListViewItem );
			}
		}

		#endregion

	}

}
