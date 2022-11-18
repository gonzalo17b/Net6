Usa el proyecto OrderApp que se encuentra en esta sección.

1. Crea un proyecto de IntegrationTests, dentro de una nueva carpeta /test/FunctionalTest. El proyecto debe ser de tipo XUnit.
2. Crea un Fixture, creando tu propio archivo ```Program.cs``` para los Tests. Que el fixture genere un TestServer y se pueda inyectar en cada clase de Test que vayamos creando con la Colección que tenga asignada.
3. Genera los tests de integración necesarios para los endpoints de Product, en una carpeta Scenarios/Products.
  * Ayudate de crear un Given para ello, cuando necesites insertar datos en el sistema.
  * Usa esta clase de Extensiones para trabajar con el cliente http:

```csharp
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
```