using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Business;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Proxy.Inproc {

	public sealed class AvatarFacade : IAvatarFacade {

		/// <summary>
		/// Get all avatars from the datatabe.
		/// </summary>
		/// <returns>An AvatarCollection containing all avatars.</returns>
		AvatarCollection IAvatarFacade.GetAvatars() {
			return new AvatarBll().GetAvatars();
		}

		/// <summary>
		/// Get a specific avatar from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the avatar to get.</param>
		/// <returns>The requested avatar.</returns>
		Avatar IAvatarFacade.GetAvatar( int sysId ) {
			return new AvatarBll().GetAvatar( sysId );
		}

		/// <summary>
		/// Add a new avatar to the database.
		/// </summary>
		/// <param name="avatar">The avatar to add to the database.</param>
		Avatar IAvatarFacade.CreateAvatar( Avatar avatar ) {
			return new AvatarBll().CreateAvatar( avatar );
		}

		/// <summary>
		/// Update an existing avatar in the database.
		/// </summary>
		/// <param name="avatar">The avatar to update.</param>
		void IAvatarFacade.UpdateAvatar( Avatar avatar ) {
			new AvatarBll().UpdateAvatar( avatar );
		}

		/// <summary>
		/// Remove one or more avatars from the database.
		/// </summary>
		/// <param name="avatars">The avatars to remove.</param>
		void IAvatarFacade.RemoveAvatars( AvatarCollection avatars ) {
			new AvatarBll().RemoveAvatars( avatars );
		}

	}

}
