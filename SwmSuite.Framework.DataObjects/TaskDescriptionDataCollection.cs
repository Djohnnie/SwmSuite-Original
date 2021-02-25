using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class TaskDescriptionDataCollection : DataObjectCollectionBase<TaskDescriptionData> {

		/// <summary>
		/// Get a collection for a single taskDescription.
		/// </summary>
		/// <param name="taskDescription">The taskDescription to store into the collection.</param>
		/// <returns>A new TaskDescriptionCollection containing the given taskDescription.</returns>
		public static TaskDescriptionDataCollection FromSingleTaskDescription( TaskDescriptionData taskDescription ) {
			TaskDescriptionDataCollection taskDescriptions = new TaskDescriptionDataCollection();
			taskDescriptions.Add( taskDescription );
			return taskDescriptions;
		}

		/// <summary>
		/// Deserializes the XML representation of an taskdescriptioncollection to a new taskdescriptioncollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an taskdescriptioncollection.</param>
		/// <returns>A new TaskDescriptionCollection deserialized from the given XML string.</returns>
		public static TaskDescriptionDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TaskDescriptionDataCollection ) );
			TaskDescriptionDataCollection toReturn = (TaskDescriptionDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
