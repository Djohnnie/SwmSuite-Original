using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Win32;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;

namespace SwmSuite.Configuration {
	
	public class ConfigUtil {

		#region -_ Private Members _-

		private static string m_AppKey = Registry.CurrentUser.Name + "\\SwmSuite";

		#endregion

		#region -_ Private Members _-

		public const String ConnectionString = "ConnectionString";

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Retrieves the windows registry value associated with the specified key.
		/// If the key is not found, returns null.
		/// </summary>
		/// <param name="key">The key of the value to retrieve.</param>
		/// <returns>The value for the specified key.</returns>
		public static string GetConfigString( string key ) {
			
			//return (string)Registry.GetValue( Registry.CurrentUser.Name + "\\SwmSuite" , key , null );
			if( Array.IndexOf( ConfigurationManager.AppSettings.AllKeys , key ) == -1 ) {
				// TODO: Globalization
				string message = String.Format( CultureInfo.InvariantCulture , "Entry with name {0} not found in AppSettings." , key );
				EventLog.WriteEntry( "SwmSuite" , message , EventLogEntryType.Error );
				throw new InvalidOperationException( message );
			}
			string valueToReturn = ConfigurationManager.AppSettings[key];
			if( String.IsNullOrEmpty( valueToReturn ) ) {
				// TODO: Globalization
				string message = String.Format( "Entry with name {0} in AppSettings has empty value." , key );
				EventLog.WriteEntry( "SwmSuite" , message , EventLogEntryType.Error );
				throw new InvalidOperationException( message );
			}
			return valueToReturn;
		}

		/// <summary>
		/// Sets a new windows registry value for the key specified.
		/// </summary>
		/// <param name="key">The key for the value to set.</param>
		/// <param name="value">The new value to set.</param>
		public static void SetConfigString( string key , string value ) {
			Registry.SetValue( m_AppKey , key , value );
		}

		#endregion

	}

}
