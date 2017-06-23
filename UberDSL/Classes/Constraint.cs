using System;

using UIKit;

namespace UberDSL
{
    internal class Constraint
    {
        internal UIView View { get; }
        internal NSLayoutConstraint LayoutConstraint { get; }

        internal void Install()
        {
            View?.AddConstraint(LayoutConstraint);
        }

        internal void Uninstall()
        {
            View?.RemoveConstraint(LayoutConstraint);
        }

        internal Constraint(UIView view, NSLayoutConstraint layoutConstraint)
        {
            View = view;
            LayoutConstraint = LayoutConstraint;
        }
    }
}
