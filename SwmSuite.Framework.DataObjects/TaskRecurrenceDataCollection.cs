using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class TaskRecurrenceDataCollection : DataObjectCollectionBase<TaskRecurrenceData> {

		/// <summary>
		/// Get a collection for a single TaskRecurrence.
		/// </summary>
		/// <param name="taskRecurrence">The TaskRecurrence to store into the collection.</param>
		/// <returns>A new MessageCollection containing the given TaskRecurrence.</returns>
		public static TaskRecurrenceDataCollection FromSingleTaskRecurrence( TaskRecurrenceData taskRecurrence ) {
			TaskRecurrenceDataCollection taskRecurrences = new TaskRecurrenceDataCollection();
			taskRecurrences.Add( taskRecurrence );
			return taskRecurrences;
		}

		/// <summary>
		/// Deserializes the XML representation of an taskrecurrencecollection to a new taskrecurrencecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an taskrecurrencecollection.</param>
		/// <returns>A new TaskRecurrenceCollection deserialized from the given XML string.</returns>
		public static TaskRecurrenceDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TaskRecurrenceDataCollection ) );
			TaskRecurrenceDataCollection toReturn = (TaskRecurrenceDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
