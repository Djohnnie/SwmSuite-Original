using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class MessageData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id for the employee this message is sent by.
		/// </summary>
		public int FromEmployeeSysId { get; set; }

		/// <summary>
		/// Gets or sets the date this message has been sent.
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the subject for this message.
		/// </summary>
		public string Subject { get; set; }

		/// <summary>
		/// Gets or sets the content for this message.
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// Gets or sets the priority for this message.
		/// </summary>
		public MessagePriority Priority { get; set; }

		/// <summary>
		/// Gets or sets the visibility for this message.
		/// </summary>
		public bool Visible { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MessageData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="employeeSysId">GThe internal id for the employee this alert is intended for. Use null if this message is intended for everyone.</param>
		/// <param name="enabled">The enabled state for this alert.</param>
		/// <param name="message">The message for this alert.</param>
		public MessageData( int fromSysId , DateTime date , string subject , string content , MessagePriority priority , bool visible ) {
			this.RowVersion = 0;
			this.FromEmployeeSysId = fromSysId;
			this.Date = date;
			this.Subject = subject;
			this.Content = content;
			this.Priority = priority;
			this.Visible = visible;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this message to its string representation.
		/// </summary>
		/// <returns>The subject for this message.</returns>
		public override string ToString( ) {
			return this.Subject;
		}

		#endregion

	}
	
}
