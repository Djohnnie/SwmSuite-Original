using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.DataAccess.Interface {
	
	/// <summary>
	/// DAL Interface for the MessageFolderService methods.
	/// </summary>
	public interface IMessageFolderDal {

		/// <summary>
		/// Get all messageFolders from the database.
		/// </summary>
		/// <returns>An MessageFolderCollection containing all messageFolders.</returns>
		MessageFolderDataCollection GetMessageFolderData();

		/// <summary>
		/// Get all messageFolders from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the messageFolders for.</param>
		/// <returns>An MessageFolderCollection containing all requested messageFolders.</returns>
		MessageFolderDataCollection GetMessageFolderDataForEmployee( int employeeSysId );

		/// <summary>
		/// Get all messagefolders from the database for a specific parent folder.
		/// </summary>
		/// <param name="folderSysId">The internal id of the folder to get the subfolders for.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		MessageFolderDataCollection GetMessageFolderDataForFolder( int folderSysId );

		/// <summary>
		/// Get the parent messagefolder for a specific message.
		/// </summary>
		/// <param name="messageSysId">The internal id of the message to get the parent folder for.</param>
		/// <param name="employeeSysId">The internal id of the owner of the message folder.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		MessageFolderDataCollection GetParentMessageFolderDataByMessage( int messageSysId , int employeeSysId );

		/// <summary>
		/// Get all special messagefolders from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the special messageFolders for.</param>
		/// <param name="specialFolder">The special messagefolders to get.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		MessageFolderDataCollection GetSpecialMessageFoldeDataForEmployee( int employeeSysId , MessageSpecialFolder specialFolder );

		/// <summary>
		/// Get a single messageFolder from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the messageFolder to retrieve.</param>
		/// <returns>An MessageFolderCollection containing the requested messageFolder.</returns>
		MessageFolderDataCollection GetMessageFolderDataBySysId( int sysId );

		/// <summary>
		/// Get multiple messageFolders from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messageFolders to retrieve.</param>
		/// <returns>An MessageFolderCollection containing the requested messageFolders.</returns>
		MessageFolderDataCollection GetMessageFolderDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more messageFolders to the database.
		/// </summary>
		/// <param name="messageFolders">An MessageFolderCollection containing the messageFolders to insert.</param>
		/// <returns>An MessageFolderCollection containing the inserted messageFolders.</returns>
		MessageFolderDataCollection InsertMessageFolderData( MessageFolderDataCollection messageFolders );

		/// <summary>
		/// Update one or more messageFolders in the database.
		/// </summary>
		/// <param name="messageFolders">An MessageFolderCollection containing the messageFolders to update.</param>
		/// <returns>An MessageFolderCollection containing the updated messageFolders.</returns>
		MessageFolderDataCollection UpdateMessageFolderData( MessageFolderDataCollection messageFolders );

		/// <summary>
		/// Remove one or more messageFolders from the database.
		/// </summary>
		/// <param name="messageFolders">An MessageFolderCollection containing the messageFolders to remove.</param>
		void RemoveMessageFolderData( MessageFolderDataCollection messageFolders );

		/// <summary>
		/// Remove all messageFolders from the database.
		/// </summary>
		void RemoveAllMessageFolderData();

	}

}