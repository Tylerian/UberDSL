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
        NSLayoutConstraint[] Equal(IRelativeCompoundEquality compound);

        NSLayoutConstraint[] Equal(Expression<IRelativeCompoundEquality> expression);
    }

    public interface IRelativeCompoundInequality : ICompound
    {
        NSLayoutConstraint[] LessThanOrEqualTo(IRelativeCompoundInequality compound);

        NSLayoutConstraint[] GreaterThanOrEqualTo(IRelativeCompoundInequality compound);

        NSLayoutConstraint[] LessThanOrEqualTo(Expression<IRelativeCompoundInequality> expression);

        NSLayoutConstraint[] GreaterThanOrEqualTo(Expression<IRelativeCompoundInequality> expression);
    }
}
