using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Proxy.Interface {
	
	public interface IAvatarFacade {

		/// <summary>
		/// Get all avatars from the datatabe.
		/// </summary>
		/// <returns>An AvatarCollection containing all avatars.</returns>
		AvatarCollection GetAvatars();

		/// <summary>
		/// Get a specific avatar from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the avatar to get.</param>
		/// <returns>The requested avatar.</returns>
		Avatar GetAvatar( int sysId );

		/// <summary>
		/// Add a new avatar to the database.
		/// </summary>
		/// <param name="avatar">The avatar to add to the database.</param>
		/// <returns></returns>
		Avatar CreateAvatar( Avatar avatar );

		/// <summary>
		/// Update an existing avatar in the database.
		/// </summary>
		/// <param name="avatar">The avatar to update.</param>
		void UpdateAvatar( Avatar avatar );

		/// <summary>
		/// Remove one or more avatars from the database.
		/// </summary>
		/// <param name="avatars">The avatars to remove.</param>
		void RemoveAvatars( AvatarCollection avatars );

	}

}
