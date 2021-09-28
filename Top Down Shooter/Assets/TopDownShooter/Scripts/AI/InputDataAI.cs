using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.AI
{
    public class InputDataAI : InputData
    {
        protected Vector3 _currantTarget;
        protected Transform _targetTransform;
        public void SetTarget(Transform targetTransform, Vector3 target)
        {
            _targetTransform = targetTransform;
            _currantTarget = target;
        }
        public override void ProcessInput()
        {
            base.ProcessInput();

        }
    }
}