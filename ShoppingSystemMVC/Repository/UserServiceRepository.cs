using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ShoppingSystemMVC.Repository
{
    public class UserServiceRepository
    {
        HttpClient client;
        public UserServiceRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiBaseURL"].ToString());
        }

        public HttpResponseMessage GetResponse(string url)
        {
            return client.GetAsync(url).Result;
        }

        public HttpResponseMessage PostResponse(string url, object content)
        {
            return client.PostAsJsonAsync(url, content).Result;
        }

        public HttpResponseMessage DeleteResponse(string url, int id)
        {
            return client.DeleteAsync(url + id.ToString()).Result;
        }

        //TO update 
        #region TO UPDATE
        public HttpResponseMessage UpdateReposne(string url, int id)
        {
            return client.GetAsync(url + id.ToString()).Result;
        }

        public HttpResponseMessage EditResponse(string url, object content)
        {
            return client.PostAsJsonAsync(url, content).Result;
        }
        #endregion

        public HttpResponseMessage VerifyLogin(string url, object model)
        {
            return client.PostAsJsonAsync(url, model).Result;
        }
    }
}