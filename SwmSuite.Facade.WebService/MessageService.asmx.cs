using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Services;
using SwmSuite.Proxy.Interface;
using SwmSuite.Business;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;
using System.ComponentModel;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {
	/// <summary>
	/// Summary description for MessageService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class MessageService : System.Web.Services.WebService , IMessageFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get all messages from the database for a specific messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the messages for.</param>
		/// <returns>A MessageCollection containing the requested messages.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public MessageCollection GetMessagesForMessageFolder( MessageFolder messageFolder ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new MessageBll().GetMessagesForMessageFolder( messageFolder );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void SendMessage( Message message , EmployeeCollection employees ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new MessageBll().SendMessage( message , employees );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void DeleteMessage( Message message , MessageFolder messageFolder ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new MessageBll().DeleteMessage( message , messageFolder );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void MoveMessage( Message message , MessageFolder source , MessageFolder destination ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new MessageBll().MoveMessage( message , source , destination );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public MessageFolderCollection GetRootMessageFolders( Employee employee ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new MessageFolderBll().GetRootMessageFolders( employee );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get the child messagefolders from the database for a specific messagefolder.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to get the child messagefolders for.</param>
		/// <returns>A MessageFolderCollection containing the requested messagefolders.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public MessageFolderCollection GetMessageFolders( MessageFolder messageFolder ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new MessageFolderBll().GetMessageFolders( messageFolder );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public MessageFolder GetSpecialMessageFolderForEmployee( Employee employee , MessageSpecialFolder specialFolder ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new MessageFolderBll().GetSpecialMessageFolderForEmployee( employee , specialFolder );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public MessageFolder GetMessageFolderDetail( MessageFolder messageFolder ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new MessageFolderBll().GetMessageFolderDetail( messageFolder );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public MessageFolder CreateMessageFolder( MessageFolder messageFolder , MessageFolder parentMessageFolder ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new MessageFolderBll().CreateMessageFolder( messageFolder , parentMessageFolder );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public MessageFolder UpdateMessageFolder( MessageFolder messageFolder , Employee employee ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new MessageFolderBll().UpdateMessageFolder( messageFolder , employee );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void MoveMessageFolder( MessageFolder messageFolder , MessageFolder newParentMessageFolder ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new MessageFolderBll().MoveMessageFolder( messageFolder , newParentMessageFolder );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update the read flag for a specific messagestorage.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <param name="messageFolder">The parent messagefolder of the message to update.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void UpdateReadFlag( Message message , MessageFolder messageFolder ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new MessageBll().UpdateReadFlag( message , messageFolder );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update the new flag for a specific messagestorage.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <param name="messageFolder">The parent messagefolder of the message to update.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void UpdateNewFlag( Message message , MessageFolder messageFolder ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new MessageBll().UpdateNewFlag( message , messageFolder );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Delete a given messagefolder from the database.
		/// </summary>
		/// <param name="messageFolder">The messagefolder to delete.</param>
		/// <returns>True if delete was succesful, false otherwise.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public bool DeleteMessageFolder( MessageFolder messageFolder ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new MessageFolderBll().DeleteMessageFolder( messageFolder );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

	}
}
