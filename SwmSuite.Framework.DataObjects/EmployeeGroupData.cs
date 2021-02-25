/***********
 * EmployeeGroup.cs
 * 
 * 08/08/2008 - Created
 * 
 */

using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class EmployeeGroupData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the name for this employeegroup.
		/// </summary>
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the description for this employeegroup.
		/// </summary>
		public String Description { get; set; }
		
		/// <summary>
		/// Gets or sets the visibility for this employeegroup.
		/// </summary>
		public bool Visible { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public EmployeeGroupData() {
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="name">The name for the new employeegroup.</param>
		/// <param name="description">The description for the new employeegroup.</param>
		/// <param name="visibility">The visibility for the new employeegroup.</param>
		public EmployeeGroupData( string name , string description , bool visibility ) {
			this.Name = name;
			this.Description = description;
			this.Visible = visibility;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this employeegroup to its string representation.
		/// </summary>
		/// <returns>The name of this employeegroup.</returns>
		public override string ToString( ) {
			return this.Name;
		}

		#endregion

	}

}