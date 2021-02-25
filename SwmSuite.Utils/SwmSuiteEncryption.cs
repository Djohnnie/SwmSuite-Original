using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace SwmSuite.Utils {

	public class SwmSuiteEncryption {

		public enum CryptType {
			Encrypt ,
			Decrypt
		}

		public static string Crypt( string data , string password , CryptType cryptType ) {
			byte[] u8_Salt = new byte[] { 0x26 , 0x19 , 0x81 , 0x4E , 0xA0 , 0x6D , 0x95 , 0x34 , 0x26 , 0x75 , 0x64 , 0x05 , 0xF6 };

			PasswordDeriveBytes i_Pass = new PasswordDeriveBytes( password , u8_Salt );

			Rijndael i_Alg = Rijndael.Create();
			i_Alg.Key = i_Pass.GetBytes( 32 );
			i_Alg.IV = i_Pass.GetBytes( 16 );

			ICryptoTransform i_Trans = ( cryptType == CryptType.Encrypt ) ? i_Alg.CreateEncryptor() : i_Alg.CreateDecryptor();

			MemoryStream i_Mem = new MemoryStream();
			CryptoStream i_Crypt = new CryptoStream( i_Mem , i_Trans , CryptoStreamMode.Write );

			byte[] u8_Data;
			if( cryptType == CryptType.Encrypt )
				u8_Data = Encoding.Unicode.GetBytes( data );
			else
				u8_Data = Convert.FromBase64String( data );

			try {
				i_Crypt.Write( u8_Data , 0 , u8_Data.Length );
				i_Crypt.FlushFinalBlock();
				i_Crypt.Close();
				if( cryptType == CryptType.Encrypt )
					return Convert.ToBase64String( i_Mem.ToArray() );
				else
					return Encoding.Unicode.GetString( i_Mem.ToArray() );
			} catch { return null; }
		}

	}

}
