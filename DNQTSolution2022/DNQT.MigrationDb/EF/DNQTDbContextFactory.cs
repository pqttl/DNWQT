using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DNQT.MigrationDb.EF
{
    public class DNQTDbContextFactory : IDesignTimeDbContextFactory<DNQTDbContext>
    {
        public DNQTDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionStringTemp = configuration.GetConnectionString("DNQTSolutionDb");
            var connectionString = configuration.GetSection("ConnectionStrings")["DNQTSolutionDb"];

            var optionsBuilder = new DbContextOptionsBuilder<DNQTDbContext>();
            optionsBuilder.UseSqlite(connectionString);

            return new DNQTDbContext(optionsBuilder.Options);
        }
    }
}
