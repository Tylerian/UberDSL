using UIKit;
using Foundation;
using CoreGraphics;

using UberDSL;

using NUnit.Framework;
using System;

namespace UberDSLTests
{
    using static UberDSL.UberDSL;

    [TestFixture]
    public class AlignFixture
    {
        private TestView viewA;
        private TestView viewB;
        private TestView viewC;

        private TestWindow window;

        [TestFixtureSetUp]
        public void SetUp()
        {
            window = new TestWindow(
                CGRect.FromLTRB(0, 0, 400, 400)
            );

            viewA = new TestView();
            window.AddSubview(viewA);

            viewB = new TestView();
            window.AddSubview(viewB);

            viewC = new TestView();
            window.AddSubview(viewC);

            Constrain(viewA, (a) =>
            {
                a.Width.Equal(100);
                a.Height.Equal(200);

                a.Top.Equal(a.Superview.Top   + 10);
                a.Left.Equal(a.Superview.Left + 10);
            });
        }

        [Test]
        public void AlignForEdges()
        {
            Constrain(viewA, viewB, viewC, (a, b, c) =>
            {
                AlignTop(a, b, c);
                AlignRight(a, b, c);
                AlignBottom(a, b, c);
                AlignLeft(a, b, c);
            });

            // Should align edges
            Assert.AreEqual(viewA.Frame, viewB.Frame);
            Assert.AreEqual(viewA.Frame, viewB.Frame);

            // Should disable translating autoresizing masks into constraints
            Assert.False(viewA.TranslatesAutoresizingMaskIntoConstraints);
            Assert.False(viewB.TranslatesAutoresizingMaskIntoConstraints);
            Assert.False(viewC.TranslatesAutoresizingMaskIntoConstraints);
        }

        [Test]
        public void AlignForHorizontalAndVerticalCenters()
        {
            Constrain(viewA, viewB, viewC, (a, b, c) =>
            {
                a.Size.Equal(b.Size);
                b.Size.Equal(c.Size);

                AlignCenterX(a, b, c);
                AlignCenterY(a, b, c);
            });

            // Should align center points
            Assert.AreEqual(viewA.Frame, viewB.Frame);
            Assert.AreEqual(viewA.Frame, viewB.Frame);

            // Should disable translating autoresizing masks into constraints
            Assert.False(viewA.TranslatesAutoresizingMaskIntoConstraints);
            Assert.False(viewB.TranslatesAutoresizingMaskIntoConstraints);
            Assert.False(viewC.TranslatesAutoresizingMaskIntoConstraints);
        }

        [Test]
        public void AlignForNoConstraints()
        {
            // Should have no constraints for a single view alignment
            Constrain(viewA, (a) =>
            {
                var constraints = AlignTop(new[] { a });

                Assert.AreEqual(0, constraints.Length);
            });

            // should have no constraints for no view
            var constraints1 = AlignTop(new LayoutProxy[] { });
            Assert.AreEqual(0, constraints1.Length);
        }
    }
}
