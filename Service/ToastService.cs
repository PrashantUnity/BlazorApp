// Services/ToastService.cs

using Microsoft.AspNetCore.Components;

namespace BlazorApp.Service;

public class ToastService
{
    public event Action<string, string, string, RenderFragment>? OnShow;

    public void ShowToast(string title, string subtitle, string icon, RenderFragment content)
    {
        OnShow?.Invoke(title, subtitle, icon, content);
    }
}