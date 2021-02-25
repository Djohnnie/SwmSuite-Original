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
	public class EmployeeGroupAlertData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id for the employeegroup this employeegroupalert applies to.
		/// </summary>
		public int EmployeeGroupSysId { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the alert this employeegroupalert applies to.
		/// </summary>
		public int AlertSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public EmployeeGroupAlertData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id for the employeegroup this employeegroupalert applies to.</param>
		/// <param name="alertSysId">The internal id for the alert this employeegroupalert applies to.</param>
		public EmployeeGroupAlertData( int employeeGroupSysId , int alertSysId ) {
			this.EmployeeGroupSysId = employeeGroupSysId;
			this.AlertSysId = alertSysId;
		}

		#endregion

	}

}
