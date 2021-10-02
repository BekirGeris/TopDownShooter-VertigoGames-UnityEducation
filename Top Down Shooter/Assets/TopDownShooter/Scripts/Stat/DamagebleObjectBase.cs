using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Invertory;

namespace TopDownShooter.Stat
{
    public class DamagebleObjectBase : MonoBehaviour, IDamageble
    {
        [SerializeField] Collider _collider;
        public float Health = 10;
        public float Armor = 10;
        private bool _isDead = false;
        public int InstanceId { get; private set; }
        public ReactiveCommand OnDeath = new ReactiveCommand();
        protected virtual void Destroy()
        {
            this.DestroyDamageble();
        }

        protected void Awake()
        {
            InstanceId = _collider.GetInstanceID();
            this.InitializeDamageble();
        }
        public virtual void Damage(IDamage dmg)
        {
            if(dmg.TimeBaseDamage > 0)
            {
                StartCoroutine(TimedBaseDamage(dmg.TimeBaseDamage, dmg.TimedBaseDamageDuration));
            }
            if(Armor > 0)
            {
                Armor -= (dmg.Damage * dmg.ArmorPenetration);  
            }
            else
            {
                Health -= dmg.Damage;
                Health += Armor;
                CheckHealth();
            }
        }
        private IEnumerator TimedBaseDamage(float damage, float totalDuration)
        {
            while (totalDuration > 0)
            {
                yield return new WaitForSeconds(1);
                totalDuration -= 1;
                Health -= damage;
                CheckHealth();
            }
        }
        private void CheckHealth()
        {
            if (_isDead)
            {
                return; 
            }
            if (Health <= 0)
            {
                StopAllCoroutines();
                _isDead = true;
                OnDeath.Execute();
                Destroy(gameObject);
            }
        }
    }
}