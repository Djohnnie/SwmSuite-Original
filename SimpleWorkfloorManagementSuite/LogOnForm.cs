using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;
using SimpleWorkfloorManagementSuite.Controls;
using SimpleWorkfloorManagementSuite.Dialogs;

using SwmSuite.Presentation.Drawing.Office2007Renderer;
using SwmSuite.Framework.Exceptions;
using SwmSuite.Presentation.ConnectionWizard;

namespace SimpleWorkfloorManagementSuite {

	public partial class LogOnForm : Form {

		#region -_ Private Members _-

		private EmployeeGroup _selectedEmployeeGroup;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LogOnForm() {
			InitializeComponent();
		}

		#endregion

		/// <summary>
		/// Handles the Load event of the LogOnForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void LogOnForm_Load( object sender , EventArgs e ) {
			this.Cursor = Cursors.WaitCursor;

			// Initialize status bar.
			statusControl.LeftCaption = "Simple Workfloor Management Suite " + Application.ProductVersion;
			statusControl.MiddleCaption = "Geen gebruiker ingelogd";
			statusControl.RightCaption = DateTime.Today.ToLongDateString();

			// Load Alerts.
			alertBackgroundWorker.RunWorkerAsync( null );
			//AlertCollection alerts = _alertFacade.GetGlobalAlerts();
			//marqueeControl.MarqueeText = alerts.ToString();

			// Load EmployeeGroups
			employeeGroupBackgroundWorker.RunWorkerAsync();

			// Check for autologin.
			try {
				Employee employee =
					SwmSuiteFacade.EmployeeFacade.GetDefaultEmployeeForMachineName( Environment.MachineName );
				if( employee != null ) {
					LoginLog loginLog = new LoginLog();
					loginLog.DateTime = DateTime.Now;
					loginLog.Employee = employee;
					SwmSuiteFacade.LoggingFacade.LogLogin( loginLog );
					SwmSuitePrincipal.CurrentEmployee = employee;
					SwmSuitePrincipal.CurrentEmployeeGroup = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroupForEmployee( employee );
					MainForm mainForm = new MainForm();
					mainForm.ShowDialog();
					mainForm.Dispose();
				}
			} catch( SwmSuiteException exception ) {
				if( exception.Error != SwmSuiteError.BusinessError ) {
					ErrorDialog.ShowErrorDialog( exception.Message );
				}
			}
		}

		/// <summary>
		/// Handles the Paint event of the LogOnForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void LogOnForm_Paint( object sender , PaintEventArgs e ) {
			LinearGradientBrush brush = new LinearGradientBrush( this.ClientRectangle , Color.FromArgb( 215 , 229 , 247 ) , Color.FromArgb( 215 , 229 , 247 ) , LinearGradientMode.Horizontal );
			e.Graphics.FillRectangle( brush , this.ClientRectangle );
			brush.Dispose();
		}

		/// <summary>
		/// Handles the SelectionChanged event of the employeeGroupTabControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabSelectionEventArgs"/> instance containing the event data.</param>
		private void employeeGroupTabControl_SelectionChanged( object sender , SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabSelectionEventArgs e ) {
			loginGroup.SetEmployees( ( (EmployeeGroup)e.Item.Tag ).Employees );
			if( !alertBackgroundWorker.IsBusy ) {
				alertBackgroundWorker.RunWorkerAsync( e.Item.Tag );
			}
			_selectedEmployeeGroup = (EmployeeGroup)e.Item.Tag;
		}

		/// <summary>
		/// Handles the Login event of the loginGroup control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SimpleWorkfloorManagementSuite.Controls.LoginGroupLoginEventArgs"/> instance containing the event data.</param>
		private void loginGroup_Login( object sender , LoginGroupLoginEventArgs e ) {
			UserPasswordDialog userPasswordDialog = new UserPasswordDialog( e.Employee.FirstName + " " + e.Employee.Name );
			if( userPasswordDialog.ShowDialog() == DialogResult.OK ) {
				try {
					if( SwmSuiteFacade.UserFacade.AuthenticateUser( e.Employee.UserName , userPasswordDialog.Password ) ) {
						LoginLog loginLog = new LoginLog();
						loginLog.DateTime = DateTime.Now;
						loginLog.Employee = e.Employee;
						SwmSuiteFacade.LoggingFacade.LogLogin( loginLog );
						SwmSuitePrincipal.CurrentEmployee = SwmSuiteFacade.EmployeeFacade.GetEmployeeDetail( e.Employee.SysId );
						SwmSuitePrincipal.CurrentEmployee.Password = userPasswordDialog.Password;
						SwmSuitePrincipal.CurrentEmployeeGroup = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroupDetail( _selectedEmployeeGroup.SysId );
						SwmSuiteFacade.ClearFacade();
						MainForm mainForm = new MainForm();
						mainForm.ShowDialog();
						mainForm.Dispose();
					} else {
						ErrorDialog.ShowErrorDialog( "U heeft een foutief wachtwoord opgegeven." );
					}
				} catch( SwmSuiteException exception ) {
					ErrorDialog.ShowErrorDialog( exception.Message );
				}
			}
		}

		/// <summary>
		/// Handles the MouseClick event of the statusControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void statusControl_MouseClick( object sender , MouseEventArgs e ) {
			if( e.Button == MouseButtons.Right ) {
				contextMenuStrip.Renderer = new Office2007Renderer();
				contextMenuStrip.Show( this.PointToScreen( Cursor.Position ) , ToolStripDropDownDirection.BelowLeft );
			}
		}

		/// <summary>
		/// Handles the Click event of the infoToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void infoToolStripMenuItem_Click( object sender , EventArgs e ) {
			AboutDialog.Show();
		}

		/// <summary>
		/// Handles the Click event of the connectionToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void connectionToolStripMenuItem_Click( object sender , EventArgs e ) {
			ConnectionDialog connectionDialog = new ConnectionDialog();
			if( connectionDialog.ShowDialog() == DialogResult.OK ) {
				Application.Restart();
			}
		}

		/// <summary>
		/// Handles the Click event of the exitToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void exitToolStripMenuItem_Click( object sender , EventArgs e ) {
			if( MessageBox.Show( "Bent u zeker dat u SwmSuite wilt beëindigen?" , "Simple Workfloor Managent Suite" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes ) {
				Application.Exit();
			}
		}

		/// <summary>
		/// Handles the Click event of the quitButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void quitButton_Click( object sender , EventArgs e ) {
			Application.Exit();
		}

		/// <summary>
		/// Handles the Click event of the infoButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void infoButton_Click( object sender , EventArgs e ) {
			AboutDialog.Show();
		}

		/// <summary>
		/// Handles the DoWork event of the employeeGroupBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void employeeGroupBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			e.Result = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups();
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the employeeGroupBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void employeeGroupBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			EmployeeGroupCollection employeeGroups = (EmployeeGroupCollection)e.Result;
			foreach( EmployeeGroup employeeGroup in employeeGroups ) {
				SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabItem newItem =
					new SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabItem( employeeGroup.Name , employeeGroup.Description );
				newItem.Tag = employeeGroup;
				employeeGroupTabControl.Items.Add( newItem );
				employeeGroupTabControl.Invalidate();
			}
			this.Cursor = Cursors.Default;
		}

		/// <summary>
		/// Handles the DoWork event of the alertBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void alertBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			AlertCollection alertsToReturn = new AlertCollection();
			if( e.Argument != null ) {
				EmployeeGroup employeeGroup = (EmployeeGroup)e.Argument;
				alertsToReturn.Add(
					SwmSuiteFacade.Alert.GetAlertsForEmployeeGroup( employeeGroup ) );
			} else {
				alertsToReturn.Add(
					SwmSuiteFacade.Alert.GetGlobalAlerts() );
			}
			e.Result = alertsToReturn;
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the alertBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void alertBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			AlertCollection alerts = (AlertCollection)e.Result;
			marqueeControl.MarqueeText = alerts.ToString();
			marqueeControl.Reset();
		}

		/// <summary>
		/// Handles the DoWork event of the loginBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void loginBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {

		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the loginBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void loginBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {

		}

	}

}
