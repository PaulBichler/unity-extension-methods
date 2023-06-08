using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

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
        /// Makes the transform look at a 2D target object by rotating its Up-axis towards the target position.
        /// </summary>
        /// <param name="transform">The transform to look at the target.</param>
        /// <param name="target">The target transform to look at.</param>
        public static void LookAt2D(this Transform transform, Transform target)
        {
            Vector2 direction = target.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
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
        
        /// <summary>
        /// Returns the Transform in the array of Transforms that is closest to this Transform.
        /// If multiple Transforms have the same distance to this Transform, the first one is returned.
        /// </summary>
        /// <param name="transform">This Transform.</param>
        /// <param name="transforms">The array of Transforms to search.</param>
        /// <returns>The closest Transform in the array.</returns>
        public static Transform FindClosest(this Transform transform, IEnumerable<Transform> transforms)
        {
            Transform closest = null;
            float closestDistance = Mathf.Infinity;

            foreach (Transform t in transforms)
            {
                float distance = Vector3.Distance(transform.position, t.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = t;
                }
            }

            return closest;
        }
        
        /// <summary>
        /// Destroy all child GameObjects of a Transform.
        /// </summary>
        /// <param name="transform">The Transform whose child GameObjects are being destroyed.</param>
        /// <param name="whereCondition">An optional predicate used to filter which child GameObjects are destroyed.</param>
        /// <returns>The number of child GameObjects that were destroyed.</returns>
        public static int DestroyAllChildren(this Transform transform, Predicate<Transform> whereCondition = null)
        {
            int childDestroyCount = 0;
            
            foreach (Transform child in transform)
            {
                //Don't destroy the child if the condition is not met
                if (whereCondition != null && !whereCondition.Invoke(child)) 
                    continue;
                
                Object.Destroy(child.gameObject);
                childDestroyCount++;
            }

            return childDestroyCount;
        }
        
        /// <summary>
        /// Gets the full path of this Transform in the scene hierarchy.
        /// </summary>
        /// <param name="transform">The Transform whose path is being requested.</param>
        /// <param name="delimiter">The delimiter used to separate the names of each parent and child in the path.</param>
        /// <returns>The full path of the Transform in the scene hierarchy.</returns>
        public static string GetPath(this Transform transform, string delimiter = "/")
        {
            if (!transform.parent)
                return transform.name;

            return transform.parent.GetPath(delimiter) + delimiter + transform.name;
        }
    }
}
