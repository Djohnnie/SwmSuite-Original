using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.DataAccess.Interface {
	
	public interface IUserDal {

		/// <summary>
		/// Authenticates a user by given username and password.
		/// </summary>
		/// <param name="userName">The username of the user to authenticate.</param>
		/// <param name="password">The password to authenticate the user with.</param>
		/// <returns>True if authenticated, false otherwise.</returns>
		bool AuthenticateUser( String userName , String password );

		/// <summary>
		/// Creates a new user.
		/// </summary>
		/// <param name="userName">Name of the user to create.</param>
		/// <param name="password">The password of the user to create.</param>
		/// <param name="email">The email of the user to create.</param>
		/// <returns>The userid (guid) of the created user if succeeded.</returns>
		Guid CreateUser( String userName , String password , String email );

		/// <summary>
		/// Deletes a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to delete.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		bool DeleteUser( String userName );

		/// <summary>
		/// Changes the password of a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to change the password for.</param>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="newPassword">The new password.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		bool ChangePassword( String userName , String oldPassword , String newPassword );

		/// <summary>
		/// Get the username of the user by given userId.
		/// </summary>
		/// <param name="userSysId">The unique user identifier from the membership data source for the user.</param>
		/// <returns>The username.</returns>
		String GetUserNameFromSysId( Guid userSysId );

	}
}
