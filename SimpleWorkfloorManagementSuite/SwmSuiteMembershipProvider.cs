using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Collections.Specialized;
using System.Reflection;
using SwmSuite.Framework.Application;

namespace SimpleWorkfloorManagementSuite {

	public class SwmSuiteMembershipProvider : SqlMembershipProvider {

		public override void Initialize( string name , NameValueCollection config ) {
			base.Initialize( name , config );

			// Update the private connection string field in the base class.  
			string connectionString = SwmSuiteSettings.ConnectionSettings.ConnectionString;
			// Set private property of Membership provider.  
			FieldInfo connectionStringField = GetType().BaseType.GetField( "_sqlConnectionString" , BindingFlags.Instance | BindingFlags.NonPublic );
			connectionStringField.SetValue( this , connectionString );
		}

	}

}
