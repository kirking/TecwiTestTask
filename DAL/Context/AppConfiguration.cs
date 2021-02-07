using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DAL.Context
{
    class AppConfiguration
    {
        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            var appSettings = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnectionString = appSettings.Value;
        }

        public string sqlConnectionString { get; set; }
    }
}
