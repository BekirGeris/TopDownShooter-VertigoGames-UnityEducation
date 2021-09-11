using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private InputData _inputRotationData;
        Vector3 _lastMouseInput;
        private void Update()
        {
            _inputData.Horizontal = Input.GetAxis("Horizontal");
            _inputData.Vertical = Input.GetAxis("Vertical");
            
            _inputRotationData.Horizontal = (_lastMouseInput.x - Input.mousePosition.x);
            _lastMouseInput = Input.mousePosition;
        }
    }
}
