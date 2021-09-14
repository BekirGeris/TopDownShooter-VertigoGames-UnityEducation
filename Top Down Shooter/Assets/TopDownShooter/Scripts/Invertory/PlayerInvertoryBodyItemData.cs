using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory
{
    public class PlayerInvertoryBodyItemData : AbstractPlayerInvertoryItemData
    {
        public override void CreateIntoInvertory(PlayerInvertoryController playerInvertory)
        {
            Debug.Log("Body");
        }
    }
}