/***********
 * ObjectFactory.cs
 * 
 * 08/08/2008 - Created
 * 
 */

using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Configuration;

namespace SwmSuite.Utils {

	public static class ObjectFactory {

		///// <summary>
		///// Create an object that is defined by a configuration setting.
		///// </summary>
		///// <typeparam name="T">The type of the returned object.</typeparam>
		///// <param name="entryName">The name of the configuration setting.</param>
		///// <returns>The created object.</returns>
		///// <remarks>The object should be defined in configuration as AssemblyQualifiedName.</remarks>
		//public static T CreateObject<T>( string entryName ) where T : class {
		//    string typeName = ConfigUtil.GetConfigString( entryName );

		//    if( typeName == null ) {
		//        throw new ArgumentNullException( "entryName" );
		//    }
		//    try {
		//        Type objectType = Type.GetType( typeName , true , true );
		//        object obj = Activator.CreateInstance( objectType );
		//        T typedObject = obj as T;
		//        return typedObject;
		//    } catch( Exception ) {
		//        // TODO: Error Handling
		//        throw;
		//    }
		//}

		public static T CreateObject<T>( string typeName ) where T : class {
			Type objectType = Type.GetType( typeName , true , true );
			object obj = Activator.CreateInstance( objectType );
			T typedObject = obj as T;
			return typedObject;
		}

		//public static T CreateObject<T>( string temp , string typeName ) where T : class {
		//    if( typeName == null ) {
		//        throw new ArgumentNullException( "typeName" );
		//    }
		//    try {
		//        Type objectType = Type.GetType( typeName , true , true );
		//        object obj = Activator.CreateInstance( objectType );
		//        T typedObject = obj as T;
		//        return typedObject;
		//    } catch( Exception ) {
		//        // TODO: Error Handling
		//        throw;
		//    }
		//}
	}

}
