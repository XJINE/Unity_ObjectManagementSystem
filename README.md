# Unity_ObjectManagementSystem

<img src="https://github.com/XJINE/Unity_ObjectManagementSystem/blob/master/Screenshot.png" width="100%" height="auto" />

ObjectManagementSystem provide a quite simple logic to control object counts and same group reference.

## Import to Your Project

You can import this asset from UnityPackage.

- [ObjectManagementSystem.unitypackage](https://github.com/XJINE/Unity_ObjectManagementSystem/blob/master/ObjectManagementSystem.unitypackage)

## How to Use

There are 3 components in this system and need to make inheritance of them.

- ``ManagedObject`` : Object gets this component when added into ``ObjectManager``.
- ``ObjectGenerator`` : Generate object instance which will be added into ``ObjectManager``.
- ``ObjectManager`` : Manage objects count and the references.

NOTE: If you need more detail, check sample scene.

### ObjectManager

``ObjectManager`` will be initialized in ``Awake()``.

NOTE: But it can also initialize on your own with ``Initialize()`` if you need.

If you want to add some object to manage, use ``AddManagedObject<U>``.
This ``U`` is ``ManagedObject``. This function will return ``U`` instance when succeeded or return null when failed.
And then, added object gets ``ManagedObject`` as component.

Managed objects in this manager are able to reference with ``ManagedObjects`` property and this is ``ReadOnlyCollection``.

If you want to release or remove object from manager, use ``ReleaseManagedObject~()`` or ``RemoveManagedObject()~``.

### ManagedObject

``ManagedObject`` is attached to object as component when the object added to ``ObjectManager``.

``ManagedObject`` has ``ObjectManager`` property.
This is reference to ``ObjectManager`` which manages own.
And when ``OnDestroy()`` called, the ``ObjectManager`` will remove the reference to this instance.

``T Data`` property is most important things of all.
You can pass a any data to each ``ManagedObject`` and referenct it as you like.
By using "T(Data)", it is able to divide manage logic(code) and the others.

To use ``T Data``, have to implement abstract method ``ObjectManager.ReturnManagedObjectData()``.

### ObjectGenerator

You don't have to inherit and use ``ObjectGenerator`` when you not need.
``ObjectGenerator`` is generate some Object instance and add it to ``ObjectManager``.

Set some prefabs which you want to generate and the generate rate into Inspector,
and call ``Generate()`` or ``GenerateRandom()``.

## Ex.

These are sample implementation. Quite simple.

```csharp

public class SampleObjectBehaviour : MonoBehaviour
{
    … Random walk logic.
}
    
public class SampleManagedObject : ManagedObject<SampleObjectBehaviour>{}

public class SampleObjectManager : ObjectManager<SampleObjectBehaviour>
{
    protected override SampleObjectBehaviour ReturnManagedObjectData(GameObject managedGameObject)
    {
        return managedGameObject.GetComponent<SampleObjectBehaviour>();
    }
}

public class SampleObjectGenerator : ObjectGenerator<SampleObjectBehaviour>{}
```

Sample scene have a debugger like this.

```csharp
public class SampleObjectGeneratorDebugger : MonoBehaviour
…
protected virtual void Update()
{
    if (Input.GetKeyDown(this.generateKey))
    {
        this.ObjectGenerator.GenerateRandom<SampleManagedObject>(Vector3.zero);
    }
    if (Input.GetKeyDown(this.removeAllKey))
    {
        this.ObjectGenerator.ObjectManager.RemoveAllManagedObjects();
    }
}
```

``SampleObjectPainter`` is sample to show the way to control managed objects from outside.

```csharp
public class SampleObjectPainter : MonoBehaviour
…
void Update()
{
    if (Time.frameCount % 180 == 0)
    {
        foreach (SampleManagedObject managedObject in this.sampleObjectManager.ManagedObjects)
        {
            managedObject.Data.SetColor(this.colors[Random.Range(0, this.colors.Length)]);
        }
    }
}
```