using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Services;
using SwmSuite.Business;
using SwmSuite.Proxy.Interface;
using System.ComponentModel;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {

	/// <summary>
	/// Summary description for UserService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class UserService : System.Web.Services.WebService , IUserFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Authenticates a user by given username and password.
		/// </summary>
		/// <param name="userName">The username of the user to authenticate.</param>
		/// <param name="password">The password to authenticate the user with.</param>
		/// <returns>True if authenticated, false otherwise.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public bool AuthenticateUser( String userName , String password ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new UserBll().AuthenticateUser( userName , password );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Creates a new user.
		/// </summary>
		/// <param name="userName">Name of the user to create.</param>
		/// <param name="password">The password of the user to create.</param>
		/// <param name="email">The email of the user to create.</param>
		/// <returns>The userid (guid) of the created user if succeeded.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Guid CreateUser( String userName , String password , String email ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new UserBll().CreateUser( userName , password , email );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Deletes a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to delete.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public bool DeleteUser( String userName ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new UserBll().DeleteUser( userName );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Changes the password of a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to change the password for.</param>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="newPassword">The new password.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public bool ChangePassword( String userName , String oldPassword , String newPassword ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new UserBll().ChangePassword( userName , oldPassword , newPassword );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}
	}
}
