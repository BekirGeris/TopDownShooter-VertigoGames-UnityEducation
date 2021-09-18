using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory 
{ 
    public class PlayerInvertoryCanonItemMono : AbstractPlayerInvertoryItemMono
    {
        [SerializeField] private Transform _canonShootPoint;
        public void Shoot()
        {
            // ayr�ca efektler ve benzeri ekleyin
            ScriptableShootManeger.Instance.Shoot(_canonShootPoint.position, _canonShootPoint.forward);
        }
    }
}

