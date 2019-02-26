using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GBEmu.Utils
{
    public static class StringExtensions
    {
        public static string ToBinary(this string str)
        {
            string binarystring = string.Join(string.Empty,
              str.Select(
                c =>
                {
                    return Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0');
                }
              )
            );

            return binarystring;
        }
    }
}
