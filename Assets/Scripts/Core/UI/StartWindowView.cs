using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class StartWindowView : MonoBehaviour
    {
        [SerializeField] private GameWindow _gameWindow;
        [SerializeField] private Button _playButton;

        public GameWindow GameWindow => _gameWindow;
        public Button PlayButton => _playButton;
    }
}