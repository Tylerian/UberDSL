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

    public interface IAddition : IProperty
    {
        Expression<IAddition> Add(nfloat c);
        Expression<IAddition> Substract(nfloat c);
    }


    public interface IMultiplication : IProperty
    {
        Expression<IMultiplication> Divide(nfloat m);
        Expression<IMultiplication> Multiply(nfloat m);
    }

    public interface IRelativeEquality : IProperty
    {
        NSLayoutConstraint Equal(LayoutSupport support);
        NSLayoutConstraint Equal(IRelativeEquality equality);
        NSLayoutConstraint Equal(Expression<LayoutSupport> expression);

        NSLayoutConstraint LessThanOrEqualTo(LayoutSupport support);
        NSLayoutConstraint LessThanOrEqualTo(Expression<LayoutSupport> expression);

        NSLayoutConstraint GreaterThanOrEqualTo(LayoutSupport support);
        NSLayoutConstraint GreaterThanOrEqualTo(Expression<LayoutSupport> expression);
    }

    public interface INumericalEquality : IProperty
    {
        NSLayoutConstraint Equal(nfloat value);
    }

    public interface IRelativeInequality : IProperty
    {
        NSLayoutConstraint LessThanOrEqualTo(IRelativeInequality inequality);
        NSLayoutConstraint GreaterThanOrEqualTo(IRelativeInequality inequality);
    }

    public interface INumericalInequality : IProperty
    {
        NSLayoutConstraint LessThanOrEqualTo(nfloat value);
        NSLayoutConstraint GreaterThanOrEqualTo(nfloat value);
    }
}