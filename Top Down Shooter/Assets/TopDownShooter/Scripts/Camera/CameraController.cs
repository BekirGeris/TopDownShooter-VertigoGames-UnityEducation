using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private Transform _rotationTransform;
        [SerializeField] private Transform _positionTransform;
        [SerializeField] private Transform _cameraTransform;
        private void Update()
        {
            CameraRotationFollow();
            CameraMovementFollow();
        }

        private void CameraRotationFollow()
        {
            _cameraTransform.rotation = Quaternion.Lerp(_cameraTransform.rotation,
                Quaternion.LookRotation(_rotationTransform.position - _cameraTransform.position),
                Time.deltaTime * _cameraSettings.RotationLerpSpeet);
        }

        private void CameraMovementFollow()
        {
            _cameraTransform.localPosition = _cameraSettings.PositionOffset;

        }
    }
}
