using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;

namespace SwmSuite.Business {

	public class AgendaBll {

		#region -_ Private Members _-

		private IAgendaDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateAgendaDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get the agenda for the given internal id.
		/// </summary>
		/// <param name="agendaSysId">The internal id of the agenda to get.</param>
		/// <returns>The agenda for the given internal id, or null if the agenda does not exist.</returns>
		public Agenda GetAgenda( int agendaSysId ) {
			Agenda agendaToReturn = null;
			AgendaDataCollection agendaData = this.GetAgendaDataBySysId( agendaSysId );
			if( agendaData.Count == 1 ) {
				agendaToReturn = AgendaMapping.FromDataObject( agendaData[0] );
			}
			return agendaToReturn;
		}

		/// <summary>
		/// Get all agendas for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the agendas for.</param>
		/// <returns>An AgendaCollection containing the requested agendas.</returns>
		public AgendaCollection GetAgendasForEmployee( Employee employee ){
			AgendaDataCollection agendaData =
				this.GetAgendaDataForEmployee( employee.SysId );
			return AgendaMapping.FromDataObjectCollection( agendaData );
		}

		/// <summary>
		/// Create a new agenda.
		/// </summary>
		/// <param name="agenda">The agenda to create.</param>
		/// <returns>The created agenda.</returns>
		public Agenda CreateAgenda( Agenda agenda ) {
			AgendaData agendaToInsert = AgendaMapping.FromBusinessObject( agenda );
			AgendaDataCollection agendaDataInserted = 
				this.InsertAgendaData( AgendaDataCollection.FromSingleAgenda( agendaToInsert ) );
			Agenda agendaToReturn = null;
			if( agendaDataInserted.Count == 1 ) {
				agendaToReturn = AgendaMapping.FromDataObject( agendaDataInserted[0] );
			}
			return agendaToReturn;
		}

		/// <summary>
		/// Update an existing agenda.
		/// </summary>
		/// <param name="agenda">The agenda to update.</param>
		/// <returns>The updated agenda.</returns>
		public Agenda UpdateAgenda( Agenda agenda ) {
			AgendaData agendaToUpdate = AgendaMapping.FromBusinessObject( agenda );
			AgendaDataCollection agendaDataUpdated =
				this.UpdateAgendaData( AgendaDataCollection.FromSingleAgenda( agendaToUpdate ) );
			Agenda agendaToReturn = null;
			if( agendaDataUpdated.Count == 1 ) {
				agendaToReturn = AgendaMapping.FromDataObject( agendaDataUpdated[0] );
			}
			return agendaToReturn;
		}

		/// <summary>
		/// Delete an existing agenda.
		/// </summary>
		/// <param name="agenda">The agenda to delete.</param>
		public void DeleteAgenda( Agenda agenda ) {
			AgendaData agendaToUpdate = AgendaMapping.FromBusinessObject( agenda );
				this.RemoveAgendaData( AgendaDataCollection.FromSingleAgenda( agendaToUpdate ) );
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all agendas from the database.
		/// </summary>
		/// <returns>An AgendaCollection containing all agendas.</returns>
		public AgendaDataCollection GetAgendaData() {
			return dal.GetAgendaData();
		}

		/// <summary>
		/// Get all agendas from the database for a specific employee.
		/// </summary>
		/// <returns>A AgendaCollection containing all requested agendas.</returns>
		AgendaDataCollection GetAgendaDataForEmployee( int employeeSysId ) {
			return dal.GetAgendaDataForEmployee( employeeSysId );
		}

		/// <summary>
		/// Get a single agenda from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the agenda to retrieve.</param>
		/// <returns>An AgendaCollection containing the requested agenda.</returns>
		public AgendaDataCollection GetAgendaDataBySysId( int sysId ) {
			return dal.GetAgendaDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple agendas from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the agendas to retrieve.</param>
		/// <returns>An AgendaCollection containing the requested agendas.</returns>
		public AgendaDataCollection GetAgendaDataBySysIds( int[] sysIds ) {
			return dal.GetAgendaDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more agendas to the database.
		/// </summary>
		/// <param name="agendas">An AgendaCollection containing the agendas to insert.</param>
		/// <returns>An AgendaCollection containing the inserted agendas.</returns>
		public AgendaDataCollection InsertAgendaData( AgendaDataCollection agendas ) {
			return dal.InsertAgendaData( agendas );
		}

		/// <summary>
		/// Update one or more agendas in the database.
		/// </summary>
		/// <param name="agendas">An AgendaCollection containing the agendas to update.</param>
		/// <returns>An AgendaCollection containing the updated agendas.</returns>
		public AgendaDataCollection UpdateAgendaData( AgendaDataCollection agendas ) {
			return dal.UpdateAgendaData( agendas );
		}

		/// <summary>
		/// Remove one or more agendas from the database.
		/// </summary>
		/// <param name="agendas">An AgendaCollection containing the agendas to remove.</param>
		public void RemoveAgendaData( AgendaDataCollection agendas ) {
			dal.RemoveAgendaData( agendas );
		}

		/// <summary>
		/// Remove all agendas from the database.
		/// </summary>
		public void RemoveAllAgendaData() {
			dal.RemoveAllAgendaData();
		}

		#endregion

	}

}
