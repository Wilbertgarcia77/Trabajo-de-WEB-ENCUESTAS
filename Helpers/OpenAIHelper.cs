using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace encuestasgym.Helpers
{
    public static class OpenAIHelper
    {
        public static async Task<string> ObtenerRecomendacion(string prompt)
        {
            var apiKey = EnvHelper.Get("OPENAI_API_KEY");
            Console.WriteLine($"API KEY leída desde .env: {apiKey}");
            string json = "";
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                var requestBody = new
                {
                    model = "gpt-4o",
                    messages = new[] { new { role = "user", content = prompt } }
                };
                var response = await client.PostAsync(
                    "https://api.openai.com/v1/chat/completions",
                    new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json")
                );
                json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var result = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                return result ?? "";
            }
            catch (Exception ex)
            {
                // Mostrar el JSON completo y el mensaje de excepción
                return $"No se pudo obtener una recomendación de OpenAI. Error: {ex.Message}\nRespuesta JSON: {json}";
            }
        }
    }
}
