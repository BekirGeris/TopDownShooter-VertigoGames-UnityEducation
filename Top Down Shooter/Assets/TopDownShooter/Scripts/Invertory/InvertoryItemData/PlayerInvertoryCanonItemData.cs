using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Invertory/Player Invertory Conan Data")]
    public class PlayerInvertoryCanonItemData : AbstractPlayerInvertoryItemData<PlayerInvertoryCanonItemMono>
    {
        [SerializeField] private float _damege;
        public float Damage { get { return _damege; } }
        public override void CreateIntoInvertory(PlayerInvertoryController playerInvertory)
        {
            InstalLiateAndInitialPrefab(playerInvertory.parent);
            Debug.Log("Canon");
        }

        public void Shoot()
        {
            _instantiated.Shoot();
        }
    }
}