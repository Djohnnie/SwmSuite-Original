using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining a country.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class Country : BusinessObjectBase {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the country representing this avatar.
		/// </summary>
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the zip codes.
		/// </summary>
		/// <value>The zip codes.</value>
		public ZipCodeCollection ZipCodes { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Country() {
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="picture">The picture representing this avatar.</param>
		public Country( String name ){
			this.Name = name;
		}

		#endregion

		#region -_ Overrides _-

		public override string ToString() {
			return this.Name;
		}

		#endregion

	}

}
