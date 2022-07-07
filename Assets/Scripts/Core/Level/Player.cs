using System;
using Core.Enemies;
using Core.Infrastructure;
using UnityEngine;

namespace Core.Level
{
    public class Player
    {
        public Player(SceneData sceneData)
        {
            PlayerView = sceneData.PlayerView;
            
            PlayerView.EnemyDetector.CollisionEnter += OnEnemyDetectorCollisionEnter;
        }

        public Vector3 Position => PlayerView.transform.position;

        public PlayerView PlayerView { get; }

        public event Action Died;

        public void MoveTo(Vector3 position) => PlayerView.Rigidbody.position = position;

        private void OnEnemyDetectorCollisionEnter(Collider collider)
        {
            if(!collider.TryGetComponent(out EnemyView _))
                return;
            
            Die();
        }
        
        private void Die()
        {
            Died?.Invoke();
            PlayerView.EnemyDetector.CollisionEnter += OnEnemyDetectorCollisionEnter;
        }
    }
}