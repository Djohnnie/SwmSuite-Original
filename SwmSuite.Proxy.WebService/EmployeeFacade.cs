using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public sealed class EmployeeFacade :
		ServiceFacade<EmployeeService.EmployeeService , EmployeeService.SwmSuiteSoapHeader> ,
		IEmployeeFacade {

		/// <summary>
		/// Get all employeegroups from the database.
		/// </summary>
		/// <returns>An EmployeeGroupCollection containing all employeegroups.</returns>
		EmployeeGroupCollection IEmployeeFacade.GetEmployeeGroups() {
			try {
				EmployeeGroupCollection employeeGroups = new EmployeeGroupCollection();
				foreach( EmployeeService.EmployeeGroup employeeGroup in GetService().GetEmployeeGroups() ) {
					employeeGroups.Add( (EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeService.EmployeeGroup ) , typeof( EmployeeGroup ) ) );
				}
				return employeeGroups;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get a specific employeegroup from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employeegroup to get.</param>
		/// <returns>The requested employeegroup.</returns>
		EmployeeGroup IEmployeeFacade.GetEmployeeGroupDetail( int sysId ) {
			try {
				EmployeeService.EmployeeGroup employeeGroup = GetService().GetEmployeeGroupDetail( sysId );
				return (EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeService.EmployeeGroup ) , typeof( EmployeeGroup ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Add a new employeegroup to the database.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to add.</param>
		/// <returns>The created employeegroup.</returns>
		EmployeeGroup IEmployeeFacade.CreateEmployeeGroup( EmployeeGroup employeeGroup ) {
			try {
				EmployeeService.EmployeeGroup employeeGroupParameter =
				(EmployeeService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( EmployeeService.EmployeeGroup ) );
				EmployeeService.EmployeeGroup employeeGroupCreated =
						GetService().CreateEmployeeGroup( employeeGroupParameter );
				return (EmployeeGroup)XmlSerialization.ConvertObject( employeeGroupCreated , typeof( EmployeeService.EmployeeGroup ) , typeof( EmployeeGroup ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing employeegroup in the database.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to update.</param>
		/// <returns>The updated employeegroup.</returns>
		EmployeeGroup IEmployeeFacade.UpdateEmployeeGroup( EmployeeGroup employeeGroup ) {
			try {
				EmployeeService.EmployeeGroup employeeGroupParameter =
				(EmployeeService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( EmployeeService.EmployeeGroup ) );
				EmployeeService.EmployeeGroup employeeGroupUpdated =
						GetService().UpdateEmployeeGroup( employeeGroupParameter );
				return (EmployeeGroup)XmlSerialization.ConvertObject( employeeGroupUpdated , typeof( EmployeeService.EmployeeGroup ) , typeof( EmployeeGroup ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove one or more employeegroups from the database.
		/// </summary>
		/// <param name="employeeGroups">The employeegroups to remove.</param>
		void IEmployeeFacade.RemoveEmployeeGroups( EmployeeGroupCollection employeeGroups ) {
			try {
				EmployeeService.EmployeeGroup[] employeeGroupsParameter = new EmployeeService.EmployeeGroup[employeeGroups.Count];
				foreach( EmployeeGroup employeeGroup in employeeGroups ) {
					employeeGroupsParameter[employeeGroups.IndexOf( employeeGroup )] =
						(EmployeeService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( EmployeeService.EmployeeGroup ) );
				}
				GetService().RemoveEmployeeGroups( employeeGroupsParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get the employeegroup for the given employee.
		/// </summary>
		/// <param name="employee">The employee to get the employeegroup for.</param>
		/// <returns>The requested employeegroup.</returns>
		EmployeeGroup IEmployeeFacade.GetEmployeeGroupForEmployee( Employee employee ) {
			try {
				EmployeeService.Employee employeeParameter = (EmployeeService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( EmployeeService.Employee ) );
				EmployeeService.EmployeeGroup employeeGroupToReturn = GetService().GetEmployeeGroupForEmployee( employeeParameter );
				return (EmployeeGroup)XmlSerialization.ConvertObject( employeeGroupToReturn , typeof( EmployeeService.EmployeeGroup ) , typeof( EmployeeGroup ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all employees from the database.
		/// </summary>
		/// <returns>An employeeCollection containing all employees.</returns>
		EmployeeCollection IEmployeeFacade.GetEmployees() {
			try {
				EmployeeCollection employees = new EmployeeCollection();
				foreach( EmployeeService.Employee employee in GetService().GetEmployees() ) {
					employees.Add( (Employee)XmlSerialization.ConvertObject( employee , typeof( EmployeeService.Employee ) , typeof( Employee ) ) );
				}
				return employees;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all employees from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the employees for.</param>
		/// <returns>An EmployeeCollection containing the requested employees.</returns>
		EmployeeCollection IEmployeeFacade.GetEmployeesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			try {
				EmployeeCollection employees = new EmployeeCollection();
				EmployeeService.EmployeeGroup employeeGroupParameter =
					(EmployeeService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( EmployeeService.EmployeeGroup ) );
				foreach( EmployeeService.Employee employee in GetService().GetEmployeesForEmployeeGroup( employeeGroupParameter ) ) {
					employees.Add( (Employee)XmlSerialization.ConvertObject( employee , typeof( EmployeeService.Employee ) , typeof( Employee ) ) );
				}
				return employees;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get a specific employee from the database containing all the details.
		/// </summary>
		/// <param name="sysId">The internal id of the employee to get.</param>
		/// <returns></returns>
		Employee IEmployeeFacade.GetEmployeeDetail( int sysId ) {
			try {
				EmployeeService.Employee employee = GetService().GetEmployeeDetail( sysId );
				return (Employee)XmlSerialization.ConvertObject( employee , typeof( EmployeeService.Employee ) , typeof( Employee ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Add a new employee tot the database.
		/// </summary>
		/// <param name="employee">The employee to create.</param>
		/// <param name="employeeGroup">The employeegroup that will contain this employee.</param>
		/// <returns>The created employee.</returns>
		Employee IEmployeeFacade.CreateEmployee( Employee employee , EmployeeGroup employeeGroup ) {
			try {
				EmployeeService.Employee employeeParameter =
				(EmployeeService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( EmployeeService.Employee ) );
				EmployeeService.EmployeeGroup employeeGroupParameter =
					(EmployeeService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( EmployeeService.EmployeeGroup ) );
				EmployeeService.Employee employeeCreated =
						GetService().CreateEmployee( employeeParameter , employeeGroupParameter );
				return (Employee)XmlSerialization.ConvertObject( employeeCreated , typeof( EmployeeService.Employee ) , typeof( Employee ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing employee in the database.
		/// </summary>
		/// <param name="employee">The employee to update.</param>
		/// <param name="employeeGroup">The employeegroup that will contain this employee.</param>
		/// <returns>The updated employee.</returns>
		Employee IEmployeeFacade.UpdateEmployee( Employee employee , EmployeeGroup employeeGroup ) {
			try {
				EmployeeService.Employee employeeParameter =
				(EmployeeService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( EmployeeService.Employee ) );
				EmployeeService.EmployeeGroup employeeGroupParameter =
					(EmployeeService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( EmployeeService.EmployeeGroup ) );
				EmployeeService.Employee employeeCreated =
						GetService().UpdateEmployee( employeeParameter , employeeGroupParameter );
				return (Employee)XmlSerialization.ConvertObject( employeeCreated , typeof( EmployeeService.Employee ) , typeof( Employee ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove one or more employees from the database.
		/// </summary>
		/// <param name="employees">The employees to remove.</param>
		void IEmployeeFacade.RemoveEmployees( EmployeeCollection employees ) {
			try {
				EmployeeService.Employee[] employeesParameter = new EmployeeService.Employee[employees.Count];
				foreach( Employee employee in employees ) {
					employeesParameter[employees.IndexOf( employee )] =
						(EmployeeService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( EmployeeService.Employee ) );
				}
				GetService().RemoveEmployees( employeesParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Changes the password of a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to change the password for.</param>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="newPassword">The new password.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		bool IEmployeeFacade.ChangePassword( String userName , String oldPassword , String newPassword ) {
			try {
				return GetService().ChangePassword( userName , oldPassword , newPassword );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get an employee that should autologin on the given machine.
		/// </summary>
		/// <param name="machineName">The machine name to get the autologon employee for.</param>
		/// <returns>The employee that should autologon.</returns>
		Employee IEmployeeFacade.GetDefaultEmployeeForMachineName( String machineName ) {
			try {
				EmployeeService.Employee employeeToReturn = GetService().GetDefaultEmployeeForMachineName( machineName );
				return (Employee)XmlSerialization.ConvertObject( employeeToReturn , typeof( EmployeeService.Employee ) , typeof( Employee ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get the employee settings for a given sysid.
		/// </summary>
		/// <param name="sysId">The internal id of the employee settings to get.</param>
		/// <returns>The requested employee settings.</returns>
		EmployeeSettings IEmployeeFacade.GetEmployeeSettings( int sysId ) {
			EmployeeService.EmployeeSettings employeeSettings =
				GetService().GetEmployeeSettings( sysId );
			return (EmployeeSettings)XmlSerialization.ConvertObject( employeeSettings , typeof( EmployeeService.EmployeeSettings ) , typeof( EmployeeSettings ) );
		}

		/// <summary>
		/// Get the employee settings for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the settings for.</param>
		/// <returns>The requested employee settings.</returns>
		EmployeeSettings IEmployeeFacade.GetEmployeeSettingsForEmployee( Employee employee ) {
			EmployeeService.Employee employeeParameter =
				(EmployeeService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( EmployeeService.Employee ) );
			EmployeeService.EmployeeSettings employeeSettings =
				GetService().GetEmployeeSettingsForEmployee( employeeParameter );
			return (EmployeeSettings)XmlSerialization.ConvertObject( employeeSettings , typeof( EmployeeService.EmployeeSettings ) , typeof( EmployeeSettings ) );
		}

		/// <summary>
		/// Set new employee settings for a specific employee.
		/// </summary>
		/// <param name="employeeSettings">The employee settings to set.</param>
		/// <param name="employee">The employee to set the settings for.</param>
		/// <returns>The created employee settings.</returns>
		EmployeeSettings IEmployeeFacade.SetEmployeeSettingsForEmployee( EmployeeSettings employeeSettings , Employee employee ) {
			EmployeeService.EmployeeSettings employeeSettingsParameter =
				(EmployeeService.EmployeeSettings)XmlSerialization.ConvertObject( employeeSettings , typeof( EmployeeSettings ) , typeof( EmployeeService.EmployeeSettings ) );
			EmployeeService.Employee employeeParameter =
				(EmployeeService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( EmployeeService.Employee ) );
			EmployeeService.EmployeeSettings employeeSettingsToReturn =
				GetService().SetEmployeeSettingsForEmployee( employeeSettingsParameter , employeeParameter );
			return (EmployeeSettings)XmlSerialization.ConvertObject( employeeSettingsToReturn , typeof( EmployeeService.EmployeeSettings ) , typeof( EmployeeSettings ) );
		}

	}

}
