using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Input/Player Input Data")]
    public class InputData : AbstractInputData
    {
        [Header("Axis Base Control")]
        [SerializeField] private bool _axisActive;
        [SerializeField] private string AxisNameHorizontal;
        [SerializeField] private string AxisNameVertical;

        [Header("Key Base Control")]
        [SerializeField] private bool _keyBaseHorizontalActive;
        [SerializeField] public KeyCode PositiveHorizontalKeyCode;
        [SerializeField] public KeyCode NegativeHorizontalKeyCode;
        [SerializeField] private bool _keyBaseVerticalActive;
        [SerializeField] public KeyCode PositiveVerticalKeyCode;
        [SerializeField] public KeyCode NegativeVerticalKeyCode;
        [SerializeField] private float _increaseAmount = 0.015f;

        public override void ProcessInput(bool isActive)
        {
            if (isActive)
            {
                if (_axisActive)
                {
                    Horizontal = Input.GetAxis(AxisNameHorizontal.ToString());
                    Vertical = Input.GetAxis(AxisNameVertical.ToString());
                }
                else
                {
                    if (_keyBaseHorizontalActive)
                    {
                        KeyBaseAxisControl(ref Horizontal, PositiveHorizontalKeyCode, NegativeHorizontalKeyCode);
                    }
                    if (_keyBaseVerticalActive)
                    {
                        KeyBaseAxisControl(ref Vertical, PositiveVerticalKeyCode, NegativeVerticalKeyCode);
                    }
                }
            }
        }

        private void KeyBaseAxisControl(ref float value, KeyCode positive, KeyCode negative)
        {
            bool positiveActive = Input.GetKey(positive);
            bool negativeActive = Input.GetKey(negative);
            if (positiveActive)
            {
                value += _increaseAmount;
            }
            else if (negativeActive)
            {
                value -= _increaseAmount;
            }
            else
            {
                value = 0;
            }

            value = Mathf.Clamp(value, -1, 1);
        }

        
    }
}