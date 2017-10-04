using System;

using UIKit;
using Foundation;
using CoreGraphics;

using UberDSL;
using NUnit.Framework;

namespace UberDSLTests.Classes.Tests
{
    using static UberDSL.UberDSL;

    [TestFixture]
    public class DistributeSpec
    {
        private TestView viewA;
        private TestView viewB;
        private TestView viewC;
        private TestWindow window;

        [SetUp]
        public void CommonSetUp()
        {
            window = new TestWindow(
                new CGRect(0, 0, 400, 400)
            );

            viewA = new TestView();
            window.AddSubview(viewA);
            viewB = new TestView();
            window.AddSubview(viewB);
            viewC = new TestView();
            window.AddSubview(viewC);

            Constrain(viewA, viewB, viewC, (a, b, c) =>
            {
                a.Height.Equal(100);
                a.Width.Equal(100);

                a.Top.Equal(a.Superview.Top);
                a.Left.Equal(a.Superview.Left);

                b.Size.Equal(a.Size);
                c.Size.Equal(b.Size);
            });
        }

        private void VerticallySetUp()
        {
            Constrain(viewA, viewB, viewC, (a, b, c) =>
            {
                AlignCenterX(a, b, c);

                DistributeVertically(new[] { a, b, c }, 10);
            });

            window.LayoutIfNeeded();
        }

        private void LeftToRightSetUp()
        {
            Constrain(viewA, viewB, viewC, (a, b, c) =>
            {
                AlignCenterY(a, b, c);

                DistributeLeftToRight(a, 10, b, c);
            });

            window.LayoutIfNeeded();
        }

        [Test]
        public void FromLeftToRight()
        {
            LeftToRightSetUp();

            // Should distribute the views
            Assert.That(viewA.Frame.GetMinX(), Is.EqualTo(  0), "Should distribute the views");
            Assert.That(viewB.Frame.GetMinX(), Is.EqualTo(110), "Should distribute the views");
            Assert.That(viewC.Frame.GetMinX(), Is.EqualTo(220), "Should distribute the views");

            // Should disable translating autoresizing masks into constraints
            Assert.That(viewA.TranslatesAutoresizingMaskIntoConstraints, Is.False);
            Assert.That(viewA.TranslatesAutoresizingMaskIntoConstraints, Is.False);
            Assert.That(viewA.TranslatesAutoresizingMaskIntoConstraints, Is.False);
        }

        [Test]
        public void Vertically()
        {
            VerticallySetUp();

            // Should distribute the views
            Assert.That(viewA.Frame.GetMinY(), Is.EqualTo(  0), "Should distribute the views");
            Assert.That(viewB.Frame.GetMinY(), Is.EqualTo(110), "Should distribute the views");
            Assert.That(viewC.Frame.GetMinY(), Is.EqualTo(220), "Should distribute the views");

            // Should disable translating autoresizing masks into constraints
            Assert.That(viewA.TranslatesAutoresizingMaskIntoConstraints, Is.False);
            Assert.That(viewA.TranslatesAutoresizingMaskIntoConstraints, Is.False);
            Assert.That(viewA.TranslatesAutoresizingMaskIntoConstraints, Is.False);
        }

        [Test]
        public void NoConstraints()
        {
            // Should have no constraints for a single view distribution
            Constrain(viewA, (a) =>
            {
                var constraints = DistributeHorizontally(a);

                Assert.That(constraints.Length, Is.EqualTo(0), "Should have no constraints for a single view distribution");
            });

            // Should have no constraints for no view
            Constrain(viewA, (a) =>
            {
                var constraints = DistributeHorizontally(new LayoutProxy[0]);

                Assert.That(constraints.Length, Is.EqualTo(0), "Should have no constraints for no view");
            });
        }
    }
}
