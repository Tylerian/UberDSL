using UIKit;
using Foundation;
using CoreGraphics;

using NUnit.Framework;
using UberDSL;
using System;

namespace UberDSLTests
{
    using static UberDSL.UberDSL;

    [TestFixture]
    public class ConstraintGroupFixture
    {
        private TestView   view1;
        private TestWindow window;

        [SetUp]
        public void SetUp()
        {
            window = new TestWindow(
                new CGRect(0, 0, 400, 400)
            );

            view1  = new TestView();
            window.AddSubview(view1);
        }

        [TestCase]
        public void ActivatingAGroup()
        {
            var a = Constrain(view1, (view) =>
            {
                view.Width .Equal(100);
                view.Height.Equal(100);
            });

            var b = Constrain(view1, (view) =>
            {
                view.Width .Equal(200);
                view.Height.Equal(200);
            });

            a.Active = false;
            b.Active = false;

            // Should update the view
            a.Active = true;

            view1.LayoutIfNeeded();

            Assert.AreEqual(100, view1.Frame.Height);
            Assert.AreEqual(100, view1.Frame.Width);

            a.Active = false;
            b.Active = true;

            window.LayoutIfNeeded();

            Assert.AreEqual(200, view1.Frame.Height);
            Assert.AreEqual(200, view1.Frame.Width);
        }

        [TestCase]
        public void ReplacingConstraints()
        {
            var view2 = new TestView(
                CGRect.Empty
            );

            window.AddSubview(view2);

            Constrain(view1, view2, (x, y) =>
            {
                x.Top.Equal(x.Superview.Top + 10);
                x.Left.Equal(x.Superview.Left + 10);
                x.Right.Equal(x.Superview.Right - 10);
                x.Height.Equal(200);

                y.CenterX.Equal(x.CenterX);
                y.Top.Equal(x.Bottom);
                y.Width.Equal(x.Width);
            });

            window.LayoutIfNeeded();

            // Should update the view

            var group = Constrain(view2, (view) =>
            {
                view.Height.Equal(100);
            });

            window.LayoutIfNeeded();

            Assert.AreEqual(100, view2.Frame.Height);

            Constrain(view2, (view) =>
            {
                view.Bottom.GreaterThanOrEqualTo(
                    view.Superview.Bottom
                );
            }, group);

            window.LayoutIfNeeded();

            Assert.AreEqual(190, view2.Frame.Height);
        }
    }
}
