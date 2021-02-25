using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the MessageService methods.
	/// </summary>
	public interface IMessageDal {

		/// <summary>
		/// Get all messages from the database.
		/// </summary>
		/// <returns>An MessageCollection containing all messages.</returns>
		MessageDataCollection GetMessageData();

		/// <summary>
		/// Get all messages from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the messages for.</param>
		/// <returns>An MessageCollection containing all requested messages.</returns>
		MessageDataCollection GetMessageDataForEmployee( int employeeSysId );

		/// <summary>
		/// Get all messages in a specific messagefolder from the database.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the messagefolder to get the messages for.</param>
		/// <returns>An MessageCollection containing all requested messages.</returns>
		MessageDataCollection GetMessageDataInMessageFolder( int messageFolderSysId );

		/// <summary>
		/// Get a single message from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the message to retrieve.</param>
		/// <returns>An MessageCollection containing the requested message.</returns>
		MessageDataCollection GetMessageDataBySysId( int sysId );

		/// <summary>
		/// Get multiple messages from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messages to retrieve.</param>
		/// <returns>An MessageCollection containing the requested messages.</returns>
		MessageDataCollection GetMessageDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more messages to the database.
		/// </summary>
		/// <param name="messages">An MessageCollection containing the messages to insert.</param>
		/// <returns>An MessageCollection containing the inserted messages.</returns>
		MessageDataCollection InsertMessageData( MessageDataCollection messages );

		/// <summary>
		/// Update one or more messages in the database.
		/// </summary>
		/// <param name="messages">An MessageCollection containing the messages to update.</param>
		/// <returns>An MessageCollection containing the updated messages.</returns>
		MessageDataCollection UpdateMessageData( MessageDataCollection messages );

		/// <summary>
		/// Remove one or more messages from the database.
		/// </summary>
		/// <param name="messages">An MessageCollection containing the messages to remove.</param>
		void RemoveMessageData( MessageDataCollection messages );

		/// <summary>
		/// Remove all messages from the database.
		/// </summary>
		void RemoveAllMessageData();

	}

}
