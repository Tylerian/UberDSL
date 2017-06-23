using UIKit;

using System;

namespace UberDSL
{
    public class Size : ICompound, IRelativeCompoundEquality, IRelativeCompoundInequality
    {
        public Context Context { get; }
        public IProperty[] Properties { get; }

        internal Size(Context context, IProperty[] properties)
        {
            Context = context;
            Properties = properties;
        }

        #region IMultiplication Operators
        public static Expression<Size> operator *(nfloat m, Size rhs)
        {
            return new Expression<Size>(rhs, new[] { new Coefficients(m, 0), new Coefficients(m, 0) });
        }

        public static Expression<Size> operator *(Size lhs, nfloat rhs)
        {
            return rhs * lhs;
        }

        public static Expression<Size> operator /(Size lhs, nfloat rhs)
        {
            return lhs * (1 / rhs);
        }
        #endregion

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
