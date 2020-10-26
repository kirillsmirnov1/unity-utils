Some little pieces of code I find useful enough to have them in several projects. 

### MonoScale

Component to change scale of object with one slider instead of three separate

## VisualEffects

`LazyFade` component fades in and out all child components with Color.             
`UiFadePanel` is helper component for `LazyFade`. `Show()` sets `LazyFade` child active and calls it's `SetVisibility()`.

## Attributes

`NamedArrayAttribute` indexes array elements with given enum values. 

## UI

### InvokableButton

Allows to «click» on button from code using `Invoke()`.

## Camera

`FitCamera` fits orthographic camera to chosen object in scene by width/height with chosen coefficient. 

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

## Saves

Call `DateChecker.CheckSaveDate(DateTime)` to check if any amount of days passed since date in question. If that is so, `DateChecker.LoadOnNewDateCallback` will be invoked. If not — `DateChecker.LoadOnSameDateCallback`.

With `SaveIO` you can write (and read) objects as JSON strings to (from) persistentDataPath.    