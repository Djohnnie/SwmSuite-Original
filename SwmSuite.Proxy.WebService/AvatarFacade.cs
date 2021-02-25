using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public sealed class AvatarFacade :
		ServiceFacade<AvatarService.AvatarService , AvatarService.SwmSuiteSoapHeader> ,
		IAvatarFacade {

		/// <summary>
		/// Get all avatars from the datatabe.
		/// </summary>
		/// <returns>An AvatarCollection containing all avatars.</returns>
		AvatarCollection IAvatarFacade.GetAvatars() {
			try {
				AvatarCollection avatars = new AvatarCollection();
				foreach( AvatarService.Avatar avatar in GetService().GetAvatars() ) {
					avatars.Add( (Avatar)XmlSerialization.ConvertObject( avatar , typeof( AvatarService.Avatar ) , typeof( Avatar ) ) );
				}
				return avatars;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get a specific avatar from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the avatar to get.</param>
		/// <returns>The requested avatar.</returns>
		Avatar IAvatarFacade.GetAvatar( int sysId ) {
			try {
				AvatarService.Avatar avatar = GetService().GetAvatar( sysId );
				return (Avatar)XmlSerialization.ConvertObject( avatar , typeof( AvatarService.Avatar ) , typeof( Avatar ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Add a new avatar to the database.
		/// </summary>
		/// <param name="avatar">The avatar to add to the database.</param>
		Avatar IAvatarFacade.CreateAvatar( Avatar avatar ) {
			try {
				AvatarService.Avatar avatarParameter =
				(AvatarService.Avatar)XmlSerialization.ConvertObject( avatar , typeof( Avatar ) , typeof( AvatarService.Avatar ) );
				AvatarService.Avatar avatarToReturn =
					GetService().CreateAvatar( avatarParameter );
				return (Avatar)XmlSerialization.ConvertObject( avatarToReturn , typeof( AvatarService.Avatar ) , typeof( Avatar ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing avatar in the database.
		/// </summary>
		/// <param name="avatar">The avatar to update.</param>
		void IAvatarFacade.UpdateAvatar( Avatar avatar ) {
			try {
				AvatarService.Avatar avatarParameter =
				(AvatarService.Avatar)XmlSerialization.ConvertObject( avatar , typeof( Avatar ) , typeof( AvatarService.Avatar ) );
				GetService().UpdateAvatar( avatarParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove one or more avatars from the database.
		/// </summary>
		/// <param name="avatars">The avatars to remove.</param>
		void IAvatarFacade.RemoveAvatars( AvatarCollection avatars ) {
			try {
				AvatarService.Avatar[] avatarsParameter = new AvatarService.Avatar[avatars.Count];
				foreach( Avatar avatar in avatars ) {
					avatarsParameter[avatars.IndexOf( avatar )] =
						(AvatarService.Avatar)XmlSerialization.ConvertObject( avatar , typeof( Avatar ) , typeof( AvatarService.Avatar ) );
				}
				GetService().RemoveAvatars( avatarsParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

	}

}
