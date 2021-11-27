using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Configuration;

namespace Reviefy.DAL
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name             { get; set; }
        public string ProviderName     { get; set; }
        public bool   IsGlobal         => false;
    }

    public class MySettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders
            => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider  => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name             = "Reviefy",
                        ProviderName     = ProviderName.SqlServer,
                        ConnectionString =
                            @"Server=.\;Database=reviefydb;Trusted_Connection=True;Enlist=False;"
                    };
            }
        }
    }
}