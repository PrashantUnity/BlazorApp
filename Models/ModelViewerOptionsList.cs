namespace BlazorApp.Models;

public class ModelViewerOptionsList
{
    public List<string> ArModes { get; set; } =
    [
        "scene-viewer",
        "quick-look",
        "webxr",
        "scene-viewer quick-look"
    ];

    public List<string> TouchActions { get; set; } =
    [
        "none",
        "pan-x",
        "pan-y",
        "pan-x pan-y",
        "pan-x pinch-rotate",
        "pan-y pinch-rotate",
        "pan-x pan-y pinch-rotate"
    ];

    public List<string> AnimationNames { get; set; } =
    [
        "Running",
        "Walking",
        "Jumping",
        "Idle"
    ];

    public List<string> ToneMappings { get; set; } =
    [
        "aces",
        "neutral",
        "reinhard",
        "legacy"
    ];

    public List<string> EnvironmentImages { get; set; } =
    [
        "https://modelviewer.dev/shared-assets/environments/spruit_sunrise_1k_HDR.jpg",
        "https://modelviewer.dev/shared-assets/environments/forest_1k_HDR.jpg",
        "https://modelviewer.dev/shared-assets/environments/park_1k_HDR.jpg"
    ];

    public List<string> SkyboxImages { get; set; } =
    [
        "https://modelviewer.dev/shared-assets/environments/spruit_sunrise_1k_HDR.jpg",
        "https://modelviewer.dev/shared-assets/environments/forest_1k_HDR.jpg",
        "https://modelviewer.dev/shared-assets/environments/park_1k_HDR.jpg"
    ];

    public List<string> SkyboxHeights { get; set; } =
    [
        "2m",
        "5m",
        "10m"
    ];
}