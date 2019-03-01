using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GBEmu.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns true if the byte in the Hexadecimal string can mask with the opcode position.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="opcode"></param>
        /// <returns></returns>
        public static bool ContainsBitCharInMap(this string str, int opcode)
        {
            // Get index for hexadecimal map
            var index = (opcode / 4);

            // Get bit position for byte
            var power = (4 - (opcode % 4)) - 1;

            // Construct bitmask for position
            var bitMask = (int) Math.Pow(2, power);

            // Get int from str[index]
            var selectedByte = int.Parse(str[index].ToString(), System.Globalization.NumberStyles.HexNumber);

            // Return the result of the selectByte and the bytePositionMask
            // This should equal the mask itself
            // i.e. str[index] = 7, position = 1, positionMask = 2
            //      7 = 0111
            //      2 = 0010
            //      Bitwise and = 0010
            return (bitMask & selectedByte) == bitMask;
        }
    }
}
