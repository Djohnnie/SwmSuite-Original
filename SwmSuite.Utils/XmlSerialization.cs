using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SwmSuite.Utils {
	
	/// <summary>
	/// Class that holds static methods to do XmlSerialization operations.
	/// </summary>
	public static class XmlSerialization {

		/// <summary>
		/// Convert an object from its type returned by the webservice to its original type via XmlSerialization.
		/// </summary>
		/// <param name="source">The object to convert.</param>
		/// <param name="sourceType">The type to convert from.</param>
		/// <param name="destinationType">The type to convert to.</param>
		/// <returns>The source object converted to the destination type.</returns>
		public static Object ConvertObject( Object source , Type sourceType , Type destinationType ) {			
			// Create the XmlSerializer.
			XmlSerializer xmlSerializer = new XmlSerializer( sourceType );
			// Create a memoryStream to hold the xml string.
			MemoryStream memoryStream = new MemoryStream();
			// Serialize the source object to an xml string.
			xmlSerializer.Serialize( memoryStream , source );
			// Rewind the stream.
			memoryStream.Seek( 0 , SeekOrigin.Begin );
			// Create the XmlDeserializer.
			XmlSerializer xmlDeserializer = new XmlSerializer( destinationType );
			// Deserialize the xml string to an object of the destionation type.
			return xmlDeserializer.Deserialize( memoryStream );
		}

	}

}
