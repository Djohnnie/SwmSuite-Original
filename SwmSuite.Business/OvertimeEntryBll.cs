using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;
using SwmSuite.Data.Common;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class OvertimeEntryBll {

		#region -_ Private Members _-

		private IOvertimeEntryDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateOvertimeEntryDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get overtime entries for a specific employee and year.
		/// </summary>
		/// <param name="employee">The employee to get the overtime entries for.</param>
		/// <param name="year">The year to get the overtime entries for.</param>
		/// <returns>An OvertimeEntryCollection containing the requested overtime entries.</returns>
		public OvertimeEntryCollection GetOvertimeEntries( Employee employee , int year ) {
			OvertimeEntryDataCollection overtimeEntryDataCollection =
				GetOvertimeEntryDataByEmployeeAndYear( employee.SysId , year );
			return OvertimeEntryMapping.FromDataObjectCollection( overtimeEntryDataCollection );
		}

		/// <summary>
		/// Get overtime entries for one or more employees and year.
		/// </summary>
		/// <param name="employees">The employees to get the overtime entries for.</param>
		/// <param name="year">The year to get the overtime entries for.</param>
		/// <returns>An OvertimeEntryCollection containing the requested overtime entries.</returns>
		public OvertimeEntryCollection GetOvertimeEntries( EmployeeCollection employees , int year ) {
			OvertimeEntryCollection overtimeEntriesToReturn = new OvertimeEntryCollection();
			foreach( Employee employee in employees ) {
				overtimeEntriesToReturn.Add( GetOvertimeEntries( employee , year ) );
			}
			return overtimeEntriesToReturn;
		}

		/// <summary>
		/// Create a new overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The new overtime entry to create.</param>
		/// <returns>The created overtime entry.</returns>
		public OvertimeEntry CreateOvertimeEntry( OvertimeEntry overtimeEntry ) {
			OvertimeEntryData overtimeEntryData = OvertimeEntryMapping.FromBusinessObject( overtimeEntry );
			OvertimeEntry overtimeEntryToReturn = null;
			OvertimeEntryDataCollection overtimeEntryDataCollection =
				OvertimeEntryDataCollection.FromSingleOvertimeEntry( overtimeEntryData );
			OvertimeEntryDataCollection overtimeEntryDataCollectionResult =
				InsertOvertimeEntryData( overtimeEntryDataCollection );
			if( overtimeEntryDataCollectionResult.Count == 1 ) {
				overtimeEntryToReturn = OvertimeEntryMapping.FromDataObject( overtimeEntryDataCollectionResult[0] );
			}
			SendNewOvertimeEntryMessage( overtimeEntry );
			return overtimeEntryToReturn;
		}

		/// <summary>
		/// Update an existing overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The existing overtime entry to update.</param>
		/// <returns>The updated overtime entry.</returns>
		public OvertimeEntry UpdateOvertimeEntry( OvertimeEntry overtimeEntry ) {
			OvertimeEntryData overtimeEntryData = OvertimeEntryMapping.FromBusinessObject( overtimeEntry );
			OvertimeEntry overtimeEntryToReturn = null;
			OvertimeEntryDataCollection overtimeEntryDataCollection =
				OvertimeEntryDataCollection.FromSingleOvertimeEntry( overtimeEntryData );
			OvertimeEntryDataCollection overtimeEntryDataCollectionResult =
				UpdateOvertimeEntryData( overtimeEntryDataCollection );
			if( overtimeEntryDataCollectionResult.Count == 1 ) {
				overtimeEntryToReturn = OvertimeEntryMapping.FromDataObject( overtimeEntryDataCollectionResult[0] );
			}
			return overtimeEntryToReturn;
		}

		/// <summary>
		/// Accept the specified overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry to accept.</param>
		public void AcceptOvertimeEntry( OvertimeEntry overtimeEntry ) {
			overtimeEntry.OvertimeStatus = OvertimeStatus.Accepted;
			UpdateOvertimeEntry( overtimeEntry );
			SendAcceptOvertimeEntryMessage( overtimeEntry );
		}

		/// <summary>
		/// Deny the specified overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry to deny.</param>
		public void DenyOvertimeEntry( OvertimeEntry overtimeEntry ) {
			overtimeEntry.OvertimeStatus = OvertimeStatus.Denied;
			UpdateOvertimeEntry( overtimeEntry );
			DenyAcceptOvertimeEntryMessage( overtimeEntry );
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all overtimeentrydata from the database.
		/// </summary>
		/// <returns>An OvertimeEntryDataCollection containing all overtimeentrydata.</returns>
		public OvertimeEntryDataCollection GetOvertimeEntryData() {
			return dal.GetOvertimeEntryData();
		}

		/// <summary>
		/// Get all overtimeentrydata from the database for a specific employee and year.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the overtime entries for.</param>
		/// <param name="year">The year to get the overtime entries for.</param>
		/// <returns>An OvertimeEntryDataCollection containing all overtimeentrydata.</returns>
		public OvertimeEntryDataCollection GetOvertimeEntryDataByEmployeeAndYear( int employeeSysId , int year ) {
			return dal.GetOvertimeEntryDataByEmployeeAndYear( employeeSysId , year );
		}

		/// <summary>
		/// Get a single overtimeentrydata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the overtimeentrydata to retrieve.</param>
		/// <returns>An OvertimeEntryDataCollection containing the requested overtimeentrydata.</returns>
		public OvertimeEntryDataCollection GetOvertimeEntryDataBySysId( int sysId ) {
			return dal.GetOvertimeEntryDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple overtimeentrydata from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the overtimeentrydata to retrieve.</param>
		/// <returns>An OvertimeEntryDataCollection containing the requested overtimeentrydata.</returns>
		public OvertimeEntryDataCollection GetOvertimeEntryDataBySysIds( int[] sysIds ) {
			return dal.GetOvertimeEntryDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more overtimeentrydata to the database.
		/// </summary>
		/// <param name="overtimeentrydata">An OvertimeEntryDataCollection containing the overtimeentrydata to insert.</param>
		/// <returns>An OvertimeEntryDataCollection containing the inserted overtimeentrydata.</returns>
		public OvertimeEntryDataCollection InsertOvertimeEntryData( OvertimeEntryDataCollection overtimeentrydata ) {
			return dal.InsertOvertimeEntryData( overtimeentrydata );
		}

		/// <summary>
		/// Update one or more overtimeentrydata in the database.
		/// </summary>
		/// <param name="overtimeentrydata">An OvertimeEntryDataCollection containing the overtimeentrydata to update.</param>
		/// <returns>An OvertimeEntryDataCollection containing the updated overtimeentrydata.</returns>
		public OvertimeEntryDataCollection UpdateOvertimeEntryData( OvertimeEntryDataCollection overtimeentrydata ) {
			return dal.UpdateOvertimeEntryData( overtimeentrydata );
		}

		/// <summary>
		/// Remove one or more overtimeentrydata from the database.
		/// </summary>
		/// <param name="overtimeentrydata">An OvertimeEntryDataCollection containing the overtimeentrydata to remove.</param>
		public void RemoveOvertimeEntryData( OvertimeEntryDataCollection overtimeentrydata ) {
			dal.RemoveOvertimeEntryData( overtimeentrydata );
		}

		/// <summary>
		/// Remove all overtimeentrydata from the database.
		/// </summary>
		public void RemoveAllOvertimeEntryData() {
			dal.RemoveAllOvertimeEntryData();
		}

		#endregion

		#region -_ Private Methods _-

		private void SendNewOvertimeEntryMessage( OvertimeEntry overtimeEntry ) {
			Message message = new Message();
			String contents = "Er werden overuren ingegeven door " + overtimeEntry.Employee.FullName + ". U kan deze overuren aanvaarden of weigeren in het beheer voor verlof.";
			message.CreateMessageContentsForSwmSuiteAlert( "Ingave overuren." , contents );
			message.Recipients = EmployeeCollection.FromSingleEmployee( overtimeEntry.Commissioner );
			message.Sender = overtimeEntry.Employee;
			message.Priority = MessagePriority.Normal;
			message.Date = DateTime.Now;
			new MessageBll().SendMessage( message , message.Recipients );
		}

		private void SendAcceptOvertimeEntryMessage( OvertimeEntry overtimeEntry ) {
			Message message = new Message();
			String contents = "Uw gepresteerde overuren op " + overtimeEntry.DateTimeStart.ToShortDateString() + " werden door " + SwmSuitePrincipal.CurrentEmployee.FullName + " goedgekeurd.";
			message.CreateMessageContentsForSwmSuiteAlert( "Uw overuren." , contents );
			message.Recipients = EmployeeCollection.FromSingleEmployee( overtimeEntry.Employee );
			message.Sender = SwmSuitePrincipal.CurrentEmployee;
			message.Priority = MessagePriority.Normal;
			message.Date = DateTime.Now;
			new MessageBll().SendMessage( message , message.Recipients );
		}

		private void DenyAcceptOvertimeEntryMessage( OvertimeEntry overtimeEntry ) {
			Message message = new Message();
			String contents = "Uw gepresteerde overuren op " + overtimeEntry.DateTimeStart.ToShortDateString() + " werden door " + SwmSuitePrincipal.CurrentEmployee.FullName + " geweigerd.";
			message.CreateMessageContentsForSwmSuiteAlert( "Uw overuren." , contents );
			message.Recipients = EmployeeCollection.FromSingleEmployee( overtimeEntry.Employee );
			message.Sender = SwmSuitePrincipal.CurrentEmployee;
			message.Priority = MessagePriority.Normal;
			message.Date = DateTime.Now;
			new MessageBll().SendMessage( message , message.Recipients );
		}

		#endregion

	}

}
