using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class LoginLogData : DataObjectBase {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the date time.
		/// </summary>
		/// <value>The date time.</value>
		public DateTime DateTime { get; set; }

		/// <summary>
		/// Gets or sets the internal id of the meployee.
		/// </summary>
		/// <value>The internal id of the meployee.</value>
		public int EmployeeSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionLogData"/> class.
		/// </summary>
		public LoginLogData() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionLogData"/> class.
		/// </summary>
		/// <param name="dateTime">The date time.</param>
		/// <param name="employeeSysId">The client.</param>
		public LoginLogData( DateTime dateTime , int employeeSysId ) {
			this.DateTime = dateTime;
			this.EmployeeSysId = employeeSysId;
		}

		#endregion

	}
}
