using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class TaskRunDataCollection : DataObjectCollectionBase<TaskRunData> {

		/// <summary>
		/// Get a collection for a single taskRun.
		/// </summary>
		/// <param name="taskRun">The taskRun to store into the collection.</param>
		/// <returns>A new TaskRunCollection containing the given taskRun.</returns>
		public static TaskRunDataCollection FromSingleTaskRun( TaskRunData taskRun ) {
			TaskRunDataCollection taskRuns = new TaskRunDataCollection();
			taskRuns.Add( taskRun );
			return taskRuns;
		}

		/// <summary>
		/// Deserializes the XML representation of an taskruncollection to a new taskruncollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an taskruncollection.</param>
		/// <returns>A new TaskRunCollection deserialized from the given XML string.</returns>
		public static TaskRunDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TaskRunDataCollection ) );
			TaskRunDataCollection toReturn = (TaskRunDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
