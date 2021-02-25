using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class ZipCodeDataCollection : DataObjectCollectionBase<ZipCodeData> {

		/// <summary>
		/// Get a collection for a single zipcode.
		/// </summary>
		/// <param name="alert">The zipcode to store into the collection.</param>
		/// <returns>A new ZipCodeCollection containing the given alert.</returns>
		public static ZipCodeDataCollection FromSingleZipCode( ZipCodeData zipcode ) {
			ZipCodeDataCollection zipcodes = new ZipCodeDataCollection();
			zipcodes.Add( zipcode );
			return zipcodes;
		}

		/// <summary>
		/// Deserializes the XML representation of an zipcodecollection to a new zipcodecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an zipcodecollection.</param>
		/// <returns>A new ZipCodeCollection deserialized from the given XML string.</returns>
		public static ZipCodeDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( ZipCodeDataCollection ) );
			ZipCodeDataCollection toReturn = (ZipCodeDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
