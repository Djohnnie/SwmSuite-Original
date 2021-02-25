using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using NHibernate;
using SwmSuite.Configuration;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.NHibernate {

	public sealed class EmployeeGroupDal : IEmployeeGroupDal {

		#region IEmployeeGroupDal Members

		/// <summary>
		/// Get the number of EmployeeGroups in the database.
		/// </summary>
		/// <returns>The number of EmployeeGroups in the database.</returns>
		int IEmployeeGroupDal.CountEmployeeGroups() {
			int countToReturn = 0;
			ISession session = NHibernateSessionFactory.OpenSession();
			IQuery q = session.CreateSQLQuery( "SELECT COUNT(*) FROM tbl_EmployeeGroups {EmployeeGroup}" ).AddEntity( "EmployeeGroup" , typeof( EmployeeGroupData ) );
			countToReturn = (int)q.List()[0];
			session.Close();
			return countToReturn;
		}

		/// <summary>
		/// Get all employeegroups from the database.
		/// </summary>
		/// <returns>An EmployeeGroupCollection containing all employeegroups.</returns> 
		EmployeeGroupDataCollection IEmployeeGroupDal.GetEmployeeGroups() {
			EmployeeGroupDataCollection employeeGroupsToReturn = new EmployeeGroupDataCollection();
			ISession session = NHibernateSessionFactory.OpenSession();
			IQuery q = session.CreateSQLQuery( "SELECT {EmployeeGroup.*} FROM tbl_EmployeeGroups {EmployeeGroup}" ).AddEntity( "EmployeeGroup" , typeof( EmployeeGroupData ) );
			foreach( EmployeeGroupData eg in q.List() ) {
				employeeGroupsToReturn.Add( eg );
			}
			session.Close();
			return employeeGroupsToReturn;
		}

		/// <summary>
		/// Get the employeegroups for the given employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the employee groups for.</param>
		/// <returns>An EmployeeGroupDataCollection containing the requested employee groups.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.GetEmployeeGroupByEmployee( int employeeSysId ) {
			//EmployeeGroupDataCollection employeeGroupsToReturn = new EmployeeGroupDataCollection();
			//ISession session = NHibernateSessionFactory.OpenSession();
			//IQuery q = session.CreateSQLQuery( "SELECT {EmployeeGroup.*} FROM tbl_EmployeeGroups {EmployeeGroup}" ).AddEntity( "EmployeeGroup" , typeof( EmployeeGroupData ) );
			//foreach( EmployeeGroupData eg in q.List() ) {
			//   employeeGroupsToReturn.Add( eg );
			//}
			//session.Close();
			//return employeeGroupsToReturn;
			return null;
		}

		/// <summary>
		/// Get a single employeegroup from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employeegroup to retrieve.</param>
		/// <returns>An EmployeeGroupCollection containing the requested employeegroup.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.GetEmployeeGroupBySysId( int sysId ) {
			return ((IEmployeeGroupDal)this).GetEmployeeGroupsBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple employeegroups from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the employeegroups to retrieve.</param>
		/// <returns>An EmployeeGroupCollection containing the requested employeegroups.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.GetEmployeeGroupsBySysIds( int[] sysIds ) {
			EmployeeGroupDataCollection employeeGroupsToReturn = new EmployeeGroupDataCollection();
			ISession session = NHibernateSessionFactory.OpenSession();
			foreach( int sysId in sysIds ) {
				employeeGroupsToReturn.Add( (EmployeeGroupData)session.Get( "EmployeeGroup" , sysId ) );
			}
			return employeeGroupsToReturn;
		}

		/// <summary>
		/// Insert one or more employeegroups to the database.
		/// </summary>
		/// <param name="employeeGroups">An EmployeeGroupCollection containing the employeegroups to insert.</param>
		/// <returns>An EmployeeGroupCollection containing the inserted employeegroups.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.InsertEmployeeGroups( EmployeeGroupDataCollection employeeGroups ) {
			ISession session = NHibernateSessionFactory.OpenSession();
			foreach( EmployeeGroupData employeeGroup in employeeGroups ) {
				employeeGroup.CreatedBy = Guid.Empty;
				employeeGroup.CreatedOn = DateTime.Now;
				session.Save( employeeGroup );
			}
			session.Flush();
			session.Close();
			return employeeGroups;
		}

		/// <summary>
		/// Update one or more employeegroups in the database.
		/// </summary>
		/// <param name="employeeGroups">An EmployeeGroupCollection containing the employeegroups to update.</param>
		/// <returns>An EmployeeGroupCollection containing the updated employeegroups.</returns>
		EmployeeGroupDataCollection IEmployeeGroupDal.UpdateEmployeeGroups( EmployeeGroupDataCollection employeeGroups ) {
			ISession session = NHibernateSessionFactory.OpenSession();
			foreach( EmployeeGroupData employeeGroup in employeeGroups ) {
				employeeGroup.EditedBy = Guid.Empty;
				employeeGroup.EditedOn = DateTime.Now;
				session.Update( employeeGroup );
			}
			session.Flush();
			session.Close();
			return employeeGroups;
		}

		/// <summary>
		/// Remove one or more employeegroups from the database.
		/// </summary>
		/// <param name="employeeGroups">An EmployeeGroupCollection containing the employeegroups to remove.</param>
		void IEmployeeGroupDal.RemoveEmployeeGroups( EmployeeGroupDataCollection employeeGroups ) {
			ISession session = NHibernateSessionFactory.OpenSession();
			foreach( EmployeeGroupData employeeGroup in employeeGroups ) {
				session.Delete( employeeGroup );
			}
			session.Flush();
			session.Close();
		}

		/// <summary>
		/// Remove all employeegroups from the database.
		/// </summary>
		void IEmployeeGroupDal.RemoveAllEmployeeGroups() {
			
		}

		#endregion

	}

}
