using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class TaskRecurrenceData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id for the taskdescription.
		/// </summary>
		public int TaskDescriptionSysId { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the recurrence.
		/// </summary>
		public int RecurrenceSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TaskRecurrenceData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="taskDescriptionSysId">The internal id for the taskdescription.</param>
		/// <param name="recurrenceSysId">The internal id for the recurrence.</param>
		public TaskRecurrenceData( int taskDescriptionSysId , int recurrenceSysId ) {
			this.TaskDescriptionSysId = taskDescriptionSysId;
			this.RecurrenceSysId = recurrenceSysId;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this taskrecurrence to its string representation.
		/// </summary>
		/// <returns>An empty string.</returns>
		public override string ToString() {
			return String.Empty;
		}

		#endregion

	}
}
