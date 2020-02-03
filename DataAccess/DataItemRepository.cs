using mvvm2.Model;
using mvvm2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace mvvm2.DataAccess
{
   public class DataItemRepository
    {
        private RestSharp.RestClient client;
        private DataItem dataItem;
        private HttpClient httpClient;
        public ObservableCollection<DataItem> DataItems { get; private set; }

        public DataItemRepository()
        {
            client = new RestClient(Settings.Default.WebService);
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Settings.Default.WebService);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            DataItems = new ObservableCollection<DataItem>();
          
        }

        public void GetData()
        {
            var request = new RestRequest("api/values", DataFormat.Json);

            var response = client.Get(request);

            var dataItem = JsonConvert.DeserializeObject<DataItem>(response.Content);

           
            if (dataItem != null)
            {
                DataItems.Add(dataItem);
            }
        }

        public void GetDataHttp()
        {
            HttpResponseMessage httpResponse = httpClient.GetAsync("api/values").Result;
            if(httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;

                dataItem = JsonConvert.DeserializeObject<DataItem>(result);
                if(dataItem!=null)
                {
                    DataItems.Add(dataItem);
                }
            }
        }



    }
}
