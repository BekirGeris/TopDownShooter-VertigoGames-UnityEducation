using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    public class WheelController : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private WheelSettings _wheelSettings;
        [SerializeField] private List<Transform> wheels;
        /*
        wheels[0] => Right Front
        wheels[1] => Left Front
        wheels[2] => Right Back
        wheels[3] => Left Back
        */
        private void Update()
        {
            StatControl();
        }
        private void StatControl()
        {
            if (_inputData.Vertical > 0)
            {
                Front();
                if (_inputData.Horizontal > 0)
                {
                    FrontRight();
                }
                else if (_inputData.Horizontal < 0)
                {
                    FrontLeft();
                }
            }
            else if (_inputData.Vertical < 0)
            {
                Back();
                if (_inputData.Horizontal > 0)
                {
                    BackRight();
                }
                else if (_inputData.Horizontal < 0)
                {
                    BackLeft();
                }
            }
            else if (_inputData.Horizontal > 0)
            {
                Right();
            }
            else if (_inputData.Horizontal < 0)
            {
                Left();
            }
        }
        private void Front()
        {
            foreach(Transform wheel in wheels)
            {
                wheel.transform.Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            }
        }
        private void FrontRight()
        {
            wheels[0].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[1].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed * _wheelSettings.RightLeftCoefficient, 0, 0, Space.Self);
            wheels[2].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[3].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed * _wheelSettings.RightLeftCoefficient, 0, 0, Space.Self);
        }
        private void FrontLeft()
        {
            wheels[0].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed * _wheelSettings.RightLeftCoefficient, 0, 0, Space.Self);
            wheels[1].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[2].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed * _wheelSettings.RightLeftCoefficient, 0, 0, Space.Self);
            wheels[3].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
        }
        private void Back()
        {
            foreach (Transform wheel in wheels)
            {
                wheel.transform.Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            }
        }
        private void BackRight()
        {
            wheels[0].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed * _wheelSettings.RightLeftCoefficient, 0, 0, Space.Self);
            wheels[1].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[2].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed * _wheelSettings.RightLeftCoefficient, 0, 0, Space.Self);
            wheels[3].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
        }
        private void BackLeft()
        {
            wheels[0].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[1].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed * _wheelSettings.RightLeftCoefficient, 0, 0, Space.Self);
            wheels[2].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[3].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed * _wheelSettings.RightLeftCoefficient, 0, 0, Space.Self);
        }
        private void Right()
        {
            wheels[0].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[1].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[2].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[3].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
        }
        private void Left()
        {
            wheels[0].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[1].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[2].Rotate(_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
            wheels[3].Rotate(-_wheelSettings.VerticalAngle * _wheelSettings.VerticalSpeed, 0, 0, Space.Self);
        }

    }
}
