# Readme / XVariable
Store, display and save data.  
Inject objects. 

Based on Ryan Hipple\'s talk [Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk).  
The main idea of that talk is to use ScriptableObjects for passing data between classes.

Part of [Unity Utils](https://github.com/kirillsmirnov1/unity-utils) package.

## Store

XVariable is easy to use to access data from different classes. Instead of setting up an access manager or DI system, you can easily drag and drop data into any MonoBehavior/ScriptableObject you want. Data can be set from code or inspector and used/changed anywhere.

`XVariable<T>` is an abstract `ScriptableObject`. To store data you need to inherit it with type/class/struct of your choice and create an instance of it.

For example, `IntVariable` looks like this:
```
[CreateAssetMenu(fileName = "New Int Variable", menuName = "Variables/Int Variable", order = 0)]
public class IntVariable : XVariable<int> { }
``` 

### Usage

`XVariable<T>` inheritors can be referenced like any other `ScriptableObject`. `XVariable<T>` data can be accessed through `Value` property or with automatic type-cast if it is possible.
```
[SerializeField] private IntVariable currentHealth;
...
currentHealth.Value = 5; // Set in one class
...
var healthAfterHealing = currentHealth + 10; // Access in another
```  

### Arrays usage

There is also `XArrayVariable<T>` for arrays of data. It can be accessed like any other array.

```
[SerializeField] private IntArrayVariable levelUpXp;
...
levelUpXp.Value = new[] {0, 10, 20, 40};
...
var xpForNextLevel = levelUpXp[currentLevel + 1] - currentXp;
```

### OnChange callbacks

`XVariable<T>` has `OnChange<T>` callback. 
   
It is called when: 
- new `Value` is set by code; 
- value is changed from the inspector.

XArrayVariable<T> has `OnEntryChange<int, T>` callback.
   
It is called when: 
- Value[i] set from code; 
- Value is changed from the inspector. In this case, OnEntryChange is called for every array element.  

### Existing inheritors  

#### XVariable<T>
by value
- `BoolVariable`
- `FloatVariable`
- `DoubleVariable`
- `IntVariable`
- `UIntVariable`
- `LongVariable`
- `ULongVariable`
- `StringVariable`
- `Vector2Variable`
- `Vector2IntVariable`
- `Vector3Variable`

by reference
- `GameObjectVariable`
- `TransformVariable`
- `RectTransformVariable`
- `CameraVariable`
- `CanvasVariable`

#### XArrayVariable<T>
- `BoolArrayVariable`
- `IntArrayVariable`
- `StringArrayVariable`
- `Vector2IntArrayVariable`
- `AudioClipArrayVariable`
- `SpriteArrayVariable`

## Display

`XVariableDisplay<T>` sets string representation of data on TextMeshProUGUI component.  

Can be used to display `Variables` changing in runtime, such as balance, health, or other always-on-screen data.

Using `ContentSizeFitter` and `LayoutGroup` you can make the view change its size automatically. Example — `IntVariableDisplayInteractiveWidth.prefab` 

![](https://github.com/kirillsmirnov1/unity-utils/raw/master/img/IntVariableDisplay.gif)

## Save

Any XVariable<T> with `[Serializable]` data can be saved via `SaveFile.cs`

- Create `SaveFile` Scriptable Object.  
- Add variables you want to save in created SaveFile.
- Provide variables with default values for them.   
- Select GameObject which will be active before any of saved XVariables would be used;
- Add `InitScriptableObjects` component to it;
- In `InitScriptableObjects` set add your `SaveFile` SO;
- Every scene can have its own `InitScriptableObjects`.  

## Inject

XVariables can be used for object injection. You just need to reference XVariable of your choice in one script and set it in another.

To bind object of any class you can use XVariableBinding<T>:
- Inherit XVariable<T> and XVariableBinding<T> for your class;
- If your class is not derived from `Component`, `XVariableBinding.BindValue()` needs to be overridden;
- Add derived XVariableBinding<T> to GameObject with required component;
- Create an instance of derived XVariable<T> and set it to XVariableBinding<T>.

`XVariableBinding<T>` will set the reference of your object to `XVariable<T>` instance on its `Awake()` call. An instance of `XVariable<T>` can be used to access a previously set object.

### Existing Inheritors

- `GameObjectVariableBinding`
- `TransformVariableBinding`
- `RectTransformVariableBinding`
- `CameraVariableBinding`
- `CanvasVariableBinding`
