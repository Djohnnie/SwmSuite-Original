using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.Controls {

	public partial class CheckListControl : UserControl {

		#region -_ Private Members _-

		private CheckListItemCollection _items = new CheckListItemCollection();

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the checklist items of this checklist control.
		/// </summary>
		public CheckListItemCollection Items {
			get {
				return _items;
			}
		}

		#endregion

		#region -_ Public Events _-

		/// <summary>
		/// Event raised if a checklist item has been checked or unchecked.
		/// </summary>
		public event EventHandler<CheckListItemEventArgs> CheckListItemChanged;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="CheckListControl"/> class.
		/// </summary>
		public CheckListControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.BackColor = Color.Transparent;

			this.Items.CollectionChanged += new EventHandler<EventArgs>( Items_CollectionChanged );
		}

		#endregion

		#region -_ Private Methods _-

		/// <summary>
		/// Refresh the checkbox layout.
		/// </summary>
		private void RefreshCheckListItems() {
			this.Controls.Clear();
			int top = 0;
			foreach( CheckListItem checkListItem in this.Items ) {
				Rectangle bounds = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top + top , this.ClientRectangle.Width , 20 );
				top += 25;
				CheckBox checkBox = new CheckBox();
				checkBox.AutoSize = false;
				checkBox.Text = checkListItem.Text;
				checkBox.Tag = checkListItem;
				checkBox.Checked = checkListItem.Checked;
				checkBox.Bounds = bounds;
				checkBox.CheckedChanged += new EventHandler( checkBox_CheckedChanged );
				checkBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				this.Controls.Add( checkBox );
			}
		}

		/// <summary>
		/// Raises the CheckListItemChanged event if it is registered.
		/// </summary>
		/// <param name="item"></param>
		private void RaiseCheckListItemChanged( CheckListItem item ) {
			if( this.CheckListItemChanged != null ) {
				CheckListItemChanged( this , new CheckListItemEventArgs( item ) );
			}
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the CollectionChanged event of the Items control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void Items_CollectionChanged( object sender , EventArgs e ) {
			RefreshCheckListItems();
		}

		/// <summary>
		/// Handles the CheckedChanged event of the checkBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void checkBox_CheckedChanged( object sender , EventArgs e ) {
			CheckBox checkBox = sender as CheckBox;
			CheckListItem item = checkBox.Tag as CheckListItem;
			item.Checked = checkBox.Checked;
			RaiseCheckListItemChanged( item );
		}

		#endregion

	}

}
