using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {
	
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class TaskDescriptionData : DataObjectBase {

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
		/// Gets or sets the internal id of the employee that initiated this taskdescription.
		/// </summary>
		public int CommissionerEmployeeSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TaskDescriptionData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="title">The title for this agenda.</param>
		/// <param name="description">The description for this agenda.</param>
		/// <param name="ownerSysId">The internal id of the employee owning this agenda.</param>
		public TaskDescriptionData( string title , DateTime creationDate , string description , DateTime? deadline , int commissionerSysId ) {
			this.Title = title;
			this.CreationDate = creationDate;
			this.Description = description;
			this.Deadline = deadline;
			this.CommissionerEmployeeSysId = commissionerSysId;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this taskdescription to its string representation.
		/// </summary>
		/// <returns>The title of this taskdescription.</returns>
		public override string ToString( ) {
			return this.Title;
		}

		#endregion

	}

}
