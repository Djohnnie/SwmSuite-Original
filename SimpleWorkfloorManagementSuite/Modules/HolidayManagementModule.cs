using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;
using SwmSuite.Presentation.Drawing.VistaRenderer;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class HolidayManagementModule : UserControl {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>The year.</value>
		public int Year { get; set; }

		#endregion

		#region -_ Construction _-

		public HolidayManagementModule() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Year = DateTime.Today.Year;
		}

		#endregion

		#region -_ Public Methods _-

		public void RefreshData() {
			RefreshTreeView();
		}

		#endregion

		#region -_ Private Methods _-

		private void RefreshTreeView() {
			employeeTreeView.Nodes.Clear();

			EmployeeGroupCollection employeeGroups = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups();
			EmployeeCollection employees = employeeGroups.GetEmployees();

			OvertimeEntryCollection allOvertimeEntries =
				SwmSuiteFacade.HolidayFacade.GetOvertimeEntries( employees , this.Year );

			// Create root node.
			TreeNode rootNode = new TreeNode( "Iedereen" );
			rootNode.Tag = allOvertimeEntries;
			rootNode.ImageIndex = 0;
			rootNode.SelectedImageIndex = 0;

			foreach( EmployeeGroup employeeGroup in employeeGroups ) {

				TreeNode employeeGroupTreeNode = new TreeNode( employeeGroup.Name );
				employeeGroupTreeNode.Tag = allOvertimeEntries.GetOvertimeEntries( employeeGroup.Employees );
				employeeGroupTreeNode.ImageIndex = 1;
				employeeGroupTreeNode.SelectedImageIndex = 1;

				foreach( Employee employee in employeeGroup.Employees ) {
					TreeNode employeeTreeNode = new TreeNode( employee.FullName );
					employeeTreeNode.Tag = allOvertimeEntries.GetOvertimeEntries( employee );
					employeeTreeNode.ImageIndex = 2;
					employeeTreeNode.SelectedImageIndex = 2;
					employeeGroupTreeNode.Nodes.Add( employeeTreeNode );
				}

				rootNode.Nodes.Add( employeeGroupTreeNode );
			}

			employeeTreeView.Nodes.Add( rootNode );
			employeeTreeView.ExpandAll();
			employeeTreeView.SelectedNode = rootNode;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the AfterSelect event of the employeeTreeView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
		private void employeeTreeView_AfterSelect( object sender , TreeViewEventArgs e ) {
			OvertimeEntryCollection overtimeEntries = (OvertimeEntryCollection)e.Node.Tag;
			overtimeBrowserView.SetOvertimeEntries( overtimeEntries );
		}

		#endregion

		/// <summary>
		/// Handles the Load event of the HolidayManagementModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void HolidayManagementModule_Load( object sender , EventArgs e ) {
			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		/// <summary>
		/// Handles the SelectedOvertimeEntryChanged event of the overtimeBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SimpleWorkfloorManagementSuite.Controls.SelectedOvertimeEntryChangedEventArgs"/> instance containing the event data.</param>
		private void overtimeBrowserView_SelectedOvertimeEntryChanged( object sender , SimpleWorkfloorManagementSuite.Controls.SelectedOvertimeEntryChangedEventArgs e ) {
			if( e.OvertimeEntry != null ) {
				acceptToolStripButton.Enabled = true;
				denyToolStripButton.Enabled = true;
			} else {
				acceptToolStripButton.Enabled = false;
				denyToolStripButton.Enabled = false;
			}

			overtimeDetail.SetOvertimeEntry( e.OvertimeEntry );
		}

		/// <summary>
		/// Handles the Click event of the acceptToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void acceptToolStripButton_Click( object sender , EventArgs e ) {
			SwmSuiteFacade.HolidayFacade.AcceptOvertimeEntry(
				overtimeDetail.OvertimeEntry );
			RefreshTreeView();
		}

		/// <summary>
		/// Handles the Click event of the denyToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void denyToolStripButton_Click( object sender , EventArgs e ) {
			SwmSuiteFacade.HolidayFacade.DenyOvertimeEntry(
				overtimeDetail.OvertimeEntry );
			RefreshTreeView();
		}

		/// <summary>
		/// Handles the Click event of the previousYearToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void previousYearToolStripButton_Click( object sender , EventArgs e ) {
			this.Year--;
			yearToolStripLabel.Text = this.Year.ToString();
			RefreshTreeView();
		}

		/// <summary>
		/// Handles the Click event of the nextYearToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nextYearToolStripButton_Click( object sender , EventArgs e ) {
			this.Year++;
			yearToolStripLabel.Text = this.Year.ToString();
			RefreshTreeView();
		}

	}

}
