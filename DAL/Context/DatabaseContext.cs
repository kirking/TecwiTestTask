using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                optionsBuilder.UseSqlServer(settings.sqlConnectionString);
                databaseOptions = optionsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> optionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> databaseOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }

        public static readonly OptionsBuild options = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
