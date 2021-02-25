using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the UserBll methods.
	/// </summary>
	[TestClass()]
	public class UserBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;
		private TransactionScope mainScope;
		private UserBll _userBll = new UserBll();

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the test context which provides
		/// information about and functionality for the current test run.
		/// </summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		#endregion

		#region -_ Additional test attributes _-

		/// <summary>
		/// Method called uppon initializing this test class.
		/// </summary>
		/// <param name="testContext">The test context.</param>
		[ClassInitialize()]
		public static void MyClassInitialize( TestContext testContext ) {
		}

		/// <summary>
		/// Method called uppon cleaning up this test class.
		/// </summary>
		[ClassCleanup()]
		public static void MyClassCleanup() {
		}

		/// <summary>
		/// Method called uppon initializing a test from this test class.
		/// </summary>
		[TestInitialize()]
		public void MyTestInitialize() {
			mainScope = new TransactionScope( TransactionScopeOption.Required );
			UnitTestUtils.ClearDatabase();
		}

		/// <summary>
		/// Method called uppon cleaning up a test from this test class.
		/// </summary>
		[TestCleanup()]
		public void MyTestCleanup() {
			mainScope.Dispose();
		}

		#endregion

		#region -_ Business Test Methods _-

		/// <summary>
		/// Test the AuthenticateUser bll method.
		/// </summary>
		[TestMethod]
		public void Business_AuthenticateUserTest() {
			_userBll.CreateUser( "UnitTestUser" , "pa$$w0rd" , "a@a.a" );
			Assert.IsTrue( _userBll.AuthenticateUser( "UnitTestUser" , "pa$$w0rd" ) );
		}

		/// <summary>
		/// Test the CreateUser bll method.
		/// </summary>
		[TestMethod]
		public void Business_CreateUserTest() {
			Guid newUserId =
				_userBll.CreateUser( "UnitTestUser" , "pa$$w0rd" , "a@a.a" );
			Assert.AreNotEqual( Guid.Empty , newUserId );
			Assert.IsTrue( _userBll.AuthenticateUser( "UnitTestUser" , "pa$$w0rd" ) );
		}

		/// <summary>
		/// Test the DeleteUserTest bll method.
		/// </summary>
		[TestMethod]
		public void Business_DeleteUserTest() {
			_userBll.CreateUser( "UnitTestUser" , "pa$$w0rd" , "a@a.a" );
			Assert.IsTrue( _userBll.AuthenticateUser( "UnitTestUser" , "pa$$w0rd" ) );
			Assert.IsTrue( _userBll.DeleteUser( "UnitTestUser" ) );
			Assert.IsFalse( _userBll.AuthenticateUser( "UnitTestUser" , "pa$$w0rd" ) );
		}

		/// <summary>
		/// Test the ChangePassword bll method.
		/// </summary>
		[TestMethod]
		public void Business_ChangePasswordTest() {
			_userBll.CreateUser( "UnitTestUser" , "pa$$w0rd" , "a@a.a" );
			Assert.IsTrue( _userBll.AuthenticateUser( "UnitTestUser" , "pa$$w0rd" ) );
			Assert.IsTrue( _userBll.ChangePassword( "UnitTestUser" , "pa$$w0rd" , "test" ) );
			Assert.IsFalse( _userBll.AuthenticateUser( "UnitTestUser" , "pa$$w0rd" ) );
			Assert.IsTrue( _userBll.AuthenticateUser( "UnitTestUser" , "test" ) );
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
