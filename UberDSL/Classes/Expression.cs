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
    }
}
