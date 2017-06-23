using System.Linq;

namespace UberDSL
{
    public static partial class Extensions
    {
        public static T[] Slice<T>(this T[] instance, int offset)
        {
            return instance.Skip(offset).ToArray();
        }

        public static T[] Merge<T>(this T[] instance, T[] another)
        {
            var combined = new T[instance.Length + another.Length];

            for (var i = 0; i < instance.Length; i++)
            {
                combined[i] = instance[i];
            }

            for (var i = instance.Length; i < combined.Length; i++)
            {
                combined[i] = another[i];
            }

            return combined;
        }
    }
}
