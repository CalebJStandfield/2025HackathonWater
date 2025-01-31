using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Components.Pages;

public partial class Slides : ComponentBase
{
    [Inject] private IJSRuntime JSRuntime { get; set; }

    private int _slideIndex = 0;
    private const string SlideUrl = "https://docs.google.com/presentation/d/1hHB7RXhkApfkbsYMBj-fB3BBuma50k3HFzgp5aduuQs/edit#slide=id.p";
    private bool _isFirstRender = true; // Ensure we only call JS on first render

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await UpdateSlide();
            _isFirstRender = false;
        }
    }

    private async Task NextSlide()
    {
        _slideIndex++;
        await UpdateSlide();
    }

    private async Task UpdateSlide()
    {
        await JSRuntime.InvokeVoidAsync("updateSlide", $"{SlideUrl}&slide={_slideIndex}");
    }
}