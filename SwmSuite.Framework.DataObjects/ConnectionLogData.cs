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
	public class ConnectionLogData : DataObjectBase {

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
		/// Initializes a new instance of the <see cref="ConnectionLogData"/> class.
		/// </summary>
		public ConnectionLogData() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionLogData"/> class.
		/// </summary>
		/// <param name="dateTime">The date time.</param>
		/// <param name="client">The client.</param>
		public ConnectionLogData( DateTime dateTime , String client ) {
			this.DateTime = dateTime;
			this.Client = client;
		}

		#endregion

	}

}
