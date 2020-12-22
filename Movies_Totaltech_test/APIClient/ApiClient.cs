using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movies_Totaltech_test.APIClient
{
    public class ApiClient
    {
        public ApiClient()
        {

        }
        private static string BaseURL => "https://api.themoviedb.org/3/movie/";

        public async Task<T> ExecuteRequestAsync<T>(string url, RequestType method = RequestType.GET, string body = "") where T : new()
        {
            var result = new T();
            try
            {
                var responseMessage = new HttpResponseMessage();
                var httpClient = CreateApiClient();

                responseMessage = await GetResponse(httpClient, method, url, body);

                var content = responseMessage.Content.ReadAsStringAsync().Result;

                if (responseMessage.StatusCode == HttpStatusCode.OK || responseMessage.StatusCode == HttpStatusCode.NoContent)
                {
                    result = JsonConvert.DeserializeObject<T>(content);
                }
                else
                {
                    throw new ArgumentException($"Ocurrio un error {responseMessage.StatusCode.ToString()}, por favor intente en un momento");
                }

                httpClient.Dispose();
                responseMessage.Dispose();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("oops", ex.Message, "ok");
            }

            return result;
        }

        private HttpClient CreateApiClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseURL),
                Timeout = TimeSpan.FromSeconds(10)
            };
            return httpClient;
        }

        private async Task<HttpResponseMessage> GetResponse(HttpClient httpClient, RequestType method, string url, string body)
        {
            var responseMessage = new HttpResponseMessage();

            switch (method)
            {
                case RequestType.GET:
                    responseMessage = await httpClient.GetAsync(url);
                    break;

                case RequestType.PUT:
                    responseMessage = await httpClient.PutAsync(url, Content(body));
                    break;

                case RequestType.POST:
                    responseMessage = await httpClient.PostAsync(url, Content(body));
                    break;

                case RequestType.DELETE:
                    responseMessage = await httpClient.DeleteAsync(url);
                    break;
            }

            return responseMessage;
        }

        private StringContent Content(string body)
        {
            return new StringContent(body, Encoding.UTF8, "application/json");
        }
    }
}
