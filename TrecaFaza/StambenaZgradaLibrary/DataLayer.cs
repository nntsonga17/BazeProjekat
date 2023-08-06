using System;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;

namespace StambenaZgradaLibrary
{
    internal static class DataLayer
    {
        private static ISessionFactory? _factory = null;
        private static readonly object objLock = new();


        //funkcija na zahtev otvara sesiju
        public static ISession? GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory ??= CreateSessionFactory();
                }
            }

            return _factory?.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory? CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ShowSql()
                .ConnectionString(c =>
                    c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S18309;Password=NikolaMilenaMasa"));

                return Fluently.Configure()
                    .Database(cfg.ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .BuildSessionFactory();
            }
            catch (Exception ec)
            {
                //ErrorHandler.HandleError(ec);
                return null;
            }

        }
    }
}
