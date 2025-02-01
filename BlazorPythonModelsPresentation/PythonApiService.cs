using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorPythonModelsPresentation;

public class PythonApiService(HttpClient httpClient)
{
    public async Task<string> CallPythonModel(string inputData)
    {
        var requestData = new { input = inputData };
        var json = JsonSerializer.Serialize(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("http://127.0.0.1:5001/process", content);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    }

    private double _riskScore;

    private List<string>? _riskScoreImage;

    public async Task DsciStateRisk(double rainfall, double temp, double groundWater, string state = "utah")
    {
        var requestData = new { input = rainfall, temp, groundWater, state };
        var json = JsonSerializer.Serialize(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("http://127.0.0.1:5001/dsci_state_risk", content);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var pyResponseDouble = double.Parse(responseString);

        double riskScore;
        List<string> images;

        response = await httpClient.PostAsJsonAsync("https://your-api-url.com/dsci_state_risk", requestData);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
            _riskScore = Convert.ToDouble(result!["risk_score"]);
            _riskScoreImage = ((JsonElement)result["images"]).Deserialize<List<string>>()!;
        }
    }
}