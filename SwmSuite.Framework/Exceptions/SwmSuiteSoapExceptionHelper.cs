using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web.Services.Protocols;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace SwmSuite.Framework.Exceptions {
	
	/// <summary>
  /// Class that provides methods to wrap and unwrap an Exception into a SoapException.
  /// </summary>
	public static class SwmSuiteSoapExceptionHelper {

		// Modify this line to change element's name or namespace...
		static private readonly XmlQualifiedName exceptionElementName =
				new XmlQualifiedName(
					"innerException" ,
					"SimpleWorkfloorManagementSuiteNameSpace" );

		// We need this class to create the nodes.    
		static private XmlDocument doc = new XmlDocument();

		/// <summary>
		/// Wrap an Exception into a SoapException.
		/// </summary>
		/// <param name="ex">The Exception to handle.</param>
		/// <param name="source">The Exception contents.</param>
		/// <returns>A SoapException that wraps the original Exception</returns>
		/// <remarks>The SoapException is constructed using XML.</remarks>
		static public SoapException WrapException( object source , Exception ex ) {
			if( ex == null ) { throw new ArgumentNullException( "ex" ); }
			SoapException wrapper = new SoapException(
					ex.InnerException != null ? ex.InnerException.Message : "" ,
				SoapException.DetailElementName ,
				BuildActor( source ) ,
				BuildDetailNode( ex ) ,
				ex );
			return wrapper;
		}

		/// <summary>
		/// Unwrap a SoapException that has been constructed by WrapException() and retrieve the original Exception.
		/// </summary>
		/// <param name="ex">The SoapException to handle.</param>
		/// <returns>The Exception that is wrapped in the SoapException.</returns>
		static public Exception UnwrapException( SoapException ex ) {
			return GetExceptionFromDetailNode( ex );
		}

		static private string BuildActor( object source ) {
			StringBuilder bob = new StringBuilder( "http://" );
			bob.Append( Dns.GetHostName() ).Append( "/" );
			bob.Append( "ThrowException" ).Append( "/" );
			bob.Append( source.ToString().Replace( "." , "/" ) );
			bob.Append( ".asmx" );
			return bob.ToString();
		}

		static private XmlNode BuildDetailNode( Exception ex ) {
			// First create the detail node as required
			XmlNode detailNode = doc.CreateElement(
				SoapException.DetailElementName.Name ,
				SoapException.DetailElementName.Namespace );
			// Add encoded custom exception
			detailNode.AppendChild( CreateExceptionNode( ex ) );
			return detailNode;
		}

		static private Exception GetExceptionFromDetailNode( SoapException ex ) {
			foreach( XmlNode child in ex.Detail.ChildNodes ) {
				if( child.Name == ExceptionElementName.Name )
					return GetExceptionFromNode( child );
			}
			return ex;
		}

		static private XmlNode CreateExceptionNode( Exception ex ) {
			string stringizedException = Exception2String( ex );
			XmlNode exceptionNode = doc.CreateElement(
			 ExceptionElementName.Name ,
			 ExceptionElementName.Namespace );
			exceptionNode.InnerText = stringizedException;
			return exceptionNode;
		}

		static private Exception GetExceptionFromNode( XmlNode exceptionNode ) {
			return String2Exception( exceptionNode.InnerText );
		}

		static private string Exception2String( Exception ex ) {
			return Exception2String( ex , new BinaryFormatter()/*new SoapFormatter()*/);
		}

		static private string Exception2String( Exception ex , IFormatter formatter ) {
			string encodedString;
			using( MemoryStream ms = new MemoryStream() ) {
				formatter.Serialize( ms , ex );
				encodedString = Convert.ToBase64String( ms.GetBuffer() );
			}
			return encodedString;
		}

		static private Exception String2Exception( string encodedString ) {
			return String2Exception( encodedString , new BinaryFormatter()/*new SoapFormatter()*/);
		}

		static private Exception String2Exception( string encodedString , IFormatter formatter ) {
			MemoryStream ms = new MemoryStream( Convert.FromBase64String( encodedString ) );
			return formatter.Deserialize( ms ) as Exception;
		}

		/// <summary>
		/// Get the name of the XML element that contains the Exception.
		/// </summary>
		static public XmlQualifiedName ExceptionElementName {
			get {
				return exceptionElementName;
			}
		}
	}
}
