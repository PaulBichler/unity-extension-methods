using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's RectTransform class.
    /// </summary>
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
        
        /// <summary>
        /// Returns the top position of the RectTransform relative to its parent.
        /// </summary>
        /// <param name="rectTransform">The RectTransform.</param>
        /// <returns>The top position of the RectTransform.</returns>
        public static float GetTop(this RectTransform rectTransform)
        {
            return -rectTransform.offsetMax.y;
        }
        
        /// <summary>
        /// Sets the top position of the RectTransform relative to its parent.
        /// </summary>
        /// <param name="rectTransform">The RectTransform.</param>
        /// <param name="top">The desired top position.</param>
        public static void SetTop(this RectTransform rectTransform, float top)
        {
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -top);
        }
        
        /// <summary>
        /// Returns the bottom position of the RectTransform relative to its parent.
        /// </summary>
        /// <param name="rectTransform">The RectTransform.</param>
        /// <returns>The bottom position of the RectTransform.</returns>
        public static float GetBottom(this RectTransform rectTransform)
        {
            return rectTransform.offsetMin.y;
        }
        
        /// <summary>
        /// Sets the bottom position of the RectTransform relative to its parent.
        /// </summary>
        /// <param name="rectTransform">The RectTransform.</param>
        /// <param name="bottom">The desired bottom position.</param>
        public static void SetBottom(this RectTransform rectTransform, float bottom)
        {
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, bottom);
        }
        
        /// <summary>
        /// Returns the left position of the RectTransform relative to its parent.
        /// </summary>
        /// <param name="rectTransform">The RectTransform.</param>
        /// <returns>The left position of the RectTransform.</returns>
        public static float GetLeft(this RectTransform rectTransform)
        {
            return rectTransform.offsetMin.x;
        }
        
        /// <summary>
        /// Sets the left position of the RectTransform relative to its parent.
        /// </summary>
        /// <param name="rectTransform">The RectTransform.</param>
        /// <param name="left">The desired left position.</param>
        public static void SetLeft(this RectTransform rectTransform, float left)
        {
            rectTransform.offsetMin = new Vector2(left, rectTransform.offsetMin.y);
        }
        
        /// <summary>
        /// Returns the right position of the RectTransform relative to its parent.
        /// </summary>
        /// <param name="rectTransform">The RectTransform.</param>
        /// <returns>The right position of the RectTransform.</returns>
        public static float GetRight(this RectTransform rectTransform)
        {
            return -rectTransform.offsetMax.x;
        }
        
        /// <summary>
        /// Sets the right position of the RectTransform relative to its parent.
        /// </summary>
        /// <param name="rectTransform">The RectTransform.</param>
        /// <param name="right">The desired right position.</param>
        public static void SetRight(this RectTransform rectTransform, float right)
        {
            rectTransform.offsetMax = new Vector2(-right, rectTransform.offsetMax.y);
        }
    }
}
