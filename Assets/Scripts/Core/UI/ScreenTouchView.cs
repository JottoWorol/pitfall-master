﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI
{
    public class ScreenTouchView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        private int? _pointerId = null;

        public event Action<PointerEventData> PointerDown;
        public event Action<PointerEventData> PointerUp;
        public event Action<PointerEventData> PointerDrag;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_pointerId != null)
                return;

            _pointerId = eventData.pointerId;
            PointerDown?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_pointerId != eventData.pointerId)
                return;

            _pointerId = null;
            PointerUp?.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_pointerId != eventData.pointerId)
                return;

            PointerDrag?.Invoke(eventData);
        }
    }
}