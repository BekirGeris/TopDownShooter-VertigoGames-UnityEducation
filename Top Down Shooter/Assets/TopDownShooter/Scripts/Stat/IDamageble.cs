using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stat
{ 
    public static class DamagebleHelper
    {
        public static Dictionary<int, IDamageble> Damagebles = new Dictionary<int, IDamageble>();
        public static void InitializeDamageble(this IDamageble damageble)
        {
            Damagebles.Add(damageble.InstanceId, damageble);
        }
    }
    public interface IDamageble
    {
        int InstanceId { get; }
        void Damage(float dmg);
    }
}