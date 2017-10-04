using System;

using UIKit;
using CoreGraphics;

using NUnit.Framework;

namespace UberDSLTests
{
    using static UberDSL.UberDSL;
    [TestFixture]
    public class MemoryLeakFixture
    {
        private WeakReference<TestView> weak_viewA;
        private WeakReference<TestView> weak_viewB;
        private WeakReference<TestView> weak_superview;

        [TestFixtureSetUp]
        public void SetUp()
        {
            var superview = new TestView(new CGRect(0, 0, 400, 400));

            var viewA = new TestView(new CGRect(0, 0, 200, 200));
            superview.AddSubview(viewA);

            var viewB = new TestView(new CGRect(0, 0, 200, 200));
            superview.AddSubview(viewB);

            Constrain(viewA, viewB, (a, b) =>
            {
                a.Top.Equal(b.Top);
                a.Bottom.Equal(b.Bottom);
            });

            weak_viewA = new WeakReference<TestView>(viewA);
            weak_viewB = new WeakReference<TestView>(viewB);
            weak_superview = new WeakReference<TestView>(superview);
        }

        [Test]
        public void AssertMemoryLeak()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Assert.That(weak_viewA.TryGetTarget(out var x), Is.False);
            Assert.That(weak_viewB.TryGetTarget(out var y), Is.False);
            Assert.That(weak_superview.TryGetTarget(out var z), Is.False);
        }
    }
}
