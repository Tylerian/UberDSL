using UIKit;

using System;

namespace UberDSL
{
    public class Edge : IProperty, IRelativeEquality, IRelativeInequality, IAddition, IMultiplication
    {
        public UIView View { get; }
        public Context Context { get; }
        public NSLayoutAttribute Attribute { get; }

        internal Edge(Context context, UIView view, NSLayoutAttribute attribute)
        {
            View = view;
            Context = context;
            Attribute = attribute;
        }

        #region IAddition Operators
        public Expression<IAddition> Add(nfloat c)
        {
            return new Expression<IAddition>(this, new[] { new Coefficients(1, c) });
        }

        public Expression<IAddition> Substract(nfloat c)
        {
            return new Expression<IAddition>(this, new[] { new Coefficients(1, -c) });
        }

        public static Expression<IAddition> operator +(nfloat c, Edge rhs)
        {
            return rhs.Add(c);
        }

        public static Expression<IAddition> operator +(Edge lhs, nfloat rhs)
        {
            return rhs + lhs;
        }

        public static Expression<IAddition> operator -(nfloat c, Edge rhs)
        {
            return rhs.Substract(c);
        }

        public static Expression<IAddition> operator -(Edge lhs, nfloat rhs)
        {
            return rhs - lhs;
        }
        #endregion

        #region IMultiplication Operators
        public Expression<IMultiplication> Divide(nfloat m)
        {
            return Multiply(1 / m);
        }

        public Expression<IMultiplication> Multiply(nfloat m)
        {
            return new Expression<IMultiplication>(this, new[] { new Coefficients(m, 0) });
        }

        public static Expression<IMultiplication> operator *(nfloat m, Edge rhs)
        {
            return rhs.Multiply(m);
        }

        public static Expression<IMultiplication> operator *(Edge lhs, nfloat rhs)
        {
            return rhs * lhs;
        }

        public static Expression<IMultiplication> operator /(Edge lhs, nfloat rhs)
        {
            return lhs.Divide(rhs);
        }
        #endregion

        #region IRelativeEquality Operators
        public NSLayoutConstraint Equal(LayoutSupport support)
        {
            return Context.AddConstraint(this, to: support);
        }

        public NSLayoutConstraint Equal(IRelativeEquality equality)
        {
            return Context.AddConstraint(this, to: equality);
        }

        public NSLayoutConstraint Equal(Expression<IAddition> expression)
        {
            return Context.AddConstraint(this, to: expression.Value, coefficients: expression.Coefficients?[0]);
        }

        public NSLayoutConstraint Equal(Expression<LayoutSupport> expression)
        {
            return Context.AddConstraint(this, to: expression.Value, coefficients: expression.Coefficients?[0]);
        }


        public NSLayoutConstraint LessThanOrEqualTo(LayoutSupport support)
        {
            return Context.AddConstraint(this, to: support, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public NSLayoutConstraint LessThanOrEqualTo(Expression<LayoutSupport> expression)
        {
            return Context.AddConstraint(this, to: expression.Value, coefficients: expression.Coefficients?[0], relation: NSLayoutRelation.LessThanOrEqual);
        }


        public NSLayoutConstraint GreaterThanOrEqualTo(LayoutSupport support)
        {
            return Context.AddConstraint(this, to: support, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        public NSLayoutConstraint GreaterThanOrEqualTo(Expression<LayoutSupport> expression)
        {
            return Context.AddConstraint(this, to: expression.Value, coefficients: expression.Coefficients?[0], relation: NSLayoutRelation.GreaterThanOrEqual);
        }
        #endregion

        #region IRelativeInequality Operators
        public NSLayoutConstraint LessThanOrEqualTo(IRelativeInequality inequality)
        {
            return Context.AddConstraint(this, to: inequality, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public NSLayoutConstraint GreaterThanOrEqualTo(IRelativeInequality inequality)
        {
            return Context.AddConstraint(this, to: inequality, relation: NSLayoutRelation.GreaterThanOrEqual);
        }
        #endregion
    }
}
