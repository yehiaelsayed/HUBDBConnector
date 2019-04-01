using HUBDBConnector.Model;
using HUBDBConnector.Utilities;
using JsonFlatFileDataStore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
//using Microsoft.Extensions.Configuration.Binder

namespace HUBDBConnector
{

    public class mode { public int Id { get; set; } public string name { get; set; } }
    class Program
    {
        static void Main(string[] args)
        {
            var config = Config.Build();
            var dbContext = new DBConnector(config.ConnectionString);
            var logger = new Logger();
            var lastRunDate = DateTime.Now;
            var lastRunCollection = logger.GetCollection<AppLog>("AppLog");

            if (lastRunCollection.Count > 0)
            {
                lastRunDate = lastRunCollection.AsQueryable().Max(x => x.LastRunDate);
            }

            dbContext.OpenConnection();

            var queryresult = dbContext.ExcuteQuery($"Select * from [User] where Created >= {lastRunDate.ToString()}");
            


            var request = RestClientHelber.CreateRequest(config.APIUrl, RestSharp.Method.GET);

            var restCallresult = RestClientHelber.ExecuteRequest(request);


            lastRunCollection.InsertOne(new AppLog() { LastRunDate = DateTime.Now });
            dbContext.CloseConnection();

            Console.ReadLine();
        }
    }
}
