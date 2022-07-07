using UnityEngine;

namespace Core.Camera
{
    public class CameraTransposer : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Transform _targetTransform;

        private Vector3 _prevPosition;

        private void Start()
        {
            _prevPosition = _targetTransform.position;
        }

        public void Update()
        {
            var newTargetPosition = _targetTransform.position;
            _cameraTransform.position += newTargetPosition - _prevPosition;
            _prevPosition = newTargetPosition;
        }
    }
}