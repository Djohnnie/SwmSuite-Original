using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining a zipcode.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class ZipCode : BusinessObjectBase {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the code representing this zipcode.
		/// </summary>
		public String Code { get; set; }

		/// <summary>
		/// Gets or sets the city representing this zipcode.
		/// </summary>
		public String City { get; set; }

		/// <summary>
		/// Gets or sets the country this zipcode is a part of.
		/// </summary>
		public String Country { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ZipCode() {
		}

		/// <summary>
		/// Custom construction.
		/// </summary>
		/// <param name="code">The code representing this zipcode.</param>
		/// <param name="city">The city representing this zipcode.</param>
		public ZipCode( String code , String city ) {
			this.Code = code;
			this.City = city;
		}

		/// <summary>
		/// Custom construction.
		/// </summary>
		/// <param name="code">The code representing this zipcode.</param>
		/// <param name="city">The city representing this zipcode.</param>
		/// <param name="country">The country this zipcode is a part of.</param>
		public ZipCode( String code , String city , String country )
			: this( code , city ) {
			this.Country = country;
		}

		#endregion

	}

}