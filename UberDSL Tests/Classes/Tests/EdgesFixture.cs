
using UIKit;
using CoreGraphics;

using UberDSL;

using NUnit.Framework;

namespace UberDSLTests
{
    using static UberDSL.UberDSL;

    [TestFixture]
    public class EdgesFixture
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

        [SetUp]
        public void SetUpMargins()
        {
            window.LayoutMargins = new UIEdgeInsets(10, 20, 30, 40);
        }

        [Test]
        public void LayoutProxyEdgesEqualities()
        {
            Constrain(view, v =>
            {
                v.Edges.Equal(v.Superview.Edges);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame, Is.EqualTo(view.Superview.Frame), "should support relative equalities");
        }

        [Test]
        public void LayoutProxyEdgesInequalities()
        {
            Constrain(view, v =>
            {
                v.Edges.LessThanOrEqualTo(v.Superview.Edges);
                v.Edges.GreaterThanOrEqualTo(v.Superview.Edges);
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame, Is.EqualTo(view.Superview.Frame), "should support relative inequalities");
        }

        [Test]
        public void InsetAllEdges()
        {
            Constrain(view, v =>
            {
                v.Edges.Equal(Inset(v.Superview.Edges, 20));
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame, Is.EqualTo(new CGRect(20, 20, 360, 360)), "Should inset all edges with the same amount");
        }

        [Test]
        public void InsetHorizontalVerticalEdges()
        {
            Constrain(view, v =>
            {
                v.Edges.Equal(Inset(v.Superview.Edges, 20, 30));
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame, Is.EqualTo(new CGRect(20, 30, 360, 340)), "Should inset the horizontal and vertical edge individually");
        }

        [Test]
        public void InsetAllEdgesIndividually()
        {
            Constrain(view, v =>
            {
                v.Edges.Equal(Inset(v.Superview.Edges, 10, 20, 30, 40));
            });

            window.LayoutIfNeeded();

            Assert.That(view.Frame, Is.EqualTo(new CGRect(20, 10, 340, 360)), "Should inset all edges individually");
        }

        [Test]
        public void ProxyLayoutEdgesWithinMargins()
        {
            Constrain(view, v =>
            {
                v.Edges.Equal(v.Superview.EdgesWithinMargins);
            });

            window.LayoutIfNeeded();


            Assert.That(view.Frame, Is.EqualTo(new CGRect(20, 10, 340, 360)), "Should inset all edges individually");
        }

        [Test]
        public void ProxyLayoutEdgesUsingEdgeInsets()
        {
            Constrain(view, v =>
            {
                var insets = new UIEdgeInsets(10, 20, 30, 40);

                v.Edges.Equal(
                    Inset(v.Superview.Edges, insets)
                );
            });

            window.LayoutIfNeeded();


            Assert.That(view.Frame, Is.EqualTo(new CGRect(20, 10, 340, 360)), "Should inset all edges individually");
        }
    }
}