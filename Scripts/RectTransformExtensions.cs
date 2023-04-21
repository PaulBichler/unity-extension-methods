using UnityEngine;

namespace UnityExtensionMethods
{
    public static class RectTransformExtensions
    {
        /// <summary>
        /// Returns the world space bounding box of this RectTransform.
        /// </summary>
        /// <param name="rectTransform">The RectTransform to get the world space bounding box of.</param>
        /// <returns>A Rect representing the world space bounding box of this RectTransform.</returns>
        public static Rect GetWorldRect(this RectTransform rectTransform)
        {
            Vector3[] corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);
            
            // Get the bottom left corner.
            Vector3 position = corners[0];

            var rect = rectTransform.rect;
            var lossyScale = rectTransform.lossyScale;
        
            Vector2 size = new Vector2(
                lossyScale.x * rect.size.x,
                lossyScale.y * rect.size.y);
     
            return new Rect(position, size);
        }
        
        /// <summary>
        /// Checks if the world space bounding box of this RectTransform contains the world space bounding box of another RectTransform.
        /// </summary>
        /// <param name="rectTransform">The RectTransform to check.</param>
        /// <param name="other">The RectTransform to check against.</param>
        /// <returns>True if this RectTransform contains the other RectTransform, otherwise false.</returns>
        public static bool Contains(this RectTransform rectTransform, RectTransform other)
        {
            Rect wr = rectTransform.GetWorldRect();
            Rect owr = other.GetWorldRect();
            return wr.xMin <= owr.xMin && wr.yMin <= owr.yMin && wr.xMax >= owr.xMax && wr.yMax >= owr.yMax;
        }
    }
}
