using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {
	
	public class MessageStorageBll {

		#region -_ Private Members _-

		private IMessageStorageDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateMessageStorageDal();

		#endregion

		#region -_ Business Methods _-



		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all messageStorages from the database.
		/// </summary>
		/// <returns>An MessageStorageCollection containing all messageStorages.</returns>
		public MessageStorageDataCollection GetMessageStorageData() {
			return dal.GetMessageStorageData();
		}

		/// <summary>
		/// Get a single messageStorage from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the messageStorage to retrieve.</param>
		/// <returns>An MessageStorageCollection containing the requested messageStorage.</returns>
		public MessageStorageDataCollection GetMessageStorageDataBySysId( int sysId ) {
			return dal.GetMessageStorageDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple messageStorages from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messageStorages to retrieve.</param>
		/// <returns>An MessageStorageCollection containing the requested messageStorages.</returns>
		public MessageStorageDataCollection GetMessageStorageDataBySysIds( int[] sysIds ) {
			return dal.GetMessageStorageDataBySysIds( sysIds );
		}

		/// <summary>
		/// Get all messagestorages for a specific message and folder from the database.
		/// </summary>
		/// <param name="messageSysId">The internal ids of the message to get the messagestorage for.</param>
		/// <param name="messageFolderSysId">The internal ids of the messagefolder to get the messagestorage for.</param>
		/// <returns>A MessagestorageCollection containing the requested messagestorages.</returns>
		/// <remarks>This should return a single MessageStorage object if the given message is stored in the given messagefolder.</remarks>
		public MessageStorageDataCollection GetMessageStorageDataByMessageAndMessageFolder( int messageSysId , int messageFolderSysId ) {
			return dal.GetMessageStorageDataByMessageAndMessageFolder( messageSysId , messageFolderSysId );
		}

		/// <summary>
		/// Insert one or more messageStorages to the database.
		/// </summary>
		/// <param name="messageStorages">An MessageStorageCollection containing the messageStorages to insert.</param>
		/// <returns>An MessageStorageCollection containing the inserted messageStorages.</returns>
		public MessageStorageDataCollection InsertMessageStorageData( MessageStorageDataCollection messageStorages ) {
			return dal.InsertMessageStorageData( messageStorages );
		}

		/// <summary>
		/// Update one or more messageStorages in the database.
		/// </summary>
		/// <param name="messageStorages">An MessageStorageCollection containing the messageStorages to update.</param>
		/// <returns>An MessageStorageCollection containing the updated messageStorages.</returns>
		public MessageStorageDataCollection UpdateMessageStorageData( MessageStorageDataCollection messageStorages ) {
			return dal.UpdateMessageStorageData( messageStorages );
		}

		/// <summary>
		/// Remove one or more messageStorages from the database.
		/// </summary>
		/// <param name="messageStorages">An MessageStorageCollection containing the messageStorages to remove.</param>
		public void RemoveMessageStorageData( MessageStorageDataCollection messageStorages ) {
			dal.RemoveMessageStorageData( messageStorages );
		}

		/// <summary>
		/// Remove all messageStorages from the database.
		/// </summary>
		public void RemoveAllMessageStorageData() {
			dal.RemoveAllMessageStorageData();
		}

		/// <summary>
		/// Update the read flag for a specific messagestorage.
		/// </summary>
		/// <param name="messageSysId">The internal id for the message</param>
		/// <param name="messageFolderSysId">The internal id for the messagefolder.</param>
		/// <param name="newReadFlag">The new read flag.</param>
		public void UpdateReadFlag( int messageSysId , int messageFolderSysId , bool newReadFlag ) {
			dal.UpdateReadFlag( messageSysId , messageFolderSysId , newReadFlag );
		}

		/// <summary>
		/// Update the new flag for a specific messagestorage.
		/// </summary>
		/// <param name="messageSysId">The internal id for the message</param>
		/// <param name="messageFolderSysId">The internal id for the messagefolder.</param>
		/// <param name="newNewFlag">The new new flag.</param>
		public void UpdateNewFlag( int messageSysId , int messageFolderSysId , bool newNewFlag ) {
			dal.UpdateNewFlag( messageSysId , messageFolderSysId , newNewFlag );
		}

		#endregion

	}

}
