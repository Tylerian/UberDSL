using UIKit;
using CoreGraphics;
using NUnit.Framework;

namespace UberDSLTests
{
    using static UberDSL.UberDSL;

    [TestFixture]
    public class PriorityFixture
    {
        private TestView view;
        private TestWindow window;

        [SetUp]
        public void SetUp()
        {
            window = new TestWindow(
                new CGRect(0, 0, 200, 200)
            );

            view = new TestView();

            window.AddSubview(view);
        }

        [Test]
        public void SingleConstraint()
        {
            var constraint = (NSLayoutConstraint) null;

            Constrain(view, (v) =>
            {
                constraint = v.Width.Equal(200) ^ 155.7f;
            });

            Assert.That(constraint.Priority, Is.EqualTo(155.7f), "Should operate on a single constraint");
        }

        [Test]
        [Ignore("Not supported yet")]
        public void MultipleConstraints()
        {
            
        }
    }
}
