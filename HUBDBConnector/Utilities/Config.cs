using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HUBDBConnector.Utilities
{
    public class Config
    {
        public string ConnectionString { get; set; }

        public string APIUrl { get; set; }
        public static Config Build()
        {

            var config = new Config();

            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", true, true)
                .Build()
                .Bind(config);

            return config;

        }
    }
}
