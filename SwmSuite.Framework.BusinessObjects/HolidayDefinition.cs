using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a message.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class HolidayDefinition : BusinessObjectBase {

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

		/// <summary>
		/// Gets whether this holiday definition is a long vacation.
		/// </summary>
		public bool Vacation {
			get {
				return this.DateStart != this.DateEnd;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public HolidayDefinition() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="recurring"></param>
		/// <param name="start">The start date.</param>
		/// <param name="end">The end date.</param>
		public HolidayDefinition( String name , bool recurring , DateTime start , DateTime end ) {
			this.Name = name;
			this.RecurringHoliday = recurring;
			this.DateStart = start;
			this.DateEnd = end;
		}

		#endregion

	}

}
