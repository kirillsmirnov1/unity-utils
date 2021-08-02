# Readme / XVariable
Store, display and save data.  
Inject objects. 

Based on Ryan Hipple\'s talk ![Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk).  
Main idea of that talk is using ScriptableObjects for passing data between other classes.

## Store

XVariable is an abstract generic `ScriptableObject`. To store data you need to inherit it with type/class/struct of your choice.

For example, `IntVariable` looks like this:
```
public class IntVariable : XVariable<int> { }
``` 

XVariable inheritors can be referenced as any other `ScriptableObject`. 
```
[SerializeField] private IntVariable currentHealth;
```
XVariable<T> data can be accessed through Value property or with automatic type-cast there it is possible.
```
currentHealth.Value = 5;
var healthAfterHealing = currentHealth + 10;
```  
  
• arrays
• onchange  
• power of xvar

## Display
!!TODO!!
## Save
!!TODO!!
## Inject
!!TODO!!