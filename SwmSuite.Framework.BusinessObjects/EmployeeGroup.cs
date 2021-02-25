using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining an employeegroup.
  /// </summary>
	[Serializable]
	[XmlType( Namespace="SwmSuite_v1" )]
	public class EmployeeGroup : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the name for this employeegroup.
		/// </summary>
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the description for this employeegroup.
		/// </summary>
		public String Description { get; set; }

		/// <summary>
		/// Gets or sets a collection of employees.
		/// </summary>
		public EmployeeCollection Employees { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public EmployeeGroup() {
		}

		#endregion

	}

}
