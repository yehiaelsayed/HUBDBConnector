using HUBDBConnector.Model;
using HUBDBConnector.Utilities;
using JsonFlatFileDataStore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
//using Microsoft.Extensions.Configuration.Binder

namespace HUBDBConnector
{

    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                var config = Config.Build();
                var dbContext = new DBConnector(config.ConnectionString);
                var lastRunDate = DateTime.Parse("01-01-1991");
                var lastRunCollection = Logger.GetCollection<AppLog>();

                if (lastRunCollection.Count > 0)
                {
                    lastRunDate = lastRunCollection.AsQueryable().Max(x => x.LastRunDate);
                }

                dbContext.OpenConnection();

                var queryresult = dbContext.ExcuteQuery($"Select * from [User] where Created >= '{lastRunDate.ToString()}'");

                var users = queryresult.ToObject<List<User>>();
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.FullName} :: {user.Id}");

                    //                  var request = RestClientHelber.CreateRequest(config.APIUrl, RestSharp.Method.GET);

                    //                    var restCallresult = RestClientHelber.ExecuteRequest(request);

                    // in case of api call failed and you want to log the user object 
                    Logger.Insert<FaildUserLog>(new FaildUserLog() { UserFullName = user.FullName, UserId = user.Id, UserTenantId = user.TenantId ?? Guid.Empty });

                }

                lastRunCollection.InsertOne(new AppLog() { LastRunDate = DateTime.Now });
                dbContext.CloseConnection();

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Insert<RuntimeLog>(new RuntimeLog() { Message = ex.Message });
            }
        }
    }
}
