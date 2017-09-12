using System;
using System.Collections.Generic;
using UnityEngine;

namespace CatPot.Framework.Utils.Pooling
{
    [CreateAssetMenu(menuName = "CatPot/Pooling/Empty Pool Strategies/Instantiate New Object", order = 1)]
    public abstract class InstantiateNewObjectStrategy : BaseEmptyPoolStrategy
    {
        public override PoolableObject HandleEmptyPool(Queue<PoolableObject> pool, List<PoolableObject> activeObjects, PoolableObject prefab, Action addObject)
        {
            PoolableObject newObject = Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            newObject.OnReset.Invoke();
            return newObject;
        }
    }

}