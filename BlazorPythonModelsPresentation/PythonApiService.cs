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

    // (String state, Double rainfall, Double Temp) return double risk 0 - 500 DSCI

    public async Task<double> DsciStateRisk(double rainfall, double temp, double groundWater, string state = "utah")
    {
        var requestData = new { input = rainfall, temp, groundWater, state };
        var json = JsonSerializer.Serialize(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("http://127.0.0.1:5001/dsci_state_risk", content);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var pyResponseDouble = double.Parse(responseString);
        return pyResponseDouble;
    }
}