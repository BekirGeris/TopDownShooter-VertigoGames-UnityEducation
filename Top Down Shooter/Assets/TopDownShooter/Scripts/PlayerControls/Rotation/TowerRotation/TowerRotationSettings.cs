using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Player Controls/Rotation/Tower Rotation Settings")]
    public class TowerRotationSettings : ScriptableObject
    {
        public float TowerRotationSpeed = 1;
        public float TowerCanonRotationMax = 10;
        public float TowerCanonRotationMin = -10;
    }
}
