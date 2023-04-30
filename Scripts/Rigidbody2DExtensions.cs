using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's Rigidbody2D class.
    /// </summary>
    public static class Rigidbody2DExtensions
    {
        /// <summary>
        /// Stops the Rigidbody2D by setting its velocity and angular velocity to zero.
        /// </summary>
        /// <param name="rb">The Rigidbody2D component to stop.</param>
        public static void Stop(this Rigidbody2D rb)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
        
        /// <summary>
        /// Sets the direction of the Rigidbody2D's velocity vector without changing its speed.
        /// </summary>
        /// <param name="rb">The Rigidbody2D component to modify.</param>
        /// <param name="direction">The desired direction of the velocity vector.</param>
        public static void SetDirection(this Rigidbody2D rb, Vector2 direction)
        {
            rb.velocity = direction.normalized * rb.velocity.magnitude;
        }
        
        /// <summary>
        /// Moves the Rigidbody2D towards the target position with a given speed. 
        /// </summary>
        /// <param name="rb">The Rigidbody2D component to move.</param>
        /// <param name="targetPosition">The position to move towards.</param>
        /// <param name="speed">The speed at which to move.</param>
        public static void MoveTowards(this Rigidbody2D rb, Vector2 targetPosition, float speed)
        {
            Vector2 direction = (targetPosition - rb.position).normalized;
            rb.velocity = direction * speed;
        }
    }
}