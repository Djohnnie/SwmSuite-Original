using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using SwmSuite.Data.Common;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public class MessageFacade :
		ServiceFacade<MessageService.MessageService , MessageService.SwmSuiteSoapHeader> ,
		IMessageFacade {

		/// <summary>
		/// Get all messages from the database for a specific messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the messages for.</param>
		/// <returns>A MessageCollection containing the requested messages.</returns>
		MessageCollection IMessageFacade.GetMessagesForMessageFolder( MessageFolder messageFolder ) {
			try {
				MessageService.MessageFolder messageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				MessageService.Message[] messages = GetService().GetMessagesForMessageFolder( messageFolderParameter );
				MessageCollection messagesToReturn = new MessageCollection();
				foreach( MessageService.Message message in messages ) {
					messagesToReturn.Add( (Message)XmlSerialization.ConvertObject( message , typeof( MessageService.Message ) , typeof( Message ) ) );
				}
				return messagesToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		void IMessageFacade.SendMessage( Message message , EmployeeCollection employees ) {
			try {
				MessageService.Message messageParameter = (MessageService.Message)XmlSerialization.ConvertObject( message , typeof( Message ) , typeof( MessageService.Message ) );
				MessageService.Employee[] employeesParameter = new MessageService.Employee[employees.Count];
				foreach( Employee employee in employees ) {
					employeesParameter[employees.IndexOf( employee )] = (MessageService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( MessageService.Employee ) );
				}
				GetService().SendMessage( messageParameter , employeesParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		void IMessageFacade.DeleteMessage( Message message , MessageFolder messageFolder ) {
			try {
				MessageService.Message messageParameter = (MessageService.Message)XmlSerialization.ConvertObject( message , typeof( Message ) , typeof( MessageService.Message ) );
				MessageService.MessageFolder messageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				GetService().DeleteMessage( messageParameter , messageFolderParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		void IMessageFacade.MoveMessage( Message message , MessageFolder source , MessageFolder destination ) {
			try {
				MessageService.Message messageParameter = (MessageService.Message)XmlSerialization.ConvertObject( message , typeof( Message ) , typeof( MessageService.Message ) );
				MessageService.MessageFolder sourceParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( source , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				MessageService.MessageFolder destinationParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( destination , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				GetService().MoveMessage( messageParameter , sourceParameter , destinationParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		MessageFolderCollection IMessageFacade.GetRootMessageFolders( Employee employee ) {
			try {
				MessageService.Employee employeeParameter = (MessageService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( MessageService.Employee ) );
				MessageService.MessageFolder[] messageFolders = GetService().GetRootMessageFolders( employeeParameter );
				MessageFolderCollection messageFoldersToReturn = new MessageFolderCollection();
				foreach( MessageService.MessageFolder messageFolder in messageFolders ) {
					messageFoldersToReturn.Add( (MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageService.MessageFolder ) , typeof( MessageFolder ) ) );
				}
				return messageFoldersToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get the child messagefolders from the database for a specific messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the child messagefolders for.</param>
		/// <returns>A MessageFolderCollection containing the requested messagefolders.</returns>
		MessageFolderCollection IMessageFacade.GetMessageFolders( MessageFolder messageFolder ) {
			try {
				MessageService.MessageFolder messageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				MessageService.MessageFolder[] messageFolders = GetService().GetMessageFolders( messageFolderParameter );
				MessageFolderCollection messageFoldersToReturn = new MessageFolderCollection();
				foreach( MessageService.MessageFolder childMessageFolder in messageFolders ) {
					messageFoldersToReturn.Add( (MessageFolder)XmlSerialization.ConvertObject( childMessageFolder , typeof( MessageService.MessageFolder ) , typeof( MessageFolder ) ) );
				}
				return messageFoldersToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		MessageFolder IMessageFacade.GetSpecialMessageFolderForEmployee( Employee employee , MessageSpecialFolder specialFolder ) {
			try {
				MessageService.Employee employeeParameter = (MessageService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( MessageService.Employee ) );
				MessageService.MessageSpecialFolder specialFolderParameter = (MessageService.MessageSpecialFolder)(byte)specialFolder;
				MessageService.MessageFolder messageFolder =
					GetService().GetSpecialMessageFolderForEmployee( employeeParameter , specialFolderParameter );
				return (MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageService.MessageFolder ) , typeof( MessageFolder ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		MessageFolder IMessageFacade.GetMessageFolderDetail( MessageFolder messageFolder ) {
			try {
				MessageService.MessageFolder messageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				MessageService.MessageFolder messageFolderToReturn =
					GetService().GetMessageFolderDetail( messageFolderParameter );
				return (MessageFolder)XmlSerialization.ConvertObject( messageFolderToReturn , typeof( MessageService.MessageFolder ) , typeof( MessageFolder ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		MessageFolder IMessageFacade.CreateMessageFolder( MessageFolder messageFolder , MessageFolder parentMessageFolder ) {
			try {
				MessageService.MessageFolder messageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				MessageService.MessageFolder parentMessageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( parentMessageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				MessageService.MessageFolder messageFolderToReturn =
					GetService().CreateMessageFolder( messageFolderParameter , parentMessageFolderParameter );
				return (MessageFolder)XmlSerialization.ConvertObject( messageFolderToReturn , typeof( MessageService.MessageFolder ) , typeof( MessageFolder ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		MessageFolder IMessageFacade.UpdateMessageFolder( MessageFolder messageFolder , Employee employee ) {
			try {
				MessageService.MessageFolder messageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				MessageService.Employee employeeParameter = (MessageService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( MessageService.Employee ) );
				MessageService.MessageFolder messageFolderToReturn =
					GetService().UpdateMessageFolder( messageFolderParameter , employeeParameter );
				return (MessageFolder)XmlSerialization.ConvertObject( messageFolderToReturn , typeof( MessageService.MessageFolder ) , typeof( MessageFolder ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		void IMessageFacade.MoveMessageFolder( MessageFolder messageFolder , MessageFolder newParentMessageFolder ) {
			try {
				MessageService.MessageFolder messageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				MessageService.MessageFolder newParentMessageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( newParentMessageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				GetService().CreateMessageFolder( messageFolderParameter , newParentMessageFolderParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update the read flag for a specific messagestorage.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <param name="messageFolder">The parent messagefolder of the message to update.</param>
		void IMessageFacade.UpdateReadFlag( Message message , MessageFolder messageFolder ) {
			try {
				MessageService.Message messageParameter = (MessageService.Message)XmlSerialization.ConvertObject( message , typeof( Message ) , typeof( MessageService.Message ) );
				MessageService.MessageFolder messageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				GetService().UpdateReadFlag( messageParameter , messageFolderParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update the new flag for a specific messagestorage.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <param name="messageFolder">The parent messagefolder of the message to update.</param>
		void IMessageFacade.UpdateNewFlag( Message message , MessageFolder messageFolder ) {
			try {
				MessageService.Message messageParameter = (MessageService.Message)XmlSerialization.ConvertObject( message , typeof( Message ) , typeof( MessageService.Message ) );
				MessageService.MessageFolder messageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				GetService().UpdateNewFlag( messageParameter , messageFolderParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Delete a given messagefolder from the database.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to delete.</param>
		/// <returns>True if delete was succesful, false otherwise.</returns>
		bool IMessageFacade.DeleteMessageFolder( MessageFolder messageFolder ) {
			try {
				MessageService.MessageFolder messageFolderParameter = (MessageService.MessageFolder)XmlSerialization.ConvertObject( messageFolder , typeof( MessageFolder ) , typeof( MessageService.MessageFolder ) );
				return GetService().DeleteMessageFolder( messageFolderParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

	}

}
