using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.BusinessObjects {
	
	/// <summary>
  /// Class defining an employee.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class OvertimeEntry : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public String Description { get; set; }

		/// <summary>
		/// Gets or sets the start date and time.
		/// </summary>
		/// <value>The start date and time.</value>
		public DateTime DateTimeStart { get; set; }

		/// <summary>
		/// Gets or sets the end date and time.
		/// </summary>
		/// <value>The end date and time.</value>
		public DateTime DateTimeEnd { get; set; }

		/// <summary>
		/// Gets or sets the employee.
		/// </summary>
		/// <value>The employee.</value>
		public Employee Employee { get; set; }

		/// <summary>
		/// Gets or sets the overtime status.
		/// </summary>
		/// <value>The overtime status.</value>
		public OvertimeStatus OvertimeStatus { get; set; }

		/// <summary>
		/// Gets or sets the commissioner employee.
		/// </summary>
		/// <value>The commissioner employee.</value>
		public Employee Commissioner { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="OvertimeEntry"/> class.
		/// </summary>
		public OvertimeEntry() {

		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this image to its string representation.
		/// </summary>
		/// <returns>The description of this overtime entry.</returns>
		public override string ToString() {
			return this.Description;
		}

		#endregion

	}

}
