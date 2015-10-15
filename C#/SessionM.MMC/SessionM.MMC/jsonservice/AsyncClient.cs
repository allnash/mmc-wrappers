using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading;
using SessionM.MMC.API;

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

        public static async Task<String> get(String Path)
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

        public static async Task<String> post(String Path, String JsonString)
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

        public static async Task<String> put(String Path, String JsonString)
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

        public static async Task<String> delete(String Path)
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
    }
}
