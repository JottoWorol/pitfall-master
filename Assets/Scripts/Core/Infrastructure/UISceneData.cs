using Core.Joystick;
using Core.UI;
using UnityEngine;

namespace Core.Infrastructure
{
    public class UISceneData : MonoBehaviour
    {
        [SerializeField] private ScreenTouchView _screenTouchView;
        [SerializeField] private JoystickView _joystickView;
        [SerializeField] private StartWindowView _startWindowView;
        [SerializeField] private FinishWindowView _finishWindowView;
        public ScreenTouchView ScreenTouchView => _screenTouchView;
        public JoystickView JoystickView => _joystickView;
        public StartWindowView StartWindowView => _startWindowView;
        public FinishWindowView FinishWindowView => _finishWindowView;
    }
}