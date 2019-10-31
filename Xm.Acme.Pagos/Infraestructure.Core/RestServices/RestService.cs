using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Core.RestServices.Interface;
using Newtonsoft.Json;

namespace Infraestructure.Core.RestServices
{
    public class RestService : IRestService
    {

        // Post
        public async Task<T> PostRestServiceAsync<T>(string url, string controller,
           string method, object parameters, IDictionary<string, string> headers)
        {
            var baseUrl = string.Format("{0}/{1}/{2}", url, controller, method);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (headers.Count > 0)
                    {
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }
                    HttpContent jsonObject = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                    HttpResponseMessage res = await client.PostAsync(baseUrl, jsonObject);

                    if (res.IsSuccessStatusCode)
                    {
                        var data = await res.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(data);
                    }

                    throw new Exception("Error al consummir el servicio");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        // Get
        public async Task<T> GetRestServiceAsync<T>(string url, string method,
            IDictionary<string, string> parameters, IDictionary<string, string> headers)
        {
            var baseUrl = string.Format("{0}/{1}", url, method);
            if (parameters.Count > 0)
                baseUrl = baseUrl + "?" + string.Join("&",
                    parameters.Select(p => p.Key + "=" + p.Value).ToArray());

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (headers.Count > 0)
                    {
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }

                    HttpResponseMessage res = await client.GetAsync(baseUrl);

                    if (res.IsSuccessStatusCode)
                    {
                        var data = await res.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(data);
                    }

                    throw new Exception("Error al consummir el servicio");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
