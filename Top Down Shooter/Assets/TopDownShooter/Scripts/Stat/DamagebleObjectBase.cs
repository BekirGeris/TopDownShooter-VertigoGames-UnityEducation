using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stat
{
    public class DamagebleObjectBase : MonoBehaviour, IDamageble
    {
        [SerializeField] Collider _collider;
        public float Health = 100;
        public int InstanceId { get; private set; }
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
                Destroy(gameObject);
            }
        }

        protected virtual void Destroy()
        {
            this.DestroyDamageble();
        }
    }
}