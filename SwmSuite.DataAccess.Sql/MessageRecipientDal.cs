using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Sql.SqlHelper.MessageModule;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;

namespace SwmSuite.DataAccess.Sql {

	public sealed class MessageRecipientDal : IMessageRecipientDal {

		#region -_ Private Members _-

		private MessageRecipientSqlHelper _sqlHelper = new MessageRecipientSqlHelper();

		#endregion

		#region -_ IMessageRecipientDal Members _-

		/// <summary>
		/// Get all messageRecipients from the database.
		/// </summary>
		/// <returns>An MessageRecipientCollection containing all messageRecipients.</returns>
		MessageRecipientDataCollection IMessageRecipientDal.GetMessageRecipientData() {
			MessageRecipientDataCollection messageRecipientsToReturn = new MessageRecipientDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageRecipientsToReturn.Add( _sqlHelper.MessageRecipientFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageRecipientsToReturn;
		}

		/// <summary>
		/// Get all messageRecipients from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the messageRecipients for.</param>
		/// <returns>An MessageRecipientCollection containing all requested messageRecipients.</returns>
		MessageRecipientDataCollection IMessageRecipientDal.GetMessageRecipientDataForEmployee( int employeeSysId ) {
			MessageRecipientDataCollection messageRecipientsToReturn = new MessageRecipientDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployee() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , employeeSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageRecipientsToReturn.Add( _sqlHelper.MessageRecipientFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageRecipientsToReturn;
		}

		/// <summary>
		/// Get a single messageRecipient from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the messageRecipient to retrieve.</param>
		/// <returns>An MessageRecipientCollection containing the requested messageRecipient.</returns>
		MessageRecipientDataCollection IMessageRecipientDal.GetMessageRecipientDataBySysId( int sysId ) {
			return ( (IMessageRecipientDal)this ).GetMessageRecipientDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple messageRecipients from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messageRecipients to retrieve.</param>
		/// <returns>An MessageRecipientCollection containing the requested messageRecipients.</returns>
		MessageRecipientDataCollection IMessageRecipientDal.GetMessageRecipientDataBySysIds( int[] sysIds ) {
			MessageRecipientDataCollection messageRecipientsToReturn = new MessageRecipientDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageRecipientsToReturn.Add( _sqlHelper.MessageRecipientFromReader( reader ) );
						}
					}
				}
			}
			return messageRecipientsToReturn;
		}

		/// <summary>
		/// Insert one or more messageRecipients to the database.
		/// </summary>
		/// <param name="messageRecipients">An MessageRecipientCollection containing the messageRecipients to insert.</param>
		/// <returns>An MessageRecipientCollection containing the inserted messageRecipients.</returns>
		MessageRecipientDataCollection IMessageRecipientDal.InsertMessageRecipientData( MessageRecipientDataCollection messageRecipients ) {
			return Save( messageRecipients , true );
		}

		/// <summary>
		/// Update one or more messageRecipients in the database.
		/// </summary>
		/// <param name="messageRecipients">An MessageRecipientCollection containing the messageRecipients to update.</param>
		/// <returns>An MessageRecipientCollection containing the updated messageRecipients.</returns>
		MessageRecipientDataCollection IMessageRecipientDal.UpdateMessageRecipientData( MessageRecipientDataCollection messageRecipients ) {
			return Save( messageRecipients , false );
		}

		/// <summary>
		/// Remove one or more messageRecipients from the database.
		/// </summary>
		/// <param name="messageRecipients">An MessageRecipientCollection containing the messageRecipients to remove.</param>
		void IMessageRecipientDal.RemoveMessageRecipientData( MessageRecipientDataCollection messageRecipients ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( MessageRecipientData messageRecipient in messageRecipients ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , messageRecipient.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , messageRecipient.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , messageRecipient.ToString( ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
							cmd.ExecuteNonQuery();
						}
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						//conn.Close();
					}
				}
				transactionScope.Complete();
			}
		}

		/// <summary>
		/// Remove all messageRecipients from the database.
		/// </summary>
		void IMessageRecipientDal.RemoveAllMessageRecipientData() {
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
				}
				transactionScope.Complete();
			}
		}

		#endregion

		#region -_ Helper methods _-

		private MessageRecipientDataCollection Save( MessageRecipientDataCollection messageRecipients , bool insert ) {
			MessageRecipientDataCollection messageRecipientsToReturn = new MessageRecipientDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( MessageRecipientData messageRecipient in messageRecipients ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId, messageRecipient.EmployeeSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessageSysId , messageRecipient.MessageSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , messageRecipient.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , messageRecipient.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									messageRecipientsToReturn.Add( _sqlHelper.MessageRecipientFromReader( reader ) );
								}
							}
						}
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						//conn.Close();
					}
				}
				transactionScope.Complete();
			}
			return messageRecipientsToReturn;
		}

		#endregion

	}

}
