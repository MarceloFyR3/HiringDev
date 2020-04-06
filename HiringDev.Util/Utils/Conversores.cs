using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HiringDev.Util.Utils
{
    public static class Conversores
    {
        static string GetEnumDescription<T>(T value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false
                );

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static T ParseDescriptionToEnum<T>(string description)
        {
            var array = Enum.GetValues(typeof(T));
            var list = new List<T>(array.Length);

            list.AddRange(array.Cast<object>().Select((t, i) => (T) array.GetValue(i)));

            var dict = list.Select(v => new {
                        Value = v,
                        Description = GetEnumDescription(v)
                    }
                )
                .ToDictionary(x => x.Description, x => x.Value);
            return dict[description];
        }
    }
}
