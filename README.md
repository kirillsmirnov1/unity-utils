Some little pieces of code I find useful enough to have them in several projects. 

To install add next line to `Packages/manifest.json`   
`"trulden.unity-utils": "https://github.com/kirillsmirnov1/unity-utils.git",`

Depends on:  
`"com.domybest.mybox": "https://github.com/Deadcows/MyBox.git",`

### MonoScale

Component to change scale of object with one slider.

![](https://raw.githubusercontent.com/kirillsmirnov1/unity-utils/master/img/MonoScale.PNG)

## VisualEffects

`LazyFade` component fades in and out all child components with Color. You can pass callback to `SetVisibility()` to be called when fade animation is finished.
             
`UiFadePanel` is helper component for `LazyFade`. `Show()` sets `LazyFade` child active and calls it's `SetVisibility()`. `Hide()` does the opposite thing. Accepts finish callbacks similar to `LazyFade`.

## Attributes

`NamedArrayAttribute` displays array indexes as given enum values. 

![](https://raw.githubusercontent.com/kirillsmirnov1/unity-utils/master/img/Named_Array_1.PNG)
![](https://raw.githubusercontent.com/kirillsmirnov1/unity-utils/master/img/NamedArray_0.PNG)

## UI

### InvokableButton

Allows to «click» on button from code using `Invoke()`.

## Camera

`FitCamera` fits orthographic camera to chosen object in scene by width/height with chosen coefficient. 

![](https://raw.githubusercontent.com/kirillsmirnov1/unity-utils/master/img/FitCamera.PNG)

## Saves

Call `DateChecker.CheckSaveDate(DateTime)` to check if any amount of days passed since date in question. If that is so, `DateChecker.LoadOnNewDateCallback` will be invoked. If not — `DateChecker.LoadOnSameDateCallback`.

With `SaveIO` you can write (and read) objects as JSON strings to (from) persistentDataPath.  

## Extensions 

### MonoBehaviourNullCheck

`CheckNullFields(MonoBehaviour o)` puts warnings in console, if object in questions has some `public` or `private` serialized fields being `null`.

### GameObjectExtensions

`InPrefabScene()` checks if current object is in prefab scene. I use it in pair with `CheckNullFields()`.

### LINQ extensions

 `IEnumerable<T> Shuffle<T>()` shuffles IEnumerable. It does so by calling OrderBy with some random values;

### RandomExtensions

`RandomValueInRangeSegment(float from, float to, int segmentCount, int segmentIndex)`  
Separates [`from`, `to`] to `segmentCount` ranges and generates random value in `segmentIndex` range.

### DebugExtensions

`DrawCross(Vector3 pos, float time, float length)` draws debug cross 

### EnumExtensions

`T Next<T>(this T src) where T : Enum` returns next enum element. For last element returns first one.  