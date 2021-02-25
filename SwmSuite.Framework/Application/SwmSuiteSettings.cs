using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace SwmSuite.Framework.Application {
	
	public class SwmSuiteSettings {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the connection settings.
		/// </summary>
		/// <value>The connection settings.</value>
		public static SwmSuiteConnectionSettings ConnectionSettings { get; set; }

		#endregion



	}

}
