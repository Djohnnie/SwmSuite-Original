using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;

using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.DataMapping;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Business {

	public class EmployeeGroupBll {

		#region -_ Private Members _-

		private IEmployeeGroupDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateEmployeeGroupDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all employeegroups from the database.
		/// </summary>
		/// <returns>An EmployeeGroupCollection containing all employeegroups.</returns>
		public EmployeeGroupCollection GetEmployeeGroups() {
			EmployeeGroupCollection employeeGroupsToReturn =
				EmployeeGroupMapping.FromDataObjectCollection( this.GetEmployeeGroupData() );
			foreach( EmployeeGroup employeeGroup in employeeGroupsToReturn ) {
				employeeGroup.Employees = new EmployeeBll().GetEmployeesForEmployeeGroup( employeeGroup );
			}
			return employeeGroupsToReturn;
		}

		/// <summary>
		/// Get a specific employeegroup from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employeegroup to get.</param>
		/// <returns>The requested employeegroup.</returns>
		public EmployeeGroup GetEmployeeGroupDetail( int sysId ) {
			EmployeeGroup employeeGroupToReturn = new EmployeeGroup();
			EmployeeGroupDataCollection employeeGroupData = this.GetEmployeeGroupDataBySysId( sysId );
			if( employeeGroupData.Count == 1 ) {
				employeeGroupToReturn = EmployeeGroupMapping.FromDataObject( employeeGroupData[0] );
			}
			employeeGroupToReturn.Employees = new EmployeeBll().GetEmployeesForEmployeeGroup( employeeGroupToReturn );
			return employeeGroupToReturn;
		}

		/// <summary>
		/// Add a new employeegroup to the database.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to add.</param>
		/// <returns>The created employeegroup.</returns>
		public EmployeeGroup CreateEmployeeGroup( EmployeeGroup employeeGroup ) {
			EmployeeGroupDataCollection employeeGroupData =
				this.InsertEmployeeGroupData( EmployeeGroupDataCollection.FromSingleEmployeeGroup( EmployeeGroupMapping.FromBusinessObject( employeeGroup ) ) );
			EmployeeGroup employeeGroupToReturn = new EmployeeGroup();
			if( employeeGroupData.Count == 1 ) {
				employeeGroupToReturn = EmployeeGroupMapping.FromDataObject( employeeGroupData[0] );
			}
			return employeeGroupToReturn;
		}

		/// <summary>
		/// Update an existing employeegroup in the database.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to update.</param>
		/// <returns>The updated employeegroup.</returns>
		public EmployeeGroup UpdateEmployeeGroup( EmployeeGroup employeeGroup ) {
			EmployeeGroupDataCollection employeeGroupData =
				this.UpdateEmployeeGroupData( EmployeeGroupDataCollection.FromSingleEmployeeGroup( EmployeeGroupMapping.FromBusinessObject( employeeGroup ) ) );
			EmployeeGroup employeeGroupToReturn = new EmployeeGroup();
			if( employeeGroupData.Count == 1 ) {
				employeeGroupToReturn = EmployeeGroupMapping.FromDataObject( employeeGroupData[0] );
			}
			return employeeGroupToReturn;
		}

		/// <summary>
		/// Remove one or more employeegroups from the database.
		/// </summary>
		/// <param name="employeeGroups">The employeegroups to remove.</param>
		public void RemoveEmployeeGroups( EmployeeGroupCollection employeeGroups ) {
			try {
				RemoveEmployeeGroupData( EmployeeGroupMapping.FromBusinessObjectCollection( employeeGroups ) );
			} catch( Exception e ) {
				String message = "";
				if( employeeGroups.Count > 1 ) {
					message = "Personeelsgroepen kunnen niet worden verwijderd omdat minstens één personeelgroep nog in gebruik is.";
				} else {
					message = "Personeelsgroep kan niet worden verwijderd omdat deze nog in gebruik is.";
				}
				throw new SwmSuiteException( e , SwmSuiteError.BusinessError , message );
			}
		}

		/// <summary>
		/// Get the employeegroup for the given employee.
		/// </summary>
		/// <param name="employee">The employee to get the employeegroup for.</param>
		/// <returns>The requested employeegroup.</returns>
		public EmployeeGroup GetEmployeeGroupForEmployee( Employee employee ) {
			EmployeeGroupDataCollection employeeGroupData = GetEmployeeGroupByEmployee( employee.SysId );
			if( employeeGroupData.Count == 1 ) {
				return EmployeeGroupMapping.FromDataObject( employeeGroupData[0] );
			} else {
				throw new SwmSuiteException( null , SwmSuiteError.BusinessError , "Gebruiker " + employee.FullName + " behoort niet tot een personeelsgroep." );
			}
		}

		#endregion

		#region -_ Crud Methods _-

		/// <summary>
		/// Check if there are EmployeeGroups available.
		/// </summary>
		/// <returns>True if EmployeeGroups are available, false otherwise.</returns>
		public bool EmployeeGroupsAvailable() {
			return dal.CountEmployeeGroups() > 0;
		}

		/// <summary>
		/// Get all employeegroups from the database.
		/// </summary>
		/// <returns>An EmployeeGroupCollection containing all employeegroups.</returns>
		public EmployeeGroupDataCollection GetEmployeeGroupData() {
			return dal.GetEmployeeGroups();
		}

		/// <summary>
		/// Get a single employeegroup from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employeegroup to retrieve.</param>
		/// <returns>An EmployeeGroupCollection containing the requested employeegroup.</returns>
		public EmployeeGroupDataCollection GetEmployeeGroupDataBySysId( int sysId ) {
			return dal.GetEmployeeGroupBySysId( sysId );
		}

		/// <summary>
		/// Get multiple employeegroups from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the employeegroups to retrieve.</param>
		/// <returns>An EmployeeGroupCollection containing the requested employeegroups.</returns>
		public EmployeeGroupDataCollection GetEmployeeGroupDataBySysIds( int[] sysIds ) {
			return dal.GetEmployeeGroupsBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more employeegroups to the database.
		/// </summary>
		/// <param name="employeeGroups">An EmployeeGroupCollection containing the employeegroups to insert.</param>
		public EmployeeGroupDataCollection InsertEmployeeGroupData( EmployeeGroupDataCollection employeeGroups ) {
			return dal.InsertEmployeeGroups( employeeGroups );
		}

		/// <summary>
		/// Update one or more employeegroups in the database.
		/// </summary>
		/// <param name="employeeGroups">An EmployeeGroupCollection containing the employeegroups to update.</param>
		public EmployeeGroupDataCollection UpdateEmployeeGroupData( EmployeeGroupDataCollection employeeGroups ) {
			return dal.UpdateEmployeeGroups( employeeGroups );
		}

		/// <summary>
		/// Remove one or more employeegroups from the database.
		/// </summary>
		/// <param name="employeeGroups">An EmployeeGroupCollection containing the employeegroups to remove.</param>
		public void RemoveEmployeeGroupData( EmployeeGroupDataCollection employeeGroups ) {
			dal.RemoveEmployeeGroups( employeeGroups );
		}

		/// <summary>
		/// Remove all employeegroups from the database.
		/// </summary>
		public void RemoveAllEmployeeGroupData() {
			dal.RemoveAllEmployeeGroups();
		}

		/// <summary>
		/// Get the employeegroups for the given employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the employee groups for.</param>
		/// <returns>An EmployeeGroupDataCollection containing the requested employee groups.</returns>
		public EmployeeGroupDataCollection GetEmployeeGroupByEmployee( int employeeSysId ) {
			return dal.GetEmployeeGroupByEmployee( employeeSysId );
		}

		#endregion

	}

}
