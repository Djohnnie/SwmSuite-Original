using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using System.IO;

namespace SwmSuiteZipCodeManagement {

	public class ImportZipCode {

		#region -_ Static Methods _-

		/// <summary>
		/// Imports the zip codes.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns></returns>
		public static ZipCodeCollection ImportZipCodes( String fileName ) {
			ZipCodeCollection zipcodesToReturn = new ZipCodeCollection();
			String[] zipcodeLines = File.ReadAllLines( fileName, Encoding.Default );
			foreach( String zipcodeLine in zipcodeLines ) {
				ZipCode newZipCode = new ZipCode();
				String[] tokens = zipcodeLine.Split( ';' );
				if( tokens.Length == 2 ) {
					newZipCode.Code = tokens[0];
					newZipCode.City = tokens[1];
				}
				zipcodesToReturn.Add( newZipCode );
			}
			return zipcodesToReturn;
		}

		#endregion

	}
}
