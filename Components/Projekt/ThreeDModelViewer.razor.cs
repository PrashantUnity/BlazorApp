using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Components.Projekt;

public partial class ThreeDModelViewer:ComponentBase
{
    [Parameter] public ModelViewerOptions Model { get; set; } = new(); 
    [Parameter] public ModelViewerOptionsList Options { get; set; } = new();

    private async Task HandleFileUpload(InputFileChangeEventArgs e)
    {
        var file = e.File;
        const long maxBytes = 50L * 1024L * 1024L; // 50MB limit

        if (file.Size > maxBytes)
        {
            await Console.Error.WriteLineAsync($"File too large: {file.Size} bytes");
            return;
        }

        try
        {
            await using var stream = file.OpenReadStream(maxBytes);
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            var bytes = ms.ToArray();
            var base64 = Convert.ToBase64String(bytes);
            Model.Source = $"data:{file.ContentType};base64,{base64}";
        }
        catch (InvalidOperationException ex)
        {
            await Console.Error.WriteLineAsync($"Couldn’t read file: {ex.Message}");
        }
    }
}