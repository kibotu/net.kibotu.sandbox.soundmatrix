using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source
{
    public static class Utils {

        /// 
        /// Output a hex string from a color
        /// 
        ///
        ///Set to true to include a # character at the start
        /// 
        public static string ToHex(this Color color, bool includeHash = false)
        {
            string red = Mathf.FloorToInt(color.r * 255).ToString("X2");
            string green = Mathf.FloorToInt(color.g * 255).ToString("X2");
            string blue = Mathf.FloorToInt(color.b * 255).ToString("X2");
            return (includeHash ? "#" : "") + red + green + blue;
        }

        /// 
        /// Create a Color object from a Hex string (It's not important if you have a # character at
        /// the start or not)
        /// 
        ///The hex string to convert
        /// A Color object
        public static Color FromHex(string color)
        {
            // remove the # character if there is one.
            color = color.TrimStart('#');
            float red = (HexToInt(color[1]) + HexToInt(color[0]) * 16f) / 255f;
            float green = (HexToInt(color[3]) + HexToInt(color[2]) * 16f) / 255f;
            float blue = (HexToInt(color[5]) + HexToInt(color[4]) * 16f) / 255f;
            Color finalColor = new Color { r = red, g = green, b = blue, a = 1 };
            return finalColor;
        }

        /// 
        /// Create a color object from integer R G B (A) components
        /// 
        ///The red component
        ///The green component
        ///The blue component
        ///The alpha component (Defaults to 255, or fully opaque)
        /// A Color object
        public static Color FromInt(int r, int g, int b, int a = 255)
        {
            return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
        }

        private static int HexToInt(char hexValue)
        {
            return int.Parse(hexValue.ToString(), System.Globalization.NumberStyles.HexNumber);
        }
    }
}
