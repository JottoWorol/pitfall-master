using Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Infrastructure
{
    public class FinishWindowView : MonoBehaviour
    {
        [SerializeField] private GameWindow _gameWindow;
        [SerializeField] private GameObject _loseLayout;
        [SerializeField] private GameObject _winLayout;
        [SerializeField] private Button _tryAgainButton;
        [SerializeField] private Button _nextButton;

        public GameWindow GameWindow => _gameWindow;
        public GameObject LoseLayout => _loseLayout;
        public GameObject WinLayout => _winLayout;
        public Button TryAgainButton => _tryAgainButton;
        public Button NextButton => _nextButton;
    }
}