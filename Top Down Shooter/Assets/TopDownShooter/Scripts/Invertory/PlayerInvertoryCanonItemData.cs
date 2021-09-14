using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Invertory/Player Invertory Conan Data")]
    public class PlayerInvertoryCanonItemData : AbstractPlayerInvertoryItemData
    {
        public override void CreateIntoInvertory(PlayerInvertoryController playerInvertory)
        {
            Debug.Log("Canon");
        }
    }
}