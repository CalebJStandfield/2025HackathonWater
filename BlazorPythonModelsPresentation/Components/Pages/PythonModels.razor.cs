using Microsoft.AspNetCore.Components;

namespace BlazorPythonModelsPresentation.Components.Pages;

public partial class PythonModels : ComponentBase
{
    private string _responseMessage;

    private async Task GetModelResponse()
    {
        _responseMessage = await PythonApiService.CallPythonModel("Test Data");
    }
}
