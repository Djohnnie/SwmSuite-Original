using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the EmployeeGroupAlertService methods.
	/// </summary>
	public interface IEmployeeGroupAlertDal {

		/// <summary>
		/// Get all employeegroupalerts from the database.
		/// </summary>
		/// <returns>A EmployeeGroupAlertDataCollection containing all employeegroupalerts.</returns>
		EmployeeGroupAlertDataCollection GetEmployeeGroupAlerts();

		/// <summary>
		/// Get all employeealerts from the database for a specific alert.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeGroupAlertDataCollection GetEmployeeGroupAlertsForAlert( int alertSysId );

		/// <summary>
		/// Get all employeealerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeGroupAlertDataCollection GetEmployeeGroupAlertsForEmployeeGroup( int employeeGroupSysId );

		/// <summary>
		/// Get all employeealerts from the database for a specific alert and employeegroup.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeGroupAlertDataCollection GetEmployeeGroupAlertsForAlertAndEmployeeGroup( int alertSysId , int employeeGroupSysId );

		/// <summary>
		/// Get a single employeegroupalert from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the employeegroupalert to retrieve.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the requested employeegroupalert.</returns>
		EmployeeGroupAlertDataCollection GetEmployeeGroupAlertBySysId( int sysId );

		/// <summary>
		/// Get multiple employeegroupalerts from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the employeegroupalerts to retrieve.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the requested employeegroupalerts.</returns>
		EmployeeGroupAlertDataCollection GetEmployeeGroupAlertsBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more employeegroupalerts to the database.
		/// </summary>
		/// <param name="employeegroupalerts">An EmployeeGroupAlertDataCollection containing the employeegroupalerts to insert.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the inserted employeegroupalerts.</returns>
		EmployeeGroupAlertDataCollection InsertEmployeeGroupAlerts( EmployeeGroupAlertDataCollection employeegroupalerts );

		/// <summary>
		/// Update one or more employeegroupalerts in the database.
		/// </summary>
		/// <param name="employeegroupalerts">An EmployeeGroupAlertDataCollection containing the employeegroupalerts to update.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the updated employeegroupalerts.</returns>
		EmployeeGroupAlertDataCollection UpdateEmployeeGroupAlerts( EmployeeGroupAlertDataCollection employeegroupalerts );

		/// <summary>
		/// Remove one or more employeegroupalerts from the database.
		/// </summary>
		/// <param name="employeegroupalerts">An EmployeeGroupAlertDataCollection containing the employeegroupalerts to remove.</param>
		void RemoveEmployeeGroupAlerts( EmployeeGroupAlertDataCollection employeegroupalerts );

		/// <summary>
		/// Remove all employeegroupalerts from the database.
		/// </summary>
		void RemoveAllEmployeeGroupAlerts();

	}

}
