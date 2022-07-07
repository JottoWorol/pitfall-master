using System;
using Core.Enemies;
using Core.Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Core.Level
{
    public class LevelLoader : IApplicationPauseListener
    {
        private const string CurrentLevelIndexKey = nameof(CurrentLevelIndex);
        private const string IsJustRestartedKey = nameof(IsJustRestarted);
        
        private readonly EnemyContainer _enemyContainer;
        private readonly EnemyFactory _enemyFactory;
        private readonly LevelList _levelList;
        private readonly Player _player;

        public LevelLoader(StaticData staticData, EnemyContainer enemyContainer, EnemyFactory enemyFactory,
            Player player)
        {
            _enemyContainer = enemyContainer;
            _enemyFactory = enemyFactory;
            _player = player;
            _levelList = staticData.LevelList;
        }

        public void LoadCurrentLevel() => LoadLevel(CurrentLevelIndex);
        public Level CurrentLevel { get; private set; }

        public event Action LevelStarted;

        public int CurrentLevelIndex
        {
            get => PlayerPrefs.GetInt(CurrentLevelIndexKey, 0);
            private set => PlayerPrefs.SetInt(CurrentLevelIndexKey, value);
        }

        public bool IsJustRestarted
        {
            get => PlayerPrefs.GetInt(IsJustRestartedKey, 0) == 1;
            private set => PlayerPrefs.SetInt(IsJustRestartedKey, value ? 1 : 0);
        }

        public void OnApplicationPause(bool pause)
        {
            if (pause)
                IsJustRestarted = false;
        }

        public void RestartScene()
        {
            IsJustRestarted = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void IncrementLevelIndex()
        {
            CurrentLevelIndex = (CurrentLevelIndex + 1) % _levelList.Levels.Count;
        }

        private Level LoadLevel(int levelIndex)
        {
            var config = _levelList.Levels[levelIndex];

            var view = Object.Instantiate(config.LevelPrefab);
            var level = new Level(view, config, _enemyFactory, _enemyContainer, _player);

            CurrentLevel = level;
            LevelStarted?.Invoke();
            level.LevelCompleted += OnLevelCompleted;
            level.LevelFailed += OnLevelFailed;
            return level;
        }

        private void OnLevelFailed()
        {
            CurrentLevel.LevelCompleted -= OnLevelCompleted;
            CurrentLevel.LevelFailed -= OnLevelFailed;
        }

        private void OnLevelCompleted()
        {
            CurrentLevel.LevelCompleted -= OnLevelCompleted;
            CurrentLevel.LevelFailed -= OnLevelFailed;
            IncrementLevelIndex();
        }
    }
}