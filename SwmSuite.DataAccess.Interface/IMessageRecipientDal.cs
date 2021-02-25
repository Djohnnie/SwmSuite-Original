using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {
	
	public interface IMessageRecipientDal {

		/// <summary>
		/// Get all messageRecipients from the database.
		/// </summary>
		/// <returns>An MessageRecipientCollection containing all messageRecipients.</returns>
		MessageRecipientDataCollection GetMessageRecipientData();

		/// <summary>
		/// Get all messageRecipients from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the messageRecipients for.</param>
		/// <returns>An MessageRecipientCollection containing all requested messageRecipients.</returns>
		MessageRecipientDataCollection GetMessageRecipientDataForEmployee( int employeeSysId );

		/// <summary>
		/// Get a single messageRecipient from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the messageRecipient to retrieve.</param>
		/// <returns>An MessageRecipientCollection containing the requested messageRecipient.</returns>
		MessageRecipientDataCollection GetMessageRecipientDataBySysId( int sysId );

		/// <summary>
		/// Get multiple messageRecipients from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messageRecipients to retrieve.</param>
		/// <returns>An MessageRecipientCollection containing the requested messageRecipients.</returns>
		MessageRecipientDataCollection GetMessageRecipientDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more messageRecipients to the database.
		/// </summary>
		/// <param name="messageRecipients">An MessageRecipientCollection containing the messageRecipients to insert.</param>
		/// <returns>An MessageRecipientCollection containing the inserted messageRecipients.</returns>
		MessageRecipientDataCollection InsertMessageRecipientData( MessageRecipientDataCollection messageRecipients );

		/// <summary>
		/// Update one or more messageRecipients in the database.
		/// </summary>
		/// <param name="messageRecipients">An MessageRecipientCollection containing the messageRecipients to update.</param>
		/// <returns>An MessageRecipientCollection containing the updated messageRecipients.</returns>
		MessageRecipientDataCollection UpdateMessageRecipientData( MessageRecipientDataCollection messageRecipients );

		/// <summary>
		/// Remove one or more messageRecipients from the database.
		/// </summary>
		/// <param name="messageRecipients">An MessageRecipientCollection containing the messageRecipients to remove.</param>
		void RemoveMessageRecipientData( MessageRecipientDataCollection messageRecipients );

		/// <summary>
		/// Remove all messageRecipients from the database.
		/// </summary>
		void RemoveAllMessageRecipientData();

	}

}
