using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class EmployeeGroupAlertBll {

		#region -_ Private Members _-

		private IEmployeeGroupAlertDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateEmployeeGroupAlertDal();

		#endregion

		#region -_ Business Methods _-

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all employeegroupalerts from the database.
		/// </summary>
		/// <returns>An EmployeeGroupAlertDataCollection containing all employeegroupalerts.</returns>
		public EmployeeGroupAlertDataCollection GetEmployeeGroupAlerts() {
			return dal.GetEmployeeGroupAlerts();
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific alert.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		public EmployeeGroupAlertDataCollection GetEmployeeGroupAlertsForAlert( int alertSysId ) {
			return dal.GetEmployeeGroupAlertsForAlert( alertSysId );
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		public EmployeeGroupAlertDataCollection GetEmployeeGroupAlertsForEmployeeGroup( int employeeGroupSysId ) {
			return dal.GetEmployeeGroupAlertsForEmployeeGroup( employeeGroupSysId );
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific alert and employeegroup.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		public EmployeeGroupAlertDataCollection GetEmployeeGroupAlertsForAlertAndEmployeeGroup( int alertSysId , int employeeGroupSysId ) {
			return dal.GetEmployeeGroupAlertsForAlertAndEmployeeGroup( alertSysId , employeeGroupSysId );
		}

		/// <summary>
		/// Get a single employeegroupalert from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the employeegroupalert to retrieve.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the requested employeegroupalert.</returns>
		public EmployeeGroupAlertDataCollection GetEmployeeGroupAlertBySysId( int sysId ) {
			return dal.GetEmployeeGroupAlertBySysId( sysId );
		}

		/// <summary>
		/// Get multiple employeegroupalerts from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the employeegroupalerts to retrieve.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the requested employeegroupalerts.</returns>
		public EmployeeGroupAlertDataCollection GetEmployeeGroupAlertsBySysIds( int[] sysIds ) {
			return dal.GetEmployeeGroupAlertsBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more employeegroupalerts to the database.
		/// </summary>
		/// <param name="employeegroupalerts">An EmployeeGroupAlertDataCollection containing the employeegroupalerts to insert.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the inserted employeegroupalerts.</returns>
		public EmployeeGroupAlertDataCollection InsertEmployeeGroupAlerts( EmployeeGroupAlertDataCollection employeegroupalerts ) {
			return dal.InsertEmployeeGroupAlerts( employeegroupalerts );
		}

		/// <summary>
		/// Update one or more employeegroupalerts in the database.
		/// </summary>
		/// <param name="employeegroupalerts">An EmployeeGroupAlertDataCollection containing the employeegroupalerts to update.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the updated employeegroupalerts.</returns>
		public EmployeeGroupAlertDataCollection UpdateEmployeeGroupAlerts( EmployeeGroupAlertDataCollection employeegroupalerts ) {
			return dal.UpdateEmployeeGroupAlerts( employeegroupalerts );
		}

		/// <summary>
		/// Remove one or more employeegroupalerts from the database.
		/// </summary>
		/// <param name="employeegroupalerts">An EmployeeGroupAlertDataCollection containing the employeegroupalerts to remove.</param>
		public void RemoveEmployeeGroupAlerts( EmployeeGroupAlertDataCollection employeegroupalerts ) {
			dal.RemoveEmployeeGroupAlerts( employeegroupalerts );
		}

		/// <summary>
		/// Remove all employeegroupalerts from the database.
		/// </summary>
		public void RemoveAllEmployeeGroupAlerts() {
			dal.RemoveAllEmployeeGroupAlerts();
		}

		#endregion

	}

}
