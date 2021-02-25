using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;
using SwmSuite.Business.DataMapping;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Business {

	public class MessageFolderBll {

		#region -_ Private Members _-

		private IMessageFolderDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateMessageFolderDal();

		#endregion

		#region -_ Business Methods _-

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
		public MessageFolderCollection GetRootMessageFolders( Employee employee ) {
			MessageFolderCollection messageFoldersToReturn = new MessageFolderCollection();
			MessageFolderDataCollection messageFolderData = new MessageFolderDataCollection();
			messageFolderData.Add( this.GetSpecialMessageFolderDataForEmployee( employee.SysId , MessageSpecialFolder.Inbox ) );
			messageFolderData.Add( this.GetSpecialMessageFolderDataForEmployee( employee.SysId , MessageSpecialFolder.Outbox ) );
			messageFolderData.Add( this.GetSpecialMessageFolderDataForEmployee( employee.SysId , MessageSpecialFolder.Archive ) );
			foreach( MessageFolderData messageFolder in messageFolderData ) {
				MessageFolder newMessageFolder = MessageFolderMapping.FromDataObject( messageFolder );
				// Get subfolders (only folder detail, not recursive).
				MessageFolderDataCollection childMessageFolderData = this.GetMessageFolderDataForFolder( messageFolder.SysId );
				newMessageFolder.ChildFolders = new MessageFolderCollection();
				foreach( MessageFolderData childMessageFolder in childMessageFolderData ) {
					MessageFolder newChildMessageFolder = MessageFolderMapping.FromDataObject( childMessageFolder );
					newMessageFolder.ChildFolders.Add( newChildMessageFolder );
				}
				messageFoldersToReturn.Add( newMessageFolder );
			}
			return messageFoldersToReturn;
		}

		public MessageFolder GetParentMessageFolderForMessage( Message message , Employee employee ) {
			return GetParentMessageFolderForMessage( message.SysId , employee.SysId );
		}

		public MessageFolder GetParentMessageFolderForMessage( int messageSysId , int employeeSysId ) {
			MessageFolderDataCollection messageFolderData = GetParentMessageFolderDataByMessage( messageSysId , employeeSysId );
			if( messageFolderData.Count == 1 ) {
				return MessageFolderMapping.FromDataObject( messageFolderData[0] );
			} else {
				throw new SwmSuiteException( null , SwmSuiteError.BusinessError , "Bericht kan niet meer dan 1 ouder-map hebben." );
			}
		}

		/// <summary>
		/// Get the child messagefolders from the database for a specific messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the child messagefolders for.</param>
		/// <returns>A MessageFolderCollection containing the requested messagefolders.</returns>
		public MessageFolderCollection GetMessageFolders( MessageFolder messageFolder ) {
			return MessageFolderMapping.FromDataObjectCollection( 
				this.GetMessageFolderDataForFolder( messageFolder.SysId ) );
		}

		/// <summary>
		/// Get all special messagefolders from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the special messageFolders for.</param>
		/// <param name="specialFolder">The special messagefolders to get.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		public MessageFolder GetSpecialMessageFolderForEmployee( Employee employee , MessageSpecialFolder specialFolder ) {
			MessageFolder messageFolderToReturn = null;
			MessageFolderDataCollection messageFolderData =
				this.GetSpecialMessageFolderDataForEmployee( employee.SysId , specialFolder );
			if( messageFolderData.Count == 1 ) {
				messageFolderToReturn = MessageFolderMapping.FromDataObject( messageFolderData[0] );
			}
			return messageFolderToReturn;
		}

		/// <summary>
		/// Get the details for a given messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the details for.</param>
		/// <returns>A detailed version of the goven messagefolder.</returns>
		/// <remarks>
		/// Get the details for a given messagefolder (subfolders and messages).
		/// </remarks>
		public MessageFolder GetMessageFolderDetail( MessageFolder messageFolder ) {
			MessageFolder messageFolderToReturn = null;
			MessageFolderDataCollection messageFolderData = this.GetMessageFolderDataBySysId( messageFolder.SysId );
			if( messageFolderData.Count == 1 ) {
				messageFolderToReturn = MessageFolderMapping.FromDataObject( messageFolderData[0] );
				// Get subfolders (only folder detail, not recursive).
				MessageFolderDataCollection childMessageFolderData = this.GetMessageFolderDataForFolder( messageFolder.SysId );
				messageFolderToReturn.ChildFolders = new MessageFolderCollection();
				foreach( MessageFolderData childMessageFolder in childMessageFolderData ) {
					MessageFolder newChildMessageFolder = MessageFolderMapping.FromDataObject( childMessageFolder );
					messageFolderToReturn.ChildFolders.Add( newChildMessageFolder );
				}
				// Get messages.
				//MessageDataCollection childMessageData = new MessageBll().GetMessages();
				//messageFolderToReturn.Messages = new MessageCollection();
				//foreach( MessageData childMessage in childMessageData ) {
				//    Message newChildMessage = childMessage.ToBusinessObject();
				//    messageFolderToReturn.Messages.Add( newChildMessage );
				//}

			} else {
				messageFolderToReturn = null;
			}
			return messageFolderToReturn;
		}

		/// <summary>
		/// Create a new messagefolder as child of a given parent messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to create.</param>
		/// <param name="parentMessageFolder">The parent messagefolder to create the child folder for.</param>
		/// <returns>The created messagefolder.</returns>
		public MessageFolder CreateMessageFolder( MessageFolder messageFolder , MessageFolder parentMessageFolder ) {
			MessageFolderData messageFolderToCreate = MessageFolderMapping.FromBusinessObject( messageFolder );
			//messageFolderToCreate.OwnerEmployeeSysId
			messageFolderToCreate.ParentMessageFolderSysId = parentMessageFolder.SysId;

			MessageFolderDataCollection messageFolderDataResult =
				this.InsertMessageFolderData( MessageFolderDataCollection.FromSingleMessageFolder( messageFolderToCreate ) );

			return MessageFolderMapping.FromDataObject( messageFolderDataResult[0] );
		}

		/// <summary>
		/// Update an existing messagefolder in the database.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to update.</param>
		/// <param name="employee">The owneremployee for the messagefolder.</param>
		/// <returns>The updated messagefolder.</returns>
		public MessageFolder UpdateMessageFolder( MessageFolder messageFolder , Employee employee ) {
			MessageFolderData messageFolderToUpdate = MessageFolderMapping.FromBusinessObject( messageFolder );
			messageFolderToUpdate.OwnerEmployeeSysId = employee.SysId;

			MessageFolderDataCollection messageFolderDataResult =
				this.UpdateMessageFolderData( MessageFolderDataCollection.FromSingleMessageFolder( messageFolderToUpdate ) );

			return MessageFolderMapping.FromDataObject( messageFolderDataResult[0] );
		}

		/// <summary>
		/// Move a given messagefolder to a given parent messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to move.</param>
		/// <param name="newParentMessageFolder">The new parent messagefolder.</param>
		/// <remarks>
		/// 
		/// </remarks>
		public void MoveMessageFolder( MessageFolder messageFolder , MessageFolder newParentMessageFolder ) {
			if( messageFolder.SpecialFolder == MessageSpecialFolder.None ) {
				MessageFolderData messageFolderToUpdate = MessageFolderMapping.FromBusinessObject( messageFolder );
				messageFolderToUpdate.ParentMessageFolderSysId = newParentMessageFolder.SysId;

				this.UpdateMessageFolderData(
					MessageFolderDataCollection.FromSingleMessageFolder( messageFolderToUpdate ) );
			}
		}

		/// <summary>
		/// Delete a given messagefolder from the database.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to delete.</param>
		/// <returns>True if delete was succesful, false otherwise.</returns>
		public bool DeleteMessageFolder( MessageFolder messageFolder ) {
			bool result = false;
			// Check for messages and subfolders.
			MessageFolderDataCollection childMessageFolderData =
				this.GetMessageFolderDataForFolder( messageFolder.SysId );
			MessageDataCollection childMessageData =
				new MessageBll().GetMessageDataInMessageFolder( messageFolder.SysId );
			if( childMessageFolderData.Count == 0 && childMessageData.Count == 0 ) {
				MessageFolderData messageFolderData = MessageFolderMapping.FromBusinessObject( messageFolder );
				this.RemoveMessageFolderData( MessageFolderDataCollection.FromSingleMessageFolder( messageFolderData ) );
				MessageFolderDataCollection messageFolderDataResult =
					this.GetMessageFolderDataBySysId( messageFolder.SysId );
				if( messageFolderDataResult.Count == 0 ) {
					result = true;
				}

			}
			return result;
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all messageFolders from the database.
		/// </summary>
		/// <returns>An MessageFolderCollection containing all messageFolders.</returns>
		public MessageFolderDataCollection GetMessageFolderData() {
			return dal.GetMessageFolderData();
		}

		/// <summary>
		/// Get all messageFolders from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the messageFolders for.</param>
		/// <returns>An MessageFolderCollection containing all requested messageFolders.</returns>
		public MessageFolderDataCollection GetMessageFolderDataForEmployee( int employeeSysId ) {
			return dal.GetMessageFolderDataForEmployee( employeeSysId );
		}

		/// <summary>
		/// Get all messagefolders from the database for a specific parent folder.
		/// </summary>
		/// <param name="folderSysId">The internal id of the folder to get the subfolders for.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		public MessageFolderDataCollection GetMessageFolderDataForFolder( int folderSysId ) {
			return dal.GetMessageFolderDataForFolder( folderSysId );
		}

		/// <summary>
		/// Get the parent messagefolder for a specific message.
		/// </summary>
		/// <param name="messageSysId">The internal id of the message to get the parent folder for.</param>
		/// <param name="employeeSysId">The internal id of the owner of the message folder.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		public MessageFolderDataCollection GetParentMessageFolderDataByMessage( int messageSysId , int employeeSysId ) {
			return dal.GetParentMessageFolderDataByMessage( messageSysId , employeeSysId );
		}

		/// <summary>
		/// Get all special messagefolders from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the special messageFolders for.</param>
		/// <param name="specialFolder">The special messagefolders to get.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		public MessageFolderDataCollection GetSpecialMessageFolderDataForEmployee( int employeeSysId , MessageSpecialFolder specialFolder ) {
			return dal.GetSpecialMessageFoldeDataForEmployee( employeeSysId , specialFolder );
		}

		/// <summary>
		/// Get a single messageFolder from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the messageFolder to retrieve.</param>
		/// <returns>An MessageFolderCollection containing the requested messageFolder.</returns>
		public MessageFolderDataCollection GetMessageFolderDataBySysId( int sysId ) {
			return dal.GetMessageFolderDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple messageFolders from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messageFolders to retrieve.</param>
		/// <returns>An MessageFolderCollection containing the requested messageFolders.</returns>
		public MessageFolderDataCollection GetMessageFolderDataBySysIds( int[] sysIds ) {
			return dal.GetMessageFolderDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more messageFolders to the database.
		/// </summary>
		/// <param name="messageFolders">An MessageFolderCollection containing the messageFolders to insert.</param>
		/// <returns>An MessageFolderCollection containing the inserted messageFolders.</returns>
		public MessageFolderDataCollection InsertMessageFolderData( MessageFolderDataCollection messageFolders ) {
			return dal.InsertMessageFolderData( messageFolders );
		}

		/// <summary>
		/// Update one or more messageFolders in the database.
		/// </summary>
		/// <param name="messageFolders">An MessageFolderCollection containing the messageFolders to update.</param>
		/// <returns>An MessageFolderCollection containing the updated messageFolders.</returns>
		public MessageFolderDataCollection UpdateMessageFolderData( MessageFolderDataCollection messageFolders ) {
			return dal.UpdateMessageFolderData( messageFolders );
		}

		/// <summary>
		/// Remove one or more messageFolders from the database.
		/// </summary>
		/// <param name="messageFolders">An MessageFolderCollection containing the messageFolders to remove.</param>
		public void RemoveMessageFolderData( MessageFolderDataCollection messageFolders ) {
			dal.RemoveMessageFolderData( messageFolders );
		}

		/// <summary>
		/// Remove all messageFolders from the database.
		/// </summary>
		public void RemoveAllMessageFolderData() {
			dal.RemoveAllMessageFolderData();
		}

		#endregion

	}

}
