using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;
using SwmSuite.Data.Common;
using System.Transactions;

namespace SwmSuite.Business {

	public class AppointmentBll {

		#region -_ Private Members _-

		private IAppointmentDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateAppointmentDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get an appointment by its internal id.
		/// </summary>
		/// <param name="sysId">The internal id of the appointment to get.</param>
		/// <returns>The requested appointment object.</returns>
		public Appointment GetAppointment( int sysId ) {
			Appointment appointmentToReturn = null;
			AppointmentDataCollection appointmentData = GetAppointmentDataBySysId( sysId );
			if( appointmentData.Count == 1 ) {
				appointmentToReturn = AppointmentMapping.FromDataObject( appointmentData[0] );
			}
			return appointmentToReturn;
		}

		/// <summary>
		/// Get all appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the appointments for.</param>
		/// <param name="onDate">The date on which to get the appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		public AppointmentCollection GetAppointmentsOnDate( Employee employee , DateTime onDate ) {
			AppointmentCollection appointmentsToReturn = new AppointmentCollection();
			//
			// Get the appointments on the given date.
			//
			AppointmentDataCollection appointmentData =
				GetAppointmentDataForEmployeeOnDate( employee.SysId , onDate );
			appointmentsToReturn.Add( AppointmentMapping.FromDataObjectCollection( appointmentData ) );
			//
			// Get the appointments with recurrence defined.
			//
			appointmentsToReturn.Add( GetRecurrentAppointmentsOnDate( employee , onDate ) );

			return appointmentsToReturn;
		}

		/// <summary>
		/// Get all guest appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the guest appointments for.</param>
		/// <param name="onDate">The date on which to get the guest appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		public AppointmentCollection GetGuestAppointmentsOnDate( Employee employee , DateTime onDate ) {
			AppointmentCollection appointmentsToReturn = new AppointmentCollection();
			//
			// Get the appointments on the given date.
			//
			AppointmentDataCollection appointmentData =
				GetGuestAppointmentDataForEmployeeOnDate( employee.SysId , onDate );
			appointmentsToReturn.Add( AppointmentMapping.FromDataObjectCollection( appointmentData ) );
			//
			// Get the appointments with recurrence defined.
			//
			appointmentsToReturn.Add( GetGuestRecurrentAppointmentsOnDate( employee , onDate ) );

			return appointmentsToReturn;
		}

		/// <summary>
		/// Get all timetable appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the guest appointments for.</param>
		/// <param name="onDate">The date on which to get the guest appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		public AppointmentCollection GetTimeTableAppointmentsOnDate( Employee employee , DateTime onDate ) {
			AppointmentCollection appointmentsToReturn = new AppointmentCollection();
			//
			// Get timetable data.
			//
			TimeTableEntryCollection timeTableEntries =
				new TimeTableEntryBll().GetTimeTableEntries( employee , onDate , onDate );
			//
			// Convert timetable data to appointment data.
			//
			appointmentsToReturn.Add( timeTableEntries.CreateAppointmentCollection() );
			return appointmentsToReturn;
		}

		/// <summary>
		/// Create a new appointment.
		/// </summary>
		/// <param name="appointment">The appointment to create.</param>
		/// <returns>The created appointment.</returns>
		public Appointment CreateAppointment( Appointment appointment ) {
			using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
				//
				// Create the appointment.
				//
				AppointmentData appointmentData =
					AppointmentMapping.FromBusinessObject( appointment );
				AppointmentDataCollection insertedAppointmentData = this.InsertAppointmentData(
					AppointmentDataCollection.FromSingleAppointment( appointmentData ) );
				int appointmentSysId = -1;
				if( insertedAppointmentData.Count == 1 ) {
					appointmentSysId = insertedAppointmentData[0].SysId;
				}
				//
				// Create the appointment guests if any.
				//
				if( appointment.Guests != null ) {
					AppointmentGuestDataCollection appointmentGuestData = new AppointmentGuestDataCollection();
					foreach( Employee employee in appointment.Guests ) {
						appointmentGuestData.Add(
							new AppointmentGuestData( appointmentSysId , employee.SysId ) );
					}
					new AppointmentGuestBll().InsertAppointmentGuestData( appointmentGuestData );
					SendNewAppointmentGuestMessage( appointment.Guests , appointment.OwnerEmployee , appointment );
				}
				//
				// Create recurrence if defined.
				//
				if( appointment.Recurrence != null ) {

				}
				appointment.SysId = appointmentSysId;
				scope.Complete();
				return appointment;
			}
		}

		/// <summary>
		/// Update an existing appointment.
		/// </summary>
		/// <param name="appointment">The appointment to update.</param>
		/// <returns>The updated appointment.</returns>
		public Appointment UpdateAppointment( Appointment appointment ) {
			using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
				AppointmentGuestBll appointmentGuestBll = new AppointmentGuestBll();
				//
				// Get the original appointment.
				//
				Appointment originalAppointment = GetAppointment( appointment.SysId );
				//
				// Remove appointment guests if any.
				//
				AppointmentGuestDataCollection appointmentGuestData =
						appointmentGuestBll.GetAppointmentGuestDataByAppointment( appointment.SysId );
				appointmentGuestBll.RemoveAppointmentGuestData( appointmentGuestData );
				//
				// update the appointment.
				//
				AppointmentData appointmentData =
					AppointmentMapping.FromBusinessObject( appointment );
				AppointmentDataCollection updatedAppointmentData = this.UpdateAppointmentData(
					AppointmentDataCollection.FromSingleAppointment( appointmentData ) );
				int appointmentSysId = -1;
				if( updatedAppointmentData.Count == 1 ) {
					appointmentSysId = updatedAppointmentData[0].SysId;
				}
				//
				// Create the appointment guests if any.
				//
				if( appointment.Guests != null ) {
					appointmentGuestData = new AppointmentGuestDataCollection();
					foreach( Employee employee in appointment.Guests ) {
						appointmentGuestData.Add(
							new AppointmentGuestData( appointmentSysId , employee.SysId ) );
					}
					new AppointmentGuestBll().InsertAppointmentGuestData( appointmentGuestData );
					SendNewAppointmentGuestMessage( appointment.Guests , appointment.OwnerEmployee , appointment );
				}
				//
				// Create recurrence if defined.
				//
				if( appointment.Recurrence != null ) {

				}
				appointment.SysId = appointmentSysId;
				scope.Complete();
				return appointment;
			}
		}

		/// <summary>
		/// Remove a specific appointment.
		/// </summary>
		/// <param name="appointment">The appointment to remove.</param>
		public void RemoveAppointment( Appointment appointment ) {
			using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
				AppointmentGuestBll appointmentGuestBll = new AppointmentGuestBll();
				//
				// Get the original appointment.
				//
				Appointment originalAppointment = GetAppointment( appointment.SysId );
				//
				// Remove appointment guests if any.
				//
				AppointmentGuestDataCollection appointmentGuestData =
						appointmentGuestBll.GetAppointmentGuestDataByAppointment( appointment.SysId );
				appointmentGuestBll.RemoveAppointmentGuestData( appointmentGuestData );
				//
				// Remove appointment.
				//
				RemoveAppointmentData( AppointmentDataCollection.FromSingleAppointment( AppointmentMapping.FromBusinessObject( appointment ) ) );
				scope.Complete();
			}
		}

		/// <summary>
		/// Get all appointment guest for a specific appointment.
		/// </summary>
		/// <param name="appointment">The appointment to get the guests for.</param>
		/// <returns>An EmployeeCollection contianing the requested appointment guests.</returns>
		public EmployeeCollection GetAppointmentGuests( Appointment appointment ) {
			EmployeeCollection guestsToReturn = new EmployeeCollection();
			AppointmentGuestDataCollection appointmentGuestsData =
				new AppointmentGuestBll().GetAppointmentGuestDataByAppointment( appointment.SysId );
			foreach( AppointmentGuestData appointmentGuestData in appointmentGuestsData ) {
				guestsToReturn.Add( new EmployeeBll().GetEmployeeDetail( appointmentGuestData.EmployeeSysId ) );
			}
			return guestsToReturn;
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all appointments from the database that have a recurrence defined.
		/// </summary>
		/// <returns>An AppointmentDataCollection containing all requested appointments.</returns>
		public AppointmentDataCollection GetRecurrentAppointmentData() {
			return dal.GetRecurrentAppointmentData();
		}

		/// <summary>
		/// Get all appointments from the database on a specific date where the given employee is a guest.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the guest appointments for.</param>
		/// <param name="onDate">The date to get the appointments for.</param>
		/// <returns>An AppointmentDataCollection containing all requested appointments.</returns>
		public AppointmentDataCollection GetGuestAppointmentDataForEmployeeOnDate( int employeeSysId , DateTime onDate ) {
			return dal.GetGuestAppointmentDataForEmployeeOnDate( employeeSysId , onDate );
		}

		/// <summary>
		/// Get all appointments from the database on a specific date.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the appointments for.</param>
		/// <param name="onDate">The date to get the appointments for.</param>
		/// <returns>An AppointmentDataCollection containing all requested appointments.</returns>
		public AppointmentDataCollection GetAppointmentDataForEmployeeOnDate( int employeeSysId , DateTime onDate ) {
			return dal.GetAppointmentDataForEmployeeOnDate( employeeSysId , onDate );
		}

		/// <summary>
		/// Get all appointments from the database.
		/// </summary>
		/// <returns>An AppointmentCollection containing all appointments.</returns>
		public AppointmentDataCollection GetAppointmentData() {
			return dal.GetAppointmentData();
		}

		/// <summary>
		/// Get a single appointment from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the appointment to retrieve.</param>
		/// <returns>An AppointmentCollection containing the requested appointment.</returns>
		public AppointmentDataCollection GetAppointmentDataBySysId( int sysId ) {
			return dal.GetAppointmentDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple appointments from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the appointments to retrieve.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		public AppointmentDataCollection GetAppointmentsDataBySysIds( int[] sysIds ) {
			return dal.GetAppointmentDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more appointments to the database.
		/// </summary>
		/// <param name="appointments">An AppointmentCollection containing the appointments to insert.</param>
		/// <returns>An AppointmentCollection containing the inserted appointments.</returns>
		public AppointmentDataCollection InsertAppointmentData( AppointmentDataCollection appointments ) {
			return dal.InsertAppointmentData( appointments );
		}

		/// <summary>
		/// Update one or more appointments in the database.
		/// </summary>
		/// <param name="appointments">An AppointmentCollection containing the appointments to update.</param>
		/// <returns>An AppointmentCollection containing the updated appointments.</returns>
		public AppointmentDataCollection UpdateAppointmentData( AppointmentDataCollection appointments ) {
			return dal.UpdateAppointmentData( appointments );
		}

		/// <summary>
		/// Remove one or more appointments from the database.
		/// </summary>
		/// <param name="appointments">An AppointmentCollection containing the appointments to remove.</param>
		public void RemoveAppointmentData( AppointmentDataCollection appointments ) {
			dal.RemoveAppointmentData( appointments );
		}

		/// <summary>
		/// Remove all appointments from the database.
		/// </summary>
		public void RemoveAllAppointmentData() {
			dal.RemoveAllAppointmentData();
		}

		#endregion

		#region -_ Private Methods _-

		private void SendNewAppointmentGuestMessage( EmployeeCollection guestEmployees , Employee employee , Appointment appointment ) {
			Message message = new Message();
			String contents = "U werd uitgenodigd door " + appointment.OwnerEmployee.FullName + " om deel te nemen aan zijn afspraak van " + appointment.DateTimeStart.ToShortDateString() + " om " + appointment.DateTimeStart.ToShortTimeString() + " tot " + appointment.DateTimeEnd.ToShortDateString() + " om " + appointment.DateTimeEnd.ToShortTimeString() + ". Consulteer uw agenda om verdere details van deze afspraak te bekijken.";
			message.CreateMessageContentsForSwmSuiteAlert( "Nieuwe afspraak." , contents );
			message.Recipients = guestEmployees;
			message.Sender = employee;
			message.Priority = MessagePriority.Normal;
			message.Date = DateTime.Now;
			new MessageBll().SendMessage( message , guestEmployees );
		}

		#endregion

		#region -_ Helper Methods _-

		private AppointmentCollection GetRecurrentAppointmentsOnDate( Employee employee , DateTime onDate ) {
			AppointmentCollection appointmentsToReturn = new AppointmentCollection();
			foreach( Appointment appointment in GetRecurrentAppointments() ) {
				if( RecurrenceCore.IsInRecurrence( appointment.Recurrence , onDate ) && appointment.OwnerEmployee.SysId == employee.SysId ) {
					if( !AppointmentAlreadyAdded( appointmentsToReturn , appointment ) ) {
						appointmentsToReturn.Add( appointment );
					}
				}
			}
			return appointmentsToReturn;
		}

		private AppointmentCollection GetGuestRecurrentAppointmentsOnDate( Employee employee , DateTime onDate ) {
			AppointmentCollection appointmentsToReturn = new AppointmentCollection();
			foreach( Appointment appointment in GetRecurrentAppointments() ) {
				if( RecurrenceCore.IsInRecurrence( appointment.Recurrence , onDate ) ) {
					foreach( Employee guest in appointment.Guests ) {
						if( guest.SysId == employee.SysId ) {
							if( !AppointmentAlreadyAdded( appointmentsToReturn , appointment ) ) {
								appointmentsToReturn.Add( appointment );
							}
						}
					}
				}
			}
			return appointmentsToReturn;
		}

		private bool AppointmentAlreadyAdded( AppointmentCollection appointments , Appointment appointment ) {
			bool exists = false;
			foreach( Appointment currentAppointment in appointments ) {
				if( currentAppointment.SysId == appointment.SysId ) {
					exists = true;
				}
			}
			return exists;
		}

		private AppointmentCollection GetRecurrentAppointments() {
			AppointmentCollection appointmentsToReturn = new AppointmentCollection();
			foreach( AppointmentData appointment in GetRecurrentAppointmentData() ) {
				Appointment newAppointment = AppointmentMapping.FromDataObject( appointment );
				RecurrenceDataCollection recurrenceData =
					new RecurrenceBll().GetRecurrenceDataForAppointment( appointment.SysId );
				newAppointment.Recurrence = RecurrenceMapping.FromDataObject( recurrenceData[0] );
				appointmentsToReturn.Add( newAppointment );
			}
			return appointmentsToReturn;
		}

		#endregion

	}

}
