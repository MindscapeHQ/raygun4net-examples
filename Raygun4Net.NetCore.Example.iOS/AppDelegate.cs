using Mindscape.Raygun4Net;

namespace Raygun4Net.NetCore.Example.iOS;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window
    {
        get;
        set;
    }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        var _raygunSettings = new RaygunSettings
        {
            ApiKey = "YOUR_API_KEY",
            CatchUnhandledExceptions = true // automatically reports any unhandled exceptions to Raygun
        };

        var _raygunClient = new RaygunClient(_raygunSettings);
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        var vc = new UIViewController();

        // Button to crash the app
        var zero = 0;
        var button = new UIButton(Window.Frame);
        button.SetTitle("Tap to crash app", UIControlState.Normal);
        button.TouchUpInside += (sender, e) =>
        {
            var crash = 1 / zero; // This will cause a divide by zero exception.
        };

        vc.View!.AddSubview(button);
        Window.RootViewController = vc;

        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }
}
