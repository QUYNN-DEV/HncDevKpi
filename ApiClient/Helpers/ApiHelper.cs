using RestSharp;
using System.Configuration;
using System.Net;

namespace ApiClient.Helpers
{
    public class ApiHelper
    {
        private static string tokenKey = ConfigurationManager.AppSettings["tokenKey"];
        private static string tokenKeyMobile = ConfigurationManager.AppSettings["tokenKeyMobile"];
        private static string baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        public static string GetJsonString(string url, string team)
        {
            string fullUrl = baseUrl + url;
            var client = new RestClient(fullUrl);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", team == "ERP" ? tokenKey : tokenKeyMobile));
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Content;
            }
            return string.Empty;
        }

        public static bool CreateObject<T>(string url, T obj, string team)
        {
            string json = JsonHelper.SerializeObject(obj);
            string fullUrl = baseUrl + url;
            var client = new RestClient(fullUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", team == "ERP" ? tokenKey : tokenKeyMobile));
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return true;
            }
            return false;
        }

        public static bool UpdateObject<T>(string url, T obj, string team)
        {
            string json = JsonHelper.SerializeObject(obj);
            string fullUrl = baseUrl + url;
            var client = new RestClient(fullUrl);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", team == "ERP" ? tokenKey : tokenKeyMobile));
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public static bool DeleleObject(string url, string team)
        {
            string fullUrl = baseUrl + url;
            var client = new RestClient(fullUrl);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", team == "ERP" ? tokenKey : tokenKeyMobile));
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
