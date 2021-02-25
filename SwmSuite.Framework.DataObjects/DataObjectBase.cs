using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class DataObjectBase {

		#region -_ Public Properties _-

		public virtual int SysId { get; set; }

		public virtual int RowVersion { get; set; }

		public virtual Guid CreatedBy { get; set; }

		public virtual DateTime CreatedOn { get; set; }

		public virtual Guid EditedBy { get; set; }

		public virtual DateTime EditedOn { get; set; }

		#endregion

	}

}
