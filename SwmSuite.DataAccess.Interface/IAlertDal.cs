using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the AlertService methods.
	/// </summary>
	public interface IAlertDal {

		/// <summary>
		/// Get all alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all alerts.</returns>
		AlertDataCollection GetAlertData();

		/// <summary>
		/// Get all alerts from the database not linked to an employee or employeegroup.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertDataCollection GetGlobalAlertData();

		/// <summary>
		/// Get all alerts from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertDataCollection GetAlertDataForEmployee( int employeeSysId );

		/// <summary>
		/// Get all alerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertDataCollection GetAlertDataForEmployeeGroup( int employeeGroupSysId );

		/// <summary>
		/// Get a single alert from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the alert to retrieve.</param>
		/// <returns>An AlertCollection containing the requested alert.</returns>
		AlertDataCollection GetAlertDataBySysId( int sysId );

		/// <summary>
		/// Get multiple alerts from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the alerts to retrieve.</param>
		/// <returns>An AlertCollection containing the requested alerts.</returns>
		AlertDataCollection GetAlertDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more alerts to the database.
		/// </summary>
		/// <param name="alerts">An AlertCollection containing the alerts to insert.</param>
		/// <returns>An AlertCollection containing the inserted alerts.</returns>
		AlertDataCollection InsertAlertData( AlertDataCollection alerts );

		/// <summary>
		/// Update one or more alerts in the database.
		/// </summary>
		/// <param name="alerts">An AlertCollection containing the alerts to update.</param>
		/// <returns>An AlertCollection containing the updated alerts.</returns>
		AlertDataCollection UpdateAlertData( AlertDataCollection alerts );

		/// <summary>
		/// Remove one or more alerts from the database.
		/// </summary>
		/// <param name="alerts">An AlertCollection containing the alerts to remove.</param>
		void RemoveAlertData( AlertDataCollection alerts );

		/// <summary>
		/// Remove all alerts from the database.
		/// </summary>
		void RemoveAllAlertData();

	}

}
