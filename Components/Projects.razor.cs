using BlazorApp.Components.Projekt;
using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components;

public partial class Projects:ComponentBase
{
    [Parameter] public List<Data> Projectslist { get; set; } = []; 
    [Parameter] public string Title { get; set; } = "Projects";
    private string _bsModalName = "projectModal";
    private RenderFragment? _selectedContent = builder =>
    {
        builder.OpenComponent(0, typeof(ProjectOne));
        builder.CloseComponent();
    };

    private void LoadContent(string contentType)
    {
        _selectedContent = contentType switch
        {
            nameof(ProjectOne)   => b => { b.OpenComponent(0, typeof(ProjectOne));   b.CloseComponent(); },
            nameof(ProjectTwo)   => b => { b.OpenComponent(0, typeof(ProjectTwo));   b.CloseComponent(); },
            nameof(ProjectThree) => b => { b.OpenComponent(0, typeof(ProjectThree)); b.CloseComponent(); },
            nameof(ProjectFour)  => b => { b.OpenComponent(0, typeof(ProjectFour));  b.CloseComponent(); },
            nameof(ThreeDModelViewer)  => b => { b.OpenComponent(0, typeof(ThreeDModelViewer));  b.CloseComponent(); },
            _=> null
        };
    } 
    
}