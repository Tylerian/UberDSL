using System;
using System.Linq;

namespace UberDSL
{
    public interface IExpression<T>
    {
        T Value { get; }
        Coefficients[] Coefficients { get; }
    }

    public class Expression<T> : IExpression<T>
    {
        public T Value { get; }
        public Coefficients[] Coefficients { get; }

        public Expression(T value, Coefficients[] coefficients)
        {
            Value = value;
            Coefficients = coefficients;
        }

        #region IAddition operators
        public Expression<T> Add(nfloat c)
        {
            return new Expression<T>(
                Value, Coefficients.Select(x => x + c).ToArray()
            );
        }

        public Expression<T> Substract(nfloat c)
        {
            return new Expression<T>(
                Value, Coefficients.Select(x => x - c).ToArray()
            );
        }

        public static Expression<T> operator +(nfloat c, Expression<T> rhs)
        {
            return rhs.Add(c);
        }

        public static Expression<T> operator +(Expression<T> lhs, nfloat rhs)
        {
            return rhs + lhs;
        }

        public static Expression<T> operator -(nfloat c, Expression<T> rhs)
        {
            return rhs.Substract(c);
        }

        public static Expression<T> operator -(Expression<T> lhs, nfloat rhs)
        {
            return rhs - lhs;
        }
        #endregion
    }
}
