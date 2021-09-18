using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stat
{
    public class DamagebleObjectBase : MonoBehaviour, IDamageble
    {
        [SerializeField] Collider _collider;
        public int InstanceId { get; private set; }
        protected void Awake()
        {
            InstanceId = _collider.GetInstanceID();
            this.InitializeDamageble();
        }
        public virtual void Damage(float dmg)
        {
            Debug.Log("Damage: " + dmg);
        }
    }
}