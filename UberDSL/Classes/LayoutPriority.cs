using System;

using UIKit;
using System.Linq;

namespace UberDSL
{
    public class LayoutPriority
    {
        private float _value;

        public LayoutPriority() :
            this(default(UILayoutPriority))
        {
            
        }

        public LayoutPriority(float value)
        {
            _value = value;
        }

        public LayoutPriority(UILayoutPriority value)
        {
            _value = (float) value;
        }

        public static implicit operator float(LayoutPriority value)
        {
            return value._value;
        }

        public static implicit operator LayoutPriority(float value)
        {
            return new LayoutPriority(value);
        }

        public static implicit operator LayoutPriority(UILayoutPriority value)
        {
            return new LayoutPriority(value);
        }

        public static implicit operator UILayoutPriority(LayoutPriority value)
        {
            return (UILayoutPriority) value._value;
        }
    }
}
