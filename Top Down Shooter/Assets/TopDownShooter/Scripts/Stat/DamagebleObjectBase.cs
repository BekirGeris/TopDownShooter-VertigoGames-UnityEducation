using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Stat
{
    public class DamagebleObjectBase : MonoBehaviour, IDamageble
    {
        [SerializeField] Collider _collider;
        public float Health = 100;
        public int InstanceId { get; private set; }
        public ReactiveCommand OnDeath = new ReactiveCommand();
        protected void Awake()
        {
            InstanceId = _collider.GetInstanceID();
            this.InitializeDamageble();
        }
        public virtual void Damage(float dmg)
        {
            Health -= dmg;
            Debug.Log("Damage: " + dmg + "Health: " + Health);
            if(Health < 0)
            {
                OnDeath.Execute();
                Destroy(gameObject);
            }
        }

        protected virtual void Destroy()
        {
            this.DestroyDamageble();
        }
    }
}