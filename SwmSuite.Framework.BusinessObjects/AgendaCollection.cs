using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.BusinessObjects;
using System.IO;
using System.Xml;

namespace SwmSuite.Data.BusinessObjects {

	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class AgendaCollection : BusinessObjectCollectionBase<Agenda> {

		/// <summary>
		/// Get a collection for a single agenda.
		/// </summary>
		/// <param name="agenda">The agenda to store into the collection.</param>
		/// <returns>A new AgendaCollection containing the given agenda.</returns>
		public static AgendaCollection FromSingleAgenda( Agenda agenda ) {
			AgendaCollection agendas = new AgendaCollection();
			agendas.Add( agenda );
			return agendas;
		}

		/// <summary>
		/// Deserializes the XML representation of an agendacollection to a new agendacollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an agendacollection.</param>
		/// <returns>A new AgendaCollection deserialized from the given XML string.</returns>
		public static AgendaCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( AgendaCollection ) );
			AgendaCollection toReturn = (AgendaCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

		/// <summary>
		/// Determines whether this collection contains a guest agenda.
		/// </summary>
		/// <returns>True if this collection contains a guest agenda. False otherwise.</returns>
		public bool ContainsGuestAgenda() {
			bool result = false;
			foreach( Agenda agenda in this ) {
				if( agenda.Special == SpecialAgenda.GuestAgenda ) {
					result = true;
				}
			}
			return result;
		}

		/// <summary>
		/// Determines whether this collection contains a timetable agenda.
		/// </summary>
		/// <returns>True if this collection contains a timetable agenda. False otherwise.</returns>
		public bool ContainsTimeTableAgenda() {
			bool result = false;
			foreach( Agenda agenda in this ) {
				if( agenda.Special == SpecialAgenda.TimeTableAgenda ) {
					result = true;
				}
			}
			return result;
		}

	}

}
