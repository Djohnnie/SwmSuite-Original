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
	public class ZipCodeData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the zipcode.
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// Gets or sets the zipcode.
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the country this zipcode applies to.
		/// </summary>
		public int CountrySysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ZipCodeData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="code"></param>
		/// <param name="city"></param>
		/// <param name="countrySysId"></param>
		public ZipCodeData( string code , string city , int countrySysId ) {
			this.Code = code;
			this.City = city;
			this.CountrySysId = countrySysId;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this zipcode to its string representation.
		/// </summary>
		/// <returns>A concatenation of the zipcode and city.</returns>
		public override string ToString() {
			return this.Code + " " + this.City;
		}

		#endregion

	}

}
