using System.Collections.Generic;
using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's Vector3 and Vector2 structs.
    /// </summary>
    public static class VectorExtensions
    {
        /// <summary>
        /// Returns the position in the array of positions that is closest to this position.
        /// If multiple positions have the same distance to this position, the first one is returned.
        /// </summary>
        /// <param name="vector3">This position as Vector3.</param>
        /// <param name="positions">The array of positions to search.</param>
        /// <returns>The closest position in the array.</returns>
        public static Vector3? FindClosest(this Vector3 vector3, IEnumerable<Vector3> positions)
        {
            Vector3? closest = null;
            float closestDistance = Mathf.Infinity;

            foreach (Vector3 position in positions)
            {
                float distance = Vector3.Distance(vector3, position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = position;
                }
            }

            return closest;
        }
        
        /// <summary>
        /// Returns the position in the array of positions that is closest to this position.
        /// If multiple positions have the same distance to this position, the first one is returned.
        /// </summary>
        /// <param name="vector2">This position as Vector2.</param>
        /// <param name="positions">The array of positions to search.</param>
        /// <returns>The closest position in the array.</returns>
        public static Vector2? FindClosest(this Vector2 vector2, IEnumerable<Vector2> positions)
        {
            Vector2? closest = null;
            float closestDistance = Mathf.Infinity;

            foreach (Vector2 position in positions)
            {
                float distance = Vector2.Distance(vector2, position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = position;
                }
            }

            return closest;
        }
    }
}