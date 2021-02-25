using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public sealed class AlertFacade :
		ServiceFacade<AlertService.AlertService , AlertService.SwmSuiteSoapHeader> ,
		IAlertFacade {

		/// <summary>
		/// Get all alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection IAlertFacade.GetAlerts() {
			try {
				AlertCollection alerts = new AlertCollection();
				foreach( AlertService.Alert alert in GetService().GetAlerts() ) {
					alerts.Add( (Alert)XmlSerialization.ConvertObject( alert , typeof( AlertService.Alert ) , typeof( Alert ) ) );
				}
				return alerts;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all global alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection IAlertFacade.GetGlobalAlerts() {
			try {
				AlertCollection alerts = new AlertCollection();
				foreach( AlertService.Alert alert in GetService().GetGlobalAlerts() ) {
					alerts.Add( (Alert)XmlSerialization.ConvertObject( alert , typeof( AlertService.Alert ) , typeof( Alert ) ) );
				}
				return alerts;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all alerts from the database for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection IAlertFacade.GetAlertsForEmployee( Employee employee ) {
			try {
				AlertService.Employee employeeParameter =
				(AlertService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( AlertService.Employee ) );
				AlertCollection alerts = new AlertCollection();
				foreach( AlertService.Alert alert in GetService().GetAlertsForEmployee( employeeParameter ) ) {
					alerts.Add( (Alert)XmlSerialization.ConvertObject( alert , typeof( AlertService.Alert ) , typeof( Alert ) ) );
				}
				return alerts;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all alerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertCollection IAlertFacade.GetAlertsForEmployeeGroup( EmployeeGroup employeeGroup ) {
			try {
				AlertService.EmployeeGroup employeeGroupParameter =
				(AlertService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( AlertService.EmployeeGroup ) );
				AlertCollection alerts = new AlertCollection();
				foreach( AlertService.Alert alert in GetService().GetAlertsForEmployeeGroup( employeeGroupParameter ) ) {
					alerts.Add( (Alert)XmlSerialization.ConvertObject( alert , typeof( AlertService.Alert ) , typeof( Alert ) ) );
				}
				return alerts;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Create a new alert.
		/// </summary>
		/// <param name="alert">Alert object that needs to be created.</param>
		void IAlertFacade.CreateAlert( Alert alert ) {
			try {
				AlertService.Alert alertParameter =
				(AlertService.Alert)XmlSerialization.ConvertObject( alert , typeof( Alert ) , typeof( AlertService.Alert ) );
				GetService().CreateAlert( alertParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing alert.
		/// </summary>
		/// <param name="alert">Alert object that needs to be updated.</param>
		void IAlertFacade.UpdateAlert( Alert alert ) {
			try {
				AlertService.Alert alertParameter =
				(AlertService.Alert)XmlSerialization.ConvertObject( alert , typeof( Alert ) , typeof( AlertService.Alert ) );
				GetService().UpdateAlert( alertParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove one or more existing alerts.
		/// </summary>
		/// <param name="alerts">Alert objects that need to be removed.</param>
		void IAlertFacade.RemoveAlerts( AlertCollection alerts ) {
			try {
				AlertService.Alert[] alertsParameter = new AlertService.Alert[alerts.Count];
				foreach( Alert alert in alerts ) {
					alertsParameter[alerts.IndexOf( alert )] =
						(AlertService.Alert)XmlSerialization.ConvertObject( alert , typeof( Alert ) , typeof( AlertService.Alert ) );
				}
				GetService().RemoveAlerts( alertsParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

	}

}
