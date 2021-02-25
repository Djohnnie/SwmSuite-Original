using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {
	
	public class CountryDataCollection : DataObjectCollectionBase<CountryData> {

		/// <summary>
		/// Get a collection for a single country.
		/// </summary>
		/// <param name="alert">The country to store into the collection.</param>
		/// <returns>A new CountryCollection containing the given alert.</returns>
		public static CountryDataCollection FromSingleCountry( CountryData country ) {
			CountryDataCollection countries = new CountryDataCollection();
			countries.Add( country );
			return countries;
		}

		/// <summary>
		/// Deserializes the XML representation of an countrycollection to a new countrycollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an countrycollection.</param>
		/// <returns>A new CountryCollection deserialized from the given XML string.</returns>
		public static CountryDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( CountryDataCollection ) );
			CountryDataCollection toReturn = (CountryDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}
}
