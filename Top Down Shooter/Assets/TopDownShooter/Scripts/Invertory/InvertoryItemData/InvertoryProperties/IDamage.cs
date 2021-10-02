using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory
{ 
    public interface IDamage 
    {
        float Damage { get; }
        float ArmorPenetration { get; }
        float TimedBaseDamageDuration { get; }
        float TimeBaseDamage { get; }
    }
}