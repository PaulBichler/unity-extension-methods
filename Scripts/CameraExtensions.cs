using System.Collections;
using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's Camera class.
    /// </summary>
    public static class CameraExtensions
    {
        /// <summary>
        /// Retrieves the mouse ray from the camera based on the current mouse position.
        /// (Mouse position is retrieved using 'Input.mousePosition')
        /// </summary>
        /// <param name="camera">The camera from which to retrieve the mouse ray.</param>
        /// <returns>The mouse ray as a <see cref="Ray"/> object.</returns>
        public static Ray GetMouseRay(this Camera camera)
        {
            return camera.ScreenPointToRay(Input.mousePosition);
        }
        
        /// <summary>
        /// Shakes the camera by modifying its local position.
        /// This is a coroutine that needs to be started by calling StartCoroutine on a MonoBehaviour.
        /// </summary>
        /// <param name="camera">The camera to shake.</param>
        /// <param name="duration">The duration of the shake in seconds.</param>
        /// <param name="magnitude">The magnitude of the shake.</param>
        /// <returns>An IEnumerator that can be used for coroutine.</returns>
        public static IEnumerator Shake(this Camera camera, float duration, float magnitude)
        {
            Vector3 originalPosition = camera.transform.localPosition;
            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;
                camera.transform.localPosition = originalPosition + new Vector3(x, y, 0);
                elapsed += Time.deltaTime;

                yield return null;
            }

            camera.transform.localPosition = originalPosition;
        }
    }
}
