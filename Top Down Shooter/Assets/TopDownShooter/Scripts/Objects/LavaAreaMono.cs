using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Invertory;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Objects
{
    public class LavaAreaMono : MonoBehaviour, IDamage
    {
        [SerializeField] private float _damege;
        public float Damage { get { return _damege; } }

        [Range(0.1f, 2)]
        [SerializeField] private float _armorPenetration;
        public float ArmorPenetration { get { return _armorPenetration; } }

        [SerializeField] private float _timeBaseDamage = 5;
        public float TimeBaseDamage { get { return _timeBaseDamage; } }

        [SerializeField] private float _timedBaseDamageDuration = 3;
        public float TimedBaseDamageDuration { get { return _timedBaseDamageDuration; } }
        private void OnTriggerEnter(Collider collider)
        {
            var colliderInstanceId = collider.GetInstanceID();
            if (DamagebleHelper.Damagebles.ContainsKey(colliderInstanceId))
            {
                DamagebleHelper.Damagebles[colliderInstanceId].Damage(this);
            }
        }
    }
}
