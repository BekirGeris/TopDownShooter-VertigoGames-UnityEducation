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
        private void Update()
        {
            _tower.Rotate(0, _inputData.Horizontal * _towerRotationSettings.TowerRotationSpeed, 0, Space.Self);


            if (_towerRotationSettings.TowerCanonRotationMax >= _towerCanon.rotation.x && _towerCanon.rotation.x >= _towerRotationSettings.TowerCanonRotationMin)
            {
                _towerCanon.Rotate(_inputData.Vertical * _towerRotationSettings.TowerRotationSpeed, 0, 0, Space.Self);
            }
            else
            {
                if (_towerRotationSettings.TowerCanonRotationMax <= _towerCanon.rotation.x && _inputData.Vertical < 0)
                    _towerCanon.Rotate(_inputData.Vertical * _towerRotationSettings.TowerRotationSpeed, 0, 0, Space.Self);

                if (_towerRotationSettings.TowerCanonRotationMin >= _towerCanon.rotation.x && _inputData.Vertical > 0)
                    _towerCanon.Rotate(_inputData.Vertical * _towerRotationSettings.TowerRotationSpeed, 0, 0, Space.Self);
            }
            
        }
    }
}