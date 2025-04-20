using System.ComponentModel;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.UI;

public partial class Toast:ComponentBase
{
    private string _title;
    private string _subtitle;
    private string _icon;
    private RenderFragment _content;
    private bool _visible;
    private System.Timers.Timer _timer;

    protected override void OnInitialized()
    {
        ToastService.OnShow += ShowToast;

        // Initialize the timer
        _timer = new System.Timers.Timer(3000); // 5 seconds
        _timer.Elapsed += (s, e) => Hide();
        _timer.AutoReset = false;
    }

    private void ShowToast(string title, string subtitle, string icon, RenderFragment content)
    {
        _title = title;
        _subtitle = subtitle;
        _icon = icon;
        _content = content;
        _visible = true;

        StateHasChanged();

        _timer.Stop(); // in case a toast was already showing
        _timer.Start(); // start countdown
    }

    private void Hide()
    {
        _visible = false;
        InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        ToastService.OnShow -= ShowToast;
        _timer?.Dispose();
    }
}