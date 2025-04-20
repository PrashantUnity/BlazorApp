using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Components.UI;

public partial class GoToFullScreen : ComponentBase
{
    [Inject] private IJSRuntime Js { get; set; } = null!;
    [Parameter] public string ElementId { get; set; } = "model-viewer";  
    private bool _isFullScreen;
    private  DotNetObjectReference<GoToFullScreen>? _objRef ;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _objRef = DotNetObjectReference.Create(this);
            await Js.InvokeVoidAsync("registerFullScreenCallback", _objRef, ElementId);
        }
    }

    private async Task GoFull()
    {
        await Js.InvokeVoidAsync("openFullScreen", ElementId);
    }

    private async Task GoExit()
    {
        await Js.InvokeVoidAsync("closeFullScreen");
    }

    [JSInvokable]
    public void SetFullScreenState(bool isFull)
    {
        _isFullScreen = isFull;
        StateHasChanged();
    }

}