using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Sql.SqlHelper;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;

namespace SwmSuite.DataAccess.Sql {

	public sealed class MessageStorageDal : IMessageStorageDal {

		#region -_ Private Members _-

		private MessageStorageSqlHelper _sqlHelper = new MessageStorageSqlHelper();

		#endregion

		#region -_ IMessageStorageDal Members _-

		/// <summary>
		/// Get all messageStorages from the database.
		/// </summary>
		/// <returns>An MessageStorageCollection containing all messageStorages.</returns>
		MessageStorageDataCollection IMessageStorageDal.GetMessageStorageData() {
			MessageStorageDataCollection messageStoragesToReturn = new MessageStorageDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageStoragesToReturn.Add( _sqlHelper.MessageStorageFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageStoragesToReturn;
		}

		/// <summary>
		/// Get a single messageStorage from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the messageStorage to retrieve.</param>
		/// <returns>An MessageStorageCollection containing the requested messageStorage.</returns>
		MessageStorageDataCollection IMessageStorageDal.GetMessageStorageDataBySysId( int sysId ) {
			return ( (IMessageStorageDal)this ).GetMessageStorageDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple messageStorages from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messageStorages to retrieve.</param>
		/// <returns>An MessageStorageCollection containing the requested messageStorages.</returns>
		MessageStorageDataCollection IMessageStorageDal.GetMessageStorageDataBySysIds( int[] sysIds ) {
			MessageStorageDataCollection messageStoragesToReturn = new MessageStorageDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageStoragesToReturn.Add( _sqlHelper.MessageStorageFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageStoragesToReturn;
		}

		/// <summary>
		/// Get all messagestorages for a specific message and folder from the database.
		/// </summary>
		/// <param name="messageSysId">The internal ids of the message to get the messagestorage for.</param>
		/// <param name="messageFolderSysId">The internal ids of the messagefolder to get the messagestorage for.</param>
		/// <returns>A MessagestorageCollection containing the requested messagestorages.</returns>
		/// <remarks>This should return a single MessageStorage object if the given message is stored in the given messagefolder.</remarks>
		MessageStorageDataCollection IMessageStorageDal.GetMessageStorageDataByMessageAndMessageFolder( int messageSysId , int messageFolderSysId ) {
			MessageStorageDataCollection messageStoragesToReturn = new MessageStorageDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByMessageAndMessageFolder() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessageSysId , messageSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessageFolderSysId , messageFolderSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageStoragesToReturn.Add( _sqlHelper.MessageStorageFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageStoragesToReturn;
		}

		/// <summary>
		/// Insert one or more messageStorages to the database.
		/// </summary>
		/// <param name="messageStorages">An MessageStorageCollection containing the messageStorages to insert.</param>
		/// <returns>An MessageStorageCollection containing the inserted messageStorages.</returns>
		MessageStorageDataCollection IMessageStorageDal.InsertMessageStorageData( MessageStorageDataCollection messageStorages ) {
			return Save( messageStorages , true );
		}

		/// <summary>
		/// Update one or more messageStorages in the database.
		/// </summary>
		/// <param name="messageStorages">An MessageStorageCollection containing the messageStorages to update.</param>
		/// <returns>An MessageStorageCollection containing the updated messageStorages.</returns>
		MessageStorageDataCollection IMessageStorageDal.UpdateMessageStorageData( MessageStorageDataCollection messageStorages ) {
			return Save( messageStorages , false );
		}

		/// <summary>
		/// Remove one or more messageStorages from the database.
		/// </summary>
		/// <param name="messageStorages">An MessageStorageCollection containing the messageStorages to remove.</param>
		void IMessageStorageDal.RemoveMessageStorageData( MessageStorageDataCollection messageStorages ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( MessageStorageData messageStorage in messageStorages ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , messageStorage.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , messageStorage.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , messageStorage.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all messageStorages from the database.
		/// </summary>
		void IMessageStorageDal.RemoveAllMessageStorageData() {
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

		/// <summary>
		/// Update the read flag for a specific messagestorage.
		/// </summary>
		/// <param name="messageSysId">The internal id for the message</param>
		/// <param name="messageFolderSysId">The internal id for the messagefolder.</param>
		/// <param name="newReadFlag">The new read flag.</param>
		void IMessageStorageDal.UpdateReadFlag( int messageSysId , int messageFolderSysId , bool newReadFlag ) {
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateUpdateReadFlag() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterIsRead , newReadFlag );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessageSysId , messageSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessageFolderSysId , messageFolderSysId );
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		/// <summary>
		/// Update the new flag for a specific messagestorage.
		/// </summary>
		/// <param name="messageSysId">The internal id for the message</param>
		/// <param name="messageFolderSysId">The internal id for the messagefolder.</param>
		/// <param name="newNewFlag">The new new flag.</param>
		void IMessageStorageDal.UpdateNewFlag( int messageSysId , int messageFolderSysId , bool newNewFlag ) {
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateUpdateNewFlag() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterIsNew , newNewFlag );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessageSysId , messageSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessageFolderSysId , messageFolderSysId );
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		#endregion

		#region -_ Helper methods _-

		private MessageStorageDataCollection Save( MessageStorageDataCollection messageStorages , bool insert ) {
			MessageStorageDataCollection messageStoragesToReturn = new MessageStorageDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( MessageStorageData messageStorage in messageStorages ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessageSysId , messageStorage.MessageSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessageFolderSysId , messageStorage.MessageFolderSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterIsRead , messageStorage.IsRead );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterIsNew , messageStorage.IsNew );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , messageStorage.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , messageStorage.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									messageStoragesToReturn.Add( _sqlHelper.MessageStorageFromReader( reader ) );
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
			return messageStoragesToReturn;
		}

		#endregion

	}

}
