using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.BusinessObjects;
using System.IO;
using System.Drawing;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the AvatarBll methods.
	/// </summary>
	[TestClass()]
	public class AvatarBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private AvatarBll avatarBll = new AvatarBll();

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		#endregion

		#region -_ Additional Test Attributes _-

		[ClassInitialize()]
		public static void MyClassInitialize( TestContext testContext ) {
		}

		[ClassCleanup()]
		public static void MyClassCleanup() {
		}

		[TestInitialize()]
		public void MyTestInitialize() {
			mainScope = new TransactionScope( TransactionScopeOption.Required );
			UnitTestUtils.ClearDatabase();
		}

		[TestCleanup()]
		public void MyTestCleanup() {
			//mainScope.Complete();
			mainScope.Dispose();
		}

		#endregion

		#region -_ Business Test Methods _-

		[TestMethod]
		public void Business_GetAvatarTest() {
			Avatar avatar = new Avatar(SwmSuite.Business.UnitTest.Resources.avatar_unittests);
			avatarBll.CreateAvatar( avatar );
			AvatarCollection result = avatarBll.GetAvatars();
			Assert.AreEqual( 1 , result.Count );
			Avatar endResult = avatarBll.GetAvatar( result[0].SysId );
			Assert.AreEqual( Convert.ToBase64String( avatar.Picture ) , Convert.ToBase64String( endResult.Picture ) );
		}

		[TestMethod]
		public void Business_CreateAndGetAvatarTest() {
			Avatar avatar = new Avatar(SwmSuite.Business.UnitTest.Resources.avatar_unittests);
			avatarBll.CreateAvatar( avatar );
			AvatarCollection result = avatarBll.GetAvatars();
			Assert.AreEqual( 1 , result.Count );
			Assert.AreEqual( Convert.ToBase64String( avatar.Picture ) , Convert.ToBase64String( result[0].Picture ) );
		}

		[TestMethod]
		public void Business_UpdateAvatarTest() {
			Image avatarUnitTestImage = (Image)SwmSuite.Business.UnitTest.Resources.avatar_unittests.Clone();
			Image avatarUnittestImageToUpdate = (Image)SwmSuite.Business.UnitTest.Resources.avatar_unittests.Clone();
			avatarUnittestImageToUpdate.RotateFlip( RotateFlipType.Rotate180FlipNone );

			Avatar avatar = new Avatar(avatarUnitTestImage);
			avatarBll.CreateAvatar( avatar );
			AvatarCollection result = avatarBll.GetAvatars();
			Assert.AreEqual( 1 , result.Count );

			Avatar avatarToUpdate = result[0];
			avatarToUpdate.Image = avatarUnittestImageToUpdate;
			avatarBll.UpdateAvatar( avatarToUpdate );

			AvatarCollection endResult = avatarBll.GetAvatars();
			Assert.AreNotEqual( Convert.ToBase64String( avatar.Picture ) , Convert.ToBase64String( endResult[0].Picture ) );
			Assert.AreEqual( Convert.ToBase64String( avatarToUpdate.Picture ) , Convert.ToBase64String( endResult[0].Picture ) );
		}

		[TestMethod]
		public void Business_RemoveAvatarsTest() {
			Avatar avatar = new Avatar();
			avatar.Image = SwmSuite.Business.UnitTest.Resources.avatar_unittests;
			avatarBll.CreateAvatar( avatar );
			AvatarCollection result = avatarBll.GetAvatars();
			Assert.AreEqual( 1 , result.Count );

			avatarBll.RemoveAvatars( result );

			AvatarCollection endResult = avatarBll.GetAvatars();
			Assert.AreEqual( 0 , endResult.Count );
		}

		#endregion

		#region -_ Crud Test Methods _-

		/// <summary>
		/// A test for InsertAvatars (insert a single avatar).
		/// </summary>
		[TestMethod]
		public void Crud_InsertAvatarTest() {
			AvatarDataCollection avatars =
				AvatarDataCollection.FromSingleAvatar( new AvatarData( new byte[] { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 } ) );
			avatarBll.InsertAvatarData( avatars );
			AvatarDataCollection avatarsResult = avatarBll.GetAvatarData();
			AvatarUnitTestHelper.AreEqual( avatars , avatarsResult );
		}

		/// <summary>
		/// A test for InsertAvatars (insert multiple avatars).
		/// </summary>
		[TestMethod]
		public void Crud_InsertAvatarsTest() {
			AvatarDataCollection avatars = new AvatarDataCollection();
			avatars.Add( new AvatarData( new byte[] { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 } ) );
			avatars.Add( new AvatarData( new byte[] { 0 , 2 , 4 , 6 , 8 , 10 , 12 , 14 , 16 , 18 } ) );
			avatars.Add( new AvatarData( new byte[] { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 } ) );
			avatarBll.InsertAvatarData( avatars );
			AvatarDataCollection avatarsResult = avatarBll.GetAvatarData();
			AvatarUnitTestHelper.AreEqual( avatars , avatarsResult );
		}

		/// <summary>
		/// A test for UpdateAvatars (update a single avatar).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateAvatarTest() {
			AvatarDataCollection avatars =
				AvatarDataCollection.FromSingleAvatar( new AvatarData( new byte[] { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 } ) );
			avatarBll.InsertAvatarData( avatars );
			AvatarDataCollection avatarsToUpdate = avatarBll.GetAvatarData();
			AvatarUnitTestHelper.UpdateAvatars( avatarsToUpdate );
			avatarBll.UpdateAvatarData( avatarsToUpdate );
			AvatarDataCollection avatarsResult = avatarBll.GetAvatarData();
			AvatarUnitTestHelper.AreEqual( avatarsToUpdate , avatarsResult );
		}

		/// <summary>
		/// A test for UpdateAvatars (update multiple avatars).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateAvatarsTest() {
			AvatarDataCollection avatars = new AvatarDataCollection();
			avatars.Add( new AvatarData( new byte[] { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 } ) );
			avatars.Add( new AvatarData( new byte[] { 0 , 2 , 4 , 6 , 8 , 10 , 12 , 14 , 16 , 18 } ) );
			avatars.Add( new AvatarData( new byte[] { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 } ) );
			avatarBll.InsertAvatarData( avatars );
			AvatarDataCollection avatarsToUpdate = avatarBll.GetAvatarData();
			AvatarUnitTestHelper.UpdateAvatars( avatarsToUpdate );
			avatarBll.UpdateAvatarData( avatarsToUpdate );
			AvatarDataCollection avatarsResult = avatarBll.GetAvatarData();
			AvatarUnitTestHelper.AreEqual( avatarsToUpdate , avatarsResult );
		}

		/// <summary>
		/// A test for RemoveAvatars (remove a single avatar).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAvatarTest() {
			AvatarDataCollection avatars =
				AvatarDataCollection.FromSingleAvatar( new AvatarData( new byte[] { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 } ) );
			avatarBll.InsertAvatarData( avatars );
			AvatarDataCollection avatarsToRemove = avatarBll.GetAvatarData();
			avatarBll.RemoveAvatarData( avatarsToRemove );
			AvatarDataCollection avatarsResult = avatarBll.GetAvatarData();
			Assert.AreEqual( 0 , avatarsResult.Count , "The avatars should be removed!" );
			AvatarUnitTestHelper.AreInLogDeletes( avatarsToRemove );
		}

		/// <summary>
		/// A test for RemoveAvatars (remove multiple avatars).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveAvatarsTest() {
			AvatarDataCollection avatars = new AvatarDataCollection();
			avatars.Add( new AvatarData( new byte[] { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 } ) );
			avatars.Add( new AvatarData( new byte[] { 0 , 2 , 4 , 6 , 8 , 10 , 12 , 14 , 16 , 18 } ) );
			avatars.Add( new AvatarData( new byte[] { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 } ) );
			avatarBll.InsertAvatarData( avatars );
			AvatarDataCollection avatarsToRemove = avatarBll.GetAvatarData();
			avatarBll.RemoveAvatarData( avatarsToRemove );
			AvatarDataCollection avatarsResult = avatarBll.GetAvatarData();
			Assert.AreEqual( 0 , avatarsResult.Count , "The avatars should be removed!" );
			AvatarUnitTestHelper.AreInLogDeletes( avatarsToRemove );
		}

		#endregion

		#region -_ IDisposable Members _-

		public void Dispose() {
			Dispose( true );
			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// Corrected implementation
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose( bool disposing ) {
			if( disposing ) {
				// free managed resources
				if( mainScope != null ) {
					mainScope.Dispose();
					mainScope = null;
				}
			}
		}

		#endregion

	}

}
