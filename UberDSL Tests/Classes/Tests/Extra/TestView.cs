using UIKit;
using CoreGraphics;

namespace UberDSLTests
{
    public class TestView : UIView
    {
        public TestView()
        {
            TranslatesAutoresizingMaskIntoConstraints = false;
        }

        public TestView(CGRect frame) : base (frame)
        {
            TranslatesAutoresizingMaskIntoConstraints = false;
        }
    }
}
