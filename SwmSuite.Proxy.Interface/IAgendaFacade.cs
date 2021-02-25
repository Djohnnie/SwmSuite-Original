using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Proxy.Interface {
	
	public interface IAgendaFacade {

		/// <summary>
		/// Get all agendas for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the agendas for.</param>
		/// <returns>An AgendaCollection containing the requested agendas.</returns>
		AgendaCollection GetAgendasForEmployee( Employee employee );

		/// <summary>
		/// Create a new agenda.
		/// </summary>
		/// <param name="agenda">The agenda to create.</param>
		/// <returns>The created agenda.</returns>
		Agenda CreateAgenda( Agenda agenda );

		/// <summary>
		/// Update an existing agenda.
		/// </summary>
		/// <param name="agenda">The agenda to update.</param>
		/// <returns>The updated agenda.</returns>
		Agenda UpdateAgenda( Agenda agenda );

		/// <summary>
		/// Delete an existing agenda.
		/// </summary>
		/// <param name="agenda">The agenda to delete.</param>
		void DeleteAgenda( Agenda agenda );

		/// <summary>
		/// Get all appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the appointments for.</param>
		/// <param name="onDate">The date on which to get the appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentCollection GetAppointmentsOnDate( Employee employee , DateTime onDate );

		/// <summary>
		/// Get all guest appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the guest appointments for.</param>
		/// <param name="onDate">The date on which to get the guest appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentCollection GetGuestAppointmentsOnDate( Employee employee , DateTime onDate );

		/// <summary>
		/// Get all timetable appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the guest appointments for.</param>
		/// <param name="onDate">The date on which to get the guest appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentCollection GetTimeTableAppointmentsOnDate( Employee employee , DateTime onDate );

		/// <summary>
		/// Create a new appointment.
		/// </summary>
		/// <param name="appointment">The appointment to create.</param>
		/// <returns>The created appointment.</returns>
		Appointment CreateAppointment( Appointment appointment );

		/// <summary>
		/// Update an existing appointment.
		/// </summary>
		/// <param name="appointment">The appointment to update.</param>
		/// <returns>The updated appointment.</returns>
		Appointment UpdateAppointment( Appointment appointment );

		/// <summary>
		/// Remove a specific appointment.
		/// </summary>
		/// <param name="appointment">The appointment to remove.</param>
		void RemoveAppointment( Appointment appointment );

	}

}
