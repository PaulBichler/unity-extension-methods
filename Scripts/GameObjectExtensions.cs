using System.Collections.Generic;
using UnityEngine;

namespace UnityExtensionMethods
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Gets or adds the specified component to this game object.
        /// If the component already exists, it's returned.
        /// Otherwise, it adds a new component of the specified type and returns it.
        /// </summary>
        /// <typeparam name="T">The type of component to get or add.</typeparam>
        /// <param name="gameObject">The game object to get or add the component to.</param>
        /// <returns>The component of the specified type attached to the game object.</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.TryGetComponent<T>(out var component))
                return component;

            return gameObject.AddComponent<T>();
        }
        
        /// <summary>
        /// Gets all components of the specified type in the direct children of this game object.
        /// </summary>
        /// <typeparam name="T">The type of component to retrieve.</typeparam>
        /// <param name="gameObject">The game object to search for the components.</param>
        /// <returns>A list of all components of the specified type found in the direct children of this game object.</returns>
        public static List<T> GetComponentsInDirectChildren<T>(this GameObject gameObject) where T : Component
        {
            List<T> components = new List<T>();

            foreach (Transform child in gameObject.transform)
            {
                if (child.TryGetComponent<T>(out var component))
                    components.Add(component);
            }

            return components;
        }
        
        /// <summary>
        /// Destroys the specified component attached to this game object.
        /// If multiple component of the specified type are attached, only the first one is destroyed. 
        /// </summary>
        /// <typeparam name="T">The type of component to destroy.</typeparam>
        /// <param name="gameObject">The game object that contains the component to destroy.</param>
        public static bool DestroyComponent<T>(this GameObject gameObject) where T : Component
        {
            if (!gameObject.TryGetComponent<T>(out var component)) 
                return false;
            
            Object.Destroy(component);
            return true;
        }
    }
}
