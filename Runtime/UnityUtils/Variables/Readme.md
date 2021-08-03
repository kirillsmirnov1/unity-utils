# Readme / XVariable
Store, display and save data.  
Inject objects. 

Based on Ryan Hipple\'s talk ![Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk).  
Main idea of that talk is using ScriptableObjects for passing data between classes.

## Store

XVariable is easy to use to access data from different classes. Instead of setting up an access manager or DI system, you can easily drag-and-drop data into any MonoBehavior/ScriptableObject you want. Data can be set from code or inspector and used/changed anywhere.

`XVariable<T>` is an abstract `ScriptableObject`. To store data you need to inherit it with type/class/struct of your choice and create instance of it.

For example, `IntVariable` looks like this:
```
[CreateAssetMenu(fileName = "New Int Variable", menuName = "Variables/Int Variable", order = 0)]
public class IntVariable : XVariable<int> { }
``` 

### Usage

`XVariable<T>` inheritors can be referenced as any other `ScriptableObject`. `XVariable<T>` data can be accessed through `Value` property or with automatic type-cast if it is possible.
```
[SerializeField] private IntVariable currentHealth;
...
currentHealth.Value = 5; // Set in one class
...
var healthAfterHealing = currentHealth + 10; // Access in another
```  

### Arrays usage

There is also `XArrayVariable<T>` for arrays of data. It can be accessed as any other array.

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
- Value is changed from the inspector. In this case OnEntryChange is called for every array element.  

### TODO 

- [ ] existing inheritors   

## Display
- [ ] !!TODO!!
## Save
- [ ] !!TODO!!
## Inject
- [ ] !!TODO!!