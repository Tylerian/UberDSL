using System;

using UIKit;

namespace UberDSL
{
    public class Edges : ICompound, IRelativeCompoundEquality, IRelativeCompoundInequality
    {
        public Context Context { get; }
        public IProperty[] Properties { get; }

        public Edges(Context context, IProperty[] properties)
        {
            Context = context;
            Properties = properties;
        }

        public Expression<Edges> Inset(Edges edges, nfloat all)
        {
            return Inset(edges, all, all, all, all);
        }

        public Expression<Edges> Inset(Edges edges, UIKit.UIEdgeInsets insets)
        {
            return Inset(edges, insets.Top, insets.Left, insets.Bottom, insets.Right);
        }

        public Expression<Edges> Inset(Edges edges, nfloat horizontal, nfloat vertical)
        {
            return Inset(edges, horizontal, vertical, horizontal, vertical);
        }

        public Expression<Edges> Inset(Edges edges, nfloat top, nfloat leading, nfloat bottom, nfloat trailing)
        {
            return new Expression<Edges>(edges, new[] {
                new Coefficients(1, top),
                new Coefficients(1, leading),
                new Coefficients(1, -bottom),
                new Coefficients(1, -trailing)
            });
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
