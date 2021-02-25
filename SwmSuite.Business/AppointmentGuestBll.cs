using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class AppointmentGuestBll {

		#region -_ Private Members _-

		private IAppointmentGuestDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateAppointmentGuestDal();

		#endregion

		#region -_ Business Methods _-

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all appointmentguests from the database.
		/// </summary>
		/// <returns>An AppointmentGuestCollection containing all appointmentguests.</returns>
		public AppointmentGuestDataCollection GetAppointmentGuestData() {
			return dal.GetAppointmentGuestData();
		}

		/// <summary>
		/// Get all appointmentguests from the database for a specific appointment.
		/// </summary>
		/// <param name="appointmentSysId">The inernal id of the appointment to get the guest data for.</param>
		/// <returns>An AppointmentGuestCollection containing all appointmentguests.</returns>
		public AppointmentGuestDataCollection GetAppointmentGuestDataByAppointment( int appointmentSysId ) {
			return dal.GetAppointmentGuestDataByAppointment( appointmentSysId );
		}

		/// <summary>
		/// Get a single appointmentguest from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the appointmentguest to retrieve.</param>
		/// <returns>An AppointmentGuestCollection containing the requested appointmentguest.</returns>
		public AppointmentGuestDataCollection GetAppointmentGuestDataBySysId( int sysId ) {
			return dal.GetAppointmentGuestDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple appointmentguests from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the appointmentguests to retrieve.</param>
		/// <returns>An AppointmentGuestCollection containing the requested appointmentguests.</returns>
		public AppointmentGuestDataCollection GetAppointmentGuestsDataBySysIds( int[] sysIds ) {
			return dal.GetAppointmentGuestsDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more appointmentguests to the database.
		/// </summary>
		/// <param name="appointmentguests">An AppointmentGuestCollection containing the appointmentguests to insert.</param>
		/// <returns>An AppointmentGuestCollection containing the inserted appointmentguests.</returns>
		public AppointmentGuestDataCollection InsertAppointmentGuestData( AppointmentGuestDataCollection appointmentguests ) {
			return dal.InsertAppointmentGuestData( appointmentguests );
		}

		/// <summary>
		/// Update one or more appointmentguests in the database.
		/// </summary>
		/// <param name="appointmentguests">An AppointmentGuestCollection containing the appointmentguests to update.</param>
		/// <returns>An AppointmentGuestCollection containing the updated appointmentguests.</returns>
		public AppointmentGuestDataCollection UpdateAppointmentGuestData( AppointmentGuestDataCollection appointmentguests ) {
			return dal.UpdateAppointmentGuestData( appointmentguests );
		}

		/// <summary>
		/// Remove one or more appointmentguests from the database.
		/// </summary>
		/// <param name="appointmentguests">An AppointmentGuestCollection containing the appointmentguests to remove.</param>
		public void RemoveAppointmentGuestData( AppointmentGuestDataCollection appointmentguests ) {
			dal.RemoveAppointmentGuestData( appointmentguests );
		}

		/// <summary>
		/// Remove all appointmentguests from the database.
		/// </summary>
		public void RemoveAllAppointmentGuestData() {
			dal.RemoveAllAppointmentGuestData();
		}

		#endregion

	}

}
