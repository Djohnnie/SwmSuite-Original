using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the EmployeeService methods.
	/// </summary>
	public interface IEmployeeGroupDal {

		/// <summary>
		/// Get the number of EmployeeGroups in the database.
		/// </summary>
		/// <returns>The number of EmployeeGroups in the database.</returns>
		int CountEmployeeGroups();

		/// <summary>
		/// Get all employeegroups from the database.
		/// </summary>
		/// <returns>An EmployeeGroupCollection containing all employeegroups.</returns>
		EmployeeGroupDataCollection GetEmployeeGroups();

		/// <summary>
		/// Get the employeegroups for the given employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the employee groups for.</param>
		/// <returns>An EmployeeGroupDataCollection containing the requested employee groups.</returns>
		EmployeeGroupDataCollection GetEmployeeGroupByEmployee( int employeeSysId );

		/// <summary>
		/// Get a single employeegroup from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employeegroup to retrieve.</param>
		/// <returns>An EmployeeGroupCollection containing the requested employeegroup.</returns>
		EmployeeGroupDataCollection GetEmployeeGroupBySysId( int sysId );

		/// <summary>
		/// Get multiple employeegroups from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the employeegroups to retrieve.</param>
		/// <returns>An EmployeeGroupCollection containing the requested employeegroups.</returns>
		EmployeeGroupDataCollection GetEmployeeGroupsBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more employeegroups to the database.
		/// </summary>
		/// <param name="employeeGroups">An EmployeeGroupCollection containing the employeegroups to insert.</param>
		/// <returns>An EmployeeGroupCollection containing the inserted employeegroups.</returns>
		EmployeeGroupDataCollection InsertEmployeeGroups( EmployeeGroupDataCollection employeeGroups );

		/// <summary>
		/// Update one or more employeegroups in the database.
		/// </summary>
		/// <param name="employeeGroups">An EmployeeGroupCollection containing the employeegroups to update.</param>
		/// <returns>An EmployeeGroupCollection containing the updated employeegroups.</returns>
		EmployeeGroupDataCollection UpdateEmployeeGroups( EmployeeGroupDataCollection employeeGroups );

		/// <summary>
		/// Remove one or more employeegroups from the database.
		/// </summary>
		/// <param name="employeeGroups">An EmployeeGroupCollection containing the employeegroups to remove.</param>
		void RemoveEmployeeGroups( EmployeeGroupDataCollection employeeGroups );

		/// <summary>
		/// Remove all employeegroups from the database.
		/// </summary>
		void RemoveAllEmployeeGroups();

	}

}
