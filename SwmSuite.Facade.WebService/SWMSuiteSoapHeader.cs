using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace SwmSuite.Facade.WebService {

	[XmlRoot( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class SwmSuiteSoapHeader : SoapHeader { 

		public string UserName {get;set;}

		public string Password { get; set; }

		public int Employee { get; set; }

	}
}
