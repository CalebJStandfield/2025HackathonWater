using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorPythonModelsPresentation;

public class PythonApiService(HttpClient httpClient)
{
    public async Task<double> DsciStateRisk(int year, int month, double rainfall, double temperature, double gslLevels,
        double rainfall3MoAvg, double rainfall6MoAvg, double temperature3MoAvg, double temperature6MoAvg,
        double gsl3MoAvg, double gsl6MoAvg, double beaverSoil, double trialSoil, double parelySoil, double haydenSoil)
    {
        // Look at how the DataFrame handles inputs

        // x_input = pd.DataFrame({
        //     "Year": [2000],
        //     "Month": [1],
        //     "Rainfall": [2.17],
        //     "Rainfall_3mo_avg": [2.17],
        //     "Rainfall_6mo_avg": [2.17],
        //     "Temperature": [35.1],
        //     "Temperature_3mo_avg": [35.1],
        //     "Temperature_6mo_avg": [35.1],
        //     "GSL Levels": [4202.58],
        //     "GSL_3mo_avg": [4202.58],
        //     "GSL_6mo_avg": [4202.58],
        //     "beaver_soil": [53.26],
        //     "trial_soil": [75.72],
        //     "parely_soil": [77.28],
        //     "hayden_soil": [79.97]
        // })
        var requestData = new
        {
            input = year, month, rainfall, temperature, gslLevels,
            rainfall3MoAvg, rainfall6MoAvg, temperature3MoAvg, temperature6MoAvg, gsl3MoAvg, gsl6MoAvg, beaverSoil,
            trialSoil, parelySoil, haydenSoil
        };
        var json = JsonSerializer.Serialize(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("http://127.0.0.1:5001/dsci_state_risk", content);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var pyRiskScore = double.Parse(responseString);
        return pyRiskScore;
    }
}