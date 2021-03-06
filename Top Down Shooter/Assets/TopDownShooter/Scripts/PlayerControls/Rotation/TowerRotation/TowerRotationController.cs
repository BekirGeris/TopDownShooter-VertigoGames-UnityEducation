using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls 
{ 
    public class TowerRotationController : MonoBehaviour
    {
        [SerializeField] private AbstractInputData _inputData;
        [SerializeField] private Transform _tower;
        [SerializeField] private Transform _towerCanon;
        [SerializeField] private TowerRotationSettings _towerRotationSettings;

        public Transform TowerTransform { get { return _tower; } } 
        
        private float value = 0;
        public void InitializeInput(AbstractInputData inputData)
        {
            _inputData = inputData;
        }
        private void Update()
        {
            _tower.Rotate(0, _inputData.Horizontal * _towerRotationSettings.TowerRotationSpeed, 0, Space.Self);

            value = Mathf.Clamp(value, _towerRotationSettings.TowerCanonRotationAngleMin, _towerRotationSettings.TowerCanonRotationAngleMax);

            if(_inputData.Vertical > 0) //_inputData.PositiveVerticalKeyCode) 
            {
                _towerCanon.localRotation = Quaternion.Euler(value, _towerCanon.rotation.y, _towerCanon.rotation.z);
                value += _towerRotationSettings.TowerCanonRotationSpeed;
            } else if (_inputData.Vertical < 0) //_inputData.NegativeVerticalKeyCode
            {
                _towerCanon.localRotation = Quaternion.Euler(value, _towerCanon.rotation.y, _towerCanon.rotation.z);
                value -= _towerRotationSettings.TowerCanonRotationSpeed;
            }
        }
    }
}