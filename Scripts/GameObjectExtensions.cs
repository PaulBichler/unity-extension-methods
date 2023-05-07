using System.Collections.Generic;
using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's GameObject class.
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Creates a copy of this GameObject by instantiating it.
        /// </summary>
        /// <param name="gameObject">The GameObject to be cloned.</param>
        /// <returns>A new instance of the GameObject.</returns>
        public static GameObject Clone(this GameObject gameObject)
        {
            return Object.Instantiate(gameObject);
        }
        
        /// <summary>
        /// Determines whether a component of type T is attached to this GameObject.
        /// If you require a reference to the component, use TryGetComponent instead!
        /// </summary>
        /// <typeparam name="T">The type of component to check for.</typeparam>
        /// <param name="gameObject">The GameObject to check for the component.</param>
        /// <returns>True if a component of type T is attached to this GameObject, otherwise false.</returns>
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.TryGetComponent<T>(out _);
        }
        
        /// <summary>
        /// Gets or adds the specified component to this GameObject.
        /// If the component already exists, it's returned.
        /// Otherwise, it adds a new component of the specified type and returns it.
        /// </summary>
        /// <typeparam name="T">The type of component to get or add.</typeparam>
        /// <param name="gameObject">The GameObject to get or add the component to.</param>
        /// <returns>The component of the specified type attached to the GameObject.</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.TryGetComponent<T>(out var component))
                return component;

            return gameObject.AddComponent<T>();
        }
        
        /// <summary>
        /// Gets all components of the specified type in the direct children of this GameObject.
        /// </summary>
        /// <typeparam name="T">The type of component to retrieve.</typeparam>
        /// <param name="gameObject">The GameObject to search for the components.</param>
        /// <returns>A list of all components of the specified type found in the direct children of this GameObject.</returns>
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
        /// Destroys the specified component attached to this GameObject.
        /// If multiple component of the specified type are attached, only the first one is destroyed. 
        /// </summary>
        /// <typeparam name="T">The type of component to destroy.</typeparam>
        /// <param name="gameObject">The GameObject that contains the component to destroy.</param>
        public static bool DestroyComponent<T>(this GameObject gameObject) where T : Component
        {
            if (!gameObject.TryGetComponent<T>(out var component)) 
                return false;
            
            Object.Destroy(component);
            return true;
        }
        
        /// <summary>
        /// Sets the layer of this GameObject and all its children recursively.
        /// </summary>
        /// <param name="gameObject">The current GameObject.</param>
        /// <param name="layer">The layer to set.</param>
        public static void SetLayerRecursively(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetLayerRecursively(layer);
            }
        }
        
        /// <summary>
        /// Gets the full path of this GameObject in the scene hierarchy.
        /// </summary>
        /// <param name="gameObject">The GameObject whose path is being requested.</param>
        /// <param name="delimiter">The delimiter used to separate the names of each parent and child in the path.</param>
        /// <returns>The full path of the GameObject in the scene hierarchy.</returns>
        public static string GetPath(this GameObject gameObject, string delimiter = "/")
        {
            return gameObject.transform.GetPath(delimiter);
        }
    }
}
