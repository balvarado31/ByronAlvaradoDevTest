using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ByronAlvaradoDevTest.Tools
{
    public class HttpServiceClient
    {        
        public bool success;
        private HttpStatusCode statusCode;
        public string message;
        
        public TypeOfOutputClass Get<TypeOfOutputClass>(string Url)
        {
            TypeOfOutputClass response = default(TypeOfOutputClass);
            HttpClient client = new HttpClient();            
            client.DefaultRequestHeaders.Add(SystemConfig.APIHeaderKey(), SystemConfig.APIKey());
            client.DefaultRequestHeaders.Add(SystemConfig.APIHostKey(), SystemConfig.APIHost());
            HttpResponseMessage httpResponseMessage = client.GetAsync(Url).Result;  
            HttpContent httpContent = httpResponseMessage.Content;            
            success = httpResponseMessage.IsSuccessStatusCode;
            statusCode = httpResponseMessage.StatusCode;
            message = httpResponseMessage.ReasonPhrase;

            string jsonResult = httpContent.ReadAsStringAsync().Result;            
            response = JsonConvert.DeserializeObject<TypeOfOutputClass>(jsonResult,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return response;
        }
    }
}