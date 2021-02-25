using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the AvatarService methods.
	/// </summary>
	public interface IAvatarDal {

		/// <summary>
		/// Get all avatars from the database.
		/// </summary>
		/// <returns>A AvatarCollection containing all avatars.</returns>
		AvatarDataCollection GetAvatarData();

		/// <summary>
		/// Get a single avatar from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the avatar to retrieve.</param>
		/// <returns>An AvatarCollection containing the requested avatar.</returns>
		AvatarDataCollection GetAvatarDataBySysId( int sysId );

		/// <summary>
		/// Get multiple avatars from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the avatars to retrieve.</param>
		/// <returns>An AvatarCollection containing the requested avatars.</returns>
		AvatarDataCollection GetAvatarDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more avatars to the database.
		/// </summary>
		/// <param name="avatars">An AvatarCollection containing the avatars to insert.</param>
		/// <returns>An AvatarCollection containing the inserted avatars.</returns>
		AvatarDataCollection InsertAvatarData( AvatarDataCollection avatars );

		/// <summary>
		/// Update one or more avatars in the database.
		/// </summary>
		/// <param name="avatars">An AvatarCollection containing the avatars to update.</param>
		/// <returns>An AvatarCollection containing the updated avatars.</returns>
		AvatarDataCollection UpdateAvatarData( AvatarDataCollection avatars );

		/// <summary>
		/// Remove one or more avatars from the database.
		/// </summary>
		/// <param name="avatars">An AvatarCollection containing the avatars to remove.</param>
		void RemoveAvatarData( AvatarDataCollection avatars );

		/// <summary>
		/// Remove all avatars from the database.
		/// </summary>
		void RemoveAllAvatarData();

	}

}
