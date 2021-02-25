using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the AppointmentService methods.
	/// </summary>
	public interface IAppointmentDal {

		/// <summary>
		/// Get all appointments from the database that have a recurrence defined.
		/// </summary>
		/// <returns>An AppointmentDataCollection containing all requested appointments.</returns>
		AppointmentDataCollection GetRecurrentAppointmentData();

		/// <summary>
		/// Get all employees from the database on a specific date where the given employee is a guest.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the guest appointments for.</param>
		/// <param name="onDate">The date to get the appointments for.</param>
		/// <returns>An AppointmentDataCollection containing all requested appointments.</returns>
		AppointmentDataCollection GetGuestAppointmentDataForEmployeeOnDate( int employeeSysId , DateTime onDate );

		/// <summary>
		/// Get all appointments from the database on a specific date.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the appointments for.</param>
		/// <param name="onDate">The date to get the appointments for.</param>
		/// <returns>An AppointmentDataCollection containing all requested appointments.</returns>
		AppointmentDataCollection GetAppointmentDataForEmployeeOnDate( int employeeSysId , DateTime onDate );

		/// <summary>
		/// Get all appointments from the database.
		/// </summary>
		/// <returns>A AppointmentCollection containing all appointments.</returns>
		AppointmentDataCollection GetAppointmentData();

		/// <summary>
		/// Get a single appointment from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the appointment to retrieve.</param>
		/// <returns>An AppointmentCollection containing the requested appointment.</returns>
		AppointmentDataCollection GetAppointmentDataBySysId( int sysId );

		/// <summary>
		/// Get multiple appointments from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the appointments to retrieve.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentDataCollection GetAppointmentDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more appointments to the database.
		/// </summary>
		/// <param name="appointments">An AppointmentCollection containing the appointments to insert.</param>
		/// <returns>An AppointmentCollection containing the inserted appointments.</returns>
		AppointmentDataCollection InsertAppointmentData( AppointmentDataCollection appointments );

		/// <summary>
		/// Update one or more appointments in the database.
		/// </summary>
		/// <param name="appointments">An AppointmentCollection containing the appointments to update.</param>
		/// <returns>An AppointmentCollection containing the updated appointments.</returns>
		AppointmentDataCollection UpdateAppointmentData( AppointmentDataCollection appointments );

		/// <summary>
		/// Remove one or more appointments from the database.
		/// </summary>
		/// <param name="appointments">An AppointmentCollection containing the appointments to remove.</param>
		void RemoveAppointmentData( AppointmentDataCollection appointments );

		/// <summary>
		/// Remove all appointments from the database.
		/// </summary>
		void RemoveAllAppointmentData();

	}

}
