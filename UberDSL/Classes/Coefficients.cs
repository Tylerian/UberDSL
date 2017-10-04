using System;

namespace UberDSL
{
    public class Coefficients
    {
        internal nfloat Constant
        {
            get;
            set;
        }

        internal nfloat Multiplier
        {
            get;
            set;
        }

        internal Coefficients()
        {
            Constant = 0.0f;
            Multiplier = 1.0f;
        }

        internal Coefficients(nfloat multiplier, nfloat constant)
        {
            Constant = constant;
            Multiplier = multiplier;
        }

        #region IAddition Operators
        public Coefficients Add(nfloat c)
        {
            return new Coefficients(Multiplier, Constant + c);
        }

        public Coefficients Substract(nfloat c)
        {
            return new Coefficients(Multiplier, Constant - c);
        }

        public static Coefficients operator +(nfloat c, Coefficients rhs)
        {
            return rhs.Add(c);
        }

        public static Coefficients operator +(Coefficients lhs, nfloat rhs)
        {
            return rhs + lhs;
        }

        public static Coefficients operator -(nfloat c, Coefficients rhs)
        {
            return rhs.Substract(c);
        }

        public static Coefficients operator -(Coefficients lhs, nfloat rhs)
        {
            return rhs - lhs;
        }
        #endregion

        #region IMultiplication Operators
        public Coefficients Divide(nfloat m)
        {
            return new Coefficients(Multiplier / m, Constant / m);
        }

        public Coefficients Multiply(nfloat m)
        {
            return new Coefficients(Multiplier * m, Constant * m);
        }

        public static Coefficients operator *(nfloat m, Coefficients rhs)
        {
            return rhs.Multiply(m);
        }

        public static Coefficients operator *(Coefficients lhs, nfloat rhs)
        {
            return rhs * lhs;
        }

        public static Coefficients operator /(nfloat m, Coefficients rhs)
        {
            return rhs.Divide(m);
        }

        public static Coefficients operator /(Coefficients lhs, nfloat rhs)
        {
            return rhs / lhs;
        }
        #endregion
    }
}