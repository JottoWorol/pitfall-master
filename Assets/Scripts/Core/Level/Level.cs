using System;
using System.Collections.Generic;
using Core.Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Level
{
    public class Level
    {
        private readonly LevelView _levelView;
        private readonly LevelConfig _levelConfig;
        private readonly EnemyFactory _enemyFactory;
        private readonly EnemyContainer _enemyContainer;
        private readonly Player _player;

        public Level(LevelView levelView, LevelConfig levelConfig, EnemyFactory enemyFactory,
            EnemyContainer enemyContainer, Player player)
        {
            _levelView = levelView;
            _levelConfig = levelConfig;
            _enemyFactory = enemyFactory;
            _enemyContainer = enemyContainer;
            _player = player;

            InitializePitfalls();
            StartEnemyWave(0);
            _player.MoveTo(_levelView.PlayerInitialPoint.position);
            
            _player.Died += OnPlayerDied;
        }

        public event Action LevelCompleted;

        public event Action LevelFailed;
        public event Action LevelFinished;

        private int _currentWaveIndex;

        private Transform[] SpawnPoints => _levelView.EnemySpawnPoints;

        private readonly List<EnemyPitfall> _enemyPitfalls = new List<EnemyPitfall>();

        private void StartEnemyWave(int waveIndex)
        {
            for (int enemyIndex = 0; enemyIndex < _levelConfig.EnemyWaveCount[waveIndex]; enemyIndex++)
            {
                _enemyFactory.SpawnEnemyAt(SpawnPoints[Random.Range(0, SpawnPoints.Length)].position);
            }
            
            _enemyContainer.EnemyCountChanged += OnEnemyCountChanged;
        }

        private void OnEnemyCountChanged()
        {
            if(_enemyContainer.Count <= 0)
                OnWaveFinished();
        }

        private void OnWaveFinished()
        {
            if(_currentWaveIndex < _levelConfig.EnemyWaveCount.Length - 1)
            {
                _currentWaveIndex++;
                StartEnemyWave(_currentWaveIndex);
            }
            else
            {
                OnLevelFinished();
                LevelCompleted?.Invoke();
            }
        }

        private void OnPlayerDied()
        {
            OnLevelFinished();
            LevelFailed?.Invoke();
        }

        private void InitializePitfalls()
        {
            foreach (var pitfallView in _levelView.PitfallViews)
            {
                var pitfall = new EnemyPitfall(pitfallView);
                _enemyPitfalls.Add(pitfall);
                pitfall.GotEnemy += OnPitfallGotEnemy;
            }
        }

        private void OnPitfallGotEnemy(EnemyView enemyView)
        {
            if(!_enemyContainer.TryGetEnemyByView(enemyView, out var enemy))
                return;

            _enemyContainer.DestroyEnemy(enemy);
        }

        private void OnLevelFinished()
        {
            _player.Died -= OnPlayerDied;
            
            foreach (var pitfall in _enemyPitfalls)
            {
                pitfall.GotEnemy -= OnPitfallGotEnemy;
                pitfall.OnDestroy();
            }
            
            LevelFinished?.Invoke();
        }
    }
}