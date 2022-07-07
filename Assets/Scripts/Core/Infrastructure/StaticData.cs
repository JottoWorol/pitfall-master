using Core.Enemies;
using Core.Joystick;
using Core.Level;
using UnityEngine;

namespace Core.Infrastructure
{
    public class StaticData : MonoBehaviour
    {
        [SerializeField] private JoystickConfig _joystickConfig;
        [SerializeField] private PlayerMoveConfig _playerMoveConfig;
        [SerializeField] private EnemyBehaviorConfig _enemyBehaviorConfig;
        [SerializeField] private EnemyView _enemyPrefab;
        [SerializeField] private LevelList _levelList;
        public JoystickConfig JoystickConfig => _joystickConfig;
        public PlayerMoveConfig PlayerMoveConfig => _playerMoveConfig;
        public EnemyBehaviorConfig EnemyBehaviorConfig => _enemyBehaviorConfig;
        public EnemyView EnemyPrefab => _enemyPrefab;
        public LevelList LevelList => _levelList;
    }
}