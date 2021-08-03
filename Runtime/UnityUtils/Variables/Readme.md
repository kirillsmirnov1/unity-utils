# Readme / XVariable
Store, display and save data.  
Inject objects. 

Based on Ryan Hipple\'s talk ![Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk).  
Main idea of that talk is using ScriptableObjects for passing data between classes.

## Store

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

- [ ] existing inheritors   
- [ ] onchange  
- [ ] power of xvar

## Display
- [ ] !!TODO!!
## Save
- [ ] !!TODO!!
## Inject
- [ ] !!TODO!!