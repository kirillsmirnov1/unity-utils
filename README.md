Some little pieces of code I find useful enough to have them in several projects. 

### MonoBehaviourNullCheck

`CheckNullFields(MonoBehaviour o)` puts warnings in console, if object in questions has some `public` or `private` serialized fields being `null`.

### GameObjectExtensions

`InPrefabScene()` checks if current object is in prefab scene. I use it in pair with `CheckNullFields()`.

### LINQ extensions

 `IEnumerable<T> Shuffle<T>()` shuffles IEnumerable. It does so by calling OrderBy with some random values;

### RandomExtensions

`RandomValueInRangeSegment(float from, float to, int segmentCount, int segmentIndex)`  
Separates [`from`, `to`] to `segmentCount` ranges and generates random value in `segmentIndex` range.

### Saves

Call `DateChecker.CheckSaveDate(DateTime)` to check if any amount of days passed since date in question. If that is so, `DateChecker.LoadOnNewDateCallback` will be invoked.

With `SaveIO` you can write (and read) objects as JSON strings to (from) persistentDataPath.    