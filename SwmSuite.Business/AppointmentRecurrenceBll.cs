using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class AppointmentRecurrenceBll {

		#region -_ Private Members _-

		private IAppointmentRecurrenceDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateAppointmentRecurrenceDal();

		#endregion

		#region -_ Business Methods _-

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all appointmentrecurrences from the database.
		/// </summary>
		/// <returns>An AppointmentRecurrenceCollection containing all appointmentrecurrences.</returns>
		public AppointmentRecurrenceDataCollection GetAppointmentRecurrenceData() {
			return dal.GetAppointmentRecurrenceData();
		}

		/// <summary>
		/// Get a single appointmentrecurrence from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the appointmentrecurrence to retrieve.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the requested appointment recurrence.</returns>
		public AppointmentRecurrenceDataCollection GetAppointmentRecurrenceDataBySysIs( int sysId ) {
			return dal.GetAppointmentRecurrenceDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple appointmentrecurrences from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the appointmentrecurrences to retrieve.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the requested appointment recurrences.</returns>
		public AppointmentRecurrenceDataCollection GetAppointmentRecurrencesDataBySysIds( int[] sysIds ) {
			return dal.GetAppointmentRecurrencesDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more appointmentrecurrences to the database.
		/// </summary>
		/// <param name="appointmentrecurrences">An AppointmentRecurrenceCollection containing the appointmentrecurrences to insert.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the inserted appointment recurrences.</returns>
		public AppointmentRecurrenceDataCollection InsertAppointmentRecurrenceData( AppointmentRecurrenceDataCollection appointmentrecurrences ) {
			return dal.InsertAppointmentRecurrenceData( appointmentrecurrences );
		}

		/// <summary>
		/// Update one or more appointmentrecurrences in the database.
		/// </summary>
		/// <param name="appointmentrecurrences">An AppointmentRecurrenceCollection containing the appointmentrecurrences to update.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the updated appointment recurrences.</returns>
		public AppointmentRecurrenceDataCollection UpdateAppointmentRecurrenceData( AppointmentRecurrenceDataCollection appointmentrecurrences ) {
			return dal.UpdateAppointmentRecurrenceData( appointmentrecurrences );
		}

		/// <summary>
		/// Remove one or more appointmentrecurrences from the database.
		/// </summary>
		/// <param name="appointmentrecurrences">An AppointmentRecurrenceCollection containing the appointmentrecurrences to remove.</param>
		public void RemoveAppointmentRecurrenceData( AppointmentRecurrenceDataCollection appointmentrecurrences ) {
			dal.RemoveAppointmentRecurrenceData( appointmentrecurrences );
		}

		/// <summary>
		/// Remove all appointmentrecurrences from the database.
		/// </summary>
		public void RemoveAllAppointmentRecurrenceData() {
			dal.RemoveAllAppointmentRecurrenceData();
		}

		#endregion

	}

}
