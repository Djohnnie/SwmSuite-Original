using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining an employee.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class ConnectionLog : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the date time.
		/// </summary>
		/// <value>The date time.</value>
		public DateTime DateTime { get; set; }

		/// <summary>
		/// Gets or sets the client.
		/// </summary>
		/// <value>The client.</value>
		public String Client { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ConnectionLog() {
		}

		#endregion

	}

}