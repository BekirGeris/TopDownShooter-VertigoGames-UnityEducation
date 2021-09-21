using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{ 
    public class AbstracScriptabletManager<T> : ScriptableObject
    {
        public static T Instance;
    }
}