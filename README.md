# Unity Extension Methods
My collection of useful extension methods for Unity classes. The goal of these extensions is to add functionality to
common Unity classes and to make code more readable.

## Installation
This package can be added to a Unity project through the [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html) with the Git URL https://github.com/PaulBichler/unity-extension-methods.git.

## Usage

### Transform Extensions
Extension methods for Unity's Transform class.

| Method                                                     | Description                                                                                   | Return        |
|------------------------------------------------------------|-----------------------------------------------------------------------------------------------|---------------|
| `transform.CopyFrom(Transform other)`                      | Sets the position, rotation, and scale of this transform to match those of another transform. | `void`        |
| `transform.Reset()`                                        | Resets the position, rotation, and scale of this transform.                                   | `void`        |
| `transform.SetX(float value)`                              | Sets the X value of this transform's position.                                                | `void`        |
| `transform.SetY(float value)`                              | Sets the Y value of this transform's position.                                                | `void`        |
| `transform.SetZ(float value)`                              | Sets the Z value of this transform's position.                                                | `void`        |
| `transform.GetChildren()`                                  | Gets all the direct children of this transform as an array.                                   | `Transform[]` |
| `transform.AddChildren(Transform[] transformsToAdd)`       | Adds an array of child transforms to the specified parent transform.                          | `void`        |
| `transform.FindClosest(IEnumerable<Transform> transforms)` | Returns the transform in the array of transforms that is closest to this transform.           | `Transform`   |

### GameObject Extensions
Extension methods for Unity's GameObject class.

| Method                                          | Description                                                                                                                                                                        | Return    |
|-------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------|
| `gameObject.HasComponent<T>()`                  | Determines whether a component of type T is attached to this GameObject. If you require a reference to the component, use TryGetComponent instead.                                 | `bool`    |
| `gameObject.GetOrAddComponent<T>()`             | Gets or adds the specified component to this game object. If the component already exists, it's returned. Otherwise, it adds a new component of the specified type and returns it. | `T`       |
| `gameObject.GetComponentsInDirectChildren<T>()` | Gets all components of the specified type in the direct children of this game object.                                                                                              | `List<T>` |
| `gameObject.DestroyComponent<T>()`              | Destroys the specified component attached to this game object. If multiple components of the specified type are attached, only the first one is destroyed.                         | `bool`    |

### Component Extensions
Extension methods for Unity's Component class.

| Method                             | Description                                                                                                                                                                                        | Return |
|------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------|
| `component.HasComponent<T>()`      | Determines whether a component of type T is attached to the game object of this component.                                                                                                         | `bool` |
| `component.AddComponent<T>()`      | Adds a component of the specified type to the GameObject of this component.                                                                                                                        | `T`    |
| `component.GetOrAddComponent<T>()` | Gets or adds the specified component to the GameObject of this component. If the component already exists, it's returned. Otherwise, it adds a new component of the specified type and returns it. | `T`    |

### MonoBehaviour Extensions
Extension methods for Unity's MonoBehaviour class.

| Method                                                                 | Description                                                                                                                       | Return |
|------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------|--------|
| `monoBehaviour.ExecuteInSeconds(float delay, Action callback)`         | Invokes the specified callback after the specified amount of scaled time. This method starts a coroutine on this MonoBehaviour.   | `void` |
| `monoBehaviour.ExecuteInSecondsRealtime(float delay, Action callback)` | Invokes the specified callback after the specified amount of unscaled time. This method starts a coroutine on this MonoBehaviour. | `void` |
| `monoBehaviour.ExecuteNextFrame(Action callback)`                      | Invokes the specified callback on the next frame. This method starts a coroutine on this MonoBehaviour.                           | `void` |

### Color Extensions
Extension methods for Unity's Color and Color32 structs. 

| Method          | Description                                                                | Return   |
|-----------------|----------------------------------------------------------------------------|----------|
| `color.ToHex()` | Converts a Color or Color32 object to a hexadecimal string representation. | `string` |
