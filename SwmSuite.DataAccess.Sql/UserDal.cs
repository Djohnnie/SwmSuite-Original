using System;
using System.Collections.Generic;

using System.Text;
using System.Web.Security;
using SwmSuite.DataAccess.Interface;
using System.Configuration;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.DataAccess.Sql {
	
	public class UserDal : IUserDal {

		/// <summary>
		/// Authenticates a user by given username and password.
		/// </summary>
		/// <param name="userName">The username of the user to authenticate.</param>
		/// <param name="password">The password to authenticate the user with.</param>
		/// <returns>True if authenticated, false otherwise.</returns>
		bool IUserDal.AuthenticateUser( String userName , String password ) {
			bool authenticated =  Membership.ValidateUser( userName , password );
			if( !authenticated ) {
				MembershipUser user = Membership.GetUser( userName );
				if( user != null && user.IsLockedOut ) {
					throw new SwmSuiteException( null , SwmSuiteError.UserLockedOutError , "De gebruiker waarmee u wenst aan te melden heeft een slot gekregen omdat er teveel foute wachtwoorden werden ingegeven. Vraag uw beheerder om het slot op te heffen." );
				}
			}
			return authenticated;
		}

		/// <summary>
		/// Creates a new user.
		/// </summary>
		/// <param name="userName">Name of the user to create.</param>
		/// <param name="password">The password of the user to create.</param>
		/// <param name="email">The email of the user to create.</param>
		/// <returns>The userid (guid) of the created user if succeeded.</returns>
		Guid IUserDal.CreateUser( String userName , String password , String email ) {
			MembershipCreateStatus membershipStatus;
			MembershipUser membershipUser =
				Membership.CreateUser( userName , password , email , "-" , "-" , true , out membershipStatus );
			Guid membershipUserId;
			switch( membershipStatus ) {
				case MembershipCreateStatus.Success: {
					membershipUserId = (Guid)membershipUser.ProviderUserKey;
					break;
				}
				default: {
					membershipUserId = Guid.Empty;
					break;
				}
			}
			return membershipUserId;
		}

		/// <summary>
		/// Deletes a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to delete.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		bool IUserDal.DeleteUser( String userName ) {
			return Membership.DeleteUser( userName , true );
		}

		/// <summary>
		/// Changes the password of a user by given username.
		/// </summary>
		/// <param name="userName">The username of the user to change the password for.</param>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="newPassword">The new password.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		bool IUserDal.ChangePassword( String userName , String oldPassword , String newPassword ) {
			//Membership.UpdateUser(
			MembershipUser test =
				Membership.GetUser( userName );
			return test.ChangePassword( oldPassword , newPassword );
		}

		/// <summary>
		/// Get the username of the user by given userId.
		/// </summary>
		/// <param name="userSysId">The unique user identifier from the membership data source for the user.</param>
		/// <returns>The username.</returns>
		String IUserDal.GetUserNameFromSysId( Guid userSysId ) {
			String userNameToReturn = String.Empty;
			MembershipUser membershipUser =
				Membership.GetUser( userSysId );
			if( membershipUser != null ) {
				userNameToReturn = membershipUser.UserName;
			}
			return userNameToReturn;
		}

	}

}
