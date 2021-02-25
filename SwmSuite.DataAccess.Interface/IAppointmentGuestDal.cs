using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the AppointmentGuestService methods.
	/// </summary>
	public interface IAppointmentGuestDal {

		/// <summary>
		/// Get all appointmentguests from the database.
		/// </summary>
		/// <returns>A AppointmentGuestCollection containing all appointmentguests.</returns>
		AppointmentGuestDataCollection GetAppointmentGuestData();

		/// <summary>
		/// Get all appointmentguests from the database for a specific appointment.
		/// </summary>
		/// <param name="appointmentSysId">The inernal id of the appointment to get the guest data for.</param>
		/// <returns>An AppointmentGuestCollection containing all appointmentguests.</returns>
		AppointmentGuestDataCollection GetAppointmentGuestDataByAppointment( int appointmentSysId );

		/// <summary>
		/// Get a single appointmentguest from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the appointmentguest to retrieve.</param>
		/// <returns>An AppointmentGuestCollection containing the requested appointmentguest.</returns>
		AppointmentGuestDataCollection GetAppointmentGuestDataBySysId( int sysId );

		/// <summary>
		/// Get multiple appointmentguests from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the appointmentguests to retrieve.</param>
		/// <returns>An AppointmentGuestCollection containing the requested appointmentguests.</returns>
		AppointmentGuestDataCollection GetAppointmentGuestsDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more appointmentguests to the database.
		/// </summary>
		/// <param name="appointmentguests">An AppointmentGuestCollection containing the appointmentguests to insert.</param>
		/// <returns>An AppointmentGuestCollection containing the inserted appointmentguests.</returns>
		AppointmentGuestDataCollection InsertAppointmentGuestData( AppointmentGuestDataCollection appointmentguests );

		/// <summary>
		/// Update one or more appointmentguests in the database.
		/// </summary>
		/// <param name="appointmentguests">An AppointmentGuestCollection containing the appointmentguests to update.</param>
		/// <returns>An AppointmentGuestCollection containing the updated appointmentguests.</returns>
		AppointmentGuestDataCollection UpdateAppointmentGuestData( AppointmentGuestDataCollection appointmentguests );

		/// <summary>
		/// Remove one or more appointmentguests from the database.
		/// </summary>
		/// <param name="appointmentguests">An AppointmentGuestCollection containing the appointmentguests to remove.</param>
		void RemoveAppointmentGuestData( AppointmentGuestDataCollection appointmentguests );

		/// <summary>
		/// Remove all appointmentguests from the database.
		/// </summary>
		void RemoveAllAppointmentGuestData();

	}

}
