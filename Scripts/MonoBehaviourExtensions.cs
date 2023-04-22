using System;
using System.Collections;
using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's MonoBehaviour class.
    /// </summary>
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// Invokes the specified callback after the specified amount of time. The timer uses scaled time to update.
        /// This method starts a coroutine on this MonoBehaviour.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour to start the coroutine on.</param>
        /// <param name="delay">The amount of scaled time to wait in seconds</param>
        /// <param name="callback">The callback to invoke after the delay</param>
        public static void ExecuteInSeconds(this MonoBehaviour monoBehaviour, float delay, Action callback)
        {
            monoBehaviour.StartCoroutine(ExecuteInSecondsCoroutine(delay, callback, false));
        }

        /// <summary>
        /// Invokes the specified callback after the specified amount of real-time. The timer uses unscaled time to update.
        /// This method starts a coroutine on this MonoBehaviour.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour to start the coroutine on.</param>
        /// <param name="delay">The amount of unscaled time to wait in seconds</param>
        /// <param name="callback">The callback to invoke after the delay</param>
        public static void ExecuteInSecondsRealtime(this MonoBehaviour monoBehaviour, float delay, Action callback)
        {
            monoBehaviour.StartCoroutine(ExecuteInSecondsCoroutine(delay, callback, true));
        }
        
        /// <summary>
        /// Invokes the specified callback on the next frame.
        /// This method starts a coroutine on this MonoBehaviour.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour to start the coroutine on.</param>
        /// <param name="callback">The callback to invoke on the next frame.</param>
        public static void ExecuteNextFrame(this MonoBehaviour monoBehaviour, Action callback)
        {
            monoBehaviour.StartCoroutine(ExecuteNextFrameCoroutine(callback));
        }

        private static IEnumerator ExecuteInSecondsCoroutine(float delay, Action callback, bool useRealtime)
        {
            if (useRealtime)
                yield return new WaitForSecondsRealtime(delay);
            else
                yield return new WaitForSeconds(delay);
            
            callback?.Invoke();
        }
        
        private static IEnumerator ExecuteNextFrameCoroutine(Action callback)
        {
            yield return null;
            callback?.Invoke();
        }
    }
}
