using System;

using UIKit;
using CoreGraphics;

using NUnit.Framework;

namespace UberDSLTests
{
    using static UberDSL.UberDSL;

    [TestFixture]
    public class ViewHierarchyFixture
    {
        [Test]
        //[Ignore("should throw an exception if the views share no common ancestor")]
        public void TestRaiseException()
        {
            TestDelegate td = () =>
            {
                var viewA = new TestView();
                var viewB = new TestView();

                Constrain(viewA, viewB, (a, b) =>
                {
                    a.Width.Equal(b.Width);
                });
            };

            Assert.That(td, Throws.TypeOf<Exception>(), "Should throw an exception if the views share no common ancestor");
        }

        [Test]
        public void TestSelfIsClosestCommonAncestror()
        {
            var view = new TestView();

            Constrain(view, v =>
            {
                v.Width.Equal(200);
            });

            Assert.That(view.Constraints.Length, Is.EqualTo(1), "Should consider a view its own closest common ancestor");
        }

        [Test]
        public void TestParentChildRelationship()
        {
            var parent = new TestView();
            var child = new TestView();

            parent.AddSubview(child);

            Constrain(parent, child, (p, c) =>
            {
                p.Width.Equal(c.Width);
            });

            Assert.That(parent.Constraints.Length, Is.EqualTo(1), "Should handle a direct parent-child-relationship");
        }

        /*it("should handle a grandparent-child-relationship") {
            let grandparent = TestView()
            let parent = TestView()
            let child = TestView()

            grandparent.addSubview(parent)
            parent.addSubview(child)

            constrain(grandparent, child) { grandparent, child in
                grandparent.width == child.width
            }

            expect(grandparent.constraints.count).to(equal(1))
        }
        */

        [Test]
        public void TestGrandparentChildRelationship()
        {
            var grandparent = new TestView();
            var parent = new TestView();
            var child = new TestView();

            grandparent.AddSubview(parent);
            parent.AddSubview(child);

            Constrain(grandparent, child, (g, c) =>
            {
                g.Width.Equal(c.Width);
            });

            Assert.That(grandparent.Constraints.Length, Is.EqualTo(1), "Should handle a grandparent-child-relationship");
        }

        [Test]
        public void TestViewsSharingParent()
        {
            var parent = new TestView();
            var childA = new TestView();
            var childB = new TestView();

            parent.AddSubview(childA);
            parent.AddSubview(childB);

            Constrain(childA, childB, (a, b) =>
            {
                a.Width.Equal(b.Width);
            });

            Assert.That(parent.Constraints.Length, Is.EqualTo(1), "Should handle views that share a parent");
        }

        [Test]
        public void TestViewsSharingGrandparent()
        {
            var grandparent = new TestView();
            var parentA = new TestView();
            var parentB = new TestView();
            var childA = new TestView();
            var childB = new TestView();

            grandparent.AddSubview(parentA);
            grandparent.AddSubview(parentB);
            parentA.AddSubview(childA);
            parentB.AddSubview(childB);

            Constrain(childA, childB, (a, b) =>
            {
                a.Width.Equal(b.Width);
            });

            Assert.That(grandparent.Constraints.Length, Is.EqualTo(1), "Should handle views that share a grandparent");
        }

        [Test]
        public void TestAsymmetricViewHierarchies()
        {
            var grandparent = new TestView();
            var parentA = new TestView();
            var parentB = new TestView();
            var childA = new TestView();

            grandparent.AddSubview(parentA);
            grandparent.AddSubview(parentB);
            parentA.AddSubview(childA);

            Constrain(childA, parentB, (a, b) =>
            {
                a.Width.Equal(b.Width);
            });

            Assert.That(grandparent.Constraints.Length, Is.EqualTo(1), "Should handle asymmetric view hierachies");
        }
    }
}
