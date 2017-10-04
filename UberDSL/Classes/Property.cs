using UIKit;

using System;

namespace UberDSL
{
    public interface IProperty
    {
        UIView View { get; }
        Context Context { get; }
        NSLayoutAttribute Attribute { get; }
    }

    public interface IAddition : IProperty, IRelativeEquality
    {
        Expression<IAddition> Add(nfloat c);
        Expression<IAddition> Substract(nfloat c);

      //Expression<IAddition> Add<T>(Expression<T> expression) where T : IAddition;
    }


    public interface IMultiplication : IProperty, IRelativeEquality
    {
        Expression<IMultiplication> Divide(nfloat m);
        Expression<IMultiplication> Multiply(nfloat m);
    }

    public interface IRelativeEquality : IProperty
    {
        LayoutConstraint Equal(LayoutSupport support);
        LayoutConstraint Equal(IRelativeEquality equality);
        LayoutConstraint Equal(Expression<LayoutSupport> expression);
        LayoutConstraint Equal<T>(Expression<T> expression) where T : IRelativeEquality;

        LayoutConstraint LessThanOrEqualTo(LayoutSupport support);
        LayoutConstraint LessThanOrEqualTo(Expression<LayoutSupport> expression);

        LayoutConstraint GreaterThanOrEqualTo(LayoutSupport support);
        LayoutConstraint GreaterThanOrEqualTo(Expression<LayoutSupport> expression);
    }

    public interface INumericalEquality : IProperty
    {
        LayoutConstraint Equal(nfloat value);
    }

    public interface IRelativeInequality : IProperty
    {
        LayoutConstraint LessThanOrEqualTo(IRelativeInequality inequality);
        LayoutConstraint GreaterThanOrEqualTo(IRelativeInequality inequality);
    }

    public interface INumericalInequality : IProperty
    {
        LayoutConstraint LessThanOrEqualTo(nfloat value);
        LayoutConstraint GreaterThanOrEqualTo(nfloat value);
    }
}