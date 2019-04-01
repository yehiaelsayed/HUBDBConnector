using JsonFlatFileDataStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HUBDBConnector.Utilities
{
    public class Logger
    {
        private DataStore _jsonDataStore { get; set; }
        public Logger()
        {
            _jsonDataStore = new DataStore($"{Directory.GetCurrentDirectory()}\\log.db");
        }

        public void Insert<T>(T input, string collectionName) where T : class
        {
            var collection = GetCollection<T>(collectionName);
            collection.InsertOne(input);
        }

        public void InsertMany<T>(List<T> input, string collectionName) where T : class
        {
            var collection = GetCollection<T>(collectionName);
            collection.InsertMany(input);
        }

        public IDocumentCollection<T> GetCollection<T>(string collectionName) where T : class
        {
            var collection = _jsonDataStore.GetCollection<T>(collectionName);
            return collection;
        }


    }
}
