using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Sql.SqlHelper.MessageModule;
using System.Transactions;
using SwmSuite.Configuration;
using System.Data.SqlClient;
using SwmSuite.Data.Common;


namespace SwmSuite.DataAccess.Sql {
	
	/// <summary>
	/// DAL Interface for the MessageFolderService methods.
	/// </summary>
	public sealed class MessageFolderDal : IMessageFolderDal {

		#region -_ Private Members _-

		private MessageFolderSqlHelper _sqlHelper = new MessageFolderSqlHelper();

		#endregion

		#region -_ IMessageDal Members _-

		/// <summary>
		/// Get all messageFolders from the database.
		/// </summary>
		/// <returns>An MessageFolderCollection containing all messageFolders.</returns>
		MessageFolderDataCollection IMessageFolderDal.GetMessageFolderData() {
			MessageFolderDataCollection messageFoldersToReturn = new MessageFolderDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageFoldersToReturn.Add( _sqlHelper.MessageFolderFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageFoldersToReturn;
		}

		/// <summary>
		/// Get all messageFolders from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the messageFolders for.</param>
		/// <returns>An MessageFolderCollection containing all requested messageFolders.</returns>
		MessageFolderDataCollection IMessageFolderDal.GetMessageFolderDataForEmployee( int employeeSysId ) {
			MessageFolderDataCollection messageFoldersToReturn = new MessageFolderDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployee() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOwnerEmployeeSysId , employeeSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageFoldersToReturn.Add( _sqlHelper.MessageFolderFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageFoldersToReturn;
		}

		/// <summary>
		/// Get all messagefolders from the database for a specific parent folder.
		/// </summary>
		/// <param name="folderSysId">The internal id of the folder to get the subfolders for.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		MessageFolderDataCollection IMessageFolderDal.GetMessageFolderDataForFolder( int folderSysId ) {
			MessageFolderDataCollection messageFoldersToReturn = new MessageFolderDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByFolder() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterParentMessageFolderSysId , folderSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageFoldersToReturn.Add( _sqlHelper.MessageFolderFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageFoldersToReturn;
		}

		/// <summary>
		/// Get the parent messagefolder for a specific message.
		/// </summary>
		/// <param name="messageSysId">The internal id of the message to get the parent folder for.</param>
		/// <param name="employeeSysId">The internal id of the owner of the message folder.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		MessageFolderDataCollection IMessageFolderDal.GetParentMessageFolderDataByMessage( int messageSysId , int employeeSysId ) {
			MessageFolderDataCollection messageFoldersToReturn = new MessageFolderDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByMessage() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessageSysId , messageSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOwnerEmployeeSysId , employeeSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageFoldersToReturn.Add( _sqlHelper.MessageFolderFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageFoldersToReturn;
		}

		/// <summary>
		/// Get all special messagefolders from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the special messageFolders for.</param>
		/// <param name="specialFolder">The special messagefolders to get.</param>
		/// <returns>A MessageFolderCollection containing all requested messagefolders.</returns>
		MessageFolderDataCollection IMessageFolderDal.GetSpecialMessageFoldeDataForEmployee( int employeeSysId , MessageSpecialFolder specialFolder ) {
			MessageFolderDataCollection messageFoldersToReturn = new MessageFolderDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployeeAndSpecialFolder() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOwnerEmployeeSysId , employeeSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSpecialFolder , (byte)specialFolder );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageFoldersToReturn.Add( _sqlHelper.MessageFolderFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageFoldersToReturn;
		}

		/// <summary>
		/// Get a single messageFolder from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the messageFolder to retrieve.</param>
		/// <returns>An MessageFolderCollection containing the requested messageFolder.</returns>
		MessageFolderDataCollection IMessageFolderDal.GetMessageFolderDataBySysId( int sysId ) {
			return ( (IMessageFolderDal)this ).GetMessageFolderDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple messageFolders from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the messageFolders to retrieve.</param>
		/// <returns>An MessageFolderCollection containing the requested messageFolders.</returns>
		MessageFolderDataCollection IMessageFolderDal.GetMessageFolderDataBySysIds( int[] sysIds ) {
			MessageFolderDataCollection messageFoldersToReturn = new MessageFolderDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							messageFoldersToReturn.Add( _sqlHelper.MessageFolderFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return messageFoldersToReturn;
		}

		/// <summary>
		/// Insert one or more messageFolders to the database.
		/// </summary>
		/// <param name="messageFolders">An MessageFolderCollection containing the messageFolders to insert.</param>
		/// <returns>An MessageFolderCollection containing the inserted messageFolders.</returns>
		MessageFolderDataCollection IMessageFolderDal.InsertMessageFolderData( MessageFolderDataCollection messageFolders ) {
			return Save( messageFolders , true );
		}

		/// <summary>
		/// Update one or more messageFolders in the database.
		/// </summary>
		/// <param name="messageFolders">An MessageFolderCollection containing the messageFolders to update.</param>
		/// <returns>An MessageFolderCollection containing the updated messageFolders.</returns>
		MessageFolderDataCollection IMessageFolderDal.UpdateMessageFolderData( MessageFolderDataCollection messageFolders ) {
			return Save( messageFolders , false );
		}

		/// <summary>
		/// Remove one or more messageFolders from the database.
		/// </summary>
		/// <param name="messageFolders">An MessageFolderCollection containing the messageFolders to remove.</param>
		void IMessageFolderDal.RemoveMessageFolderData( MessageFolderDataCollection messageFolders ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( MessageFolderData messageFolder in messageFolders ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , messageFolder.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , messageFolder.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , messageFolder.ToString( ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all messageFolders from the database.
		/// </summary>
		void IMessageFolderDal.RemoveAllMessageFolderData() {
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

		private MessageFolderDataCollection Save( MessageFolderDataCollection messageFolders , bool insert ) {
			MessageFolderDataCollection messageFoldersToReturn = new MessageFolderDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( MessageFolderData messageFolder in messageFolders ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOwnerEmployeeSysId , messageFolder.OwnerEmployeeSysId );
							if( messageFolder.ParentMessageFolderSysId.HasValue ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterParentMessageFolderSysId , messageFolder.ParentMessageFolderSysId );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterParentMessageFolderSysId , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSpecialFolder , messageFolder.SpecialFolder );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterName , messageFolder.Name );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterVisible , messageFolder.Visible );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , messageFolder.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , messageFolder.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									messageFoldersToReturn.Add( _sqlHelper.MessageFolderFromReader( reader ) );
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
			return messageFoldersToReturn;
		}

		#endregion

	}

}
