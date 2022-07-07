﻿using System;
using Core.Infrastructure;
using Core.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Joystick
{
    public class MoveJoystick : IStartable, IDestroyable
    {
        private readonly ScreenTouchView _screenTouchView;
        private readonly JoystickConfig _joystickConfig;
        private readonly JoystickView _joystickView;

        public MoveJoystick(UISceneData uiSceneData, StaticData staticData)
        {
            _joystickConfig = staticData.JoystickConfig;
            _screenTouchView = uiSceneData.ScreenTouchView;
            _joystickView = uiSceneData.JoystickView;
        }

        public event Action StartedMoving;
        public event Action StoppedMoving;
        private bool _isMoving;
        private Vector2 _initialPoint;
        public Vector2 Value { get; private set; }

        public void OnStart()
        {
            _screenTouchView.PointerDown += OnPointerDown;
            _screenTouchView.PointerUp += OnPointerUp;
            _screenTouchView.PointerDrag += OnPointerDrag;
        }

        public void OnDestroy()
        {
            _screenTouchView.PointerDown -= OnPointerDown;
            _screenTouchView.PointerUp -= OnPointerUp;
            _screenTouchView.PointerDrag -= OnPointerDrag;
        }

        private void OnPointerDrag(PointerEventData eventData)
        {
            Value = (eventData.position - _initialPoint) / _joystickConfig.RadiusPixels;
            Value = Vector2.ClampMagnitude(Value, 1f);
            _joystickView.SetMovePosition(Value);
            
            if (!_isMoving && Value.magnitude >= _joystickConfig.MoveThreshold)
            {
                StartMove();
            }

            if (_isMoving && Value.magnitude < _joystickConfig.MoveThreshold)
            {
                StopMove();
            }
        }

        private void OnPointerUp(PointerEventData eventData)
        {
            StopMove();
            _joystickView.SetActive(false);
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            _initialPoint = eventData.position;
            _joystickView.SetPosition(_initialPoint);
        }

        private void StartMove()
        {
            StartedMoving?.Invoke();
            _isMoving = true;
            _joystickView.SetActive(true);
        }

        private void StopMove()
        {
            StoppedMoving?.Invoke();
            _isMoving = false;
        }
    }
}