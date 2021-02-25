using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Services;
using System.ComponentModel;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using System.Web.Services.Protocols;
using SwmSuite.Business;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {

	/// <summary>
	/// Summary description for AgendaService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class AgendaService : System.Web.Services.WebService , IAgendaFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get all agendas for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the agendas for.</param>
		/// <returns>An AgendaCollection containing the requested agendas.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public AgendaCollection GetAgendasForEmployee( Employee employee ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AgendaBll().GetAgendasForEmployee( employee );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Create a new agenda.
		/// </summary>
		/// <param name="agenda">The agenda to create.</param>
		/// <returns>The created agenda.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Agenda CreateAgenda( Agenda agenda ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AgendaBll().CreateAgenda( agenda );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing agenda.
		/// </summary>
		/// <param name="agenda">The agenda to update.</param>
		/// <returns>The updated agenda.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Agenda UpdateAgenda( Agenda agenda ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AgendaBll().UpdateAgenda( agenda );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Delete an existing agenda.
		/// </summary>
		/// <param name="agenda">The agenda to delete.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void DeleteAgenda( Agenda agenda ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new AgendaBll().DeleteAgenda( agenda );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the appointments for.</param>
		/// <param name="onDate">The date on which to get the appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public AppointmentCollection GetAppointmentsOnDate( Employee employee , DateTime onDate ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AppointmentBll().GetAppointmentsOnDate( employee , onDate );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all guest appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the guest appointments for.</param>
		/// <param name="onDate">The date on which to get the guest appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public AppointmentCollection GetGuestAppointmentsOnDate( Employee employee , DateTime onDate ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AppointmentBll().GetGuestAppointmentsOnDate( employee , onDate );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all timetable appointments for a specific employee on a specific date.
		/// </summary>
		/// <param name="employee">The employee to get the guest appointments for.</param>
		/// <param name="onDate">The date on which to get the guest appointments for.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public AppointmentCollection GetTimeTableAppointmentsOnDate( Employee employee , DateTime onDate ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AppointmentBll().GetTimeTableAppointmentsOnDate( employee , onDate );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Create a new appointment.
		/// </summary>
		/// <param name="appointment">The appointment to create.</param>
		/// <returns>The created appointment.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Appointment CreateAppointment( Appointment appointment ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AppointmentBll().CreateAppointment( appointment );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing appointment.
		/// </summary>
		/// <param name="appointment">The appointment to update.</param>
		/// <returns>The updated appointment.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Appointment UpdateAppointment( Appointment appointment ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AppointmentBll().UpdateAppointment( appointment );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove a specific appointment.
		/// </summary>
		/// <param name="appointment">The appointment to remove.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveAppointment( Appointment appointment ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new AppointmentBll().RemoveAppointment( appointment );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

	}
}
