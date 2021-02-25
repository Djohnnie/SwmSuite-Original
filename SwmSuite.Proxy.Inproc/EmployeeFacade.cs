using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {
	
	public sealed class EmployeeFacade : IEmployeeFacade {

		/// <summary>
		/// Get all employeegroups from the database.
		/// </summary>
		/// <returns>An EmployeeGroupCollection containing all employeegroups.</returns>
		EmployeeGroupCollection IEmployeeFacade.GetEmployeeGroups() {
			return new EmployeeGroupBll().GetEmployeeGroups();
		}

		/// <summary>
		/// Get a specific employeegroup from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employeegroup to get.</param>
		/// <returns>The requested employeegroup.</returns>
		EmployeeGroup IEmployeeFacade.GetEmployeeGroupDetail( int sysId ) {
			return new EmployeeGroupBll().GetEmployeeGroupDetail( sysId );
		}

		/// <summary>
		/// Add a new employeegroup to the database.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to add.</param>
		/// <returns>The created employeegroup.</returns>
		EmployeeGroup IEmployeeFacade.CreateEmployeeGroup( EmployeeGroup employeeGroup ) {
			return new EmployeeGroupBll().CreateEmployeeGroup( employeeGroup );
		}

		/// <summary>
		/// Update an existing employeegroup in the database.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to update.</param>
		/// <returns>The updated employeegroup.</returns>
		EmployeeGroup IEmployeeFacade.UpdateEmployeeGroup( EmployeeGroup employeeGroup ) {
			return new EmployeeGroupBll().UpdateEmployeeGroup( employeeGroup );
		}

		/// <summary>
		/// Remove one or more employeegroups from the database.
		/// </summary>
		/// <param name="employeeGroups">The employeegroups to remove.</param>
		void IEmployeeFacade.RemoveEmployeeGroups( EmployeeGroupCollection employeeGroups ) {
			new EmployeeGroupBll().RemoveEmployeeGroups( employeeGroups );
		}

		/// <summary>
		/// Get the employeegroup for the given employee.
		/// </summary>
		/// <param name="employee">The employee to get the employeegroup for.</param>
		/// <returns>The requested employeegroup.</returns>
		EmployeeGroup IEmployeeFacade.GetEmployeeGroupForEmployee( Employee employee ) {
			return new EmployeeGroupBll().GetEmployeeGroupForEmployee( employee );
		}

		/// <summary>
		/// Get all employees from the database.
		/// </summary>
		/// <returns>An employeeCollection containing all employees.</returns>
		EmployeeCollection IEmployeeFacade.GetEmployees() {
			return new EmployeeBll().GetEmployees();
		}

		/// <summary>
		/// Get all employees from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the employees for.</param>
		/// <returns>An EmployeeCollection containing the requested employees.</returns>
		EmployeeCollection IEmployeeFacade.GetEmployeesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			return new EmployeeBll().GetEmployeesForEmployeeGroup( employeeGroup );
		}

		/// <summary>
		/// Get a specific employee from the database containing all the details.
		/// </summary>
		/// <param name="sysId">The internal id of the employee to get.</param>
		/// <returns></returns>
		Employee IEmployeeFacade.GetEmployeeDetail( int sysId ) {
			return new EmployeeBll().GetEmployeeDetail( sysId );
		}

		/// <summary>
		/// Add a new employee tot the database.
		/// </summary>
		/// <param name="employee">The employee to create.</param>
		/// <param name="employeeGroup">The employeegroup that will contain this employee.</param>
		/// <returns>The created employee.</returns>
		Employee IEmployeeFacade.CreateEmployee( Employee employee , EmployeeGroup employeeGroup ) {
			return new EmployeeBll().CreateEmployee( employee , employeeGroup );
		}

		/// <summary>
		/// Update an existing employee in the database.
		/// </summary>
		/// <param name="employee">The employee to update.</param>
		/// <param name="employeeGroup">The employeegroup that will contain this employee.</param>
		/// <returns>The updated employee.</returns>
		Employee IEmployeeFacade.UpdateEmployee( Employee employee , EmployeeGroup employeeGroup ) {
			return new EmployeeBll().UpdateEmployee( employee, employeeGroup );
		}

		/// <summary>
		/// Remove one or more employees from the database.
		/// </summary>
		/// <param name="employees">The employees to remove.</param>
		void IEmployeeFacade.RemoveEmployees( EmployeeCollection employees ) {
			new EmployeeBll().RemoveEmployees( employees );
		}

		/// <summary>
		/// Changes the password of a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to change the password for.</param>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="newPassword">The new password.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		bool IEmployeeFacade.ChangePassword( String userName , String oldPassword , String newPassword ) {
			return new UserBll().ChangePassword( userName , oldPassword , newPassword );
		}

		/// <summary>
		/// Get an employee that should autologin on the given machine.
		/// </summary>
		/// <param name="machineName">The machine name to get the autologon employee for.</param>
		/// <returns>The employee that should autologon.</returns>
		Employee IEmployeeFacade.GetDefaultEmployeeForMachineName( String machineName ) {
			return new EmployeeBll().GetDefaultEmployeeForMachineName( machineName );
		}

		/// <summary>
		/// Get the employee settings for a given sysid.
		/// </summary>
		/// <param name="sysId">The internal id of the employee settings to get.</param>
		/// <returns>The requested employee settings.</returns>
		EmployeeSettings IEmployeeFacade.GetEmployeeSettings( int sysId ) {
			return new EmployeeSettingsBll().GetEmployeeSettings( sysId );
		}

		/// <summary>
		/// Get the employee settings for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the settings for.</param>
		/// <returns>The requested employee settings.</returns>
		EmployeeSettings IEmployeeFacade.GetEmployeeSettingsForEmployee( Employee employee ) {
			return new EmployeeSettingsBll().GetEmployeeSettingsForEmployee( employee );
		}

		/// <summary>
		/// Set new employee settings for a specific employee.
		/// </summary>
		/// <param name="employeeSettings">The employee settings to set.</param>
		/// <param name="employee">The employee to set the settings for.</param>
		/// <returns>The created employee settings.</returns>
		EmployeeSettings IEmployeeFacade.SetEmployeeSettingsForEmployee( EmployeeSettings employeeSettings , Employee employee ) {
			return new EmployeeSettingsBll().SetEmployeeSettingsForEmployee( employeeSettings , employee );
		}

	}

}
