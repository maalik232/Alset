 using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AlsetMobileAttendence.Services
{
    public class APIService
    {
       

        string BaseURL = "https://d6otawvpj7.execute-api.us-east-1.amazonaws.com/dev/";
        HttpClient client;
        public APIService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseURL);
        }

        public async Task<T> makeAPICall<T>(T obj, string method )
        {
            try
            {
                
                    var json = JsonConvert.SerializeObject(obj);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(method, data);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<T>(content);
                    }

                    return obj;
            }
            catch (Exception ex)
            {
                throw;
            }

            return default;
        }

        public async Task<T> makeAPICallForUpdate<T>(T obj, string method)
        {
            try
            {
                var json = JsonConvert.SerializeObject(obj);
                var data = new StringContent(json, Encoding.UTF8, "application/image");

                var response = await client.PutAsync(method, data);

                if (response.IsSuccessStatusCode)
                {
                    //string content = await response.Content.ReadAsStringAsync();
                    //obj = JsonConvert.DeserializeObject<T>(content);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }

            return default;
        }



        public async Task<T> getDataList<T>(string url)
        {
            try
            {
                T Items;
             
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<T>(content);
                        return Items;
                    }
                
                return default;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
