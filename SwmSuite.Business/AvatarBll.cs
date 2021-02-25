using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using System.Drawing;
using System.IO;

namespace SwmSuite.Business {

	public class AvatarBll {

		#region -_ Private Members _-

		private IAvatarDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateImageDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all avatars from the datatabe.
		/// </summary>
		/// <returns>An AvatarCollection containing all avatars.</returns>
		public AvatarCollection GetAvatars() {
			AvatarDataCollection imageData = this.GetAvatarData();
			AvatarCollection avatarsToReturn = new AvatarCollection();
			foreach( AvatarData image in imageData ) {
				avatarsToReturn.Add( new Avatar( image.Picture ) { SysId = image.SysId , RowVersion = image.RowVersion } );
			}
			return avatarsToReturn;
		}

		/// <summary>
		/// Get a specific avatar from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the avatar to get.</param>
		/// <returns>The requested avatar.</returns>
		public Avatar GetAvatar( int sysId ) {
			AvatarDataCollection imageData = this.GetAvatarDataBySysId( sysId );
			Avatar avatarToReturn = new Avatar( imageData[0].Picture );
			avatarToReturn.SysId = imageData[0].SysId;
			avatarToReturn.RowVersion = imageData[0].RowVersion;
			return avatarToReturn;
		}

		/// <summary>
		/// Add a new avatar to the database.
		/// </summary>
		/// <param name="avatar">The avatar to add to the database.</param>
		public Avatar CreateAvatar( Avatar avatar ) {
			AvatarData avatarToCreate = new AvatarData( avatar.Picture );
			AvatarDataCollection avatarData =
				this.InsertAvatarData( AvatarDataCollection.FromSingleAvatar( avatarToCreate ) );
			return new Avatar( avatarData[0].Picture );
		}

		/// <summary>
		/// Update an existing avatar in the database.
		/// </summary>
		/// <param name="avatar">The avatar to update.</param>
		public void UpdateAvatar( Avatar avatar ){
			AvatarData avatarToUpdate = new AvatarData( avatar.Picture );
			avatarToUpdate.SysId = avatar.SysId;
			avatarToUpdate.RowVersion = avatar.RowVersion;
			this.UpdateAvatarData( AvatarDataCollection.FromSingleAvatar( avatarToUpdate ) );
		}

		/// <summary>
		/// Remove one or more avatars from the database.
		/// </summary>
		/// <param name="avatars">The avatars to remove.</param>
		public void RemoveAvatars( AvatarCollection avatars ) {
			AvatarDataCollection avatarsToRemove = new AvatarDataCollection();
			foreach( Avatar avatar in avatars ) {
				avatarsToRemove.Add( new AvatarData() { SysId = avatar.SysId , RowVersion = avatar.RowVersion } );
			}
			this.RemoveAvatarData( avatarsToRemove );
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all avatars from the database.
		/// </summary>
		/// <returns>An AvatarCollection containing all avatars.</returns>
		public AvatarDataCollection GetAvatarData() {
			return dal.GetAvatarData();
		}

		/// <summary>
		/// Get a single avatar from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the avatar to retrieve.</param>
		/// <returns>An AvatarCollection containing the requested avatar.</returns>
		public AvatarDataCollection GetAvatarDataBySysId( int sysId ) {
			return dal.GetAvatarDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple avatars from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the avatars to retrieve.</param>
		/// <returns>An AvatarCollection containing the requested avatars.</returns>
		public AvatarDataCollection GetAvatarDataBySysIds( int[] sysIds ) {
			return dal.GetAvatarDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more avatars to the database.
		/// </summary>
		/// <param name="avatars">An AvatarCollection containing the avatars to insert.</param>
		/// <returns>An AvatarCollection containing the inserted avatars.</returns>
		public AvatarDataCollection InsertAvatarData( AvatarDataCollection avatars ) {
			return dal.InsertAvatarData( avatars );
		}

		/// <summary>
		/// Update one or more avatars in the database.
		/// </summary>
		/// <param name="avatars">An AvatarCollection containing the avatars to update.</param>
		/// <returns>An AvatarCollection containing the updated avatars.</returns>
		public AvatarDataCollection UpdateAvatarData( AvatarDataCollection avatars ) {
			return dal.UpdateAvatarData( avatars );
		}

		/// <summary>
		/// Remove one or more avatars from the database.
		/// </summary>
		/// <param name="avatars">An AvatarCollection containing the avatars to remove.</param>
		public void RemoveAvatarData( AvatarDataCollection avatars ) {
			dal.RemoveAvatarData( avatars );
		}

		/// <summary>
		/// Remove all avatars from the database.
		/// </summary>
		public void RemoveAllAvatarData() {
			dal.RemoveAllAvatarData();
		}

		#endregion

	}


}
