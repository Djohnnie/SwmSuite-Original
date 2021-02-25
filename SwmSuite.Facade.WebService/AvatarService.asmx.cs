using System;
using System.Collections;
using System.ComponentModel;
using System.Data;

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {

	/// <summary>
	/// Summary description for AvatarService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class AvatarService : System.Web.Services.WebService , IAvatarFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get all avatars from the datatabe.
		/// </summary>
		/// <returns>An AvatarCollection containing all avatars.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public AvatarCollection GetAvatars() {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AvatarBll().GetAvatars();
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get a specific avatar from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the avatar to get.</param>
		/// <returns>The requested avatar.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Avatar GetAvatar( int sysId ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AvatarBll().GetAvatar( sysId );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Add a new avatar to the database.
		/// </summary>
		/// <param name="avatar">The avatar to add to the database.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Avatar CreateAvatar( Avatar avatar ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AvatarBll().CreateAvatar( avatar );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing avatar in the database.
		/// </summary>
		/// <param name="avatar">The avatar to update.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void UpdateAvatar( Avatar avatar ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new AvatarBll().UpdateAvatar( avatar );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove one or more avatars from the database.
		/// </summary>
		/// <param name="avatars">The avatars to remove.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveAvatars( AvatarCollection avatars ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new AvatarBll().RemoveAvatars( avatars );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

	}

}