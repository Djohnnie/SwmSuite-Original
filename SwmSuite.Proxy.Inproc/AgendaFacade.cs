using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {
	
	public class AgendaFacade : IAgendaFacade {

		#region IAgendaFacade Members

		/// <summary>
		/// Get all agendas for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the agendas for.</param>
		/// <returns>An AgendaCollection containing the requested agendas.</returns>
		AgendaCollection IAgendaFacade.GetAgendasForEmployee( Employee employee ) {
			return new AgendaBll().GetAgendasForEmployee( employee );
		}

		/// <summary>
		/// Create a new agenda.
		/// </summary>
		/// <param name="agenda">The agenda to create.</param>
		/// <returns>The created agenda.</returns>
		Agenda IAgendaFacade.CreateAgenda( Agenda agenda ) {
			return new AgendaBll().CreateAgenda( agenda );
		}

		/// <summary>
		/// Update an existing agenda.
		/// </summary>
		/// <param name="agenda">The agenda to update.</param>
		/// <returns>The updated agenda.</returns>
		Agenda IAgendaFacade.UpdateAgenda( Agenda agenda ) {
			return new AgendaBll().UpdateAgenda( agenda );
		}

		/// <summary>
		/// Delete an existing agenda.
		/// </summary>
		/// <param name="agenda">The agenda to delete.</param>
		void IAgendaFacade.DeleteAgenda( Agenda agenda ) {
			new AgendaBll().DeleteAgenda( agenda );
		}

		/// <summary>
		/// Get all appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the appointments for.</param>
		/// <param name="onDate">The date on which to get the appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentCollection IAgendaFacade.GetAppointmentsOnDate( Employee employee , DateTime onDate ) {
			return new AppointmentBll().GetAppointmentsOnDate( employee , onDate );
		}

		/// <summary>
		/// Get all guest appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the guest appointments for.</param>
		/// <param name="onDate">The date on which to get the guest appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentCollection IAgendaFacade.GetGuestAppointmentsOnDate( Employee employee , DateTime onDate ) {
			return new AppointmentBll().GetGuestAppointmentsOnDate( employee , onDate );
		}

		/// <summary>
		/// Get all timetable appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the guest appointments for.</param>
		/// <param name="onDate">The date on which to get the guest appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentCollection IAgendaFacade.GetTimeTableAppointmentsOnDate( Employee employee , DateTime onDate ) {
			return new AppointmentBll().GetTimeTableAppointmentsOnDate( employee , onDate );
		}

		/// <summary>
		/// Create a new appointment.
		/// </summary>
		/// <param name="appointment">The appointment to create.</param>
		/// <returns>The created appointment.</returns>
		Appointment IAgendaFacade.CreateAppointment( Appointment appointment ) {
			return new AppointmentBll().CreateAppointment( appointment );
		}

		/// <summary>
		/// Update an existing appointment.
		/// </summary>
		/// <param name="appointment">The appointment to update.</param>
		/// <returns>The updated appointment.</returns>
		Appointment IAgendaFacade.UpdateAppointment( Appointment appointment ) {
			return new AppointmentBll().UpdateAppointment( appointment );
		}

		/// <summary>
		/// Remove a specific appointment.
		/// </summary>
		/// <param name="appointment">The appointment to remove.</param>
		void IAgendaFacade.RemoveAppointment( Appointment appointment ) {
			new AppointmentBll().RemoveAppointment( appointment );
		}

		#endregion
	}

}
