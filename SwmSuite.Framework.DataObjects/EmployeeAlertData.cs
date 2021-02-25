using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class EmployeeAlertData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id for the employee this employeealert applies to.
		/// </summary>
		public int EmployeeSysId { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the alert this employeealert applies to.
		/// </summary>
		public int AlertSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public EmployeeAlertData() {
			
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="employeeSysId">The internal id for the employee this employeealert applies to.</param>
		/// <param name="alertSysId">The internal id for the alert this employeealert applies to.</param>
		public EmployeeAlertData( int employeeSysId , int alertSysId ) {
			this.EmployeeSysId = employeeSysId;
			this.AlertSysId = alertSysId;
		}

		#endregion

	}

}
