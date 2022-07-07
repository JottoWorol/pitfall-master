using Core.Level;
using UnityEngine;

namespace Core.Infrastructure
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;

        public PlayerView PlayerView => _playerView;
    }
}