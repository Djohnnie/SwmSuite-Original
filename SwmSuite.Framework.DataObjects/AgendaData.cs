using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class AgendaData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the title for this agenda.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the description for this agenda.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the internal id of the employee owning this agenda.
		/// </summary>
		public int OwnerEmployeeSysId { get; set; }

		/// <summary>
		/// Gets or sets the visibility for this agenda.
		/// </summary>
		public AppointmentVisibility Visibility { get; set; }

		/// <summary>
		/// Gets or sets the color1 for this agenda.
		/// </summary>
		public int Color1 { get; set; }

		/// <summary>
		/// Gets or sets the color1 for this agenda.
		/// </summary>
		public int Color2 { get; set; }

		/// <summary>
		/// Gets or sets the color1 for this agenda.
		/// </summary>
		public int Color3 { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AgendaData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="title">The title for this agenda.</param>
		/// <param name="description">The description for this agenda.</param>
		/// <param name="ownerSysId">The internal id of the employee owning this agenda.</param>
		/// <param name="visibility">The visibility for this agenda.</param>
		/// <param name="color">The color for this agenda.</param>
		public AgendaData( string title , string description , int ownerSysId , AppointmentVisibility visibility , int color ) {
			this.Title = title;
			this.Description = description;
			this.OwnerEmployeeSysId = ownerSysId;
			this.Visibility = visibility;
			this.Color1 = color;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this agenda to its string representation.
		/// </summary>
		/// <returns>The title of this agenda.</returns>
		public override string ToString( ) {
			return this.Title;
		}

		#endregion

	}

}
