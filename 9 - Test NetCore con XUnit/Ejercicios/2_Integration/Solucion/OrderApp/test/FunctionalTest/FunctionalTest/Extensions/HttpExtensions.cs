using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace FunctionalTest.Extensions
{
    public static class HttpExtensions
    {
        private static JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public static Task<HttpResponseMessage> PostJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data, SerializerOptions);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpClient.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data, SerializerOptions);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpClient.PutAsync(url, content);
        }

        public static async Task<T?> GetJsonAsync<T>(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(content, SerializerOptions);
        }
    }
}
