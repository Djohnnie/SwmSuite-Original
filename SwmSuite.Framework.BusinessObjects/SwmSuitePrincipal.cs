using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using SwmSuite.Data.BusinessObjects;
using System.Web;
using System.Threading;

namespace SwmSuite.Data.BusinessObjects {

	public class SwmSuitePrincipal : GenericPrincipal {

		#region -_ Private Members _-

		private static bool threadPolicySet;

		#endregion

		#region -_ Public Properties _-

		public static Employee CurrentEmployee { get; set; }

		public static EmployeeGroup CurrentEmployeeGroup { get; set; }

		public static EmployeeSettings Settings { get; set; }

		#endregion

		#region -_ Construction _-

		public SwmSuitePrincipal( IIdentity user , string[] roles )
			: base( user , roles ) {
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Request if the current client is a Windows Form application.
		/// </summary>
		/// <returns>True if the current application is a Windows Form application.</returns>
		static bool IsWinApp() {
			return HttpContext.Current == null;
		}

		/// <summary>
		/// Factory method to create a GeraccPrincipal object and attach it to the current and all future threads.
		/// </summary>
		/// <param name="user">The user identity.</param>
		/// <param name="roles">An array with the roles the user forfills.</param>
		/// <param name="settings">A GeraccSettings object that holds application wide settings.</param>
		public static void Attach( IIdentity user , string[] roles ) {
			IPrincipal customPrincipal = new SwmSuitePrincipal( user , roles );
			AppDomain currentDomain = AppDomain.CurrentDomain;

			if( IsWinApp() ) {
				Thread.CurrentPrincipal = customPrincipal;
			} else {
				HttpContext.Current.User = customPrincipal;
			}

			if( threadPolicySet == false ) {
				currentDomain.SetThreadPrincipal( customPrincipal );
				threadPolicySet = true;
			}
		}

		/// <summary>
		/// Anonymous principal to avoid problems but keep security
		/// </summary>
		public static void AttachAnonymousPrincipal() {
			SwmSuitePrincipal.Attach( new GenericIdentity( "Anonymous" , "Anonymous" ) , new string[] { } );
		}

		/// <summary>
		/// Gets the user id.
		/// </summary>
		/// <returns></returns>
		public static Guid GetUserId() {
			if( SwmSuitePrincipal.CurrentEmployee != null ) {
				return SwmSuitePrincipal.CurrentEmployee.UserSysId;
			} else {
				return Guid.Empty;
			}
		}

		#endregion

	}

}
