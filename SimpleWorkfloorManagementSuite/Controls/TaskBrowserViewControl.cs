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

	public partial class TaskBrowserViewControl : UserControl {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Events _-

		/// <summary>
		/// Occurs when the task selection has changed.
		/// </summary>
		public event EventHandler<SelectedTaskChangedEventArgs> SelectedTaskChanged;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TaskBrowserViewControl"/> class.
		/// </summary>
		public TaskBrowserViewControl() {
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
		/// Associate a collection of tasks with this <see cref="TaskBrowserViewControl"/>.
		/// </summary>
		/// <param name="tasks">The collection of tasks to set</param>
		public void SetTasks( TaskCollection tasks ) {
			browserViewControl.Items.Clear();
			foreach( Task task in tasks ) {
				ListViewItem newListViewItem = new ListViewItem();
				if( task.IsPending ) {
					newListViewItem.ImageIndex = 0;
				}
				if( task.IsFinished ) {
					newListViewItem.ImageIndex = 1;
				}
				if( task.IsFailed ) {
					newListViewItem.ImageIndex = 2;
				}
				if( task.IsOverDue ) {
					newListViewItem.ImageIndex = 3;
				}
				newListViewItem.SubItems.Add( task.Title );
				if( task.Commissioner != null ) {
					newListViewItem.SubItems.Add( task.Commissioner.FullName );
				} else {
					newListViewItem.SubItems.Add( "" );
				}
				if( task.Deadline.HasValue ) {
					newListViewItem.SubItems.Add( task.Deadline.Value.ToShortDateString() );
				} else {
					newListViewItem.SubItems.Add( "Geen deadline" );
				}
				newListViewItem.Tag = task;
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
			Task selectedTask = null;
			if( browserViewControl.SelectedItems.Count == 1 ) {
				selectedTask = (Task)browserViewControl.SelectedItems[0].Tag;
			}
			if( this.SelectedTaskChanged != null ) {
				SelectedTaskChanged( this , new SelectedTaskChangedEventArgs( selectedTask ) );
			}
		}

		#endregion

	}

}
