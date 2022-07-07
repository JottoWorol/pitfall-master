using Core.Infrastructure;
using Core.Level;

namespace Core.Enemies
{
    public class EnemyBehavior : IUpdateable
    {
        private readonly EnemyContainer _enemyContainer;
        private readonly EnemyBehaviorConfig _behaviorConfig;
        private LevelLoader _levelLoader;
        private readonly Player _player;

        public EnemyBehavior(EnemyContainer enemyContainer, Player player, StaticData staticData, LevelLoader levelLoader)
        {
            _enemyContainer = enemyContainer;
            _player = player;
            _levelLoader = levelLoader;
            _behaviorConfig = staticData.EnemyBehaviorConfig;
            
            _levelLoader.LevelStarted += OnLevelStarted;
        }

        private bool _applyBehavior;

        private void OnLevelStarted()
        {
            _levelLoader.LevelStarted -= OnLevelStarted;
            _levelLoader.CurrentLevel.LevelFinished += OnLevelFinished;
            
            _applyBehavior = true;
        }

        private void OnLevelFinished()
        {
            _levelLoader.CurrentLevel.LevelFinished -= OnLevelFinished;
            _applyBehavior = false;
        }

        public void OnUpdate()
        {
            if(!_applyBehavior)
                return;
            
            foreach (var enemy in _enemyContainer.Enemies)
            {
                var directionVector = _player.Position - enemy.Position;
                enemy.SetVelocity(directionVector.normalized * _behaviorConfig.Speed);
            }
        }
    }
}