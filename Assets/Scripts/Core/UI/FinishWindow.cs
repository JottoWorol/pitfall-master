using Core.Infrastructure;
using Core.Level;

namespace Core.UI
{
    public class FinishWindow
    {
        private readonly LevelLoader _levelLoader;
        private readonly FinishWindowView _view;
        
        public FinishWindow(UISceneData uiSceneData, LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
            _view = uiSceneData.FinishWindowView;

            _levelLoader.LevelStarted += OnLevelStarted;
        }

        private void OnLevelStarted()
        {
            _levelLoader.LevelStarted -= OnLevelStarted;
            
            _levelLoader.CurrentLevel.LevelCompleted += OnLevelCompleted;
            _levelLoader.CurrentLevel.LevelFailed += OnLevelFailed;
        }

        private void InitializeWindow()
        {
            _levelLoader.CurrentLevel.LevelCompleted -= OnLevelCompleted;
            _levelLoader.CurrentLevel.LevelFailed -= OnLevelFailed;
            
            _view.GameWindow.Open();
        }

        private void OnLevelFailed()
        {
            InitializeWindow();
            _view.LoseLayout.SetActive(true);
            _view.WinLayout.SetActive(false);
            
            _view.TryAgainButton.onClick.AddListener(OnTryAgainButtonClick);
        }

        private void OnLevelCompleted()
        {
            InitializeWindow();
            _view.LoseLayout.SetActive(false);
            _view.WinLayout.SetActive(true);
            
            _view.NextButton.onClick.AddListener(OnNextButtonClick);
        }

        private void OnNextButtonClick()
        {
            _view.NextButton.onClick.RemoveListener(OnNextButtonClick);
            _levelLoader.RestartScene();
        }
        
        private void OnTryAgainButtonClick()
        {
            _view.TryAgainButton.onClick.RemoveListener(OnTryAgainButtonClick);
            _levelLoader.RestartScene();
        }
    }
}