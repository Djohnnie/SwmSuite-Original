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

	/// <summary>
	/// Usercontrol representing an overtime detail.
	/// </summary>
	public partial class OvertimeDetailControl : UserControl {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the overtime entry.
		/// </summary>
		/// <value>The overtime entry.</value>
		public OvertimeEntry OvertimeEntry { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the employee is displayed.
		/// </summary>
		/// <value><c>true</c> if the employee is displayed; otherwise, <c>false</c>.</value>
		public bool DisplayEmployee {
			get {
				return employeeTitleLabel.Visible;
			}
			set {
				employeeTitleLabel.Visible = value;
				employeeLabel.Visible = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="OvertimeDetailControl"/> class.
		/// </summary>
		public OvertimeDetailControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		#region -_ Public methods _-

		/// <summary>
		/// Sets the overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry.</param>
		public void SetOvertimeEntry( OvertimeEntry overtimeEntry ) {
			this.OvertimeEntry = overtimeEntry;
			if( overtimeEntry == null ) {
				dateLabel.Text = String.Empty;
				fromLabel.Text = String.Empty;
				toLabel.Text = String.Empty;
				commissionerLabel.Text = String.Empty;
				descriptionTextBox.Text = String.Empty;
				employeeLabel.Text = String.Empty;
				statusGroup.Status = SwmSuite.Presentation.Common.StatusGroup.StatusGroupStatus.Invalid;
				statusLabel.Text = "Onbekend";
			} else {
				dateLabel.Text = overtimeEntry.DateTimeStart.ToLongDateString();
				fromLabel.Text = overtimeEntry.DateTimeStart.ToShortTimeString();
				toLabel.Text = overtimeEntry.DateTimeEnd.ToShortTimeString();
				if( overtimeEntry.Commissioner != null ) {
					commissionerLabel.Text = overtimeEntry.Commissioner.FullName;
				}
				if( overtimeEntry.Employee != null ) {
					employeeLabel.Text = overtimeEntry.Employee.FullName;
				}
				descriptionTextBox.Text = overtimeEntry.Description;
				switch( overtimeEntry.OvertimeStatus ) {
					case SwmSuite.Data.Common.OvertimeStatus.Pending: {
							statusGroup.Status = SwmSuite.Presentation.Common.StatusGroup.StatusGroupStatus.Warn;
							statusLabel.Text = "In behandeling...";
							break;
						}
					case SwmSuite.Data.Common.OvertimeStatus.Accepted: {
							statusGroup.Status = SwmSuite.Presentation.Common.StatusGroup.StatusGroupStatus.Good;
							statusLabel.Text = "Aanvaard";
							break;
						}
					case SwmSuite.Data.Common.OvertimeStatus.Denied: {
							statusGroup.Status = SwmSuite.Presentation.Common.StatusGroup.StatusGroupStatus.Bad;
							statusLabel.Text = "Geweigerd";
							break;
						}
				}
			}
			Invalidate();
		}

		#endregion

	}

}
