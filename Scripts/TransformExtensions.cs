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
        /// Sets the X value of this transform's position.
        /// </summary>
        /// <param name="transform">The transform who's position to modify.</param>
        /// <param name="value">The new x value.</param>
        public static void SetX(this Transform transform, float value)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(value, position.y, position.z);
        }
        
        /// <summary>
        /// Sets the Y value of this transform's position.
        /// </summary>
        /// <param name="transform">The transform who's position to modify.</param>
        /// <param name="value">The new y value.</param>
        public static void SetY(this Transform transform, float value)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(position.x, value, position.z);
        }
        
        /// <summary>
        /// Sets the Z value of this transform's position.
        /// </summary>
        /// <param name="transform">The transform who's position to modify.</param>
        /// <param name="value">The new z value.</param>
        public static void SetZ(this Transform transform, float value)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(position.x, position.y, value);
        }
        
        /// <summary>
        /// Gets all the direct children of this transform as an array. 
        /// </summary>
        /// <param name="transform">The transform who's direct children to get.</param>
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
    
        /// <summary>
        /// Adds an array of child transforms to the specified parent transform.
        /// </summary>
        /// <param name="transform">The parent transform to add the child transforms to.</param>
        /// <param name="transformsToAdd">The array of child transforms to add.</param>
        public static void AddChildren(this Transform transform, Transform[] transformsToAdd)
        {
            foreach (var transformToAdd in transformsToAdd)
            {
                transformToAdd.SetParent(transform);
            }
        }
    }
}
