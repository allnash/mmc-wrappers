using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading;
using SessionM.MMC.API;
using Newtonsoft.Json;

namespace SessionM.MMC.JsonService
{
    public class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler(HttpMessageHandler innerHandler): base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Request:");
            Console.WriteLine(request.ToString());
            if (request.Content != null)
            {
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }
            Console.WriteLine();

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine("Response:");
            Console.WriteLine(response.ToString());
            if (response.Content != null)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            Console.WriteLine();

            return response;
        }
    }

    public class AsyncClient
    {

        public static async Task<String> getResponseString(String Path)
        {
            HttpResponseMessage response;
            var client = new HttpClient(new LoggingHandler(new HttpClientHandler()));
            var byteArray = Encoding.ASCII.GetBytes(APIConstants.getCredentials());
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.BaseAddress = new Uri(Path);
            try
            {
                response = client.GetAsync(Path).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("DELETE SUCCESS\n");
                }
                else
                    Console.WriteLine("DELETE ERROR\n");

                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return "";
        }

        public static async Task<SMResponse> get(String path)
        {
            string responseString = await getResponseString(path);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            return m;
        }

        public static async Task<String> postResponseString(String Path, String JsonString)
        {
            HttpResponseMessage response;
            CancellationTokenSource cts;
            cts = new CancellationTokenSource();
            HttpClient client = new HttpClient(new LoggingHandler(new HttpClientHandler()));
            var byteArray = Encoding.ASCII.GetBytes(APIConstants.getCredentials());
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(Path));
            request.Content = new StringContent(JsonString,
                                                Encoding.UTF8,
                                                "application/json");

            try
            {
                response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("POST SUCCESS\n");
                }
                else
                    Console.WriteLine("POST ERROR\n");

                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return "";
        }

        public static async Task<SMResponse> post(string path, SMRequest request)
        {
            string json = JsonConvert.SerializeObject(request, Formatting.Indented,
             new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, });
            string responseString = await postResponseString(path, json);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            return m;
        }

        public static async Task<String> putResponseString(String Path, String JsonString)
        {
            HttpResponseMessage response;
            CancellationTokenSource cts;
            cts = new CancellationTokenSource();
            HttpClient client = new HttpClient(new LoggingHandler(new HttpClientHandler()));
            var byteArray = Encoding.ASCII.GetBytes(APIConstants.getCredentials());
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, new Uri(Path));
            request.Content = new StringContent(JsonString,
                                                Encoding.UTF8,
                                                "application/json");

            try
            {
                response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("PUT SUCCESS\n");
                }
                else
                    Console.WriteLine("PUT ERROR\n");

                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return "";
        }

        public static async Task<SMResponse> put(string path, SMRequest request)
        {
            string json = JsonConvert.SerializeObject(request, Formatting.Indented,
                 new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
            string responseString = await putResponseString(path, json);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            return m;
        }

        public static async Task<String> deleteResponseString(String Path)
        {
            HttpResponseMessage response;
            var client = new HttpClient(new LoggingHandler(new HttpClientHandler()));
            var byteArray = Encoding.ASCII.GetBytes(APIConstants.getCredentials());
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.BaseAddress = new Uri(Path);

            try
            {
                response = client.DeleteAsync(Path).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("DELETE SUCCESS\n");
                }
                else
                    Console.WriteLine("DELETE ERROR\n");

                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return "";

        }

        public static async Task<SMResponse> delete(string path)
        {
            string responseString = await deleteResponseString(path);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            return m;
        }
    }
}
