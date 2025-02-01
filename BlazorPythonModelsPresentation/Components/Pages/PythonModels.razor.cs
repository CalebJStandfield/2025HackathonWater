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
    private int year;
    private int month;
    private double rainfall;
    private double temperature;
    private double gslLevels;
    private double rainfall3MoAvg;
    private double rainfall6MoAvg;
    private double temperature3MoAvg;
    private double temperature6MoAvg;
    private double gsl3MoAvg;
    private double gsl6MoAvg;
    private double beaverSoil;
    private double trialSoil;
    private double parelySoil;
    private double haydenSoil;

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
