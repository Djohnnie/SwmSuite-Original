using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;
using SwmSuite.Data.Common;

namespace SwmSuite.Proxy.Inproc {

	public sealed class MessageFacade : IMessageFacade {

		/// <summary>
		/// Get all messages from the database for a specific messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the messages for.</param>
		/// <returns>A MessageCollection containing the requested messages.</returns>
		MessageCollection IMessageFacade.GetMessagesForMessageFolder( MessageFolder messageFolder ) {
			return new MessageBll().GetMessagesForMessageFolder( messageFolder );
		}

		void IMessageFacade.SendMessage( Message message , EmployeeCollection employees ) {
			new MessageBll().SendMessage( message , employees );
		}

		void IMessageFacade.DeleteMessage( Message message , MessageFolder messageFolder ) {
			new MessageBll().DeleteMessage( message , messageFolder );
		}

		void IMessageFacade.MoveMessage( Message message , MessageFolder source , MessageFolder destination ) {
			new MessageBll().MoveMessage( message , source , destination );
		}

		MessageFolderCollection IMessageFacade.GetRootMessageFolders( Employee employee ) {
			return new MessageFolderBll().GetRootMessageFolders( employee );
		}

		/// <summary>
		/// Get the child messagefolders from the database for a specific messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the child messagefolders for.</param>
		/// <returns>A MessageFolderCollection containing the requested messagefolders.</returns>
		MessageFolderCollection IMessageFacade.GetMessageFolders( MessageFolder messageFolder ) {
			return new MessageFolderBll().GetMessageFolders( messageFolder );
		}

		MessageFolder IMessageFacade.GetSpecialMessageFolderForEmployee( Employee employee , MessageSpecialFolder specialFolder ) {
			return new MessageFolderBll().GetSpecialMessageFolderForEmployee( employee , specialFolder );
		}

		MessageFolder IMessageFacade.GetMessageFolderDetail( MessageFolder messageFolder ) {
			return new MessageFolderBll().GetMessageFolderDetail( messageFolder );
		}

		MessageFolder IMessageFacade.CreateMessageFolder( MessageFolder messageFolder , MessageFolder parentMessageFolder ) {
			return new MessageFolderBll().CreateMessageFolder( messageFolder , parentMessageFolder );
		}

		MessageFolder IMessageFacade.UpdateMessageFolder( MessageFolder messageFolder , Employee employee ) {
			return new MessageFolderBll().UpdateMessageFolder( messageFolder , employee );
		}

		void IMessageFacade.MoveMessageFolder( MessageFolder messageFolder , MessageFolder newParentMessageFolder ) {
			new MessageFolderBll().MoveMessageFolder( messageFolder , newParentMessageFolder );
		}

		/// <summary>
		/// Update the read flag for a specific messagestorage.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <param name="messageFolder">The parent messagefolder of the message to update.</param>
		void IMessageFacade.UpdateReadFlag( Message message , MessageFolder messageFolder ) {
			new MessageBll().UpdateReadFlag( message , messageFolder );
		}

		/// <summary>
		/// Update the new flag for a specific messagestorage.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <param name="messageFolder">The parent messagefolder of the message to update.</param>
		void IMessageFacade.UpdateNewFlag( Message message , MessageFolder messageFolder ) {
			new MessageBll().UpdateNewFlag( message , messageFolder );
		}

		/// <summary>
		/// Delete a given messagefolder from the database.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to delete.</param>
		/// <returns>True if delete was succesful, false otherwise.</returns>
		bool IMessageFacade.DeleteMessageFolder( MessageFolder messageFolder ) {
			return new MessageFolderBll().DeleteMessageFolder( messageFolder );
		}

	}

}
