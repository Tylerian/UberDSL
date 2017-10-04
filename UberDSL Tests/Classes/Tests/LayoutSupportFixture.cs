using System;

using UberDSL;

using UIKit;
using Foundation;
using CoreGraphics;

using NUnit.Framework;

namespace UberDSLTests.Classes.Tests
{
    using static UberDSL.UberDSL;

    [TestFixture]
    public class LayoutSupportFixture
    {
        private TestView view;

        private TestWindow window;

        private UIViewController viewController;
        private UITabBarController tabBarController;
        private UINavigationController navigationController;

        [SetUp]
        public void SetUp()
        {
            window = new TestWindow(
                new CGRect(0, 0, 400, 400)
            );

            view = new TestView();

            viewController = new UIViewController();
            viewController.View.AddSubview(view);

            Constrain(view, v =>
            {
                v.Height.Equal(200);
                v.Width .Equal(200);
            });

            navigationController = new UINavigationController(
                rootViewController: viewController
            );

            tabBarController = new UITabBarController
            {
                ViewControllers = new[] { navigationController }
            };

            tabBarController.View.Frame = window.Bounds;
            tabBarController.View.LayoutIfNeeded();

            window.RootViewController = tabBarController;

            window.SetNeedsLayout();
            window.LayoutIfNeeded();

            Console.WriteLine($"tlg -->>>>>>>> {viewController.TopLayoutGuide}");
        }

        [Test]
        public void LayoutSupportTopRelativeEqualities()
        {
            viewController.View.LayoutIfNeeded();

            Constrain(view, v =>
            {
                v.Top.Equal(viewController.TopLayoutGuideCartography());
            });

            viewController.View.LayoutIfNeeded();

            Assert.That(view.ConvertRectToView(view.Bounds, window).GetMinY(), Is.EqualTo(viewController.TopLayoutGuide.Length));
        }

        [Test]
        public void LayoutSupportTopRelativeInequalities()
        {
            viewController.View.LayoutIfNeeded();

            Constrain(view, v =>
            {
                v.Top.LessThanOrEqualTo(viewController.TopLayoutGuideCartography());
                v.Top.GreaterThanOrEqualTo(viewController.TopLayoutGuideCartography());
            });

            viewController.View.LayoutIfNeeded();

            Assert.That(view.ConvertRectToView(view.Bounds, window).GetMinY(), Is.EqualTo(viewController.TopLayoutGuide.Length));
        }

        [Test]
        public void LayoutSupportTopAddition()
        {
            viewController.View.LayoutIfNeeded();

            Constrain(view, v =>
            {
                v.Top.Equal(viewController.TopLayoutGuideCartography() + 100);
            });

            viewController.View.LayoutIfNeeded();

            Assert.That(view.ConvertRectToView(view.Bounds, window).GetMinY(), Is.EqualTo(100 + viewController.TopLayoutGuide.Length));
        }

        [Test]
        public void LayoutSupportTopSubstraction()
        {
            viewController.View.LayoutIfNeeded();

            Constrain(view, v =>
            {
                v.Top.Equal(viewController.TopLayoutGuideCartography() - 100);
            });

            viewController.View.LayoutIfNeeded();

            Assert.That(view.ConvertRectToView(view.Bounds, window).GetMinY(), Is.EqualTo(-100 - viewController.TopLayoutGuide.Length));
        }

        [Test]
        public void LayoutSupportBottomRelativeEqualities()
        {
            viewController.View.LayoutIfNeeded();

            Constrain(view, v =>
            {
                v.Bottom.Equal(viewController.BottomLayoutGuideCartography());
            });

            viewController.View.LayoutIfNeeded();

            Assert.That(view.ConvertRectToView(view.Bounds, window).GetMaxY(), Is.EqualTo(viewController.BottomLayoutGuide.Length));
        }

        [Test]
        public void LayoutSupportBottomRelativeInequalities()
        {
            viewController.View.LayoutIfNeeded();

            Constrain(view, v =>
            {
                v.Bottom.LessThanOrEqualTo(viewController.BottomLayoutGuideCartography());
                v.Bottom.GreaterThanOrEqualTo(viewController.BottomLayoutGuideCartography());

            });

            viewController.View.LayoutIfNeeded();

            Assert.That(view.ConvertRectToView(view.Bounds, window).GetMaxY(), Is.EqualTo(viewController.BottomLayoutGuide.Length));
        }

        [Test]
        public void LayoutSupportBottomAddition()
        {
            viewController.View.LayoutIfNeeded();

            Constrain(view, v =>
            {
                v.Bottom.Equal(viewController.BottomLayoutGuideCartography() + 100);
            });

            viewController.View.LayoutIfNeeded();

            Assert.That(view.ConvertRectToView(view.Bounds, window).GetMaxY(), Is.EqualTo(100 + viewController.BottomLayoutGuide.Length));
        }

        [Test]
        public void LayoutSupportBottomSubstraction()
        {
            viewController.View.LayoutIfNeeded();

            Constrain(view, v =>
            {
                v.Bottom.Equal(viewController.BottomLayoutGuideCartography() - 100);
            });

            viewController.View.LayoutIfNeeded();

            Assert.That(view.ConvertRectToView(view.Bounds, window).GetMaxY(), Is.EqualTo(-100 - viewController.BottomLayoutGuide.Length));
        }
    }
}
