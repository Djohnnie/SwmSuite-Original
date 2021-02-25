using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Sql.SqlHelper;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using SwmSuite.DataAccess.Interface;
using System.Transactions;
using SwmSuite.DataAccess.Sql.SqlHelper.MessageModule;

namespace SwmSuite.DataAccess.Sql {

	public sealed class MessageDal : IMessageDal {

		#region -_ Private Members _-

		private MessageSqlHelper _sqlHelper = new MessageSqlHelper();
		private MessageStorageSqlHelper _messageStorageSqlHelper = new MessageStorageSqlHelper();

		#endregion

		#region -_ IMessageDal Members _-

		/// <summary>
		/// Get all messages from the database.
		/// </summary>
		/// <returns>An MessageCollection containing all messages.</returns>
		MessageDataCollection IMessageDal.GetMessageData() {
			MessageDataCollection messagesToReturn = new MessageDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messagesToReturn.Add( _sqlHelper.MessageFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messagesToReturn;
		}

		/// <summary>
		/// Get all messages from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the messages for.</param>
		/// <returns>An MessageCollection containing all requested messages.</returns>
		MessageDataCollection IMessageDal.GetMessageDataForEmployee( int employeeSysId ) {
			MessageDataCollection messagesToReturn = new MessageDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployee() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterFromEmployeeSysId , employeeSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messagesToReturn.Add( _sqlHelper.MessageFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messagesToReturn;
		}

		/// <summary>
		/// Get all messages in a specific messagefolder from the database.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the messagefolder to get the messages for.</param>
		/// <returns>An MessageCollection containing all requested messages.</returns>
		MessageDataCollection IMessageDal.GetMessageDataInMessageFolder( int messageFolderSysId ) {
			MessageDataCollection messagesToReturn = new MessageDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByMessageFolder() , conn ) ) {
					cmd.Parameters.AddWithValue( _messageStorageSqlHelper.DBParameterMessageFolderSysId , messageFolderSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messagesToReturn.Add( _sqlHelper.MessageFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messagesToReturn;
		}

		/// <summary>
		/// Get a single message from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the message to retrieve.</param>
		/// <returns>An MessageCollection containing the requested message.</returns>
		MessageDataCollection IMessageDal.GetMessageDataBySysId( int sysId ) {
			return ( (IMessageDal)this ).GetMessageDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple messages from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messages to retrieve.</param>
		/// <returns>An MessageCollection containing the requested messages.</returns>
		MessageDataCollection IMessageDal.GetMessageDataBySysIds( int[] sysIds ) {
			MessageDataCollection messagesToReturn = new MessageDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messagesToReturn.Add( _sqlHelper.MessageFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messagesToReturn;
		}

		/// <summary>
		/// Insert one or more messages to the database.
		/// </summary>
		/// <param name="messages">An MessageCollection containing the messages to insert.</param>
		/// <returns>An MessageCollection containing the inserted messages.</returns>
		MessageDataCollection IMessageDal.InsertMessageData( MessageDataCollection messages ) {
			return Save( messages , true );
		}

		/// <summary>
		/// Update one or more messages in the database.
		/// </summary>
		/// <param name="messages">An MessageCollection containing the messages to update.</param>
		/// <returns>An MessageCollection containing the updated messages.</returns>
		MessageDataCollection IMessageDal.UpdateMessageData( MessageDataCollection messages ) {
			return Save( messages , false );
		}

		/// <summary>
		/// Remove one or more messages from the database.
		/// </summary>
		/// <param name="messages">An MessageCollection containing the messages to remove.</param>
		void IMessageDal.RemoveMessageData( MessageDataCollection messages ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( MessageData message in messages ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , message.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , message.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , message.ToString( ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all messages from the database.
		/// </summary>
		void IMessageDal.RemoveAllMessageData() {
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

		private MessageDataCollection Save( MessageDataCollection messages , bool insert ) {
			MessageDataCollection messagesToReturn = new MessageDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( MessageData message in messages ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterFromEmployeeSysId , message.FromEmployeeSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDate , message.Date );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSubject , message.Subject );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterContent , message.Content );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPriority , message.Priority );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterVisible , message.Visible );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , message.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , message.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									messagesToReturn.Add( _sqlHelper.MessageFromReader( reader ) );
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
			return messagesToReturn;
		}

		#endregion

	}

}