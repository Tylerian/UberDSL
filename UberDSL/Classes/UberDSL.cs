using UIKit;

using System;
using System.Linq;
using System.Collections.Generic;

namespace UberDSL
{
    public static class UberDSL
    {
        #region Align Methods
        public static NSLayoutConstraint[] AlignTop(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Bottom, views);
        }

        public static NSLayoutConstraint[] AlignTop(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignTop(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignLeft(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Left, views);
        }

        public static NSLayoutConstraint[] AlignLeft(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignLeft(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignRight(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Right, views);
        }

        public static NSLayoutConstraint[] AlignRight(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignRight(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignBottom(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Bottom, views);
        }

        public static NSLayoutConstraint[] AlignBottom(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignBottom(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignLeading(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Leading, views);
        }

        public static NSLayoutConstraint[] AlignLeading(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignLeading(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignTrailing(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Trailing, views);
        }

        public static NSLayoutConstraint[] AlignTrailing(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignTrailing(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignCenterX(LayoutProxy[] views)
        {
            return MakeEquals(x => x.CenterX, views);
        }

        public static NSLayoutConstraint[] AlignCenterX(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignCenterX(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignCenterY(LayoutProxy[] views)
        {
            return MakeEquals(x => x.CenterY, views);
        }

        public static NSLayoutConstraint[] AlignCenterY(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignCenterY(new[] { first }.Merge(rest));
        }

        public static NSLayoutConstraint[] AlignBaseline(LayoutProxy[] views)
        {
            return MakeEquals(x => x.Baseline, views);
        }

        public static NSLayoutConstraint[] AlignBaseline(LayoutProxy first, params LayoutProxy[] rest)
        {
            return AlignBaseline(new[] { first }.Merge(rest));
        }

        private static NSLayoutConstraint[] MakeEquals(Func<LayoutProxy, IRelativeEquality> attribute, LayoutProxy[] elements)
        {
            var  first = (LayoutProxy)null;

            if ((first = elements?.FirstOrDefault()) != null)
            {
                first.View.TranslatesAutoresizingMaskIntoConstraints = false;

                var rest = elements.Slice(1);

                return rest.Select(x => {
                    x.View.TranslatesAutoresizingMaskIntoConstraints = false;
                    return (NSLayoutConstraint) attribute(first).Equal(attribute(x));
                }).ToArray();
            }

            return Array.Empty<NSLayoutConstraint>();
        }
        #endregion

        #region Constrain Methods
        public static void ClearConstrains(ConstraintGroup group)
        {
            group.ReplaceConstraints(Array.Empty<Constraint>());
        }

        public static ConstraintGroup Constrain(UIView view, Action<LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(new LayoutProxy(context, view));
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView[] views, Action<LayoutProxy[]> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();
            var proxies = views.Select(x => new LayoutProxy(context, x)).ToArray();

            closure(proxies);
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView view1, UIView view2, Action<LayoutProxy, LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(
                new LayoutProxy(context, view1),
                new LayoutProxy(context, view2)
            );
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView view1, UIView view2, UIView view3, Action<LayoutProxy, LayoutProxy, LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(
                new LayoutProxy(context, view1),
                new LayoutProxy(context, view2),
                new LayoutProxy(context, view3)
            );
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView view1, UIView view2, UIView view3, UIView view4, Action<LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(
                new LayoutProxy(context, view1),
                new LayoutProxy(context, view2),
                new LayoutProxy(context, view3),
                new LayoutProxy(context, view4)
            );
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView view1, UIView view2, UIView view3, UIView view4, UIView view5, Action<LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(
                new LayoutProxy(context, view1),
                new LayoutProxy(context, view2),
                new LayoutProxy(context, view3),
                new LayoutProxy(context, view4),
                new LayoutProxy(context, view5)
            );
            group.ReplaceConstraints(context.Constraints);

            return group;
        }

        public static ConstraintGroup Constrain(UIView view1, UIView view2, UIView view3, UIView view4, UIView view5, UIView view6, Action<LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy, LayoutProxy> closure, ConstraintGroup group = null)
        {
            var context = new Context();
                group   = group ?? new ConstraintGroup();

            closure(
                new LayoutProxy(context, view1),
                new LayoutProxy(context, view2),
                new LayoutProxy(context, view3),
                new LayoutProxy(context, view4),
                new LayoutProxy(context, view5),
                new LayoutProxy(context, view6)
            );
            group.ReplaceConstraints(context.Constraints);

            return group;
        }
        #endregion

        #region Inset Methods
        public static Expression<Edges> Inset(Edges edges, nfloat all)
        {
            return Inset(edges, all, all, all, all);
        }

        public static Expression<Edges> Inset(Edges edges, UIEdgeInsets insets)
        {
            return Inset(edges, insets.Top, insets.Left, insets.Bottom, insets.Right);
        }

        public static Expression<Edges> Inset(Edges edges, nfloat horizontal, nfloat vertical)
        {
            return Inset(edges, vertical, horizontal, vertical, horizontal);
        }

        public static Expression<Edges> Inset(Edges edges, nfloat top, nfloat leading, nfloat bottom, nfloat trailing)
        {
            return new Expression<Edges>(edges, new[] {
                new Coefficients(1, top),
                new Coefficients(1, leading),
                new Coefficients(1, -bottom),
                new Coefficients(1, -trailing)
            });
        }
        #endregion

        #region Distribute Methods
        public static NSLayoutConstraint[] DistributeVertically(LayoutProxy[] views, nfloat amount = default(nfloat))
        {
            return Reduce(views, (x, y) => x.Bottom.Equal(y.Top - amount));
        }

        public static NSLayoutConstraint[] DistributeLeftToRight(LayoutProxy[] views, nfloat amount = default(nfloat))
        {
            return Reduce(views, (x, y) => x.Right.Equal(y.Left - amount));
        }

        public static NSLayoutConstraint[] DistributeHorizontally(LayoutProxy[] views, nfloat amount = default(nfloat))
        {
            return Reduce(views, (x, y) => x.Trailing.Equal(y.Leading - amount));
        }

        public static NSLayoutConstraint[] DistributeVertically(LayoutProxy first, nfloat amount = default(nfloat), params LayoutProxy[] rest)
        {
            return DistributeVertically(new[] { first }.Merge(rest), amount);
        }

        public static NSLayoutConstraint[] DistributeLeftToRight(LayoutProxy first, nfloat amount = default(nfloat), params LayoutProxy[] rest)
        {
            return DistributeLeftToRight(new[] { first }.Merge(rest), amount);
        }

        public static NSLayoutConstraint[] DistributeHorizontally(LayoutProxy first, nfloat amount = default(nfloat), params LayoutProxy[] rest)
        {
            return DistributeHorizontally(new[] { first }.Merge(rest), amount);
        }

        private static NSLayoutConstraint[] Reduce(LayoutProxy[] elements, Func<LayoutProxy, LayoutProxy, NSLayoutConstraint> closure)
        {
            var lastElement  = elements.LastOrDefault();
            var firstElement = elements.FirstOrDefault();

            if (lastElement != null)
            {
                lastElement.View.TranslatesAutoresizingMaskIntoConstraints = false;
            }

            if (firstElement != null)
            {
                var rest = elements.Slice(1);

                var reduce = new List<NSLayoutConstraint>();

                for (var i = 0; i < rest.Length; i++)
                {
                    var current  = rest[i];
                    var previous = (i == 0) ? firstElement : rest[i - 1];

                    reduce.Add(closure(previous, current));
                }
                
                return reduce.ToArray();
            }

            return Array.Empty<NSLayoutConstraint>();
        }
        #endregion
    }
}
