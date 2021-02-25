using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining a task.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class Task : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the title for this taskdescription.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the date of creation for this taskdescription.
		/// </summary>
		public DateTime CreationDate { get; set; }

		/// <summary>
		/// Gets or sets the description for this taskdescription.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the deadline for this taskdescription.
		/// </summary>
		public DateTime? Deadline { get; set; }

		/// <summary>
		/// Gets or sets the commisioner.
		/// </summary>
		public Employee Commissioner { get; set; }

		/// <summary>
		/// Gets or sets the employees.
		/// </summary>
		public EmployeeCollection Employees { get; set; }

		/// <summary>
		/// Gets or sets the employee.
		/// </summary>
		public Employee Employee { get; set; }

		/// <summary>
		/// Gets or sets the recurrence for this task.
		/// </summary>
		public Recurrence Recurrence { get; set; }

		/// <summary>
		/// Gets or sets the task run information.
		/// </summary>
		public TaskRun TaskRun { get; set; }



		/// <summary>
		/// Gets a value indicating whether this instance is pending.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is pending; otherwise, <c>false</c>.
		/// </value>
		public bool IsPending {
			get {
				return this.TaskRun == null && ( !this.Deadline.HasValue || this.Deadline.Value >= DateTime.Now );
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is over due.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is over due; otherwise, <c>false</c>.
		/// </value>
		public bool IsOverDue {
			get {
				return this.TaskRun == null && this.Deadline.HasValue && this.Deadline.Value < DateTime.Now;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is finished.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is finished; otherwise, <c>false</c>.
		/// </value>
		public bool IsFinished {
			get {
				return this.TaskRun != null && this.TaskRun.Mode == SwmSuite.Data.Common.TaskRunMode.TaskFinished;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is failed.
		/// </summary>
		/// <value><c>true</c> if this instance is failed; otherwise, <c>false</c>.</value>
		public bool IsFailed {
			get {
				return this.TaskRun != null && this.TaskRun.Mode == SwmSuite.Data.Common.TaskRunMode.TaskFailed;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="Task"/> class.
		/// </summary>
		public Task() {
		}

		#endregion

	}

}
