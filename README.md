# Unity Extension Methods
My collection of useful extension methods for Unity classes. The goal of these extensions is to add functionality to
common Unity classes and to make code more readable.

## Installation
This package can be added to a Unity project through the [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html) with the Git URL https://github.com/PaulBichler/unity-extension-methods.git.

## Usage

### Transform Extensions
Extension methods for Unity's Transform class.

| Method                                                                     | Description                                                                                         | Return        |
|----------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|---------------|
| `transform.CopyFrom(Transform other)`                                      | Sets the position, rotation, and scale of this transform to match those of another transform.       | `void`        |
| `transform.Reset()`                                                        | Resets the position, rotation, and scale of this transform.                                         | `void`        |
| `transform.SetX(float value)`                                              | Sets the X value of this transform's position.                                                      | `void`        |
| `transform.SetY(float value)`                                              | Sets the Y value of this transform's position.                                                      | `void`        |
| `transform.SetZ(float value)`                                              | Sets the Z value of this transform's position.                                                      | `void`        |
| `transform.LookAt2D(Transform target)`                                     | Makes the transform look at a 2D target object by rotating its Up-axis towards the target position. | `void`        |
| `transform.GetChildren()`                                                  | Gets all the direct children of this transform as an array.                                         | `Transform[]` |
| `transform.AddChildren(Transform[] transformsToAdd)`                       | Adds an array of child transforms to the specified parent transform.                                | `void`        |
| `transform.FindClosest(IEnumerable<Transform> transforms)`                 | Returns the transform in the array of transforms that is closest to this transform.                 | `Transform`   |
| `transform.DestroyAllChildren(Predicate<Transform> whereCondition = null)` | Destroy all child GameObjects of a Transform. Returns the number of children destroyed.             | `int`         |
| `transform.GetPath(string delimiter = "/")`                                | Gets the full path of this Transform in the scene hierarchy.                                        | `string`      |

### GameObject Extensions
Extension methods for Unity's GameObject class.

| Method                                          | Description                                                                                                                                                                        | Return       |
|-------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|
| `gameObject.Clone()`                            | Creates a copy of this GameObject by instantiating it.                                                                                                                             | `GameObject` |
| `gameObject.HasComponent<T>()`                  | Determines whether a component of type T is attached to this GameObject. If you require a reference to the component, use TryGetComponent instead.                                 | `bool`       |
| `gameObject.GetOrAddComponent<T>()`             | Gets or adds the specified component to this game object. If the component already exists, it's returned. Otherwise, it adds a new component of the specified type and returns it. | `T`          |
| `gameObject.GetComponentsInDirectChildren<T>()` | Gets all components of the specified type in the direct children of this game object.                                                                                              | `List<T>`    |
| `gameObject.DestroyComponent<T>()`              | Destroys the specified component attached to this game object. If multiple components of the specified type are attached, only the first one is destroyed.                         | `bool`       |
| `gameObject.GetPath(string delimiter = "/")`    | Gets the full path of this GameObject in the scene hierarchy.                                                                                                                      | `string`     |

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

### Rigidbody Extensions
Extension methods for Unity's Rigidbody class.

| Method                                                       | Description                                                                       | Return |
|--------------------------------------------------------------|-----------------------------------------------------------------------------------|--------|
| `rigidbody.Stop()`                                           | Stops the Rigidbody by setting its velocity and angular velocity to zero.         | `void` |
| `rigidbody.SetDirection(Vector3 direction)`                  | Sets the direction of the Rigidbody's velocity vector without changing its speed. | `void` |
| `rigidbody.MoveTowards(Vector3 targetPosition, float speed)` | Moves the Rigidbody towards the target position with a given speed.               | `void` |

### Rigidbody2D Extensions
Extension methods for Unity's Rigidbody2D class.

| Method                                                         | Description                                                                         | Return |
|----------------------------------------------------------------|-------------------------------------------------------------------------------------|--------|
| `rigidbody2d.Stop()`                                           | Stops the Rigidbody2D by setting its velocity and angular velocity to zero.         | `void` |
| `rigidbody2d.SetDirection(Vector2 direction)`                  | Sets the direction of the Rigidbody2D's velocity vector without changing its speed. | `void` |
| `rigidbody2d.MoveTowards(Vector2 targetPosition, float speed)` | Moves the Rigidbody2D towards the target position with a given speed.               | `void` |

### Vector Extensions
Extension methods for Unity's Vector2 and Vector3 structs.

| Method                                                                                                      | Description                                                                                                                                                 | Return                |
|-------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------|
| `vector2.FindClosest(IEnumerable<Vector2> positions)` `vector3.FindClosest(IEnumerable<Vector3> positions)` | Returns the closest position in the array of positions. If multiple positions have the same distance to this vector2 or vector3, the first one is returned. | `Vector2?` `Vector3?` |

### RectTransform Extensions
Extension methods for Unity's RectTransform class.

| Method                                        | Description                                                                                                                  | Return  |
|-----------------------------------------------|------------------------------------------------------------------------------------------------------------------------------|---------|
| `rectTransform.GetWorldRect()`                | Returns the world space bounding box of this RectTransform.                                                                  | `Rect`  |
| `rectTransform.Contains(RectTransform other)` | Checks if the world space bounding box of this RectTransform contains the world space bounding box of another RectTransform. | `bool`  |
| `rectTransform.GetTop()`                      | Returns the top position of the RectTransform relative to its parent.                                                        | `float` |
| `rectTransform.GetBottom()`                   | Returns the bottom position of the RectTransform relative to its parent.                                                     | `float` |
| `rectTransform.GetRight()`                    | Returns the right position of the RectTransform relative to its parent.                                                      | `float` |
| `rectTransform.GetLeft()`                     | Returns the left position of the RectTransform relative to its parent.                                                       | `float` |
| `rectTransform.SetTop(float top)`             | Sets the top position of the RectTransform relative to its parent.                                                           | `void`  |
| `rectTransform.SetBottom(float bottom)`       | Sets the bottom position of the RectTransform relative to its parent.                                                        | `void`  |
| `rectTransform.SetRight(float right)`         | Sets the right position of the RectTransform relative to its parent.                                                         | `void`  |
| `rectTransform.SetLeft(float left)`           | Sets the left position of the RectTransform relative to its parent.                                                          | `void`  |

### Color Extensions
Extension methods for Unity's Color and Color32 structs.

| Method          | Description                                                                | Return   |
|-----------------|----------------------------------------------------------------------------|----------|
| `color.ToHex()` | Converts a Color or Color32 object to a hexadecimal string representation. | `string` |

### AudioSource Extensions
Extension methods for Unity's AudioSource class.

| Method                                                                                  | Description                                                                                                                                                                        | Return        |
|-----------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------|
| `audioSource.FadeIn(float duration, float targetVolume, Action onComplete = null)`      | Fades in the AudioSource to the target volume over a specified duration. This is a coroutine that needs to be started by calling StartCoroutine on a MonoBehaviour.                | `IEnumerator` |
| `audioSource.FadeInAsync(float duration, float targetVolume, Action onComplete = null)` | Asynchronously fades in the AudioSource to a specified target volume over a specified duration.                                                                                    | `void`        |
| `audioSource.FadeOut(float duration, Action onComplete = null)`                         | Fades out the AudioSource from its current volume to silence over a specified duration. This is a coroutine that needs to be started by calling StartCoroutine on a MonoBehaviour. | `IEnumerator` |
| `audioSource.FadeOutAsync(float duration, Action onComplete = null)`                    | Asynchronously fades out the volume of the AudioSource over a specified duration.                                                                                                  | `void`        |

### Camera Extensions
Extension methods for Unity's Camera class.

| Method                                          | Description                                                                                                                                   | Return        |
|-------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|---------------|
| `camera.GetMouseRay()`                          | Retrieves the mouse ray from the camera based on the current mouse position. (Mouse position is retrieved using 'Input.mousePosition')        | `Ray`         |
| `camera.Shake(float duration, float magnitude)` | Shakes the camera by modifying its local position. This is a coroutine that needs to be started by calling StartCoroutine on a MonoBehaviour. | `IEnumerator` |