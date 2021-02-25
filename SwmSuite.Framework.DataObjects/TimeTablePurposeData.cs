using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class TimeTablePurposeData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id of the employeegroup this timetablepurpose applies to.
		/// </summary>
		/// <value>The internal id of the employeegroup this timetablepurpose applies to.</value>
		public int EmployeeGroupSysId { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the color of the leganda.
		/// </summary>
		/// <value>The color of the leganda.</value>
		public int LegendaColor1 { get; set; }

		/// <summary>
		/// Gets or sets the color of the leganda.
		/// </summary>
		/// <value>The color of the leganda.</value>
		public int LegendaColor2 { get; set; }

		/// <summary>
		/// Gets or sets the color of the leganda.
		/// </summary>
		/// <value>The color of the leganda.</value>
		public int LegendaColor3 { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTablePurposeData"/> class.
		/// </summary>
		public TimeTablePurposeData() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTablePurposeData"/> class.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup this timetablepurpose applies to.</param>
		/// <param name="description">The description.</param>
		/// <param name="legandaColor">Color of the leganda.</param>
		public TimeTablePurposeData( int employeeGroupSysId , string description , int legandaColor){
			this.EmployeeGroupSysId = employeeGroupSysId;
			this.Description = description;
			this.LegendaColor1 = LegendaColor1;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this agenda to its string representation.
		/// </summary>
		/// <returns>The title of this agenda.</returns>
		public override string ToString( ) {
			return this.Description;
		}

		#endregion

	}

}
