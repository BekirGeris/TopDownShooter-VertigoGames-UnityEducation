using System.Collections;
using System.Collections.Generic;
using TouchControlsKit;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Input/TCK Input Data")]
    public class TCKInputData : AbstractInputData
    {
        public string AxisName;
        public bool IsActive;
        public override void ProcessInput(bool isActive)
        {
            this.ProcessInput();
        }
        public override void ProcessInput()
        {
            if (IsActive)
            {

            }
            else
            {
                Vector2 move = TCKInput.GetAxis(AxisName); // NEW func since ver 1.5.5
                Horizontal = move.x;
                Vertical = move.y;
            }
            
        }
    }
}