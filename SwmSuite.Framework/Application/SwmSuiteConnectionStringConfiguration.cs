using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.Framework.Application {
	
	public class SwmSuiteConnectionStringConfiguration {

		#region -_ Private Members _-

		private String _server;

		private AuthenticationMode _authentication;

		private String _username;

		private String _password;

		private String _database;

		#endregion

		#region -_ Private Members _-

		public event EventHandler<EventArgs> ConfigurationChanged;

		public String Server {
			get {
				return _server;
			}
			set {
				_server = value;
				RaiseConfigurationChanged();
			}
		}

		public AuthenticationMode Authentication {
			get {
				return _authentication;
			}
			set {
				_authentication = value;
				RaiseConfigurationChanged();
			}
		}

		public String Username {
			get {
				return _username;
			}
			set {
				_username = value;
				RaiseConfigurationChanged();
			}
		}

		public String Password {
			get {
				return _password;
			}
			set {
				_password = value;
				RaiseConfigurationChanged();
			}
		}

		public String Database {
			get {
				return _database;
			}
			set {
				_database = value;
				RaiseConfigurationChanged();
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SwmSuiteConnectionStringConfiguration() {
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="server"></param>
		/// <param name="authentication"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="database"></param>
		public SwmSuiteConnectionStringConfiguration( String server ,AuthenticationMode authentication , String username , String password,String database ) {
			this.Server = server;
			this.Authentication = authentication;
			this.Username = username;
			this.Password = password;
			this.Database = database;
		}

		#endregion

		#region -_ Public Methods _-

		public override string ToString() {
			String server = @"Data Source=" + this.Server + "; ";
			String database = @"Initial Catalog=" + this.Database + "; ";
			String connectionTimeOut = @"Connect Timeout=30; ";
			String authentication = "";
			switch( this.Authentication ) {
				case AuthenticationMode.Windows: {
					authentication = @"Integrated Security=SSPI; ";
					break;
				}
				case AuthenticationMode.SqlServer: {
					authentication = @"User Id=" + this.Username + "; Password=" + this.Password + "; ";
					break;
				}
			}
			return server + database + connectionTimeOut + authentication;
		}

		public string ToStringNoDatabase() {
			String server = @"Data Source=" + this.Server + "; ";
			String connectionTimeOut = @"Connect Timeout=30; ";
			String authentication = "";
			switch( this.Authentication ) {
				case AuthenticationMode.Windows: {
					authentication = @"Integrated Security=SSPI; ";
					break;
				}
				case AuthenticationMode.SqlServer: {
					authentication = @"User Id=" + this.Username + "; Password=" + this.Password + "; ";
					break;
				}
			}
			return server + connectionTimeOut + authentication;
		}

		#endregion

		#region -_ Private Methods _-

		private void RaiseConfigurationChanged() {
			if( this.ConfigurationChanged != null ) {
				ConfigurationChanged( this , new EventArgs() );
			}
		}

		#endregion

	}
}
