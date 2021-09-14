using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class AbstractScriptabletManager<T> : AbstractBaseScriptabletManager where T : AbstractScriptabletManager<T>
    {
        public static T Instance;
        public override void Initialize()
        {
            base.Initialize();
            Instance = this as T;
        }
        public override void Destroy()
        {
            base.Destroy();

        }
    }
}
