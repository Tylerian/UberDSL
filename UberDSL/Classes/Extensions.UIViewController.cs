using UIKit;

namespace UberDSL
{
    public static partial class Extensions
    {
        public static LayoutSupport TopLayoutGuideCartography(this UIViewController instance)
        {
            return new LayoutSupport(instance.TopLayoutGuide, NSLayoutAttribute.Top);
        }

        public static LayoutSupport BottomLayoutGuideCartography(this UIViewController instance)
        {
            return new LayoutSupport(instance.TopLayoutGuide, NSLayoutAttribute.Bottom);
        }
    }
}
