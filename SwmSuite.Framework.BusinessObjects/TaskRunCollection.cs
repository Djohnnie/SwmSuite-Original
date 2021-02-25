using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

	public class TaskRunCollection : BusinessObjectCollectionBase<TaskRun> {

		/// <summary>
		/// Get a collection for a single taskRun.
		/// </summary>
		/// <param name="taskRun">The taskRun to store into the collection.</param>
		/// <returns>A new TaskRunCollection containing the given taskRun.</returns>
		public static TaskRunCollection FromSingleTaskRun( TaskRun taskRun ) {
			TaskRunCollection taskRuns = new TaskRunCollection();
			taskRuns.Add( taskRun );
			return taskRuns;
		}

		/// <summary>
		/// Deserializes the XML representation of an taskRuncollection to a new taskRuncollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an taskRuncollection.</param>
		/// <returns>A new TaskRunCollection deserialized from the given XML string.</returns>
		public static TaskRunCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TaskRunCollection ) );
			TaskRunCollection toReturn = (TaskRunCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
