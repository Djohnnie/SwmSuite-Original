using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class TaskData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id of the employee this task applies to.
		/// </summary>
		public int EmployeeSysId { get; set; }

		/// <summary>
		/// Gets or sets the internal id of the taskdescription describing this task.
		/// </summary>
		public int TaskDescriptionSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TaskData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee this task applies to.</param>
		/// <param name="taskDescriptionSysId">The internal id of the taskdescription describing this task.</param>
		public TaskData( int employeeSysId , int taskDescriptionSysId ) {
			this.EmployeeSysId = employeeSysId;
			this.TaskDescriptionSysId = taskDescriptionSysId;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this task to its string representation.
		/// </summary>
		/// <returns>An empty string.</returns>
		public override string ToString() {
			return String.Empty;
		}

		#endregion

	}

}
