using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.Data.DataObjects {
	
	public class LogDeleteData {

		#region -_ Private Members _-

		#endregion

		#region -_ Private Members _-

		public const String DBColumnSysId = "SysId";
		public const String DBColumnTableName = "TableName";
		public const String DBColumnInfo = "Info";
		public const String DBColumnDeletedBy = "DeletedBy";
		public const String DBColumnDeletedOn = "DeletedOn";

		public const String DBParameterSysId = "@SysId";
		public const String DBParameterTableName = "@TableName";
		public const String DBParameterInfo = "@Info";
		public const String DBParameterDeletedBy = "@DeletedBy";
		public const String DBParameterDeletedOn = "@DeletedOn";

		#endregion

		#region -_ Public Properties _-

		public int SysId { get; set; }
		public String TableName { get; set; }
		public String Info { get; set; }
		public Guid DeletedBy { get; set; }
		public DateTime DeletedOn { get; set; }

		#endregion

		#region -_ Construction _-

		public LogDeleteData() {
		}

		public LogDeleteData( String tableName , String info , Guid deletedBy , DateTime deletedOn ) {
			this.TableName = tableName;
			this.Info = info;
			this.DeletedBy = deletedBy;
			this.DeletedOn = deletedOn;
		}

		#endregion

		#region -_ Public Methods _-

		public override string ToString( ) {
			return this.TableName + ": " + this.Info;
		}

		#endregion

	}

}
