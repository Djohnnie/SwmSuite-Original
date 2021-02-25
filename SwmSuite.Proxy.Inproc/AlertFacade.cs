using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {

	public sealed class AlertFacade : IAlertFacade {

		/// <summary>
		/// Get all alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection IAlertFacade.GetAlerts() {
			return new AlertBll().GetAlerts();
		}

		/// <summary>
		/// Get all global alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection IAlertFacade.GetGlobalAlerts() {
			return new AlertBll().GetGlobalAlerts();
		}

		/// <summary>
		/// Get all alerts from the database for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection IAlertFacade.GetAlertsForEmployee( Employee employee ) {
			return new AlertBll().GetAlerts( employee );
		}

		/// <summary>
		/// Get all alerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection IAlertFacade.GetAlertsForEmployeeGroup( EmployeeGroup employeeGroup ) {
			return new AlertBll().GetAlerts( employeeGroup );
		}

		/// <summary>
		/// Create a new alert.
		/// </summary>
		/// <param name="alert">Alert object that needs to be created.</param>
		void IAlertFacade.CreateAlert( Alert alert ) {
			new AlertBll().CreateAlert( alert );
		}

		/// <summary>
		/// Update an existing alert.
		/// </summary>
		/// <param name="alert">Alert object that needs to be updated.</param>
		void IAlertFacade.UpdateAlert( Alert alert ) {
			new AlertBll().UpdateAlert( alert );
		}

		/// <summary>
		/// Remove one or more existing alerts.
		/// </summary>
		/// <param name="alerts">Alert objects that need to be removed.</param>
		void IAlertFacade.RemoveAlerts( AlertCollection alerts ) {
			new AlertBll().RemoveAlerts( alerts );
		}

	}
}
