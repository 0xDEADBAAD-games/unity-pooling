using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatPot.Framework.Utils.Pooling
{
    [CreateAssetMenu(menuName = "CatPot/Pooling/Empty Pool Strategies/Increase Pool Size", order = 1)]
    public class IncreasePoolSizeStrategy : BaseEmptyPoolStrategy
    {
        [SerializeField] private int _amount;

        public override PoolableObject HandleEmptyPool(Queue<PoolableObject> pool, List<PoolableObject> activeObjects, PoolableObject prefab, Action addObject)
        {
            for(int i = 0; i < _amount; i++)
            {
                addObject();
            }

            return null;
        }
    }

}