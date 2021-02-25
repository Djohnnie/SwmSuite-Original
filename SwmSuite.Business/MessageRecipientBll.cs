using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {
	
	public class MessageRecipientBll {

		#region -_ Private Members _-

		private IMessageRecipientDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateMessageRecipientDal();

		#endregion

		#region -_ Business Methods _-

		

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all messageRecipients from the database.
		/// </summary>
		/// <returns>An MessageRecipientCollection containing all messageRecipients.</returns>
		public MessageRecipientDataCollection GetMessageRecipientData() {
			return dal.GetMessageRecipientData();
		}

		/// <summary>
		/// Get all messageRecipients from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the messageRecipients for.</param>
		/// <returns>An MessageRecipientCollection containing all requested messageRecipients.</returns>
		public MessageRecipientDataCollection GetMessageRecipientDataForEmployee( int employeeSysId ) {
			return dal.GetMessageRecipientDataForEmployee( employeeSysId );
		}

		/// <summary>
		/// Get a single messageRecipient from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the messageRecipient to retrieve.</param>
		/// <returns>An MessageRecipientCollection containing the requested messageRecipient.</returns>
		public MessageRecipientDataCollection GetMessageRecipientDataBySysId( int sysId ) {
			return dal.GetMessageRecipientDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple messageRecipients from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messageRecipients to retrieve.</param>
		/// <returns>An MessageRecipientCollection containing the requested messageRecipients.</returns>
		public MessageRecipientDataCollection GetMessageRecipientDataBySysIds( int[] sysIds ) {
			return dal.GetMessageRecipientDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more messageRecipients to the database.
		/// </summary>
		/// <param name="messageRecipients">An MessageRecipientCollection containing the messageRecipients to insert.</param>
		/// <returns>An MessageRecipientCollection containing the inserted messageRecipients.</returns>
		public MessageRecipientDataCollection InsertMessageRecipientData( MessageRecipientDataCollection messageRecipients ) {
			return dal.InsertMessageRecipientData( messageRecipients );
		}

		/// <summary>
		/// Update one or more messageRecipients in the database.
		/// </summary>
		/// <param name="messageRecipients">An MessageRecipientCollection containing the messageRecipients to update.</param>
		/// <returns>An MessageRecipientCollection containing the updated messageRecipients.</returns>
		public MessageRecipientDataCollection UpdateMessageRecipientData( MessageRecipientDataCollection messageRecipients ) {
			return dal.UpdateMessageRecipientData( messageRecipients );
		}

		/// <summary>
		/// Remove one or more messageRecipients from the database.
		/// </summary>
		/// <param name="messageRecipients">An MessageRecipientCollection containing the messageRecipients to remove.</param>
		public void RemoveMessageRecipientData( MessageRecipientDataCollection messageRecipients ) {
			dal.RemoveMessageRecipientData( messageRecipients );
		}

		/// <summary>
		/// Remove all messageRecipients from the database.
		/// </summary>
		public void RemoveAllMessageRecipientData() {
			dal.RemoveAllMessageRecipientData();
		}

		#endregion

	}

}
