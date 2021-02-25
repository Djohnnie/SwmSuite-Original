using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Framework;
using SwmSuite.Proxy.Interface;
using System.Web.Security;
using System.Threading;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard {

	public partial class SwmSuiteAdminWizardContent5 : UserControl {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		public Employee Administrator { get; set; }
		public EmployeeGroup AdministratorGroup { get; set; }

		#endregion

		#region -_ Events _-

		public event EventHandler<EventArgs> Completed;

		#endregion

		#region -_ Construction _-

		public SwmSuiteAdminWizardContent5() {
			InitializeComponent();
		}

		#endregion

		#region -_ Public Methods _-

		public void Go() {
			backgroundWorker.RunWorkerAsync( this.Administrator );
		}

		#endregion

		private void backgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			//
			// Delete all previous users.
			//
			//MembershipUserCollection memberships = Membership.GetAllUsers();
			//foreach( MembershipUser user in memberships ) {
			//    Membership.DeleteUser( user.UserName );
			//}

			this.AdministratorGroup =
				SwmSuiteFacade.EmployeeFacade.CreateEmployeeGroup( this.AdministratorGroup );
			SwmSuiteFacade.EmployeeFacade.CreateEmployee( this.Administrator , this.AdministratorGroup );

			////
			//// Create Membership user.
			////
			//MembershipCreateStatus status;
			//MembershipUser newUser = Membership.CreateUser( this.Administrator.UserName , this.Administrator.Password.ToString() , "a@a.a" , "a" , "a" , true , null , out status );
			//switch( status ) {
			//    case MembershipCreateStatus.Success: {
			//        //
			//        // Create the employeegroup.
			//        //
			//        this.AdministratorGroup = 
			//            _employeeGroupFacade.CreateEmployeeGroup( this.AdministratorGroup );

			//        //
			//        // Create the corresponding employee.
			//        //
			//        this.Administrator.UserSysId = (Guid)newUser.ProviderUserKey;
			//        _employeeFacade.CreateEmployee( this.Administrator , this.AdministratorGroup );

			//        e.Result = null;
			//        break;
			//    }
			//    default: {
			//        e.Result = status;
			//        break;
			//    }
			//}	
		}

		private void backgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			if( this.Completed != null ) {
				if( e.Result == null ) {
					Completed( this , EventArgs.Empty );
				} else {
					MessageBox.Show( ( (MembershipCreateStatus)e.Result ).ToString() );
					//switch( (MembershipCreateStatus)e.Result ) {
					//    case MembershipCreateStatus.DuplicateUserName:

					//}
				}
			}
		}
	}
}
