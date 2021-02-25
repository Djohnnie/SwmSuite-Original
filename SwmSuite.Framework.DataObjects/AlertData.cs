using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class AlertData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the enabled state for this alert.
		/// </summary>
		public bool Visible { get; set; }

		/// <summary>
		/// Gets or sets the message for this alert.
		/// </summary>
		public String Message { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AlertData() {
			
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="visible">The enabled state for this alert.</param>
		/// <param name="message">The message for this alert.</param>
		public AlertData( bool visible , String message ) {
			this.RowVersion = 0;
			this.Visible = visible;
			this.Message = message;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this alert to its string representation.
		/// </summary>
		/// <returns>The message for this alert.</returns>
		public override string ToString( ) {
			return this.Message;
		}

		#endregion

	}

}
