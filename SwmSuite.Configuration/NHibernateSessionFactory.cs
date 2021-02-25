using System;
using System.Collections.Generic;

using System.Text;
using System.Reflection;

namespace SwmSuite.Configuration {

	public class NHibernateSessionFactory {

		private static NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
		private static NHibernate.ISessionFactory sessionFactory = null;

		static NHibernateSessionFactory() {
			// set provider & driver properties
			cfg.Properties.Add( NHibernate.Cfg.Environment.ConnectionProvider ,
					"NHibernate.Connection.DriverConnectionProvider" );
			cfg.Properties.Add( NHibernate.Cfg.Environment.ConnectionDriver ,
					"NHibernate.Driver.SqlClientDriver" );
			cfg.Properties.Add( NHibernate.Cfg.Environment.Dialect ,
					"NHibernate.Dialect.MsSql2005Dialect" );
			cfg.Properties.Add( NHibernate.Cfg.Environment.MaxFetchDepth ,
					"-1" ); // allows for unlimited outer joins (recommeded value is maximum 4
			cfg.Properties.Add( NHibernate.Cfg.Environment.ConnectionString ,
					"Server=.\\SQLEXPRESS;initial catalog=swms;Trusted_Connection=yes" );

			//// here we add all the needed assemblies that contain mappings or objects
			//if( System.IO.File.Exists( "SwmSuite.FrameWork.dll" ) ) {
			//  // context is .net 2.0
			//  cfg.AddAssembly( Assembly.LoadFrom( "SwmSuite.FrameWork.dll" ) );
			//}

			// here we add all the needed assemblies that contain mappings or objects
			if( System.IO.File.Exists( "SwmSuite.Framework.dll" ) ) {
				// context is .net 2.0
				cfg.AddAssembly( Assembly.LoadFrom( "SwmSuite.Framework.dll" ) );
			}

			//cfg.AddDirectory(new System.IO.DirectoryInfo(@"c:\myproject\mappings"));
			//cfg.AddFile(@"c:\myproject\mappings\class1.hmb.xml");
			//cfg.AddInputStream(new System.IO.StringReader("..xml goes here.."));
			//cfg.AddClass(typeof(OrderSystem.Objects.Manufacturer));
			sessionFactory = cfg.BuildSessionFactory();
		}

		public static NHibernate.ISession OpenSession() {
			return sessionFactory.OpenSession();
		}

	}

}
