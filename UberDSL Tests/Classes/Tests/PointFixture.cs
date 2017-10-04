using System;

using UIKit;
using CoreGraphics;

using NUnit.Framework;

namespace UberDSLTests
{
    using static UberDSL.UberDSL;
    
    [TestFixture]
    public class PointFixture
    {
        private TestView   view;
        private TestWindow window;


        [SetUp]
        public void SetUp()
        {
            window = new TestWindow(
                new CGRect(0, 0, 400, 400)
            );

            view = new TestView();
            window.AddSubview(view);

            Constrain(view, view =>
            {
                view.Width.Equal(200);
                view.Height.Equal(200);
            });
        }

        private void SetUpWindowMargins()
        {
            window.LayoutMargins = new UIEdgeInsets(10, 20, 30, 40);
        }

        [Test]
        public void LayoutProxyCenterRelativeEq()
        {
            Constrain(view, view =>
            {
                view.Center.Equal(view.Superview.Center);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame, Is.EqualTo(new CGRect(100, 100, 200, 200)), "LayoutProxy.Center should support relative equalities");
        }

        [Test]
        public void LayoutProxyCenterRelativeIneq()
        {

            Constrain(view, view =>
            {
                view.Center.LessThanOrEqualTo(view.Superview.Center);
                view.Center.GreaterThanOrEqualTo(view.Superview.Center);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame, Is.EqualTo(new CGRect(100, 100, 200, 200)), "LayoutProxy.Center should support relative inequalities");
        }

        [Test]
        public void LayoutProxyCenterWithinMarginsRelativeEq()
        {
            SetUpWindowMargins();

            Constrain(view, view =>
            {
                view.CenterWithinMargins.Equal(view.Superview.Center);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame, Is.EqualTo(new CGRect(110, 110, 200, 200)), "LayoutProxy.CenterWithinMargins should support relative equalities");
        }

        [Test]
        public void LayoutProxyCenterWithinMarginsRelativeIneq()
        {
            SetUpWindowMargins();

            Constrain(view, view =>
            {
                view.CenterWithinMargins.LessThanOrEqualTo(view.Superview.Center);
                view.CenterWithinMargins.GreaterThanOrEqualTo(view.Superview.Center);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame, Is.EqualTo(new CGRect(110, 110, 200, 200)), "LayoutProxy.CenterWithinMargins should support relative inequalities");
        }
    }
}