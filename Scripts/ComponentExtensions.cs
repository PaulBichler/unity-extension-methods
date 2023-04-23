using UnityEngine;

namespace UnityExtensionMethods
{
    /// <summary>
    /// Extension methods for Unity's Component class.
    /// </summary>
    public static class ComponentExtensions
    {
        /// <summary>
        /// Determines whether a component of type T is attached to the game object of this component.
        /// </summary>
        /// <typeparam name="T">The type of component to check for.</typeparam>
        /// <param name="component">The component who's GameObject to check.</param>
        /// <returns>True if a component of type T is attached to the GameObject of this component, otherwise false.</returns>
        public static bool HasComponent<T>(this Component component) where T : Component
        {
            return component.gameObject.HasComponent<T>();
        }
        
        /// <summary>
        /// Adds a component of the specified type to the GameObject of this component.
        /// </summary>
        /// <typeparam name="T">The type of component to add.</typeparam>
        /// <param name="component">The component who's GameObject to add the new component to.</param>
        /// <returns>The added component.</returns>
        public static T AddComponent<T>(this Component component) where T : Component
        {
            return component.gameObject.AddComponent<T>();
        }
        
        /// <summary>
        /// Gets or adds the specified component to the GameObject of this component.
        /// If the component already exists, it's returned.
        /// Otherwise, it adds a new component of the specified type and returns it.
        /// </summary>
        /// <typeparam name="T">The type of component to get or add.</typeparam>
        /// <param name="component">The component who's GameObject to get or add the component to.</param>
        /// <returns>The component of the specified type attached to the GameObject.</returns>
        public static T GetOrAddComponent<T>(this Component component) where T : Component
        {
            return component.gameObject.GetOrAddComponent<T>();
        }
    }
}
