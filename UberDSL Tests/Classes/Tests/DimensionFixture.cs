using System;

using UIKit;
using NUnit.Framework;

using UberDSL;
using CoreGraphics;

namespace UberDSLTests
{
    using static UberDSL.UberDSL;

    public class DimensionFixture
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
        }

        [Test]
        public void LayoutProxyWidth()
        {
            // Should support relative equalities
            Constrain(view, (x) =>
            {
                x.Width.Equal(x.Superview.Width);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Width, Is.EqualTo(400), "Should support relative equalities.");

            // Reset test variables
            SetUp();

            // Should support relative inequalities
            Constrain(view, (x) =>
            {
                x.Width.LessThanOrEqualTo(x.Superview.Width);
                x.Width.GreaterThanOrEqualTo(x.Superview.Width);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Width, Is.EqualTo(400), "Should support relative inequalities.");

            // Reset test variables
            SetUp();

            // Should support addition
            Constrain(view, (x) =>
            {
                x.Width.Equal(x.Superview.Width + 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Width, Is.EqualTo(500), "Should support addition.");

            // Reset test variables
            SetUp();

            // Should support substraction
            Constrain(view, (x) =>
            {
                x.Width.Equal(x.Superview.Width - 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Width, Is.EqualTo(300), "Should support substraction.");

            // Reset test variables
            SetUp();

            // Should support multiplication
            Constrain(view, (x) =>
            {
                x.Width.Equal(x.Superview.Width * 2);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Width, Is.EqualTo(800), "Should support multiplication.");

            // Reset test variables
            SetUp();

            // Should support division
            Constrain(view, (x) =>
            {
                x.Width.Equal(x.Superview.Width / 2);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Width, Is.EqualTo(200), "Should support division.");

            // Reset test variables
            SetUp();

            // Should support complex expressions
            Constrain(view, (x) =>
            {
                x.Width.Equal(x.Superview.Width / 2 + 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Width, Is.EqualTo(300), "Should support complex expressions.");

            // Reset test variables
            SetUp();

            // Should support numerical equalities
            Constrain(view, (x) =>
            {
                x.Width.Equal(200);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Width, Is.EqualTo(200), "Should support numerical equalities.");
        }

        [Test]
        public void LayoutProxyHeight()
        {
            // Should support relative equalities
            Constrain(view, (x) =>
            {
                x.Height.Equal(x.Superview.Height);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Height, Is.EqualTo(400), "Should support relative equalities.");

            // Reset test variables
            SetUp();

            // Should support relative inequalities
            Constrain(view, (x) =>
            {
                x.Height.LessThanOrEqualTo(x.Superview.Height);
                x.Height.GreaterThanOrEqualTo(x.Superview.Height);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Height, Is.EqualTo(400), "Should support relative inequalities.");

            // Reset test variables
            SetUp();

            // Should support addition
            Constrain(view, (x) =>
            {
                x.Height.Equal(x.Superview.Height + 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Height, Is.EqualTo(500), "Should support addition.");

            // Reset test variables
            SetUp();

            // Should support substraction
            Constrain(view, (x) =>
            {
                x.Height.Equal(x.Superview.Height - 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Height, Is.EqualTo(300), "Should support substraction.");

            // Reset test variables
            SetUp();

            // Should support multiplication
            Constrain(view, (x) =>
            {
                x.Height.Equal(x.Superview.Height * 2);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Height, Is.EqualTo(800), "Should support multiplication.");

            // Reset test variables
            SetUp();

            // Should support division
            Constrain(view, (x) =>
            {
                x.Height.Equal(x.Superview.Height / 2);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Height, Is.EqualTo(200), "Should support division.");

            // Reset test variables
            SetUp();

            // Should support complex expressions
            Constrain(view, (x) =>
            {
                x.Height.Equal(x.Superview.Height / 2 + 100);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Height, Is.EqualTo(300), "Should support complex expressions.");

            // Reset test variables
            SetUp();

            // Should support numerical equalities
            Constrain(view, (x) =>
            {
                x.Height.Equal(200);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame.Height, Is.EqualTo(200), "Should support numerical equalities.");
        }
    }
}
