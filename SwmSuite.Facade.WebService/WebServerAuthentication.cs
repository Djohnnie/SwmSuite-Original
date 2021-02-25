using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SwmSuite.Proxy.Interface;

using SwmSuite.Business;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Facade.WebService {

	public class WebServerAuthentication {

		public static void Authenticate( SwmSuiteSoapHeader soapHeader ) {
			if( soapHeader == null || !Membership.ValidateUser( soapHeader.UserName , soapHeader.Password ) ) {
				throw new SwmSuiteAuthenticationFailedException( soapHeader != null ? soapHeader.UserName : String.Empty );
			} else {
				EmployeeBll employeeBll = new EmployeeBll();
				SwmSuitePrincipal.CurrentEmployee = new EmployeeBll().GetEmployeeDetail( soapHeader.Employee );
				if( SwmSuitePrincipal.CurrentEmployee != null ) {
					SwmSuitePrincipal.CurrentEmployeeGroup = new EmployeeGroupBll().GetEmployeeGroupDetail( SwmSuitePrincipal.CurrentEmployee.SysId );
					SwmSuitePrincipal.Settings = new EmployeeSettingsBll().GetEmployeeSettingsForEmployee( SwmSuitePrincipal.CurrentEmployee );
				}
			}
		}

	}

}
