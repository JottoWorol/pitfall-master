using System;
using System.Collections.Generic;

namespace Core.Enemies
{
    public class EnemyContainer
    {
        private readonly List<Enemy> _enemies = new List<Enemy>();
        
        private readonly Dictionary<EnemyView, Enemy> _viewToEnemyMap = new Dictionary<EnemyView, Enemy>();

        public void Add(Enemy enemy)
        {
            _enemies.Add(enemy);
            _viewToEnemyMap.Add(enemy.View, enemy);
            EnemyCountChanged?.Invoke();
        }

        public IEnumerable<Enemy> Enemies => _enemies;
        public int Count => _enemies.Count;
        public event Action EnemyCountChanged;

        public bool TryGetEnemyByView(EnemyView enemyView, out Enemy enemy)
        {
            if (!_viewToEnemyMap.ContainsKey(enemyView))
            {
                enemy = null;
                return false;
            }
            
            enemy = _viewToEnemyMap[enemyView];
            return true;
        }

        public void DestroyEnemy(Enemy enemy)
        {
            _viewToEnemyMap.Remove(enemy.View);
            _enemies.Remove(enemy);
            enemy.Destroy();
            EnemyCountChanged?.Invoke();
        }
    }
}