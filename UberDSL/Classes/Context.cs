using System;
using System.Collections.Generic;

using UIKit;

namespace UberDSL
{
    public class Context
    {
        private List<Constraint> _constraints;

        internal Constraint[] Constraints
        {
            get
            {
                return _constraints.ToArray();
            }
        }

        internal Context()
        {
            _constraints = new List<Constraint>();
        }

        internal LayoutConstraint AddConstraint(IProperty from, LayoutSupport to, Coefficients coefficients = null, NSLayoutRelation relation = default(NSLayoutRelation))
        {
            if (coefficients == null)
            {
                coefficients = new Coefficients();
            }

            from.View.TranslatesAutoresizingMaskIntoConstraints = false;

            var constraint = NSLayoutConstraint.Create(
                from.View,
                from.Attribute,
                relation,
                to.LayoutGuide,
                to.Attribute,
                coefficients.Multiplier,
                coefficients.Constant
            );

            var view = from.View;

            while (view?.Superview != null)
            {
                view = view.Superview;
            }

            _constraints.Add(new Constraint(view, constraint));

            return constraint;
        }

        internal LayoutConstraint AddConstraint(IProperty from, IProperty to = null, Coefficients coefficients = null, NSLayoutRelation relation = default(NSLayoutRelation))
        {
            if (coefficients == null)
            {
                coefficients = new Coefficients();
            }

            from.View.TranslatesAutoresizingMaskIntoConstraints = false;

            var constraint = NSLayoutConstraint.Create(
                from.View,
                from.Attribute,
                relation,
                to?.View,
                to?.Attribute ?? NSLayoutAttribute.NoAttribute,
                coefficients.Multiplier,
                coefficients.Constant
            );

            if (to == null)
            {
                _constraints.Add(new Constraint(from.View, constraint));
            }

            else
            {
                var common = from.View.ClosestCommonAncestor(to.View);

                if (common != null)
                {
                    _constraints.Add(new Constraint(common, constraint));
                }

                else
                {
                    throw new Exception($"No common superview found between ${from.View} and ${to.View}");
                }
            }

            return constraint;
        }

        internal LayoutConstraint[] AddConstraint(ICompound from, ICompound to = null, Coefficients[] coefficients = null, NSLayoutRelation relation = default(NSLayoutRelation))
        {
            var results = new List<LayoutConstraint>();

            for (var i = 0; i < from.Properties.Length; i++)
            {
                var n = coefficients?[i] ?? new Coefficients();

                results.Add(AddConstraint(from.Properties[i], to: to?.Properties?[i], coefficients: n, relation: relation));
            }

            return results.ToArray();
        }
    }
}