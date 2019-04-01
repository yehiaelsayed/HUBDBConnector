using JsonFlatFileDataStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HUBDBConnector.Utilities
{
    /// <summary>
    /// Flat file data storage [json format] and it supports all linq query 
    /// </summary>
    public static class Logger
    {
        private static DataStore _jsonDataStore = new DataStore($"{Directory.GetCurrentDirectory()}\\log.db");

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">input to save in collection</param>
        /// <param name="collectionName">the name of collection something like table (it will be created if not exists)</param>
        public static void Insert<T>(T input) where T : class
        {
            var collection = GetCollection<T>();
            collection.InsertOne(input);
        }

        public static void InsertMany<T>(List<T> input) where T : class
        {
            var collection = GetCollection<T>();
            collection.InsertMany(input);
        }

        public static IDocumentCollection<T> GetCollection<T>() where T : class
        {
            var collection = _jsonDataStore.GetCollection<T>();
            return collection;
        }


    }
}
