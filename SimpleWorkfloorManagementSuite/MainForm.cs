using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Presentation.Common.ModuleWindowMenu;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SimpleWorkfloorManagementSuite.Dialogs;

namespace SimpleWorkfloorManagementSuite {

	/// <summary>
	/// Form representing the main window of the application.
	/// </summary>
	public partial class MainForm : Form {

		#region -_ Private Members _-

		private ModuleWindowMenuItem _messageMenuItem;
		private ModuleWindowMenuItem _agendaMenuItem;
		private ModuleWindowMenuItem _timeTableMenuItem;
		private ModuleWindowMenuItem _holidayMenuItem;
		private ModuleWindowMenuItem _taskMenuItem;
		private ModuleWindowMenuItem _personalManagementMenuItem;
		private ModuleWindowMenuItem _staffManagementMenuItem;
		private ModuleWindowMenuItem _alertManagementMenuItem;
		private ModuleWindowMenuItem _timeTableManagementMenuItem;
		private ModuleWindowMenuItem _holidayManagementMenuItem;
		private ModuleWindowMenuItem _taskManagementMenuItem;
		private ModuleWindowMenuItem _loggingMenuItem;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// </summary>
		public MainForm() {
			InitializeComponent();
			HideAllModules();
		}

		#endregion

		#region -_ Form Event Handlers _-

		/// <summary>
		/// Handles the Load event of the MainForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MainForm_Load( object sender , EventArgs e ) {
			InitializeMenu();

			LoadMenu();

			alertBackgroundWorker.RunWorkerAsync();

			headerText.Caption = "T h u i s p a g i n a";

			InitializeAllModules();

			statusControl.MiddleCaption = SwmSuitePrincipal.CurrentEmployee.FullName + " ingelogd";
			statusControl.RightCaption = DateTime.Today.ToLongDateString();

			homeModule.Initialize();

			if( SwmSuitePrincipal.CurrentEmployee.Settings != null ) {
				applicationIdle.IdleTime = new TimeSpan( 0 , SwmSuitePrincipal.CurrentEmployee.Settings.LogoutTimeout , 0 );
			} else {
				applicationIdle.IdleTime = new TimeSpan( 0 , 2 , 0 );
			}

			applicationIdle.Start();
		}

		/// <summary>
		/// Handles the MenuItemClicked event of the moduleWindowMenu control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SwmSuite.Presentation.Common.ModuleWindowMenu.ModuleWindowMenuEventArgs"/> instance containing the event data.</param>
		private void moduleWindowMenu_MenuItemClicked( object sender , ModuleWindowMenuEventArgs e ) {
			if( e.MenuItem == _messageMenuItem ) {
				LoadMessageModule();
			}
			if( e.MenuItem == _agendaMenuItem ) {
				LoadAgendaModule();
			}
			if( e.MenuItem == _timeTableMenuItem ) {
				LoadTimeTableModule();
			}
			if( e.MenuItem == _holidayMenuItem ) {
				LoadHolidayModule();
			}
			if( e.MenuItem == _taskMenuItem ) {
				LoadTaskModule();
			}
			if( e.MenuItem == _personalManagementMenuItem ) {
				LoadPersonalManagementModule();
			}
			if( e.MenuItem == _alertManagementMenuItem ) {
				LoadAlertManagementModule();
			}
			if( e.MenuItem == _staffManagementMenuItem ) {
				LoadStaffManagementModule();
			}
			if( e.MenuItem == _timeTableManagementMenuItem ) {
				LoadTimeTableManagementModule();
			}
			if( e.MenuItem == _holidayManagementMenuItem ) {
				LoadHolidayManagementModule();
			}
			if( e.MenuItem == _taskManagementMenuItem ) {
				LoadTaskManagementModule();
			}
			if( e.MenuItem == _loggingMenuItem ) {
				LoadLoggingModule();
			}
		}

		/// <summary>
		/// Handles the MessageNotificationClicked event of the homeModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void homeModule_MessageNotificationClicked( object sender , EventArgs e ) {
			_messageMenuItem.Selected = true;
			LoadMessageModule();
			moduleWindowMenu.Invalidate();
		}

		/// <summary>
		/// Handles the AgendaNotificationClicked event of the homeModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void homeModule_AgendaNotificationClicked( object sender , EventArgs e ) {
			_agendaMenuItem.Selected = true;
			LoadAgendaModule();
			moduleWindowMenu.Invalidate();
		}

		/// <summary>
		/// Handles the TimeTableNotificationClicked event of the homeModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void homeModule_TimeTableNotificationClicked( object sender , EventArgs e ) {
			_timeTableMenuItem.Selected = true;
			LoadTimeTableModule();
			moduleWindowMenu.Invalidate();
		}

		/// <summary>
		/// Handles the HolidayNotificationClicked event of the homeModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void homeModule_HolidayNotificationClicked( object sender , EventArgs e ) {
			_holidayMenuItem.Selected = true;
			LoadHolidayModule();
			moduleWindowMenu.Invalidate();
		}

		/// <summary>
		/// Handles the TaskNotificationClicked event of the homeModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void homeModule_TaskNotificationClicked( object sender , EventArgs e ) {
			_taskMenuItem.Selected = true;
			LoadTaskModule();
			moduleWindowMenu.Invalidate();
		}

		#endregion

		#region -_ Private Methods _-

		private void InitializeMenu() {
			_messageMenuItem = new ModuleWindowMenuItem() {
				Title = "Berichten" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Berichten"
			};
			_agendaMenuItem = new ModuleWindowMenuItem() {
				Title = "Agenda" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Agenda"
			};
			_timeTableMenuItem = new ModuleWindowMenuItem() {
				Title = "Uurrooster" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Uurrooster"
			};
			_holidayMenuItem = new ModuleWindowMenuItem() {
				Title = "Verlof" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Verlof"
			};
			_taskMenuItem = new ModuleWindowMenuItem() {
				Title = "Taken" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Taken"
			};
			_personalManagementMenuItem = new ModuleWindowMenuItem() {
				Title = "Persoonlijk beheer" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Persoonlijk beheer"
			};
			_alertManagementMenuItem = new ModuleWindowMenuItem() {
				Title = "Aankondigingen" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Aankondigingen"
			};
			_staffManagementMenuItem = new ModuleWindowMenuItem() {
				Title = "Beheer van Personeel" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Beheer van Personeel"
			};
			_timeTableManagementMenuItem = new ModuleWindowMenuItem() {
				Title = "Beheer van Uurrooster" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Beheer van Uurrooster"
			};
			_holidayManagementMenuItem = new ModuleWindowMenuItem() {
				Title = "Beheer van Verlof" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Beheer van Verlof"
			};
			_taskManagementMenuItem = new ModuleWindowMenuItem() {
				Title = "Beheer van Taken" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Beheer van Taken"
			};
			_loggingMenuItem = new ModuleWindowMenuItem() {
				Title = "Logboeken" ,
				Selected = false ,
				Hovered = false ,
				Enabled = true ,
				Description = "Logboeken"
			};
		}

		private void LoadMenu() {
			//int numberOfMenuItems = 6;
			moduleWindowMenu.MenuItems.Add( _messageMenuItem );
			moduleWindowMenu.MenuItems.Add( _agendaMenuItem );
			moduleWindowMenu.MenuItems.Add( _timeTableMenuItem );
			moduleWindowMenu.MenuItems.Add( _holidayMenuItem );
			moduleWindowMenu.MenuItems.Add( _taskMenuItem );
			moduleWindowMenu.MenuItems.Add( _personalManagementMenuItem );
			if( SwmSuitePrincipal.CurrentEmployee.Administrator ) {
				//numberOfMenuItems = 12;
				moduleWindowMenu.MenuItems.Add( _alertManagementMenuItem );
				moduleWindowMenu.MenuItems.Add( _staffManagementMenuItem );
				moduleWindowMenu.MenuItems.Add( _timeTableManagementMenuItem );
				moduleWindowMenu.MenuItems.Add( _holidayManagementMenuItem );
				moduleWindowMenu.MenuItems.Add( _taskManagementMenuItem );
				moduleWindowMenu.MenuItems.Add( _loggingMenuItem );
			}
			//moduleWindowMenu.Scheme.MenuTopOffset = moduleWindowMenu.Height / 2 - moduleWindowMenu.Scheme.MenuItemHeight * numberOfMenuItems / 2;
			moduleWindowMenu.Scheme.MenuTopOffset = moduleWindowMenu.Height / 2 - moduleWindowMenu.Scheme.MenuItemHeight * moduleWindowMenu.MenuItems.List.Count / 2;
		}

		private void LoadMessageModule() {
			HideAllModules();
			messageModule.RefreshData();
			messageModule.Visible = true;
			headerText.Caption = "B e r i c h t e n";
			pictureBox.Image = headerImageList.Images[1];
		}

		private void LoadAgendaModule() {
			HideAllModules();
			agendaModule.Visible = true;
			agendaModule.RefreshData();
			headerText.Caption = "A g e n d a";
			pictureBox.Image = headerImageList.Images[2];
		}

		private void LoadTimeTableModule() {
			HideAllModules();
			timeTableModule.RefreshData();
			timeTableModule.Visible = true;
			headerText.Caption = "U u r r o o s t e r";
			pictureBox.Image = headerImageList.Images[3];
		}

		private void LoadHolidayModule() {
			HideAllModules();
			holidayModule.RefreshData();
			holidayModule.Visible = true;
			headerText.Caption = "V e r l o f";
			pictureBox.Image = headerImageList.Images[4];
		}

		private void LoadTaskModule() {
			HideAllModules();
			taskModule.RefreshData();
			taskModule.Visible = true;
			headerText.Caption = "T a k e n";
			pictureBox.Image = headerImageList.Images[5];
		}

		private void LoadPersonalManagementModule() {
			HideAllModules();
			personalManagementModule.RefreshData();
			personalManagementModule.Visible = true;
			headerText.Caption = "P e r s o o n l i j k   B e h e e r";
			pictureBox.Image = headerImageList.Images[6];
		}

		private void LoadAlertManagementModule() {
			HideAllModules();
			alertManagementModule.RefreshData();
			alertManagementModule.Visible = true;
			headerText.Caption = "A a n k o n d i g i n g e n";
			pictureBox.Image = headerImageList.Images[11];
		}

		private void LoadStaffManagementModule() {
			HideAllModules();
			staffManagementModule.RefreshData();
			staffManagementModule.Visible = true;
			headerText.Caption = "B e h e e r   P e r s o n e e l";
			pictureBox.Image = headerImageList.Images[7];
		}

		private void LoadTimeTableManagementModule() {
			HideAllModules();
			timeTableManagementModule.RefreshData();
			timeTableManagementModule.Visible = true;
			headerText.Caption = "B e h e e r   U u r r o o s t e r";
			pictureBox.Image = headerImageList.Images[8];
		}

		private void LoadHolidayManagementModule() {
			HideAllModules();
			holidayManagementModule.RefreshData();
			holidayManagementModule.Visible = true;
			headerText.Caption = "B e h e e r   V e r l o f";
			pictureBox.Image = headerImageList.Images[9];
		}

		private void LoadTaskManagementModule() {
			HideAllModules();
			taskManagementModule.RefreshData();
			taskManagementModule.Visible = true;
			headerText.Caption = "B e h e e r   T a k e n";
			pictureBox.Image = headerImageList.Images[10];
		}

		private void LoadLoggingModule() {
			HideAllModules();
			loggingModule.RefreshData();
			loggingModule.Visible = true;
			headerText.Caption = "L o g b o e k e n";
			pictureBox.Image = headerImageList.Images[12];
		}

		private void HideAllModules() {
			messageModule.Visible = false;
			agendaModule.Visible = false;
			timeTableModule.Visible = false;
			holidayModule.Visible = false;
			taskModule.Visible = false;
			personalManagementModule.Visible = false;
			alertManagementModule.Visible = false;
			staffManagementModule.Visible = false;
			timeTableManagementModule.Visible = false;
			holidayManagementModule.Visible = false;
			taskManagementModule.Visible = false;
			loggingModule.Visible = false;
		}

		private void InitializeAllModules() {
			messageModule.Dock = DockStyle.Fill;
			messageModule.BringToFront();
			messageModule.BorderStyle = BorderStyle.None;

			agendaModule.Dock = DockStyle.Fill;
			agendaModule.BringToFront();
			agendaModule.BorderStyle = BorderStyle.None;

			timeTableModule.Dock = DockStyle.Fill;
			timeTableModule.BringToFront();
			timeTableModule.BorderStyle = BorderStyle.None;

			holidayModule.Dock = DockStyle.Fill;
			holidayModule.BringToFront();
			holidayModule.BorderStyle = BorderStyle.None;

			taskModule.Dock = DockStyle.Fill;
			taskModule.BringToFront();
			taskModule.BorderStyle = BorderStyle.None;

			personalManagementModule.Dock = DockStyle.Fill;
			personalManagementModule.BringToFront();
			personalManagementModule.BorderStyle = BorderStyle.None;

			alertManagementModule.Dock = DockStyle.Fill;
			alertManagementModule.BringToFront();
			alertManagementModule.BorderStyle = BorderStyle.None;

			staffManagementModule.Dock = DockStyle.Fill;
			staffManagementModule.BringToFront();
			staffManagementModule.BorderStyle = BorderStyle.None;

			timeTableManagementModule.Dock = DockStyle.Fill;
			timeTableManagementModule.BringToFront();
			timeTableManagementModule.BorderStyle = BorderStyle.None;

			holidayManagementModule.Dock = DockStyle.Fill;
			holidayManagementModule.BringToFront();
			holidayManagementModule.BorderStyle = BorderStyle.None;

			taskManagementModule.Dock = DockStyle.Fill;
			taskManagementModule.BringToFront();
			taskManagementModule.BorderStyle = BorderStyle.None;

			loggingModule.Dock = DockStyle.Fill;
			loggingModule.BringToFront();
			loggingModule.BorderStyle = BorderStyle.None;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the quitButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void quitButton_Click( object sender , EventArgs e ) {
			this.Close();
		}

		/// <summary>
		/// Handles the Click event of the set settingsButton.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void settingsButton_Click( object sender , EventArgs e ) {
			UserSettingsDialog dialog = new UserSettingsDialog();
			dialog.ShowDialog();
		}

		/// <summary>
		/// Handles the FormClosing event of the MainForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
		private void MainForm_FormClosing( object sender , FormClosingEventArgs e ) {
			//if( !_forceLogout ) {
			//   if( LogoutNotificationDialog.Show() == DialogResult.OK ) {
			//      SwmSuitePrincipal.CurrentEmployee = null;
			//      SwmSuitePrincipal.CurrentEmployeeGroup = null;
			//   } else {
			//      e.Cancel = true;
			//   }
			//}
		}

		/// <summary>
		/// Handles the Idle event of the applicationIdle control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void applicationIdle_Idle( object sender , EventArgs e ) {
			// Close all opened dialogs...
			for( int i = 0 ; i < Application.OpenForms.Count ; i++ ) {
				Form openedForm = Application.OpenForms[i];
				if( openedForm != this && !openedForm.Name.Equals( "LogOnForm" ) ) {
					openedForm.Close();
				}
			}
			this.Close();
		}

		/// <summary>
		/// Handles the Tick event of the applicationIdle control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SwmSuite.Presentation.Common.ApplicationIdle.TickEventArgs"/> instance containing the event data.</param>
		private void applicationIdle_Tick( object sender , SwmSuite.Presentation.Common.ApplicationIdle.TickEventArgs e ) {
		}

		/// <summary>
		/// Handles the Warn event of the applicationIdle control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void applicationIdle_Warn( object sender , EventArgs e ) {
			int length = applicationIdle.TimeRemaining.Seconds;
			int start = DateTime.Now.Second;
			analogClockControl.SetCountDown( start , length );
		}

		/// <summary>
		/// Handles the Activity event of the applicationIdle control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SwmSuite.Presentation.Common.ApplicationIdle.ActivityEventArgs"/> instance containing the event data.</param>
		private void applicationIdle_Activity( object sender , SwmSuite.Presentation.Common.ApplicationIdle.ActivityEventArgs e ) {
			analogClockControl.SetCountDown( 0 , 0 );
		}

		/// <summary>
		/// Handles the DoubleClick event of the headerText control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void headerText_DoubleClick( object sender , EventArgs e ) {
			if( this.WindowState == FormWindowState.Normal ) {
				this.WindowState = FormWindowState.Maximized;
			} else {
				this.WindowState = FormWindowState.Normal;
			}
		}

		/// <summary>
		/// Handles the DoWork event of the alertBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void alertBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			e.Result = SwmSuiteFacade.Alert.GetAlertsForEmployee( SwmSuitePrincipal.CurrentEmployee );
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the alertBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void alertBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			AlertCollection alerts = (AlertCollection)e.Result;
			marqueeControl.MarqueeText = alerts.ToString();
		}

		#endregion

	}

}
