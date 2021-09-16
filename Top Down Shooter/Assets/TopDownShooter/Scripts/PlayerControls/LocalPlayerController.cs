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
        [SerializeField] private InputData _shootData;

        private void Update()
        {
            if (Input.GetKeyDown(_shootData.PositiveHorizontalKeyCode))
            {
                _playerInvertoryController.ReactiveShootCommand.Execute();
            }
        }
    }
}