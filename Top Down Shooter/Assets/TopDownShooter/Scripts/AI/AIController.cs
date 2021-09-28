using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Invertory;
using TopDownShooter.PlayerControls;
using TopDownShooter.PlayerInput;
using UnityEngine;
 
namespace TopDownShooter.AI
{ 
    public class AIController : MonoBehaviour
    {
        [SerializeField] private InputDataAI _aiMovementInput;
        [SerializeField] private InputDataAI _aiRotationInput;
        [SerializeField] private InputDataAI _towerRotationInput;
        [SerializeField] private PlayerInvertoryController _playerInvertoryController;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private TowerRotationController _towerRotationController;

        public Transform _movementTarget;
        public Transform _towerTarget;
        private void Awake()
        {
            _aiMovementInput = Instantiate(_aiMovementInput);
            _aiRotationInput = Instantiate(_aiRotationInput);
            _towerRotationInput = Instantiate(_towerRotationInput);
            _playerMovementController.InitializeInput(_aiMovementInput);
            _towerRotationController.InitializeInput(_towerRotationInput);
        }
        private void Update()
        {
            _aiMovementInput.SetTarget(transform, _movementTarget.position);
            _aiRotationInput.SetTarget(transform, _movementTarget.position);
            _towerRotationInput.SetTarget(_towerRotationController.TowerTransform, _towerTarget.position);

            _aiMovementInput.ProcessInput();
            _aiRotationInput.ProcessInput();
            _towerRotationInput.ProcessInput();

            if(Vector3.Distance(_movementTarget.position, transform.position) < 25)
            {
                _playerInvertoryController.ReactiveShootCommand.Execute();
            }
        }
    }
}