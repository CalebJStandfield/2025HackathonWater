using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorPythonModelsPresentation;

public class PythonApiService
{
    private readonly HttpClient _httpClient;

    public PythonApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> CallPythonModel(string inputData)
    {
        var requestData = new { input = inputData };
        var json = JsonSerializer.Serialize(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("http://127.0.0.1:5001/process", content);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    }
}