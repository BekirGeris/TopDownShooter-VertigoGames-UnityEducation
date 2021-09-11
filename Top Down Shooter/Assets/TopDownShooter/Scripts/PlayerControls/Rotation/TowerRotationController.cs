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
        [SerializeField] private TowerRotationSettings _towerRotationSettings;

        private void Update()
        {
            _tower.Rotate(0, _inputData.Horizontal * _towerRotationSettings.TowerRotationSpeed, 0, Space.Self);
        }
    }
}