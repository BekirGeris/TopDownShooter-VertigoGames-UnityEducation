using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory
{
    public enum InvertoryItemDataType { Canon, Body}
    public abstract class AbstractPlayerInvertoryItemData : ScriptableObject
    {
        [SerializeField] private string _itemId;

        public abstract void CreateIntoInvertory(PlayerInvertoryController playerInvertory);
    }
}
