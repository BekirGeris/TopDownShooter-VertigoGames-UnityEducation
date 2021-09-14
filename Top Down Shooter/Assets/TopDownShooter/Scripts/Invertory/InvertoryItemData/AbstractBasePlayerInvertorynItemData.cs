using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory
{
    public abstract class AbstractBasePlayerInvertorynItemData : ScriptableObject
    {
        public abstract void CreateIntoInvertory(PlayerInvertoryController playerInvertory);
        public virtual void Destroy()
        {
            Destroy(this);
        }
    }
}