using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Components.Pages;

public partial class Slides : ComponentBase
{
    [Inject] private IJSRuntime JSRuntime { get; set; }

    private int _slideIndex = 0;
    private readonly List<string> _slideIds =
    [
        "id.p",
        "id.g32b89602ec3_0_0",
        "id.g32b89602ec3_0_5"
    ];

    private const string SlideUrl = "https://docs.google.com/presentation/d/1hHB7RXhkApfkbsYMBj-fB3BBuma50k3HFzgp5aduuQs/edit#slide=";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await UpdateSlide();
        }
    }

    private async Task NextSlide()
    {
        _slideIndex = (_slideIndex + 1) % _slideIds.Count; // Loop back to the first slide if at the end
        await UpdateSlide();
    }

    private async Task UpdateSlide()
    {
        // Use the correct slide ID from the list
        var finalUrl = $"{SlideUrl}{_slideIds[_slideIndex]}";
        await JSRuntime.InvokeVoidAsync("updateSlide", finalUrl);
    }
}