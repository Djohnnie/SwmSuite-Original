using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business;
using SwmSuite.Data.BusinessObjects;
using System.Web.Security;
using SwmSuite.Data.Common;
using SwmSuite.Business.DataMapping;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Business {
	
	public class EmployeeBll {

		#region -_ Private Members _-

		private IEmployeeDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateEmployeeDal();

		private MessageFolderBll messageFolderBll = new MessageFolderBll();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all employees from the database.
		/// </summary>
		/// <returns>An employeeCollection containing all employees.</returns>
		public EmployeeCollection GetEmployees() {
			return EmployeeMapping.FromDataObjectCollection(
				this.GetEmployeeData() );
		}

		/// <summary>
		/// Get all employees from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the employees for.</param>
		/// <returns>An EmployeeCollection containing the requested employees.</returns>
		public EmployeeCollection GetEmployeesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			return EmployeeMapping.FromDataObjectCollection(
				this.GetEmployeeDataForEmployeeGroup( employeeGroup.SysId ) );
		}

		/// <summary>
		/// Get an employee that should autologin on the given machine.
		/// </summary>
		/// <param name="machineName">The machine name to get the autologon employee for.</param>
		/// <returns>The employee that should autologon.</returns>
		public Employee GetDefaultEmployeeForMachineName( String machineName ) {
			EmployeeDataCollection employeeData = GetDefaultEmployeeByMachineName( machineName );
			if( employeeData.Count > 0 ) {
				return EmployeeMapping.FromDataObject( employeeData[0] );
			} else {
				throw new SwmSuiteException( null , SwmSuiteError.BusinessError , "Er werden geen gebruikers gevonden om automatisch in te loggen op deze machine." );
			}
		}

		/// <summary>
		/// Get a specific employee from the database containing all the details.
		/// </summary>
		/// <param name="sysId">The internal id of the employee to get.</param>
		/// <returns></returns>
		public Employee GetEmployeeDetail( int sysId ) {
			EmployeeDataCollection employeeData = this.GetEmployeeDataBySysId( sysId );
			Employee employeeToReturn = new Employee();
			if( employeeData.Count == 1 ) {
				employeeToReturn = EmployeeMapping.FromDataObject( employeeData[0] );
				if( employeeData[0].ZipCodeSysId.HasValue ) {
					employeeToReturn.ZipCode = new ZipCodeBll().GetZipCode( employeeData[0].ZipCodeSysId.Value );
				}
				if( employeeData[0].AvatarSysId.HasValue ) {
					employeeToReturn.Avatar = new AvatarBll().GetAvatar( employeeData[0].AvatarSysId.Value );
				}
				if( employeeData[0].ApplicationSettingsSysId.HasValue ) {
				}
			}
			return employeeToReturn;
		}

		public Employee CreateEmployee( Employee employee , EmployeeGroup employeeGroup ) {
			Employee employeeToReturn = null;
			// Register a new user with asp membership.
			Guid userSysId = new UserBll().CreateUser( employee.UserName , employee.Password , employee.EmailAddress1 );
			if( userSysId != Guid.Empty ){
				EmployeeData employeeData = EmployeeMapping.FromBusinessObject( employee );
				employeeData.UserSysId = userSysId;
				// Address
				if( employee.ZipCode != null ) {
					employeeData.ZipCodeSysId = employee.ZipCode.SysId;
				}
				// Avatar
				if( employee.Avatar != null ) {
					employeeData.AvatarSysId = employee.Avatar.SysId;
				}
				// ApplicationSettings
				//employeeData.ApplicationSettingsSysId = applicationSettings.SysId;
				// EmployeeGroup
				employeeData.EmployeeGroupSysId = employeeGroup.SysId;

				// Insert the employee in the database.
				EmployeeDataCollection employees =
					this.InsertEmployeeData( EmployeeDataCollection.FromSingleEmployee( employeeData ) );
				employeeToReturn = EmployeeMapping.FromDataObject( employees[0] );
				//
				// Insert the default created data for an employee.
				//

				//
				// Insert message folders for employee.
				//
				MessageFolderData inbox = new MessageFolderData( employees[0].SysId , null , MessageSpecialFolder.Inbox , "Ontvangen" , true );
				MessageFolderData outbox = new MessageFolderData( employees[0].SysId , null , MessageSpecialFolder.Outbox , "Verzonden" , true );
				MessageFolderData archive = new MessageFolderData( employees[0].SysId , null , MessageSpecialFolder.Archive , "Gearchiveerd" , true );
				MessageFolderDataCollection messageFolders = new MessageFolderDataCollection();
				messageFolders.Add( inbox );
				messageFolders.Add( outbox );
				messageFolders.Add( archive );
				messageFolderBll.InsertMessageFolderData( messageFolders );

				//
				// Insert default agenda.
				//
				Agenda agenda = new Agenda( "Mijn agenda" , "Mijn agenda" , EmployeeMapping.FromDataObject( employees[0] ) , AppointmentVisibility.Public );
				new AgendaBll().CreateAgenda( agenda );
			}
			return employeeToReturn;
		}

		public Employee UpdateEmployee( Employee employee , EmployeeGroup employeeGroup ) {
			EmployeeData employeeDataToUpdate = EmployeeMapping.FromBusinessObject( employee );
			if( employee.ZipCode != null ) {
				employeeDataToUpdate.ZipCodeSysId = employee.ZipCode.SysId;
			}
			if( employee.Avatar != null ) {
				employeeDataToUpdate.AvatarSysId = employee.Avatar.SysId;
			}
			employeeDataToUpdate.EmployeeGroupSysId = employeeGroup.SysId;

			EmployeeDataCollection employeeDataUpdated =
				UpdateEmployeeData( EmployeeDataCollection.FromSingleEmployee( employeeDataToUpdate ) );

			Employee employeeToReturn = new Employee();
			if( employeeDataUpdated.Count == 1 ) {
				employeeToReturn = EmployeeMapping.FromDataObject( employeeDataUpdated[0] );
				employeeToReturn.UserName = new UserBll().GetUserNameFromSysId( employeeToReturn.UserSysId );
				if( employeeDataUpdated[0].ZipCodeSysId.HasValue ) {
					employeeToReturn.ZipCode = new ZipCodeBll().GetZipCode( employeeDataUpdated[0].ZipCodeSysId.Value );
				}
				if( employeeDataUpdated[0].AvatarSysId.HasValue ) {
					employeeToReturn.Avatar = new AvatarBll().GetAvatar( employeeDataUpdated[0].AvatarSysId.Value );
				}
				if( employeeDataUpdated[0].ApplicationSettingsSysId.HasValue ) {
				}
			}
			return employeeToReturn;
		}

		public void RemoveEmployees( EmployeeCollection employees ) {
			try {
				RemoveEmployeeData( EmployeeMapping.FromBusinessObjectCollection( employees ) );
			} catch( Exception e ) {
				String message = "";
				if( employees.Count > 1 ) {
					message = "Personeelsleden kunnen niet worden verwijderd omdat minstens één personeelslid nog in gebruik is.";
				} else {
					message = "Personeelslid kan niet worden verwijderd omdat deze nog in gebruik is.";
				}
				throw new SwmSuiteException( e , SwmSuiteError.BusinessError , message );
			}
		}

		#endregion

		#region -_ Crud Methods _-

		/// <summary>
		/// Get all employees from the database.
		/// </summary>
		/// <returns>An EmployeeCollection containing all employees.</returns>
		public EmployeeDataCollection GetEmployeeData() {
			return dal.GetEmployeeData();
		}

		/// <summary>
		/// Get all employees from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the employees for.</param>
		/// <returns>An EmployeeCollection containing all requested employees.</returns>
		public EmployeeDataCollection GetEmployeeDataForEmployeeGroup( int employeeGroupSysId ) {
			return dal.GetEmployeeDataForEmployeeGroup( employeeGroupSysId );
		}

		/// <summary>
		/// Get all employees from the database for a specific machinename.
		/// </summary>
		/// <param name="machineName">The machine name to get the default employee for.</param>
		/// <returns>An EmployeeDataCollection containing all requested employees.</returns>
		/// <remarks>This method gets the employees that have an autologin setting on a specific machine.</remarks>
		public EmployeeDataCollection GetDefaultEmployeeByMachineName( String machineName ) {
			return dal.GetDefaultEmployeeForMachineName( machineName );
		}

		/// <summary>
		/// Get a single employee from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employee to retrieve.</param>
		/// <returns>An EmployeeCollection containing the requested employee.</returns>
		public EmployeeDataCollection GetEmployeeDataBySysId( int sysId ) {
			return dal.GetEmployeeDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple employees from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the employees to retrieve.</param>
		/// <returns>An EmployeeCollection containing the requested employees.</returns>
		public EmployeeDataCollection GetEmployeeDataBySysIds( int[] sysIds ) {
			return dal.GetEmployeeDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more employees to the database.
		/// </summary>
		/// <param name="employees">An EmployeeCollection containing the employees to insert.</param>
		/// <returns>An EmployeeCollection containing the inserted employees.</returns>
		public EmployeeDataCollection InsertEmployeeData( EmployeeDataCollection employees ) {
			return dal.InsertEmployeeData( employees );
		}

		/// <summary>
		/// Update one or more employees in the database.
		/// </summary>
		/// <param name="employees">An EmployeeCollection containing the employees to update.</param>
		/// <returns>An EmployeeCollection containing the updated employees.</returns>
		public EmployeeDataCollection UpdateEmployeeData( EmployeeDataCollection employees ) {
			return dal.UpdateEmployeeData( employees );
		}

		/// <summary>
		/// Remove one or more employees from the database.
		/// </summary>
		/// <param name="employees">An EmployeeCollection containing the employees to remove.</param>
		public void RemoveEmployeeData( EmployeeDataCollection employees ) {
			dal.RemoveEmployeeData( employees );
		}

		/// <summary>
		/// Remove all employees from the database.
		/// </summary>
		public void RemoveAllEmployeeData() {
			dal.RemoveAllEmployeeData();
		}

		#endregion

	}

}