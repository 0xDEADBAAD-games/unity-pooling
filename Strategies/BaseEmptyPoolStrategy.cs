using System;
using System.Collections.Generic;
using UnityEngine;

namespace CatPot.Framework.Utils.Pooling
{
    public abstract class BaseEmptyPoolStrategy : ScriptableObject
    {
        public abstract PoolableObject HandleEmptyPool(Queue<PoolableObject> pool, List<PoolableObject> activeObjects, PoolableObject prefab, Action addObject);
    }

}