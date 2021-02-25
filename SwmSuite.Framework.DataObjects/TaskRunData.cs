using System;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.DataObjects {
	
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class TaskRunData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id of the taskdescription this taskrun applies to.
		/// </summary>
		public int TaskSysId { get; set; }

		/// <summary>
		/// Gets or sets the finished date and time for this taskrun.
		/// </summary>
		public DateTime DateTimeFinished { get; set; }

		/// <summary>
		/// Gets or sets the remarks for this taskrun.
		/// </summary>
		public string Remarks { get; set; }

		/// <summary>
		/// Gets or sets the mode for this taskrun.
		/// </summary>
		public TaskRunMode TaskRunMode { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TaskRunData() {

		}

		/// <summary>
		/// Custom construcor.
		/// </summary>
		/// <param name="taskDescriptionSysId">The internal id of the taskdescription this taskrun applies to.</param>
		/// <param name="finished">The finished date and time for this taskrun.</param>
		/// <param name="remarks">The remarks for this taskrun.</param>
		/// <param name="taskRunMode">The mode for this taskrun.</param>
		public TaskRunData( int taskDescriptionSysId , DateTime finished , string remarks , TaskRunMode taskRunMode ) {
			this.TaskSysId = taskDescriptionSysId;
			this.DateTimeFinished = finished;
			this.Remarks = remarks;
			this.TaskRunMode = taskRunMode;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this taskrun to its string representation.
		/// </summary>
		/// <returns>The remarks of this taskrun.</returns>
		public override string ToString( ) {
			return this.Remarks;
		}

		#endregion

	}

}
