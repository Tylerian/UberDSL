using System;

using UIKit;
using CoreGraphics;

using NUnit.Framework;

namespace UberDSLTests
{
    using static UberDSL.UberDSL;

    [TestFixture]
    public class SizeFixture
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
        }

        [Test]
        public void LayoutProxySizeShouldSupportRelativeEqualities()
        {
            Constrain(view, view =>
            {
                view.Size.Equal(view.Superview.Size);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Size, Is.EqualTo(new CGSize(400, 400)));
        }

        [Test]
        public void LayoutProxySizeShouldSupportRelativeInequalities()
        {
            Constrain(view, view =>
            {
                view.Size.LessThanOrEqualTo(view.Superview.Size);
                view.Size.GreaterThanOrEqualTo(view.Superview.Size);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Size, Is.EqualTo(new CGSize(400, 400)));
        }

        [Test]
        public void LayoutProxySizeShouldSupportMultiplication()
        {
            Constrain(view, view =>
            {
                view.Size.Equal(view.Superview.Size * 2);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Size, Is.EqualTo(new CGSize(800, 800)));
        }

        [Test]
        public void LayoutProxySizeShouldSupportDivision()
        {
            Constrain(view, view =>
            {
                view.Size.Equal(view.Superview.Size / 2);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Size, Is.EqualTo(new CGSize(200, 200)));
        }
    }
}