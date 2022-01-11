using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.application.Settings
{
    public static class ConnectionStrings
    {
        public static string GetPostgreSqlDatabaseConnecitonString => EnvironmentSettings.Env switch
        {
            Environments.Docker => "User ID=postgres;Password=ikobatu;Host=postgresql_db;Port=5432;Database=payment_database;",
            Environments.Local => "User ID=postgres;Password=ikobatu;Host=localhost;Port=5432;Database=payment_database;",
            _ => throw new ArgumentOutOfRangeException()
        };

    }
}
