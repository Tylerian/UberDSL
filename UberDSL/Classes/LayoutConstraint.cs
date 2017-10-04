using System;
using UIKit;
using System.Linq;

namespace UberDSL
{
    public class LayoutConstraint
    {
        NSLayoutConstraint _value;

        private LayoutConstraint(NSLayoutConstraint value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public static implicit operator LayoutConstraint(NSLayoutConstraint value)
        {
            return new LayoutConstraint(value);
        }

        public static implicit operator NSLayoutConstraint(LayoutConstraint value)
        {
            return value._value;
        }

        #region Priority Operators
        public static LayoutConstraint operator ^(LayoutConstraint lhs, float rhs)
        {
            lhs._value.Priority = rhs;

            return lhs;
        }

        public static LayoutConstraint operator ^(LayoutConstraint lhs, Int32 rhs)
        {
            return lhs ^ (float)rhs;
        }

        public static LayoutConstraint operator ^(LayoutConstraint lhs, LayoutPriority rhs)
        {
            lhs._value.Priority = rhs;

            return lhs;
        }

        public static LayoutConstraint operator ^(LayoutConstraint lhs, UILayoutPriority rhs)
        {
            lhs._value.Priority = (float) rhs;

            return lhs;
        }

        /*
        public static LayoutConstraint[] operator ^(LayoutConstraint[] lhs, nfloat rhs)
        {
            return lhs.Select(x => x ^ rhs).ToArray();
        }
        
        public static LayoutConstraint[] operator ^(LayoutConstraint[] lhs, LayoutPriority rhs)
        {
            return lhs.Select(x => x ^ rhs).ToArray();
        }
        */
        #endregion
    }
}
