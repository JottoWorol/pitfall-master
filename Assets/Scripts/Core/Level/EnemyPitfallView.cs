using System;
using UnityEngine;

namespace Core.Level
{
    public class EnemyPitfallView : MonoBehaviour
    {
        public event Action<Collider> OnColliderEnter;
        private void OnTriggerEnter(Collider other)
        {
            OnColliderEnter?.Invoke(other);
        }
    }
}