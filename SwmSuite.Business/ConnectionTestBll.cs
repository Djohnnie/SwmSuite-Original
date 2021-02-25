using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class ConnectionTestBll {

		#region -_ Private Members _-

		private IConnectionTestDal dal = DalFactory.CreateDalFactory( Guid.Empty ).CreateConnectionTestDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Checks the connection.
		/// </summary>
		/// <returns></returns>
		public bool CheckConnection() {
			try {
				return dal.CheckConnection();
			} catch {
				return false;
			}
		}

		#endregion

	}

}