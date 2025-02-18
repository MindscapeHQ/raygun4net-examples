using Mindscape.Raygun4Net;

namespace Mono.Samples.Button;

[Activity(Label = "Raygun4Net Demo", MainLauncher = true)]
public class ButtonActivity : Activity
{
    int count = 0;

    protected override void OnCreate(Bundle? bundle)
    {
        base.OnCreate(bundle);

        var _raygunSettings = new RaygunSettings
        {
            ApiKey = "YOUR_API_KEY",
            CatchUnhandledExceptions = true // automatically reports any unhandled exceptions to Raygun
        };

        var _raygunClient = new RaygunClient(_raygunSettings);

        // Create your application here
        Android.Widget.Button button = new(this);

        button.Text = $"Tap to crash app";
        button.Click += delegate
        {
            var result = 1 / count;
        };

        SetContentView(button);
    }
}
