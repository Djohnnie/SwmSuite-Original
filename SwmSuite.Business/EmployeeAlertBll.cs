using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class EmployeeAlertBll {

		#region -_ Private Members _-

		private IEmployeeAlertDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateEmployeeAlertDal();

		#endregion

		#region -_ Business Methods _-

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all employeealerts from the database.
		/// </summary>
		/// <returns>An EmployeeAlertDataCollection containing all employeealerts.</returns>
		public EmployeeAlertDataCollection GetEmployeeAlertData() {
			return dal.GetEmployeeAlertData();
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific alert.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		public EmployeeAlertDataCollection GetEmployeeAlertDataForAlert( int alertSysId ) {
			return dal.GetEmployeeAlertDataForAlert( alertSysId );
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		public EmployeeAlertDataCollection GetEmployeeAlertDataForEmployee( int employeeSysId ) {
			return dal.GetEmployeeAlertDataForEmployee( employeeSysId );
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific alert and employee.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <param name="employeeSysId">The internal id of the employee to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		public EmployeeAlertDataCollection GetEmployeeAlertDataForAlertAndEmployee( int alertSysId , int employeeSysId ) {
			return dal.GetEmployeeAlertDataForAlertAndEmployee( alertSysId , employeeSysId );
		}

		/// <summary>
		/// Get a single employeealert from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the employeealert to retrieve.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		public EmployeeAlertDataCollection GetEmployeeAlertDataBySysId( int sysId ) {
			return dal.GetEmployeeAlertDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple employeealerts from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the employeealerts to retrieve.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealerts.</returns>
		public EmployeeAlertDataCollection GetEmployeeAlertDataBySysIds( int[] sysIds ) {
			return dal.GetEmployeeAlertDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more employeealerts to the database.
		/// </summary>
		/// <param name="employeealerts">An EmployeeAlertDataCollection containing the employeealerts to insert.</param>
		/// <returns>An EmployeeAlertDataCollection containing the inserted employeealerts.</returns>
		public EmployeeAlertDataCollection InsertEmployeeAlertData( EmployeeAlertDataCollection employeealerts ) {
			return dal.InsertEmployeeAlertData( employeealerts );
		}

		/// <summary>
		/// Update one or more employeealerts in the database.
		/// </summary>
		/// <param name="employeealerts">An EmployeeAlertDataCollection containing the employeealerts to update.</param>
		/// <returns>An EmployeeAlertDataCollection containing the updated employeealerts.</returns>
		public EmployeeAlertDataCollection UpdateEmployeeAlertData( EmployeeAlertDataCollection employeealerts ) {
			return dal.UpdateEmployeeAlertData( employeealerts );
		}

		/// <summary>
		/// Remove one or more employeealerts from the database.
		/// </summary>
		/// <param name="employeealerts">An EmployeeAlertDataCollection containing the employeealerts to remove.</param>
		public void RemoveEmployeeAlertData( EmployeeAlertDataCollection employeealerts ) {
			dal.RemoveEmployeeAlertData( employeealerts );
		}

		/// <summary>
		/// Remove all employeealerts from the database.
		/// </summary>
		public void RemoveAllEmployeeAlertData() {
			dal.RemoveAllEmployeeAlertData();
		}

		#endregion

	}

}
