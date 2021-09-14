using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public void Shoot()
        {
            Debug.Log("ScriptableShootManeger shoot");
        }
    }
}