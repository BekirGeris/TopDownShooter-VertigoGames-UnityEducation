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
        private float firstSpeed;

        private void Start()
        {
            firstSpeed = _playerMovementSettings.VerticalSpeed;
        }

        private void Update()
        {
            _rigidbody.MovePosition((_rigidbody.position) + _rigidbody.transform.forward * _inputData.Vertical * _playerMovementSettings.VerticalSpeed);
            //_rigidbody.MovePosition((_rigidbody.position) +  _rigidbody.transform.right * _inputData.Horizontal * _playerMovementSettings.HorizontalSpeed);
            _targetTransform.Rotate(0, _inputData.Horizontal * _playerMovementSettings.RotationSpeed, 0, Space.Self);

            SpeedControls();
        }

        private void SpeedControls()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if(_playerMovementSettings.VerticalSpeed <= _playerMovementSettings.MaxSpeed)
                {
                    _playerMovementSettings.VerticalSpeed += _playerMovementSettings.Acceleration;
                }
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                _playerMovementSettings.VerticalSpeed = firstSpeed;
            }
        }
    }
}