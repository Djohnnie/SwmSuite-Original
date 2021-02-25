using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Data.BusinessObjects;
using System.Collections.ObjectModel;
using SimpleWorkfloorManagementSuite.Dialogs;
using SwmSuite.Presentation.Common.AgendaControl;
using SwmSuite.Proxy.Interface;
using SwmSuite.Framework;

using SwmSuite.Presentation.Common.CheckList;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class AgendaModule : UserControl {

		#region -_ Construction _-

		public AgendaModule() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			agendaControl.SelectionStart = new DateTime( DateTime.Now.Year , DateTime.Now.Month , DateTime.Now.Day , DateTime.Now.Hour , 0 , 0 );
			agendaControl.SelectionEnd = new DateTime( DateTime.Now.Year , DateTime.Now.Month , DateTime.Now.Day , DateTime.Now.Hour , 30 , 0 );
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the AgendaModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void AgendaModule_Load( object sender , EventArgs e ) {
			toolStrip.Renderer = new WindowsVistaRenderer();
			if( !this.DesignMode ) {
				agendaControl.SetSelection( DateTime.Today );
			}
		}

		/// <summary>
		/// Handles the Click event of the agendaManagementToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void agendaManagementToolStripButton_Click( object sender , EventArgs e ) {
			AgendaManagementDialog dialog = new AgendaManagementDialog();
			dialog.ShowDialog();
			RefreshAgendaCheckList();
		}

		/// <summary>
		/// Handles the Click event of the dayToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void dayToolStripMenuItem_Click( object sender , EventArgs e ) {
			dayToolStripMenuItem.Checked = true;
			weekToolStripMenuItem.Checked = false;
			agendaViewToolStripButton.Text = "Dag";
			agendaControl.ViewMode = AgendaViewMode.Day;
			agendaViewToolStripButton.Image = SimpleWorkfloorManagementSuite.Properties.Resources.calendar_1_241;
			SetSelectionDisplay();
		}

		/// <summary>
		/// Handles the Click event of the weekToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void weekToolStripMenuItem_Click( object sender , EventArgs e ) {
			dayToolStripMenuItem.Checked = false;
			weekToolStripMenuItem.Checked = true;
			agendaViewToolStripButton.Text = "Week";
			agendaControl.ViewMode = AgendaViewMode.Week;
			agendaViewToolStripButton.Image = SimpleWorkfloorManagementSuite.Properties.Resources.calendar_7_241;
			SetSelectionDisplay();
		}

		/// <summary>
		/// Handles the Click event of the newAppointmentToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void newAppointmentToolStripButton_Click( object sender , EventArgs e ) {
			AppointmentDetailDialog dialog = new AppointmentDetailDialog( agendaControl.SelectionStart , agendaControl.SelectionEnd.AddMinutes( 30 ) );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				SwmSuiteFacade.AgendaFacade.CreateAppointment( dialog.Appointment );
				agendaControl.RefreshAgenda();
			}
		}

		/// <summary>
		/// Handles the Click event of the editToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editToolStripButton_Click( object sender , EventArgs e ) {
			if( agendaControl.SelectedAppointment != null ) {
				Appointment appointment = (Appointment)agendaControl.SelectedAppointment.Tag;
				AppointmentDetailDialog dialog = new AppointmentDetailDialog();
				dialog.Appointment = appointment;
				if( dialog.ShowDialog() == DialogResult.OK ) {
					SwmSuiteFacade.AgendaFacade.UpdateAppointment( dialog.Appointment );
					agendaControl.RefreshAgenda();
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the removeAppointmentToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void removeAppointmentToolStripButton_Click( object sender , EventArgs e ) {
			if( agendaControl.SelectedAppointment != null ) {
				Appointment appointment = (Appointment)agendaControl.SelectedAppointment.Tag;
				if( appointment.Agenda.Special == SpecialAgenda.NothingSpecial ) {
					if( QueryDialog.ShowQueryDialog( "Agenda" , "Bent u zeker dat u de geselecteerde afspraak wilt verwijderen?" ) == DialogResult.Yes ) {
						SwmSuiteFacade.AgendaFacade.RemoveAppointment( appointment );
						agendaControl.RefreshAgenda();
					}
				}
			}
		}

		/// <summary>
		/// Handles the NeedsUpdate event of the agendaControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SwmSuite.Presentation.Common.AgendaControl.AgendaNeedsUpdateEventArgs"/> instance containing the event data.</param>
		private void agendaControl_NeedsUpdate( object sender , AgendaNeedsUpdateEventArgs e ) {
			AppointmentCollection appointments = new AppointmentCollection();
			AgendaCollection selectedAgendas = GetSelectedAgendas();
			foreach( DateTime date in e.Dates ) {
				if( selectedAgendas.ContainsGuestAgenda() ) {
					AppointmentCollection guestAppointments = SwmSuiteFacade.AgendaFacade.GetGuestAppointmentsOnDate( SwmSuitePrincipal.CurrentEmployee , date );
					foreach( Appointment appointment in guestAppointments ) {
						appointment.Agenda = Agenda.GetGuestAgenda();
					}
					appointments.Add( guestAppointments );
				}
				if( selectedAgendas.ContainsTimeTableAgenda() ) {
					AppointmentCollection timeTableAppointments = SwmSuiteFacade.AgendaFacade.GetTimeTableAppointmentsOnDate( SwmSuitePrincipal.CurrentEmployee , date );
					foreach( Appointment appointment in timeTableAppointments ) {
						appointment.Agenda = Agenda.GetTimeTableAgenda();
					}
					appointments.Add( timeTableAppointments );
				}
				foreach( Appointment appointment in SwmSuiteFacade.AgendaFacade.GetAppointmentsOnDate( SwmSuitePrincipal.CurrentEmployee , date ) ) {
					if( IsAgendaSelected( selectedAgendas , appointment ) ) {
						if( !IsAppointmentAlreadyAdded( appointments , appointment ) ) {
							appointments.Add( appointment );
						}
					}
				}
			}
			SetAgendaAppointmentData( appointments , e.Dates );
		}

		private bool IsAgendaSelected( AgendaCollection selectedAgendas , Appointment appointment ) {
			bool selected = false;
			foreach( Agenda agenda in selectedAgendas ) {
				if( appointment.Agenda.SysId == agenda.SysId ) {
					selected = true;
				}
			}
			return selected;
		}

		private AgendaCollection GetSelectedAgendas() {
			AgendaCollection agendasToReturn = new AgendaCollection();
			foreach( CheckListItem checkListItem in agendaCheckListControl.Items ) {
				if( checkListItem.Checked ) {
					agendasToReturn.Add( (Agenda)checkListItem.Tag );
				}
			}
			return agendasToReturn;
		}

		/// <summary>
		/// Handles the CheckListSelectionChanged event of the agendaCheckListControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void agendaCheckListControl_CheckListSelectionChanged( object sender , EventArgs e ) {
			agendaControl.UpdateData();
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Refreshes the data for this formula.
		/// </summary>
		public void RefreshData() {
			RefreshAgendaCheckList();
			agendaControl.SetSelection( DateTime.Today );
		}

		private void RefreshAgendaCheckList() {
			agendaCheckListControl.Items.Clear();
			AgendaCollection agendaCollection = SwmSuiteFacade.AgendaFacade.GetAgendasForEmployee( SwmSuitePrincipal.CurrentEmployee );
			agendaCollection.Add( Agenda.GetGuestAgenda() );
			agendaCollection.Add( Agenda.GetTimeTableAgenda() );
			foreach( Agenda agenda in agendaCollection ) {
				CheckListItem newCheckListItem = new CheckListItem( agenda.Title , agenda );
				agendaCheckListControl.Items.Add( newCheckListItem );
				switch( agenda.Special ) {
					case SpecialAgenda.GuestAgenda:
					case SpecialAgenda.TimeTableAgenda: {
							newCheckListItem.Checked = false;
							break;
						}
				}
			}
			agendaCheckListControl.Renderer.Invalidate();
			agendaCheckListControl.Invalidate();
		}

		#endregion

		private bool IsAppointmentAlreadyAdded( AppointmentCollection appointments , Appointment appointment ) {
			bool exists = false;
			foreach( Appointment currentAppointment in appointments ) {
				if( currentAppointment.SysId == appointment.SysId ) {
					exists = true;
				}
			}
			return exists;
		}

		/// <summary>
		/// Handles the Click event of the previousToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void previousToolStripButton_Click( object sender , EventArgs e ) {
			agendaControl.Backwards();
			SetSelectionDisplay();
		}

		private void SetSelectionDisplay() {
			switch( agendaControl.ViewMode ) {
				case AgendaViewMode.Day: {
						selectionToolStripButton.Text = agendaControl.Selection.ToString( "dd/MM/yyyy" );
						break;
					}
				case AgendaViewMode.Week: {
						selectionToolStripButton.Text = agendaControl.Selection.StartOfWeek().ToString( "dd/MM/yyyy" ) + " - " + agendaControl.Selection.EndOfWeek().ToString( "dd/MM/yyyy" );
						break;
					}
			}
		}

		/// <summary>
		/// Handles the Click event of the nextToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nextToolStripButton_Click( object sender , EventArgs e ) {
			agendaControl.Forwards();
			SetSelectionDisplay();
		}

		private void SetAgendaAppointmentData( AppointmentCollection appointments , DateTime[] dates ) {
			agendaControl.Appointments.Clear();

			foreach( SwmSuite.Data.BusinessObjects.Appointment appointment in appointments ) {
				bool appointmentSet = false;
				foreach( DateTime date in dates ) {
					List<DateTime> datesInAppointment = new List<DateTime>();
					for( int i = 0 ; i < appointment.DateTimeEnd.Subtract( appointment.DateTimeStart ).Days + 1 ; i++ ) {
						datesInAppointment.Add( appointment.DateTimeStart.AddDays( i ).Date );
					}
					if( appointment.DateTimeEnd.Subtract( appointment.DateTimeStart ).Days > 0 ) {
						datesInAppointment.Add( appointment.DateTimeEnd.Date );
					}
					if( datesInAppointment.Contains( date.Date ) ) {
						AgendaAppointment newAgendaAppointment = new AgendaAppointment();
						newAgendaAppointment.Tag = appointment;
						newAgendaAppointment.Title = appointment.Title;
						newAgendaAppointment.Place = appointment.Place;
						newAgendaAppointment.Contents = appointment.Contents;
						if( appointment.DateTimeStart < new DateTime( date.Year , date.Month , date.Day , 0 , 0 , 0 ) ) {
							newAgendaAppointment.Begin = new DateTime( date.Year , date.Month , date.Day , 0 , 0 , 0 );
						} else {
							newAgendaAppointment.Begin = appointment.DateTimeStart;
						}
						if( appointment.DateTimeEnd > new DateTime( date.Year , date.Month , date.Day , 23 , 59 , 59 ) ) {
							newAgendaAppointment.End = new DateTime( date.Year , date.Month , date.Day , 23 , 59 , 59 );
						} else {
							newAgendaAppointment.End = appointment.DateTimeEnd;
						}
						newAgendaAppointment.Color1 = appointment.Agenda.Color1;
						newAgendaAppointment.Color2 = appointment.Agenda.Color2;
						newAgendaAppointment.Color3 = appointment.Agenda.Color3;
						agendaControl.Appointments.Add( newAgendaAppointment );
						appointmentSet = true;
					}
				}
			}
			CalculateAgendaAppointmentOverlaps();
		}

		private void CalculateAgendaAppointmentOverlaps() {
			foreach( AgendaAppointment appointment in agendaControl.Appointments ) {
				int overlaps = 1;
				int overlapOffset = 0;
				foreach( AgendaAppointment appointmentToCheck in agendaControl.Appointments ) {
					if( appointmentToCheck != appointment ) {
						if( TimePeriodOverlap( appointment.Begin , appointment.End , appointmentToCheck.Begin , appointmentToCheck.End ) ) {
							overlaps++;
							if( appointmentToCheck.OverlapOffset == 0 ) {
								overlapOffset++;
							}
						}
					}
				}
				appointment.Overlaps = overlaps;
				appointment.OverlapOffset = overlapOffset;
			}
		}

		/// <summary>
		/// Tests if two given periods overlap each other.
		/// </summary>
		/// <param name="BS">Base period start</param>
		/// <param name="BE">Base period end</param>
		/// <param name="TS">Test period start</param>
		/// <param name="TE">Test period end</param>
		/// <returns>
		/// 	<c>true</c> if the periods overlap; <c>false</c> otherwise.
		/// </returns>
		private bool TimePeriodOverlap( DateTime BS , DateTime BE , DateTime TS , DateTime TE ) {
			return (
				// 1. Case:
				//
				//       TS-------TE
				//    BS------BE 
				//
				// TS is after BS but before BE
				( TS >= BS && TS < BE )
				|| // or

				// 2. Case
				//
				//    TS-------TE
				//        BS---------BE
				//
				// TE is before BE but after BS
				( TE <= BE && TE > BS )
				|| // or

				// 3. Case
				//
				//  TS----------TE
				//     BS----BE
				//
				// TS is before BS and TE is after BE
				( TS <= BS && TE >= BE )
		);

		}

		/// <summary>
		/// Handles the AppointmentSelectionChanged event of the agendaControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SwmSuite.Presentation.Common.AgendaControl.AppointmentSelectionChangedEventArgs"/> instance containing the event data.</param>
		private void agendaControl_AppointmentSelectionChanged( object sender , AppointmentSelectionChangedEventArgs e ) {
			if( e.Appointment == null ) {
				editToolStripButton.Enabled = false;
				removeAppointmentToolStripButton.Enabled = false;
			} else {
				Appointment appointment = (Appointment)e.Appointment.Tag;
				if( appointment.Agenda.Special == SpecialAgenda.NothingSpecial ) {
					editToolStripButton.Enabled = true;
					removeAppointmentToolStripButton.Enabled = true;
				} else {
					editToolStripButton.Enabled = false;
					removeAppointmentToolStripButton.Enabled = false;
				}
			}
		}

	}

}
