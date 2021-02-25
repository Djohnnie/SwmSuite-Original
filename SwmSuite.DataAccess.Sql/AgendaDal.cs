using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Sql.SqlHelper;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;
using System.Globalization;

namespace SwmSuite.DataAccess.Sql {

	public sealed class AgendaDal : IAgendaDal {

		#region -_ Private Members _-

		private AgendaSqlHelper _sqlHelper = new AgendaSqlHelper();

		#endregion

		#region -_ IAgendaDal Members _-

		/// <summary>
		/// Get all agendas from the database.
		/// </summary>
		/// <returns>A AgendaCollection containing all agendas.</returns>
		AgendaDataCollection IAgendaDal.GetAgendaData() {
			AgendaDataCollection agendasToReturn = new AgendaDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							agendasToReturn.Add( _sqlHelper.AgendaFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return agendasToReturn;
		}

		/// <summary>
		/// Get all agendas from the database for a specific employee.
		/// </summary>
		/// <returns>A AgendaCollection containing all requested agendas.</returns>
		AgendaDataCollection IAgendaDal.GetAgendaDataForEmployee( int employeeSysId ) {
			AgendaDataCollection agendasToReturn = new AgendaDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployee() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOwnerEmployeeSysId , employeeSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							agendasToReturn.Add( _sqlHelper.AgendaFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return agendasToReturn;
		}

		/// <summary>
		/// Get a single agenda from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the agenda to retrieve.</param>
		/// <returns>An AgendaCollection containing the requested agenda.</returns>
		AgendaDataCollection IAgendaDal.GetAgendaDataBySysId( int sysId ) {
			return ( (IAgendaDal)this ).GetAgendaDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple agendas from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the agendas to retrieve.</param>
		/// <returns>An AgendaCollection containing the requested agendas.</returns>
		AgendaDataCollection IAgendaDal.GetAgendaDataBySysIds( int[] sysIds ) {
			AgendaDataCollection agendasToReturn = new AgendaDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							agendasToReturn.Add( _sqlHelper.AgendaFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return agendasToReturn;
		}

		/// <summary>
		/// Insert one or more agendas to the database.
		/// </summary>
		/// <param name="agendas">An AgendaCollection containing the agendas to insert.</param>
		/// <returns>An AgendaCollection containing the inserted agendas.</returns>
		AgendaDataCollection IAgendaDal.InsertAgendaData( AgendaDataCollection agendas ) {
			return Save( agendas , true );
		}

		/// <summary>
		/// Update one or more agendas in the database.
		/// </summary>
		/// <param name="agendas">An AgendaCollection containing the agendas to update.</param>
		/// <returns>An AgendaCollection containing the updated agendas.</returns>
		AgendaDataCollection IAgendaDal.UpdateAgendaData( AgendaDataCollection agendas ) {
			return Save( agendas , false );
		}

		/// <summary>
		/// Remove one or more agendas from the database.
		/// </summary>
		/// <param name="agendas">An AgendaCollection containing the agendas to remove.</param>
		void IAgendaDal.RemoveAgendaData( AgendaDataCollection agendas ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AgendaData agenda in agendas ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , agenda.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , agenda.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , agenda.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
							cmd.ExecuteNonQuery();
						}
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						//conn.Close();
					}
					conn.Close();
				}
				transactionScope.Complete();
			}
		}

		/// <summary>
		/// Remove all agendas from the database.
		/// </summary>
		void IAgendaDal.RemoveAllAgendaData() {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteAllCommand() , conn );
						cmd.ExecuteNonQuery();
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						//conn.Close();
					}
					conn.Close();
				}
				transactionScope.Complete();
			}

		}

		#endregion

		#region -_ Helper methods _-

		private AgendaDataCollection Save( AgendaDataCollection agendas , bool insert ) {
			AgendaDataCollection agendasToReturn = new AgendaDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AgendaData agenda in agendas ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTitle , agenda.Title );
							if( !String.IsNullOrEmpty( agenda.Description ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , agenda.Description );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOwnerEmployeeSysId , agenda.OwnerEmployeeSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterVisibility , agenda.Visibility );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterColor1 , agenda.Color1 );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterColor2 , agenda.Color2 );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterColor3 , agenda.Color3 );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , agenda.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , agenda.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									agendasToReturn.Add( _sqlHelper.AgendaFromReader( reader ) );
								}
							}
						}
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						//conn.Close();
					}
					conn.Close();
				}
				transactionScope.Complete();
			}
			return agendasToReturn;
		}

		#endregion

	}

}
