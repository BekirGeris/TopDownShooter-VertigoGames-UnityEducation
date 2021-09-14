using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Invertory/Player Invertory Body Data")]
    public class PlayerInvertoryBodyItemData : AbstractPlayerInvertoryItemData<PlayerInvertoryBodyItemMono>
    {
        public override void CreateIntoInvertory(PlayerInvertoryController playerInvertory)
        {
            var instantLated = InstalLiateAndInitialPrefab(playerInvertory.parent);
            Debug.Log("Body");
        }
    }
}