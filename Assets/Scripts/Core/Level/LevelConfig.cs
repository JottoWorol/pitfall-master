using UnityEngine;

namespace Core.Level
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Game Configs/LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private LevelView _levelPrefab;
        [SerializeField] private int[] _enemyWaveCount;

        public LevelView LevelPrefab => _levelPrefab;
        public int[] EnemyWaveCount => _enemyWaveCount;
    }
}