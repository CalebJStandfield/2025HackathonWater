using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPythonModelsPresentation.Components.Pages;

public partial class Presentation : ComponentBase
{
    /// <summary>
    ///   <para>
    ///     SlideUrl to show the current slide
    ///     Home page is default value
    ///   </para>
    /// </summary>
    private string _slideUrl = "https://docs.google.com/presentation/d/1hHB7RXhkApfkbsYMBj-fB3BBuma50k3HFzgp5aduuQs/edit#slide=id.p";
}