using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {
	
	public class UserFacade : IUserFacade {

		/// <summary>
		/// Authenticates a user by given username and password.
		/// </summary>
		/// <param name="userName">The username of the user to authenticate.</param>
		/// <param name="password">The password to authenticate the user with.</param>
		/// <returns>True if authenticated, false otherwise.</returns>
		bool IUserFacade.AuthenticateUser( String userName , String password ) {
			return new UserBll().AuthenticateUser( userName , password );
		}

		/// <summary>
		/// Creates a new user.
		/// </summary>
		/// <param name="userName">Name of the user to create.</param>
		/// <param name="password">The password of the user to create.</param>
		/// <param name="email">The email of the user to create.</param>
		/// <returns>The userid (guid) of the created user if succeeded.</returns>
		Guid IUserFacade.CreateUser( String userName , String password , String email ) {
			return new UserBll().CreateUser( userName , password , email );
		}

		/// <summary>
		/// Deletes a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to delete.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		bool IUserFacade.DeleteUser( String userName ) {
			return new UserBll().DeleteUser( userName );
		}

		/// <summary>
		/// Changes the password of a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to change the password for.</param>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="newPassword">The new password.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		bool IUserFacade.ChangePassword( String userName , String oldPassword , String newPassword ) {
			return new UserBll().ChangePassword( userName , oldPassword , newPassword );
		}

	}
}
