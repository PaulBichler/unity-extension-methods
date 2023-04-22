using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's Transform class.
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        /// Sets the position, rotation, and scale of this transform to match those of another transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="other">The transform to copy the values from.</param>
        public static void CopyFrom(this Transform transform, Transform other)
        {
            transform.position = other.position;
            transform.rotation = other.rotation;
            transform.localScale = other.localScale;
        }
        
        /// <summary>
        /// Resets the position, rotation, and scale of this transform.
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        public static void Reset(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
        
        /// <summary>
        /// Gets all the direct children of this transform as an array. 
        /// </summary>
        /// <returns>Children of this transform</returns>
        public static Transform[] GetChildren(this Transform transform)
        {
            Transform[] children = new Transform[transform.childCount];
            
            for (int i = 0; i < transform.childCount; i++)
            {
                children[i] = transform.GetChild(i);
            }
            
            return children;
        }
    }
}
