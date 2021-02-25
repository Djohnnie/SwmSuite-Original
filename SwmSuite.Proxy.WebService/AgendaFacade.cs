using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public class AgendaFacade :
		ServiceFacade<AgendaService.AgendaService , AgendaService.SwmSuiteSoapHeader> ,
		IAgendaFacade {

		#region IAgendaFacade Members

		/// <summary>
		/// Get all agendas for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the agendas for.</param>
		/// <returns>An AgendaCollection containing the requested agendas.</returns>
		AgendaCollection IAgendaFacade.GetAgendasForEmployee( Employee employee ) {
			try {
				AgendaService.Employee employeeParameter = (AgendaService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( AgendaService.Employee ) );
				AgendaCollection agendas = new AgendaCollection();
				foreach( AgendaService.Agenda agenda in GetService().GetAgendasForEmployee( employeeParameter ) ) {
					agendas.Add( (Agenda)XmlSerialization.ConvertObject( agenda , typeof( AgendaService.Agenda ) , typeof( Agenda ) ) );
				}
				return agendas;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Create a new agenda.
		/// </summary>
		/// <param name="agenda">The agenda to create.</param>
		/// <returns>The created agenda.</returns>
		Agenda IAgendaFacade.CreateAgenda( Agenda agenda ) {
			try {
				AgendaService.Agenda agendaParameter = (AgendaService.Agenda)XmlSerialization.ConvertObject( agenda , typeof( Agenda ) , typeof( AgendaService.Agenda ) );
				AgendaService.Agenda agendaResult = GetService().CreateAgenda( agendaParameter );
				return (Agenda)XmlSerialization.ConvertObject( agendaResult , typeof( AgendaService.Agenda ) , typeof( Agenda ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing agenda.
		/// </summary>
		/// <param name="agenda">The agenda to update.</param>
		/// <returns>The updated agenda.</returns>
		Agenda IAgendaFacade.UpdateAgenda( Agenda agenda ) {
			try {
				AgendaService.Agenda agendaParameter = (AgendaService.Agenda)XmlSerialization.ConvertObject( agenda , typeof( Agenda ) , typeof( AgendaService.Agenda ) );
				AgendaService.Agenda agendaResult = GetService().UpdateAgenda( agendaParameter );
				return (Agenda)XmlSerialization.ConvertObject( agendaResult , typeof( AgendaService.Agenda ) , typeof( Agenda ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Delete an existing agenda.
		/// </summary>
		/// <param name="agenda">The agenda to delete.</param>
		void IAgendaFacade.DeleteAgenda( Agenda agenda ) {
			try {
				AgendaService.Agenda agendaParameter = (AgendaService.Agenda)XmlSerialization.ConvertObject( agenda , typeof( Agenda ) , typeof( AgendaService.Agenda ) );
				GetService().DeleteAgenda( agendaParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the appointments for.</param>
		/// <param name="onDate">The date on which to get the appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentCollection IAgendaFacade.GetAppointmentsOnDate( Employee employee , DateTime onDate ) {
			try {
				AgendaService.Employee employeeParameter = (AgendaService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( AgendaService.Employee ) );
				AppointmentCollection appointmentsToReturn = new AppointmentCollection();
				foreach( AgendaService.Appointment appointment in GetService().GetAppointmentsOnDate( employeeParameter , onDate ) ) {
					appointmentsToReturn.Add( (Appointment)XmlSerialization.ConvertObject( appointment , typeof( AgendaService.Appointment ) , typeof( Appointment ) ) );
				}
				return appointmentsToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all guest appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the guest appointments for.</param>
		/// <param name="onDate">The date on which to get the guest appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentCollection IAgendaFacade.GetGuestAppointmentsOnDate( Employee employee , DateTime onDate ) {
			try {
				AgendaService.Employee employeeParameter = (AgendaService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( AgendaService.Employee ) );
				AppointmentCollection appointmentsToReturn = new AppointmentCollection();
				foreach( AgendaService.Appointment appointment in GetService().GetGuestAppointmentsOnDate( employeeParameter , onDate ) ) {
					appointmentsToReturn.Add( (Appointment)XmlSerialization.ConvertObject( appointment , typeof( AgendaService.Appointment ) , typeof( Appointment ) ) );
				}
				return appointmentsToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all timetable appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the guest appointments for.</param>
		/// <param name="onDate">The date on which to get the guest appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentCollection IAgendaFacade.GetTimeTableAppointmentsOnDate( Employee employee , DateTime onDate ) {
			try {
				AgendaService.Employee employeeParameter = (AgendaService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( AgendaService.Employee ) );
				AppointmentCollection appointmentsToReturn = new AppointmentCollection();
				foreach( AgendaService.Appointment appointment in GetService().GetTimeTableAppointmentsOnDate( employeeParameter , onDate ) ) {
					appointmentsToReturn.Add( (Appointment)XmlSerialization.ConvertObject( appointment , typeof( AgendaService.Appointment ) , typeof( Appointment ) ) );
				}
				return appointmentsToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Create a new appointment.
		/// </summary>
		/// <param name="appointment">The appointment to create.</param>
		/// <returns>The created appointment.</returns>
		Appointment IAgendaFacade.CreateAppointment( Appointment appointment ) {
			try {
				AgendaService.Appointment appointmentParameter = (AgendaService.Appointment)XmlSerialization.ConvertObject( appointment , typeof( Appointment ) , typeof( AgendaService.Appointment ) );
				AgendaService.Appointment appointmentResult = GetService().CreateAppointment( appointmentParameter );
				return (Appointment)XmlSerialization.ConvertObject( appointmentResult , typeof( AgendaService.Appointment ) , typeof( Appointment ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing appointment.
		/// </summary>
		/// <param name="appointment">The appointment to update.</param>
		/// <returns>The updated appointment.</returns>
		Appointment IAgendaFacade.UpdateAppointment( Appointment appointment ) {
			try {
				AgendaService.Appointment appointmentParameter = (AgendaService.Appointment)XmlSerialization.ConvertObject( appointment , typeof( Appointment ) , typeof( AgendaService.Appointment ) );
				AgendaService.Appointment appointmentResult = GetService().UpdateAppointment( appointmentParameter );
				return (Appointment)XmlSerialization.ConvertObject( appointmentResult , typeof( AgendaService.Appointment ) , typeof( Appointment ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove a specific appointment.
		/// </summary>
		/// <param name="appointment">The appointment to remove.</param>
		void IAgendaFacade.RemoveAppointment( Appointment appointment ) {
			try {
				AgendaService.Appointment appointmentParameter = (AgendaService.Appointment)XmlSerialization.ConvertObject( appointment , typeof( Appointment ) , typeof( AgendaService.Appointment ) );
				GetService().RemoveAppointment( appointmentParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		#endregion
	}

}
