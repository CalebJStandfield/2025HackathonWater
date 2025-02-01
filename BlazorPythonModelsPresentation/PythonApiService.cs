using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorPythonModelsPresentation;

public class PythonApiService(HttpClient httpClient)
{
    public async Task<string> DsciStateRisk(int year, int month, double rainfall, double temperature, double gslLevels,
        double rainfall3MoAvg, double rainfall6MoAvg, double temperature3MoAvg, double temperature6MoAvg,
        double gsl3MoAvg, double gsl6MoAvg, double beaverSoil, double trialSoil, double parelySoil, double haydenSoil)
    {
        var requestData = new
        {
            year, month, rainfall, temperature, gslLevels,
            rainfall3MoAvg, rainfall6MoAvg, temperature3MoAvg, temperature6MoAvg, gsl3MoAvg, gsl6MoAvg, beaverSoil,
            trialSoil, parelySoil, haydenSoil
        };
        var json = JsonSerializer.Serialize(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("http://127.0.0.1:5001/dsci_state_risk", content);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    }
}