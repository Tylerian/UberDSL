using UIKit;
using System.Collections.Generic;
using System;

namespace UberDSL
{
    public static partial class Extensions
    {
        internal static List<UIView> Ancestors(this UIView view)
        {
            var ancestors = new List<UIView>();
            var superview = view?.Superview ?? view;

            while (superview != null)
            {
                ancestors.Add(superview);
                superview = superview.Superview;
            }

            return ancestors;
        }

        internal static UIView ClosestCommonAncestor(this UIView a, UIView b)
        {
            var aSuper = a.Superview;
            var bSuper = b.Superview;

            if (ReferenceEquals(a, b)) return a;
            if (ReferenceEquals(a, bSuper)) return a;
            if (ReferenceEquals(b, aSuper)) return b;
            if (ReferenceEquals(aSuper, bSuper)) return aSuper;

            var ancestorsOfA = a.Ancestors();
            var ancestorsOfB = b.Ancestors();

            foreach (var ancestor in ancestorsOfB)
            {
                if (ancestorsOfA.Contains(ancestor))
                {
                    return ancestor;
                }
            }

            return null;
        }
    }
}
