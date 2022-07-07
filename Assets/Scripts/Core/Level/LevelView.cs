using UnityEngine;

namespace Core.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Transform[] _enemySpawnPoints;
        [SerializeField] private EnemyPitfallView[] _pitfallViews;
        [SerializeField] private Transform _playerInitialPoint;

        public Transform[] EnemySpawnPoints => _enemySpawnPoints;
        public EnemyPitfallView[] PitfallViews => _pitfallViews;

        public Transform PlayerInitialPoint => _playerInitialPoint;
    }
}