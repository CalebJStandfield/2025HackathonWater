using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPythonModelsPresentation.Components.Pages;

public partial class PythonModels : ComponentBase
{
    /// <summary>
    ///   RiskScore of utah based off python model and input params.
    /// </summary>
    private double RiskScore;

    // Params for DSCI, All will have default params
    private int year = 2000;
    private int month = 1;
    private double rainfall = 2.17;
    private double temperature = 35.1;
    private double gslLevels = 4202.58;
    private double rainfall3MoAvg = 2.17;
    private double rainfall6MoAvg = 2.17;
    private double temperature3MoAvg = 35.1;
    private double temperature6MoAvg = 35.1;
    private double gsl3MoAvg = 4202.58;
    private double gsl6MoAvg = 4202.58;
    private double beaverSoil = 53.26;
    private double trialSoil = 75.72;
    private double parelySoil = 77.28;
    private double haydenSoil = 79.97;

    private async void CalculateRiskScore()
    {
        Console.WriteLine("Button clicked!");  // Log to console to check if it gets called
        await DsciRiskScoreModel();
        StateHasChanged();
    }

    private async Task DsciRiskScoreModel()
    {
        RiskScore = await PythonApiService.DsciStateRisk(year, month, rainfall, temperature, gslLevels, rainfall3MoAvg, rainfall6MoAvg, temperature3MoAvg, temperature6MoAvg,
        gsl3MoAvg, gsl6MoAvg, beaverSoil, trialSoil, parelySoil, haydenSoil);
    }

}
