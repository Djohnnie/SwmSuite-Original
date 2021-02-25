using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;
using System.Transactions;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Business {

	public class EmployeeSettingsBll {

		#region -_ Private Members _-

		private IEmployeeSettingsDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateEmployeeSettingsDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get the employee settings for a given sysid.
		/// </summary>
		/// <param name="sysId">The internal id of the employee settings to get.</param>
		/// <returns>The requested employee settings.</returns>
		public EmployeeSettings GetEmployeeSettings( int sysId ) {
			EmployeeSettings employeeSettingsToReturn = null;
			EmployeeSettingsDataCollection employeeSettingsData =
				GetEmployeeSettingsDataBySysId( sysId );
			if( employeeSettingsData.Count == 1 ) {
				employeeSettingsToReturn = EmployeeSettingsMapping.FromDataObject( employeeSettingsData[0] );
			}
			return employeeSettingsToReturn;
		}

		/// <summary>
		/// Get the employee settings for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the settings for.</param>
		/// <returns>The requested employee settings.</returns>
		public EmployeeSettings GetEmployeeSettingsForEmployee( Employee employee ) {
			EmployeeSettings employeeSettingsToReturn = null;
			EmployeeSettingsDataCollection employeeSettingsData =
				GetEmployeeSettingsDataForEmployee( employee.SysId );
			if( employeeSettingsData.Count == 1 ) {
				employeeSettingsToReturn = EmployeeSettingsMapping.FromDataObject( employeeSettingsData[0] );
			}
			return employeeSettingsToReturn;
		}

		/// <summary>
		/// Set new employee settings for a specific employee.
		/// </summary>
		/// <param name="employeeSettings">The employee settings to set.</param>
		/// <param name="employee">The employee to set the settings for.</param>
		/// <returns>The created employee settings.</returns>
		public EmployeeSettings SetEmployeeSettingsForEmployee( EmployeeSettings employeeSettings , Employee employee ) {
			if( employeeSettings.Validate() ) {
				using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
					EmployeeSettingsData employeeSettingsData =
						EmployeeSettingsMapping.FromBusinessObject( employeeSettings );

					// Get employee detail.
					Employee previousEmployee = new EmployeeBll().GetEmployeeDetail( employee.SysId );

					// Remove existing applicationsettings.
					if( previousEmployee.Settings != null ) {
						EmployeeSettingsData previousEmployeeSettingsData = EmployeeSettingsMapping.FromBusinessObject( previousEmployee.Settings );
						RemoveEmployeeSettingsData( EmployeeSettingsDataCollection.FromSingleEmployeeSettings( previousEmployeeSettingsData ) );
					}

					// Insert new settings.
					EmployeeSettingsDataCollection employeeSettingsDataCollection = InsertEmployeeSettingsData(
						EmployeeSettingsDataCollection.FromSingleEmployeeSettings( employeeSettingsData ) );

					// Update employee with new settings.
					EmployeeData previousEmployeeData = new EmployeeBll().GetEmployeeDataBySysId( employee.SysId )[0];
					previousEmployeeData.ApplicationSettingsSysId = employeeSettingsDataCollection[0].SysId;
					new EmployeeBll().UpdateEmployeeData( EmployeeDataCollection.FromSingleEmployee( previousEmployeeData ) );

					scope.Complete();
					return EmployeeSettingsMapping.FromDataObject( employeeSettingsDataCollection[0] );
				}
			} else {
				throw new SwmSuiteException( null , SwmSuiteError.ValidationError , employeeSettings.GetValidationError() );
			}
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all employeesettings from the database.
		/// </summary>
		/// <returns>An EmployeeSettingsCollection containing all employeesettings.</returns>
		public EmployeeSettingsDataCollection GetEmployeeSettingsData() {
			return dal.GetEmployeeSettingsData();
		}

		/// <summary>
		/// Get employee settings for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the settings for.</param>
		/// <returns>An EmployeeSettingsDataCollection containing the requested settings.</returns>
		public EmployeeSettingsDataCollection GetEmployeeSettingsDataForEmployee( int employeeSysId ) {
			return dal.GetEmployeeSettingsDataForEmployee( employeeSysId );
		}

		/// <summary>
		/// Get a single employeesettings from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the employeesettings to retrieve.</param>
		/// <returns>An EmployeeSettingsCollection containing the requested employeesettings.</returns>
		public EmployeeSettingsDataCollection GetEmployeeSettingsDataBySysId( int sysId ) {
			return dal.GetEmployeeSettingsDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple employeesettings from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the employeesettings to retrieve.</param>
		/// <returns>An EmployeeSettingsCollection containing the requested employeesettings.</returns>
		public EmployeeSettingsDataCollection GetEmployeeSettingsDataBySysIds( int[] sysIds ) {
			return dal.GetEmployeeSettingsDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more employeesettings to the database.
		/// </summary>
		/// <param name="employeesettings">An EmployeeSettingsCollection containing the employeesettings to insert.</param>
		/// <returns>An EmployeeSettingsCollection containing the inserted employeesettings.</returns>
		public EmployeeSettingsDataCollection InsertEmployeeSettingsData( EmployeeSettingsDataCollection employeesettings ) {
			return dal.InsertEmployeeSettingsData( employeesettings );
		}

		/// <summary>
		/// Update one or more employeesettings in the database.
		/// </summary>
		/// <param name="employeesettings">An EmployeeSettingsCollection containing the employeesettings to update.</param>
		/// <returns>An EmployeeSettingsCollection containing the updated employeesettings.</returns>
		public EmployeeSettingsDataCollection UpdateEmployeeSettingsData( EmployeeSettingsDataCollection employeesettings ) {
			return dal.UpdateEmployeeSettingsData( employeesettings );
		}

		/// <summary>
		/// Remove one or more employeesettings from the database.
		/// </summary>
		/// <param name="employeesettings">An EmployeeSettingsCollection containing the employeesettings to remove.</param>
		public void RemoveEmployeeSettingsData( EmployeeSettingsDataCollection employeesettings ) {
			dal.RemoveEmployeeSettingsData( employeesettings );
		}

		/// <summary>
		/// Remove all employeesettings from the database.
		/// </summary>
		public void RemoveAllEmployeeSettingsData() {
			dal.RemoveAllEmployeeSettingsData();
		}

		#endregion

	}

}
