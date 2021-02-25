using System;
using System.Collections.Generic;

using System.Text;
using System.Reflection;
using SwmSuite.Configuration;
using System.Globalization;
using SwmSuite.Framework.Application;
using System.Net;
using SwmSuite.Data.BusinessObjects;


namespace SwmSuite.Proxy.WebService {

	/// <summary>
	/// Base class for service facades.
	/// </summary> 
	public abstract class ServiceFacade<TService , TSoapHeader>
		where TService : class
		where TSoapHeader : class {

		private TService _service;

		public TService GetService() {
			if( _service == null ) {
				_service = GetService<TService , TSoapHeader>();
			}
			return _service;
		}

		/// <summary>
		/// Create a service instance.
		/// </summary>
		/// <typeparam name="T">Type of service to create.</typeparam>
		/// <typeparam name="K">Type of soapheader.</typeparam>
		/// <returns></returns>
		public static T1 GetService<T1 , T2>()
			where T1 : class
			where T2 : class {
			PropertyInfo p;

			// Create the webservice.
			T1 service = Activator.CreateInstance<T1>();

			// Create a new soapheader.
			T2 soapHeader = Activator.CreateInstance<T2>();

			// Fill the soapheader.
			if( SwmSuitePrincipal.CurrentEmployee != null ) {
				p = soapHeader.GetType().GetProperty( "UserName" );
				p.SetValue( soapHeader , SwmSuitePrincipal.CurrentEmployee.UserName , null );
				p = soapHeader.GetType().GetProperty( "Password" );
				p.SetValue( soapHeader , SwmSuitePrincipal.CurrentEmployee.Password , null );
				p = soapHeader.GetType().GetProperty( "Employee" );
				p.SetValue( soapHeader , SwmSuitePrincipal.CurrentEmployee.SysId , null );
			}

			// Assign the soapheader to the webservice.
			p = service.GetType().GetProperty( "SwmSuiteSoapHeaderValue" );
			p.SetValue( service , soapHeader , null );

			// Set the service URL.
			p = service.GetType().GetProperty( "Url" );
			string currentUrl = (string)p.GetValue( service , null );
			p.SetValue( service , ConfigureUrl( new Uri( currentUrl ) , SwmSuiteSettings.ConnectionSettings.ConnectionTarget ).ToString() , null );

			if( !String.IsNullOrEmpty( SwmSuiteSettings.ConnectionSettings.ConnectionProxyAddress ) && !String.IsNullOrEmpty( SwmSuiteSettings.ConnectionSettings.ConnectionProxyPort ) ) {
				WebProxy webProxy = new WebProxy( "http://" + SwmSuiteSettings.ConnectionSettings.ConnectionProxyAddress + ":" + SwmSuiteSettings.ConnectionSettings.ConnectionProxyPort + "/" , true );
				p = service.GetType().GetProperty( "Proxy" );
				p.SetValue( service , webProxy , null );
			}

			return service;
		}

		/// <summary>
		/// Replace the host address of a Url by a host address from configuration.
		/// </summary>
		/// <param name="uri">A valid Url.</param>
		/// <param name="hostAddress">The host address.</param>
		/// <returns></returns>
		public static Uri ConfigureUrl( Uri uri , string hostAddress ) {
			Uri newUri;
			UriBuilder builder = new UriBuilder( uri );
			builder.Port = -1;
			builder.Host = hostAddress;
			// Somehow "localhost" is replaced by "[localhost]", this can not be changed in the host member.
			builder.Host = builder.Host.Replace( "[" , "" );
			builder.Host = builder.Host.Replace( "]" , "" );
			newUri = builder.Uri;
			return newUri;
		}

	}

}