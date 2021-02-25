using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;

namespace SwmSuite.DataAccess.Sql {

	public sealed class AvatarDal : IAvatarDal {

		#region -_ Private Members _-

		private AvatarSqlHelper _sqlHelper = new AvatarSqlHelper();

		#endregion

		#region -_ IAvatarDal Members _-

		/// <summary>
		/// Get all avatars from the database.
		/// </summary>
		/// <returns>A AvatarCollection containing all avatars.</returns>
		AvatarDataCollection IAvatarDal.GetAvatarData() {
			AvatarDataCollection avatarsToReturn = new AvatarDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							avatarsToReturn.Add( _sqlHelper.AvatarFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return avatarsToReturn;
		}

		/// <summary>
		/// Get a single avatar from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the avatar to retrieve.</param>
		/// <returns>An AvatarCollection containing the requested avatar.</returns>
		AvatarDataCollection IAvatarDal.GetAvatarDataBySysId( int sysId ) {
			return ( (IAvatarDal)this ).GetAvatarDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple avatars from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the avatars to retrieve.</param>
		/// <returns>An AvatarCollection containing the requested avatars.</returns>
		AvatarDataCollection IAvatarDal.GetAvatarDataBySysIds( int[] sysIds ) {
			AvatarDataCollection avatarsToReturn = new AvatarDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							avatarsToReturn.Add( _sqlHelper.AvatarFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return avatarsToReturn;
		}

		/// <summary>
		/// Insert one or more avatars to the database.
		/// </summary>
		/// <param name="avatars">An AvatarCollection containing the avatars to insert.</param>
		/// <returns>An AvatarCollection containing the inserted avatars.</returns>
		AvatarDataCollection IAvatarDal.InsertAvatarData( AvatarDataCollection avatars ) {
			return Save( avatars , true );
		}

		/// <summary>
		/// Update one or more avatars in the database.
		/// </summary>
		/// <param name="avatars">An AvatarCollection containing the avatars to update.</param>
		/// <returns>An AvatarCollection containing the updated avatars.</returns>
		AvatarDataCollection IAvatarDal.UpdateAvatarData( AvatarDataCollection avatars ) {
			return Save( avatars , false );
		}

		/// <summary>
		/// Remove one or more avatars from the database.
		/// </summary>
		/// <param name="avatars">An AvatarCollection containing the avatars to remove.</param>
		void IAvatarDal.RemoveAvatarData( AvatarDataCollection avatars ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AvatarData avatar in avatars ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , avatar.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , avatar.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , avatar.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all avatars from the database.
		/// </summary>
		void IAvatarDal.RemoveAllAvatarData() {
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

		private AvatarDataCollection Save( AvatarDataCollection avatars , bool insert ) {
			AvatarDataCollection avatarsToReturn = new AvatarDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AvatarData avatar in avatars ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPicture , avatar.Picture );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , avatar.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , avatar.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									avatarsToReturn.Add( _sqlHelper.AvatarFromReader( reader ) );
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
			return avatarsToReturn;
		}

		#endregion

	}

}
