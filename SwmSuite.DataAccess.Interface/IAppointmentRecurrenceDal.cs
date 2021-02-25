using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the AppointmentRecurrenceService methods.
	/// </summary>
	public interface IAppointmentRecurrenceDal {

		/// <summary>
		/// Get all appointmentrecurrences from the database.
		/// </summary>
		/// <returns>A AppointmentRecurrenceCollection containing all appointmentrecurrences.</returns>
		AppointmentRecurrenceDataCollection GetAppointmentRecurrenceData();

		/// <summary>
		/// Get a single appointmentrecurrence from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the appointmentrecurrence to retrieve.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the requested appointmentrecurrence.</returns>
		AppointmentRecurrenceDataCollection GetAppointmentRecurrenceDataBySysId( int sysId );

		/// <summary>
		/// Get multiple appointmentrecurrences from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the appointmentrecurrences to retrieve.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the requested appointmentrecurrences.</returns>
		AppointmentRecurrenceDataCollection GetAppointmentRecurrencesDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more appointmentrecurrences to the database.
		/// </summary>
		/// <param name="appointmentrecurrences">An AppointmentRecurrenceCollection containing the appointmentrecurrences to insert.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the inserted appointmentrecurrences.</returns>
		AppointmentRecurrenceDataCollection InsertAppointmentRecurrenceData( AppointmentRecurrenceDataCollection appointmentrecurrences );

		/// <summary>
		/// Update one or more appointmentrecurrences in the database.
		/// </summary>
		/// <param name="appointmentrecurrences">An AppointmentRecurrenceCollection containing the appointmentrecurrences to update.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the updated appointmentrecurrences.</returns>
		AppointmentRecurrenceDataCollection UpdateAppointmentRecurrenceData( AppointmentRecurrenceDataCollection appointmentrecurrences );

		/// <summary>
		/// Remove one or more appointmentrecurrences from the database.
		/// </summary>
		/// <param name="appointmentrecurrences">An AppointmentRecurrenceCollection containing the appointmentrecurrences to remove.</param>
		void RemoveAppointmentRecurrenceData( AppointmentRecurrenceDataCollection appointmentrecurrences );

		/// <summary>
		/// Remove all appointmentrecurrences from the database.
		/// </summary>
		void RemoveAllAppointmentRecurrenceData();

	}

}
