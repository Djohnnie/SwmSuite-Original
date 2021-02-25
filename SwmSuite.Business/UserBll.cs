using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {
	
	/// <summary>
	/// Business class encapsuling the ASP Membership methods.
	/// </summary>
	public class UserBll {

		#region -_ Private Members _-

		private IUserDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateUserDal();

		#endregion

		/// <summary>
		/// Authenticates a user by given username and password.
		/// </summary>
		/// <param name="userName">The username of the user to authenticate.</param>
		/// <param name="password">The password to authenticate the user with.</param>
		/// <returns>True if authenticated, false otherwise.</returns>
		public bool AuthenticateUser( String userName , String password ) {
			return dal.AuthenticateUser( userName , password );
		}

		/// <summary>
		/// Creates a new user.
		/// </summary>
		/// <param name="userName">Name of the user to create.</param>
		/// <param name="password">The password of the user to create.</param>
		/// <param name="email">The email of the user to create.</param>
		/// <returns>The userid (guid) of the created user if succeeded.</returns>
		public Guid CreateUser( String userName , String password , String email ) {
			return dal.CreateUser( userName , password , email );
		}

		/// <summary>
		/// Deletes a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to delete.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool DeleteUser( String userName ) {
			return dal.DeleteUser( userName );
		}

		/// <summary>
		/// Changes the password of a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to change the password for.</param>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="newPassword">The new password.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool ChangePassword( String userName , String oldPassword , String newPassword ) {
			return dal.ChangePassword( userName , oldPassword , newPassword );
		}

		public String GetUserNameFromSysId( Guid userSysId ) {
			return dal.GetUserNameFromSysId( userSysId );
		}

	}
}
