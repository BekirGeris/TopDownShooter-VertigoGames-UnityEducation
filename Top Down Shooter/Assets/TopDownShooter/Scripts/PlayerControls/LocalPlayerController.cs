using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Invertory;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter
{
    public class LocalPlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInvertoryController _playerInvertoryController;
        [SerializeField] private AbstractInputData _shootData;

        private void Update()
        {
            if (_shootData.Horizontal > 0) //Input.GetKeyDown(_shootData.PositiveHorizontalKeyCode)
            {
                _playerInvertoryController.ReactiveShootCommand.Execute();
            }
        }
    }
}