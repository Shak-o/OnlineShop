using System.Collections;

namespace OnlineShop.Persistence.Helpers
{
    public static class ComparisonHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x">Destination</param>
        /// <param name="y">Source</param>
        public static T MapDiff<T>(T x, T y) where T : class
        {
            var type = x.GetType();
            var props = type.GetProperties();

            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                var valueX = prop.GetValue(x);
                var valueY = prop.GetValue(y);

                if (valueX is null)
                {
                    if (valueY is not null)
                        prop.SetValue(x, valueY);
                    break;
                }

                if (valueX.GetType().IsValueType || valueX is string)
                {
                    if (!valueX.Equals(valueY))
                        prop.SetValue(x, valueY);
                }
                else if (valueX is IEnumerable convertedX && valueY is IEnumerable convertedY)
                {
                    //TODO will do with hand for now
                    break;
                }
                else if (valueX.GetType().IsClass)
                {
                    var mapped = MapDiff(valueX, valueY);
                    prop.SetValue(x, mapped);
                }

            }

            return x;
        }

        public static bool CompareSimple(ValueType x, ValueType y)
        {
            return x.Equals(y);
        }

        public static bool CompareList<T>(IEnumerable<T> x, IEnumerable<T> y)
        {
            return true;
        }
    }
}
