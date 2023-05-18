using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's AudioSource class.
    /// </summary>
    public static class AudioSourceExtensions
    {
        /// <summary>
        /// Fades in the AudioSource to the target volume over a specified duration.
        /// This is a coroutine that needs to be started by calling StartCoroutine on a MonoBehaviour.
        /// </summary>
        /// <param name="audioSource">The AudioSource to fade in.</param>
        /// <param name="duration">The duration of the fade-in effect in seconds.</param>
        /// <param name="targetVolume">The desired volume to fade in to (between 0 and 1).</param>
        /// <param name="onComplete">An optional callback to be invoked when the fade-in is complete.</param>
        /// <returns>An IEnumerator that can be used in a Coroutine to control the fade-in process.</returns>
        public static IEnumerator FadeIn(this AudioSource audioSource, float duration, float targetVolume, Action onComplete = null)
        {
            if(audioSource.volume >= targetVolume)
                yield break;
            
            float currentTime = 0;
            float endVolume = Mathf.Clamp(targetVolume, 0f, 1f);

            while (currentTime < duration)
            {
                currentTime += Time.unscaledDeltaTime;
                audioSource.volume = Mathf.Lerp(0, endVolume, currentTime / duration);
                yield return null;
            }

            audioSource.volume = endVolume;
            onComplete?.Invoke();
        }

        /// <summary>
        /// Fades out the AudioSource from its current volume to silence over a specified duration.
        /// This is a coroutine that needs to be started by calling StartCoroutine on a MonoBehaviour.
        /// </summary>
        /// <param name="audioSource">The AudioSource to fade out.</param>
        /// <param name="duration">The duration of the fade-out effect in seconds.</param>
        /// <param name="onComplete">An optional callback to be invoked when the fade-out is complete.</param>
        /// <returns>An IEnumerator that can be used in a Coroutine to control the fade-out process.</returns>
        public static IEnumerator FadeOut(this AudioSource audioSource, float duration, Action onComplete = null)
        {
            float currentTime = 0;
            float startingVolume = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.unscaledDeltaTime;
                audioSource.volume = Mathf.Lerp(startingVolume, 0, currentTime / duration);
                yield return null;
            }

            audioSource.volume = 0;
            onComplete?.Invoke();
        }
        
#if CSHARP_7_3_OR_NEWER
        
        /// <summary>
        /// Asynchronously fades in the AudioSource to a specified target volume over a specified duration.
        /// </summary>
        /// <param name="audioSource">The AudioSource to fade in.</param>
        /// <param name="duration">The duration of the fade-in in seconds.</param>
        /// <param name="targetVolume">The target volume to reach during the fade-in operation.</param>
        /// <param name="onComplete">Optional action to invoke when the fade-in is complete.</param>
        public static async void FadeInAsync(this AudioSource audioSource, float duration, float targetVolume, Action onComplete = null)
        {
            if(audioSource.volume >= targetVolume)
                return;
            
            float currentTime = 0;
            float endVolume = Mathf.Clamp(targetVolume, 0f, 1f);

            while (currentTime < duration)
            {
                currentTime += Time.unscaledDeltaTime;
                audioSource.volume = Mathf.Lerp(0, endVolume, currentTime / duration);
                await Task.Yield();
            }

            audioSource.volume = endVolume;
            onComplete?.Invoke();
        }
        
        /// <summary>
        /// Asynchronously fades out the volume of the AudioSource over a specified duration.
        /// </summary>
        /// <param name="audioSource">The AudioSource to fade out.</param>
        /// <param name="duration">The duration in seconds for the fade-out effect.</param>
        /// <param name="onComplete">Optional callback action to invoke when the fade-out completes.</param>
        public static async void FadeOutAsync(this AudioSource audioSource, float duration, Action onComplete = null)
        {
            float currentTime = 0;
            float startingVolume = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.unscaledDeltaTime;
                audioSource.volume = Mathf.Lerp(startingVolume, 0, currentTime / duration);
                await Task.Yield();
            }

            audioSource.volume = 0;
            onComplete?.Invoke();
        }
        
#endif
        
    }
}