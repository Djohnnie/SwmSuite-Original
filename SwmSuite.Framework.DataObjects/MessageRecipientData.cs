using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class MessageRecipientData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id for the message.
		/// </summary>
		public int MessageSysId { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the employee the message is sent to.
		/// </summary>
		public int EmployeeSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MessageRecipientData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="messageSysId">The internal id for the message.</param>
		/// <param name="EmployeeSysId">The internal id for the employee the message is sent to.</param>
		public MessageRecipientData( int messageSysId , int employeeSysId ) {
			this.MessageSysId = messageSysId;
			this.EmployeeSysId = employeeSysId;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this messagefolder to its string representation.
		/// </summary>
		/// <returns>The name of this messagefolder.</returns>
		public override string ToString() {
			return "";
		}

		#endregion

	}

}
