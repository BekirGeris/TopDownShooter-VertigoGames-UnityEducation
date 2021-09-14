using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls 
{ 
    public class TowerRotationController : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private Transform _tower;
        [SerializeField] private Transform _towerCanon;
        [SerializeField] private TowerRotationSettings _towerRotationSettings;
        private float value = 0;
        private void Update()
        {
            _tower.Rotate(0, _inputData.Horizontal * _towerRotationSettings.TowerRotationSpeed, 0, Space.Self);

            value = Mathf.Clamp(value, _towerRotationSettings.TowerCanonRotationAngleMin, _towerRotationSettings.TowerCanonRotationAngleMax);

            if(Input.GetKey(_inputData.PositiveVerticalKeyCode))
            {
                _towerCanon.localRotation = Quaternion.Euler(value, _towerCanon.rotation.y, _towerCanon.rotation.z);
                value += _towerRotationSettings.TowerCanonRotationSpeed;
            } else if (Input.GetKey(_inputData.NegativeVerticalKeyCode))
            {
                _towerCanon.localRotation = Quaternion.Euler(value, _towerCanon.rotation.y, _towerCanon.rotation.z);
                value -= _towerRotationSettings.TowerCanonRotationSpeed;
            }
        }
    }
}