using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's Rigidbody class.
    /// </summary>
    public static class RigidbodyExtensions
    {
        /// <summary>
        /// Stops the Rigidbody by setting its velocity and angular velocity to zero.
        /// </summary>
        /// <param name="rb">The Rigidbody component to stop.</param>
        public static void Stop(this Rigidbody rb)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
        /// <summary>
        /// Sets the direction of the Rigidbody's velocity vector without changing its speed.
        /// </summary>
        /// <param name="rb">The Rigidbody component to modify.</param>
        /// <param name="direction">The desired direction of the velocity vector.</param>
        public static void SetDirection(this Rigidbody rb, Vector3 direction)
        {
            rb.velocity = direction.normalized * rb.velocity.magnitude;
        }
        
        /// <summary>
        /// Moves the Rigidbody towards the target position with a given speed. 
        /// </summary>
        /// <param name="rb">The Rigidbody component to move.</param>
        /// <param name="targetPosition">The position to move towards.</param>
        /// <param name="speed">The speed at which to move.</param>
        public static void MoveTowards(this Rigidbody rb, Vector3 targetPosition, float speed)
        {
            Vector3 direction = (targetPosition - rb.position).normalized;
            rb.velocity = direction * speed;
        }
    }
}
