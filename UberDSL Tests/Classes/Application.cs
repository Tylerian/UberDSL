using System;

using UIKit;
using Foundation;

using MonoTouch.NUnit.UI;

namespace UberDSLTests
{
    [Register("Application")]
    public partial class Application : UIApplicationDelegate
    {
        private UIWindow    _window;
        private TouchRunner _runner;

        static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }
        
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _runner = new TouchRunner(
                _window = new UIWindow(UIScreen.MainScreen.Bounds)
            );

            // register every tests included in the main application/assembly
            _runner.Add(System.Reflection.Assembly.GetExecutingAssembly());

            _window.RootViewController = new UINavigationController(_runner.GetViewController());

            // make the window visible
            _window.MakeKeyAndVisible();

            return true;
        }
    }
}
