using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the AgendaService methods.
	/// </summary>
	public interface IAgendaDal {

		/// <summary>
		/// Get all agendas from the database.
		/// </summary>
		/// <returns>A AgendaCollection containing all agendas.</returns>
		AgendaDataCollection GetAgendaData();

		/// <summary>
		/// Get all agendas from the database for a specific employee.
		/// </summary>
		/// <returns>A AgendaCollection containing all requested agendas.</returns>
		AgendaDataCollection GetAgendaDataForEmployee( int employeeSysId );

		/// <summary>
		/// Get a single agenda from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the agenda to retrieve.</param>
		/// <returns>An AgendaCollection containing the requested agenda.</returns>
		AgendaDataCollection GetAgendaDataBySysId( int sysId );

		/// <summary>
		/// Get multiple agendas from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the agendas to retrieve.</param>
		/// <returns>An AgendaCollection containing the requested agendas.</returns>
		AgendaDataCollection GetAgendaDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more agendas to the database.
		/// </summary>
		/// <param name="agendas">An AgendaCollection containing the agendas to insert.</param>
		/// <returns>An AgendaCollection containing the inserted agendas.</returns>
		AgendaDataCollection InsertAgendaData( AgendaDataCollection agendas );

		/// <summary>
		/// Update one or more agendas in the database.
		/// </summary>
		/// <param name="agendas">An AgendaCollection containing the agendas to update.</param>
		/// <returns>An AgendaCollection containing the updated agendas.</returns>
		AgendaDataCollection UpdateAgendaData( AgendaDataCollection agendas );

		/// <summary>
		/// Remove one or more agendas from the database.
		/// </summary>
		/// <param name="agendas">An AgendaCollection containing the agendas to remove.</param>
		void RemoveAgendaData( AgendaDataCollection agendas );

		/// <summary>
		/// Remove all agendas from the database.
		/// </summary>
		void RemoveAllAgendaData();

	}

}
