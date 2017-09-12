using System;
using System.Collections.Generic;
using UnityEngine;

namespace CatPot.Framework.Utils.Pooling
{
    [CreateAssetMenu(menuName = "CatPot/Pooling/Empty Pool Strategies/Throw Exception", order = 1)]
    public class ThrowExceptionStrategy : BaseEmptyPoolStrategy
    {
        public override PoolableObject HandleEmptyPool(Queue<PoolableObject> pool, List<PoolableObject> activeObjects, PoolableObject prefab, Action addObject)
        {
            throw new IndexOutOfRangeException("You're trying to spawn more objects than your pool size.");
        }
    }

}