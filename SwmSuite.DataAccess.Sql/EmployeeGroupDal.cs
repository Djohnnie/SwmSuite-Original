using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;

using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;
using SwmSuite.DataAccess.Sql.SqlHelper;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql {

	public sealed class EmployeeGroupDal : IEmployeeGroupDal {

		#region -_ Private Members _-

		private EmployeeGroupSqlHelper _sqlHelper = new EmployeeGroupSqlHelper();

		#endregion

		#region -_ IEmployeeGroupDal Members _-

		/// <summary>
		/// Get the number of EmployeeGroups in the database.
		/// </summary>
		/// <returns>The number of EmployeeGroups in the database.</returns>
		int IEmployeeGroupDal.CountEmployeeGroups() {
			int countToReturn = 0;
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateCountCommand() , conn ) ) {
					countToReturn = (int)cmd.ExecuteScalar();
				}
				conn.Close();
			}
			return countToReturn;
		}

		/// <summary>
		/// Get all employeegroups from the database.
		/// </summary>
		/// <returns>A EmployeeGroupCollection containing all employeegroups.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.GetEmployeeGroups() {
			EmployeeGroupDataCollection employeegroupsToReturn = new EmployeeGroupDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeegroupsToReturn.Add( _sqlHelper.EmployeeGroupFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeegroupsToReturn;
		}

		/// <summary>
		/// Get the employeegroups for the given employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the employee groups for.</param>
		/// <returns>An EmployeeGroupDataCollection containing the requested employee groups.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.GetEmployeeGroupByEmployee( int employeeSysId ) {
			EmployeeGroupDataCollection employeegroupsToReturn = new EmployeeGroupDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployee() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , employeeSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeegroupsToReturn.Add( _sqlHelper.EmployeeGroupFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeegroupsToReturn;
		}

		/// <summary>
		/// Get a single employeegroup from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employeegroup to retrieve.</param>
		/// <returns>An EmployeeGroupCollection containing the requested employeegroup.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.GetEmployeeGroupBySysId( int sysId ) {
			return ( (IEmployeeGroupDal)this ).GetEmployeeGroupsBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple employeegroups from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the employeegroups to retrieve.</param>
		/// <returns>An EmployeeGroupCollection containing the requested employeegroups.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.GetEmployeeGroupsBySysIds( int[] sysIds ) {
			EmployeeGroupDataCollection employeegroupsToReturn = new EmployeeGroupDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeegroupsToReturn.Add( _sqlHelper.EmployeeGroupFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeegroupsToReturn;
		}

		/// <summary>
		/// Insert one or more employeegroups to the database.
		/// </summary>
		/// <param name="employeegroups">An EmployeeGroupCollection containing the employeegroups to insert.</param>
		/// <returns>An EmployeeGroupCollection containing the inserted employeegroups.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.InsertEmployeeGroups( EmployeeGroupDataCollection employeegroups ) {
			return Save( employeegroups , true );
		}

		/// <summary>
		/// Update one or more employeegroups in the database.
		/// </summary>
		/// <param name="employeegroups">An EmployeeGroupCollection containing the employeegroups to update.</param>
		/// <returns>An EmployeeGroupCollection containing the updated employeegroups.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.UpdateEmployeeGroups( EmployeeGroupDataCollection employeegroups ) {
			return Save( employeegroups , false );
		}

		/// <summary>
		/// Remove one or more employeegroups from the database.
		/// </summary>
		/// <param name="employeegroups">An EmployeeGroupCollection containing the employeegroups to remove.</param>
		void IEmployeeGroupDal.RemoveEmployeeGroups( EmployeeGroupDataCollection employeegroups ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( EmployeeGroupData employeegroup in employeegroups ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , employeegroup.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , employeegroup.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , employeegroup.ToString( ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all employeegroups from the database.
		/// </summary>
		void IEmployeeGroupDal.RemoveAllEmployeeGroups() {
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

		private EmployeeGroupDataCollection Save( EmployeeGroupDataCollection employeegroups , bool insert ) {
			EmployeeGroupDataCollection employeegroupsToReturn = new EmployeeGroupDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( EmployeeGroupData employeegroup in employeegroups ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterName , employeegroup.Name );
							if( !String.IsNullOrEmpty( employeegroup.Description ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , employeegroup.Description );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterVisible , employeegroup.Visible );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , employeegroup.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , employeegroup.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									employeegroupsToReturn.Add( _sqlHelper.EmployeeGroupFromReader( reader ) );
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
			return employeegroupsToReturn;
		}

		#endregion

	}

}