using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.AI
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Input/AI/Input Movement Data AI")]
    public class InputMovementDataAI : InputDataAI
    {
        public override void ProcessInput()
        {
            float distance = Vector3.Distance(_targetTransform.position, _currantTarget);
            if(distance > 20)
            {
                Vertical = 1;
            }
            else
            {
                Vertical = 0;
            }
            Vector3 dir = _currantTarget - _targetTransform.position;
            var rotation = Quaternion.LookRotation(dir, Vector3.up).eulerAngles;
            if(rotation.y > 360)
            {
                rotation.y = 360 - rotation.y;
            }
            var rotationGap = rotation.y - _targetTransform.rotation.eulerAngles.y;
            bool isGapNegatife = rotationGap < 0;
            if (Mathf.Abs(rotationGap) > 5)
            {
                float horizontalCalmped = Mathf.Clamp(Mathf.Abs(rotationGap / 180), -1, 1);
                Horizontal = horizontalCalmped;
            }
            else
            {
                Horizontal = 0;
            }
        }
    }
}