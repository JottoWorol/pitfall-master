using Core.Infrastructure;
using UnityEngine;

namespace Core.Enemies
{
    public class EnemyFactory
    {
        private readonly EnemyContainer _enemyContainer;
        private readonly EnemyView _enemyPrefab;
        
        public EnemyFactory(EnemyContainer enemyContainer, StaticData staticData)
        {
            _enemyContainer = enemyContainer;
            _enemyPrefab = staticData.EnemyPrefab;
        }

        public Enemy SpawnEnemyAt(Vector3 position)
        {
            var view = Object.Instantiate(_enemyPrefab, position, Quaternion.identity);
            var enemy = new Enemy(view);
            _enemyContainer.Add(enemy);
            return enemy;
        }
    }
}