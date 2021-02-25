using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;
using SwmSuite.Data.Common;
using SwmSuite.Framework.Exceptions;
using System.Transactions;

namespace SwmSuite.Business {
	
	public class MessageBll {

		#region -_ Private Members _-

		private IMessageDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateMessageDal();
		private MessageFolderBll messageFolderBll = new MessageFolderBll();
		private MessageStorageBll messageStorageBll = new MessageStorageBll();
		private MessageRecipientBll messageRecipientBll = new MessageRecipientBll();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all messages from the database for a specific messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the messages for.</param>
		/// <returns>A MessageCollection containing the requested messages.</returns>
		public MessageCollection GetMessagesForMessageFolder( MessageFolder messageFolder ) {
			MessageCollection messageCollectionToReturn = new MessageCollection();
			foreach( MessageData messageData in this.GetMessageDataInMessageFolder( messageFolder.SysId ) ) {
				MessageStorageDataCollection messageStorageData =
					new MessageStorageBll().GetMessageStorageDataByMessageAndMessageFolder( messageData.SysId , messageFolder.SysId );
				Message message = MessageMapping.FromDataObject( messageData );
				message.IsNew = messageStorageData[0].IsNew;
				message.IsRead = messageStorageData[0].IsRead;
				message.Sender = new EmployeeBll().GetEmployeeDetail( messageData.FromEmployeeSysId );
				message.ParentFolder = messageFolder;
				messageCollectionToReturn.Add( message );
			}
			return messageCollectionToReturn;
		}

		/// <summary>
		/// Send a message to one or more employees.
		/// </summary>
		/// <param name="message">The message to send.</param>
		/// <param name="employees">A collection of employees to send the message to.</param>
		public void SendMessage( Message message , EmployeeCollection employees ) {
			if( message.Validate() ) {
				using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
					MessageData messageToInsert = MessageMapping.FromBusinessObject( message );

					MessageDataCollection messagesInserted;
					// Insert the message in the database.
					messagesInserted = this.InsertMessageData( MessageDataCollection.FromSingleMessage( messageToInsert ) );

					// Create the message recipients.
					MessageRecipientDataCollection messageRecipientsToInsert = new MessageRecipientDataCollection();
					foreach( Employee employee in employees ) {
						messageRecipientsToInsert.Add( new MessageRecipientData( messagesInserted[0].SysId , employee.SysId ) );
					}
					// Insert the message recipients in the database.
					messageRecipientBll.InsertMessageRecipientData( messageRecipientsToInsert );

					// Register the message in the OUTBOX folder of the sender.
					MessageFolderDataCollection outboxFolders = messageFolderBll.GetSpecialMessageFolderDataForEmployee( message.Sender.SysId , MessageSpecialFolder.Outbox );
					MessageStorageDataCollection outboxStorages = MessageStorageDataCollection.FromSingleMessageStorage( new MessageStorageData( messagesInserted[0].SysId , outboxFolders[0].SysId , false , false ) );
					// Register the message in the INBOX folder of the recipients.
					MessageStorageDataCollection inboxStorages = new MessageStorageDataCollection();
					foreach( Employee employee in employees ) {
						MessageFolderDataCollection inboxFolders = messageFolderBll.GetSpecialMessageFolderDataForEmployee( employee.SysId , MessageSpecialFolder.Inbox );
						inboxStorages.Add( new MessageStorageData( messagesInserted[0].SysId , inboxFolders[0].SysId , false , true ) );
						// send mail.
						EmployeeSettings employeeSettings = new EmployeeSettingsBll().GetEmployeeSettingsForEmployee( employee );
						EmailNotificationBll.SendEmailNotification( employeeSettings , message );
					}
					// Collect all new messagestorages.
					MessageStorageDataCollection messageStorages = new MessageStorageDataCollection();
					messageStorages.Add( outboxStorages );
					messageStorages.Add( inboxStorages );
					// Insert the messagestorages into the database.
					messageStorageBll.InsertMessageStorageData( messageStorages );

					scope.Complete();
				}
			} else {
				throw new SwmSuiteException( null , SwmSuiteError.ValidationError , message.GetValidationError() );
			}
		}

		/// <summary>
		/// Delete a message from a given messagefolder.
		/// </summary>
		/// <param name="message">The message to delete.</param>
		/// <param name="messageFolder">The folder to delete the message from.</param>
		public void DeleteMessage( Message message , MessageFolder messageFolder ) {
			////this.RemoveMessages( MessageCollection.FromSingleMessage( message ) );
			//// Get the ARCHIVE folder for th
			//MessageFolderDataCollection archiveMessageFolders =
			//    messageFolderBll.GetSpecialMessageFolderDataForEmployee( messageFolder , MessageSpecialFolder.Archive );

			//this.MoveMessage( message , messageFolder , archiveMessageFolders[0] );
		}

		/// <summary>
		/// Move a message from source to destination folder.
		/// </summary>
		/// <param name="source">The source messagefolder.</param>
		/// <param name="destination">The destinationmessagefolder.</param>
		public void MoveMessage( Message message , MessageFolder source , MessageFolder destination ) {
			//// Source and destination messagefolder should have the same employee as owner.
			
			//if( source.OwnerEmployeeSysId != destination.OwnerEmployeeSysId ) {
			//    throw new SwmSuiteMoveMessageException( message , source , destination , MoveMessageError.DifferentOwnerEmployee );
			//} else if( source.SysId == destination.SysId ) {
			//    throw new SwmSuiteMoveMessageException( message , source , destination , MoveMessageError.SourceAndDestinationAreSame );
			//} else {
			//MessageStorageDataCollection messageStorages =
			//    messageStorageBll.GetMessageStorageByMessageAndMessageFolder( message.SysId , source.SysId );
			//messageStorages[0].MessageFolderSysId = destination.SysId;
			//messageStorageBll.UpdateMessageStorages( messageStorages );
			//}
			MessageStorageDataCollection messageStorages =
				messageStorageBll.GetMessageStorageDataByMessageAndMessageFolder( message.SysId , source.SysId );
			messageStorages[0].MessageFolderSysId = destination.SysId;
			messageStorageBll.UpdateMessageStorageData( messageStorages );
		}

		/// <summary>
		/// Update the read flag for a specific messagestorage.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <param name="messageFolder">The parent messagefolder of the message to update.</param>
		public void UpdateReadFlag( Message message , MessageFolder messageFolder ) {
			new MessageStorageBll().UpdateReadFlag( message.SysId , messageFolder.SysId , message.IsRead );
		}

		/// <summary>
		/// Update the new flag for a specific messagestorage.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <param name="messageFolder">The parent messagefolder of the message to update.</param>
		public void UpdateNewFlag( Message message , MessageFolder messageFolder ) {
			new MessageStorageBll().UpdateNewFlag( message.SysId , messageFolder.SysId , message.IsNew );
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all messages from the database.
		/// </summary>
		/// <returns>An MessageCollection containing all messages.</returns>
		public MessageDataCollection GetMessageData() {
			return dal.GetMessageData();
		}

		/// <summary>
		/// Get all messages from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the messages for.</param>
		/// <returns>An MessageCollection containing all requested messages.</returns>
		public MessageDataCollection GetMessageDataForEmployee( int employeeSysId ) {
			return dal.GetMessageDataForEmployee( employeeSysId );
		}

		/// <summary>
		/// Get all messages in a specific messagefolder from the database.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the messagefolder to get the messages for.</param>
		/// <returns>An MessageCollection containing all requested messages.</returns>
		public MessageDataCollection GetMessageDataInMessageFolder( int messageFolderSysId ) {
			return dal.GetMessageDataInMessageFolder( messageFolderSysId );
		}

		/// <summary>
		/// Get a single message from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the message to retrieve.</param>
		/// <returns>An MessageCollection containing the requested message.</returns>
		public MessageDataCollection GetMessageDataBySysId( int sysId ) {
			return dal.GetMessageDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple messages from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messages to retrieve.</param>
		/// <returns>An MessageCollection containing the requested messages.</returns>
		public MessageDataCollection GetMessageDataBySysIds( int[] sysIds ) {
			return dal.GetMessageDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more messages to the database.
		/// </summary>
		/// <param name="messages">An MessageCollection containing the messages to insert.</param>
		/// <returns>An MessageCollection containing the inserted messages.</returns>
		public MessageDataCollection InsertMessageData( MessageDataCollection messages ) {
			return dal.InsertMessageData( messages );
		}

		/// <summary>
		/// Update one or more messages in the database.
		/// </summary>
		/// <param name="messages">An MessageCollection containing the messages to update.</param>
		/// <returns>An MessageCollection containing the updated messages.</returns>
		public MessageDataCollection UpdateMessageData( MessageDataCollection messages ) {
			return dal.UpdateMessageData( messages );
		}

		/// <summary>
		/// Remove one or more messages from the database.
		/// </summary>
		/// <param name="messages">An MessageCollection containing the messages to remove.</param>
		public void RemoveMessageData( MessageDataCollection messages ) {
			dal.RemoveMessageData( messages );
		}

		/// <summary>
		/// Remove all messages from the database.
		/// </summary>
		public void RemoveAllMessageData() {
			dal.RemoveAllMessageData();
		}

		#endregion

	}

}
