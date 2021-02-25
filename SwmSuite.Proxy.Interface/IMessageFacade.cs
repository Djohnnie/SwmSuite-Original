using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.Proxy.Interface {
	
	public interface IMessageFacade {

		/// <summary>
		/// Get all messages from the database for a specific messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the messages for.</param>
		/// <returns>A MessageCollection containing the requested messages.</returns>
		MessageCollection GetMessagesForMessageFolder( MessageFolder messageFolder );

		/// <summary>
		/// Send a message to one or more employees.
		/// </summary>
		/// <param name="message">The message to send.</param>
		/// <param name="employees">A collection of employees to send the message to.</param>
		void SendMessage( Message message , EmployeeCollection employees );

		/// <summary>
		/// Delete a message from a given messagefolder.
		/// </summary>
		/// <param name="message">The message to delete.</param>
		/// <param name="messageFolder">The folder to delete the message from.</param>
		void DeleteMessage( Message message , MessageFolder messageFolder );

		/// <summary>
		/// Move a message from source to destination folder.
		/// </summary>
		/// <param name="source">The source messagefolder.</param>
		/// <param name="destination">The destinationmessagefolder.</param>
		void MoveMessage( Message message , MessageFolder source , MessageFolder destination );

		/// <summary>
		/// Get the root messagefolders for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the root messagefolders for.</param>
		/// <returns>A MessageFolderCollection containing the requested messagefolders.</returns>
		/// <remarks>
		/// Get the root messagefolders (Inbox, Outbox and Archive) for the given
		/// employee. For each of these folders the subfolders are retrieved to know
		/// if the folder can be expanded.
		/// </remarks>
		MessageFolderCollection GetRootMessageFolders( Employee employee );

		/// <summary>
		/// Get the child messagefolders from the database for a specific messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the child messagefolders for.</param>
		/// <returns>A MessageFolderCollection containing the requested messagefolders.</returns>
		MessageFolderCollection GetMessageFolders( MessageFolder messageFolder );

		/// <summary>
		/// Get all special messagefolders from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the special messageFolders for.</param>
		/// <param name="specialFolder">The special messagefolders to get.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		MessageFolder GetSpecialMessageFolderForEmployee( Employee employee , MessageSpecialFolder specialFolder );

		/// <summary>
		/// Get the details for a given messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the details for.</param>
		/// <returns>A detailed version of the goven messagefolder.</returns>
		/// <remarks>
		/// Get the details for a given messagefolder (subfolders and messages).
		/// </remarks>
		MessageFolder GetMessageFolderDetail( MessageFolder messageFolder );

		/// <summary>
		/// Create a new messagefolder as child of a given parent messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to create.</param>
		/// <param name="parentMessageFolder">The parent messagefolder to create the child folder for.</param>
		/// <returns>The created messagefolder.</returns>
		MessageFolder CreateMessageFolder( MessageFolder messageFolder , MessageFolder parentMessageFolder );

		/// <summary>
		/// Update an existing messagefolder in the database.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to update.</param>
		/// <param name="employee">The owneremployee for the messagefolder.</param>
		/// <returns>The updated messagefolder.</returns>
		MessageFolder UpdateMessageFolder( MessageFolder messageFolder , Employee employee );

		/// <summary>
		/// Move a given messagefolder to a given parent messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to move.</param>
		/// <param name="newParentMessageFolder">The new parent messagefolder.</param>
		/// <remarks>
		/// 
		/// </remarks>
		void MoveMessageFolder( MessageFolder messageFolder , MessageFolder newParentMessageFolder );

		/// <summary>
		/// Update the read flag for a specific messagestorage.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <param name="messageFolder">The parent messagefolder of the message to update.</param>
		void UpdateReadFlag( Message message , MessageFolder messageFolder );

		/// <summary>
		/// Update the new flag for a specific messagestorage.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <param name="messageFolder">The parent messagefolder of the message to update.</param>
		void UpdateNewFlag( Message message , MessageFolder messageFolder );

		/// <summary>
		/// Delete a given messagefolder from the database.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to delete.</param>
		/// <returns>True if delete was succesful, false otherwise.</returns>
		bool DeleteMessageFolder( MessageFolder messageFolder );

	}

}
