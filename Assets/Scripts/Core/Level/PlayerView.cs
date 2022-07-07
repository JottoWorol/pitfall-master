using UnityEngine;

namespace Core.Level
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private EnemyDetector _enemyDetector;

        public Rigidbody Rigidbody => _rigidbody;
        public EnemyDetector EnemyDetector => _enemyDetector;
    }
}