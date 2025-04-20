namespace BlazorApp.Models;

public class ModelViewerOptions
{
    public string Description { get; set; } = " Neil Armstrong was an American astronaut and aeronautical engineer who was the first person to walk on the Moon.";
    public string Source { get; set; } = "https://modelviewer.dev/shared-assets/models/NeilArmstrong.glb";
    public string Poster { get; set; } = "poster.webp";
    public bool EnableAr { get; set; } = true;
    public bool AutoRotate { get; set; } = true;
    public bool DisablePan { get; set; } = true;
    public bool DisableTap { get; set; } = false;
    public bool CameraControls { get; set; } = true;
    public string AltText { get; set; } = "3D Model";
    public string ArModes { get; set; } = "scene-viewer quick-look";
    public string ArScale { get; set; } = "auto";
    public string TouchAction { get; set; } = "pan-y";
    public int AutoRotateDelay { get; set; } = 0;
    public string AnimationName { get; set; } = "Running";
    public int AnimationCrossfadeDuration { get; set; } = 300;
    public string CameraOrbit { get; set; } = "auto auto auto";
    public string MaxCameraOrbit { get; set; } = "auto 90deg auto";
    public string MinCameraOrbit { get; set; } = "auto auto auto";
    public string FieldOfView { get; set; } = "auto";
    public string MaxFieldOfView { get; set; } = "auto";
    public string MinFieldOfView { get; set; } = "auto";
    public string EnvironmentImage { get; set; } = "";
    public string SkyboxImage { get; set; } = "https://modelviewer.dev/shared-assets/environments/spruit_sunrise_1k_HDR.jpg";
    public string SkyboxHeight { get; set; } = "2m";
    public string ToneMapping { get; set; } = "aces";
    public double ShadowIntensity { get; set; } = 1.0;
    public double ShadowSoftness { get; set; } = 0.0;
    public double Exposure { get; set; } = 1.0;
    public string IosSrc { get; set; } = "";
    public string Reveal { get; set; } = "auto";
    public string Loading { get; set; } = "auto";
    public string BackgroundColor { get; set; } = "transparent";
}