using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class AvatarUnitTestHelper {

		public static void AreEqual( AvatarDataCollection expected , AvatarDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " avatars expected, " + actual.Count.ToString() + " avatars actual!" );
			// Test individual avatars.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( ByteArrayToString( expected[i].Picture ) , ByteArrayToString( actual[i].Picture ) , "UT: expected Avatar.Picture (" + ByteArrayToString( expected[i].Picture ) + ") <> actual Avatar.Picture (" + ByteArrayToString( actual[i].Picture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( AvatarDataCollection avatars ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , avatars.Count , "UT: " + avatars.Count.ToString() + " avatars expected in LogDeletes, " + logDeletes.Count.ToString() + " avatars found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new AvatarSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( avatars[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateAvatars( AvatarDataCollection avatars ) {
			foreach( AvatarData avatar in avatars ) {
				byte[] oldPicture = avatar.Picture;
				byte[] newPicture = new byte[oldPicture.Length];
				for( int i = 0 ; i < oldPicture.Length ; i++ ) {
					newPicture[i] = oldPicture[oldPicture.Length - i - 1];
				}
				avatar.Picture = newPicture;
			}
		}

		public static string ByteArrayToString( byte[] byteArray ) {
			string toReturn = "{ ";
			for( int i = 0 ; i < byteArray.Length ; i++ ) {
				toReturn += byteArray[i].ToString() + ( ( i == byteArray.Length - 1 ) ? " }" : " , " );
			}
			return toReturn;
		}

	}

}
