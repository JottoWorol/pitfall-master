using UnityEngine;

namespace Core.Level
{
    [CreateAssetMenu(fileName = "PlayerMoveConfig", menuName = "Game Configs/PlayerMoveConfig", order = 0)]
    public class PlayerMoveConfig : ScriptableObject
    {
        [SerializeField] private float _speed = 1f;

        public float Speed => _speed;
    }
}