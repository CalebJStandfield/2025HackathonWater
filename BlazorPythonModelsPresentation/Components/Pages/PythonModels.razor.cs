using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPythonModelsPresentation.Components.Pages;

public partial class PythonModels : ComponentBase
{
    /// <summary>
    ///   RiskScore of utah based off python model and input params.
    /// </summary>
    private string RiskScore;

    // Params for DSCI, All will have default params
    private int year = 2025;
    private int month = 1;
    private double rainfall = 1.043333;
    private double temperature = 35.1;
    private double gslLevels = 4192.33;
    private double rainfall3MoAvg = 0.796667;
    private double rainfall6MoAvg = 0.796667;
    private double temperature3MoAvg = 46.900000;
    private double temperature6MoAvg = 62.833333;
    private double gsl3MoAvg = 4192.276667;
    private double gsl6MoAvg = 4192.798333;
    private double beaverSoil = 66.505891;
    private double trialSoil = 74.932462;
    private double parelySoil = 87.861519;
    private double haydenSoil = 95.997901;

    private async void CalculateRiskScore()
    {
        // Log to console to check if it gets called
        await DsciRiskScoreModel();
        StateHasChanged();
    }

    private async Task DsciRiskScoreModel()
    {
        RiskScore = await PythonApiService.DsciStateRisk(year, month, rainfall, temperature, gslLevels, rainfall3MoAvg, rainfall6MoAvg, temperature3MoAvg, temperature6MoAvg,
        gsl3MoAvg, gsl6MoAvg, beaverSoil, trialSoil, parelySoil, haydenSoil);
    }

}
