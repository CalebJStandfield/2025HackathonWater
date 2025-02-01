using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;



namespace BlazorPythonModelsPresentation.Components.Pages;

public partial class PythonModels : ComponentBase
{
    private string _responseMessage = "Default";

    private void UpdateResponse()
    {
        Console.WriteLine("Button clicked!");  // Log to console to check if it gets called
        _responseMessage = "Updated";
        StateHasChanged();
    }

    private async Task GetModelResponse()
    {
        _responseMessage = await PythonApiService.CallPythonModel("Test Data");
    }

    private string _stateName = "";

}
