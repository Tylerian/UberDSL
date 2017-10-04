using UIKit;

using System;

namespace UberDSL
{
    public class Point : ICompound, IRelativeCompoundEquality, IRelativeCompoundInequality
    {
        public Context Context { get; }
        public IProperty[] Properties { get; }

        internal Point(Context context, IProperty[] properties)
        {
            Context = context;
            Properties = properties;
        }

        #region IRelativeCompoundEquality Operators
        public LayoutConstraint[] Equal(IRelativeCompoundEquality compound)
        {
            return Context.AddConstraint(this, to: compound);
        }

        public LayoutConstraint[] Equal<T>(Expression<T> expression) where T : IRelativeCompoundEquality
        {
            return Context.AddConstraint(this, to: expression.Value, coefficients: expression.Coefficients);
        }
        #endregion

        #region IRelativeCompoundInequality Operators
        public LayoutConstraint[] LessThanOrEqualTo(IRelativeCompoundInequality compound)
        {
            return Context.AddConstraint(this, to: compound, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public LayoutConstraint[] GreaterThanOrEqualTo(IRelativeCompoundInequality compound)
        {
            return Context.AddConstraint(this, to: compound, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        public LayoutConstraint[] LessThanOrEqualTo<T>(Expression<T> expression) where T : IRelativeCompoundInequality
        {
            return Context.AddConstraint(this, to: expression.Value, coefficients: expression.Coefficients, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public LayoutConstraint[] GreaterThanOrEqualTo<T>(Expression<T> expression) where T : IRelativeCompoundInequality
        {
            return Context.AddConstraint(this, to: expression.Value, coefficients: expression.Coefficients, relation: NSLayoutRelation.GreaterThanOrEqual);
        }
        #endregion
    }
}