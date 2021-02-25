using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the EmployeeAlertService methods.
	/// </summary>
	public interface IEmployeeAlertDal {

		/// <summary>
		/// Get all employeealerts from the database.
		/// </summary>
		/// <returns>A EmployeeAlertDataCollection containing all employeealerts.</returns>
		EmployeeAlertDataCollection GetEmployeeAlertData();

		/// <summary>
		/// Get all employeealerts from the database for a specific alert.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeAlertDataCollection GetEmployeeAlertDataForAlert( int alertSysId );

		/// <summary>
		/// Get all employeealerts from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeAlertDataCollection GetEmployeeAlertDataForEmployee( int employeeSysId );

		/// <summary>
		/// Get all employeealerts from the database for a specific alert and employee.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <param name="employeeSysId">The internal id of the employee to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeAlertDataCollection GetEmployeeAlertDataForAlertAndEmployee( int alertSysId , int employeeSysId );

		/// <summary>
		/// Get a single employeealert from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the employeealert to retrieve.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeAlertDataCollection GetEmployeeAlertDataBySysId( int sysId );

		/// <summary>
		/// Get multiple employeealerts from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the employeealerts to retrieve.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealerts.</returns>
		EmployeeAlertDataCollection GetEmployeeAlertDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more employeealerts to the database.
		/// </summary>
		/// <param name="employeealerts">An EmployeeAlertDataCollection containing the employeealerts to insert.</param>
		/// <returns>An EmployeeAlertDataCollection containing the inserted employeealerts.</returns>
		EmployeeAlertDataCollection InsertEmployeeAlertData( EmployeeAlertDataCollection employeealerts );

		/// <summary>
		/// Update one or more employeealerts in the database.
		/// </summary>
		/// <param name="employeealerts">An EmployeeAlertCollection containing the employeealerts to update.</param>
		/// <returns>An EmployeeAlertDataCollection containing the updated employeealerts.</returns>
		EmployeeAlertDataCollection UpdateEmployeeAlertData( EmployeeAlertDataCollection employeealerts );

		/// <summary>
		/// Remove one or more employeealerts from the database.
		/// </summary>
		/// <param name="employeealerts">An EmployeeAlertDataCollection containing the employeealerts to remove.</param>
		void RemoveEmployeeAlertData( EmployeeAlertDataCollection employeealerts );

		/// <summary>
		/// Remove all employeealerts from the database.
		/// </summary>
		void RemoveAllEmployeeAlertData();

	}


}
