using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;

using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business;
using System.Transactions;

namespace SwmSuite.Business {

	public class AlertBll {

		#region -_ Private Members _-

		private IAlertDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateAlertDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		public AlertCollection GetAlerts() {
			EmployeeAlertBll employeeAlertBll = new EmployeeAlertBll();
			EmployeeGroupAlertBll employeeGroupAlertBll = new EmployeeGroupAlertBll();
			EmployeeBll employeeBll = new EmployeeBll();
			
			AlertDataCollection alertDataCollection = GetAlertData();
			EmployeeAlertDataCollection employeeAlertDataCollection = employeeAlertBll.GetEmployeeAlertData();
			EmployeeGroupAlertDataCollection employeeGroupAlertDataCollection = employeeGroupAlertBll.GetEmployeeGroupAlerts();

			AlertCollection alertCollectionToReturn = new AlertCollection();

			foreach( AlertData alertData in alertDataCollection ) {
				Alert newAlert = new Alert();
				newAlert.SysId = alertData.SysId;
				newAlert.RowVersion = alertData.RowVersion;
				newAlert.Message = alertData.Message;
				newAlert.Visible = alertData.Visible;
				newAlert.Employees = new EmployeeCollection();
				foreach( EmployeeAlertData employeeAlertData in employeeAlertDataCollection ) {
					if( employeeAlertData.AlertSysId == alertData.SysId ) {
						//
						// Add dummy employee instead of real data.
						//
						Employee newEmployee = new EmployeeBll().GetEmployeeDetail( employeeAlertData.EmployeeSysId );
						newAlert.Employees.Add( newEmployee );
					}
				}
				newAlert.EmployeeGroups = new EmployeeGroupCollection();
				foreach( EmployeeGroupAlertData employeeGroupAlertData in employeeGroupAlertDataCollection ) {
					if( employeeGroupAlertData.AlertSysId == alertData.SysId ) {
						//
						// Add dummy employeeGroup instead of real data.
						//
						EmployeeGroup newEmployeeGroup = new EmployeeGroupBll().GetEmployeeGroupDetail( employeeGroupAlertData.EmployeeGroupSysId );
						newAlert.EmployeeGroups.Add( newEmployeeGroup );
					}
				}
				alertCollectionToReturn.Add( newAlert );
			}

			return alertCollectionToReturn;
		}

		/// <summary>
		/// Get all global alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		public AlertCollection GetGlobalAlerts() {
			//
			// Get global alerts from database.
			//
			AlertDataCollection alertDataCollection = GetGlobalAlertData();
			//
			// Create AlertCollection.
			//
			AlertCollection alertCollectionToReturn = new AlertCollection();
			foreach( AlertData alertData in alertDataCollection ) {
				Alert newAlert = new Alert();
				newAlert.SysId = alertData.SysId;
				newAlert.RowVersion = alertData.RowVersion;
				newAlert.Message = alertData.Message;
				newAlert.Visible = alertData.Visible;
				alertCollectionToReturn.Add( newAlert );
			}
			//
			// Return.
			//
			return alertCollectionToReturn;
		}

		/// <summary>
		/// Get all alerts from the database for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		public AlertCollection GetAlerts( Employee employee ) {
			//
			// Get employee alerts from database.
			//
			AlertDataCollection alertDataCollection = GetAlertDataForEmployee( employee.SysId );
			//
			// Create AlertCollection.
			//
			AlertCollection alertCollectionToReturn = new AlertCollection();
			foreach( AlertData alertData in alertDataCollection ) {
				Alert newAlert = new Alert();
				newAlert.SysId = alertData.SysId;
				newAlert.RowVersion = alertData.RowVersion;
				newAlert.Message = alertData.Message;
				newAlert.Visible = alertData.Visible;
				alertCollectionToReturn.Add( newAlert );
			}
			//
			// Return.
			//
			return alertCollectionToReturn;
		}

		/// <summary>
		/// Get all alerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		public AlertCollection GetAlerts( EmployeeGroup employeeGroup ) {
			//
			// Get employeegroup alerts from database.
			//
			AlertDataCollection alertDataCollection = GetAlertDataForEmployeeGroup( employeeGroup.SysId );
			//
			// Create AlertCollection.
			//
			AlertCollection alertCollectionToReturn = new AlertCollection();
			foreach( AlertData alertData in alertDataCollection ) {
				Alert newAlert = new Alert();
				newAlert.SysId = alertData.SysId;
				newAlert.RowVersion = alertData.RowVersion;
				newAlert.Message = alertData.Message;
				newAlert.Visible = alertData.Visible;
				alertCollectionToReturn.Add( newAlert );
			}
			//
			// Return.
			//
			return alertCollectionToReturn;
		}

		/// <summary>
		/// Create a new alert.
		/// </summary>
		/// <param name="alert">Alert object that needs to be created.</param>
		public void CreateAlert( Alert alert ) {
			using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
				EmployeeAlertBll employeeAlertBll = new EmployeeAlertBll();
				EmployeeGroupAlertBll employeeGroupAlertBll = new EmployeeGroupAlertBll();
				//
				// Create and insert the alert into the database.
				//
				AlertDataCollection alertDataCollection = AlertDataCollection.FromSingleAlert(
					new AlertData( alert.Visible , alert.Message ) );
				AlertDataCollection alertDataCollectionResult =
					this.InsertAlertData( alertDataCollection );
				//
				// Create and insert the employeealert links into the database.
				//
				EmployeeAlertDataCollection employeeAlertsToInsert = new EmployeeAlertDataCollection();
				foreach( Employee employee in alert.Employees ) {
					employeeAlertsToInsert.Add( new EmployeeAlertData( employee.SysId , alertDataCollectionResult[0].SysId ) );
				}
				if( employeeAlertsToInsert.Count > 0 ) {
					employeeAlertBll.InsertEmployeeAlertData( employeeAlertsToInsert );
				}
				//
				// Create and insert the employeegroupalert links into the database.
				//
				EmployeeGroupAlertDataCollection employeeGroupAlertsToInsert = new EmployeeGroupAlertDataCollection();
				foreach( EmployeeGroup employeeGroup in alert.EmployeeGroups ) {
					employeeGroupAlertsToInsert.Add( new EmployeeGroupAlertData( employeeGroup.SysId , alertDataCollectionResult[0].SysId ) );
				}
				if( employeeGroupAlertsToInsert.Count > 0 ) {
					employeeGroupAlertBll.InsertEmployeeGroupAlerts( employeeGroupAlertsToInsert );
				}
				scope.Complete();
			}
		}

		/// <summary>
		/// Update an existing alert.
		/// </summary>
		/// <param name="alert">Alert object that needs to be updated.</param>
		public void UpdateAlert( Alert alert ) {
			using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
				EmployeeAlertBll employeeAlertBll = new EmployeeAlertBll();
				EmployeeGroupAlertBll employeeGroupAlertBll = new EmployeeGroupAlertBll();
				//
				// Get all existing links to employees and employeegroups.
				//
				EmployeeAlertDataCollection employeeAlerts =
					employeeAlertBll.GetEmployeeAlertDataForAlert( alert.SysId );
				EmployeeGroupAlertDataCollection employeeGroupAlerts =
					employeeGroupAlertBll.GetEmployeeGroupAlertsForAlert( alert.SysId );
				//
				// Remove all links to employees and employeegroups.
				//
				employeeAlertBll.RemoveEmployeeAlertData( employeeAlerts );
				employeeGroupAlertBll.RemoveEmployeeGroupAlerts( employeeGroupAlerts );
				//
				// Create data for alert.
				//
				AlertData alertDataToUpdate = new AlertData();
				alertDataToUpdate.SysId = alert.SysId;
				alertDataToUpdate.RowVersion = alert.RowVersion;
				alertDataToUpdate.Visible = alert.Visible;
				alertDataToUpdate.Message = alert.Message;
				//
				// Update alert.
				//
				AlertDataCollection alertDataResult =
					this.UpdateAlertData( AlertDataCollection.FromSingleAlert( alertDataToUpdate ) );
				//
				// Create new links to employees and employeegroups.
				//
				EmployeeAlertDataCollection newEmployeeAlerts = new EmployeeAlertDataCollection();
				EmployeeGroupAlertDataCollection newEmployeeGroupAlerts = new EmployeeGroupAlertDataCollection();
				foreach( Employee employee in alert.Employees ) {
					newEmployeeAlerts.Add( new EmployeeAlertData( employee.SysId , alert.SysId ) );
				}
				foreach( EmployeeGroup employeeGroup in alert.EmployeeGroups ) {
					newEmployeeGroupAlerts.Add( new EmployeeGroupAlertData( employeeGroup.SysId , alert.SysId ) );
				}
				employeeAlertBll.InsertEmployeeAlertData( newEmployeeAlerts );
				employeeGroupAlertBll.InsertEmployeeGroupAlerts( newEmployeeGroupAlerts );

				scope.Complete();
			}
		}

		/// <summary>
		/// Remove one or more existing alerts.
		/// </summary>
		/// <param name="alerts">Alert objects that need to be removed.</param>
		public void RemoveAlerts( AlertCollection alerts ) {
			using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
				EmployeeAlertBll employeeAlertBll = new EmployeeAlertBll();
				EmployeeGroupAlertBll employeeGroupAlertBll = new EmployeeGroupAlertBll();

				EmployeeAlertDataCollection employeeAlertsToRemove = new EmployeeAlertDataCollection();
				EmployeeGroupAlertDataCollection employeeGroupAlertsToRemove = new EmployeeGroupAlertDataCollection();
				AlertDataCollection alertsToRemove = new AlertDataCollection();

				foreach( Alert alert in alerts ) {
					//
					// Get all existing links to employees and employeegroups.
					//
					employeeAlertsToRemove.Add(
						employeeAlertBll.GetEmployeeAlertDataForAlert( alert.SysId ) );
					employeeGroupAlertsToRemove.Add(
						employeeGroupAlertBll.GetEmployeeGroupAlertsForAlert( alert.SysId ) );
					//
					// Create data for alert.
					//
					alertsToRemove.Add( new AlertData() { SysId = alert.SysId, RowVersion = alert.RowVersion, Visible = alert.Visible , Message = alert.Message } );
				}
				//
				// Remove all links to employees and employeegroups.
				//
				employeeAlertBll.RemoveEmployeeAlertData( employeeAlertsToRemove );
				employeeGroupAlertBll.RemoveEmployeeGroupAlerts( employeeGroupAlertsToRemove );
				//
				// Remove alerts.
				//
				this.RemoveAlertData( alertsToRemove );

				scope.Complete();
			}
		}

		#endregion

		#region -_ Crud Methods _-

		/// <summary>
		/// Get all alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all alerts.</returns>
		public AlertDataCollection GetAlertData() {
			return dal.GetAlertData();
		}

		/// <summary>
		/// Get all alerts from the database not linked to an employee or employeegroup.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		public AlertDataCollection GetGlobalAlertData() {
			return dal.GetGlobalAlertData();
		}

		/// <summary>
		/// Get all alerts from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		public AlertDataCollection GetAlertDataForEmployee( int employeeSysId ) {
			return dal.GetAlertDataForEmployee( employeeSysId );
		}

		/// <summary>
		/// Get all alerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		public AlertDataCollection GetAlertDataForEmployeeGroup( int employeeGroupSysId ) {
			return dal.GetAlertDataForEmployeeGroup( employeeGroupSysId );
		}

		/// <summary>
		/// Get a single alert from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the alert to retrieve.</param>
		/// <returns>An AlertCollection containing the requested alert.</returns>
		public AlertDataCollection GetAlertDataBySysId( int sysId ) {
			return dal.GetAlertDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple alerts from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the alerts to retrieve.</param>
		/// <returns>An AlertCollection containing the requested alerts.</returns>
		public AlertDataCollection GetAlertDataBySysIds( int[] sysIds ) {
			return dal.GetAlertDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more alerts to the database.
		/// </summary>
		/// <param name="alerts">An AlertCollection containing the alerts to insert.</param>
		/// <returns>An AlertCollection containing the inserted alerts.</returns>
		public AlertDataCollection InsertAlertData( AlertDataCollection alerts ) {
			return dal.InsertAlertData( alerts );
		}

		/// <summary>
		/// Update one or more alerts in the database.
		/// </summary>
		/// <param name="alerts">An AlertCollection containing the alerts to update.</param>
		/// <returns>An AlertCollection containing the updated alerts.</returns>
		public AlertDataCollection UpdateAlertData( AlertDataCollection alerts ) {
			return dal.UpdateAlertData( alerts );
		}

		/// <summary>
		/// Remove one or more alerts from the database.
		/// </summary>
		/// <param name="alerts">An AlertCollection containing the alerts to remove.</param>
		public void RemoveAlertData( AlertDataCollection alerts ) {
			dal.RemoveAlertData( alerts );
		}

		/// <summary>
		/// Remove all alerts from the database.
		/// </summary>
		public void RemoveAllAlertData() {
			dal.RemoveAllAlertData();
		}

		#endregion

	}

}
