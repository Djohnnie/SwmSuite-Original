using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining a collection of zipcodes.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class ZipCodeCollection : BusinessObjectCollectionBase<ZipCode> {

		/// <summary>
		/// Get a collection for a single zipcode.
		/// </summary>
		/// <param name="zipCode">The zipCode to store into the collection.</param>
		/// <returns>A new ZipCodeCollection containing the given zipCode.</returns>
		public static ZipCodeCollection FromSingleZipCode( ZipCode zipCode ) {
			ZipCodeCollection zipCodes = new ZipCodeCollection();
			zipCodes.Add( zipCode );
			return zipCodes;
		}

		/// <summary>
		/// Deserializes the XML representation of an ZipCodeCollection to a new ZipCodeCollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an ZipCodeCollection.</param>
		/// <returns>A new ZipCodeCollection deserialized from the given XML string.</returns>
		public static ZipCodeCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( ZipCodeCollection ) );
			ZipCodeCollection toReturn = (ZipCodeCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
