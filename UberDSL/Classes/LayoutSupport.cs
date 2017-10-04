using UIKit;

using System;

namespace UberDSL
{
    public class LayoutSupport
    {
        public IUILayoutSupport  LayoutGuide { get; }
        public NSLayoutAttribute Attribute   { get; }

        public LayoutSupport(IUILayoutSupport layoutGuide, NSLayoutAttribute layoutAttribute)
        {
            LayoutGuide = layoutGuide;
            Attribute   = layoutAttribute;
        }

        public static Expression<LayoutSupport> operator +(LayoutSupport lhs, nfloat c)
        {
            return new Expression<LayoutSupport>(lhs, new[] { new Coefficients(1, c) });
        }

        public static Expression<LayoutSupport> operator -(LayoutSupport lhs, nfloat c)
        {
            return lhs + (-c);
        }
    }
}
