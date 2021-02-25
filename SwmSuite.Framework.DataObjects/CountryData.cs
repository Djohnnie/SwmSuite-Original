using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class CountryData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the street address for this address.
		/// </summary>
		public String CountryName { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public CountryData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="country"></param>
		public CountryData( string country ) {
			this.RowVersion = 0;
			this.CountryName = country;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this address to its string representation.
		/// </summary>
		/// <returns>The message for this alert.</returns>
		public override string ToString() {
			return this.CountryName;
		}

		#endregion

	}

}
