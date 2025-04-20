using System.Text.Json;
using BlazorApp.Components.UI;
using BlazorApp.Models;
using BlazorApp.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BlazorApp.Components.Projekt;

public partial class ThreeDModelPreviwerGenerator : ComponentBase
{ 
    [Parameter] public ModelViewerOptions Model { get; set; } = new(); 
    [Parameter] public ModelViewerOptionsList Options { get; set; } = new();
    [Inject] private IJSRuntime Js { get; set; } = null!;
    [Inject] private ToastService ToastService { get; set; } = null!;
    private async Task Generate()
    { 
        var jsonString = JsonSerializer.Serialize(Model, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        await Js.InvokeVoidAsync("navigator.clipboard.writeText", jsonString);
        const string message = "✅ Copied!";
        ToastService.ShowToast(
            title: "Model Data",
            subtitle: string.Empty,
            icon :"bi bi-chat-left-fill",
            content:builder =>
            {
                builder.AddContent(0, message);
            });
    } 
    private async Task HandleGltfUpload(InputFileChangeEventArgs e)
    {
        var data = await GetBase64FromFile(e);
        if (data != null)
        {
            Model.Source = data; 
        }  
    }
    private async Task HandleSkyBoxUpload(InputFileChangeEventArgs e)
    {
        var data = await GetBase64FromFile(e);
        if (data != null)
        {
            Model.SkyboxImage = data; 
        } 
    }
    private async Task HandleEnvironmentImageUpload(InputFileChangeEventArgs e)
    {
        var data = await GetBase64FromFile(e);
        if (data != null)
        {
            Model.EnvironmentImage = data; 
        } 
    }
    private async Task HandleSkyImageImageUpload(InputFileChangeEventArgs e)
    {
        var data = await GetBase64FromFile(e);
        if (data != null)
        {
            Model.SkyboxImage = data; 
        } 
    }
    
    private static async Task<string?> GetBase64FromFile(InputFileChangeEventArgs e)
    {
        var file = e.File;
        const long maxBytes = 50L * 1024L * 1024L; // 50MB limit

        if (file.Size > maxBytes)
        {
            await Console.Error.WriteLineAsync($"File too large: {file.Size} bytes");
            return null;
        }

        try
        {
            await using var stream = file.OpenReadStream(maxBytes);
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            var bytes = ms.ToArray();
            var base64 = Convert.ToBase64String(bytes);
            return $"data:{file.ContentType};base64,{base64}";
        }
        catch (InvalidOperationException ex)
        {
            await Console.Error.WriteLineAsync($"Couldn’t read file: {ex.Message}");
            return null;
        }
    }
}