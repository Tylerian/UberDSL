using System;

using UIKit;
using NUnit.Framework;

using UberDSL;
using CoreGraphics;

namespace UberDSLTests
{
    using static UberDSL.UberDSL;

    public class EdgeFixture
    {
        private TestView view;
        private TestWindow window;

        [SetUp]
        public void SetUp()
        {
            window = new TestWindow(
                new CGRect(0, 0, 400, 400)
            );

            view = new TestView();
            window.AddSubview(view);

            Constrain(view, (v) =>
            {
                v.Height.Equals(200);
                v.Width.Equals(200);
            });
        }

        private void SetUpInsets()
        {
            window.LayoutMargins = new UIEdgeInsets(10, 20, 30, 40);
        }

        [Test]
        public void LayoutProxyTop()
        {
            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Top.Equal(v.Superview.Top);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMinY(), Is.EqualTo(0), "Should support relative equalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Top.LessThanOrEqualTo(v.Superview.Top);
                v.Top.GreaterThanOrEqualTo(v.Superview.Top);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMinY(), Is.EqualTo(0), "Should support relative inequalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Top.Equal(v.Superview.Top + 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMinY(), Is.EqualTo(100), "Should support addition");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Top.Equal(v.Superview.Top - 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMinY(), Is.EqualTo(-100), "Should support substraction");
        }

        [Test]
        public void LayoutProxyRight()
        {
            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Right.Equal(v.Superview.Right);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMaxX(), Is.EqualTo(400), "Should support relative equalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Right.LessThanOrEqualTo(v.Superview.Right);
                v.Right.GreaterThanOrEqualTo(v.Superview.Right);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMaxX(), Is.EqualTo(400), "Should support relative inequalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Right.Equal(v.Superview.Right + 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMaxX(), Is.EqualTo(500), "Should support addition");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Right.Equal(v.Superview.Right - 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMaxX(), Is.EqualTo(300), "Should support substraction");
        }

        [Test]
        public void LayoutProxyBottom()
        {
            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Bottom.Equal(v.Superview.Bottom);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMaxY(), Is.EqualTo(400), "Should support relative equalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Bottom.LessThanOrEqualTo(v.Superview.Bottom);
                v.Bottom.GreaterThanOrEqualTo(v.Superview.Bottom);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMaxY(), Is.EqualTo(400), "Should support relative inequalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Bottom.Equal(v.Superview.Bottom + 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMaxY(), Is.EqualTo(500), "Should support addition");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Bottom.Equal(v.Superview.Bottom - 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMaxY(), Is.EqualTo(300), "Should support substraction");
        }

        [Test]
        public void LayoutProxyLeft()
        {
            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Left.Equal(v.Superview.Left);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMinY(), Is.EqualTo(0), "Should support relative equalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative inequalities
            Constrain(view, (v) =>
            {
                v.Left.LessThanOrEqualTo(v.Superview.Left);
                v.Left.GreaterThanOrEqualTo(v.Superview.Left);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMinY(), Is.EqualTo(0), "Should support relative inequalities");

            // Clear vars for next assertion
            SetUp();

            // Should support addition
            Constrain(view, (v) =>
            {
                v.Left.Equal(v.Superview.Left + 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMinX(), Is.EqualTo(100), "Should support addition");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Left.Equal(v.Superview.Left - 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMinX(), Is.EqualTo(-100), "Should support substraction");
        }

        [Test]
        public void LayoutProxyCenterX()
        {
            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterX.Equal(v.Superview.CenterX);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidX(), Is.EqualTo(200), "Should support relative equalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterX.LessThanOrEqualTo(v.Superview.CenterX);
                v.CenterX.GreaterThanOrEqualTo(v.Superview.CenterX);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidX(), Is.EqualTo(200), "Should support relative inequalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterX.Equal(v.Superview.CenterX + 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidX(), Is.EqualTo(300), "Should support addition");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterX.Equal(v.Superview.CenterX - 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidX(), Is.EqualTo(100), "Should support substraction");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterX.Equal(v.Superview.CenterX * 2);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidX(), Is.EqualTo(400), "Should support multiplication");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterX.Equal(v.Superview.CenterX / 2);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidX(), Is.EqualTo(100), "Should support division");
        }

        [Test]
        public void LayoutProxyCenterY()
        {
            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterY.Equal(v.Superview.CenterY);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidY(), Is.EqualTo(200), "Should support relative equalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterY.LessThanOrEqualTo(v.Superview.CenterY);
                v.CenterY.GreaterThanOrEqualTo(v.Superview.CenterY);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidY(), Is.EqualTo(200), "Should support relative inequalities");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterY.Equal(v.Superview.CenterY + 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidY(), Is.EqualTo(300), "Should support addition");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterY.Equal(v.Superview.CenterY - 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidY(), Is.EqualTo(100), "Should support substraction");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterY.Equal(v.Superview.CenterY * 2);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidY(), Is.EqualTo(400), "Should support multiplication");

            // Clear vars for next assertion
            SetUp();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.CenterY.Equal(v.Superview.CenterY / 2);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMidY(), Is.EqualTo(100), "Should support division");
        }

        [Test]
        public void LayoutProxyTopMargin()
        {
            SetUpInsets();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Top.Equal(v.Superview.TopMargin);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMinY(), Is.EqualTo(10));
        }

        [Test]
        public void LayoutProxyLeftMargin()
        {
            SetUpInsets();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Left.Equal(v.Superview.LeftMargin);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMinX(), Is.EqualTo(20));
        }

        [Test]
        public void LayoutProxyBottomMargin()
        {
            SetUpInsets();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Bottom.Equal(v.Superview.BottomMargin);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMaxY(), Is.EqualTo(370));
        }

        [Test]
        public void LayoutProxyRightMargin()
        {
            SetUpInsets();

            // Should support relative equalities
            Constrain(view, (v) =>
            {
                v.Right.Equal(v.Superview.RightMargin);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.GetMaxX(), Is.EqualTo(360));
        }
    }
}