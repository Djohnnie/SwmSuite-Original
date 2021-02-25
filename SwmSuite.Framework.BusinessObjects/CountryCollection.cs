using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining a collection of countries.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class CountryCollection : BusinessObjectCollectionBase<Country> {

		/// <summary>
		/// Get a collection for a single country.
		/// </summary>
		/// <param name="country">The country to store into the collection.</param>
		/// <returns>A new CountryCollection containing the given country.</returns>
		public static CountryCollection FromSingleCountry( Country country ) {
			CountryCollection countries = new CountryCollection();
			countries.Add( country );
			return countries;
		}

		/// <summary>
		/// Deserializes the XML representation of an countrycollection to a new countrycollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an countrycollection.</param>
		/// <returns>A new CountryCollection deserialized from the given XML string.</returns>
		public static CountryCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( CountryCollection ) );
			CountryCollection toReturn = (CountryCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
