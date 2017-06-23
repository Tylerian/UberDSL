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
        public NSLayoutConstraint[] Equal(IRelativeCompoundEquality compound)
        {
            return Context.AddConstraint(this, to: compound);
        }

        public NSLayoutConstraint[] Equal(Expression<IRelativeCompoundEquality> expression)
        {
            return Context.AddConstraint(this, to: expression.Value, coefficients: expression.Coefficients);
        }
        #endregion

        #region IRelativeCompoundInequality Operators
        public NSLayoutConstraint[] LessThanOrEqualTo(IRelativeCompoundInequality compound)
        {
            return Context.AddConstraint(this, to: compound, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public NSLayoutConstraint[] GreaterThanOrEqualTo(IRelativeCompoundInequality compound)
        {
            return Context.AddConstraint(this, to: compound, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        public NSLayoutConstraint[] LessThanOrEqualTo(Expression<IRelativeCompoundInequality> expression)
        {
            return Context.AddConstraint(this, to: expression.Value, coefficients: expression.Coefficients, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public NSLayoutConstraint[] GreaterThanOrEqualTo(Expression<IRelativeCompoundInequality> expression)
        {
            return Context.AddConstraint(this, to: expression.Value, coefficients: expression.Coefficients, relation: NSLayoutRelation.GreaterThanOrEqual);
        }
        #endregion
    }
}