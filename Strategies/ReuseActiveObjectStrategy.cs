using System;
using System.Collections.Generic;
using UnityEngine;

namespace CatPot.Framework.Utils.Pooling
{
    [CreateAssetMenu(menuName = "CatPot/Pooling/Empty Pool Strategies/Reuse Active Object", order = 1)]
    public class ReuseActiveObjectStrategy : BaseEmptyPoolStrategy
    {
        public override PoolableObject HandleEmptyPool(Queue<PoolableObject> pool, List<PoolableObject> activeObjects, PoolableObject prefab, Action addObject)
        {
            PoolableObject newObject = activeObjects[0];
            newObject.OnReturn.Invoke();

            return newObject;
        }
    }

}