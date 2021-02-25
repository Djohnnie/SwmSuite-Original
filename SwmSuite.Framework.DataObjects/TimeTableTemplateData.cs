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
	public class TimeTableTemplateData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the name for this timetable template.
		/// </summary>
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the description for this timetable template.
		/// </summary>
		public String Description { get; set; }

		/// <summary>
		/// Gets or sets the internal id of the employeegroup this timetable template applies to.
		/// </summary>
		public int EmployeeGroupSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TimeTableTemplateData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="name">The name for this timetable template.</param>
		/// <param name="description">The name for this timetable template.</param>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup this timetable template applies to.</param>
		public TimeTableTemplateData( String name , String description , int employeeGroupSysId ) {
			this.RowVersion = 0;
			this.Name = name;
			this.Description = description;
			this.EmployeeGroupSysId = employeeGroupSysId;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this address to its string representation.
		/// </summary>
		/// <returns>The message for this alert.</returns>
		public override string ToString() {
			return this.Name;
		}

		#endregion

	}

}
