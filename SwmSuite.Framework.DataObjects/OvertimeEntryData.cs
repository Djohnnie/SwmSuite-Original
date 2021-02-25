using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class OvertimeEntryData : DataObjectBase {

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
		/// Gets or sets the internal id of the employee.
		/// </summary>
		/// <value>The internal id of the employee.</value>
		public int EmployeeSysId { get; set; }

		/// <summary>
		/// Gets or sets the overtime status.
		/// </summary>
		/// <value>The overtime status.</value>
		public OvertimeStatus OvertimeStatus { get; set; }

		/// <summary>
		/// Gets or sets the internal id of the commissioner employee.
		/// </summary>
		/// <value>The internal id of the commissioner employee.</value>
		public int CommissionerSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="OvertimeEntryData"/> class.
		/// </summary>
		public OvertimeEntryData() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OvertimeEntryData"/> class.
		/// </summary>
		/// <param name="description">The description.</param>
		/// <param name="start">The start date and time.</param>
		/// <param name="end">The end date and time.</param>
		/// <param name="employeeSysId">The internal id of the employee.</param>
		/// <param name="status">The overtime status.</param>
		/// <param name="commissionerSysId">The internal id of the commissioner.</param>
		public OvertimeEntryData( String description , DateTime start , DateTime end , int employeeSysId , OvertimeStatus status , int commissionerSysId ) {
			this.Description = description;
			this.DateTimeStart = start;
			this.DateTimeEnd = end;
			this.EmployeeSysId = employeeSysId;
			this.OvertimeStatus = status;
			this.CommissionerSysId = commissionerSysId;
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
