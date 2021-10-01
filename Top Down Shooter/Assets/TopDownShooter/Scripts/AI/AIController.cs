using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Invertory;
using TopDownShooter.PlayerControls;
using TopDownShooter.PlayerInput;
using UnityEngine;
using UniRx;
using System;

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

        public List<AITarget> TargetList;
        private Vector3 _targetMovementPosition;
        private CompositeDisposable _targetDipose;
        private void Awake()
        {
            _aiMovementInput = Instantiate(_aiMovementInput);
            _aiRotationInput = Instantiate(_aiRotationInput);
            _towerRotationInput = Instantiate(_towerRotationInput);

            _playerMovementController.InitializeInput(_aiMovementInput);
            _towerRotationController.InitializeInput(_towerRotationInput);

            UpdateTarget();
        }
        public void UpdateTarget()
        {
            UpdateTargetPosition();

            _targetDipose = new CompositeDisposable();
            TargetList[0].OnDeath.Subscribe(OnTargetDeath).AddTo(_targetDipose);
        }
        public void UpdateTargetPosition()
        {
            _targetMovementPosition = transform.position + (TargetList[0].transform.position - transform.position).normalized *
                (Vector3.Distance(TargetList[0].transform.position, transform.position) - 25);

            _aiMovementInput.SetTarget(transform, _targetMovementPosition);
            _aiRotationInput.SetTarget(transform, _targetMovementPosition);
            _towerRotationInput.SetTarget(_towerRotationController.TowerTransform, TargetList[0].transform.position);
        }
        private void OnTargetDeath(Unit obj)
        {
            Debug.Log("Target is dath");
            _targetDipose.Dispose();
            TargetList.RemoveAt(0);
            if(TargetList.Count > 0)
            {
                UpdateTarget();
            }
            else
            {
                this.enabled = false;
            }
        }
        private void Update()
        {
            UpdateTargetPosition();
            UpdateTargetList();

            _aiMovementInput.ProcessInput();
            _aiRotationInput.ProcessInput();
            _towerRotationInput.ProcessInput();

            if(_towerRotationInput.Horizontal < 0.1f && Vector3.Distance(_targetMovementPosition, transform.position) <= 25)
            {
                _playerInvertoryController.ReactiveShootCommand.Execute();
            }
        }
        public void UpdateTargetList()
        {
            for(int i = 0; i <= TargetList.Count - 1; i++)
            {
                if (TargetList[i] == null)
                {
                    Debug.Log("null");
                    TargetList.RemoveAt(i);
                }
            }
        }
    } 
}