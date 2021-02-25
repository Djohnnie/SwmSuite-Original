using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class HolidayDefinitionData : DataObjectBase {

		#region -_ Private Members _-



		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets if this holliday recurs every year.
		/// </summary>
		public bool RecurringHoliday { get; set; }

		/// <summary>
		/// Gets or sets the start date.
		/// </summary>
		public DateTime DateStart {get;set;}

		/// <summary>
		/// Gets or sets the end date.
		/// </summary>
		public DateTime DateEnd { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public HolidayDefinitionData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="recurring"></param>
		/// <param name="start">The start date.</param>
		/// <param name="end">The end date.</param>
		public HolidayDefinitionData( String name , bool recurring , DateTime start , DateTime end ) {
			this.Name = name;
			this.RecurringHoliday = recurring;
			this.DateStart = start;
			this.DateEnd = end;
		}

		#endregion

	}

}
