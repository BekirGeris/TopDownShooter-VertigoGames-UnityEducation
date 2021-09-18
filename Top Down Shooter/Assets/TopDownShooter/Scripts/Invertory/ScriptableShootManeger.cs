using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Stat;

namespace TopDownShooter.Invertory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Invertory/ScriptableShootManeger")]
    public class ScriptableShootManeger : AbstractScriptabletManager<ScriptableShootManeger>
    {
        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("ScriptableShootManeger active");
        }

        public override void Destroy()
        {
            base.Destroy();
            Debug.Log("ScriptableShootManeger destroy");
        }
        public void Shoot(Vector3 origin, Vector3 direction)
        {
            RaycastHit rHit;
            var physics = Physics.Raycast(origin, direction, out rHit);
            if (physics)
            {
                Debug.Log("Collider : " + rHit.collider.name);
            }
            int colliderInstanceId = rHit.collider.GetInstanceID();
            if (DamagebleHelper.Damagebles.ContainsKey(colliderInstanceId))
            {
                DamagebleHelper.Damagebles[colliderInstanceId].Damage(5);
            }
        }
    }
}