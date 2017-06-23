using System;
using System.Linq;

namespace UberDSL
{
    public class ConstraintGroup
    {
        private Constraint[] _constraints;

        internal bool Active
        {
            get
            {
                return _constraints
                    .Select(x => x.LayoutConstraint.Active)
                    .Aggregate((x, y) => x && y);
            }

            set
            {
                foreach (var constraint in _constraints)
                {
                    constraint.LayoutConstraint.Active = value;
                }
            }
        }

        public ConstraintGroup()
        {
            _constraints = new Constraint[0];
        }

        internal void ReplaceConstraints(Constraint[] constraints)
        {
            foreach (var constraint in _constraints)
            {
                constraint.Uninstall();
            }

            _constraints = constraints;

            foreach (var constraint in _constraints)
            {
                constraint.Install();
            }
        }
    }
}
