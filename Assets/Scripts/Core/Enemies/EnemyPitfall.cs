using System;
using Core.Level;
using UnityEngine;

namespace Core.Enemies
{
    public class EnemyPitfall
    {
        private readonly EnemyPitfallView _enemyPitfallView;
        public event Action<EnemyView> GotEnemy; 

        public EnemyPitfall(EnemyPitfallView enemyPitfallView)
        {
            _enemyPitfallView = enemyPitfallView;
            _enemyPitfallView.OnColliderEnter += OnColliderEnter;
        }

        private void OnColliderEnter(Collider collider)
        {
            if(collider.TryGetComponent(out EnemyView enemyView))
                GotEnemy?.Invoke(enemyView);
        }

        public void OnDestroy()
        {
            _enemyPitfallView.OnColliderEnter -= OnColliderEnter;
        }
    }
}