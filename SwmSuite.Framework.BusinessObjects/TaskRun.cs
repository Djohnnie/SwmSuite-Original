using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a taskrun.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class TaskRun : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the datetime finished.
		/// </summary>
		/// <value>The finished.</value>
		public DateTime Finished { get; set; }

		/// <summary>
		/// Gets or sets the remarks.
		/// </summary>
		/// <value>The remarks.</value>
		public String Remarks { get; set; }

		/// <summary>
		/// Gets or sets the mode.
		/// </summary>
		/// <value>The mode.</value>
		public TaskRunMode Mode { get; set; }

		/// <summary>
		/// Gets or sets the task.
		/// </summary>
		/// <value>The task.</value>
		public Task Task { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TaskRun"/> class.
		/// </summary>
		public TaskRun() {
		}

		#endregion

	}

}
