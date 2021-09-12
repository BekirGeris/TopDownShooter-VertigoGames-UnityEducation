using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private AbstractInputData[] _inputDataArray;
        private bool isActive = true;
        private void Update()
        {
            for (int i = 0; i < _inputDataArray.Length; i++)
            {
                _inputDataArray[i].ProcessInput(isActive);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
