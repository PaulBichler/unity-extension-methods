using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's Color and Color32 structs. 
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a Color object to a hexadecimal string representation.
        /// </summary>
        /// <param name="color">The Color object to convert.</param>
        /// <param name="includeAlpha">Whether or not to include the alpha value in the output.</param>
        /// <returns>A string representing the Color object in hexadecimal format.</returns>
        public static string ToHex(this Color color, bool includeAlpha = true)
        {
            return "#" + (includeAlpha 
                ? ColorUtility.ToHtmlStringRGBA(color) 
                : ColorUtility.ToHtmlStringRGB(color));
        }
        
        /// <summary>
        /// Converts a Color32 object to a hexadecimal string representation.
        /// </summary>
        /// <param name="color32">The Color32 object to convert.</param>
        /// <param name="includeAlpha">Whether or not to include the alpha value in the output.</param>
        /// <returns>A string representing the Color32 object in hexadecimal format.</returns>
        public static string ToHex(this Color32 color32, bool includeAlpha = true)
        {
            Color color = color32;
            return color.ToHex(includeAlpha);
        }
    }
}
