using System;
using UnityEngine;

namespace Core.Level
{
    public class EnemyDetector : MonoBehaviour
    {
        public event Action<Collider> CollisionEnter;
        
        private void OnCollisionEnter(Collision collision)
        {
            CollisionEnter?.Invoke(collision.collider);
        }
    }
}