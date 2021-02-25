using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {
	
	/// <summary>
  /// DAL Interface for the EmployeeService methods.
  /// </summary>
	public interface IEmployeeDal {

		/// <summary>
		/// Get all employees from the database.
		/// </summary>
		/// <returns>An EmployeeCollection containing all employees.</returns>
		EmployeeDataCollection GetEmployeeData();

		/// <summary>
		/// Get all employees from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the employees for.</param>
		/// <returns>An EmployeeCollection containing all requested employees.</returns>
		EmployeeDataCollection GetEmployeeDataForEmployeeGroup( int employeeGroupSysId );

		/// <summary>
		/// Get all employees from the database for a specific machinename.
		/// </summary>
		/// <param name="machineName">The machine name to get the default employee for.</param>
		/// <returns>An EmployeeDataCollection containing all requested employees.</returns>
		/// <remarks>This method gets the employees that have an autologin setting on a specific machine.</remarks>
		EmployeeDataCollection GetDefaultEmployeeForMachineName( String machineName );

		/// <summary>
		/// Get a single employee from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employee to retrieve.</param>
		/// <returns>An EmployeeCollection containing the requested employee.</returns>
		EmployeeDataCollection GetEmployeeDataBySysId( int sysId );

		/// <summary>
		/// Get multiple employees from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the employees to retrieve.</param>
		/// <returns>An EmployeeCollection containing the requested employees.</returns>
		EmployeeDataCollection GetEmployeeDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more employees to the database.
		/// </summary>
		/// <param name="employees">An EmployeeCollection containing the employees to insert.</param>
		/// <returns>An EmployeeCollection containing the inserted employees.</returns>
		EmployeeDataCollection InsertEmployeeData( EmployeeDataCollection employees );

		/// <summary>
		/// Update one or more employees in the database.
		/// </summary>
		/// <param name="employees">An EmployeeCollection containing the employees to update.</param>
		/// <returns>An EmployeeCollection containing the updated employees.</returns>
		EmployeeDataCollection UpdateEmployeeData( EmployeeDataCollection employees );

		/// <summary>
		/// Remove one or more employees from the database.
		/// </summary>
		/// <param name="employees">An EmployeeCollection containing the employees to remove.</param>
		void RemoveEmployeeData( EmployeeDataCollection employees );

		/// <summary>
		/// Remove all employees from the database.
		/// </summary>
		void RemoveAllEmployeeData();

	}

}
