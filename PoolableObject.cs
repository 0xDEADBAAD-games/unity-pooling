using UnityEngine;
using UnityEngine.Events;

namespace CatPot.Framework.Utils.Pooling
{
    public class PoolableObject : MonoBehaviour
    {
        public UnityEvent OnEnabled;
        public UnityEvent OnReturn;

        public UnityEvent OnReset;

        private void OnEnable()
        {
            OnEnabled.Invoke();
        }

        /// <summary>
        /// Replace destroying the GameObject with this call
        /// </summary>
        public void Destroy()
        {
            OnReturn.Invoke();
        }
    }
}