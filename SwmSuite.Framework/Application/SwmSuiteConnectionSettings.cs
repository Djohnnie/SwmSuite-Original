using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;

namespace SwmSuite.Framework.Application {

	[Serializable]
	public class SwmSuiteConnectionSettings {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the connection mode.
		/// </summary>
		/// <value>The connection mode.</value>
		public SwmSuiteConnectionMode ConnectionMode { get; set; }

		/// <summary>
		/// Gets the connection mode string.
		/// </summary>
		/// <value>The connection mode string.</value>
		public String ConnectionModeString {
			get {
				switch( this.ConnectionMode ) {
					case SwmSuiteConnectionMode.FatClient: {
							return "SwmSuite.Proxy.Inproc.ServiceBroker,SwmSuite.Proxy.Inproc";
						}
					case SwmSuiteConnectionMode.SmartClient: {
							return "SwmSuite.Proxy.WebService.ServiceBroker,SwmSuite.Proxy.WebService";
						}
				}
				return String.Empty;
			}
		}

		/// <summary>
		/// Gets or sets the connection string configuration.
		/// </summary>
		/// <value>The connection string configuration.</value>
		public SwmSuiteConnectionStringConfiguration ConnectionStringConfiguration { get; set; }

		/// <summary>
		/// Gets or sets the connection string.
		/// </summary>
		/// <value>The connection string.</value>
		public String ConnectionString {
			get {
				return this.ConnectionStringConfiguration.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the connection target.
		/// </summary>
		/// <value>The connection target.</value>
		public String ConnectionTarget { get; set; }

		/// <summary>
		/// Gets or sets the connection proxy address.
		/// </summary>
		/// <value>The connection proxy address.</value>
		public String ConnectionProxyAddress { get; set; }

		/// <summary>
		/// Gets or sets the connection proxy port.
		/// </summary>
		/// <value>The connection proxy port.</value>
		public String ConnectionProxyPort { get; set; }

		/// <summary>
		/// Gets or sets the dal factory.
		/// </summary>
		/// <value>The dal factory.</value>
		public String DalFactory { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="SwmSuiteConnectionSettings"/> class.
		/// </summary>
		public SwmSuiteConnectionSettings() {
			this.ConnectionMode = SwmSuiteConnectionMode.SmartClient;
			this.ConnectionStringConfiguration = new SwmSuiteConnectionStringConfiguration();
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Saves the specified settings to file.
		/// </summary>
		/// <param name="settings">The settings.</param>
		/// <param name="file">The file.</param>
		public static void Save( SwmSuiteConnectionSettings settings , String file ) {
			StreamWriter writer = File.CreateText( file );
			XmlSerializer serializer = new XmlSerializer( typeof( SwmSuiteConnectionSettings ) );
			serializer.Serialize( writer , settings );
			writer.Flush();
			writer.Close();
			writer.Dispose();
		}

		/// <summary>
		/// Loads the specified settings from file.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <returns></returns>
		public static SwmSuiteConnectionSettings Load( String file ) {
			SwmSuiteConnectionSettings settingsToReturn;
			StreamReader reader = File.OpenText( file );
			XmlSerializer serializer = new XmlSerializer( typeof( SwmSuiteConnectionSettings ) );
			settingsToReturn = (SwmSuiteConnectionSettings)serializer.Deserialize( reader );
			reader.Close();
			reader.Dispose();
			return settingsToReturn;
		}

		/// <summary>
		/// Saves the settings to a specified file.
		/// </summary>
		/// <param name="file">The file.</param>
		public void Save( String file ) {
			SwmSuiteConnectionSettings.Save( this , file );
		}

		/// <summary>
		/// Check if the settings file exists.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <returns></returns>
		public static bool SettingsExist( String file ) {
			return File.Exists( file );
		}

		/// <summary>
		/// Writes to application configuration.
		/// </summary>
		/// <param name="exePath">The exe path.</param>
		public void WriteToApplicationConfiguration( string exePath ) {
			//Configuration config = ConfigurationManager.OpenExeConfiguration( exePath );
			//config.AppSettings.Settings.Add( "DalFactory" , this.DalFactory );
			//config.AppSettings.Settings.Add( "ServiceBroker" , this.ConnectionMode );
			//config.AppSettings.Settings.Add( "ServiceAddress" , this.ConnectionTarget );
			//config.AppSettings.Settings.Add( "ConnectionString" , this.ConnectionString );
			//config.AppSettings.Settings.Add( "ConnectionProxyAddress" , this.ConnectionProxyAddress );
			//config.AppSettings.Settings.Add( "ConnectionProxyPort" , this.ConnectionProxyPort );
			//if( config.ConnectionStrings.ConnectionStrings.
			//config.ConnectionStrings.ConnectionStrings.Add( new ConnectionStringSettings( "SwmSuite" , this.ConnectionString , "System.Data.SqlClient" ) );
		}

		#endregion

	}

}
