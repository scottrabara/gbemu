using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Utils
{
    public static class BitwiseExtensions
    {
        /// <summary>
        /// Given a two byte int, get left nibble as int
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int GetLeftNibble(this int i)
        {
            // Shift bits to left 4 times
            // 11001101 becomes 00001100
            return i >> 4;
        }
        /// <summary>
        /// Given a two byte int, get right nibble as int
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int GetRightNibble(this int i)
        {
            // Mask with 0x00001111;
            // 11001101 becomes 00001101
            return i & 15;
        }
    }
}
