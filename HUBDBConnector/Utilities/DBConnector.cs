using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HUBDBConnector.Utilities
{
    public class DBConnector
    {
        private SqlConnection _connection { get; set; }
        public DBConnector(string connString)
        {
            _connection = new SqlConnection(connString);
        }

        public void OpenConnection()
        {
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        /// <summary>
        /// execute query and map query result to JObject dynamicly so you can map it to any model easily
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JArray ExcuteQuery(string query)
        {
            var command = new SqlCommand(query, _connection);
         
            JArray rows = new JArray();

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    JObject row = new JObject();
                    for (var i=0; i < dataReader.FieldCount; i++) {
                        row[dataReader.GetName(i)] =JToken.FromObject(dataReader[i]);
                    }
                    rows.Add(row);
                }
            }

            return rows;

        }


    }
}
