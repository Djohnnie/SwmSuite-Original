using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Proxy.Interface {
	
	public interface IAlertFacade {

		/// <summary>
		/// Get all alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection GetAlerts();

		/// <summary>
		/// Get all global alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection GetGlobalAlerts();

		/// <summary>
		/// Get all alerts from the database for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection GetAlertsForEmployee( Employee employee );

		/// <summary>
		/// Get all alerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection GetAlertsForEmployeeGroup( EmployeeGroup employeeGroup );

		/// <summary>
		/// Create a new alert.
		/// </summary>
		/// <param name="alert">Alert object that needs to be created.</param>
		void CreateAlert( Alert alert );

		/// <summary>
		/// Update an existing alert.
		/// </summary>
		/// <param name="alert">Alert object that needs to be updated.</param>
		void UpdateAlert( Alert alert );

		/// <summary>
		/// Remove one or more existing alerts.
		/// </summary>
		/// <param name="alerts">Alert objects that need to be removed.</param>
		void RemoveAlerts( AlertCollection alerts );

	}

}
