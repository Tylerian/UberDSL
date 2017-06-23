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
            Constant   = 0.0f;
            Multiplier = 1.0f;
        }

        internal Coefficients(nfloat multiplier, nfloat constant)
        {
            Constant   = constant;
            Multiplier = multiplier;
        }

        public static Coefficients operator +(nfloat c, Coefficients rhs)
        {
            return new Coefficients(rhs.Multiplier, rhs.Constant + c);
        }

        public static Coefficients operator +(Coefficients lhs, nfloat rhs)
        {
            return rhs + lhs;
        }

        public static Coefficients operator -(nfloat c, Coefficients rhs)
        {
            return new Coefficients(rhs.Multiplier, rhs.Constant - c);
        }

        public static Coefficients operator -(Coefficients lhs, nfloat rhs)
        {
            return rhs - lhs;
        }

        public static Coefficients operator *(nfloat m, Coefficients rhs)
        {
            return new Coefficients(rhs.Multiplier * m, rhs.Constant * m);
        }

        public static Coefficients operator *(Coefficients lhs, nfloat rhs)
        {
            return rhs * lhs;
        }

        public static Coefficients operator /(nfloat m, Coefficients rhs)
        {
            return new Coefficients(rhs.Multiplier / m, rhs.Constant / m);
        }

        public static Coefficients operator /(Coefficients lhs, nfloat rhs)
        {
            return rhs / lhs;
        }
    }
}