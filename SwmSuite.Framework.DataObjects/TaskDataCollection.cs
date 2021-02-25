using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class TaskDataCollection : DataObjectCollectionBase<TaskData> {

		/// <summary>
		/// Get a collection for a single task.
		/// </summary>
		/// <param name="task">The task to store into the collection.</param>
		/// <returns>A new TaskCollection containing the given task.</returns>
		public static TaskDataCollection FromSingleTask( TaskData task ) {
			TaskDataCollection tasks = new TaskDataCollection();
			tasks.Add( task );
			return tasks;
		}

		/// <summary>
		/// Deserializes the XML representation of an taskcollection to a new taskcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an taskcollection.</param>
		/// <returns>A new TaskCollection deserialized from the given XML string.</returns>
		public static TaskDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TaskDataCollection ) );
			TaskDataCollection toReturn = (TaskDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
