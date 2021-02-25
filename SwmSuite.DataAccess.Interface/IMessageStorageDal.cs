using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {
	
	public interface IMessageStorageDal {

		/// <summary>
		/// Get all messageStorages from the database.
		/// </summary>
		/// <returns>An MessageStorageCollection containing all messageStorages.</returns>
		MessageStorageDataCollection GetMessageStorageData();

		/// <summary>
		/// Get a single messageStorage from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the messageStorage to retrieve.</param>
		/// <returns>An MessageStorageCollection containing the requested messageStorage.</returns>
		MessageStorageDataCollection GetMessageStorageDataBySysId( int sysId );

		/// <summary>
		/// Get multiple messageStorages from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messageStorages to retrieve.</param>
		/// <returns>An MessageStorageCollection containing the requested messageStorages.</returns>
		MessageStorageDataCollection GetMessageStorageDataBySysIds( int[] sysIds );

		/// <summary>
		/// Get all messagestorages for a specific message and folder from the database.
		/// </summary>
		/// <param name="messageSysId">The internal ids of the message to get the messagestorage for.</param>
		/// <param name="messageFolderSysId">The internal ids of the messagefolder to get the messagestorage for.</param>
		/// <returns>A MessagestorageCollection containing the requested messagestorages.</returns>
		/// <remarks>This should return a single MessageStorage object if the given message is stored in the given messagefolder.</remarks>
		MessageStorageDataCollection GetMessageStorageDataByMessageAndMessageFolder( int messageSysId , int messageFolderSysId );

		/// <summary>
		/// Insert one or more messageStorages to the database.
		/// </summary>
		/// <param name="messageStorages">An MessageStorageCollection containing the messageStorages to insert.</param>
		/// <returns>An MessageStorageCollection containing the inserted messageStorages.</returns>
		MessageStorageDataCollection InsertMessageStorageData( MessageStorageDataCollection messageStorages );

		/// <summary>
		/// Update one or more messageStorages in the database.
		/// </summary>
		/// <param name="messageStorages">An MessageStorageCollection containing the messageStorages to update.</param>
		/// <returns>An MessageStorageCollection containing the updated messageStorages.</returns>
		MessageStorageDataCollection UpdateMessageStorageData( MessageStorageDataCollection messageStorages );

		/// <summary>
		/// Remove one or more messageStorages from the database.
		/// </summary>
		/// <param name="messageStorages">An MessageStorageCollection containing the messageStorages to remove.</param>
		void RemoveMessageStorageData( MessageStorageDataCollection messageStorages );

		/// <summary>
		/// Remove all messageStorages from the database.
		/// </summary>
		void RemoveAllMessageStorageData();

		/// <summary>
		/// Update the read flag for a specific messagestorage.
		/// </summary>
		/// <param name="messageSysId">The internal id for the message</param>
		/// <param name="messageFolderSysId">The internal id for the messagefolder.</param>
		/// <param name="newReadFlag">The new read flag.</param>
		void UpdateReadFlag( int messageSysId , int messageFolderSysId , bool newReadFlag );

		/// <summary>
		/// Update the new flag for a specific messagestorage.
		/// </summary>
		/// <param name="messageSysId">The internal id for the message</param>
		/// <param name="messageFolderSysId">The internal id for the messagefolder.</param>
		/// <param name="newNewFlag">The new new flag.</param>
		void UpdateNewFlag( int messageSysId , int messageFolderSysId , bool newNewFlag );

	}

}
