# unity-pooling
Test for a simple and straightforward pooling system for Unity3D

How it's supposed to work:

1. Attach a "PoolableObject" component to any prefab you want to pool
2. Hook methods you want executed on enabling your object to the "OnEnabled" UnityEvent
3. Hook methods you want executed when returning your object to the pool to the "OnReturn" UnityEvent
4. Hook methods you want executed when returning your object to its default state to the "OnEnabled" UnityEvent
5. Attach an "ObjectPool" component to the GameObject holding your pool
6. Select a prefab and an initial pool size
7. Navigate to a project folder where you want to instantiate a "Strategy" ScriptableObject to determine how your pool should behave
8. Right click in the folder and navigate to "CatPot/Pooling/Empty Pool Strategies/Increase Pool Size" menu to select an object to spawn (there are a couple built-in)
9. Drag and drop the created object to the "Empty Pool Strategy" field on the pool's inspector
10. Instead of calling Destroy(gameObject) on the pooled objects, use the Destroy() method of their PoolableObject component.

That should be it. If anything explodes feel free to report a bug.
