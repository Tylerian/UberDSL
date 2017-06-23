using UIKit;
using System.Collections.Generic;

namespace UberDSL
{
    public static partial class Extensions
    {
        internal static List<UIView> Ancestrors(this UIView view)
        {
            var superview = view?.Superview;
            var ancestrors = new List<UIView>();

            while (superview != null)
            {
                ancestrors.Add(superview);
                superview = superview.Superview;
            }

            return ancestrors;
        }

        internal static UIView ClosestCommonAncestror(UIView a, UIView b)
        {
            var aSuper = a.Superview;
            var bSuper = b.Superview;

            if (ReferenceEquals(a, b)) return a;
            if (ReferenceEquals(a, bSuper)) return a;
            if (ReferenceEquals(b, aSuper)) return b;
            if (ReferenceEquals(aSuper, bSuper)) return aSuper;

            var ancestrorsOfA = a.Ancestrors();

            foreach (var ancestror in b.Ancestrors())
            {
                if (ancestrorsOfA.Contains(ancestror))
                {
                    return ancestror;
                }
            }

            return null;
        }
    }
}
