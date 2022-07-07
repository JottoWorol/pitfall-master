using Core.Infrastructure;
using Core.Level;

namespace Core.UI
{
    public class StartWindow : IStartable
    {
        private readonly StartWindowView _view;
        private readonly LevelLoader _levelLoader;
        
        public StartWindow(UISceneData uiSceneData, LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
            _view = uiSceneData.StartWindowView;
        }

        private void OnPlayButtonClick()
        {
            _levelLoader.LoadCurrentLevel();
            _view.GameWindow.Close();
        }
        
        public void OnStart()
        {
            if (_levelLoader.IsJustRestarted)
            {
                _levelLoader.LoadCurrentLevel();
                return;
            }
            
            _view.GameWindow.Open();
            _view.PlayButton.onClick.AddListener(OnPlayButtonClick);
        }
    }
}