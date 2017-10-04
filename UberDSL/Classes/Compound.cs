using System;

using UIKit;

namespace UberDSL
{
    public interface ICompound
    {
        Context Context { get; }
        IProperty[] Properties { get; }
    }

    public interface IRelativeCompoundEquality : ICompound
    {
        LayoutConstraint[] Equal(IRelativeCompoundEquality compound);

        LayoutConstraint[] Equal<T>(Expression<T> expression) where T : IRelativeCompoundEquality;
    }

    public interface IRelativeCompoundInequality : ICompound
    {
        LayoutConstraint[] LessThanOrEqualTo(IRelativeCompoundInequality compound);

        LayoutConstraint[] GreaterThanOrEqualTo(IRelativeCompoundInequality compound);

        LayoutConstraint[] LessThanOrEqualTo<T>(Expression<T> expression) where T : IRelativeCompoundInequality;

        LayoutConstraint[] GreaterThanOrEqualTo<T>(Expression<T> expression) where T : IRelativeCompoundInequality;
    }
}
