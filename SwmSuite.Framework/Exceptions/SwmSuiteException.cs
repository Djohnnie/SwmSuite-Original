using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.Serialization;

namespace SwmSuite.Framework.Exceptions {

	[Serializable]
	public class SwmSuiteException : Exception {

		#region -_ Private Members _-

		public DateTime _exceptionDateTime;

		public SwmSuiteError _error;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the exception date time.
		/// </summary>
		/// <value>The exception date time.</value>
		public DateTime ExceptionDateTime {
			get {
				return _exceptionDateTime;
			}
			set {
				_exceptionDateTime = value;
			}
		}

		/// <summary>
		/// Gets or sets the error.
		/// </summary>
		/// <value>The error.</value>
		public SwmSuiteError Error {
			get {
				return _error;
			}
			set {
				_error = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="SwmSuiteException"/> class.
		/// </summary>
		public SwmSuiteException()
			: base() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SwmSuiteException"/> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// The <paramref name="info"/> parameter is null.
		/// </exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">
		/// The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0).
		/// </exception>
		protected SwmSuiteException( SerializationInfo info , StreamingContext context )
			: base( info.GetString( "_message" ) ) {
			this.ExceptionDateTime = info.GetDateTime( "_exceptionDateTime" );
			this.Error = (SwmSuiteError)info.GetByte( "_error" );
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SwmSuiteException( Exception e )
			: base( e.Message , e ) {
			this.ExceptionDateTime = DateTime.Now;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SwmSuiteException"/> class.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="error">The error.</param>
		/// <param name="description">The description.</param>
		public SwmSuiteException( Exception exception , SwmSuiteError error , String description )
			: base( description , exception ) {
			this.ExceptionDateTime = DateTime.Now;
			this.Error = error;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Creates and returns a string representation of the current exception.
		/// </summary>
		/// <returns>
		/// A string representation of the current exception.
		/// </returns>
		/// <PermissionSet>
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/>
		/// </PermissionSet>
		public override string ToString() {
			return base.Message;
		}

		#endregion

		/// <summary>
		/// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with information about the exception.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// The <paramref name="info"/> parameter is a null reference (Nothing in Visual Basic).
		/// </exception>
		/// <PermissionSet>
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/>
		/// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/>
		/// </PermissionSet>
		public override void GetObjectData( SerializationInfo info , StreamingContext context ) {
			base.GetObjectData( info , context );
			info.AddValue( "_exceptionDateTime" , this.ExceptionDateTime );
			info.AddValue( "_error" , this.Error );
			info.AddValue( "_message" , this.Message );
		}

	}
}
