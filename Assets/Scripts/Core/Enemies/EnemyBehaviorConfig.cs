using UnityEngine;

namespace Core.Enemies
{
    [CreateAssetMenu(fileName = "EnemyBehaviorConfig", menuName = "Game Configs/EnemyBehaviorConfig",
        order = 0
    )]
    public class EnemyBehaviorConfig : ScriptableObject
    {
        [SerializeField] private float _speed = 1f;

        public float Speed => _speed;
    }
}