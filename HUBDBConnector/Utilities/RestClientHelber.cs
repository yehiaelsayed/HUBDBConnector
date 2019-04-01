using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using RestSharp;
namespace HUBDBConnector.Utilities
{
    class RestClientHelber
    {
        private static RestClient _restClient = new RestClient();
        public static RestRequest CreateRequest(string url, Method method, object body = null)
        {
            var request = new RestRequest(url, method);
            request.AddJsonBody(body);
            return request;
        }

        public static JToken ExecuteRequest(RestRequest request)
        {
            JToken result;
            var response = _restClient.Execute(request);

            result = JToken.Parse(response.Content);
            
            return result;
        }
    }
}
