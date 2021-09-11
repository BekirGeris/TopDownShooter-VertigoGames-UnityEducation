using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{ 
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;

        private void Update()
        {
            _rigidbody.MovePosition((_rigidbody.position) + _rigidbody.transform.forward * _inputData.Vertical * _playerMovementSettings.VerticalSpeed);
            //_rigidbody.MovePosition((_rigidbody.position) +  _rigidbody.transform.right * _inputData.Horizontal * _playerMovementSettings.HorizontalSpeed);
            _targetTransform.Rotate(0, _inputData.Horizontal * _playerMovementSettings.RotationSpeed, 0, Space.Self);
        }
    }
}