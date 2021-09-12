using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TopDownShooter.PlayerControls
{ 
    [CreateAssetMenu(menuName = "TopDown Shooter/Player Controls/Rotation/Wheel Rotation Settings")]
    public class WheelSettings : ScriptableObject
    {
        public float VerticalAngle = 1;
        public float VerticalSpeed = 10;
        public float RightLeftCoefficient = 2;
    }
}