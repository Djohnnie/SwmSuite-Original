using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Services;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {
	/// <summary>
	/// Summary description for EmployeeService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[System.ComponentModel.ToolboxItem( false )]
	public class EmployeeService : System.Web.Services.WebService , IEmployeeFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Get all employeegroups from the database.
		/// </summary>
		/// <returns>An EmployeeGroupCollection containing all employeegroups.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public EmployeeGroupCollection GetEmployeeGroups() {
			//WebServerAuthentication.Authenticate( this.SoapHeader );
			try {
				return new EmployeeGroupBll().GetEmployeeGroups();
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get a specific employeegroup from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employeegroup to get.</param>
		/// <returns>The requested employeegroup.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public EmployeeGroup GetEmployeeGroupDetail( int sysId ) {
			//WebServerAuthentication.Authenticate( this.SoapHeader );
			try {
				return new EmployeeGroupBll().GetEmployeeGroupDetail( sysId );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Add a new employeegroup to the database.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to add.</param>
		/// <returns>The created employeegroup.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public EmployeeGroup CreateEmployeeGroup( EmployeeGroup employeeGroup ) {
			WebServerAuthentication.Authenticate( this.SoapHeader );
			try {
				return new EmployeeGroupBll().CreateEmployeeGroup( employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing employeegroup in the database.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to update.</param>
		/// <returns>The updated employeegroup.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public EmployeeGroup UpdateEmployeeGroup( EmployeeGroup employeeGroup ) {
			WebServerAuthentication.Authenticate( this.SoapHeader );
			try {
				return new EmployeeGroupBll().UpdateEmployeeGroup( employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove one or more employeegroups from the database.
		/// </summary>
		/// <param name="employeeGroups">The employeegroups to remove.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveEmployeeGroups( EmployeeGroupCollection employeeGroups ) {
			WebServerAuthentication.Authenticate( this.SoapHeader );
			try {
				new EmployeeGroupBll().RemoveEmployeeGroups( employeeGroups );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get the employeegroup for the given employee.
		/// </summary>
		/// <param name="employee">The employee to get the employeegroup for.</param>
		/// <returns>The requested employeegroup.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public EmployeeGroup GetEmployeeGroupForEmployee( Employee employee ) {
			try {
				return new EmployeeGroupBll().GetEmployeeGroupForEmployee( employee );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get all employees from the database.
		/// </summary>
		/// <returns>An employeeCollection containing all employees.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public EmployeeCollection GetEmployees() {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new EmployeeBll().GetEmployees();
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all employees from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the employees for.</param>
		/// <returns>An EmployeeCollection containing the requested employees.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public EmployeeCollection GetEmployeesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new EmployeeBll().GetEmployeesForEmployeeGroup( employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get a specific employee from the database containing all the details.
		/// </summary>
		/// <param name="sysId">The internal id of the employee to get.</param>
		/// <returns></returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Employee GetEmployeeDetail( int sysId ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new EmployeeBll().GetEmployeeDetail( sysId );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Add a new employee tot the database.
		/// </summary>
		/// <param name="employee">The employee to create.</param>
		/// <param name="employeeGroup">The employeegroup that will contain this employee.</param>
		/// <returns>The created employee.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Employee CreateEmployee( Employee employee , EmployeeGroup employeeGroup ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new EmployeeBll().CreateEmployee( employee , employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing employee in the database.
		/// </summary>
		/// <param name="employee">The employee to update.</param>
		/// <param name="employeeGroup">The employeegroup that will contain this employee.</param>
		/// <returns>The updated employee.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Employee UpdateEmployee( Employee employee , EmployeeGroup employeeGroup ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new EmployeeBll().UpdateEmployee( employee , employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove one or more employees from the database.
		/// </summary>
		/// <param name="employees">The employees to remove.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveEmployees( EmployeeCollection employees ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new EmployeeBll().RemoveEmployees( employees );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Changes the password of a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to change the password for.</param>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="newPassword">The new password.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public bool ChangePassword( String userName , String oldPassword , String newPassword ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new UserBll().ChangePassword( userName , oldPassword , newPassword );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get an employee that should autologin on the given machine.
		/// </summary>
		/// <param name="machineName">The machine name to get the autologon employee for.</param>
		/// <returns>The employee that should autologon.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Employee GetDefaultEmployeeForMachineName( String machineName ) {
			try {
				return new EmployeeBll().GetDefaultEmployeeForMachineName( machineName );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get the employee settings for a given sysid.
		/// </summary>
		/// <param name="sysId">The internal id of the employee settings to get.</param>
		/// <returns>The requested employee settings.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public EmployeeSettings GetEmployeeSettings( int sysId ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new EmployeeSettingsBll().GetEmployeeSettings( sysId );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get the employee settings for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the settings for.</param>
		/// <returns>The requested employee settings.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public EmployeeSettings GetEmployeeSettingsForEmployee( Employee employee ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new EmployeeSettingsBll().GetEmployeeSettingsForEmployee( employee );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Set new employee settings for a specific employee.
		/// </summary>
		/// <param name="employeeSettings">The employee settings to set.</param>
		/// <param name="employee">The employee to set the settings for.</param>
		/// <returns>The created employee settings.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public EmployeeSettings SetEmployeeSettingsForEmployee( EmployeeSettings employeeSettings , Employee employee ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new EmployeeSettingsBll().SetEmployeeSettingsForEmployee( employeeSettings , employee );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

	}
}
