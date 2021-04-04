using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperString
{
    public static class StringExtension
    {
        public static StringType GetStringType(this string str)
        {
            if (str.All(c => char.IsDigit(c)))
            {
                return StringType.Number;
            }

            if (str.All(c => char.ToLower(c) is >= 'a' and <= 'z'))
            {
                return StringType.English;
            }

            if (str.All(c => char.ToLower(c) is >= 'а' and <= 'я'))
            {
                return StringType.Russian;
            }

            return StringType.Mixed;
        }
    }
}