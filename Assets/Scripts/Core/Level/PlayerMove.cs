using Core.Infrastructure;
using Core.Joystick;
using UnityEngine;

namespace Core.Level
{
    public class PlayerMove : IStartable, IDestroyable, IUpdateable
    {
        private readonly MoveJoystick _moveJoystick;
        private readonly PlayerView _playerView;
        private readonly PlayerMoveConfig _playerMoveConfig;

        private bool _isMoving;
        
        public PlayerMove(Player player, MoveJoystick moveJoystick, StaticData staticData)
        {
            _moveJoystick = moveJoystick;
            _playerMoveConfig = staticData.PlayerMoveConfig;
            _playerView = player.PlayerView;
        }
        
        public void OnStart()
        {
            _moveJoystick.StartedMoving += OnStartedMoving;
            _moveJoystick.StoppedMoving += OnStoppedMoving;
        }

        public void OnDestroy()
        {
            _moveJoystick.StartedMoving -= OnStartedMoving;
            _moveJoystick.StoppedMoving -= OnStoppedMoving;
        }

        private void OnStartedMoving()
        {
            if(_isMoving || _playerView == null)
                return;
            
            _isMoving = true;
        }
        
        private void OnStoppedMoving()
        {
            if(!_isMoving || _playerView == null)
                return;
            
            _playerView.Rigidbody.velocity = Vector3.zero;
            _isMoving = false;
        }

        public void OnUpdate()
        {
            if(!_isMoving || _playerView == null)
                return;

            var joystickValue = _moveJoystick.Value;
            var velocity = new Vector3(joystickValue.x, 0, joystickValue.y).normalized;
            _playerView.Rigidbody.velocity = velocity * _playerMoveConfig.Speed;
            _playerView.Rigidbody.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
    }
}