using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a timetable template.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class TimeTableTemplate : BusinessObjectBase {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public String Description { get; set; }

		/// <summary>
		/// Gets or sets the employee group.
		/// </summary>
		/// <value>The employee group.</value>
		public EmployeeGroup EmployeeGroup { get; set; }

		/// <summary>
		/// Gets or sets the time table template entries.
		/// </summary>
		/// <value>The time table template entries.</value>
		public TimeTableTemplateEntryCollection TimeTableTemplateEntries { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableTemplate"/> class.
		/// </summary>
		public TimeTableTemplate() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableTemplate"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="description">The description.</param>
		/// <param name="employeeGroup">The employee group.</param>
		/// <param name="timeTableTemplateEntries">The time table template entries.</param>
		public TimeTableTemplate( String name , String description , EmployeeGroup employeeGroup , TimeTableTemplateEntryCollection timeTableTemplateEntries ) {
			this.Name = name;
			this.Description = description;
			this.EmployeeGroup = employeeGroup;
			this.TimeTableTemplateEntries = timeTableTemplateEntries;
		}

		#endregion

		#region -_ Overrides _-

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString() {
			return this.Name;
		}

		#endregion

	}

}
